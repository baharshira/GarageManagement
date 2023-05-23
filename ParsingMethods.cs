using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ex03.GarageLogic;

namespace Ex03.ConsoleUI
{
    internal class ParsingMethods
    {
        internal static float ParseStringToFloat()
        {
            float result = 0f;
            bool validInput;

            do
            {
                System.Console.Write("Please enter type a valid float number:");
                validInput = float.TryParse(System.Console.ReadLine(), out result);
            }
            while (!validInput);

            return result;
        }

        internal static int ParseStringToInt()
        {
            int result = 0;
            bool validInput;

            do
            {
                System.Console.Write("Please type a valid natural number:");
                validInput = int.TryParse(Console.ReadLine(), out result);
            }
            while (!validInput);

            return result;
        }

        internal static int ChoiceOutOfMenu()
        {
            int usersChoice = ParseStringToInt();

            if (usersChoice < 1 || usersChoice > 8)
            {
                throw new ArgumentException("Invalid choice out of menu");
            }

            return usersChoice;
        }
    }
}
