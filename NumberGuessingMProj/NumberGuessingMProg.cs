
/* Source: https://www.sanfoundry.com/csharp-program-performs-number-guessing-game/
 * Definition Source (mdoc): https://docs.microsoft.com/en-us/dotnet/
 * Author: Sanfoundry
 * Summary: Number guessing game that generates a random number
 *          and let user know if user's number is higher/lower/same as the random number.
 * Modifications: Modified project name.
 *                Removed unnecessary imported namespaces.
 *                Added a namespace that contains class Program.
 *                Modified Newnum method that it generates a random number.
 *                between two given numbers inclusive for better readability.
 *                Added a FormatException exception handler.
 * Student: Ted Kim
 * Capture Date: April 15, 2019
 */

using System;

namespace NumberGuessingMProj
{

    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                // Generates a random number between 1-100.
                int randno = Newnum(1, 100);
                int count = 1;
                while (true)
                {
                    Console.Write("Enter a number between 1 and 100(0 to quit):");

                    try
                    {
                        // Converts user input to int type.
                        int input = Convert.ToInt32(Console.ReadLine());
                        if (input == 0)
                            // "return": "return statement terminates the execution of a function 
                            //            and returns control to the calling function" (mdoc). 
                            // Terminates Main method.
                            return;
                        else if (input < randno)
                        {
                            Console.WriteLine("Low, try again.");
                            ++count;
                            // Next iteration of while loop begins.
                            continue;
                        }
                        else if (input > randno)
                        {
                            Console.WriteLine("High, try again.");
                            ++count;
                            continue;
                        }
                        else
                        {
                            // Composit formatting: { index[,alignment][:formatString]} (mdoc).
                            // Items inside [] are not optional.
                            // Console.WriteLine("{0}", rando) writes 
                            // the first object (index 0) after the comma.
                            Console.WriteLine("You guessed it! The number was {0}!",
                                               randno);
                            // "?:" ternary operator: condition ? consequent : alternative (mdoc).
                            // If count is 1 write try otherwise write tries.
                            Console.WriteLine("It took you {0} {1}.\n", count,
                                               count == 1 ? "try" : "tries");
                            // "break" statement: "terminates the closest enclosing loo
                            //                     or switch statement in which it appears" (mdoc). 
                            // "break" statement is used to break out of an inner while loop, 
                            // and return control to the outer while loop 
                            // to reset random number and counter ("int count") and restart the game.
                            break;
                        }
                    }
                    catch(FormatException)
                    {
                        Console.WriteLine("Invalid Input.");
                    }
                    }
                }

            }
        // Random number (between min and max) generator.
        static int Newnum(int min, int max)
        {
            // Pseudo-ranom number generator.
            Random random = new Random();
            // Returns a random number between min and max.
            return random.Next(min, max + 1);
        }
    }
}

/* 

Enter a number between 1 and 100(0 to quit):Fifty
Invalid Input.
Enter a number between 1 and 100(0 to quit):50
High, try again.
Enter a number between 1 and 100(0 to quit):25
Low, try again.
Enter a number between 1 and 100(0 to quit):37
Low, try again.
Enter a number between 1 and 100(0 to quit):44
High, try again.
Enter a number between 1 and 100(0 to quit):41
High, try again.
Enter a number between 1 and 100(0 to quit):38
Low, try again.
Enter a number between 1 and 100(0 to quit):40
High, try again.
Enter a number between 1 and 100(0 to quit):39
You guessed it! The number was 39!
It took you 8 tries.

Enter a number between 1 and 100(0 to quit):0

Press any key to continue...

*/
