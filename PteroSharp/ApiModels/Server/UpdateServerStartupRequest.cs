using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace PteroSharp.ApiModels.Server
{
    public partial class UpdateServerStartupRequest
    {
        [JsonProperty("startup")]
        public string Startup { get; set; }

        [JsonProperty("environment")]
        public Dictionary<string, string> Environment { get; set; }

        [JsonProperty("egg")]
        public long Egg { get; set; }

        [JsonProperty("image")]
        public string Image { get; set; }

        [JsonProperty("skip_scripts")]
        public bool SkipScripts { get; set; }
    }
}
