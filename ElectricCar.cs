using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    internal class ElectricCar : Car
    {
        private const float k_Maxbatterylife = 3.3f;

        public ElectricCar()
            : base()
        {
            Engine = new ElectricEngine(k_Maxbatterylife);
        }
    }

}
