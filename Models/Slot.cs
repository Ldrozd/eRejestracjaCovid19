using Newtonsoft.Json;
using System;

namespace eRejestracjaCovid19.Models
{
    public class Slot
    {
        [JsonProperty("id")]
        public Guid Id { get; set; }

        [JsonProperty("startAt")]
        public DateTimeOffset StartAt { get; set; }

        [JsonProperty("duration")]
        public long Duration { get; set; }

        [JsonProperty("servicePoint")]
        public ServicePoint ServicePoint { get; set; }

        [JsonProperty("vaccineType")]
        public string VaccineType { get; set; }

        [JsonProperty("mobility")]
        public string Mobility { get; set; }

        [JsonProperty("dose")]
        public long Dose { get; set; }

        [JsonProperty("status")]
        public Status Status { get; set; }
    }
}