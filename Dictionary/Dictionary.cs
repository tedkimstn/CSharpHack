/*
 * Source: https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.dictionary-2?view=netframework-4.8
 * Definition Source (mdoc): https://docs.microsoft.com/en-us/dotnet/
 * Author: Microsoft Docs
 * Summary: Creates a dictionary, adds, removes and retrieves elements, 
 *          checks if it contains keys, and handle dictionary execptions.
 * Modifications: Modified project name.
 *                Added a TryGetValue uninitalized out-parameter value test.
 *                Modified Variable names for readability.
 *                Added a test to see if a value was removed when a key was removed.
 * Student: Ted Kim
 * Capture Date: April 22, 2019
 */

using System;
using System.Collections.Generic;

namespace Dictionary
{
    public class Program
    {
        public static void Main()
        {
            // A dictionary with string keys and string values.
            Dictionary<string, string> openWith =
                new Dictionary<string, string>();

            // "Add": "Adds the specified key and value to the dictionary" (mdoc).
            openWith.Add("txt", "notepad.exe");
            openWith.Add("bmp", "paint.exe");
            openWith.Add("dib", "paint.exe");
            openWith.Add("rtf", "wordpad.exe");

            // "try"-"catch": "When an exception is thrown, the common language runtime (CLR) 
            //  looks for the catch statement that handles this exception" (mdoc).
            // In "try" block, dictionary collection throws ArgumentException when duplicate key is added.
            try
            {
                openWith.Add("txt", "winword.exe");
            }
            // "catch" block include code that handles ArgumentException.
            catch (ArgumentException)
            {
                Console.WriteLine("An element with Key = \"txt\" already exists.");
            }

            // Dictionary[key] returns a value.
            Console.WriteLine("For key = \"rtf\", value = {0}.",
                openWith["rtf"]);

            // Dictionary[key] = newValue.
            openWith["rtf"] = "winword.exe";
            Console.WriteLine("For key = \"rtf\", value = {0}.",
                openWith["rtf"]);

            // If key does not exist, adds a new key-value pair.
            openWith["doc"] = "winword.exe";

            // If a key is not found in dictionary, it throws KeyNotFoundException.
            try
            {
                Console.WriteLine("For key = \"tif\", value = {0}.",
                    openWith["tif"]);
            }
            catch (KeyNotFoundException)
            {
                Console.WriteLine("Key = \"tif\" is not found.");
            }


            string value = "";
            // If key is found, TryGetValue returns method return value true
            // and found-value in out-parameter (2nd parameter).
            // Otherwise, returns false and uninitialized out-parameter.
            if (openWith.TryGetValue("tif", out value))
            {
                Console.WriteLine("For key = \"tif\", value = {0}.", value);
            }
            else
            {
                Console.WriteLine("Key = \"tif\" is not found.");
                // "TryGetValue" returns nothing in out-parameter.
                Console.WriteLine("For key = \"tif\", value = {0}.", value);
            }

            // "ContainsKey": "true if the IDictionary<TKey,TValue> contains an element with the key; otherwise, false" (mdoc).
            // If key "ht" is not found.
            if (!openWith.ContainsKey("ht"))
            {
                openWith.Add("ht", "hypertrm.exe");
                // Use \" to print quotation marks.
                Console.WriteLine("Value added for key = \"ht\": {0}",
                    openWith["ht"]);
            }


            Console.WriteLine();
            // "Since each element of a collection based on IDictionary<TKey,TValue> is a key/value pair, 
            //  the element type is not the type of the key or the type of the value" (mdoc). 
            // kvp is a local variable of specified type.
            foreach (KeyValuePair<string, string> kvp in openWith)
            {
                Console.WriteLine("Key = {0}, Value = {1}",
                    // ".Key" and ".Value" returns a key and a value respectively.
                    kvp.Key, kvp.Value);
            }

            // "ValueCollection": "collection of values in a Dictionary<TKey,TValue>" (mdoc). 
            Dictionary<string, string>.ValueCollection valueColl =
                // "Values": "Gets a collection containing the values in the Dictionary<TKey,TValue>" (mdoc).
                openWith.Values;


            Console.WriteLine();
            foreach (string val in valueColl)
            {
                Console.WriteLine("Value = {0}", val);
            }


            Dictionary<string, string>.KeyCollection keyColl =
                // ".Keys" gets a collection containing the keys
                openWith.Keys;


            Console.WriteLine();
            foreach (string key in keyColl)
            {
                Console.WriteLine("Key = {0}", key);
            }


            Console.WriteLine("\nRemove(\"doc\")");
            // ".Remove": "Removes the element with the specified key" (mdoc). 
            openWith.Remove("doc");

            if (!openWith.ContainsKey("doc"))
            {
                Console.WriteLine("Key \"doc\" is not found.");
            }


            Console.WriteLine();
            // Test to see if .Remove removed a value with a key.
            foreach (string val in valueColl)
            {
                Console.WriteLine("Value = {0}", val);
            }

        }
    }
}

/* This code produces the following results:

An element with Key = "txt" already exists.
For key = "rtf", value = wordpad.exe.
For key = "rtf", value = winword.exe.
Key = "tif" is not found.
Key = "tif" is not found.
For key = "tif", value = .
Value added for key = "ht": hypertrm.exe

Key = txt, Value = notepad.exe
Key = bmp, Value = paint.exe
Key = dib, Value = paint.exe
Key = rtf, Value = winword.exe
Key = doc, Value = winword.exe
Key = ht, Value = hypertrm.exe

Value = notepad.exe
Value = paint.exe
Value = paint.exe
Value = winword.exe
Value = winword.exe
Value = hypertrm.exe

Key = txt
Key = bmp
Key = dib
Key = rtf
Key = doc
Key = ht

Remove("doc")
Key "doc" is not found.

Value = notepad.exe
Value = paint.exe
Value = paint.exe
Value = winword.exe
Value = hypertrm.exe

Press any key to continue...

*/
