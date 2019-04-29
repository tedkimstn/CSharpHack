/*
 * Source: https://github.com/tedkimstn/CSC180Modified/blob/master/TemplateMProj/TemplateMProg.cs
 * Definition Source (mdoc): https://docs.microsoft.com/en-us/dotnet/
 * Author: Ted Kim
 * Summary: A input handler and a restart handler.
 * Modifications: None.
 * Student: Ted Kim
 * Capture Date: April 28, 2019
 */

using System;
using System.Collections.Generic;

namespace TemplateMProj
{
    class Program
    {
        static void Main(string[] args)
        {
            bool resume = true;
            while (resume)
            {
                // Instantiates a list of valid inputs.
                // Add valid inputs inside curly braces.
                List<string> validInputs = new List<string>() { };
                InputHandler(validInputs);

                // Ask if a user wishes to restart the program.
                resume = RestartHandler();
            }
        }

        //
        static string InputHandler(List<string> defInputs)
        {
            while (true)
            {
                Console.WriteLine("Please input one of the followings: ");

                foreach (var defInput in defInputs)
                {
                    Console.WriteLine(defInput);
                }

                Console.Write("\n>");
                string input = Console.ReadLine();

                if (defInputs.Contains(input)) 
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

        // Returns true if user wishes to restart and vice versa.
        static bool RestartHandler()
        {
            while (true)
            {
                Console.Write("Restart? (y/n)\n>");
                // "ReadLine" reads a line of user input.
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
