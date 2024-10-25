using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using TollFeeCalculator;
using Newtonsoft.Json;
using System.Xml.Linq;


namespace TheCarTolls
{
    class program
    {
        private static readonly HttpClient client = new HttpClient();

        static async Task Main(string[] args)
        {
            Car car = new Car();
            Motorbike motorbike = new Motorbike();
            Tractor tractor = new Tractor();
            Emergency emergency = new Emergency();
            Diplomat diplomat = new Diplomat();
            Foreign foreign = new Foreign();
            Military military = new Military();

            // Skriv in registreringsnumret för bilen
            //string regNumber = "CRG019"; // Exempel på registreringsnummer
            //await GetVehicleInfoAsync(regNumber);

            // Exempel på hur du kan använda IVehicle-interface
            //IVehicle someVehicle = car; // Car implementerar IVehicle
            //Console.WriteLine($"Vehicle type: {someVehicle.GetVehicleType()}");

            // Exempel på hur du kan använda TollCalculator
            TollCalculator tollCalculator = new TollCalculator();
            DateTime[] dates = { DateTime.Now, DateTime.Now.AddHours(1), DateTime.Now.AddHours(2) };
            // Anropa GetTollFee-metoden
            int totalTollCar = tollCalculator.GetTollFee(car, dates);
            int totalTollMotorbike = tollCalculator.GetTollFee(motorbike, dates);
            int totalTollTractor = tollCalculator.GetTollFee(tractor, dates);
            int totalTollEmergency = tollCalculator.GetTollFee(emergency, dates);
            int totalTollDiplomat = tollCalculator.GetTollFee(diplomat, dates);
            int totalTollForeign = tollCalculator.GetTollFee(foreign, dates);
            int totalTollMilitary = tollCalculator.GetTollFee(military, dates);

            // Visa resultat
            var date = DateTime.Now;
            Console.WriteLine($"{Environment.NewLine}Hello, on {date:d} at {date:t}!");

            Console.WriteLine($"Total toll for Car:       for today Now: {dates[0]} = {totalTollCar} kr");
            Console.WriteLine($"Total toll for Motorbike: for today Now: {dates[0]} = {totalTollMotorbike} kr");
            Console.WriteLine($"Total toll for Tractor:   for today Now: {dates[0]} = {totalTollTractor} kr");
            Console.WriteLine($"Total toll for Emergency: for today Now: {dates[0]} = {totalTollEmergency} kr");
            Console.WriteLine($"Total toll for Diplomat:  for today Now: {dates[0]} = {totalTollDiplomat} kr");
            Console.WriteLine($"Total toll for Foreign:   for today Now: {dates[0]} = {totalTollForeign} kr");
            Console.WriteLine($"Total toll for Military:  for today Now: {dates[0]} = {totalTollMilitary} kr");

            // Testfall 1: Skattefri dag
            Console.WriteLine("------------------------------------------------------------------------");
            DateTime[] exemptDay = { new DateTime(2024, 1, 1, 8, 0, 0) };
            int toll1 = tollCalculator.GetTollFee(car, exemptDay);
            Console.WriteLine($"Testfall 1: Skattefri dag: Datum är {exemptDay[0]}, Den dag är en helgdag i Sverige! Trängselskatt = {toll1} kr");

            // Testfall 2: Skattefri tidpunkt
            Console.WriteLine("------------------------------------------------------------------------");
            DateTime[] exemptTime = { new DateTime(2024, 1, 2, 3, 0, 0) };
            int toll2 = tollCalculator.GetTollFee(car, exemptTime);
            Console.WriteLine($"Testfall 2: Skattefri tidpunkt: Tidpunkt är {exemptTime[0]}, Trängselskatt = {toll2} kr");

            // Testfall 3: Normal tidpunkt för car
            Console.WriteLine("------------------------------------------------------------------------");
            DateTime[] normalTime = { new DateTime(2024, 1, 2, 6, 0, 0) };
            int toll3 = tollCalculator.GetTollFee(car, normalTime);
            Console.WriteLine($"Testfall 3: Normal tidpunkt för car är {normalTime[0]}: Trängselskatt = {toll3} kr");

            // Testfall 4: Max Total Fee för car
            Console.WriteLine("------------------------------------------------------------------------");
            DateTime[] multiTime = new DateTime[24];
            DateTime currentDate = new DateTime(2024, 1, 22); 

            for (int hour = 0; hour < 24; hour++)
            {
                multiTime[hour] = currentDate.AddHours(hour);
            }
            int toll4 = tollCalculator.GetTollFee(car, multiTime);
            Console.WriteLine($"Testfall 4: Max Total Fee för {multiTime[0]}, Total tullavgift: Trängselskatt = {toll4} kr");

            // Testfall 5: Normal tidpunkt för motorbike
            Console.WriteLine("------------------------------------------------------------------------");
            int toll5 = tollCalculator.GetTollFee(motorbike, normalTime);
            Console.WriteLine($"Testfall 5: Normal tidpunkt för motorbike är {normalTime[0]}: Trängselskatt = {toll5} kr");

            // Testfall 6: Normal tidpunkt för tractor
            Console.WriteLine("------------------------------------------------------------------------");
            int toll6 = tollCalculator.GetTollFee(tractor, normalTime);
            Console.WriteLine($"Testfall 6: Normal tidpunkt för tractor är {normalTime[0]}: Trängselskatt = {toll6} kr");

            // Testfall 7: Normal tidpunkt för emergency
            Console.WriteLine("------------------------------------------------------------------------");
            int toll7 = tollCalculator.GetTollFee(emergency, normalTime);
            Console.WriteLine($"Testfall 7: Normal tidpunkt för emergency är {normalTime[0]}: Trängselskatt = {toll7} kr");           

        }
        public class VehicleInfo
        {    

    
        public string RegNo { get; set; }

            
        public string Make { get; set; }

            
        public string Model { get; set; }
        public int Year { get; set; } // Lägg till fler egenskaper efter behov

        }



        private static async Task GetVehicleInfoAsync(string regNumber)
        {
            try
            {
                // Bygg URL:en för API-förfrågan
                string url = $"https://biluppgifter.se/fordon/{regNumber}";

                // Gör en GET-förfrågan
                using (HttpClient client = new HttpClient())
                {
                    // Gör anropet till API:et
                    HttpResponseMessage response = await client.GetAsync(url);

                    if (response.IsSuccessStatusCode)
                    {
                        // Läs svaret som en sträng
                        string json = await response.Content.ReadAsStringAsync();

                        // Deserialisera JSON-svaret till ett VehicleInfo-objekt
                        VehicleInfo vehicleInfo = JsonConvert.DeserializeObject<VehicleInfo>(json);

                        // Använd objektet
                        Console.WriteLine($"Registreringsnummer: {vehicleInfo.RegNo}");
                        Console.WriteLine($"Tillverkare: {vehicleInfo.Make}");
                        Console.WriteLine($"Modell: {vehicleInfo.Model}");
                        Console.WriteLine($"År: {vehicleInfo.Year}");
                    }
                    else
                    {
                        //Console.WriteLine($"Fel vid hämtning av data: {response.StatusCode}");
                    }
                }

                //HttpResponseMessage response = await client.GetAsync(url);

                //// Kontrollera om svaret är framgångsrikt
                //if (response.IsSuccessStatusCode)
                //{
                //    // Läs innehållet som en sträng
                //    string json = await response.Content.ReadAsStringAsync();
                //    Console.WriteLine("Fordonsinformation:");
                //    // Deserialisera JSON-svaret till ett VehicleInfo-objekt
                //    VehicleInfo vehicleInfo = JsonConvert.DeserializeObject<VehicleInfo>(json);

                //    // Skriv ut fordonsinformation
                //    Console.WriteLine($"Registreringsnummer: {vehicleInfo.RegNo}");
                //    Console.WriteLine($"Tillverkare: {vehicleInfo.Make}");
                //    Console.WriteLine($"Modell: {vehicleInfo.Model}");
                //    Console.WriteLine($"År: {vehicleInfo.Year}");
                //}
                //else
                //{
                //    Console.WriteLine($"Fel vid hämtning av fordonsinformation: {response.StatusCode}");
                //}
            }
            catch (Exception ex)
            {
                //Console.WriteLine($"Ett fel inträffade: {ex.Message}");
            }
        }
    }
}
