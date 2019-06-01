/*
 * Source: https://docs.microsoft.com/en-us/dotnet/api/system.string.trim?view=netframework-4.8
 * Definition Source (mdoc): https://docs.microsoft.com/en-us/dotnet/
 * Author: Microsoft Docs
 * Summary: Trims user input by eliminating whitespaces.
 * Modifications: Added a namespace.           
 * Student: Ted Kim
 * Capture Date: May 09, 2019
 */

using System;

public class Example
{
   public static void Main()
   {
      // Receives first name user input.
      Console.Write("Enter your first name: ");
      string firstName = Console.ReadLine();

      // Receives middle name user input.
      Console.Write("Enter your middle name or initial: ");
      string middleName = Console.ReadLine();
      
      // Receives last name user input.
      Console.Write("Enter your last name: ");
      string lastName = Console.ReadLine();
      
      // Prints received user input.
      Console.WriteLine();
      Console.WriteLine("You entered '{0}', '{1}', and '{2}'.", 
                        firstName, middleName, lastName);
      
      // Prints trimmed and concatenated user input.
      // "trim": "Returns a new string in which all leading and trailing occurrences 
      //  of a set of specified characters from the current String object are removed" (mdoc).
      string name = ((firstName.Trim() + " " + middleName.Trim()).Trim() + " " + 
                    lastName.Trim()).Trim();
      Console.WriteLine("The result is " + name + ".");
   }
}

/* This code produces the following results:

Enter your first name:            Ted            
Enter your middle name or initial:    T.
Enter your last name: Kim             

You entered '           Ted            ', '   T.', and 'Kim             '.
The result is Ted T. Kim.

Press any key to continue...

 */
