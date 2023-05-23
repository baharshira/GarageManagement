using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class Truck : Vehicle
    {
        private const float k_MaxAmountOfFuel = 120f;
        private const int k_NumberOfWheels = 16;
        public bool ContainsCooledCargo { get; set; }
        public float CargoTankVolume { get; set; }
        public Truck()
            : base()
        {
            Engine = new FuelEngine(k_MaxAmountOfFuel, eFuelType.Soler);

            for (int i = 0; i < k_NumberOfWheels; i++)
            {
                Wheel wheel = new Wheel();
                ListOfWheels.Add(wheel);
                wheel.MaxAirPressue = 24;
            }
        }
    }
}
