using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TollFeeCalculator;

namespace TheCarTolls
{
    public class Diplomat : IVehicle
    {
        public string GetVehicleType()
        {
            return "Diplomat";
        }
    }
}
