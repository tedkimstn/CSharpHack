/*
 * Source: https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/delegate
 * Definition Source (mdoc): https://docs.microsoft.com/en-us/dotnet/
 * Author: Microsoft Docs
 * Summary: Showcases usage of the delegate reference type.
 * Modifications: Added a namespace.
 *                Added using System.
 * Student: Ted Kim
 * Capture Date: May 07, 2019
 */

using System;

namespace Delegate
{

    // Delegate declaration.
    // "delegate" keyword + method signature with return type.
    // "Delegates are used to pass methods as arguments to other methods" (mdoc).
    delegate double MathAction(double num);

    class DelegateTest
    {

        // Returns double amount of an input.
        static double DoubleAmount(double input)
        {
            return input * 2;
        }

        static void Main()
        {

            // Delegate instantiation with method "DoubleAmount".
            MathAction ma = DoubleAmount;

            // Calls delegate ma that is associated with method "DoubleAmount".
            double multByTwo = ma(4.5);
            Console.WriteLine("multByTwo: {0}", multByTwo);

            // Instantiate a delegate associate with an anonymous method
            // that returns squared amount of an input with return type double.
            MathAction ma2 = delegate (double input)
            {
                return input * input;
            };

            // Calls ma2 delegate associate with an anonymous method that
            // returns squared amount of an input.
            double square = ma2(5);
            Console.WriteLine("square: {0}", square);

            // Instantiate a delegate with a lambda expression.
            // A delegate can be instantiated with a method or a lambda expression.
            // The following lambda expression returns cubed amount of an input.
            MathAction ma3 = s => s * s * s;
            double cube = ma3(4.375);

            Console.WriteLine("cube: {0}", cube);
        }
   
    }
}

/* This code produces the following results:

multByTwo: 9
square: 25
cube: 83.740234375

Press any key to continue...

 */
