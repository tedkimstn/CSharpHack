/*
 * Source: https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/delegate
 * Definition Source (mdoc): https://docs.microsoft.com/en-us/dotnet/
 * Author: Microsoft Docs
 * Summary: 
 * Modifications: Added a namespace.
 *                Added using System.
 * Student: Ted Kim
 * Capture Date: May 07, 2019
 */

using System;

namespace DelegateMProj
{

    delegate double MathAction(double num);

    class DelegateTest
    {

        static double DoubleAmount(double input)
        {
            return input * 2;
        }

        static void Main()
        {

            MathAction ma = DoubleAmount;


            double multByTwo = ma(4.5);
            Console.WriteLine("multByTwo: {0}", multByTwo);

           
            MathAction ma2 = delegate (double input)
            {
                return input * input;
            };

            double square = ma2(5);
            Console.WriteLine("square: {0}", square);


            MathAction ma3 = s => s * s * s;
            double cube = ma3(4.375);

            Console.WriteLine("cube: {0}", cube);
        }
   
    }
}
/* This code produces the following results:



 */