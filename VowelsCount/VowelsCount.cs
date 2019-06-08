/*
 * Source: https://github.com/tedkimstn/CSharpHack/blob/master/VowelsCount/VowelsCount.cs
 * Definition Source (mdoc): https://docs.microsoft.com/en-us/dotnet/
 * Author: Ted Kim
 * Summary: Counts the number of vowels in a user input.
 * Modifications: N/A       
 * Student: Ted Kim
 * Capture Date: May 21, 2019
 */

using System;
using System.Collections.Generic;

namespace VowelsCount
{
    class Program
    {
        static void Main(string[] args)
        {
            // Restart handler part 1/2.
            bool resume = true;
            while (resume)
            {

                // Reads a user input converted to lowercase.
                string input = Handler.HandleInput();

                char[] vowels = { 'a', 'e', 'i', 'o', 'u' };
                int vowelsCount = 0;
                foreach (char c in input)
                {
                    // If a character is a vowel, increment the counter.
                    if (Array.IndexOf(vowels, c) != -1) { vowelsCount++; }

                }

                Console.WriteLine(vowelsCount);
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
                Console.WriteLine("Please input a string: ");
                Console.Write("\n>");

                return Console.ReadLine().ToLower();
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
