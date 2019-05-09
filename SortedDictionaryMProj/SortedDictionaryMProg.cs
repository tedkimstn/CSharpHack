/*
 * Source: https://www.dotnetperls.com/sorteddictionary
 * Definition Source (mdoc): https://docs.microsoft.com/en-us/dotnet/
 * Author: dotnetperls
 * Summary: A showcase of SortedDictionary that sorts itmes by Keys.
 * Modifications: Added a namespace.
 * Student: Ted Kim
 * Capture Date: May 09, 2019
 */

using System;
using System.Collections.Generic;

namespace SortedDictionaryMProj
{
    class Program
    {
        static void Main()
        {
            // "SortedDictionary": "a collection of Key/Value pairs 
            //  that are sorted on the Key" (mdoc).
            SortedDictionary<string, int> sort =
                new SortedDictionary<string, int>();

            // Add key/value pairs.
            sort.Add("zebra", 5);
            sort.Add("cat", 2);
            sort.Add("dog", 9);
            sort.Add("mouse", 4);
            sort.Add("programmer", 100);

            // Writes True/False if the SortedDictoinary contains a Key.
            if (sort.ContainsKey("dog"))
            {
                Console.WriteLine(true);
            }
            if (sort.ContainsKey("zebra"))
            {
                Console.WriteLine(true);
            }
            Console.WriteLine(sort.ContainsKey("ape"));

            int v;
            // "Dictionary<TKey,TValue>.TryGetValue(TKey, TValue)": 
            // "Gets the value associated with the specified key" (mdoc).
            // Returns True/False as return value and value in out parameter.
            if (sort.TryGetValue("programmer", out v))
            {
                Console.WriteLine(v);
            }

            // Prints SortedDictionary Key/Value pairs.
            foreach (KeyValuePair<string, int> p in sort)
            {
                Console.WriteLine("{0} = {1}",
                    p.Key,
                    p.Value);
            }
        }
    }
}

/* This code produces the following results:

True
True
False
100
cat = 2
dog = 9
mouse = 4
programmer = 100
zebra = 5

Press any key to continue...

 */
