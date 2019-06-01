/*
 * Source: https://www.dotnetperls.com/duplicate-chars
 * Definition Source (mdoc): https://docs.microsoft.com/en-us/dotnet/
 * Author: dotnetperls
 * Summary: Removes duplicate characters using indexOf and for loop
 *          and compares turnaround time.
 * Modifications: Added a namespace.
 *                Removed "table" from "RemoveDuplicateCharsFast".
 *                Removed redundant declaration of key.Length.
 *                Added that a program prints the results.
 * Student: Ted Kim
 * Capture Date: May 08, 2019
 */

using System;
using System.Diagnostics;

namespace RemoveDuplicate
{

    class Program
    {
        const int _max = 1000000;
        static void Main()
        {

            // Runs a slower method that removes duplicates 1000000 times.
            var s1 = Stopwatch.StartNew();
            for (int i = 0; i < _max; i++)
            {
                string value = RemoveDuplicateChars("datagridviewtips");
                if (value == null)
                {
                    return;
                }
            }
            s1.Stop();

            // Runs a faster method that removes duplicates 1000000 times.
            var s2 = Stopwatch.StartNew();
            for (int i = 0; i < _max; i++)
            {
                string value = RemoveDuplicateCharsFast("datagridviewtips");
                if (value == null)
                {
                    return;
                }
            }
            s2.Stop();

            // Prints test results.
            Console.WriteLine("RemoveDuplicateChars: " + RemoveDuplicateChars("datagridviewtips"));
            Console.WriteLine("RemoveDuplicateCharsFast: " + RemoveDuplicateCharsFast("datagridviewtips"));

            // Prints elapsed time for each results.
            Console.WriteLine(((double)(s1.Elapsed.TotalMilliseconds * 1000000) /
                _max).ToString("0.00 ns"));
            Console.WriteLine(((double)(s2.Elapsed.TotalMilliseconds * 1000000) /
                _max).ToString("0.00 ns"));
            Console.Read();
        }

        // Remove duplicate characters using IndexOf method.
        static string RemoveDuplicateChars(string key)
        {
            string result = "";

            // For each characters in a string
            // If a character is not in the result string
            // append it to the result string.
            foreach (char value in key)
            {
                if (result.IndexOf(value) == -1)
                {
                    result += value;
                }
            }
            return result;
        }

        // Remove duplicate characters by using for loop.
        static string RemoveDuplicateCharsFast(string key)
        {

            // Creates a new result char[] that is potentially
            // as big as the original string.
            char[] result = new char[key.Length];
            int resultLength = 0;

            // Checks if each character is in result string using a for loop.
            foreach (char value in key)
            {

                bool exists = false;
                // If a character is not in result, add to the result.
                // Otherwise, do nothing.
                for (int i = 0; i < resultLength; i++)
                {
                    if (value == result[i])
                    {
                        exists = true;
                        break;
                    }
                }

                // If a character does not exist in result, add to the result.
                if (!exists)
                {

                    result[resultLength] = value;
                    resultLength++;
                }
            }
            // Return the string at this range.
            return new string(result, 0, resultLength);
        }
    }
}

/* This code produces the following results:

RemoveDuplicateChars: datgrivewps
RemoveDuplicateCharsFast: datgrivewps
522.77 ns
334.77 ns

 */
