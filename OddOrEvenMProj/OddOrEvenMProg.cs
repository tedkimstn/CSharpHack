/*
 * Source: https://www.sanfoundry.com/csharp-program-check-given-number-even-odd/
 * Definition Source (mdoc): https://docs.microsoft.com/en-us/dotnet/
 * Author: sanfoundry
 * Summary: Determines if a number is an odd or an even number.
 * Modifications: Added a namespace.
 *                Removed unnecessary namespaces.
 * Student: Ted Kim
 * Capture Date: May 09, 2019
 */

using System;

namespace OddOrEvenMProj
{

        class Program
        {
            static void Main(string[] args)
            {
                int i;
                Console.Write("Enter a Number : ");
                // Takes a user input and converts into an int.
                i = int.Parse(Console.ReadLine());
                // If remainder is 0, when it is divided by 2, it is a even number.
                if (i % 2 == 0)
                {
                    Console.Write("Entered Number is an Even Number");
                    Console.Read();
                }
                // If a ramainder is not 0, when it is divided by 2, it is an odd number.
                else
                {
                    Console.Write("Entered Number is an Odd Number");
                    Console.Read();
                }
            }
        }
}

/* This code produces the following results:

    Enter a Number : 34
Entered Number is an Even Number

 */
