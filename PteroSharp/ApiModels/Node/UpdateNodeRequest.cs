using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace PteroSharp.ApiModels.Node
{
    public partial class UpdateNodeRequest
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("location_id")]
        public long LocationId { get; set; }

        [JsonProperty("fqdn")]
        public string Fqdn { get; set; }

        [JsonProperty("scheme")]
        public string Scheme { get; set; }

        [JsonProperty("behind_proxy")]
        public bool BehindProxy { get; set; }

        [JsonProperty("maintenance_mode")]
        public bool MaintenanceMode { get; set; }

        [JsonProperty("memory")]
        public long Memory { get; set; }

        [JsonProperty("memory_overallocate")]
        public long MemoryOverallocate { get; set; }

        [JsonProperty("disk")]
        public long Disk { get; set; }

        [JsonProperty("disk_overallocate")]
        public long DiskOverallocate { get; set; }

        [JsonProperty("upload_size")]
        public long UploadSize { get; set; }

        [JsonProperty("daemon_sftp")]
        public long DaemonSftp { get; set; }

        [JsonProperty("daemon_listen")]
        public long DaemonListen { get; set; }
    }
}
