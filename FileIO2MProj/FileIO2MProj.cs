/*
 * Source: https://www.youtube.com/watch?v=cST5TT3OFyg
 * Definition Source (mdoc): https://docs.microsoft.com/en-us/dotnet/
 * Author: Tim Corey
 * Summary: Reads a file, store each line as a Person object with properties.        
 * Modifications: Modified project name.
 *                Added FileNotFoundException handler.
 *                Added restart function.
 * Student: Ted Kim
 * Capture Date: April 28, 2019
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace FileIO2MProj
{


    class Program
    {


        static void Main(string[] args)
        {
            while (true)
            {
                string filePath = "./tc_fileio.txt";

                // Instantiates a list of type Person.
                List<Person> people = new List<Person>();

                try
                {
                    // Creates a list of string objects where each element is 
                    // each line read from the file.
                    List<string> lines = File.ReadAllLines(filePath).ToList();

                    foreach (string line in lines)
                    {
                        // "Split": "String.Split method creates an array of substrings 
                        //  by splitting the input string based on one or more delimiters" (mdocs).
                        // Splits each line by commas and stores them in a string array.
                        string[] entries = line.Split(',');

                        // If a line is not consisted of 3 elements, skip.
                        if (entries.Length != 3)
                        {
                            Console.WriteLine("skipping invalid line in file: " + line);
                            continue;
                        }
                        // Creates a person object with 3 elements from a line.
                        Person newPerson = new Person(entries[0], entries[1], entries[2]);
                        // Add the person object to a List<Person>
                        people.Add(newPerson);
                    }
                }
                catch (FileNotFoundException ex)
                {
                    Console.WriteLine("File was not found. Please create: {0}", ex.FileName);
                }

                Console.WriteLine();

                // Prints each person object using properties of the class Person.
                foreach (var person in people)
                {
                    // "$": "special character identifies a string literal as an interpolated string" (mdoc).
                    // Instead of Console.WriteLine("{0} {1}: {2}", person.FirstName, person.LastName, person.URL);
                    Console.WriteLine($"{ person.FirstName } { person.LastName }: { person.URL }");
                }
                // Ask user to restart or not.
                bool restart = Restart();
                if (restart == true) { continue; }
                if (restart == false) { break; }

            }
        }

        static bool Restart()
        {
            while (true)
            {
                Console.WriteLine("Restart? (y/n)");
                // "ReadLine" reads a line of user input.
                string restart = Console.ReadLine();

                if (restart == "y") { Console.WriteLine(); return true; }
                else if (restart == "n") { Console.WriteLine(); return false; }
                else { Console.WriteLine("Invalid Input.\n"); }
            }
        }

    }


    class Person
    {
        public string FirstName;
        public string LastName;
        public string URL;


        public Person(string fn, string ln, string url)
        {
            FirstName = fn;
            LastName = ln;
            URL = url;
        }
    }


}

/* This code produces the following results:

Bahrt Dan: github.com/dbahrt
Kim Ted: github.com/tedkimflo
Restart? (y/n)
Airborne
Invalid Input.

Restart? (y/n)
y


Bahrt Dan: github.com/dbahrt
Kim Ted: github.com/tedkimflo
Restart? (y/n)
n


Press any key to continue...

 */
