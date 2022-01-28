using Newtonsoft.Json;

namespace PteroSharp.ApiModels.Server
{
    public partial class GetServerResourceUsageResponse
    {
        [JsonProperty("object")]
        public string Object { get; set; }

        [JsonProperty("attributes")]
        public ResourceAttributes Attributes { get; set; }
    }

    public partial class ResourceAttributes
    {
        [JsonProperty("current_state")]
        public string CurrentState { get; set; }

        [JsonProperty("is_suspended")]
        public bool IsSuspended { get; set; }

        [JsonProperty("resources")]
        public Resources Resources { get; set; }
    }

    public partial class Resources
    {
        [JsonProperty("memory_bytes")]
        public long MemoryBytes { get; set; }

        [JsonProperty("cpu_absolute")]
        public long CpuAbsolute { get; set; }

        [JsonProperty("disk_bytes")]
        public long DiskBytes { get; set; }

        [JsonProperty("network_rx_bytes")]
        public long NetworkRxBytes { get; set; }

        [JsonProperty("network_tx_bytes")]
        public long NetworkTxBytes { get; set; }
    }
}
