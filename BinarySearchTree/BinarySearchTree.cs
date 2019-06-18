/*
 * Source: N/A
 * Definition Source (mdoc): https://docs.microsoft.com/en-us/dotnet/
 * Author: Ted Kim
 * Summary: Binary Search Tree
 * Modifications: N/A
 * Student: Ted Kim
 * Capture Date: June 16, 2019
 */

using System;
using System.Collections.Generic;

namespace BinarySearchTree
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }

    // A value of a node.
    class Student
    {
        // Properties.
        public string Name { get; set; }
        public string Major { get; set; }
        public string OriginState { get; set; }

        // A constructor.
        public Student(string studentName, string studentMajor, string studentOriginState)
        {
            Name = studentName;
            Major = studentMajor;
            OriginState = studentOriginState;
        }
    }

    // A node of a Binary Search Tree.
    class Node
    {
        // Properties.
        public Student Value { get; set; }
        public Node Left { get; set; }
        public Node Right { get; set; }

        // A constructor.
        public Node(Student nodeValue)
        {
            Value = nodeValue;
        }
    }

    // A Binary Search Tree (BST).
    class Tree
    {
        // A property.
        public Node Root { get; set; }

        // A constructor.
        public Tree()
        {
            Root = null;
        }

        // Inserts a new student created using parameters into a BST.
        public void Insert(string studName, string major, string originState)
        {
            Insert(new Student(studName, major, originState));
        }

        // Inserts a newStudent into a BST.
        public void Insert(Student newStudent)
        {
            // If a BST is empty, newStudent becomes the Root.
            if (Root == null) { Root = new Node(newStudent); }
            else
            {
                // Initializes the current node.
                Node current = Root;

                while (true)
                {
                    // If a newStudent's name comes after the current student's name.
                    if (String.Compare(newStudent.Name, current.Value.Name) > 0)
                    {
                        // If the right node of the current node is null,
                        // set it to point to the newStudent.
                        if (current.Right == null)
                        {
                            current.Right = new Node(newStudent);
                            break;
                        }
                        // If the right node of the current node is not null,
                        // move the current node to point to it.
                        else
                        {
                            current = current.Right;
                        }
                    }
                    // If a newStudent's name comes before the current student's name
                    // or the students' names are the same.
                    else
                    {
                        // If the left node of the current node is null,
                        // set it to point to the newStudent.
                        if (current.Left == null)
                        {
                            current.Left = new Node(newStudent);
                            break;
                        }
                        // If the left node of the current node is not null,
                        // move the current node to point to it.
                        else
                        {
                            current = current.Left;
                        }
                    }
                }
            }
        }

        // Prints the BST in inorder (Left, Node, Right).
        public void PrintInOrder()
        {
            // Calls PrintInOrderHelper with an initial node.
            PrintInOrderHelper(Root);
        }

        // Prints the BST in inorder recursively.
        public void PrintInOrderHelper(Node node)
        {
            // Does not print anything for an empty node.
            if (node != null)
            {
                // Prints the left sub-tree of a node.
                PrintInOrderHelper(node.Left);
                // Prints the node.
                Console.WriteLine(node.Value.Name);
                // Prints the right sub-tree of a node.
                PrintInOrderHelper(node.Right);
            }
        }

        // Prints the BST in preorder (Node, Left, Right).
        public void PrintPreOrder()
        {
            PrintPreOrderHelper(Root);
        }

        // Prints the BST in preorder recursively.
        public void PrintPreOrderHelper(Node node)
        {
            // Does not print anything for an empty node.
            if (node != null)
            {
                // Prints the node.
                Console.WriteLine(node.Value.Name);
                // Prints the left sub-tree of a node.
                PrintPreOrderHelper(node.Left);
                // Prints the right sub-tree of a node.
                PrintPreOrderHelper(node.Right);
            }
        }

        // Prints the BST in postorder (Left, Right, Node).
        public void PrintPostOrder()
        {
            PrintPostOrderHelper(Root);
        }

        // Prints the BST in postorder (Left, Right, Node).
        public void PrintPostOrderHelper(Node node)
        {
            if (node != null)
            {
                // Prints the left sub-tree of a node.
                PrintPostOrderHelper(node.Left);
                // Prints the right sub-tree of a node.
                PrintPostOrderHelper(node.Right);
                // Prints the node.
                Console.WriteLine(node.Value.Name);
            }
        }

        // Search if a Student with a specified name exists in a BST.
        public bool Search(string studName)
        {
            // Fields initialization.
            bool exists = false;
            Node current = Root;

            while (current != null)
            {
                // A Student with a specified name exists.
                if (String.Compare(studName, current.Value.Name) == 0)
                {
                    exists = true;
                    break;
                }
                // If "studName" comes before the current student's name.
                else if (String.Compare(studName, current.Value.Name) < 0)
                {
                    current = current.Left;
                }
                // If "studName" comes after the current student's name.
                else if (String.Compare(studName, current.Value.Name) > 0)
                {
                    current = current.Right;
                }
            }

            return exists;
        }

        // Finds a height of a BST.
        public int height()
        {
            // If a BST is empty.
            if (Root == null) { return -1; }
            // Calls heightHelper with initial values.
            else { return heightHelper(Root, 0); }
        }

        // Finds a height of a BST with a given node and the current height.
        public int heightHelper(Node node, int height)
        {
            // Initializes the current height of each subtrees.
            int left = height;
            int right = height;

            // If the left subtree exists, calls heightHelper with the left node and incrementd height.
            if (node.Left != null) { left = heightHelper(node.Left, height + 1); }
            // If the right subtree exists, calls heightHelper with the right node and incrementd height.
            if (node.Right != null) { right = heightHelper(node.Right, height + 1); }

            // Returns a height of a taller subtree.
            if (left > right) { return left; }
            else { return right; }
        }

        // Finds the number of leaf nodes.
        public int numLeafNodes()
        {
            // If a BST is empty.
            if (Root == null) { return 0; }
            // Calls numLeafNodesHelper with an initial value.
            else { return numLeafNodesHelper(Root); }
        }

        // Finds the number of leaf nodes with a give node.
        public int numLeafNodesHelper(Node node)
        {
            // If both the left and right nodes are null, there is a node.
            if (node.Left == null && node.Right == null)
            {
                return 1;
            }
            else
            {
                // Initializes number of left and right nodes.
                int left = 0;
                int right = 0;

                // If there is a left or right subtree, calls numLeafNodesHelper with either nodes.
                if (node.Left != null) { left = numLeafNodesHelper(node.Left); }
                if (node.Right != null) { right = numLeafNodesHelper(node.Right); }

                // Returns the total number of nodes.
                return left + right;
            }
        }
    }
}
