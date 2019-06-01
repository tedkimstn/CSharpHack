/*
 * Source: https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.queue-1?view=netframework-4.8
 * Definition Source (mdoc): https://docs.microsoft.com/en-us/dotnet/
 * Author: Microsoft Docs
 * Summary: Showcases basic functions and properties of a Queue collection.
 * Modifications: Added a namespace.
 * Student: Ted Kim
 * Capture Date: May 07, 2019
 */

using System;
using System.Collections.Generic;

namespace Queue
{

    class Example
    {
        public static void Main()
        {
            // Queue is a FIFO (first-in, first-out) collections of objects. 
            Queue<string> numbers = new Queue<string>();
            // "Adds an object to the end of the Queue<T>" (mdoc).
            numbers.Enqueue("one");
            numbers.Enqueue("two");
            numbers.Enqueue("three");
            numbers.Enqueue("four");
            numbers.Enqueue("five");

            // Prints each item in queue.
            foreach (string number in numbers)
            {
                Console.WriteLine(number);
            }
            // "Removes and returns the object at the beginning of the Queue<T>" (mdoc).
            Console.WriteLine("\nDequeuing '{0}'", numbers.Dequeue());
            // "Returns the object at the beginning of the Queue<T> without removing it" (mdoc).
            Console.WriteLine("Peek at next item to dequeue: {0}",
                numbers.Peek());
            Console.WriteLine("Dequeuing '{0}'", numbers.Dequeue());

            // Creates a copy of a queue by converting it to Array and assigning it to a new queue.
            Queue<string> queueCopy = new Queue<string>(numbers.ToArray());

            Console.WriteLine("\nContents of the first copy:");
            foreach (string number in queueCopy)
            {
                Console.WriteLine(number);
            }

            // Copies "number" queue to an array starting at midpoint.
            string[] array2 = new string[numbers.Count * 2];
            numbers.CopyTo(array2, numbers.Count);

            // Creates a new queue using "array2".
            Queue<string> queueCopy2 = new Queue<string>(array2);

            // Prints a new copied queue.
            Console.WriteLine("\nContents of the second copy, with duplicates and nulls:");
            foreach (string number in queueCopy2)
            {
                Console.WriteLine(number);
            }
            // Prints "True" if a queue contains "four". Otherwise, prints "False".
            Console.WriteLine("\nqueueCopy.Contains(\"four\") = {0}",
                queueCopy.Contains("four"));

            Console.WriteLine("\nqueueCopy.Clear()");
            // Empties a queue.
            queueCopy.Clear();
            // Counts how many items are in a queue.
            Console.WriteLine("\nqueueCopy.Count = {0}", queueCopy.Count);
        }
    }
}

/* This code produces the following results:

one
two
three
four
five

Dequeuing 'one'
Peek at next item to dequeue: two
Dequeuing 'two'

Contents of the first copy:
three
four
five

Contents of the second copy, with duplicates and nulls:



three
four
five

queueCopy.Contains("four") = True

queueCopy.Clear()

queueCopy.Count = 0

Press any key to continue...

 */
