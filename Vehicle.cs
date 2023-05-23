using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    // $G$ DSN-999 (-3) This class should have been abstract.
    public class Vehicle
    {
        public string LicenseNumber { get; set; }
        public string ModelName { get; set; }
        public Engine Engine { get; set; }
        public List<Wheel> ListOfWheels { get; set; }
        public string CarOwner { get; set; }
        public string OwnerCellphone { get; set; }
        public eVehicleStatus VehicleStatus { get; set; }
        public eVehicleType VehicleType { get; set; }
        public Vehicle()
        {
            VehicleStatus = eVehicleStatus.InRepair;
            ListOfWheels = new List<Wheel>();
        }
    }
}
