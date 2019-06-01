/*
 * Source: https://www.sanfoundry.com/csharp-programs-generate-sum-digits/
 * Definition Source (mdoc): https://docs.microsoft.com/en-us/dotnet/
 * Author: sanfoundry
 * Summary: Adds up the digits of a number input.
 * Modifications: Added a namespace.
 *                Removed unnecessary namespaces.
 *                Added a restart manager and removed ReadLine().
 * Student: Ted Kim
 * Capture Date: May 08, 2019
 */

using System;

namespace SumOfDigits1
{
    class Program
    {
        static void Main(string[] args)
        {
            // Restart condition.
            bool resume = true;
            while (resume)
            {
                // Catches FormatException when an input is not a number.
                try
                {
                    int num, sum = 0, r;
                    Console.WriteLine("Enter a Number : ");
                    // Reads a user input and converts it to int type.
                    num = int.Parse(Console.ReadLine());

                    // Divide the number by 10 and adds up remainder until
                    // the quotient is 0.
                    // Skipeed when user input is 0.
                    while (num != 0)
                    {
                        r = num % 10;
                        num = num / 10;
                        sum = sum + r;
                    }
                    Console.WriteLine("Sum of Digits of the Number : " + sum);
                }
                // Catches and prints name of exception.
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

                // Restarts the program if the user input is y.
                // Terminates the program if the user input is n.
                resume = RestartHandler();

            }
        }

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

Enter a Number : 
Hello, World!
Input string was not in a correct format.
Restart? (y/n)
>y

Enter a Number : 
123 
Sum of Digits of the Number : 6
Restart? (y/n)
>n


Press any key to continue...

 */