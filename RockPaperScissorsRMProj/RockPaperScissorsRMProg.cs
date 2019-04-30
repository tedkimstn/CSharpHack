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
            while (resume)
            {
                RockPaperScissors();

                // Ask if a user wishes to restart the program.
                resume = RestartHandler();
            }
        }

        static void RockPaperScissors()
        {

            Console.WriteLine("Rock Paper Scissors");

            // A list of valid inputs.
            // Add valid inputs inside the curly braces.
            List<string> validInputs = new List<string> { "rock", "paper", "scissors" };

            CustomLinkedNode rockN = new CustomLinkedNode("rock");
            CustomLinkedNode paperN = new CustomLinkedNode("paper");
            CustomLinkedNode scissorsN = new CustomLinkedNode("scissors");

            rockN.Previous = scissorsN;
            rockN.Next = paperN;
            paperN.Previous = rockN;
            paperN.Next = scissorsN;
            scissorsN.Previous = paperN;
            scissorsN.Next = rockN;



            // Reads a user input.
            string input = InputHandler(validInputs);




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
                // "ReadLine" reads a line of user input.
                string restart = Console.ReadLine();

                if (restart == "y") { Console.WriteLine(); return true; }
                else if (restart == "n") { Console.WriteLine(); return false; }
                else { Console.WriteLine("Invalid Input.\n"); }
            }
        }
    }
    class CustomLinkedNode
    {
        public CustomLinkedNode Previous { get; set; }
        public string Value { get; set; }
        public CustomLinkedNode Next { get; set; }

        public CustomLinkedNode(string val) { Value = val; }
    }
    class CustomLinkedList
    {

        public CustomLinkedList(List<string> stringList)
        {
            List<CustomLinkedNode> nodeList = new List<CustomLinkedNode>;
            foreach(string item in stringList)
            {
                nodeList.
            }
        }
    }

   


}

/* This code produces the following results:



 */
