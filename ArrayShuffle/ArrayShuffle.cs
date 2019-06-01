/*
 * Source: https://www.geeksforgeeks.org/shuffle-a-given-array-using-fisher-yates-shuffle-algorithm/
 * Definition Source (mdoc): https://docs.microsoft.com/en-us/dotnet/
 * Author: Sam007
 * Summary: Randomizes an array.
 * Modifications: Added a namespace.            
 * Student: Ted Kim
 * Capture Date: May 09, 2019
 */

using System;

namespace ArrayShuffle
{
    class GFG
    {
        // Swap elements in an array using a pseudo-random geneartor.
        static void randomize(int[] arr, int n)
        {
            // Pseudo-random geneartor.
            Random r = new Random();

            // For each elements in an array from the end to the beginning
            for (int i = n - 1; i > 0; i--)
            {
                // Rnadom number from 0 to array length-1.
                int j = r.Next(0, i + 1);

                // Saves an array element.
                int temp = arr[i];
                // Swaps an array element with a random array element.
                arr[i] = arr[j];
                arr[j] = temp;
            }

            // Prints a randommized array.
            for (int i = 0; i < n; i++)
                Console.Write(arr[i] + " ");
        }


        static void Main()
        {
            // A sorted array.
            int[] arr = {1, 2, 3, 4,
                5, 6, 7, 8};
            int n = arr.Length;
            // Shuffles and prints an array.
            randomize(arr, n);
        }
    }
}

/* This code produces the following results:

6 4 3 7 8 5 2 1 
Press any key to continue...

 */

