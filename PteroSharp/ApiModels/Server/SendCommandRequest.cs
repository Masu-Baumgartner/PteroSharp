using Newtonsoft.Json;

namespace PteroSharp.ApiModels.Server
{
    public class SendCommandRequest
    {
        [JsonProperty("command")]
        public string Command { get; set; }
    }
}
