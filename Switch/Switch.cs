/*
 * Source: https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/switch
 * Definition Source (mdoc): https://docs.microsoft.com/en-us/dotnet/
 * Author: Microsoft Docs
 * Summary: Calculates various sizes of coffee using switch statements.
 * Modifications: Added a namespace.
 *                Added a restart manager.
 * Student: Ted Kim
 * Capture Date: May 09, 2019
 */

using System;

namespace Switch
{
    class Example
    {
       static void Main()
       {
           // Restart handler part 1/2.
           bool resume = true;
           while (resume)
           {
               Console.WriteLine("Coffee sizes: 1=small 2=medium 3=large");
               Console.Write("Please enter your selection: ");
               // Saves coffee size selection.
               string str = Console.ReadLine();

               int cost = 0;

               // "switch": "selection statement that chooses a single switch section 
               //  to execute from a list of candidates based on a pattern match 
               //  with the match expression.
               switch (str)
               {
                  // case "1" or "small".
                  // "small" costs 25 cents.
                  case "1":
                  case "small":
                      cost += 25;
                      // "terminates the closest enclosing loop 
                      //  or switch statement in which it appears" (mdoc).
                      break;
                  // "medium" costs 25 cents + 25 cents
                  case "2":
                  case "medium":
                      cost += 25;
                      // "transfers the program control 
                      //directly to a labeled statement" (mdoc).
                      goto case "1";
                  case "3":
                  case "large":
                      cost += 50;
                      goto case "1";
                   // "specifies the switch section to execute if the match expression 
                   // doesn't match any other case label" (mdoc).
                   default:
                      Console.WriteLine("Invalid selection. Please select 1, 2, or 3.");
                      break;
              }
              // If user made right size choices, print cost.
              if (cost != 0)
              {
                  Console.WriteLine("Please insert {0} cents.", cost);
              }
              Console.WriteLine("Thank you for your business.");

              resume = RestartHandler();
          }

        }

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

Coffee sizes: 1=small 2=medium 3=large
Please enter your selection: s
Invalid selection. Please select 1, 2, or 3.
Thank you for your business.
Restart? (y/n)
>y

Coffee sizes: 1=small 2=medium 3=large
Please enter your selection: 1
Please insert 25 cents.
Thank you for your business.
Restart? (y/n)
>y

Coffee sizes: 1=small 2=medium 3=large
Please enter your selection: medium
Please insert 50 cents.
Thank you for your business.
Restart? (y/n)
>n


Press any key to continue...

 */
