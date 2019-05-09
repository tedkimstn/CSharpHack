/*
 * Source: https://www.geeksforgeeks.org/c-sharp-sealed-class/
 * Definition Source (mdoc): https://docs.microsoft.com/en-us/dotnet/
 * Author: Akanksha_Rai
 * Summary: Showcases sealed class members.
 * Modifications: Added a namespace.
 * Student: Ted Kim
 * Capture Date: May 09, 2019
 */

using System;

namespace SealedMProj
{

    class Printer
    {
        // Shows dimension.
        // "virtual": "allow for it to be overridden in a derived class" (mdoc).
        public virtual void show()
        {
            Console.WriteLine("display dimension : 6*6");
        }

        // Prints class name.
        public virtual void print()
        {
            Console.WriteLine("printer printing....\n");
        }
    }

    // LaserJet class inherits Printer class.
    class LaserJet : Printer
    {

        // "sealed" Prevents derived classes from modifying it.
        // "override": "extend or modify the abstract or virtual implementation 
        //  of an inherited method" (mdoc).
        sealed override public void show()
        {
            Console.WriteLine("display dimension : 12*12");
        }

        override public void print()
        {
            Console.WriteLine("Laserjet printer printing....\n");
        }
    }

    class Officejet : LaserJet
    {

        override public void print()
        {
            Console.WriteLine("Officejet printer printing....");
        }
    }

    class Program
    {

        static void Main(string[] args)
        {
            // Prints inherited and overridden methods.
            Printer p = new Printer();
            p.show();
            p.print();

            Printer ls = new LaserJet();
            ls.show();
            ls.print();

            Printer of = new Officejet();
            of.show();
            of.print();
        }
    }
}

/* This code produces the following results:

display dimension : 6*6
printer printing....

display dimension : 12*12
Laserjet printer printing....

display dimension : 12*12
Officejet printer printing....

Press any key to continue...

 */
