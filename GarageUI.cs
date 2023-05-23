using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ex03.GarageLogic;

namespace Ex03.ConsoleUI
{
    public class GarageUI
    {
        public void StartUI()
        {
            bool invalidRun = true;

            while (invalidRun)
            {
                try
                {
                    runGarageUI();
                    invalidRun = false;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        private void runGarageUI()
        {
            const bool v_runGarage = true;
            GarageManagement garage = new GarageManagement();

            while (v_runGarage)
            {
                Console.WriteLine(PrintFormats.MainMenu());
                int userChoice = ParsingMethods.ChoiceOutOfMenu();

                switch (userChoice)
                {
                    case 1:
                        InitVehicle initVehicle = new InitVehicle();
                        initVehicle.InsertVehicleToGarage(garage);
                        break;
                    case 2:
                        showVehiclesWithThisStatus(garage);
                        break;
                    case 3:
                        changeStatus(garage);
                        break;
                    case 4:
                        inflateTiresToMaximum(garage);
                        break;
                    case 5:
                        refuel(garage);
                        break;
                    case 6:
                        reCharge(garage);
                        break;
                    case 7:
                        displayVehiclesinformation(garage);
                        break;
                    case 8:
                        exitProgram();
                        break;
                }

                Console.ReadLine();
                Console.Clear();
            }
        }

        private void showVehiclesWithThisStatus(GarageManagement i_Garage)
        {
            bool invalidStatus = true;

            while (invalidStatus)
            {
                try
                {
                    getUserStatusFilter(i_Garage);
                    invalidStatus = false;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        private void getUserStatusFilter(GarageManagement i_Garage)
        {
            bool invalidStatus = true;
            string userInput;
            eVehicleStatus vehicleStatus = (eVehicleStatus)2;

            Console.WriteLine(PrintFormats.VehicleStatusMsg());
            while (invalidStatus)
            {
                userInput = Console.ReadLine();
                if (Enum.TryParse<eVehicleStatus>(userInput, out vehicleStatus) && Enum.IsDefined(typeof(eVehicleStatus), vehicleStatus))
                {
                    invalidStatus = false;
                    Console.WriteLine(i_Garage.ShowVehiclesInGarage(vehicleStatus));
                }
                else
                {
                    throw new FormatException("Invalid status, please try again");
                }
            }
        }

        private void changeStatus(GarageManagement i_Garage)
        {
            bool invalidInput = true;

            while (invalidInput)
            {
                try
                {
                    tryToChangeStatus(i_Garage);
                    invalidInput = false;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        private void tryToChangeStatus(GarageManagement i_Garage)
        {
            string licsenseNumber = getLicsenseNumber();
            string statusInput;
            bool invalidStatus = true;
            eVehicleStatus newVehicleStatus = (eVehicleStatus)2;

            Console.WriteLine(PrintFormats.VehicleStatusMsg());
            while (invalidStatus)
            {
                statusInput = Console.ReadLine();
                if (Enum.TryParse<eVehicleStatus>(statusInput, out newVehicleStatus) && Enum.IsDefined(typeof(eVehicleStatus), newVehicleStatus))
                {
                    invalidStatus = false;
                    Console.WriteLine(i_Garage.ChangeVehicleStutusInGarage(licsenseNumber, newVehicleStatus));
                }
                else
                {
                    throw new FormatException("Invalid status");
                }
            }
        }

        private void inflateTiresToMaximum(GarageManagement i_Garage)
        {
            bool invalidInflateTires = true;

            while(invalidInflateTires)
            {
                try
                {
                    string licsenseNumber = getLicsenseNumber();
                    string msg = i_Garage.InflateTiresToMaximum(licsenseNumber);
                    System.Console.WriteLine(msg);
                    invalidInflateTires = false;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        private void getToRefuelSettings(GarageManagement i_Garage)
        {
            string msg;
            string fuelTypeInput;
            eFuelType fuelType;
            float amountToFill;
            StringBuilder refuelMsg = new StringBuilder();
            string licsenseNumber = getLicsenseNumber();
            bool vehicleInGarage = i_Garage.CheckIfVehicleInGarage(licsenseNumber);

            if (vehicleInGarage)
            {
                Console.WriteLine(PrintFormats.FuelTypeMsg());
                fuelTypeInput = Console.ReadLine();
                Console.WriteLine("Please choose your amount to fill");
                amountToFill = ParsingMethods.ParseStringToFloat();
                if (Enum.TryParse<eFuelType>(fuelTypeInput, out fuelType) && Enum.IsDefined(typeof(eFuelType), fuelType))
                {
                    refuelMsg.Append(i_Garage.ReFuel(amountToFill, fuelType, licsenseNumber));
                }
                else
                {
                    throw new FormatException("Invalid input, please try again");
                }
            }
            else
            {
                refuelMsg.Append("Vehicle not in the garage. Please insert your vehicle to the garage first");
            }

            Console.WriteLine(refuelMsg.ToString());
        }

        private void refuel(GarageManagement i_Garage)
        {
            bool invalidRefuel = true;

            while (invalidRefuel)
            {
                try
                {
                    getToRefuelSettings(i_Garage);
                    invalidRefuel = false;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        private void reCharge(GarageManagement i_Garage)
        {
            bool invalidRecharge = true;

            while (invalidRecharge)
            {
                try
                {
                    getReChargeSettings(i_Garage);
                    invalidRecharge = false;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        private void getReChargeSettings(GarageManagement i_Garage)
        {
            float amountToFill;
            StringBuilder reChargeMsg = new StringBuilder();
            string liscencNumber = getLicsenseNumber();
            bool vehicleInGarage = i_Garage.CheckIfVehicleInGarage(liscencNumber);

            if (vehicleInGarage)
            {
                Console.WriteLine("How many hours do you want to charge?");
                amountToFill = float.Parse(Console.ReadLine());
                reChargeMsg.Append(i_Garage.ReCharge(amountToFill, liscencNumber));
            }
            else
            {
                reChargeMsg.Append("Vehicle not in the garage. Please insert your vehicle to the garage first");
            }

            Console.WriteLine(reChargeMsg.ToString());
        }
        // $G$ CSS-999 (-2) method name should be camelCased, "displayVehicleInformation".
        private void displayVehiclesinformation(GarageManagement i_Garage)
        {
            bool invalidDisplay = true;

            while (invalidDisplay)
            {
                try
                {
                    string liscencNumber = getLicsenseNumber();
                    string display = i_Garage.DisplayVehicleInformation(liscencNumber);
                    Console.WriteLine(display);
                    invalidDisplay = false;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        private string getLicsenseNumber()
        {
            Console.WriteLine("Please enter liscense number");
            string liscencNumber = Console.ReadLine();

            return liscencNumber;
        }

        private void exitProgram()
        {
            Console.WriteLine("Goodbye!");
            Environment.Exit(1);
        }
    }
}
