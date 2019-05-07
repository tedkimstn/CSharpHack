/*
 * Source: https://www.youtube.com/watch?v=4a_iTOtGhM8 
 * Definition Source (mdoc): https://docs.microsoft.com/en-us/dotnet/
 * Author: kudvenkat 
 * Summary: 
 * Modifications: Added a namespace.
 *                Moved Main method from bottom to top.
 *                Added name to each employee.
 *                Commented out a method that overrides a base class method
 *                in TemporaryEmployee class to see if base class method is used.
 * Student: Ted Kim
 * Capture Date: May 06, 2019
 */

using System;

namespace PolymorphismMProj
{

    public class Program
    {
        public static void Main()
        {
            // Instantitated a list of type Employee with a size of 5.
            Employee[] employees = new Employee[5];

            // Instantiated a FullTimeEmployee and 
            // assigned it to the first item of employees list.
            employees[0] = new FullTimeEmployee();
            // Modified FirstName and LastName using properties.
            employees[0].FirstName = "Dan";
            employees[0].LastName = "Bahrt";

            employees[1] = new PartTimeEmployee();
            employees[1].FirstName = "Ted";
            employees[1].LastName = "Kim";

            employees[2] = new TemporaryEmployee();
            employees[2].FirstName = "Snoop";
            employees[2].LastName = "Dogg";

            employees[3] = new InternEmployee();
            employees[3].FirstName = "John";
            employees[3].LastName = "Doe";

            // Did not change FirstName or LastName.
            // Using default FirstName and LastName.
            employees[4] = new Employee();

            // Calls overridden PrintFullName methods from each derived classes.
            foreach (Employee e in employees)
            {
                e.PrintFullName();
            }
        }
    }

    // Base class with a virtual method to be overrideen.
    public class Employee
    {
        public string FirstName = "FN";
        public string LastName = "LN";

        // A virtual method allows derived classes to modify it.
        public virtual void PrintFullName()
        {
            Console.WriteLine(FirstName + " " + LastName + " base default");
        }

    }

    // Inherits base class fields and methods.
    public class FullTimeEmployee : Employee
    {

        // Override keword allows a method to modify a method from base class.
        public override void PrintFullName()
        {
            Console.WriteLine(FirstName + " " + LastName + " Full Time");
        }

    }

    public class PartTimeEmployee : Employee
    {

        public override void PrintFullName()
        {
            Console.WriteLine(FirstName + " " + LastName + " Part Time");
        }
    }

    public class TemporaryEmployee : Employee
    {

        // A base class method is used when it is not overridden.
        /*
        public override void PrintFullName()
        {
            Console.WriteLine(FirstName + " " + LastName + " Temporary");
        }
        */
    }

    public class InternEmployee : Employee
    {

    }


}

/* This code produces the following results:

Dan Bahrt Full Time
Ted Kim Part Time
Snoop Dogg base default
John Doe base default
FN LN base default

Press any key to continue...

*/
