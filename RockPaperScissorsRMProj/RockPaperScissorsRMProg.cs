/*
 * Source: https://github.com/tedkimstn/CSC180Modified/blob/master/RockPaperScissorsRMProj/RockPaperScissorsRMProg.cs
 * Definition Source (mdoc): https://docs.microsoft.com/en-us/dotnet/
 * Author: Ted Kim
 * Summary: Rock Paper Scissors.
 * Modifications: N/A.
 * Student: Ted Kim
 * Capture Date: April 28, 2019
 */

using System;
using System.Collections.Generic;

namespace RockPaperScissorsRMProj
{
    class Program
    {
        static void Main(string[] args)
        {
            // Restart manager.
            bool resume = true;

            // Point counter.
            int point = 0;

            Console.WriteLine("Rock Paper Scissors Game");

            while (resume)
            {
                // Point = old point + new point.
                point = point + RockPaperScissors();
                Console.WriteLine("Current Point: {0}", point);
                // Ask if a user wishes to restart the program.
                resume = RestartHandler();
            }
        }

        static int RockPaperScissors()
        {



            // A list of valid inputs.
            List<string> validInputs = new List<string>() { "rock", "paper", "scissors" };

            // Reads a user input.
            string input = InputHandler(validInputs);

            // Generates a random hand.
            Random ranNumGen = new Random();
            int ranNum = ranNumGen.Next(0, 3);
            Console.WriteLine("Computer: {0}", validInputs[ranNum]);

            // In cases of {user, computer} = {paper, rock}, {scissors, paper}, {rock, scissors}
            if(validInputs.IndexOf(input) - ranNum == 1 || validInputs.IndexOf(input) - ranNum == -2) { Console.WriteLine("User won"); return 1; }
            // In cases of both user and computer choose same shape
            else if (validInputs.IndexOf(input) - ranNum == 0) { Console.WriteLine("Drew"); return 0; }
            // In cases of {computer, user} = {paper, rock}, {scissors, paper}, {rock, scissors}
            else if (validInputs.IndexOf(input) - ranNum == -1 || validInputs.IndexOf(input) - ranNum == 2 ) { Console.WriteLine("User lost"); return -1; }
            else { Console.WriteLine("Unexpected Error"); return 0; }

        }
        
        // Prints a list of option inputs,
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

Rock Paper Scissors Game
Please input one of the followings: 
rock
paper
scissors

>drinking coffee with harold in olympia coffee roasting co
Invalid input.

Please input one of the followings: 
rock
paper
scissors

>rock
Valid input.
Computer: scissors
User won
Current Point: 1
Restart? (y/n)
>harold left
Invalid Input.

Restart? (y/n)
>y

Please input one of the followings: 
rock
paper
scissors

>paper
Valid input.
Computer: rock
User won
Current Point: 2
Restart? (y/n)
>y       

Please input one of the followings: 
rock
paper
scissors

>scissors
Valid input.
Computer: paper
User won
Current Point: 3
Restart? (y/n)
>y

Please input one of the followings: 
rock
paper
scissors

>rock
Valid input.
Computer: paper
User lost
Current Point: 2
Restart? (y/n)
>n


Press any key to continue...

 */
