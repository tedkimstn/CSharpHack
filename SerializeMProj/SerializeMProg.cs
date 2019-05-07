/*
 * Source: https://www.dotnetperls.com/serialize-list
 * Definition Source (mdoc): https://docs.microsoft.com/en-us/dotnet/
 * Author: dotnetpearls
 * Summary: Serialize and deserialize a list.
 * Modifications: Added a namespace.
 *                Modified restart program.
 *                Added an input handler.
 * Student: Ted Kim
 * Capture Date: May 07, 2019
 */

using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace SerializeMProj
{
    // "Indicates that a class can be serialized. This class cannot be inherited" (mdoc).
    [Serializable()]
    // An object with a constructor to be serialized.
    public class Lizard
    {
        public string Type { get; set; }
        public int Number { get; set; }
        public bool Healthy { get; set; }

        public Lizard(string t, int n, bool h)
        {
            Type = t;
            Number = n;
            Healthy = h;
        }
    }

    class Program
    {
        static void Main()
        {
            bool resume = true;
            while (resume)
            {
                // A list of valid inputs.
                // Add valid inputs inside the curly braces.
                List<string> validInputs = new List<string>() {"serialize", "read"};

                // Reads a user input.
                string input = InputHandler(validInputs);

                switch (input)
                {
                    // Creates a list of Lizard and serialize data.
                    case "serialize":
                        var lizards1 = new List<Lizard>();
                        lizards1.Add(new Lizard("Thorny devil", 1, true));
                        lizards1.Add(new Lizard("Casquehead lizard", 0, false));
                        lizards1.Add(new Lizard("Green iguana", 4, true));
                        lizards1.Add(new Lizard("Blotched blue-tongue lizard", 0, false));
                        lizards1.Add(new Lizard("Gila monster", 1, false));

                        try
                        {
                            // "using": "Provides a convenient syntax that ensures 
                            // the correct use of IDisposable objects" (mdoc).
                            // IDisposable: "Provides a mechanism for releasing unmanaged resources" (mdoc).
                            // "File.Open": "Opens a FileStream on the specified 
                            // path with read / write access" (mdoc).
                            // "FileMode.Create": "Specifies that the operating system 
                            // should create a new file" (mdoc).
                            using (Stream stream = File.Open("data.bin", FileMode.Create))
                            {
                                //"BinaryFormatter": "Serializes and deserializes an object, 
                                // or an entire graph of connected objects, in binary format" (mdoc).
                                BinaryFormatter bin = new BinaryFormatter();
                                // "Serialize": "process of converting an object into a stream of byte
                                // to store the object or transmit it to memory" (mdoc).
                                bin.Serialize(stream, lizards1);
                            }
                        }
                        catch (IOException)
                        {
                        }
                        break;

                    // Deserializes data.
                    case "read":
                        try
                        {
                            // "FileMode.Open": "Specifies that the operating system 
                            // should open an existing file" (mdoc).
                            using (Stream stream = File.Open("data.bin", FileMode.Open))
                            {
                                BinaryFormatter bin = new BinaryFormatter();

                                // "Deserialize returns an object, hence it is casted.
                                var lizards2 = (List<Lizard>)bin.Deserialize(stream);
                                foreach (Lizard lizard in lizards2)
                                {
                                    Console.WriteLine("{0}, {1}, {2}",
                                        lizard.Type,
                                        lizard.Number,
                                        lizard.Healthy);
                                }
                            }
                        }
                        catch (IOException)
                        {
                        }
                        break;
                }

                // Ask if a user wishes to restart the program.
                resume = RestartHandler();


            }
        }
        // Prints a list of optoin inputs,
        // Reads and returns an error-checked user input.
        static string InputHandler(List<string> optionInputs)
        {
            while (true)
            {
                Console.WriteLine("Please input one of the followings: ");

                foreach (var defInput in optionInputs)
                {
                    Console.WriteLine(defInput);
                }

                Console.Write("\n>");
                string input = Console.ReadLine().ToLower();

                if (optionInputs.Contains(input))
                {
                    Console.WriteLine("Valid input.");
                    return input;
                }
                else
                {
                    Console.WriteLine("Invalid input.\n");
                    continue;
                }
            }
        }

        // Returns true if user wishes to restart and vice versa.
        static bool RestartHandler()
        {
            while (true)
            {
                Console.Write("Restart? (y/n)\n>");
                // "ReadLine" reads a line of user input.
                string restart = Console.ReadLine();

                if (restart == "y") { Console.WriteLine(); return true; }
                else if (restart == "n") { Console.WriteLine(); return false; }
                else { Console.WriteLine("Invalid Input.\n"); }
            }
        }
    }
}