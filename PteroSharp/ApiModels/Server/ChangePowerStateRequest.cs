using Newtonsoft.Json;

namespace PteroSharp.ApiModels.Server
{
    public class ChangePowerStateRequest
    {
        [JsonProperty("signal")]
        public string Signal { get; set; }
    }
}
