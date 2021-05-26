using Newtonsoft.Json;
using System;

namespace eRejestracjaCovid19.Models
{
    public class ServicePoint
    {
        [JsonProperty("id")]
        public Guid Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("addressText")]
        public string AddressText { get; set; }

        [JsonProperty("mobility")]
        public string Mobility { get; set; }

    }
}