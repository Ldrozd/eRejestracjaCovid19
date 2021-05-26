using eRejestracjaCovid19.Models;
using Newtonsoft.Json;
using System;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace eRejestracjaCovid19
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var settingsJson = JsonFileReader.Read("settings.json");
            var setting = JsonConvert.DeserializeObject<Settings>(settingsJson);

            var httpClientWrapper = new HttpClientWrapper($"patient_sid={setting.PatientSid}; Path=/; Domain=pacjent.erejestracja.ezdrowie.gov.pl; HttpOnly; Secure", setting.XCsrfToken);

            var continueSearch = true;

            var delay = 1000;

            Console.WriteLine("Searching free slot");

            while (continueSearch)
            {
                var authResult = await httpClientWrapper.FindAsync();
                var result = await authResult.Content.ReadAsStringAsync();

                if (authResult.StatusCode == HttpStatusCode.Unauthorized)
                {
                    throw new Exception("Unauthorized!");
                }

                if (authResult.StatusCode == HttpStatusCode.TooManyRequests)
                {
                    Console.WriteLine("Too many requests!");
                }

                var slots = JsonConvert.DeserializeObject<Slots>(result);

                if (slots != null && slots.List != null)
                {
                    var filteredSlots = slots.List.Where(c => c.ServicePoint.AddressText.Contains(setting.City)).ToList();
                    Console.WriteLine($"Found {filteredSlots.Count} free slots");

                    foreach (var slot in filteredSlots)
                    {
                        var confirmResult = await httpClientWrapper.ConfirmAsync(slot.Id.ToString());

                        Console.WriteLine($"Registered in {slot.ServicePoint.Name} at {slot.StartAt.LocalDateTime.ToString()}");

                        continueSearch = false;
                        break;
                    }

                    await Task.Delay(delay);
                }
            }
        }
    }
}