using System;
using System.Collections.Generic;
using TollFeeCalculator;

namespace TheCarTolls
{
    class program
    {

        static void Main(string[] args)
        {
            Car car = new Car();
            Motorbike motorbike = new Motorbike();
            Tractor tractor = new Tractor();
            Emergency emergency = new Emergency();
            Diplomat diplomat = new Diplomat();
            Foreign foreign = new Foreign();
            Military military = new Military();

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
            Console.WriteLine($"Total toll for Car: for today: {dates[0]} = {totalTollCar} kr");
            Console.WriteLine($"Total toll for Motorbike: for today: {dates[0]} = {totalTollMotorbike} kr");
            Console.WriteLine($"Total toll for Tractor: for today: {dates[0]} = {totalTollTractor} kr");
            Console.WriteLine($"Total toll for Emergency: for today: {dates[0]} = {totalTollEmergency} kr");
            Console.WriteLine($"Total toll for Diplomat: for today: {dates[0]} = {totalTollDiplomat} kr");
            Console.WriteLine($"Total toll for Foreign: for today: {dates[0]} = {totalTollForeign} kr");
            Console.WriteLine($"Total toll for Military: for today: {dates[0]} = {totalTollMilitary} kr");


            // Testfall 1: Skattefri dag
            DateTime[] exemptDay = { new DateTime(2024, 1, 1, 8, 0, 0) };
            int toll1 = tollCalculator.GetTollFee(car, exemptDay);
            Console.WriteLine($"Testfall 1: Skattefri dag: Datum är {exemptDay[0]}, Den dag är en helgdag i Sverige! Trängselskatt = {toll1} kr");

            // Testfall 2: Skattefri tidpunkt
            DateTime[] exemptTime = { new DateTime(2024, 1, 2, 3, 0, 0) };
            int toll2 = tollCalculator.GetTollFee(car, exemptTime);
            Console.WriteLine($"Testfall 2: Skattefri tidpunkt: Tidpunkt är {exemptTime[0]}, Trängselskatt = {toll2} kr");

            // Testfall 3: Normal tidpunkt för car
            DateTime[] normalTime = { new DateTime(2024, 1, 2, 8, 0, 0) };
            int toll3 = tollCalculator.GetTollFee(car, normalTime);
            Console.WriteLine($"Testfall 3: Normal tidpunkt för car är {normalTime[0]}: Trängselskatt = {toll3} kr");

            // Testfall 4: Max Total Fee för car
            DateTime[] multiTime = new DateTime[24];
            DateTime currentDate = new DateTime(2024, 1, 22); 

            for (int hour = 0; hour < 24; hour++)
            {
                multiTime[hour] = currentDate.AddHours(hour);
            }
            int toll4 = tollCalculator.GetTollFee(car, multiTime);
            Console.WriteLine($"Testfall 4: Max Total Fee, Total tullavgift: Trängselskatt = {toll4} kr");

            // Testfall 5: Normal tidpunkt för motorbike
            int toll5 = tollCalculator.GetTollFee(motorbike, normalTime);
            Console.WriteLine($"Testfall 5: Normal tidpunkt för motorbike är {normalTime[0]}: Trängselskatt = {toll5} kr");

            // Testfall 6: Normal tidpunkt för tractor
            int toll6 = tollCalculator.GetTollFee(tractor, normalTime);
            Console.WriteLine($"Testfall 6: Normal tidpunkt för tractor är {normalTime[0]}: Trängselskatt = {toll6} kr");

            // Testfall 7: Normal tidpunkt för emergency
            int toll7 = tollCalculator.GetTollFee(emergency, normalTime);
            Console.WriteLine($"Testfall 7: Normal tidpunkt för emergency är {normalTime[0]}: Trängselskatt = {toll7} kr");

        }       
       
    }
}
