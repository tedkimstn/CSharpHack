/*
 * Source: https://www.geeksforgeeks.org/c-sharp-params/
 * Definition Source (mdoc): https://docs.microsoft.com/en-us/dotnet/
 * Author: niku123
 * Summary: Usage of a params parameter that takes a dynamic length of input.
 * Modifications: Modified a namespace.
 * Student: Ted Kim
 * Capture Date: May 09, 2019
 */

using System; 

namespace Params { 
    
class Geeks { 
    
    // Params parameter takes various lengths of arguments.
    // Adds up numbers received as an int[].
    public static int Add(params int[] ListNumbers) 
    { 
        int total = 0; 
        
        // Adds up each elements in a list.
        foreach(int i in ListNumbers) 
        { 
            total += i; 
        } 
        return total; 
    } 
        
static void Main(string[] args) 
{ 
    // A method call that adds up arguments.
    int y = Add(12,13,10,15,56); 
    
    // Prints result.
    Console.WriteLine(y); 
} 
} 
}

/* This code produces the following results:

106

Press any key to continue...

 */


