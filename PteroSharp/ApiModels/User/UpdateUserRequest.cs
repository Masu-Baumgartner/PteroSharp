using Newtonsoft.Json;

namespace PteroSharp.ApiModels.User
{
    public partial class UpdateUserRequest
    {
        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("username")]
        public string Username { get; set; }

        [JsonProperty("first_name")]
        public string FirstName { get; set; }

        [JsonProperty("last_name")]
        public string LastName { get; set; }

        [JsonProperty("language")]
        public string Language { get; set; }

        [JsonProperty("password")]
        public string Password { get; set; }
    }
}
