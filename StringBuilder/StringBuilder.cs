/*
 * Source: https://docs.microsoft.com/en-us/dotnet/api/system.text.stringbuilder?view=netframework-4.8
 * Definition Source (mdoc): https://docs.microsoft.com/en-us/dotnet/
 * Author: Microsoft Docs
 * Summary: Showcases functions of a StringBuilder class such as Append, Insert and Replace. 
 * Modifications: Added a namespace.
 *                Removed unnecessary ToStrig() when printing a StringBuilder.
 * Student: Ted Kim
 * Capture Date: May 07, 2019
 */

using System;
using System.Text;

namespace StringBuilde
{
    // "sealed": "prevents other classes from inheriting from it" (mdoc).
    public sealed class App
    {
        static void Main()
        {

            // "StringBuilder": "Represents a mutable string of characters" (mdoc).
            // "StringBuilder(String, Int32)" is initialized with specified string and capacity.
            StringBuilder sb = new StringBuilder("ABC", 50);

            // Appends a list of characters.
            sb.Append(new char[] { 'D', 'E', 'F' });

            // "AppendFormat": "Appends the string returned by 
            // processing a composite format string" (mdoc).
            sb.AppendFormat("GHI{0}{1}", 'J', 'k');

            // StringBuilder.Length returns number of characters not its capacity.
            Console.WriteLine("{0} chars: {1}", sb.Length, sb);

            // Inserts a string at specified position.
            sb.Insert(0, "Alphabet: ");

            // Replaces all occurences of the first char with the second char.
            // StringBuilder is case-sensitive.
            sb.Replace('k', 'K');


            Console.WriteLine("{0} chars: {1}", sb.Length, sb);
        }
    }
}

/* This code produces the following results:

11 chars: ABCDEFGHIJk
21 chars: Alphabet: ABCDEFGHIJK

Press any key to continue...

 */
