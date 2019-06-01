/*
 * Source: https://www.youtube.com/watch?v=cST5TT3OFyg
 * Definition Source (mdoc): https://docs.microsoft.com/en-us/dotnet/
 * Author: Tim Corey
 * Summary: Reads from a text file, adds an entry, and writes new file contents onto a text file.
 * Modifications: Modified project name.
 *                Added a FileNotFoundException handler.
 *                Added periods(".") at the end of each line printed.
 *                Added a restart function.
 *                Added a method that prints List<Person>.
 *                Modified that it prints new file contents after adding an object.
 * Student: Ted Kim
 * Capture Date: April 28, 2019
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace ConsoleUI
{


    class Program
    {


        static void Main(string[] args)
        {
            while (true)
            {
                string filePath = "./tc_fileio.txt";

                List<Person> people = new List<Person>();

                try
                {
                    // "string[]" vs "List<string>": an array list is is not expandable
                    // but a List is. An array list is also indexed.
                    List<string> lines = File.ReadAllLines(filePath).ToList();

                    // Make a List<Person> from a file.
                    foreach (string line in lines)
                    {
                        // Splits a line separated by commas.
                        string[] entries = line.Split(',');

                        // If a line does not have 3 elements, skip.
                        if (entries.Length != 3)
                        {
                            // "+" operator concatenates strings.
                            Console.WriteLine("skipping invalid line in file: " + line + ".");
                            continue;
                        }

                        // Instantiates a Person object with 3 properties from a line.
                        Person newPerson = new Person(entries[0], entries[1], entries[2]);

                        // Adds a person to a List<Person>. 
                        people.Add(newPerson);
                    }

                    Console.WriteLine("Read from text file.\n");
                    // Prints each person.
                    printPeople(people);

                    // "new": "Used to create objects and invoke constructors" (mdoc).
                    // Adds a new Person object to the list.
                    people.Add(new Person("Greg", "Jones", "www.test.com"));
                    Console.WriteLine("\nA new entry was added.");

                    // Converts from List<Person> to List<string> to File.Write.AllLines.
                    List<string> output = new List<string>();
                    foreach (var person in people)
                    {
                        // "$": Interpolated strings.
                        output.Add($"{ person.FirstName },{ person.LastName },{ person.URL }");
                    }

                    Console.WriteLine("Writing to text file.");

                    // Writes a List<string> onto a file.
                    File.WriteAllLines(filePath, output);

                    Console.WriteLine("\nAll entries written.\n");
                    // Prints new file contents.
                    string newFileContents = File.ReadAllText(filePath);
                    Console.WriteLine(newFileContents);
                }
                // Cataches FileNotFoundException thrown in the try block.
                catch (FileNotFoundException ex)
                {
                    // "FileName" is a property of FileNotFoundException that
                    //  "[g]ets the name of the file that cannot be found" (mdoc).
                    Console.WriteLine("File was not found. Please create: {0}", ex.FileName);
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

        static void printPeople (List<Person> peopleList) 
        {
            foreach(Person person in peopleList)
            {
                Console.WriteLine($"{person.FirstName} {person.LastName}: {person.URL}");
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

skipping invalid line in file: stmartis.edu.
Read from text file.

Bahrt Dan: github.com/dbahrt
Kim Ted: github.com/tedkimflo

A new entry was added.
Writing to text file.

All entries written.

Bahrt,Dan,github.com/dbahrt
Kim,Ted,github.com/tedkimflo
Greg,Jones,www.test.com

Restart? (y/n)
Air Assault
Invalid Input.

Restart? (y/n)
y

Read from text file.

Bahrt Dan: github.com/dbahrt
Kim Ted: github.com/tedkimflo
Greg Jones: www.test.com

A new entry was added.
Writing to text file.

All entries written.

Bahrt,Dan,github.com/dbahrt
Kim,Ted,github.com/tedkimflo
Greg,Jones,www.test.com
Greg,Jones,www.test.com

Restart? (y/n)
n


Press any key to continue...

 */
