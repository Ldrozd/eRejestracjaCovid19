using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace eRejestracjaCovid19
{
    public class HttpClientWrapper
    {
        private readonly HttpClient _httpClient;

        public HttpClientWrapper(string cookie, string token)
        {
            _httpClient = new HttpClient();
            _httpClient.DefaultRequestHeaders.Add("cookie", cookie);
            _httpClient.DefaultRequestHeaders.Add("x-csrf-token", token);
            _httpClient.DefaultRequestHeaders.ExpectContinue = false;
        }

        public Task<HttpResponseMessage> FindAsync()
        {
            StringContent stringContent = LoadJsonFile("find.json");

            return _httpClient.PostAsync("https://pacjent.erejestracja.ezdrowie.gov.pl/api/calendarSlots/find", stringContent);
        }

        public Task<HttpResponseMessage> ConfirmAsync(string id)
        {
            StringContent stringContent = LoadJsonFile("confirm.json");

            return _httpClient.PostAsync($"https://pacjent.erejestracja.ezdrowie.gov.pl/api/calendarSlot/{id}/confirm", stringContent);
        }

        private StringContent LoadJsonFile(string nameFile)
        {
            var json = JsonFileReader.Read(nameFile);

            var stringContent = new StringContent(json, UnicodeEncoding.UTF8, "application/json");
            return stringContent;
        }

    }
}