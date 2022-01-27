using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace PteroSharp.ApiModels.Server
{
    public partial class ListServersResponse
    {
        [JsonProperty("object")]
        public string Object { get; set; }

        [JsonProperty("data")]
        public ListServersResponseDatum[] Data { get; set; }

        [JsonProperty("meta")]
        public Meta Meta { get; set; }
    }

    public partial class ListServersResponseDatum
    {
        [JsonProperty("object")]
        public string Object { get; set; }

        [JsonProperty("attributes")]
        public ServerAttributes Attributes { get; set; }
    }

    public partial class ServerAttributes
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("external_id")]
        public string ExternalId { get; set; }

        [JsonProperty("uuid")]
        public Guid Uuid { get; set; }

        [JsonProperty("identifier")]
        public string Identifier { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("suspended")]
        public bool Suspended { get; set; }

        [JsonProperty("limits")]
        public Limits Limits { get; set; }

        [JsonProperty("feature_limits")]
        public FeatureLimits FeatureLimits { get; set; }

        [JsonProperty("user")]
        public long User { get; set; }

        [JsonProperty("node")]
        public long Node { get; set; }

        [JsonProperty("allocation")]
        public long Allocation { get; set; }

        [JsonProperty("nest")]
        public long Nest { get; set; }

        [JsonProperty("egg")]
        public long Egg { get; set; }

        [JsonProperty("pack")]
        public object Pack { get; set; }

        [JsonProperty("container")]
        public Container Container { get; set; }

        [JsonProperty("updated_at")]
        public DateTimeOffset UpdatedAt { get; set; }

        [JsonProperty("created_at")]
        public DateTimeOffset CreatedAt { get; set; }

        [JsonProperty("relationships")]
        public Relationships Relationships { get; set; }
    }

    public partial class Container
    {
        [JsonProperty("startup_command")]
        public string StartupCommand { get; set; }

        [JsonProperty("image")]
        public string Image { get; set; }

        [JsonProperty("installed")]
        public bool Installed { get; set; }

        [JsonProperty("environment")]
        public Dictionary<string, string> Environment { get; set; }
    }

    public partial class FeatureLimits
    {
        [JsonProperty("databases")]
        public long Databases { get; set; }

        [JsonProperty("allocations")]
        public long Allocations { get; set; }

        [JsonProperty("backups")]
        public long Backups { get; set; }
    }

    public partial class Limits
    {
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
    }

    public partial class Relationships
    {
        [JsonProperty("databases")]
        public Databases Databases { get; set; }
    }

    public partial class Databases
    {
        [JsonProperty("object")]
        public string Object { get; set; }

        [JsonProperty("data")]
        public DatabasesDatum[] Data { get; set; }
    }

    public partial class DatabasesDatum
    {
        [JsonProperty("object")]
        public string Object { get; set; }

        [JsonProperty("attributes")]
        public DatabaseAttributes Attributes { get; set; }
    }

    public partial class DatabaseAttributes
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("server")]
        public long Server { get; set; }

        [JsonProperty("host")]
        public long Host { get; set; }

        [JsonProperty("database")]
        public string Database { get; set; }

        [JsonProperty("username")]
        public string Username { get; set; }

        [JsonProperty("remote")]
        public string Remote { get; set; }

        [JsonProperty("max_connections")]
        public long MaxConnections { get; set; }

        [JsonProperty("created_at")]
        public DateTimeOffset CreatedAt { get; set; }

        [JsonProperty("updated_at")]
        public DateTimeOffset UpdatedAt { get; set; }
    }
}
