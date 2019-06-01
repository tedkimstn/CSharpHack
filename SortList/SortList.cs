/*
 * Source: https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1.sort?view=netframework-4.8
 * Definition Source (mdoc): https://docs.microsoft.com/en-us/dotnet/
 * Author: Microsoft Docs
 * Summary: Sorts a string list.
 * Modifications: Added a namespace.
 * Student: Ted Kim
 * Capture Date: May 09, 2019
 */

using System;
using System.Collections.Generic;

namespace SortList
{

    public class Example
    {
        public static void Main()
        {
            // String array of unsorted names.
            String[] names = { "Samuel", "Dakota", "Koani", "Saya", "Vanya", "Jody",
                         "Yiska", "Yuma", "Jody", "Nikita" };

            // Moves string array of unsorted names into a string list.
            // "AddRange": "Adds the elements of the specified collection 
            //  to the end of the List<T>" (mdoc).
            var nameList = new List<String>();
            nameList.AddRange(names);

            // Prints an unsorted list.
            Console.WriteLine("List in unsorted order: ");
            foreach (var name in nameList)
                Console.Write("   {0}", name);

            // "Environment.NewLine" = "\n".
            Console.WriteLine(Environment.NewLine);

            // "List<T>.Sort": "Sorts the elements or a portion of the elements in the List<T> 
            //  using either the specified or default IComparer<T> implementation or 
            //  a provided Comparison<T> delegate to compare list elements". (mdoc)
            nameList.Sort();

            // Prints a sorted list.
            Console.WriteLine("List in sorted order: ");
            foreach (var name in nameList)
                Console.Write("   {0}", name);

            Console.WriteLine();
        }
    }
}

/* This code produces the following results:

List in unsorted order: 
   Samuel   Dakota   Koani   Saya   Vanya   Jody   Yiska   Yuma   Jody   Nikita

List in sorted order: 
   Dakota   Jody   Jody   Koani   Nikita   Samuel   Saya   Vanya   Yiska   Yuma

Press any key to continue...

 */
