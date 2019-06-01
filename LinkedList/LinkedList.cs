/*
 * Source: https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.linkedlist-1?view=netframework-4.8
 * Definition Source (mdoc): https://docs.microsoft.com/en-us/dotnet/
 * Author: Microsoft Docs
 * Summary: A program that showcases methods and properties of LinkedList and prints test results.
 * Modifications: Added a namespace.
 * Student: Ted Kim
 * Capture Date: May 07, 2019
 */

using System;
using System.Text;
using System.Collections.Generic;

namespace LinkedList
{

    public class Example
    {
        public static void Main()
        {
            // ArrayList of type string.
            string[] words =
                { "the", "fox", "jumps", "over", "the", "dog" };
            // "LinkedList<T>": "Represents a doubly linked list" (mdoc).
            // LinkedList<T>(IEnumerable<T>).
            LinkedList<string> sentence = new LinkedList<string>(words);
            // Prints test identifier each item in sentence linked list.
            Display(sentence, "The linked list values:");
            // "LinkedList<T>.Contains(T)": "Determines whether a value is in the LinkedList<T>" (mdoc).
            Console.WriteLine("sentence.Contains(\"jumps\") = {0}",
                sentence.Contains("jumps"));
            // "LinkedList<T>.AddFirst": "Adds a new node or value at the start of the LinkedList<T>" (mdoc).
            sentence.AddFirst("today");
            // Print a new LinkedList.
            Display(sentence, "Test 1: Add 'today' to beginning of the list:");

            // "LinkedListNode <string>" = "Represents a node in a LinkedList<T>" (mdoc).
            // "LinkedList<T>.First": "Gets the first node of the LinkedList<T>" (mdoc).
            LinkedListNode<string> mark1 = sentence.First;
            // "Removes the node at the start of the LinkedList<T>" (mdoc).
            sentence.RemoveFirst();
            // "Adds a new node or value at the end of the LinkedList<T>" (mdoc).
            sentence.AddLast(mark1);
            Display(sentence, "Test 2: Move first node to be last node:");

            // "Removes the node at the end of the LinkedList<T>" (mdoc).
            sentence.RemoveLast();
            sentence.AddLast("yesterday");
            Display(sentence, "Test 3: Change the last node to 'yesterday':");

            // "Gets the last node of the LinkedList<T>" (mdoc).
            mark1 = sentence.Last;
            sentence.RemoveLast();
            sentence.AddFirst(mark1);
            Display(sentence, "Test 4: Move last node to be first node:");


            sentence.RemoveFirst();
            // "Finds the last node that contains the specified value" (mdoc).
            LinkedListNode<string> current = sentence.FindLast("the");
            // Put parenthesis around the last occurence of "the" and prints new sentence.
            IndicateNode(current, "Test 5: Indicate last occurence of 'the':");

            // "Adds a new node or value after an existing node in the LinkedList<T>" (mdoc).
            sentence.AddAfter(current, "old");
            sentence.AddAfter(current, "lazy");
            IndicateNode(current, "Test 6: Add 'lazy' and 'old' after 'the':");

            current = sentence.Find("fox");
            IndicateNode(current, "Test 7: Indicate the 'fox' node:");

            sentence.AddBefore(current, "quick");
            sentence.AddBefore(current, "brown");
            IndicateNode(current, "Test 8: Add 'quick' and 'brown' before 'fox':");

            mark1 = current;
            LinkedListNode<string> mark2 = current.Previous;
            current = sentence.Find("dog");
            IndicateNode(current, "Test 9: Indicate the 'dog' node:");

            Console.WriteLine("Test 10: Throw exception by adding node (fox) already in the list:");
            try
            {
                // "Adds a new node or value before an existing node in the LinkedList<T>" (mdoc).
                sentence.AddBefore(current, mark1);
            }
            // "The exception that is thrown when a method call is invalid for the object's current state (mdoc).
            catch (InvalidOperationException ex)
            {
                // "Gets a message that describes the current exception" (mdoc).
                Console.WriteLine("Exception message: {0}", ex.Message);
            }
            Console.WriteLine();

            // "Removes the specified node from the LinkedList<T>" (mdoc).
            sentence.Remove(mark1);
            sentence.AddBefore(current, mark1);
            IndicateNode(current, "Test 11: Move a referenced node (fox) before the current node (dog):");

            sentence.Remove(current);
            IndicateNode(current, "Test 12: Remove current node (dog) and attempt to indicate it:");

            sentence.AddAfter(mark2, current);
            IndicateNode(current, "Test 13: Add node removed in test 11 after a referenced node (brown):");

            sentence.Remove("old");
            Display(sentence, "Test 14: Remove node that has the value 'old':");

            sentence.RemoveLast();
            // LinkedList<T> implements ICollection.
            ICollection<string> icoll = sentence;
            icoll.Add("rhinoceros");
            Display(sentence, "Test 15: Remove last node, cast to ICollection, and add 'rhinoceros':");

            Console.WriteLine("Test 16: Copy the list to an array:");
            // Initializes an string Array.
            string[] sArray = new string[sentence.Count];
            // "Copies the entire LinkedList<T> to a compatible one-dimensional Array, 
            //  starting at the specified index of the target array" (mdoc).
            sentence.CopyTo(sArray, 0);

            // Prints each item in an Array.
            foreach (string s in sArray)
            {
                Console.WriteLine(s);
            }

            // "Removes all nodes from the LinkedList<T>" (mdoc).
            sentence.Clear();

            Console.WriteLine();
            // Checks if "sentence" LinkedList contains a node of value "jumps".
            Console.WriteLine("Test 17: Clear linked list. Contains 'jumps' = {0}",
                sentence.Contains("jumps"));

            Console.ReadLine();
        }

        // Prints test identifier and each item in a LinkedList.
        private static void Display(LinkedList<string> words, string test)
        {
            Console.WriteLine(test);
            foreach (string word in words)
            {
                Console.Write(word + " ");
            }
            Console.WriteLine();
            Console.WriteLine();
        }

        // Prints test identifier.
        // Prints a LinkedList with the node in parameter in parenthesis.
        private static void IndicateNode(LinkedListNode<string> node, string test)
        {
            // Prints test identifier.
            Console.WriteLine(test);
            // "LinkedListNode.List": "Gets the LinkedList<T> that the LinkedListNode<T> belongs to" (mdoc).
            // Method terminates if a LinkedListNode is not linked.
            // "LinkedListNode.ValueGets": "the value contained in the node" (mdoc).
            if (node.List == null)
            {
                Console.WriteLine("Node '{0}' is not in the list.\n",
                    node.Value);
                return;
            }

            // Concatenates parenthesis with a node value.
            StringBuilder result = new StringBuilder("(" + node.Value + ")");
            // "Gets the previous node in the LinkedList<T>" (mdoc).
            LinkedListNode<string> nodeP = node.Previous;

            // Add all nodes before node.Value to result.
            while (nodeP != null)
            {
                // "Inserts a string into this instance at the specified character position" (mdoc).
                result.Insert(0, nodeP.Value + " ");
                nodeP = nodeP.Previous;
            }

            // Add all nodes after node.Value to result.
            node = node.Next;
            while (node != null)
            {
                // "Appends a copy of the specified string to this instance" (mdoc).
                result.Append(" " + node.Value);
                node = node.Next;
            }

            Console.WriteLine(result);
            Console.WriteLine();
        }
    }

}

/* This code produces the following results:

The linked list values:
the fox jumps over the dog 

sentence.Contains("jumps") = True
Test 1: Add 'today' to beginning of the list:
today the fox jumps over the dog 

Test 2: Move first node to be last node:
the fox jumps over the dog today 

Test 3: Change the last node to 'yesterday':
the fox jumps over the dog yesterday 

Test 4: Move last node to be first node:
yesterday the fox jumps over the dog 

Test 5: Indicate last occurence of 'the':
the fox jumps over (the) dog

Test 6: Add 'lazy' and 'old' after 'the':
the fox jumps over (the) lazy old dog

Test 7: Indicate the 'fox' node:
the (fox) jumps over the lazy old dog

Test 8: Add 'quick' and 'brown' before 'fox':
the quick brown (fox) jumps over the lazy old dog

Test 9: Indicate the 'dog' node:
the quick brown fox jumps over the lazy old (dog)

Test 10: Throw exception by adding node (fox) already in the list:
Exception message: The LinkedList node already belongs to a LinkedList.

Test 11: Move a referenced node (fox) before the current node (dog):
the quick brown jumps over the lazy old fox (dog)

Test 12: Remove current node (dog) and attempt to indicate it:
Node 'dog' is not in the list.

Test 13: Add node removed in test 11 after a referenced node (brown):
the quick brown (dog) jumps over the lazy old fox

Test 14: Remove node that has the value 'old':
the quick brown dog jumps over the lazy fox 

Test 15: Remove last node, cast to ICollection, and add 'rhinoceros':
the quick brown dog jumps over the lazy rhinoceros 

Test 16: Copy the list to an array:
the
quick
brown
dog
jumps
over
the
lazy
rhinoceros

Test 17: Clear linked list. Contains 'jumps' = False

 */