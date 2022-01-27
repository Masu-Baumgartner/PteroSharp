using Newtonsoft.Json;

namespace PteroSharp.ApiModels.Server
{
    public class UpdateServerDetailsRequest
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("user")]
        public long User { get; set; }

        [JsonProperty("external_id")]
        public string ExternalId { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }
    }
}
