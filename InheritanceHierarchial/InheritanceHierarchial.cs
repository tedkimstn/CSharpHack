/*
 * Source: https://www.sanfoundry.com/csharp-program-hierarchical-inheritence/
 * Definition Source (mdoc): https://docs.microsoft.com/en-us/dotnet/
 * Author: sanfoundry
 * Summary: Showcases hierarchial inheritance where a child class inherits parents memebrs.
 * Modifications: Modified a namespace.
 *                Removed unnecessary using namespaces.
 *                Reversed hierarchy from Student : Principal, Teacher : Principal
 *                to Principal : Teacher : Stduent.
 *                Modified Monitor method to Manage method in Principal class.
 *                Changed variable names for classes.
 *                Changed orders and types of method calls in Main method.
 * Student: Ted Kim
 * Capture Date: May 09, 2019
 */


using System;

namespace InheritanceHierarchial
{
    class Program
    {
        static void Main(string[] args)
        {

            // A child class inherits members of parents classes.
            Principal terrence = new Principal();
            Console.WriteLine("\nPrincipal Terrence: ");
            terrence.Manage();
            terrence.Teach();
            terrence.Learn();

            Teacher dan = new Teacher();
            Console.WriteLine("\nTeacher Dan: ");
            dan.Teach();
            dan.Learn();

            Student ted = new Student();
            Console.WriteLine("\nStudent Ted: ");
            ted.Learn();
          
        }

        // Base class.
        class Student
        {
            public void Learn()
            {
                Console.WriteLine("Learn");
            }
        }
        // Teacher class extends Student class.
        // Derived class inherits Stduent class members.
        class Teacher : Student
        {
            public void Teach()
            {
                Console.WriteLine("Teach");
            }
        }
        // Principal class inherits Teacher and Student class members.
        class Principal : Teacher
        {
            public void Manage()
            {
                Console.WriteLine("Manage");
            }
        }
    }
}

/* This code produces the following results:

Principal Terrence: 
Manage
Teach
Learn

Teacher Dan: 
Teach
Learn

Student Ted: 
Learn

Press any key to continue...

 */
