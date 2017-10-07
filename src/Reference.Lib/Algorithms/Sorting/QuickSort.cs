using System;
using System.Collections.Generic;
using Reference.Lib.Utils;

namespace Reference.Lib.Algorithms.Sorting
{
    public static class QuickSortExtension
    {
        /// <summary>
        ///     Average: O(n log n)
        ///     Best:  O(n log n)
        ///     Worst: O(n log n)
        ///     Space: O(1)
        ///     Stable: No
        /// </summary>
        /// <param name="data">Collection to be sorted</param>
        public static void QuickSort<T>(this IList<T> data)
            where T : IComparable<T>
        {
            Apply(data, 0, data.Count - 1);
        }

        private static void Apply<T>(IList<T> data, int low, int high)
            where T : IComparable<T>
        {
            if (low >= high) return;

            var partition = Partition(data, low, high);

            Apply(data, low, partition - 1);

            Apply(data, partition + 1, high);
        }

        public static int Partition<T>(IList<T> data, int low, int high)
            where T : IComparable<T>
        {
            /* This function takes last element as pivot, places
                the pivot element at its correct position in sorted
                    array, and places all smaller (smaller than pivot)
                to left of pivot and all greater elements to right
                of pivot */

            // get pivot value
            var pivot = data[high];

            var i = low - 1;

            for (var j = low; j <= high - 1; ++j)
            {
                // value is greater than pivot, do nothing
                if (data[j].CompareTo(pivot) > 0) continue;

                // value is <= pivot, do a swap
                ++i; // increment i
                data.Swap(i, j); // swap previous low with current
            }

            data.Swap(i + 1, high); // we now know from low to i is less than the pivot
            // select i + 1 as the new pivot, since it must be > old pivot

            // invariant: (data[low..i] <= data[i+1])
            return i + 1;
        }
    }
}