/*
 * Source: 
 * Definition Source (mdoc): https://docs.microsoft.com/en-us/dotnet/
 * Author: 
 * Summary: 
 * Modifications: 
 * Student: Ted Kim
 * Capture Date: May , 2019
 */

using System;
using System.Collections.Generic;

namespace TemplateMProj
{
    class Program
    {
        static void Main(string[] args)
        {
            // Restart handler part 1/2.
            bool resume = true;
            while (resume)
            {

                // A list of valid inputs.
                // Add valid inputs inside the curly braces.
                List<string> validInputs = new List<string>(){ };
                // Reads a user input.
                string input = InputHandler(validInputs);

                // Restart handler part 2/2.
                // Ask if a user wishes to restart the program.
                resume = RestartHandler();

            }
        }

        // Prints a list of optoin inputs,
        // Reads and returns an error-checked user input.
        static string InputHandler(List<string> optionInputs)
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
        static string InputHandler()
        {
            while (true)
            {
                Console.WriteLine("Please input: ");
                Console.Write("\n>");

                return Console.ReadLine();

            }
        }

        // Returns true if user wishes to restart and vice versa.
        static bool RestartHandler()
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

/* This code produces the following results:



 */
