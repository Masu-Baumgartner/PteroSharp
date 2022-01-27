using Newtonsoft.Json;

namespace PteroSharp.ApiModels.Server
{
    public class GetServerDetailsResponse
    {
        [JsonProperty("object")]
        public string Object { get; set; }

        [JsonProperty("attributes")]
        public ServerAttributes Attributes { get; set; }
    }
}
