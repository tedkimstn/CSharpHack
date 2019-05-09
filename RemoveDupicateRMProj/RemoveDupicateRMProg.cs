/*
 * Source: 
 * Definition Source (mdoc): https://docs.microsoft.com/en-us/dotnet/
 * Author: Ted Kim
 * Summary: Remove duplicates using a HashSet.
 * Modifications: N/A.
 * Student: Ted Kim
 * Capture Date: May 08, 2019
 */

using System;
using System.Collections.Generic;

namespace RemoveDupicateRMProj
{
    class Program
    {
        static void Main(string[] args)
        {
            // Restart handler part 1/2.
            bool resume = true;
            while (resume)
            {

                Console.WriteLine(RemoveDuplicates(InputHandler()));

                // Restart handler part 2/2.
                // Ask if a user wishes to restart the program.
                resume = RestartHandler();

            }

        }

       
        static string RemoveDuplicates(string oString)
        {
            HashSet<char> charHash = new HashSet<char>(oString);
            char[] nString = new char[charHash.Count];
            charHash.CopyTo(nString);

            return new string(nString);
            
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
