/*
 * Source: https://github.com/tedkimstn/CSharpHack/blob/master/SinglyLinkedList/SinglyLinkedList.cs
 * Definition Source (mdoc): https://docs.microsoft.com/en-us/dotnet/
 * Author: Ted Kim
 * Summary: A reinvented Doubly Linked List.
 * Modifications: Modified a namespace.
 *                Modified from "SLLNode" and "SinglyLinkedList" to "DLLNode" and "DoublyLinkedList"
 *                Modified fields and methods in previous "SLLNode" and "SinglyLinkedList"
 *                that they work with Doubly Linked List.
 *                Modified that "DLLNode" and "DoublyLinkedList" work with ints instead of strings.
 *                Added "printReverse" method in "doublyLinkedList" class.
 * Student: Ted Kim
 * Capture Date: June 03, 2019
 */

using System;
using System.Collections.Generic;

namespace DoublyLinkedList
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }

    // A node of a Doubly Linked List.
    class DLLNode
    {
        // A value a node contains.
        public int Value { get; set; }

        // Each nodes of a Doubly Linked List contains 
        // previous and next node information.
        public DLLNode previous;
        public DLLNode next;

        // Constructor.
        public DLLNode(int value)
        {
            Value = value;
            previous = null;
            next = null;
        }
    }

    // A list of linked nodes where each nodes contains next node information.
    class DoublyLinkedList
    {
        // First node is the only known node information in a DoublyLinkedList.
        public DLLNode first;

        // A DoublyLinkedList constructor.
        public DoublyLinkedList()
        {
            first = null;
        }

        // Checks if a DoublyLinkedList is empty.
        // Running time: O(1).
        public bool IsEmpty() { return first == null; }

        // Creates a new node with a value 
        // and adds it at the beginning of a DoublyLinkedList.
        // Running time: O(1).
        public void AddFirst(int value)
        {
            DLLNode newNode = new DLLNode(value);

            if (!this.IsEmpty()) 
            { 
                first.previous = newNode;
                newNode.next = first;
            }

            first = newNode;
        }

        // Creates a new node and adds it at the end of a DoublyLinkedList.
        // Running time: O(n).
        public void AddLast(int val)
        {
            // If a DoublyLinked is empty, 
            // adds it at the beginning of a DoublyLinkedList.
            if (IsEmpty()) { AddFirst(val); }
            else
            {
                DLLNode newNode = new DLLNode(val);

                // Sets "current" node to the last node of a DoublyLinkedList.
                DLLNode current = first;
                while (current.next != null)
                {
                    current = current.next;
                }

                current.next = newNode;
                newNode.previous = current;
            }
        }

        // Removes the first node of a DoublyLinkedList.
        // Running time: O(1).
        public void RemoveFirst()
        {
            if (IsEmpty())
                throw new IndexOutOfRangeException("You can't remove the first element from an empty list.");
            else
            {
                first = first.next;
                first.previous = null;
            }
        }

        // Removes the last node of a DoublyLinkedList.
        // Running time: O(n).
        public void RemoveLast()
        {
            if (IsEmpty())
                throw new IndexOutOfRangeException("You can't remove the last element from an emtpy list.");
            // If there is only one element in a DoublyLinkedList.
            else if (first.next == null)
            {
                // Removes the only element from a DoublyLinkedList.
                first = null;
            }
            else
            {
                // Sets the current node as the node before the last node.
                DLLNode current = first;
                while (current.next.next != null)
                    current = current.next;

                // Removes the last node of a DoublyLinkedList.
                current.next = null;
            }
        }

        // Delete a node of a DoublyLinkedList that contains a specified value.
        // Running time: O(n).
        public void Delete(int val)
        {
            if (IsEmpty())
                throw new Exception("You can't delete an element from an empty list.");
            else if (val == first.Value)
                RemoveFirst();
            else
            {
                // Sets the current node as the node 
                // right before a node that contains a specified value
                // or the last node of a DoublyLinkedList.
                DLLNode curr = first;
                while (curr.next != null && curr.next.Value != val)
                    curr = curr.next;

                // If a node that contains a specified value does not exist.
                if (curr.next == null)
                    throw new Exception("A node that contains a specified value does not exist.");
                // If a node that contains a spcified value exists, deletes the node.
                else
                {
                    curr.next = curr.next.next;
                    curr.next.next.previous = curr;
                }
            }
        }

        // Inserts a node with a specified value in a sorted DoublyLinkedList.
        // Running time: O(n).
        public void Insert(int val)
        {
            // If a DoublyLinkedList is empty 
            // or a specified value is smaller than the value of the first node,
            // adds a new node at the beginning of a DoublyLinkedList.
            if (IsEmpty() || first.Value > val)
                AddFirst(val);
            else
            {
                // Creates a new node with the specified value.
                DLLNode newNode = new DLLNode(val);

                // Sets the current node as the last node of a DoublyLinkedList
                // or right before a node that contains a value 
                // that is greater than or equal to a specified value.
                DLLNode curr = first;
                while (curr.next != null && curr.next.Value < val)
                    curr = curr.next;

                // Inserts a new node between the current and the next node.
                newNode.previous = curr;
                newNode.next = curr.next;
                curr.next = newNode;
                if (newNode.next != null) { newNode.next.previous = newNode; }
            }
        }

        // Prints all values of nodes in a DoublyLinkedList.
        // Running time: O(n).
        public void PrintList()
        {
            if (IsEmpty())
                Console.Write("The DoublyLinkedList is empty.");
            else
            {
                // Prints the entire DoublyLinkedList.
                DLLNode current = first;
                while (current != null)
                {
                    Console.Write(current.Value + "  ");
                    current = current.next;
                }
            }

            Console.WriteLine();
        }

        // Prints all values of nodes in a DoublyLinkedList in a reverse way.
        // Running time: O(n).
        public void printReverse()
        {
            if (IsEmpty())
                Console.Write("The DoublyLinkedList is empty.");
            else
            {
                // Sets the current node as the last node in a DoublyLinkedList.
                DLLNode current = first;
                while (current.next != null)
                {
                    current = current.next;
                }

                // Prints the entire DoublyLinkedList.
               while (current != null)
                {
                    Console.Write(current.Value + "  ");
                    current = current.previous;
                }
            }
        }

        // Remove duplicate values of a DoublyLinkedList.
        // Running time: O(n^2).
        public void RemoveDuplicates()
        {
            // Initializes the current node.
            DLLNode current = first;
            // Initializes the node that will be right before 
            // the node current node will be compared to.
            DLLNode beforeComparer = first;

            // Removes duplicate values.
            while (current != null && beforeComparer.next != null)
            {
                while (beforeComparer.next != null)
                {
                    if (current.Value == beforeComparer.next.Value)
                    {
                        beforeComparer.next = beforeComparer.next.next;
                    }
                    else { beforeComparer = beforeComparer.next; }
                }

                // Sets the current node as the next node in a DoublyLinkedList.
                current = current.next;
                // Sets the node that will be right before 
                // the node current node will be compared to.
                beforeComparer = current;
            }
        }

        // Checks if a DoublyLinkedList is a palindrome
        // which includes an empty or single-element DoublyLinkedList.
        // Running time: O(n).
        public bool IsPalindrome()
        {
            // Initializes the current node and a stack.
            DLLNode current = first;
            Stack<int> valueStack = new Stack<int>();

            // Transfers all values in a DoublyLinkedList to a stack.
            while (current != null)
            {
                valueStack.Push(current.Value);
                current = current.next;
            }

            // Initalizes the current node.
            current = first;

            // Checks if a DoublyLinkedList is a palindrome.
            for (int i = 0; i < valueStack.Count / 2; i++)
            {
                if (current.Value != valueStack.Pop())
                {
                    return false;
                }
                current = current.next;
            }

            return true;
        }
    }
}

