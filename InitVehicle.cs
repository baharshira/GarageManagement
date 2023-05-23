using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ex03.GarageLogic;

namespace Ex03.ConsoleUI
{
    // $G$ RUL-003 (-10) word document wasn't attached to the solution in the folder.
    public class InitVehicle
    {
        public void InsertVehicleToGarage(GarageManagement i_Garage)
        {
            bool invalidVehicleToInsert = true;

            while (invalidVehicleToInsert)
            {
                try
                {
                    Vehicle vehicleToInsert = InitNewVehicle();
                    i_Garage.AddNewVehicleToGarage(vehicleToInsert);
                    invalidVehicleToInsert = false;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            Console.WriteLine("Vehicle was added succsesfully to the garage!");
        }

        public Vehicle InitNewVehicle()
        {
            Vehicle vehicle = setTypeOfVehicle();
            setBasicVehicleDetails(vehicle);
            setUniqueVehicleDetails(vehicle);

            return vehicle;
        }

        private Vehicle setTypeOfVehicle()
        {
            Console.WriteLine(PrintFormats.VehicleTypeMsg());
            int intVehicleType = ParsingMethods.ParseStringToInt();
            eVehicleType vehicleType = (eVehicleType)intVehicleType;
            Vehicle vehicle = VehicleFactory.InitVehicleByType(vehicleType);
            vehicle.VehicleType = vehicleType;
            Console.Clear();

            return vehicle;
        }

        // $G$ DSN-003 (-15) The UI part should not "know" the vehicles types that supported in the garage system
        // in case we want to add some more vehicle types, you will have to change it in the UI too.
        // The moment you type "I_Vehicle.VehicleType is eVehicleType.x" you break the polymorphism.
        private void setUniqueVehicleDetails(Vehicle i_Vehicle)
        {
            if (i_Vehicle.VehicleType is eVehicleType.ElectricCar || i_Vehicle.VehicleType is eVehicleType.FuelCar)
            {
                setCarDetails(i_Vehicle);
            }

            if (i_Vehicle.VehicleType is eVehicleType.ElectricMotorcycle || i_Vehicle.VehicleType is eVehicleType.FuelMotorcycle)
            {
                setMotorcycleDetails(i_Vehicle);
            }

            if (i_Vehicle.VehicleType is eVehicleType.Truck)
            {
                setTruckDetails(i_Vehicle);
            }

            if (i_Vehicle.VehicleType is eVehicleType.Other)
            {
                setOtherDetails(i_Vehicle);
            }
        }

        private void setBasicVehicleDetails(Vehicle i_Vehicle)
        {
            string manufecturerName;
            float currentAirPressure;
            float currentLevelOfEnergy;
            string[] setBasicDetails = PrintFormats.PrintBasicVehicleDetails();

            Console.WriteLine(setBasicDetails[0]);
            Console.WriteLine(setBasicDetails[1]);
            i_Vehicle.LicenseNumber = Console.ReadLine();
            Console.WriteLine(setBasicDetails[2]);
            i_Vehicle.ModelName = Console.ReadLine();
            Console.WriteLine(setBasicDetails[3]);
            i_Vehicle.CarOwner = Console.ReadLine();
            Console.WriteLine(setBasicDetails[4]);
            i_Vehicle.OwnerCellphone = Console.ReadLine();
            Console.WriteLine(setBasicDetails[5]);
            manufecturerName = System.Console.ReadLine();
            Console.WriteLine(setBasicDetails[6]);
            currentAirPressure = ParsingMethods.ParseStringToFloat();
            foreach (Wheel wheel in i_Vehicle.ListOfWheels)
            {
                wheel.ManufacturerName = manufecturerName;
                wheel.CurrentAirPressure = currentAirPressure;
            }

            Console.Clear();
        }

        private void setCarDetails(Vehicle i_Vehicle)
        {
            Car car = i_Vehicle as Car;
            eCarColor carColor = default(eCarColor);
            eNumberOfDoors numberOfDoors = default(eNumberOfDoors);

            Console.WriteLine(PrintFormats.CarColorMsg());
            string userColor = Console.ReadLine();

            if (Enum.TryParse<eCarColor>(userColor, out carColor) && Enum.IsDefined(typeof(eCarColor), carColor))
            {
                car.CarColor = carColor;
            }
            else
            {
                throw new FormatException("Invalid color, please try again");
            }

            Console.WriteLine(PrintFormats.NumOfDoorsMsg());
            string userNumOfDoors = Console.ReadLine();

            if (Enum.TryParse<eNumberOfDoors>(userNumOfDoors, out numberOfDoors) && Enum.IsDefined(typeof(eNumberOfDoors), numberOfDoors))
            {
                car.NumberOfDoors = numberOfDoors;
            }
            else
            {
                throw new FormatException("Invalid number of doors, please try again");
            }
        }

        private void setMotorcycleDetails(Vehicle i_Vehicle)
        {
            Motorcycle motorcycle = i_Vehicle as Motorcycle;
            eLicenseType licseneType = default(eLicenseType);

            Console.Write(PrintFormats.MotorcycleLicseneMsg());
            string userLicsenseType = Console.ReadLine();

            if (Enum.TryParse<eLicenseType>(userLicsenseType, out licseneType) && Enum.IsDefined(typeof(eLicenseType), licseneType))
            {
                motorcycle.LicenseType = licseneType;
            }
            else
            {
                throw new FormatException("Invalid licsense, please try again");
            }

            Console.WriteLine("Please enter engine volume");
            motorcycle.EngineVolume = ParsingMethods.ParseStringToInt();
        }

        private void setTruckDetails(Vehicle i_Vehicle)
        {
            Truck truck = i_Vehicle as Truck;

            Console.WriteLine("Does the truck contains cooled cargo? answer 1 if yes, 2 if no");
            int containesCooledCargo = ParsingMethods.ParseStringToInt();

            truck.ContainsCooledCargo = containesCooledCargo == 1;
            Console.WriteLine("Please write cargo tank volume");
            int tankVolume = ParsingMethods.ParseStringToInt();

            truck.CargoTankVolume = tankVolume;
        }

        private Dictionary<string, string> setOtherDetails(Vehicle i_Vehicle)
        {
            Dictionary<string, string> vehicleProperties = new Dictionary<string, string>();
            bool getVehicleFields = true;

            initWheels(i_Vehicle);
            initEngine(i_Vehicle);
            Console.WriteLine("Now, you can add more unqiue details about your vehicle. Write the name of the detail and the detail value, and seperate them by ':");
            while (getVehicleFields)
            {
                string field = Console.ReadLine();
                string[] fieldArray = field.Split(':');

                if (fieldArray.Length != 2)
                {
                    throw new FormatException("Please type in the next format: key:value");
                }

                vehicleProperties.Add(fieldArray[0], fieldArray[1]);
                System.Console.WriteLine("are there any more properties about your car? if no - press n, else - cotinue");
                if (System.Console.ReadLine().Equals("n"))
                {
                    getVehicleFields = false;
                }
            }

            return vehicleProperties;
        }

        private void initWheels(Vehicle i_Vehicle)
        {
            string getVehicleWheelInfo;
            string getVehicleEngineInfo;

            System.Console.WriteLine(PrintFormats.PrintWheelInfo());
            int numberOfWheels = ParsingMethods.ParseStringToInt();
            if (numberOfWheels < 1)
            {
                throw new FormatException("Invalid number of wheels");
            }

            float maximumAirPressure = ParsingMethods.ParseStringToFloat();
            float currentAirPressure = ParsingMethods.ParseStringToFloat();

            if (currentAirPressure > maximumAirPressure)
            {
                throw new FormatException("Current air pressure cannot be bigger then maximum air pressure");
            }

            for (int i = 0; i < numberOfWheels; i++)
            {
                Wheel wheel = new Wheel();
                wheel.MaxAirPressue = maximumAirPressure;
                wheel.CurrentAirPressure = currentAirPressure;
                i_Vehicle.ListOfWheels.Add(wheel);
            }
        }

        private void initEngine(Vehicle i_Vehicle)
        {
            string getVehicleEngineInfo;

            getVehicleEngineInfo = string.Format(
@"Please type: 1 if your car is fuel based, and 2 if it's electric based");
            System.Console.WriteLine(getVehicleEngineInfo);
            int intEngineType = ParsingMethods.ParseStringToInt();

            if (intEngineType == 1)
            {
                initFuelEngine(i_Vehicle);

            }
            else if (intEngineType == 2)
            {
                initElectricEngine(i_Vehicle);
            }
            else
            {
                throw new ArgumentException("Invalid type of engine");
            }
        }

        private void initFuelEngine(Vehicle i_Vehicle)
        {
            eFuelType fuelType = default(eFuelType);

            Console.WriteLine("Please type max amount of fuel");
            int maxAmountOfFuel = ParsingMethods.ParseStringToInt();

            Console.WriteLine("Please type current amount of fuel");
            float currentLevelOfEnergy = ParsingMethods.ParseStringToFloat();

            Console.WriteLine(PrintFormats.FuelTypeMsg());
            string userInput = Console.ReadLine();

            if (Enum.TryParse<eFuelType>(userInput, out fuelType) && Enum.IsDefined(typeof(eFuelType), fuelType))
            {
                FuelEngine engine = new FuelEngine(maxAmountOfFuel, fuelType);
                i_Vehicle.Engine = engine;
                engine.CurrentCapacity = currentLevelOfEnergy;
            }
            else
            {
                throw new FormatException("Invalid type of fuel");
            }
        }

        private void initElectricEngine(Vehicle i_Vehicle)
        {
            System.Console.WriteLine("please type maximum battery life in hours");
            int maxBatteryLife = ParsingMethods.ParseStringToInt();

            Console.WriteLine("Please type current energy level");
            float currentLevelOfEnergy = ParsingMethods.ParseStringToFloat();

            if (maxBatteryLife < 0)
            {
                throw new FormatException("Battery life must be greater then 0 hours");
            }

            ElectricEngine electricEngine = new ElectricEngine(maxBatteryLife);
            i_Vehicle.Engine = electricEngine;
            electricEngine.CurrentCapacity = currentLevelOfEnergy;
        }
    }
}
