﻿/*
 * Source: 
 * Definition Source (mdoc): https://docs.microsoft.com/en-us/dotnet/
 * Author: 
 * Summary: 
 * Modifications: 
 * Student: Ted Kim
 * Capture Date: May , 2019
 */

using System;

namespace SumOfDigitsRMProj
{
    class Program
    {
        static void Main(string[] args)
        {
            // Restart manager.
            bool resume = true;
            while (resume)
            {

                Console.WriteLine("Sum of Digits");

                // Receives an input.
                Console.Write("Please enter a number: \n>");
                string input = Console.ReadLine();

                // Checks if an input is a number.
                bool numberQ = Int32.TryParse(input, out int iInput);

                // If an input is a number.
                if (numberQ)
                {
                    // Initializes an int variable. 
                    int sum = 0;

                    // Adds up each digits.
                    // Digits are represented as number 48-57 in unicode.
                    foreach (char c in input) { sum += c - '0'; }
                    Console.WriteLine(sum);
                }
                // If an input is not a number.
                else
                {
                    Console.WriteLine("Invalid input.");
                }

                // Ask if a user wishes to restart the program.
                resume = RestartHandler();
            }
        }

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
