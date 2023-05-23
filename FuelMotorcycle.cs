using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    internal class FuelMotorcycle : Motorcycle
    {
        private const float k_MaxAmountOfFuel = 6.2f;
        public FuelMotorcycle()
            : base()
        {
            Engine = new FuelEngine(k_MaxAmountOfFuel, eFuelType.Octan98);
        }
    }
}
