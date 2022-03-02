using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using Newtonsoft.Json;

using PteroSharp.ApiModels.Server;
using PteroSharp.ApiModels.Server.Console;
using PteroSharp.Utils;

namespace PteroSharp
{
    public class PteroConsole
    {
        public PteroServer Server { get; set; }

        // This feature is originally made by DalkGithub in our project EndelonPanel
        public bool FormatAsHtml { get; set; }

        public ReadOnlyCollection<string> Messages
        {
            get
            {
                return ConsoleMessages.AsReadOnly();
            }
        }

        public bool IsConnected
        {
            get
            {
                return (WebSocket.State == WebSocketState.Open);
            }
        }
        private int Subscribers { get; set; } = 0;
        private List<string> ConsoleMessages { get; set; }
        private bool IsFirstStatus { get; set; } = true;
        public EventHandler OnConsoleContentChanged { get; set; }
        public EventHandler<string> OnConsoleContentAdded { get; set; }
        public EventHandler<string> OnServerStateChanged { get; set; }
        public EventHandler<long> OnServerCpuChanged { get; set; }
        public EventHandler<long> OnServerMemoryChanged { get; set; }
        public EventHandler<long> OnServerDiskChanged { get; set; }

        #region Websocket Things
        private Task WebSocketTask { get; set; }
        private ClientWebSocket WebSocket { get; set; }
        private CancellationToken CancellationToken { get; set; }
        #endregion

        public PteroConsole(PteroServer server)
        {
            Server = server;
            CancellationToken = new CancellationToken();
            WebSocket = new ClientWebSocket();
        }

        public void Subscribe()
        {
            Subscribers++;

            if(!IsConnected && WebSocket.State != WebSocketState.Connecting)
            {
                Reconnect();
            }
        }

        public void Unsubscribe()
        {
            Subscribers--;

            if (Subscribers < 0)
                Subscribers = 0;

            if(Subscribers == 0)
            {
                if (WebSocket == null)
                {
                    WebSocket = new ClientWebSocket();
                }

                if (WebSocket.State == WebSocketState.Open
                    || WebSocket.State == WebSocketState.Connecting)
                {
                    WebSocket.CloseAsync(WebSocketCloseStatus.Empty, null, CancellationToken).Wait();
                }
            }
        }

        private void Reconnect()
        {
            if(WebSocket == null)
            {
                WebSocket = new ClientWebSocket();
            }

            if(WebSocket.State == WebSocketState.Open
                || WebSocket.State == WebSocketState.Connecting)
            {
                WebSocket.CloseAsync(WebSocketCloseStatus.Empty, null, CancellationToken).Wait();
            }

            var cd = PterodactylApiHelper.Get<GetServerConsoleDetailsReponse>(
                    Server.Client.ClientPool,
                    Server.Client.PterodactylUrl,
                    "api/client/servers/" + Server.Uuid + "/websocket",
                    null,
                    out _
                );

            WebSocket.Options.SetRequestHeader("Authorization", "Bearer " + cd.Data.Token);
            WebSocket.Options.SetRequestHeader("Origin", Server.Client.PterodactylUrl);

            IsFirstStatus = true;

            if (ConsoleMessages == null)
                ConsoleMessages = new List<string>();

            lock (ConsoleMessages)
            {
                ConsoleMessages.Clear();
            }

            WebSocketTask = new Task(() =>
            {
                WebSocket.ConnectAsync(new System.Uri(cd.Data.Socket), CancellationToken).Wait();

                if(WebSocket.State == WebSocketState.Closed
                    || WebSocket.State == WebSocketState.Aborted)
                {
                    ConsoleMessages.Add("Cannot connect to server console");
                }

                var auth = new SendBaseRequest()
                {
                    Event = "auth",
                    Args = new List<string>()
                };

                auth.Args.Add(cd.Data.Token);

                Send(JsonConvert.SerializeObject(auth)).Wait();

                while (!CancellationToken.IsCancellationRequested && (WebSocket.State == WebSocketState.Open || WebSocket.State == WebSocketState.Connecting))
                {
                    string read = Receive().Result;

                    if(Subscribers <= 0)
                    {
                        WebSocket.CloseAsync(WebSocketCloseStatus.Empty, null, CancellationToken).Wait();
                        return;
                    }

                    var readevent = JsonConvert.DeserializeObject<ReceiveBaseResponse>(read);

                    switch(readevent.Event)
                    {
                        case "auth success":
                            var msg = "Console: Authenicated";
                            ConsoleMessages.Add(msg);
                            OnConsoleContentAdded?.Invoke(this, msg);
                            OnConsoleContentChanged?.Invoke(this, EventArgs.Empty);
                            break;

                        case "status":
                            if(IsFirstStatus)
                            {
                                IsFirstStatus = false;

                                var sl = new SendBaseRequest()
                                {
                                    Event = "send logs",
                                    Args = new List<string>()
                                };

                                Send(JsonConvert.SerializeObject(sl)).Wait();
                            }

                            OnServerStateChanged?.Invoke(this, readevent.Args[0]);
                            break;

                        case "console output":

                            string line1 = readevent.Args[0];

                            ConsoleMessages.Add(line1);
                            OnConsoleContentAdded?.Invoke(this, line1);
                            OnConsoleContentChanged?.Invoke(this, EventArgs.Empty);

                            break;

                        case "token expiring":

                            string line2 = "Token expiring. Reconnecting";
                            ConsoleMessages.Add(line2);
                            OnConsoleContentAdded?.Invoke(this, line2);
                            OnConsoleContentChanged?.Invoke(this, EventArgs.Empty);

                            Reconnect();

                            break;
                        case "stats":

                            var ri = JsonConvert.DeserializeObject<ServerStatusModel>(readevent.Args[0]);

                            OnServerCpuChanged?.Invoke(this, (long)ri.CpuAbsolute);
                            OnServerDiskChanged?.Invoke(this, ri.DiskBytes);
                            OnServerMemoryChanged?.Invoke(this, ri.MemoryBytes);

                            break;
                        default:
                            string line3 = "Unknown state: " + readevent.Event;
                            ConsoleMessages.Add(line3);
                            OnConsoleContentAdded?.Invoke(this, line3);
                            OnConsoleContentChanged?.Invoke(this, EventArgs.Empty);
                            break;
                    }
                }

                ConsoleMessages.Add("Console disconnected");
            });

            WebSocketTask.Start();
        }

        #region Read / Write

        private async Task<string> Receive()
        {
            ArraySegment<byte> receivedBytes = new(new byte[1024]);
            WebSocketReceiveResult result = await WebSocket.ReceiveAsync(receivedBytes, CancellationToken);
            return Encoding.UTF8.GetString(receivedBytes.Array, 0, result.Count);
        }

        private async Task Send(string message)
        {
            if (WebSocket.State == WebSocketState.Open)
            {
                byte[] byteContentBuffer = Encoding.UTF8.GetBytes(message);
                await WebSocket.SendAsync(new ArraySegment<byte>(byteContentBuffer), WebSocketMessageType.Text, true, CancellationToken);
            }
        }

        #endregion
    }
}
