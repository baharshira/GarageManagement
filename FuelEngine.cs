using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class FuelEngine : Engine
    {
        public eFuelType FuelType { get; set; }

        public FuelEngine(float maxAmountOfFuel, eFuelType fuelType)
            : base(maxAmountOfFuel)
        {
            FuelType = fuelType;
        }

        public override string ToString()
        {
            string msg = "Fuel";

            return msg;
        }
    }
}
