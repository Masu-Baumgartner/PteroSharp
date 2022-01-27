using Newtonsoft.Json;

namespace PteroSharp.ApiModels.Server
{
    public partial class UpdateServerBuildRequest
    {
        [JsonProperty("allocation")]
        public long Allocation { get; set; }

        [JsonProperty("memory")]
        public long Memory { get; set; }

        [JsonProperty("swap")]
        public long Swap { get; set; }

        [JsonProperty("disk")]
        public long Disk { get; set; }

        [JsonProperty("io")]
        public long Io { get; set; }

        [JsonProperty("cpu")]
        public long Cpu { get; set; }

        [JsonProperty("threads")]
        public object Threads { get; set; }

        [JsonProperty("feature_limits")]
        public FeatureLimits FeatureLimits { get; set; }
    }
}
