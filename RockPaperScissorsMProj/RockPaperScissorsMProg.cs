/*
 * Source: https://gist.github.com/karthicbz/914c269a7dece4938d0eb864c87abfae
 * Definition Source (mdoc): https://docs.microsoft.com/en-us/dotnet/
 * Author: karthicbz (GitHub)
 * Summary: tedkim220 tedkims2n tedkimstn
 * Modifications: Modified project name.
 *                Modified restart variable for readability.
 *                Modified variable names for readability.
 *                Added a restart handler method. Modified restart handling.
 *                Added a input handler method. Modified input handling.
 *                Modified how to choose a random hand.
 *                Modified that user input can be handled case-insensitive.
 *                Modified a string scissor to scissors.
 * Student: Ted Kim
 * Capture Date: April 28, 2019
 */

using System;
using System.Collections.Generic;

namespace RockPaperScissorsM
{
    class Program
    {
        static void Main(string[] args)
        {


            Console.WriteLine("Welcome to RPS game");

            int winCounter = 0;
            int loseCounter = 0;
           
            bool resume = true;
            while (resume)
            {
                // A list of valid inputs.
                List<string> validInputs = new List<string>() { "rock", "paper", "scissors" };

                // Reads a user input.
                string input = InputHandler(validInputs);

                // Generates a random hand.
                Random ranNumGen = new Random();
                int ranNum = ranNumGen.Next(0, 3);
                string ranHand = validInputs[ranNum];

                Console.WriteLine("Computer:" + ranHand);

                // Compare hands and count how many times user and computer won.
                // "string.Equals(string1, string2, StringComparison.CurrentCultureIgnoreCase)"
                // compares 2 strings case-insensitively.
                if ( input == "rock" && ranHand == "scissors")
                {
                    Console.WriteLine("User won");
                    winCounter += 1;
                }
                else if (input == "rock" && ranHand == "paper")
                {
                    Console.WriteLine("Computer won");
                    loseCounter += 1;
                }
                else if (input == "paper" && ranHand == "rock")
                {
                    Console.WriteLine("User won");
                    winCounter += 1;
                }
                else if (input == "paper" && ranHand == "scissors")
                { 
                    Console.WriteLine("Computer Won");
                    loseCounter += 1;
                }
                else if (input == "scissors" && ranHand == "rock")
                {
                    Console.WriteLine("Computer Won");
                    loseCounter += 1;
                }
                else if (input == "scissors" && ranHand == "paper")
                {
                    Console.WriteLine("User won");
                    winCounter += 1;
                }
                else
                {
                    Console.WriteLine("Drew");
                }

                resume = Restart();

            }
            Console.WriteLine("User won " + winCounter + " time(s).");
            Console.WriteLine("Computer won " + loseCounter + " time(s).");
        }
        static bool Restart()
        {
            while (true)
            {
                Console.WriteLine("Restart? (y/n)");
                // "ReadLine" reads a line of user input.
                string restart = Console.ReadLine();

                if (restart == "y") { Console.WriteLine(); return true; }
                else if (restart == "n") { Console.WriteLine(); return false; }
                else { Console.WriteLine("Invalid Input.\n"); }
            }
        }

        static bool InputValidation<T> (T input, List<T> predefinedInput)
        {

            bool validity = predefinedInput.Contains(input);
            return validity;
        }

        // Prints a list of optoin inputs,
        // Reads and returns an error-checked user input.
        static string InputHandler(List<string> optionInputs)
        {
            while (true)
            {
                Console.WriteLine("Please input one of the followings: ");

                foreach (var optionInput in optionInputs)
                {
                    Console.WriteLine(optionInput);
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

Welcome to RPS game
Please input one of the followings: 
rock
paper
scissors

>comsec check
Invalid input.

Please input one of the followings: 
rock
paper
scissors

>RoCk
Valid input.
Computer:scissors
User won
Restart? (y/n)
Lima Charlie
Invalid Input.

Restart? (y/n)
y

Please input one of the followings: 
rock
paper
scissors

>paper
Valid input.
Computer:rock
User won
Restart? (y/n)
n

User won 2 time(s).
Computer won 0 time(s).

Press any key to continue...

 */
