/*
 * Source: https://www.youtube.com/watch?v=cST5TT3OFyg
 * Definition Source (mdoc): https://docs.microsoft.com/en-us/dotnet/
 * Author: Tim Corey
 * Summary: Reads and prints file contents. Adds a line of string on a file.
 * Modifications: Modified project name.
 *                Added try-catch-finally block to handle FileNotFoundException.
 *                Added restart function.
 *                Printed if the file was read, not found or a new entry was added onto.
 * Student: Ted Kim
 * Capture Date: April 27, 2019
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace FileIO1MProj
{

    class Program
    {

        static void Main(string[] args)
        {
            bool restart = true;
            while (true)
            {
                while(restart)
                {
                    string filePath = "./tc_fileio.txt";

                    // FileNotFoundException is thrown if a file is not found.
                    try
                    {
                        // "File.ReadAllLines": "Opens a text file, reads all lines of the file 
                        //  into a string array, and then closes the file" (mdoc).
                        // "ToList": "Creates a List<T> from an IEnumerable<T>" (mdoc).
                        // List<T>: "a strongly typed list of objects" (mdoc).
                        List<string> lines = File.ReadAllLines(filePath).ToList();

                        Console.WriteLine("File was read succefully.\n");
                        // "line" is a local variable that represents an element of List<T>.
                        foreach (string line in lines)
                        {
                            Console.WriteLine(line);
                        }

                        // List<T>.Add: "Adds an object to the end of the List<T>." (mdoc).
                        // Adds a string object to a List<string>.
                        lines.Add("Sue,Storm,www.stormy.com");
                        //"File.WriteAllLines": "Creates a new file, writes one or more strings 
                        // to the file and then closes the file." (mdoc).
                        // Writing old file contents and a new string added onto the file.
                        File.WriteAllLines(filePath, lines);
                        Console.WriteLine("\nA new entry was added on the file.\n");

                        //"File.ReadAllText": "Opens a text file, reads all the text in the file 
                        // into a string, and then closes the file" (mdoc).
                        // Reads and prints new file contents.
                        string newFileContents = File.ReadAllText(filePath);
                        Console.WriteLine(newFileContents);
                    }
                    // FileNotFoundException handler.
                    // If the specified file is not found, prints the file name to be created.
                    catch (FileNotFoundException ex)
                    {
                        Console.WriteLine("File was not found. Please create: {0}", ex.FileName);
                    }
                    // This block is executed whether an exception was thrown or not.
                    finally
                    {
                        restart = Restart();
                    }

                }
                // If "restart" is false, terminates the program.
                break;

            }
        }

        // Ask a user to restart or not.
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
}

/* This code produces the following results:

File was read succefully.

Bahrt,Dan,github.com/dbahrt
Kim,Ted,github.com/tedkimflo

A new entry was added on the file.

Bahrt,Dan,github.com/dbahrt
Kim,Ted,github.com/tedkimflo
Sue,Storm,www.stormy.com

Restart? (y/n)
Hooah
Invalid Input.

Restart? (y/n)
y

File was read succefully.

Bahrt,Dan,github.com/dbahrt
Kim,Ted,github.com/tedkimflo
Sue,Storm,www.stormy.com

A new entry was added on the file.

Bahrt,Dan,github.com/dbahrt
Kim,Ted,github.com/tedkimflo
Sue,Storm,www.stormy.com
Sue,Storm,www.stormy.com

Restart? (y/n)
n


Press any key to continue...

 */
