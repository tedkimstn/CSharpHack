/*
 * Source: https://github.com/tedkimstn/CSharpExamples/blob/master/SinglyLinkedList/SinglyLinkedList.cs
 * Definition Source (mdoc): https://docs.microsoft.com/en-us/dotnet/
 * Author: Dr. Razvan A. Mezei
 * Summary: A reivented Singly Linked List.
 * Modifications: Modified a namespace.
 *                Modified the name of class "Node" to "SLLNode".
 *                Modified "value" property in Node class to "Value".
 *                Removed unnecessary "this" keyword in the Node class constructor.
 *                Relocated AddFirst method in the Node class to before AddLast method.
 *                Modified "delete" method in "SinglyLinkedList" class to "Delete".
 *                Relocated "RemoveFirst" method in "SinglyLinkedList" class before "Delete" method.
 *                Modified an IndexOutOfRangeException message in RemoveFirst method in "SinglyLinkedList" class.
 *                Modified an IndexOutOfRangeException message in Delete method in "SinglyLinkedList" class.
 *                Modified an Exception message in Delete method in "SinglyLinkedList" class.
 *                Modified an IndexOutOfRangeException message in RemoveLast method in "SinglyLinkedList" class.
 *                Removed "Console.WriteLine()"x2 from the PrintList method in "SinglyLinkedList" class.
 *                Modified a message that is displayed when a Singly Linked List is empty 
 *                in the PrintList method in "SinglyLinkedList" class.
 *                Relocated "SinglyLinkedList" constructor to below "SLLNode first".
 *                Modified "SLLNode" and "SinglyLinkedList" class to work with strings instead of ints.
 *                Added "PrintList" method in "SinglyLinkedList" class to print a new line after printing a "SinglyLinkedList".
 *                Added "RemoveDuplicates" method.
 *                Added "IsPalindrome" method.
 * Student: Ted Kim
 * Capture Date: June 01, 2019
 */

using System;
using System.Collections.Generic;

namespace SinglyLinkedList
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }

    // A node of a Singly Linked List.
    class SLLNode
    {
        // A value a node contains.
        public string Value { get; set; }

        // Each nodes of a Singly Linked List contains next node information.
        public SLLNode next;

        // Constructor.
        public SLLNode(string value)
        {
            Value = value;
            next = null;
        }
    }

    // A list of linked nodes where each nodes contains next node information.
    class SinglyLinkedList
    {
        // First node is the only known node information in a SinglyLinkedList.
        public SLLNode first;

        // A SinglyLinkedList constructor.
        public SinglyLinkedList()
        {
            first = null;
        }

        // Checks if a SinglyLinkedList is empty.
        // Running time: O(1).
        public bool IsEmpty() { return first == null; }

        // Creates a new node with a value 
        // and adds it at the beginning of a SinglyLinkedList.
        // Running time: O(1).
        public void AddFirst(string value)
        {
            SLLNode newNode = new SLLNode(value);
            newNode.next = first;
            first = newNode;
        }

        // Creates a new node and adds it at the end of a SinglyLinkedList.
        // Running time: O(n).
        public void AddLast(string val)
        {
            // If a SinglyLinked is empty, 
            // adds it at the beginning of a SingleyLinkedList.
            if (IsEmpty()) { AddFirst(val); }
            else
            {
                SLLNode newNode = new SLLNode(val);

                // Sets "current" node to the last node of a SingleyLinkedList.
                SLLNode current = first;
                while (current.next != null)
                {
                    current = current.next;
                }

                // Sets the new node as the next node of the last node.
                current.next = newNode;
            }
        }

        // Removes the first node of a SinglyLinkedList.
        // Running time: O(1).
        public void RemoveFirst()
        {
            if (IsEmpty())
                throw new IndexOutOfRangeException("You can't remove the first element from an empty list.");
            else
                first = first.next;
        }

        // Removes the last node of a SinglyLinkedList.
        // Running time: O(n).
        public void RemoveLast()
        {
            if (IsEmpty())
                throw new IndexOutOfRangeException("You can't remove the last element from an emtpy list.");
            // If there is only one element in a SinglyLinkedList.
            else if (first.next == null)
            {
                // Removes the only element from a SinglyLinkedList.
                first = null;
            }
            else
            {
                // Sets the current node as the node before the last node.
                SLLNode current = first;
                while (current.next.next != null)
                    current = current.next;

                // Removes the last node of a SinglyLinkedList.
                current.next = null;
            }
        }

        // Delete a node of a SinglyLinkedList that contains a specified value.
        // Running time: O(n).
        public void Delete(string val)
        {
            if (IsEmpty())
                throw new Exception("You can't delete an element from an empty list.");
            else if (val == first.Value)
                RemoveFirst();
            else
            {
                // Sets the current node as the node 
                // right before a node that contains a specified value
                // or the last node of a SinglyLinkedList.
                SLLNode curr = first;
                while (curr.next != null && curr.next.Value != val)
                    curr = curr.next;

                // If a node that contains a specified value does not exist.
                if (curr.next == null)
                    throw new Exception("A node that contains a specified value does not exist.");
                // If a node that contains a spcified value exists, deletes the node.
                else
                    curr.next = curr.next.next;
            }
        }

        // Inserts a node with a specified value in a sorted SinglyLinkedList.
        // Running time: O(n).
        public void Insert(string val)
        {
            // If a SinglyLinkedList is empty 
            // or a specified value is smaller than the value of the first node,
            // adds a new node at the beginning of a SinglyLinkedList.
            if (IsEmpty() || String.Compare(first.Value,val) > 0)
                AddFirst(val);
            else
            {
                // Creates a new node with the specified value.
                SLLNode newNode = new SLLNode(val);

                // Sets the current node as the last node of a SinglyLinkedList
                // or right before a node that contains a value 
                // that is greater than or equal to a specified value.
                SLLNode curr = first;
                while (curr.next != null && String.Compare(curr.next.Value, val) < 0)
                    curr = curr.next;

                // Inserts a new node between the current and the next node.
                newNode.next = curr.next;
                curr.next = newNode;
            }
        }

        // Prints all node values of a SinglyLinkedList.
        // Running time: O(n).
        public void PrintList()
        {
            if (IsEmpty())
                Console.Write("The SinglyLinkedList is empty.");
            else
            {
                // Prints the entire SinglyLinkedList.
                SLLNode current = first;
                while (current != null)
                {
                    Console.Write(current.Value + "  ");
                    current = current.next;
                }
            }

            Console.WriteLine();
        }

        // Remove duplicate values of a SinglyLinkedList.
        // Running time: O(n^2).
        public void RemoveDuplicates()
        {
            // Initializes the current node.
            SLLNode current = first;
            // Initializes the node that will be right before 
            // the node current node will be compared to.
            SLLNode beforeComparer = first;

            // Removes duplicate values.
            while(current != null && beforeComparer.next != null)
            {
                while(beforeComparer.next != null)
                {
                    if (current.Value == beforeComparer.next.Value)
                    {
                        beforeComparer.next = beforeComparer.next.next;
                    }
                    else { beforeComparer = beforeComparer.next; }
                }

                // Sets the current node as the next node in a SinglyLinkedList.
                current = current.next;
                // Sets the node that will be right before 
                // the node current node will be compared to.
                beforeComparer = current;
            }
        }

        // Checks if a SinglyLinkedList is a palindrome
        // which includes an empty or single-element SinglyLinkedList.
        // Running time: O(n).
        public bool IsPalindrome()
        {
            // Initializes the current node and a stack.
            SLLNode current = first;
            Stack<string> valueStack = new Stack<string>();

            // Transfers all values in a SinglyLinkedList to a stack.
            while(current != null)
            {
                valueStack.Push(current.Value);
                current = current.next;
            }

            // Initalizes the current node.
            current = first;

            // Checks if a SinglyLinkedList is a palindrome.
            for(int i = 0; i<valueStack.Count/2; i++)
            {
                if(current.Value != valueStack.Pop())
                {
                    return false;
                }
                current = current.next;
            }

            return true;
        }
    }
}
