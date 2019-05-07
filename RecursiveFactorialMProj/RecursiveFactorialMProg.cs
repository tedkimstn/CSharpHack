/*
 * Source: https://www.c-sharpcorner.com/blogs/factorial-number-program-in-c-sharp-using-recursion1
 * Definition Source (mdoc): https://docs.microsoft.com/en-us/dotnet/
 * Author: Sandeep Singh Shekhawat
 * Summary: Calculates a factorial of a number recursively.
 * Modifications: Modified namespace.
 *                Added a restart handler.
 *                Added a exception handler.
 *                Modififed spacings for better readability.
 *                Added an if-else statement that factorial works for numbers upto 20.
 * Student: Ted Kim
 * Capture Date: May 07, 2019
 */
using System;

namespace RecursiveFactorialMProg
{

    class Program
    {

        static void Main(string[] args)
        {

            bool resume = true;
            while (resume)
            {
                Console.WriteLine("Enter a number");

                try
                {
                    // Converts a string user input to a Int32 type.
                    int number = Convert.ToInt32(Console.ReadLine());

                    if (number < 21)
                    {
                        // "long" is a signed 64-bit integer.
                        // Returns a factorial of a number recrusively.
                        long fact = GetFactorial(number);
                        Console.WriteLine("{0} factorial is {1}", number, fact);
                    }
                    else { Console.WriteLine("Number is too large!"); }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

                resume = RestartHandler();

            }
        }

        // Returns a recursively calculated a factorial.
        private static long GetFactorial(int number)
        {          
            // GetFactorial(0) = 1.
            if (number == 0)
            {

                return 1;

            }

            // number! = number*(number-1)! and 0! = 1.
            return number * GetFactorial(number-1);

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

Enter a number
dan   
Input string was not in a correct format.
Restart? (y/n)
>y 

Enter a number
21 
Number is too large!
Restart? (y/n)
>y

Enter a number
4.1
Input string was not in a correct format.
Restart? (y/n)
>y

Enter a number
4
4 factorial is 24
Restart? (y/n)
>n


Press any key to continue...

 */