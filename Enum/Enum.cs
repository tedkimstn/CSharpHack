/*
 * Source: https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/enum
 * Definition Source (mdoc): https://docs.microsoft.com/en-us/dotnet/
 * Author: Microsoft Docs
 * Summary: Showcases usage of enum data type.
 * Modifications: Added a namespace.
 *                Added using System.
 *                Added using System.Collections.Generic.
 *                Removed printing default values.
 *                Added an input handler.
 *                Added a restart handler.
 * Student: Ted Kim
 * Capture Date: May 09, 2019
 */

using System;
using System.Collections.Generic;

namespace Enum
{
    public class EnumTest
    {
        // "enum": "a set of named constants" (mdoc).
        enum Day { Sun, Mon, Tue, Wed, Thu, Fri, Sat };

        static void Main()
        {

            // Restart handler part 1/2.
            bool resume = true;
            while (resume)
            {
                Console.WriteLine("What is nth day of the week?");

                // Input options.
                List<string> validInputs = new List<string>() {"1", "2", "3", "4", "5", "6", "7" };
                // Reads a user input.
                string input = InputHandler(validInputs);

                // "Enum.Parse": "Converts the string representation of the name or numeric value 
                // of one or more enumerated constants to an equivalent enumerated object" (mdoc).
                Day day = (Day)Enum.Parse(typeof(Day), input);
                Console.WriteLine(day);

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

What is nth day of the week?
Please input one of the followings: 
1
2
3
4
5
6
7

>1
Valid input.
Mon
Restart? (y/n)
>y

What is nth day of the week?
Please input one of the followings: 
1
2
3
4
5
6
7

>2
Valid input.
Tue
Restart? (y/n)
>n


Press any key to continue...

 */
