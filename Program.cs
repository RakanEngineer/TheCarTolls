using System;
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

            // Exempel på hur du kan använda IVehicle-interface
            Vehicle someVehicle = car; // Car implementerar IVehicle
            Console.WriteLine($"Vehicle type: {someVehicle.GetVehicleType()}");

            // Exempel på hur du kan använda TollCalculator
            TollCalculator tollCalculator = new TollCalculator();
            DateTime[] dates = { DateTime.Now, DateTime.Now.AddHours(1), DateTime.Now.AddHours(2) };

            // Anropa GetTollFee-metoden
            int totalTollCar = tollCalculator.GetTollFee(car, dates);
            int totalTollMotorbike = tollCalculator.GetTollFee(motorbike, dates);
            int totalTollTractor = tollCalculator.GetTollFee(tractor, dates);
            int totalTollEmergency = tollCalculator.GetTollFee(emergency, dates);

            // Visa resultat
            Console.WriteLine($"Total toll for Car: {totalTollCar} kr");
            Console.WriteLine($"Total toll for Motorbike: {totalTollMotorbike} kr");
            Console.WriteLine($"Total toll for Tractor: {totalTollTractor} kr");
            Console.WriteLine($"Total toll for Emergency: {totalTollEmergency} kr");

            

            // Testfall 1: Skattefri dag
            DateTime[] exemptDay = { new DateTime(2023, 12, 25, 12, 0, 0) };
            int toll1 = tollCalculator.GetTollFee(car, exemptDay);
            Console.WriteLine($"Skattefri dag: Trängselskatt = {toll1} kr");

            // Testfall 2: Skattefri tidpunkt
            DateTime[] exemptTime = { new DateTime(2024, 1, 1, 3, 0, 0) };
            int toll2 = tollCalculator.GetTollFee(car, exemptTime);
            Console.WriteLine($"Skattefri tidpunkt: Trängselskatt = {toll2} kr");

            // Testfall 3: Normal tidpunkt
            DateTime[] normalTime = { new DateTime(2024, 1, 2, 8, 0, 0) };
            int toll3 = tollCalculator.GetTollFee(car, normalTime);
            Console.WriteLine($"Normal tidpunkt: Trängselskatt = {toll3} kr");

            // Testfall 4: Max Total Fee
            DateTime[] multiTime = { DateTime.Now, new DateTime(2024, 1, 2, 7, 0, 0), new DateTime(2024, 1, 2, 8, 0, 0),
            DateTime.Now.AddHours(1),
            DateTime.Now.AddHours(2),
            DateTime.Now.AddHours(3),
            DateTime.Now.AddHours(4),
            DateTime.Now.AddHours(5),
            DateTime.Now.AddHours(6),
            DateTime.Now.AddHours(7),
            DateTime.Now.AddHours(8),
            DateTime.Now.AddHours(9),
            DateTime.Now.AddHours(10),
            DateTime.Now.AddHours(11),
            DateTime.Now.AddHours(12),
            DateTime.Now.AddHours(13),
            DateTime.Now.AddHours(14),
            DateTime.Now.AddHours(15),
            DateTime.Now.AddHours(16),
            DateTime.Now.AddHours(17),
            DateTime.Now.AddHours(18),
            DateTime.Now.AddHours(19),
            DateTime.Now.AddHours(20),
            DateTime.Now.AddHours(21),
            DateTime.Now.AddHours(22),
            DateTime.Now.AddHours(23),
              };
            int toll4 = tollCalculator.GetTollFee(car, multiTime);
            Console.WriteLine($"Total tullavgift: Trängselskatt = {toll4} kr");
        }
    }
}
