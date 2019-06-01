/*
 * Source: https://moodle.stmartin.edu/mod/resource/view.php?id=480366
 * Definition Source (mdoc): https://docs.microsoft.com/en-us/dotnet/
 * Author: Dr. Razvan A. Mezei
 * Summary: Bubble-, Selection-, Merge- and Quick-sort algorithms.
 * Modifications: Modified original sorting algorithms to perform reverse sorting.
 *                Added to read file contents.
 *                Added to measure and display running time of each algorithms.
 * Student: Ted Kim
 * Capture Date: May 25, 2019
 */

using System;
using System.IO;

namespace Sort
{
    class Program
    {
        // Running Time: O(n^2).
        static void Main(string[] args)
        {
            try
            {
                // Reads and stores all lines of the file into a string array.
                string[] input = File.ReadAllLines("input.txt");

                // Makes 4 copies of the input array.
                string[] input1, input2, input3, input4;
                input1 = (string[])input.Clone();
                input2 = (string[])input.Clone();
                input3 = (string[])input.Clone();
                input4 = (string[])input.Clone();

                // Calls each sorting methods and prints execution time.

                var watch1 = System.Diagnostics.Stopwatch.StartNew();
                bubbleReverseSort(input1);
                watch1.Stop();
                var elapsedMs1 = watch1.ElapsedMilliseconds;
                Console.WriteLine("bubbleReverseSort execution time: " + elapsedMs1 + "ms");


                var watch2 = System.Diagnostics.Stopwatch.StartNew();
                selectionReverseSort(input2);
                watch2.Stop();
                var elapsedMs2 = watch2.ElapsedMilliseconds;
                Console.WriteLine("selectionReverseSort execution time: " + elapsedMs2 + "ms");

                var watch3 = System.Diagnostics.Stopwatch.StartNew();
                mergeReverseSort(input3);
                watch3.Stop();
                var elapsedMs3 = watch3.ElapsedMilliseconds;
                Console.WriteLine("mergeReverseSort execution time: " + elapsedMs3 + "ms");

                var watch4 = System.Diagnostics.Stopwatch.StartNew();
                quickReverseSort(input4);
                watch4.Stop();
                var elapsedMs4 = watch4.ElapsedMilliseconds;
                Console.WriteLine("quickReverseSort execution time: " + elapsedMs4 + "ms");
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine("The following file does not exist:\n{0}", ex.FileName);
            }
        }

        // Bubble-sorts an array of strings in descending order.
        // Running Time: O(n^2).
        static void bubbleReverseSort(string[] arr)
        {
            // Temporary variable needed for swap.
            string tmp;
            // Number of comparisons performed counter.
            long count=0;


            // Each iteration does not include the last element
            // of the previous iteration.
            for (int j = arr.Length - 1; j > 0; j--)
            {
                for (int i = 0; i < j; i++)
                {
                    // Compares adjacent pairs and swaps them 
                    // if the first value precedes the second value.
                    if (String.Compare(arr[i], arr[i+1]) < 0)
                    {
                        tmp = arr[i];
                        arr[i] = arr[i + 1];
                        arr[i + 1] = tmp;
                    }
                    count++;
                }
            }

            Console.WriteLine("bubbleReverseSort number of comparisons: " + count);
        }

        // Selection-sorts an array of strings in descending order.
        // Running Time: O(n^2).
        static void selectionReverseSort(string[] arr)
        {
            // Number of comparisons performed counter.
            long count = 0;

            // Finds the biggest value in an array,
            // swaps it with the first element of an array,
            // increment the first position of an array,
            // and repeats the same process until only 1 element is left in an array.
            for (int i = 0; i < arr.Length - 1; i++)
            {
                int maxPos = i;

                // Finds the biggest value in an array.
                for (int j = i + 1; j < arr.Length; j++)
                {
                    if (String.Compare(arr[maxPos],arr[j]) < 0)
                    {
                        maxPos = j;
                    }
                    count++;
                }

                // Swaps the biggest value with the first element of an array.
                string tmp = arr[i];
                arr[i] = arr[maxPos];
                arr[maxPos] = tmp;
            }

            Console.WriteLine("selectionReverseSort number of comparisons: " + count);
        }

        // Merge-sorts an array of strings in descending order.
        // Running Time: O(nlogn).
        static void mergeReverseSort(string[] arr)
        {
            // Temporary buffer.
            string[] tmp = new string[arr.Length];

            MergeSortHelper(arr, 0, arr.Length - 1, tmp, out long count);

            Console.WriteLine("mergeReverseSort number of comparisons: " + count);
        }

        // Divides an array into halves and merge them.
        // Running Time: O(nlogn).
        public static void MergeSortHelper(string[] arr, int first, int last, string[] tmp, out long count)
        {
            count = 0;
            // If an array has at least 2 elements.
            if (first < last)
            {
                int mid = (first + last) / 2;
                MergeSortHelper(arr, first, mid, tmp, out long count2);
                MergeSortHelper(arr, mid + 1, last, tmp, out long count3);
                Merge(arr, first, mid + 1, last, tmp, out long localCount);

                // Number of comparisons performed =
                // previous number of comparisons + new number of comparisons.
                count = localCount + count2 + count3;
            }
        }

        // Merge 2 arrays into an array with strings in descending order.
        // Running Time: O(n).
        public static void Merge(string[] arr, int first, int mid, int last, string[] tmp, out long localCount)
        {
            // First array index.
            int i = first;
            // Second array index.
            int j = mid;
            // Temporary array index.
            int k = first;

            // Number of comparisons performed counter.
            localCount = 0;

            while (i < mid && j <= last)
            {
                // If an element of the first array 
                // follows an element of the second array in the sort order.
                if(String.Compare(arr[i],arr[j]) > 0)
                {
                    tmp[k] = arr[i];
                    k++;
                    i++;
                }
                else
                {
                    tmp[k] = arr[j];
                    j++;
                    k++;
                }

                localCount++;
            }

            // Places the remanining elements in the first array
            // in the temporary array.
            while (i < mid) 
            {
                tmp[k] = arr[i];
                k++;
                i++;
            }

            // Places the remanining elements in the second array
            // in the temporary array.
            while (j <= last)
            {
                tmp[k] = arr[j];
                j++;
                k++;
            }

            // Copies elements from the temporary array
            // to the original array.
            for (int p = first; p <= last; p++)
                arr[p] = tmp[p];
        }

        // Quick-sorts an array of strings in descending order.
        // Running Time: O(n^2).
        static void quickReverseSort(string[] arr)
        {
            // Quick-sort the whole array.
            QuickSortHelper(arr, 0, arr.Length - 1, out long count);
            Console.WriteLine("quickReverseSort number of comparisons: " + count);
        }

        // Finds a new pivot position and recursively calls itself
        // for an array on the left and an array on the right.
        // Running Time: O(n^2).
        public static void QuickSortHelper(string[] arr, int first, int last, out long count)
        {
            count = 0;
            // If there are at least 2 elements in an array.
            if (first < last)
            {
                // Finds and places a pivot in the right position. 
                int p = Partition(arr, first, last, out long localCount);
                // Repeats the same process for the arrays on the left and the right.
                QuickSortHelper(arr, first, p - 1, out long count2);
                QuickSortHelper(arr, p + 1, last, out long count3);

                // Number of comparisons performed =
                // previous number of comparisons + new number of comparisons.
                count = localCount + count2 + count3;
            }
        }

        // Returns a new pivot (last element of an array) position
        // and places all elements greater than the pivot before the pivot in an array.
        // Running Time: O(n)
        public static int Partition(string[] arr, int first, int last, out long localCount)
        {
            // Chooses the last element of an array as the pivot.
            string pivot = arr[last];

            // Tracks the last element that is greater than the pivot.
            int greaterIndex = first - 1;

            // Number of comparisons performed counter.
            localCount = 0;

            for (int j = first; j < last; j++)
            {
                // If an element is greater than or equal to the pivot,
                // Moves it on the left side of the future pivot position.
                if(String.Compare(arr[j], pivot) >= 0)
                {
                    greaterIndex++;
                    string tmp = arr[j];
                    arr[j] = arr[greaterIndex];
                    arr[greaterIndex] = tmp;
                }
                localCount++;
            }

            // Swaps the pivot with the first element
            // less than or equal to the pivot in an array.
            arr[last] = arr[greaterIndex + 1];
            arr[greaterIndex + 1] = pivot;

            // Returns the new position of the pivot.
            return greaterIndex + 1;
        }
    }
}
