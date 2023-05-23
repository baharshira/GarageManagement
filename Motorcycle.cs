using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    // $G$ DSN-999 (-3) This class should have been abstract.
    public class Motorcycle : Vehicle
    {
        private const int k_NumberOfWheels = 2;
        public int EngineVolume { get; set; }
        public eLicenseType LicenseType { get; set; }
        public Motorcycle()
         : base()
        {
            for (int i = 0; i < k_NumberOfWheels; i++)
            {
                Wheel wheel = new Wheel();
                ListOfWheels.Add(wheel);
                wheel.MaxAirPressue = 31;
            }
        }
    }
}
