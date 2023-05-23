using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    internal class ElectricMotorcycle : Motorcycle
    {
        private const float k_Maxbatterylife = 2.5f;
        public ElectricMotorcycle()
            : base()
        {
            Engine = new ElectricEngine(k_Maxbatterylife);
        }
    }
}
