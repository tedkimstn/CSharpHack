/*
 * Source: https://www.dotnetperls.com/lambda
 * Definition Source (mdoc): https://docs.microsoft.com/en-us/dotnet/
 * Author: dotnetperls
 * Summary: A showcase of a lambda expression that
 *          uses "=>" to separate parameters with expressions.
 * Modifications: Added a namespace.
 * Student: Ted Kim
 * Capture Date: May 09, 2019
 */

using System;
using System.Collections.Generic;

namespace Lambda
{

    class Program
    {
        static void Main()
        {
            // A List of int elements.
            List<int> elements = new List<int>() { 10, 20, 31, 40 };
            // Find an index of the first odd number from elements List.
            // => or "go to" separates parameters with an expression.
            int oddIndex = elements.FindIndex(x => x % 2 != 0);
            // Prints an index of the first odd item.
            Console.WriteLine(oddIndex);
        }
    }
}

/* This code produces the following results:

2

Press any key to continue...

 */
