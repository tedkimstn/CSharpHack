/*
 * Source: https://www.tutorialspoint.com/csharp/csharp_bitwise_operators.htm
 * Definition Source (mdoc): https://docs.microsoft.com/en-us/dotnet/
 * Author: tutorialspoint
 * Summary: Showcases bitwise operations.
 * Modifications: Added a namespace.
 *                Modified WriteLine that user can identify which operation is used.
 * Student: Ted Kim
 * Capture Date: May 07, 2019
 */

using System;

namespace BitManipulationMProj
{

    class Program
    {

        static void Main(string[] args)
        {
            // 60 = 0011 1100
            int a = 60;
            // 13 = 0000 1101
            int b = 13;
            // 0 = 0000 0000
            int c = 0;

            // Logical AND.
            // "c" = 0000 1100 = 12.
            c = a & b;             
            Console.WriteLine("a & b - Value of c is {0}", c);

            // Logical OR.
            // "c" = 0011 1101 = 61.
            c = a | b;             
            Console.WriteLine("a | b - Value of c is {0}", c);

            // Logical XOR.
            // "c" = 0011 0001 = 49.
            c = a ^ b;            
            Console.WriteLine("a ^ b - Value of c is {0}", c);

            // Bitwise Complement.
            // "c" = 1100 0011 = -61.
            // Leading 1 in most-significant bit indicates a negative number.
            // 1100 0011 is a 2's complement of 61.
            c = ~a;                
            Console.WriteLine("~a - Value of c is {0}", c);

            // "shifts its first operand left 
            // by the number of bits defined by its second operand" (mdoc).
            // "c" = 1111 0000 = 240
            c = a << 2;      
            Console.WriteLine("a << 2 - Value of c is {0}", c);

            // "shifts its first operand right 
            //  by the number of bits defined by its second operand" (mdoc).
            // "c" = 0000 1111 = 15
            c = a >> 2;      
            Console.WriteLine("a >> 2 - Value of c is {0}", c);
            Console.ReadLine();
        }
    }
}

/* This code produces the following results:

a & b - Value of c is 12
a | b - Value of c is 61
a ^ b - Value of c is 49
~a - Value of c is -61
a << 2 - Value of c is 240
a >> 2 - Value of c is 15

 */
