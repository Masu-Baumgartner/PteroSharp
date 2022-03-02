using Newtonsoft.Json;

namespace PteroSharp.ApiModels.Server.Console
{
    public partial class ServerStatusModel
    {
        [JsonProperty("memory_bytes")]
        public long MemoryBytes { get; set; }

        [JsonProperty("memory_limit_bytes")]
        public long MemoryLimitBytes { get; set; }

        [JsonProperty("cpu_absolute")]
        public double CpuAbsolute { get; set; }

        [JsonProperty("network")]
        public Network Network { get; set; }

        [JsonProperty("state")]
        public string State { get; set; }

        [JsonProperty("disk_bytes")]
        public long DiskBytes { get; set; }
    }

    public partial class Network
    {
        [JsonProperty("rx_bytes")]
        public long RxBytes { get; set; }

        [JsonProperty("tx_bytes")]
        public long TxBytes { get; set; }
    }
}
