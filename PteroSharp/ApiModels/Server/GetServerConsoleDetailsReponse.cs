using Newtonsoft.Json;

namespace PteroSharp.ApiModels.Server
{
    public partial class GetServerConsoleDetailsReponse
    {
        [JsonProperty("data")]
        public ConsoleDetailsData Data { get; set; }
    }

    public partial class ConsoleDetailsData
    {
        [JsonProperty("token")]
        public string Token { get; set; }

        [JsonProperty("socket")]
        public string Socket { get; set; }
    }
}
