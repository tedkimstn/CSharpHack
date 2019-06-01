/*
 * Source: 
 * Definition Source (mdoc): https://docs.microsoft.com/en-us/dotnet/
 * Author: 
 * Summary: 
 * Modifications: Added a namespace.
 *                
 * Student: Ted Kim
 * Capture Date: May , 2019
 */

using System;
using System.Collections.Generic;

namespace Template
{
    class Program
    {
        static void Main(string[] args)
        {
            // Restart handler part 1/2.
            bool resume = true;
            while (resume)
            {
                Console.WriteLine("Hello World!");

                // Add a list of valid inputs inside the curly braces.
                List<string> validInputs = new List<string>() { "Test" };
                // Reads a user input.
                string input = Handler.HandleInput(validInputs);
               
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
                Console.WriteLine("Please input: ");
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

/* This code produces the following results:



 */
