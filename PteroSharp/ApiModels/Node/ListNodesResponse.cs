using Newtonsoft.Json;

using System;

namespace PteroSharp.ApiModels.Node
{
    public partial class ListNodesResponse
    {
        [JsonProperty("object")]
        public string Object { get; set; }

        [JsonProperty("data")]
        public NodeDatum[] Data { get; set; }

        [JsonProperty("meta")]
        public Meta Meta { get; set; }
    }

    public partial class NodeDatum
    {
        [JsonProperty("object")]
        public string Object { get; set; }

        [JsonProperty("attributes")]
        public NodeAttributes Attributes { get; set; }
    }

    public partial class NodeAttributes
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("uuid")]
        public Guid Uuid { get; set; }

        [JsonProperty("public")]
        public bool Public { get; set; }

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

        [JsonProperty("daemon_listen")]
        public long DaemonListen { get; set; }

        [JsonProperty("daemon_sftp")]
        public long DaemonSftp { get; set; }

        [JsonProperty("daemon_base")]
        public string DaemonBase { get; set; }

        [JsonProperty("created_at")]
        public DateTimeOffset CreatedAt { get; set; }

        [JsonProperty("updated_at")]
        public DateTimeOffset UpdatedAt { get; set; }
    }
}
