/*
 * Source: https://www.tutorialspoint.com/csharp/csharp_inheritance.htm
 * Definition Source (mdoc): https://docs.microsoft.com/en-us/dotnet/
 * Author: tutorialspoint
 * Summary: Showcases implementation (of interface) and inheritance.
 * Modifications: Modified project and program name.
 *                Moved main method from bottom to top for readability.
 *                Combined declaration and assignment of int area.
 *                Modified to write area calculated, instead of calculating new area.
 * Student: Ted Kim
 * Capture Date: May 06, 2019
 */

using System;

namespace InheritanceMProj
{
    class Program
    {
        static void Main(string[] args)
        {
            // Instantiation of a Rectangle object.
            Rectangle Rect = new Rectangle();

            // Assigning values of width and height using
            // properties of base class of Rectangle, Shape.
            Rect.setWidth(5);
            Rect.setHeight(7);
            // Uses area method unique to class Rectangle.
            int area = Rect.getArea();

            Console.WriteLine("Total area: {0}", area);
            // Uses a method that implemented a method in interface PaintCost.
            Console.WriteLine("Total paint cost: ${0}", Rect.getCost(area));
            Console.ReadKey();
        }
    }

    // Base class.
    class Shape
    {
        // Base class properties.
        public void setWidth(int w)
        {
            width = w;
        }
        public void setHeight(int h)
        {
            height = h;
        }

        // Base class fields.
        protected int width;
        protected int height;
    }

    // Interface. All members of an interface must be implemented
    // when a class implements an interface.
    public interface PaintCost
    {
        int getCost(int area);
    }

    // "class Rectangle" inherits Shape class and implements PaintCost.
    // "class Rectangle" inherits members of base class Shape.
    // "class Rectangle" must implement all methods of PaintCost.
    class Rectangle : Shape, PaintCost
    {
        public int getArea()
        {
            return (width * height);
        }
        // Implements getCost method of PaintCost interface.
        public int getCost(int area)
        {
            return area * 70;
        }
    }

}