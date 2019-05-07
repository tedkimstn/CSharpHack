/*
 * Source: https://docs.microsoft.com/en-us/dotnet/api/system.int32.tryparse?view=netframework-4.8
 * Definition Source (mdoc): https://docs.microsoft.com/en-us/dotnet/
 * Author: Microsoft Docs.
 * Summary: Converts string representation of Int32 type to Int32 type.
 * Modifications: Added a namespace.
 * Student: Ted Kim
 * Capture Date: May 07, 2019
 */

using System;

namespace TryParseMProj
{
    public class Example
    {
        public static void Main()
        {
            String[] values = { null, "160519", "9432.0", "16,667",
                          "   -322   ", "+4302", "(100);", "01FA" };
            foreach (var value in values)
            {
                int number;

                // "Converts the string representation of a number to its 32-bit signed integer equivalent" (mdoc). 
                // "A return value indicates whether the conversion succeeded" (mdoc).
                bool success = Int32.TryParse(value, out number);
                if (success)
                {
                    Console.WriteLine("Converted '{0}' to {1}.", value, number);
                }
                else
                {
                    // "??": "null-coalescing operator. It returns the left-hand operand if the operand is not null;
                    // otherwise it returns the right hand operand" (mdoc).
                    Console.WriteLine("Attempted conversion of '{0}' failed.",
                                       value ?? "<null>");
                }
            }
        }
    }
}

/* This code produces the following results:

Attempted conversion of '<null>' failed.
Converted '160519' to 160519.
Attempted conversion of '9432.0' failed.
Attempted conversion of '16,667' failed.
Converted '   -322   ' to -322.
Converted '+4302' to 4302.
Attempted conversion of '(100);' failed.
Attempted conversion of '01FA' failed.

Press any key to continue...

 */
