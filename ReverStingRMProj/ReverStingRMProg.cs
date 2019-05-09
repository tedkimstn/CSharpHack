/*
 * Source: https://github.com/tedkimstn/CSC180Modified/blob/master/ReverStingRMProj/ReverStingRMProg.cs
 * Definition Source (mdoc): https://docs.microsoft.com/en-us/dotnet/
 * Author: Ted Kim
 * Summary: Reverses a string using a for loop.
 * Modifications: N/A.
 * Student: Ted Kim
 * Capture Date: May 08, 2019
 */

using System;

namespace ReverStingRMProj
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("String reverser");

            // Restart handler part 1/2.
            bool resume = true;
            while (resume)
            {

                string input = InputHandler();
                Console.WriteLine(ReverseString(input));

                // Restart handler part 2/2.
                // Ask if a user wishes to restart the program.
                resume = RestartHandler();

            }
        }

        static string ReverseString(string oString)
        {
            string rString = "";

            for(int i=oString.Length-1; i>=0; i--)
            {
                rString += oString[i];
            }
            return rString.ToString();
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
    }
}

/* This code produces the following results:

String reverser
Please input: 

>james
semaj
Restart? (y/n)
>y   

Please input: 

>hi there james
semaj ereht ih
Restart? (y/n)
>n


Press any key to continue...

 */
