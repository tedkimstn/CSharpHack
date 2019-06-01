/*
 * Source: https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.stack-1?view=netframework-4.8
 * Definition Source (mdoc): https://docs.microsoft.com/en-us/dotnet/
 * Author: Microsoft Docs
 * Summary: Showcases Push, Pop, Peek and Clear function and count Properties of Stack<T>.
 * Modifications: Added a namespace.
 * Student: Ted Kim
 * Capture Date: May 07, 2019
 */

using System;
using System.Collections.Generic;

namespace Stack
{
    class Example
    {
        public static void Main()
        {
            // "Represents a variable size last-in-first-out (LIFO) collection" (mdoc).
            Stack<string> numbers = new Stack<string>();
            // "Inserts an object at the top of the Stack<T>" (mdoc).
            numbers.Push("one");
            numbers.Push("two");
            numbers.Push("three");
            numbers.Push("four");
            numbers.Push("five");

            // Prints each elements in a stack.
            foreach (string number in numbers)
            {
                Console.WriteLine(number);
            }

            // "Removes and returns the object at the top of the Stack<T>" (mdoc).
            Console.WriteLine("\nPopping '{0}'", numbers.Pop());
            // "Returns the object at the top of the Stack<T> without removing it" (mdoc).
            Console.WriteLine("Peek at next item to destack: {0}",
                numbers.Peek());
            Console.WriteLine("Popping '{0}'", numbers.Pop());

            // Makes an Array out of "numbers" stack and feed it into a stack
            // which results in a reverse stack.
            Stack<string> stack2 = new Stack<string>(numbers.ToArray());

            // Prints reversed stack.
            Console.WriteLine("\nContents of the first copy:");
            foreach (string number in stack2)
            {
                Console.WriteLine(number);
            }

            // Makes an Array of string with twice the size of "numbers" Stack.
            string[] array2 = new string[numbers.Count * 2];
            // Copies numbers Stack to an Array starting at index numbers.Count.
            numbers.CopyTo(array2, numbers.Count);

            // Makes a Stack out of an Array.
            Stack<string> stack3 = new Stack<string>(array2);

            // Prints a new Stack.
            Console.WriteLine("\nContents of the second copy, with duplicates and nulls:");
            foreach (string number in stack3)
            {
                Console.WriteLine(number);
            }

            // Prints "True" if a Stack contains "four". Otherwise, print "False".
            Console.WriteLine("\nstack2.Contains(\"four\") = {0}",
                stack2.Contains("four"));

            Console.WriteLine("\nstack2.Clear()");
            // "Removes all objects from the Stack<T>" (mdoc).
            stack2.Clear();
            // "Gets the number of elements contained in the Stack<T>" (mdoc).
            Console.WriteLine("\nstack2.Count = {0}", stack2.Count);
        }
    }
}

/* This code produces the following results:

five
four
three
two
one

Popping 'five'
Peek at next item to destack: four
Popping 'four'

Contents of the first copy:
one
two
three

Contents of the second copy, with duplicates and nulls:
one
two
three




stack2.Contains("four") = False

stack2.Clear()

stack2.Count = 0

Press any key to continue...

 */
