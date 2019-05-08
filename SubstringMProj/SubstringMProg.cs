/*
 * Source: https://www.dotnetperls.com/substring
 * Definition Source (mdoc): https://docs.microsoft.com/en-us/dotnet/
 * Author: dotnetperls
 * Summary: Showcases efficiencies of using char access vs substring.
 * Modifications: Added a namespace.
 *                Printed test indentifiers.
 * Student: Ted Kim
 * Capture Date: May 07, 2019
 */

using System;
using System.Diagnostics;

namespace SubstringmProj
{
    class Program
    {
        // Value of a const variable is non-modifiable.
        const int _max = 1000000;

        static void Main()
        {
            const string value = "jounce";

            // "Stopwatch.StartNew()": "starts measuring elapsed time" (mdoc).
            var s1 = Stopwatch.StartNew();

            // Repeats the same process 1000000 times to measure turnaround time.
            for (int i = 0; i < _max; i++)
            {
                // Retrieves a substring that starts at index 0 and with length 1.
                string firstLetter = value.Substring(0, 1);
                if (firstLetter != "j")
                {
                    return;
                }
            }

            // Stops measuring elapsed time.
            s1.Stop();

            // Measures turnaround time of using char access.
            var s2 = Stopwatch.StartNew();
            for (int i = 0; i < _max; i++)
            {
                char firstLetter = value[0];
                if (firstLetter != 'j')
                {
                    return;
                }
            }
            s2.Stop();

            Console.Write("Substring: ");
            // Writes elapsed time in nano seconds using customized number format.
            Console.WriteLine(((double)(s1.Elapsed.TotalMilliseconds * 1000000) /
                _max).ToString("0.00 ns"));
            Console.Write("Char access: ");
            Console.WriteLine(((double)(s2.Elapsed.TotalMilliseconds * 1000000) /
                _max).ToString("0.00 ns"));
        }
    }
}

/* This code produces the following results:

Substring: 37.79 ns
Char access: 3.58 ns

Press any key to continue...

 */
