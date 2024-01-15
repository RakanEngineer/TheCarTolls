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

            // Exempel på hur du kan använda IVehicle-interface
            Vehicle someVehicle = car; // Car implementerar IVehicle
            Console.WriteLine($"Vehicle type: {someVehicle.GetVehicleType()}");

            // Exempel på hur du kan använda TollCalculator
            TollCalculator tollCalculator = new TollCalculator();
            DateTime[] dates = { DateTime.Now };

            // Anropa GetTollFee-metoden
            int totalTollCar = tollCalculator.GetTollFee(car, dates);
            //int totalTollMotorbike = tollCalculator.GetTollFee(motorbike, dates);

            // Visa resultat
            Console.WriteLine($"Total toll for Car: {totalTollCar} kr");
            //Console.WriteLine($"Total toll for Motorbike: {totalTollMotorbike} kr");

            //TollCalculator tollCalculator = new TollCalculator();
            //Vehicle vehicle = new Vehicle();
            //DateTime[] dates = { DateTime.Now, DateTime.Now.AddHours(1), DateTime.Now.AddHours(2) };

            //int totalToll = tollCalculator.GetTollFee(vehicle, dates);

            //Console.WriteLine($"Total Toll Fee: {totalToll} kr");
        }
    }
}
