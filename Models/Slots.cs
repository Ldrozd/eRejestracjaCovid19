using Newtonsoft.Json;

namespace eRejestracjaCovid19.Models
{
    public class Slots
    {
        [JsonProperty("list")]
        public Slot[] List { get; set; }
    }
}