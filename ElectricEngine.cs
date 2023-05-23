using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class ElectricEngine : Engine
    {
        public ElectricEngine(float maxBatteryLife)
        : base(maxBatteryLife)
        {
        }

        public override string ToString()
        {
            string msg = "Electricity";

            return msg;
        }
    }
}
