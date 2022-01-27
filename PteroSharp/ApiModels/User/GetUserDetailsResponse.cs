using Newtonsoft.Json;
using System;

namespace PteroSharp.ApiModels.User
{
    public partial class GetUserDetailsResponse
    {
        [JsonProperty("object")]
        public string Object { get; set; }

        [JsonProperty("attributes")]
        public UserAttributes Attributes { get; set; }
    }
}
