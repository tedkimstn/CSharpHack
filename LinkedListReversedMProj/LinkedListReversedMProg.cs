/*
 * Source: https://www.geeksforgeeks.org/reverse-a-linked-list/
 * Definition Source (mdoc): https://docs.microsoft.com/en-us/dotnet/
 * Author: Mayank Sharma
 * Summary: 
 * Modifications: 
 * Student: Ted Kim
 * Capture Date: May , 2019
 */

using System; 

class GFG 
{ 
    static void Main(string[] args) 
    { 
        LinkedList list = new LinkedList(); 
        list.AddNode(new LinkedList.Node(85)); 
        list.AddNode(new LinkedList.Node(15)); 
        list.AddNode(new LinkedList.Node(4)); 
        list.AddNode(new LinkedList.Node(20)); 
    
        Console.WriteLine("Given linked list:"); 
        list.PrintList(); 
    
        list.ReverseList(); 
    
        Console.WriteLine("Reversed linked list:"); 
        list.PrintList(); 
    } 
} 

class LinkedList 
{ 
    Node head; 

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

    public void AddNode(Node node) 
    { 
        if (head == null) 
            head = node; 
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

    public void ReverseList() 
    { 
        Node prev = null, current = head, next = null; 
        while(current!=null) 
        { 
            next = current.next; 
            current.next = prev; 
            prev = current; 
            current = next; 
        } 
        head = prev; 
    } 

    public void PrintList() 
    { 
        Node current = head; 
        while(current != null) 
        { 
            Console.Write(current.data + " "); 
            current = current.next; 
        } 
        Console.WriteLine(); 
    } 
} 


