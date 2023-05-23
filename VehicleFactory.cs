using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public static class VehicleFactory
    {
        public static Vehicle InitVehicleByType(eVehicleType i_VehicletType)
        {
            switch (i_VehicletType)
            {
                case eVehicleType.ElectricCar:
                    {
                        return new ElectricCar();
                    }

                case eVehicleType.FuelCar:
                    {
                        return new FuelCar();
                    }

                case eVehicleType.ElectricMotorcycle:
                    {
                        return new ElectricMotorcycle();
                    }

                case eVehicleType.FuelMotorcycle:
                    {
                        return new FuelMotorcycle();
                    }

                case eVehicleType.Truck:
                    {
                        return new Truck();
                    }

                case eVehicleType.Other:
                    {
                        return new Vehicle(); 
                    }
            }

            return null;
        }
    }
}
