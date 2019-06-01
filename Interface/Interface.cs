/*
 * Source: https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/interface
 * Definition Source (mdoc): https://docs.microsoft.com/en-us/dotnet/
 * Author: Microsoft Docs
 * Summary: Demonstrates implementing an interface.
 * Modifications: Added a namespace.
 *                Added using System.
 * Student: Ted Kim
 * Capture Date: May 07, 2019
 */

using System;

namespace Interface
{
    // An interface with two properties.
    // All members must be implemented 
    // by a class that implements an interface.
    interface IPoint
    {

        int x
        {
            get;
            set;
        }

        int y
        {
            get;
            set;
        }
    }

    // A class that implements IPoint interface.
    class Point : IPoint
    {

        // Private fields.
        private int _x;
        private int _y;

        // A constructor that is initialized 
        // when an object is instantiated with x and y values.
        public Point(int x, int y)
        {
            _x = x;
            _y = y;
        }

        // Implements a properties of the interface IPoint.
        public int x
        {
            get
            {
                return _x;
            }

            set
            {
                _x = value;
            }
        }
        public int y
        {
            get
            {
                return _y;
            }
            set
            {
                _y = value;
            }
        }
    }

    class MainClass
    {
        // Prints x and y values of an object 
        // that implements IPoint using properties.
        static void PrintPoint(IPoint p)
        {
            Console.WriteLine("x={0}, y={1}", p.x, p.y);
        }

        static void Main()
        {
            // IPoint can be used as a type as Point implements IPoint.
            // Instantiate a Point.
            IPoint p = new Point(2, 3);
            Console.Write("My Point: ");
            // Prints a Point.
            PrintPoint(p);
        }
    }
}

/* This code produces the following results:

My Point: x=2, y=3

Press any key to continue...

 */
