using Newtonsoft.Json;

namespace eRejestracjaCovid19.Models
{
    public class Settings
    {
        [JsonProperty("patient_sid")]
        public string PatientSid { get; set; }

        [JsonProperty("x-csrf-token")]
        public string XCsrfToken { get; set; }

        [JsonProperty("city")]
        public string City { get; set; }  
    }
}