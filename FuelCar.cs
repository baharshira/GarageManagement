using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    internal class FuelCar : Car
    {
        private const float k_MaxAmountOfFuel = 38.0f;
        public FuelCar()
            : base()
        {

            Engine = new FuelEngine(k_MaxAmountOfFuel, eFuelType.Octan95);
        }
    }
}
