/*
 * Source: https://www.dotnetperls.com/split
 * Definition Source (mdoc): https://docs.microsoft.com/en-us/dotnet/
 * Author: dotnetperls
 * Summary: Splits a string using delimiters.
 * Modifications: Added a namespace.
 * Student: Ted Kim
 * Capture Date: May 09, 2019
 */

using System;

namespace StringSplit
{
class Program
{
    static void Main()
    {
        // A string that represents a directory.
        const string dir = @"C:\Users\Sam\Documents\Perls\Main";
        // Splits a string by \ delimiter and stores it in a string array.
        string[] parts = dir.Split('\\');

        // Prints a string without \ delimiter
        foreach (string part in parts)
        {
            Console.WriteLine(part);
        }
    }
}
}

/* This code produces the following results:

C:
Users
Sam
Documents
Perls
Main

Press any key to continue...

 */
