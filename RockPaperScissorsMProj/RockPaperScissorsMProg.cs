/*
 * Source: https://gist.github.com/karthicbz/914c269a7dece4938d0eb864c87abfae
 * Definition Source (mdoc): https://docs.microsoft.com/en-us/dotnet/
 * Author: karthicbz (GitHub)
 * Summary: tedkim220 tedkims2n tedkimstn
 * Modifications: Modified project name.
 *                Modified restart variable for readability.
 *                Modified restart function.
 *                Modified variable names for readability.
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
            bool restart = true;

            while (restart)
            {
                Console.WriteLine("Select any one:\nROCK\nPAPER\nSCISSOR");
                string[] choices = new string[3] { "ROCK", "PAPER", "SCISSOR" };
                Random rgn = new Random();
                int n = rgn.Next(0, 3);
                Console.WriteLine("Enter your choice:");
                string user = Console.ReadLine().ToUpper();
                Console.WriteLine("Computer:" + choices[n]);

                if (user == "ROCK" && choices[n] == "SCISSOR")
                {
                    Console.WriteLine("User wins");
                    winCounter += 1;
                }
                else if (user == "ROCK" && choices[n] == "PAPER")
                {
                    Console.WriteLine("Computer wins");
                    loseCounter += 1;
                }
                else if (user == "PAPER" && choices[n] == "ROCK")
                {
                    Console.WriteLine("User wins");
                    winCounter += 1;
                }
                else if (user == "PAPER" && choices[n] == "SCISSOR")
                {
                    Console.WriteLine("Computer Wins");
                    loseCounter += 1;
                }
                else if (user == "SCISSOR" && choices[n] == "ROCK")
                {
                    Console.WriteLine("Computer Wins");
                    loseCounter += 1;
                }
                else if (user == "SCISSOR" && choices[n] == "PAPER")
                {
                    Console.WriteLine("User wins");
                    winCounter += 1;
                }
                else
                {
                    Console.WriteLine("Same choices");
                }

                restart = Restart();

            }
            Console.WriteLine("User wins " + winCounter + " time(s).");
            Console.WriteLine("Computer wins " + loseCounter + " time(s).");
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
    }
}

/* This code produces the following results:



 */
