/*
 * Source: https://www.sanfoundry.com/csharp-program-quick-sort/
 * Definition Source (mdoc): https://docs.microsoft.com/en-us/dotnet/
 * Author: sanfoundry
 * Summary: Quicksort, the best sorting algorithm with O(n log n).
 * Modifications: Modified project name.
 *                Modified variable names for readability.
 *                Removed unnecessary using namespaces.
 * Student: Ted Kim
 * Capture Date: May , 2019
 */

using System;

namespace QuickSortMProj
{
    class quickSort
    {

        public static void Main()
        {
            quickSort q_Sort = new quickSort();

            // An array to be sorted.
            int[] array = { 4, 3, 1, 4, 6, 7, 5, 4, 32, 5, 26, 187, 8 };
            q_Sort.array = array;
            q_Sort.len = q_Sort.array.Length;
            // Execute quick sort.
            q_Sort.QuickSort();

            for (int j = 0; j < q_Sort.len; j++)
            {
                Console.WriteLine(q_Sort.array[j]);
            }
            Console.ReadKey();
        }

        private int[] array = new int[20];
        private int len;

        public void QuickSort()
        {
            sort(0, len - 1);
        }

        // Sorts an array.
        public void sort(int leftIndex, int rightIndex)
        {
            int pivotValue, arrayStarts, arrayEnds;

            // "leftIndex" = left-most index of an array to be sorted.
            arrayStarts = leftIndex;
            // "rightIndex" = right-most index of an array to be sorted.
            arrayEnds = rightIndex;
            // "pivotValue" = left-most item of an array.
            pivotValue = array[leftIndex];

            // Sorting ends when leftIndex is not leftIndex anymore.
            while (leftIndex < rightIndex)
            {
                // "rightIndex" finds the first item less than the pivotValue.
                while ((array[rightIndex] >= pivotValue) && (leftIndex < rightIndex))
                {
                    rightIndex--;
                }

                // Moves an item that is less than the pivotValue to the left-side.
                if (leftIndex != rightIndex)
                {
                    array[leftIndex] = array[rightIndex];
                    leftIndex++;
                }

                // "leftIndex" finds the first item greater than the pivotValue.
                while ((array[leftIndex] <= pivotValue) && (leftIndex < rightIndex))
                {
                    leftIndex++;
                }

                // Moves an item that is less than the pivotValue to the right-side.
                if (leftIndex != rightIndex)
                {
                    array[rightIndex] = array[leftIndex];
                    rightIndex--;
                }
            }

            // Insert pivotValue.
            array[leftIndex] = pivotValue;

            // Sort first half of an array.
            if (arrayStarts < leftIndex)
            {
                sort(arrayStarts, leftIndex - 1);
            }

            // Sort second half of an array.
            if (arrayEnds > leftIndex)
            {
                sort(leftIndex + 1, arrayEnds);
            }
        }


    }
}

/* This code produces the following results:

1
3
4
4
4
5
5
6
7
8
26
32
187

 */
