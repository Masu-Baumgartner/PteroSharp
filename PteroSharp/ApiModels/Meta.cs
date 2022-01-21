
using Newtonsoft.Json;

// EndelonStore
// (C) Copyright Endelon Hosting 2021/2022
// https://endelon-hosting.de
// This project is closed source. If you are seeing this
// without permission you are acting illegal
//
// Author(s):
// Marcel-Baumgartner
// Dalk-Github
namespace PteroSharp.ApiModels
{
    public partial class Meta
    {
        [JsonProperty("pagination")]
        public Pagination Pagination { get; set; }
    }

    public partial class Pagination
    {
        [JsonProperty("total")]
        public long Total { get; set; }

        [JsonProperty("count")]
        public long Count { get; set; }

        [JsonProperty("per_page")]
        public long PerPage { get; set; }

        [JsonProperty("current_page")]
        public long CurrentPage { get; set; }

        [JsonProperty("total_pages")]
        public long TotalPages { get; set; }
    }
}
