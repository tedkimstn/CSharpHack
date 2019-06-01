/*
 * Source: https://www.sanfoundry.com/csharp-program-convert-decimal-binary/
 * Definition Source (mdoc): https://docs.microsoft.com/en-us/dotnet/
 * Author: sanfoundry
 * Summary: Converts a decimal number to a binary number.
 * Modifications: Added a namespace.
 *                
 * Student: Ted Kim
 * Capture Date: May 09, 2019
 */

using System;

namespace DecimalToBinary
{

    class myclass
    {
        static void Main()
        {
            int num;
            Console.Write("Enter a Number : ");
            // Converts a string to an int type.
            num = int.Parse(Console.ReadLine());

            int quot;
            string rem = "";


            // Divides a number by 2 and keep appending remainders to a string
            // while a number or quotient is >=1.
            while (num >= 1)
            {
                quot = num / 2;
                rem += (num % 2).ToString();
                num = quot;
            }
            string bin = "";
            // Reverse the order of appended remainders.
            for (int i = rem.Length - 1; i >= 0; i--)
            {
                bin = bin + rem[i];
            }
           
            Console.WriteLine("The Binary format for given number is {0}", bin);
        }
    }

}

/* This code produces the following results:

Enter a Number : 128
The Binary format for given number is 10000000

Press any key to continue...

 */
