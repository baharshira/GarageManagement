using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    // $G$ DSN-999 (-3) This class should have been abstract.
    public class Car : Vehicle
    {
        private const int k_NumberOfWheels = 4;
        public eNumberOfDoors NumberOfDoors { get; set; }
        public eCarColor CarColor { get; set; }
        public Car()
         : base()
        {
            CarColor = CarColor;
            NumberOfDoors = NumberOfDoors;

            for (int i = 0; i < k_NumberOfWheels; i++)
            {
                Wheel wheel = new Wheel();
                ListOfWheels.Add(wheel);
                wheel.MaxAirPressue = 29;
            }
        }
    }
}