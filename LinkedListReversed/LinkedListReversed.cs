/*
 * Source: https://www.geeksforgeeks.org/reverse-a-linked-list/
 * Definition Source (mdoc): https://docs.microsoft.com/en-us/dotnet/
 * Author: Mayank Sharma
 * Summary: Reverses a LinkedList.
 * Modifications: Added a namespace.
 * Student: Ted Kim
 * Capture Date: May 08, 2019
 */

using System;

namespace LinkedListReversed
{
    class GFG
    {
        static void Main(string[] args)
        {
            // Creates a new LinkedList.
            LinkedList list = new LinkedList();

            // Creates nodes with data.
            list.AddNode(new LinkedList.Node(85));
            list.AddNode(new LinkedList.Node(15));
            list.AddNode(new LinkedList.Node(4));
            list.AddNode(new LinkedList.Node(20));

            Console.WriteLine("Given linked list:");
            // Prints a LinkedList.
            list.PrintList();

            // Reverse a LinkedList.
            list.ReverseList();

            Console.WriteLine("Reversed linked list:");
            list.PrintList();
        }
    }

    // A data stcuture with nodes, data and a head.
    class LinkedList
    {
        // Head of a LinkedList pointing to a next node.
        Node head;

        // A node is consisted of data (int) and next (Node).
        public class Node
        {
            public int data;
            public Node next;

            public Node(int d)
            {
                data = d;
                next = null;
            }
        }

        // Adds a new node in a LinkedList.
        public void AddNode(Node node)
        {
            // If it is the first node in a LinkedList,
            // it is the head.
            if (head == null)
                head = node;
            // If it is not the first node,
            // Current LinkedList's last node points to the new node.
            else
            {
                Node temp = head;
                while (temp.next != null)
                {
                    temp = temp.next;
                }
                temp.next = node;
            }
        }

        // Reverse the order of a LinkedList.
        public void ReverseList()
        {
            Node prev = null, current = head, next = null;
            while (current != null)
            {
                // Saves next node to move onto next node at the end.
                next = current.next;
                // Sets previous node as next node.
                current.next = prev;
                // Sets current node as previous node that
                // next node can set its previous node as next node.
                prev = current;
                // Moves onto next node.
                current = next;
            }
            // The last node becomes the head.
            head = prev;
        }

        // Prints each data of nodes of a LinkedList.
        public void PrintList()
        {
            // Starts from the head.
            Node current = head;
            // Until a node is not a null.
            while (current != null)
            {
                // Writes the data of the current node.
                Console.Write(current.data + " ");
                // Moves onto the next node.
                current = current.next;
            }
            Console.WriteLine();
        }
    }
}

/* This code produces the following results:

Given linked list:
85 15 4 20 
Reversed linked list:
20 4 15 85 

Press any key to continue...

 */

