/*
 * Source: https://www.dotnetperls.com/reverse-string
 * Definition Source (mdoc): https://docs.microsoft.com/en-us/dotnet/
 * Author: dotnetperls
 * Summary: Reverses a string using a native method and a custom method
 *          and compares turnaround time.
 * Modifications: Added a namespace.
 *                Modified tests to see if methods are working.
 *                Removed length methods inside while loop to measure turnaround
 *                more accurately.
 *                Modified and moved turnaround time printer identifiers.
 *                Modified iteration time to gain turnaround time per a method call.
 * Student: Ted Kim
 * Capture Date: May 08, 2019
 */

using System;
using System.Diagnostics;

namespace ReverseString
{

    class Program
    {
        // Uses a native method char[].Reverse to reverse a string.
        public static string ReverseString(string s)
        {
            char[] array = s.ToCharArray();
            Array.Reverse(array);
            // Casts a char[] to a string.
            return new string(array);
        }

        // Custom method to reverse a string.
        public static string ReverseStringDirect(string s)
        {
            // Initializes an array to hold a reversed string.
            char[] array = new char[s.Length];
            int forward = 0;

            // reversedString[firstChar++] = originalString[lastChar--]
            for (int i = s.Length - 1; i >= 0; i--)
            {
                array[forward++] = s[i];
            }
            return new string(array);
        }



        static void Main()
        {
            const int _max = 1000;

            // Starts to measure time.
            var s1 = Stopwatch.StartNew();
            // Reverstring 1000 times to measure turnaround time with a native method.
            for (int i = 0; i < _max; i++)
            {
                ReverseString("programmingisfun");
            }
            // Stops Stopwatch.
            s1.Stop();
            // Prints to see if ReverString worked.
            Console.WriteLine("Native version: {0}", ReverseString("programmingisfun"));
            // Prints turnaround time.
            Console.WriteLine("Native version elapsed time: {0} seconds", s1.Elapsed.TotalMilliseconds);

            // Repeats the same process as above with a custom reverse string method.
            var s2 = Stopwatch.StartNew();
            for (int i = 0; i < _max; i++)
            {
                ReverseStringDirect("programmingisfun");
            }
            s2.Stop();
            Console.WriteLine("Custom version: {0}", ReverseStringDirect("programmingisfun"));
            Console.WriteLine("Custom version elapsed time: {0} seconds", s2.Elapsed.TotalMilliseconds);
        }
    }
}

/* This code produces the following results:

Native version: nufsignimmargorp
Native version elapsed time: 0.8354 seconds
Custom version: nufsignimmargorp
Custom version elapsed time: 0.4231 seconds

Press any key to continue...

 */
