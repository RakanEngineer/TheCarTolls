using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TollFeeCalculator
{
    public class Foreign : IVehicle
    {   
        public Type GetVehicleType()
        {
            return typeof(Foreign);
        }
    }
}
