using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.ConsoleUI
{
    internal static class PrintFormats
    {
        internal static string MainMenu()
        {
            string menu = string.Format(
@"Hello and welcome to our garage!
please press your selected choice:
1. Insert a new vehicle into the garage
2. Display a list of license numbers currently in the garage (you can choose to see by their status in the garage)
3. Change a certain vehicle’s status
4. Inflate tires to maximum
5. Refuel a fuel-based vehicle 
6. Charge an electric-based vehicle
7. Display vehicle's information
8. exit");

            return menu;
        }

        internal static string VehicleStatusMsg()
        {
            string msg = string.Format(
@"Please enter status:
1. Repair
2. In Repair
3. Payed For");

            return msg;
        }

        internal static string FuelTypeMsg()
        {
            string msg = string.Format(
@"Please choose fuel type to refuel:
1 Soler
2 Octan95
3 Octan96
4 Octan98");

            return msg;
        }

        internal static string VehicleTypeMsg()
        {
            string vehicleTypeMsg;

            vehicleTypeMsg = string.Format(
@"please choose your vehicle:
1 Electric Car
2 Fuel Car
3 Electric Motorcycle
4 Fuel Motorcycle
5 Truck
6 Other");

            return vehicleTypeMsg;
        }

        internal static string[] PrintBasicVehicleDetails()
        {
            string[] printBasicVehicleDetails = new string[8];

            printBasicVehicleDetails[0] = "Good. Now, let's continue - please write (in each line) the next details about your car:";
            printBasicVehicleDetails[1] = "1. Licsence number:";
            printBasicVehicleDetails[2] = "2. Model name:";
            printBasicVehicleDetails[3] = "3. Your Name:";
            printBasicVehicleDetails[4] = "4. Your Cellphone:";
            printBasicVehicleDetails[5] = "5. Wheel's manufecturer name:";
            printBasicVehicleDetails[6] = "6. Wheel's current air pressure - ";
            printBasicVehicleDetails[7] = "7. Current amount of energy - ";

            return printBasicVehicleDetails;
        }

        internal static string CarColorMsg()
        {
            string msg = string.Format(
@"Please enter number of color:
1 Red
2 White
3 Green
4 Blue");

            return msg;
        }

        internal static string NumOfDoorsMsg()
        {
            string msg = string.Format(
@"Please enter number of doors:
2
3
4
5");

            return msg;
        }

        internal static string MotorcycleLicseneMsg()
        {
            string motorcycleLicseneMsg = string.Format(
 @"Please enter licsense type:
1 A
2 A1
3 B1
4 BB");

            return motorcycleLicseneMsg;
        }

        internal static string PrintWheelInfo()
        {
            string getVehicleWheelInfo = string.Format(
@"Please type (in each line) details about your vehicle,
1 - number of wheels
2 - maximum air pressure in wheels
3 - current air pressure in wheels");

            return getVehicleWheelInfo;
        }
    }
}
