/*
 * Source: https://github.com/tedkimstn/CSharpHack/blob/master/QueueStack/QueueStack.cs
 * Definition Source (mdoc): https://docs.microsoft.com/en-us/dotnet/
 * Author: Ted Kim
 * Summary: Simulates and reverses queues using stacks.
 * Modifications: N/A                
 * Student: N/A
 * Capture Date: June 07, 2019
 */

using System;
using System.IO;
using System.Collections.Generic;

namespace QueueStack
{
    class Program
    {
        static void Main(string[] args)
        {
        }

        // Reverses a non-empty queue using an empty stack.
        static void ReverseQueue<T>(Queue<T> Q)
        {
            // An empty stack initialization.
            Stack<T> S = new Stack<T>();

            // Deques each items in a queue ("Q")
            // and pushs it onto a stack (S). 
            while(Q.Count > 0)
            {
                S.Push(Q.Dequeue());
            }

            // Pops each items in a stack ("S")
            // and enqueues it into a queue ("Q").
            while(S.Count > 0)
            {
                Q.Enqueue(S.Pop());
            }
        }

        // Reverses lines of a file "input.txt" and saves them in "output.txt".
        static void ReverseFileLines()
        {
            // Read all lines of a file "input.txt".
            string[] readText = File.ReadAllLines("input.txt");

            // An empty stack initialization.
            Stack<string> S = new Stack<string>();

            // Pushes each line of a file "input.txt" onto a stack "S".
            foreach (string line in readText)
            {
                S.Push(line);
            }

            // Converts a stack into a string array. Lines reversed.
            string[] writeText = S.ToArray();
            // Saves reversed lines in a file "output.txt".
            File.WriteAllLines("output.txt", writeText);
        }
    }

    // A queue simulator using two stacks.
    class TwoStacksQueue<T>
    {
        // A stack used to assist simulating a queue.
        Stack<T> tempStack;
        // A queue simulator stack.
        Stack<T> queueStack;

        // A constructor.
        public TwoStacksQueue()
        {
            queueStack = new Stack<T>();
            tempStack = new Stack<T>();
        }

        // Adds an item to the end of a queue<t>.
        // Running time: O(n).
        public void Enqueue(T item)
        {
            // Transfers all items from a queueStack into tempStack.
            // A queue is reversed.
            while (queueStack.Count > 0)
            {
                tempStack.Push(queueStack.Pop());
            }

            // Adds a new item into a tempStack.
            // An item was added at the end of a queue.
            tempStack.Push(item);

            // Transfers all items from a queueStack into tempStack.
            // A reversed queue was reversed.
            while (tempStack.Count > 0)
            {
                queueStack.Push(tempStack.Pop());
            }
        }

        // Removes and returns an item at the beginning of a Queue<T>.
        // Running time: O(1).
        public T Dequeue()
        {
            return queueStack.Pop();
        }

        // Returns an item at the beginning of a Queue<T> without removing it.
        public T peek()
        {
            return queueStack.Peek();
        }

        // Checks if a Queue<T> is empty.
        public bool isEmpty()
        {
            bool empty = true;
            if(queueStack.Count > 0)
            {
                empty = false;
            }

            return empty;
        }
    }
}
