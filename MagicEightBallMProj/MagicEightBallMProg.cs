/* Source: https://github.com/dbahrt/csc180/blob/master/magic8ball.cs
 * Author: Dan Bahrt (original author: Pandit Akshay)
 * Summary: Takes user question and returns one of 19 predefined answers.
 * Modifications: Modified project name.
 *                Modified return type of getQuestion method from string to void
 *                as returning of user input is unnecessary.
 * Student: Ted Kim
 * Capture Date: April 15, 2019
 */

/* Comments from Dan Bahrt
// source: https://github.com/panditakshay/Magic-8-ball/blob/master/Magic-8-Ball/Program.cs
// author: Pandit Akshay
// summary: c# magic 8 ball game
// modifications: eliminated foul-mouthed insults and words; eliminated comments;
//     condensed braces; changed predictions switch for a simple array lookup;
//     minor code modifications; reworked program exit logic; reworkded getQuestion
//     method; 
// student: Dan Bahrt
// capture date: 3 Apr 2019
*/

// Using directive imports types defined in other namespaces.
using System;
using System.Threading;

namespace MagicEightBallMProj
{

    public class Program
    {
        // String array of defined answers.
        static string[] predictions = {
        "YES!",
        "NO!",
        "HELL NO!",
        "HELL YES!",
        "It is certain",
        "It is decidedly so",
        "Without a doubt",
        "You may rely on it",
        "Most likely!",
        "Outlook good!",
        "Reply hazy try again!",
        "Ask again later",
        "Better not tell you now!",
        "Cannot predict now",
        "Concentrate and ask again",
        "Don't count on it",
        "My sources say no",
        "Outlook not so good",
        "Very doubtful",
    };
        // Instantiates pseduo-random number generator.
        static Random randomObject = new Random();
        // Saves the color of current console characters.
        static ConsoleColor oldColor = Console.ForegroundColor;
        // Set responses to start the program again.
        static string[] ynresponses = { "y", "n" };

        // Beginning of the program.
        // Static modifier makes an item non-instantiable.
        // Static items can be accessed without creating an object of the class.
        static void Main(string[] args)
        {
            // Writes name of the game and the original author on a console.
            programInfo();

            // Program continues unless the user responds with "n".
            while (true)
            {
                // Writes a prompt passed by the parameter
                // and take and error-check user input.
                getQuestion("Ask a question?: ");

                // Console.ForegroundColor sets the colors of console characters.
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("\nThinking...");
                // "randomObject.Next" method returns a non-negative random integer 
                //  that is less than the specified parameter.
                // 1 <= randomObject.Next(5) + 1 <= 5
                int numberOfSecondsToSleep = ((randomObject.Next(5) + 1) * 1000);
                // Thread.Sleep suspends the thread for 
                // the specified number of milliseconds.
                // Suspends the program for 1-5 seconds.
                Thread.Sleep(numberOfSecondsToSleep);
                // Carriage return, 11 whitespaces to remove "thinking...", 
                // carriage return.
                Console.Write("\r           \r");
                // Writes a random answer from an array of defined answers.
                definedBallReplies();
                Console.WriteLine();

                Console.ForegroundColor = ConsoleColor.Green;
                // Terminates the program if user input is n.
                // Otherwise, the program restarts.
                if (getValidResponse("Again (Y|N)? ", ynresponses) == "n")
                {
                    // Terminates the closes enclosing loop.
                    break;
                }
            }

            Console.ForegroundColor = oldColor;
        }


        static void programInfo()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("Magic ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("8 ");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("Ball ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("(By: ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("Pandit ");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write("Akshay ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write(")");
            Console.WriteLine();
        }

        // Writes a prompt and error-check user input.
        static void getQuestion(string prompt)
        {
            // Same as while(1).
            for (; ; )
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine();
                Console.Write(prompt);

                Console.ForegroundColor = ConsoleColor.Gray;
                // ReadLine reads the next line of characters.
                // Trim removes whitespace characters from the current string object.
                // ToLower returns a string converted to lowercase.
                String userinput = Console.ReadLine().Trim().ToLower();
                // Error check userinput if it is at least 2 characters question
                // with a question mark.
                if ((userinput.Length >= 2) && (userinput[userinput.Length - 1] == '?'))
                {
                    // Terminates exectution of the method
                    // and returns control to the calling method.
                    return;
                }

                Console.ForegroundColor = ConsoleColor.Red;
                // User input can't be 0 or 1 character
                // because question mark is 1 character itself.
                if (userinput.Length < 2)
                {
                    Console.Write("Input is too short! ");
                    Console.WriteLine("Try again...");
                    // "continue" statement passes control 
                    // to the next interation of enclosing loop statement.
                    // Another iteration of for loop starts.
                    continue;
                }
                // If the last character of userinput is not a questionmark.
                if (userinput[userinput.Length - 1] != '?')
                {
                    Console.Write("A valid question ends with a \"?\" mark! ");
                    Console.WriteLine("Try again...");
                    continue;
                }
            }
        }

        // Writes a prompt "Again (Y|N)? "
        // Returns a user input if it is "y" or "n".
        // Otherwise, writes an error message.
        static string getValidResponse(string prompt, string[] valid)
        {
            for (; ; )
            {
                Console.Write(prompt);
                string result = Console.ReadLine().Trim().ToLower();
                // Check if user input matches with one of the predefined answers.
                for (int ii = 0; ii < valid.Length; ii++)
                {
                    if (result == valid[ii])
                    {
                        return result;
                    }
                }
                Console.WriteLine("Invalid input! Try again...");
                Console.WriteLine();
            }
        } // End function getValidResponse().

        // Writes a random string from an array of predefined answers.
        static void definedBallReplies()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            // Chooses a predefined answer from predictions[0] to predictions[18].
            int randomNumber = randomObject.Next(19);
            Console.WriteLine(predictions[randomNumber]);
            Console.WriteLine();
        }
    }

}

/* This code produces the following results:

Magic 8 Ball (By: Pandit Akshay )

Ask a question?: What do you think ßbout Dan?

YES!       


Again (Y|N)? Y       

Ask a question?: What do you think about Ted?

Ask again later


Again (Y|N)? N

Press any key to continue...

*/
