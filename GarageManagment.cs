using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class GarageManagement
    {
        private readonly Dictionary<string, Vehicle> r_currentVehiclesInGarage = new Dictionary<string, Vehicle>();

        public void AddNewVehicleToGarage(Vehicle i_Vehicle)
        {
            if (CheckIfVehicleInGarage(i_Vehicle.LicenseNumber))
            {
                throw new ArgumentException("Vehicle is already in garage");
            }
            else
            {
                r_currentVehiclesInGarage.Add(i_Vehicle.LicenseNumber, i_Vehicle);
            }
        }

        public string ShowVehiclesInGarage(eVehicleStatus i_VehicleStatusFilter)
        {
            bool garageContainsVehiclesWithThisStatus = false;
            StringBuilder vehiclesInGarageToPrint = new StringBuilder();

            foreach (Vehicle vehicle in r_currentVehiclesInGarage.Values)
            {
                if (vehicle.VehicleStatus == i_VehicleStatusFilter)
                {
                    vehiclesInGarageToPrint.Append("Vehicle number : " + vehicle.LicenseNumber + "\n");
                    garageContainsVehiclesWithThisStatus = true;
                }
            }

            if (r_currentVehiclesInGarage.Count == 0)
            {
                vehiclesInGarageToPrint.Append("No vehicles in garage!");
            }
            else if (!garageContainsVehiclesWithThisStatus)
            {
                vehiclesInGarageToPrint.Append("No vehicles in garage with this status");
            }

            return vehiclesInGarageToPrint.ToString();
        }

        public string ChangeVehicleStutusInGarage(string i_LiscenceNumber, eVehicleStatus i_NewStatus)
        {
            StringBuilder msg = new StringBuilder();

            if (r_currentVehiclesInGarage[i_LiscenceNumber].Equals(null))
            {
                throw new Exception("Sorry, no such vehicle in garage");
            }
            else
            {
                msg.Append("Curren status of vehicle is : " + r_currentVehiclesInGarage[i_LiscenceNumber].VehicleStatus + "\nChanged to : " + i_NewStatus);
                r_currentVehiclesInGarage[i_LiscenceNumber].VehicleStatus = i_NewStatus;
            }

            return msg.ToString();
        }

        public string InflateTiresToMaximum(string i_LiscenceNumber)
        {
            StringBuilder msg = new StringBuilder();
            float currentAirPressure = r_currentVehiclesInGarage[i_LiscenceNumber].ListOfWheels[1].CurrentAirPressure;
            float maxAirPressure = r_currentVehiclesInGarage[i_LiscenceNumber].ListOfWheels[1].MaxAirPressue;

            if (r_currentVehiclesInGarage[i_LiscenceNumber].Equals(null))
            {
                throw new ArgumentException("Sorry, no such vehicle in garage");
            }
            else
            {
                msg.Append("Current air pressure is: " + currentAirPressure + "\nChanged to: " + maxAirPressure);
                foreach (Wheel wheel in r_currentVehiclesInGarage[i_LiscenceNumber].ListOfWheels)
                {
                    wheel.CurrentAirPressure = wheel.MaxAirPressue;
                }
            }

            return msg.ToString();
        }

        public string DisplayVehicleInformation(string i_LiscenceNumber)
        {
            Vehicle vehicle;

            if (!CheckIfVehicleInGarage(i_LiscenceNumber))
            {
                throw new ArgumentException("Vehicle is not in garage");
            }

            vehicle = r_currentVehiclesInGarage[i_LiscenceNumber];

            string msg = string.Format(
@"Here are some details about vehicle number {0}:
vehicle's model name is {1}
vehicle's owner's name is {2}
vehicle's status in garage is {3}
wheel's current air pressure is {4}
wheel's manufacture name is {5}
vehicle is based on {6},
and it's energy level is {7}%.",
i_LiscenceNumber,
vehicle.ModelName,
vehicle.CarOwner,
vehicle.VehicleStatus,
vehicle.ListOfWheels[1].CurrentAirPressure,
vehicle.ListOfWheels[1].ManufacturerName,
vehicle.Engine.ToString(),
((vehicle.Engine.CurrentCapacity / vehicle.Engine.MaxCapacity) * 100));

            return msg.ToString();
        }

        public string ReFuel(float i_AmountToFill, eFuelType i_FuelType, string i_LiscenceNumber)
        {
            StringBuilder msg = new StringBuilder();
            Vehicle vehicle = r_currentVehiclesInGarage[i_LiscenceNumber];
            Engine engine = vehicle.Engine;

            if (engine is FuelEngine)
            {
                FuelEngine fuelEngine = (FuelEngine)engine;
                vehicle.Engine = fuelEngine;

                if (fuelEngine.FuelType != i_FuelType)
                {
                    throw new ArgumentException("Wrong type of fuel to refuel");
                }

                if (i_AmountToFill + vehicle.Engine.CurrentCapacity > vehicle.Engine.MaxCapacity)
                {
                    throw new ValueOutOfRangeException("Amount to fuel is out of range", vehicle.Engine.MaxCapacity, 0);
                }
            }
            else
            {
                throw new ArgumentException("Cannot refuel electric vehicle");
            }

            float currentCapacity = vehicle.Engine.CurrentCapacity;
            vehicle.Engine.CurrentCapacity = vehicle.Engine.CurrentCapacity + i_AmountToFill;
            float newCapacity = vehicle.Engine.CurrentCapacity;

            msg.Append("Current capacity is: " + currentCapacity + "\nChanged to: " + newCapacity);

            return msg.ToString();
        }

        public string ReCharge(float i_AmountToFill, string i_LiscenceNumber)
        {
            StringBuilder msg = new StringBuilder();
            Vehicle vehicle = r_currentVehiclesInGarage[i_LiscenceNumber];
            Engine engine = vehicle.Engine;

            if (engine is ElectricEngine)
            {
                ElectricEngine electricEngine = (ElectricEngine)engine;
                vehicle.Engine = electricEngine;

                if (i_AmountToFill + vehicle.Engine.CurrentCapacity > vehicle.Engine.MaxCapacity)
                {
                    throw new ValueOutOfRangeException("Amount to fuel is out of range", vehicle.Engine.MaxCapacity, 0);
                }
            }
            else
            {
                throw new ArgumentException("Cannot recharge fuel-based vehicle");
            }

            float currentCapacity = vehicle.Engine.CurrentCapacity;
            vehicle.Engine.CurrentCapacity = vehicle.Engine.CurrentCapacity + i_AmountToFill;
            float newCapacity = vehicle.Engine.CurrentCapacity;

            msg.Append("Current capacity is: " + currentCapacity + "\nChanged to: " + newCapacity);

            return msg.ToString();
        }

        public bool CheckIfVehicleInGarage(string i_LiscenceNumber)
        {
            bool vehicleInGarage = false;

            if (r_currentVehiclesInGarage.ContainsKey(i_LiscenceNumber))
            {
                vehicleInGarage = true;
            }

            return vehicleInGarage;
        }
    }
}