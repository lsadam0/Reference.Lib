using System;
using Reference.Lib.Utils;

namespace Reference.Lib.Algorithms.Sorting
{
    public static class QuickSort<T>
        where T : IComparable<T>
    {
        public static void Sort(T[] data)
        {
            Apply(data, 0, data.Length - 1);
        }

        private static void Apply(T[] data, int low, int high)
        {
            if (low >= high) return;

            var partition = Partition(data, low, high);

            Apply(data, low, partition - 1);

            Apply(data, partition + 1, high);
        }

        public static int Partition(T[] data, int low, int high)
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