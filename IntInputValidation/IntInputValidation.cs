using System;
using System.Collections.Generic;

namespace IntInputValidation
{
    class Program
    {
        static void Main(string[] args)
        {
            // Restart handler part 1/2.
            bool resume = true;
            while (resume)
            {
                // Reads a user input.
                string input = Handler.HandleInput();

                int intInput;
                // Checks if a user input is an integer.
                bool isInt = Int32.TryParse(input, out intInput);

                // If user input is an integer.
                if(isInt)
                {
                    // If user input is not a positive number.
                    if(intInput<=1) { throw new Exception("Input is not positive."); }
                    // If user input is a positive number.
                    else
                    {
                        if(intInput%3==0) { Console.WriteLine("Input is divisible by 3"); }
                        else { Console.WriteLine("Input is not divisible by 3"); }
                    } 
                }

                // If user input is not an integer.
                else { Console.WriteLine("Non-integer input was entered"); }

                // Restart handler part 2/2.
                // Ask if a user wishes to restart the program.
                resume = Handler.HandleRestart();
            }
        }
    }

    class Handler
    {
        // Prints a list of optoin inputs.
        // Reads and returns an error-checked user input.
        public static string HandleInput(List<string> optionInputs)
        {
            while (true)
            {
                Console.WriteLine("Please input one of the followings: ");

                foreach (var defInput in optionInputs)
                {
                    Console.WriteLine(defInput);
                }

                Console.Write("\n>");
                string input = Console.ReadLine().ToLower();

                if (optionInputs.Contains(input))
                {
                    Console.WriteLine("Valid input.");
                    return input;
                }
                else
                {
                    Console.WriteLine("Invalid input.\n");
                    continue;
                }
            }
        }

        // Reads and returns a user input.
        public static string HandleInput()
        {
            while (true)
            {
                Console.WriteLine("Please enter a positive integer: ");
                Console.Write("\n>");

                return Console.ReadLine();

            }
        }

        // Returns true if user wishes to restart and vice versa.
        public static bool HandleRestart()
        {
            while (true)
            {
                Console.Write("Restart? (y/n)\n>");
                string restart = Console.ReadLine();

                if (restart == "y") { Console.WriteLine(); return true; }
                else if (restart == "n") { Console.WriteLine(); return false; }
                else { Console.WriteLine("Invalid Input.\n"); }
            }
        }

    }
}
