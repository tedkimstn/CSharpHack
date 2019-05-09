/*
 * Source: https://www.geeksforgeeks.org/nested-classes-in-c-sharp/
 * Definition Source (mdoc): https://docs.microsoft.com/en-us/dotnet/
 * Author: ankita_saini
 * Summary: Showcases a type of encapsulation that uses nested classes.
 * Modifications: Added a namespace.
 *                Added another inner class to showcase method call between inner classes.
 * Student: Ted Kim
 * Capture Date: May 09, 2019
 */

using System;

namespace NestedClassesMproj
{
    // Nested classes group classes that are related.
    public class Outer_class
    {

        public int number = 1000000;

        // Nested inner class.
        public class Inner_class
        {
        
            // A method in an inner class have access to members of an outer class.
            // A method in an inner class also instantiate an outer class.
            public static void method1()
            {
               

                Outer_class obj = new Outer_class();

                Console.WriteLine(obj.number);
            }
        }

        public class Inner_class_2
        {
            // Calls a method from another inner class.
            public static void method1()
            {
                Console.WriteLine("Method call from Inner_class_2");
                Inner_class.method1();
            }
        }
    }

    public class GFG
    {

        static public void Main()
        {
            // A method in inner class prints a number in outerclass.
            Console.WriteLine("Method call from Main method");
            Outer_class.Inner_class.method1();
            // A method call from an inner class to antoher inner class.
            Outer_class.Inner_class_2.method1();
        }
    }
}

/* This code produces the following results:

Method call from Main method
1000000
Method call from Inner_class_2
1000000

Press any key to continue...

 */
