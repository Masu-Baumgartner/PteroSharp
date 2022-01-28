using System;

using PteroSharp.ApiModels.Server;
using PteroSharp.Utils;

namespace PteroSharp
{
    public class PteroServer
    {
        #region Backlink to client
        public PteroClient Client { get; private set; }
        #endregion

        public long Id { get; private set; }
        public string ExternalId { get; private set; }
        public Guid Uuid { get; private set; }
        public string Identifier { get; private set; }
        public string Name
        {
            get
            {
                return _Name;
            }
            set
            {
                _Name = value;
                UpdateDetails();
            }
        }
        private string _Name { get; set; }
        public string Description
        {
            get
            {
                return _Description;
            }
            set
            {
                _Description = value;
                UpdateDetails();
            }
        }
        private string _Description { get; set; }
        public bool Suspended
        {
            get
            {
                return _Suspended;
            }
            set
            {
                _Suspended = value;
                UpdateSuspended();
            }
        }
        private bool _Suspended { get; set; }
        public Limits Limits
        {
            get
            {
                return _Limits;
            }
            set
            {
                _Limits = value;
                UpdateBuild();
            }
        }
        private Limits _Limits { get; set; }
        public FeatureLimits FeatureLimits
        {
            get
            {
                return _FeatureLimits;
            }
            set
            {
                _FeatureLimits = value;
                UpdateBuild();
            }
        }
        private FeatureLimits _FeatureLimits { get; set; }
        public long User
        {
            get
            {
                return _User;
            }
            set
            {
                _User = value;
                UpdateDetails();
            }
        }
        private long _User { get; set; }
        public long Node { get; set; }
        public long Allocation
        {
            get
            {
                return _Allocation;
            }
            set
            {
                _Allocation = value;
                UpdateBuild();
            }
        }
        private long _Allocation { get; set; }
        public long Nest { get; set; }
        public long Egg
        {
            get
            {
                return _Egg;
            }
            set
            {
                _Egg = value;
                UpdateStartup();
            }
        }
        private long _Egg { get; set; }
        public Container Container
        {
            get
            {
                return _Container;
            }
            set
            {
                _Container = value;
                UpdateStartup();
            }
        }
        private Container _Container { get; set; }
        public CurrentStatus Status { get; set; }
        public PteroConsole Console
        {
            get
            {
                if (_Console == null)
                    _Console = new PteroConsole(this);

                return _Console;
            }
        }

        private PteroConsole _Console { get; set; }


        public static PteroServer FromServerAttributes(ServerAttributes attributes, PteroClient client)
        {
            var result = new PteroServer();

            result.Id = attributes.Id;
            result.Identifier = attributes.Identifier;
            result._Limits = attributes.Limits;
            result._FeatureLimits = attributes.FeatureLimits;
            result._Name = attributes.Name;
            result.Nest = attributes.Nest;
            result.Node = attributes.Node;
            result._Suspended = attributes.Suspended;
            result._User = attributes.User;
            result.Uuid = attributes.Uuid;
            result._Allocation = attributes.Allocation;
            result._Container = attributes.Container;
            result._Egg = attributes.Egg;

            result.Status = new CurrentStatus()
            {
                UsedServer = result
            };

            result.Client = client;

            return result;
        }

        public void Delete()
        {
            PterodactylApiHelper.Delete(
                Client.AppPool,
                Client.PterodactylUrl,
                "api/application/servers/" + Id,
                null,
                out _
                );
        }

        public void DeleteForce()
        {
            PterodactylApiHelper.Delete(
                Client.AppPool,
                Client.PterodactylUrl,
                "api/application/servers/" + Id + "/force",
                null,
                out _
                );
        }

        private void UpdateBuild()
        {
            var request = new UpdateServerBuildRequest()
            {
                Allocation = _Allocation,
                Cpu = _Limits.Cpu,
                Disk = _Limits.Disk,
                FeatureLimits = _FeatureLimits,
                Io = _Limits.Io,
                Memory = _Limits.Memory,
                Swap = _Limits.Swap,
                Threads = _Limits.Threads
            };

            PterodactylApiHelper.Patch(
                Client.AppPool,
                Client.PterodactylUrl,
                "api/application/servers/" + Id + "/build",
                request,
                out _
                );
        }

        private void UpdateDetails()
        {
            var request = new UpdateServerDetailsRequest()
            {
                Description = _Description,
                ExternalId = ExternalId,
                Name = _Name,
                User = _User
            };

            PterodactylApiHelper.Patch(
                Client.AppPool,
                Client.PterodactylUrl,
                "api/application/servers/" + Id + "/details",
                request,
                out _
                );
        }

        private void UpdateSuspended()
        {
            if(_Suspended)
            {
                PterodactylApiHelper.Post(
                    Client.AppPool,
                    Client.PterodactylUrl,
                    "api/application/servers/" + Id + "/suspend",
                    null,
                    out _
                    );
            }
            else
            {
                PterodactylApiHelper.Post(
                    Client.AppPool,
                    Client.PterodactylUrl,
                    "api/application/servers/" + Id + "/unsuspend",
                    null,
                    out _
                    );
            }
        }

        private void UpdateStartup()
        {
            var request = new UpdateServerStartupRequest()
            {
                Egg = _Egg,
                Startup = _Container.StartupCommand,
                Environment = _Container.Environment,
                Image = _Container.Image,
                SkipScripts = false
            };

            PterodactylApiHelper.Patch(
                    Client.AppPool,
                    Client.PterodactylUrl,
                    "api/application/servers/" + Id + "/startup",
                    request,
                    out _
                    );
        }

        #region Power Actions

        public void Start()
        {
            try
            {
                PterodactylApiHelper.Post(
                    Client.ClientPool,
                    Client.PterodactylUrl,
                    "api/client/servers/" + Uuid + "/power",
                    new ChangePowerStateRequest()
                    {
                        Signal = "start"
                    },
                    out _
                    );
            }
            catch (Exception) { }
        }

        public void Stop()
        {
            try
            {
                PterodactylApiHelper.Post(
                    Client.ClientPool,
                    Client.PterodactylUrl,
                    "api/client/servers/" + Uuid + "/power",
                    new ChangePowerStateRequest()
                    {
                        Signal = "stop"
                    },
                    out _
                    );
            }
            catch (Exception) { }
        }

        public void Kill()
        {
            try
            {
                PterodactylApiHelper.Post(
                    Client.ClientPool,
                    Client.PterodactylUrl,
                    "api/client/servers/" + Uuid + "/power",
                    new ChangePowerStateRequest()
                    {
                        Signal = "kill"
                    },
                    out _
                    );
            }
            catch (Exception) { }
        }

        public void Restart()
        {
            try
            {
                PterodactylApiHelper.Post(
                    Client.ClientPool,
                    Client.PterodactylUrl,
                    "api/client/servers/" + Uuid + "/power",
                    new ChangePowerStateRequest()
                    {
                        Signal = "restart"
                    },
                    out _
                    );
            }
            catch (Exception) { }
        }

        #endregion

        public void EnterCommand(string cmd)
        {
            try
            {
                PterodactylApiHelper.Post(
                    Client.ClientPool,
                    Client.PterodactylUrl,
                    "api/client/servers/" + Uuid + "/command",
                    new SendCommandRequest()
                    {
                        Command = cmd
                    },
                    out _
                    );
            }
            catch (Exception) { }
        }

        public struct CurrentStatus
        {
            public PteroServer UsedServer { get; set; }
            public string State
            {
                get
                {
                    return PterodactylApiHelper.Get<GetServerResourceUsageResponse>(
                            UsedServer.Client.ClientPool,
                            UsedServer.Client.PterodactylUrl,
                            "api/client/servers/" + UsedServer.Uuid + "/resources",
                            null,
                            out _
                        ).Attributes.CurrentState;
                }
            }
            public bool Suspended
            {
                get
                {
                    return PterodactylApiHelper.Get<GetServerResourceUsageResponse>(
                            UsedServer.Client.ClientPool,
                            UsedServer.Client.PterodactylUrl,
                            "api/client/servers/" + UsedServer.Uuid + "/resources",
                            null,
                            out _
                        ).Attributes.IsSuspended;
                }
            }
            public long MemoryBytes
            {
                get
                {
                    return PterodactylApiHelper.Get<GetServerResourceUsageResponse>(
                            UsedServer.Client.ClientPool,
                            UsedServer.Client.PterodactylUrl,
                            "api/client/servers/" + UsedServer.Uuid + "/resources",
                            null,
                            out _
                        ).Attributes.Resources.MemoryBytes;
                }
            }
            public long CpuAbsolute
            {
                get
                {
                    return PterodactylApiHelper.Get<GetServerResourceUsageResponse>(
                            UsedServer.Client.ClientPool,
                            UsedServer.Client.PterodactylUrl,
                            "api/client/servers/" + UsedServer.Uuid + "/resources",
                            null,
                            out _
                        ).Attributes.Resources.CpuAbsolute;
                }
            }
            public long DiskBytes
            {
                get
                {
                    return PterodactylApiHelper.Get<GetServerResourceUsageResponse>(
                            UsedServer.Client.ClientPool,
                            UsedServer.Client.PterodactylUrl,
                            "api/client/servers/" + UsedServer.Uuid + "/resources",
                            null,
                            out _
                        ).Attributes.Resources.DiskBytes;
                }
            }
            public long NetworkRxBytes
            {
                get
                {
                    return PterodactylApiHelper.Get<GetServerResourceUsageResponse>(
                            UsedServer.Client.ClientPool,
                            UsedServer.Client.PterodactylUrl,
                            "api/client/servers/" + UsedServer.Uuid + "/resources",
                            null,
                            out _
                        ).Attributes.Resources.NetworkRxBytes;
                }
            }
            public long NetworkTxBytes
            {
                get
                {
                    return PterodactylApiHelper.Get<GetServerResourceUsageResponse>(
                            UsedServer.Client.ClientPool,
                            UsedServer.Client.PterodactylUrl,
                            "api/client/servers/" + UsedServer.Uuid + "/resources",
                            null,
                            out _
                        ).Attributes.Resources.NetworkTxBytes;
                }
            }
        }
    }
}
