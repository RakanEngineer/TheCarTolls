using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TollFeeCalculator
{
    public class Tractor : IVehicle
    {
        public Type GetVehicleType() 
        {
            return typeof(Tractor);
        }
    }
}
