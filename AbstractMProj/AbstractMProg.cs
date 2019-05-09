/*
 * Source: https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/abstract
 * Definition Source (mdoc): https://docs.microsoft.com/en-us/dotnet/
 * Author: Microsoft Docs
 * Summary: Showcases usage of abstract class and overriding properties and methods.
 * Modifications: Added a namespace.
 *                Added using System.
 * Student: Ted Kim
 * Capture Date: May 09, 2019
 */
using System;

namespace AbstractMProj
{

    // "abstract": "indicates that the thing being modified has 
    //              a missing or incomplete implementation" (mdoc).
    abstract class BaseClass
    {
        // "protected": "accessible within its class 
        //  and by derived class instances" (mdoc).
        protected int _x = 100;
        protected int _y = 150;
        public abstract void AbstractMethod();
        public abstract int X { get; }
        public abstract int Y { get; }
    }

    // DerivedClass inherits BaseClass.
    class DerivedClass : BaseClass
    {
        // "override": "extend or modify the abstract or virtual implementation 
        //  of an inherited method, property, indexer, or event" (mdoc).
        // Increments _x and _y by 1 each.
        public override void AbstractMethod()
        {
            _x++;
            _y++;
        }

        // Returns 110.
        public override int X 
        {
            get
            {
                return _x + 10;
            }
        }

        // Returns 160.
        public override int Y 
        {
            get
            {
                return _y + 10;
            }
        }

        static void Main()
        {
            DerivedClass o = new DerivedClass();
            // Calls AbstractMethod that is defined in DerivedClass.
            o.AbstractMethod();
            Console.WriteLine("x = {0}, y = {1}", o.X, o.Y);
        }
    }
}


/* This code produces the following results:

x = 111, y = 161

Press any key to continue...

 */
