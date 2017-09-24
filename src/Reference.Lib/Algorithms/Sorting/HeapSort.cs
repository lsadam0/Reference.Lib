using System;
using System.Collections.Generic;
using Reference.Lib.DataStructures.Heaps;

namespace Reference.Lib.Algorithms.Sorting
{

    public static class HeapSortExtension
    {
        /// <summary>
        /// Average: O(n log n) 
        /// Best:  O(n log n) 
        /// Worst: O(n log n) 
        /// Space: O(1)
        /// Stable: No
        /// </summary>
        /// <param name="data">Collection to be sorted</param>
        public static void HeapSort<T>(this IList<T> data)
        {
            // build the heap
            var heap = new MaxBinaryHeap<T>(data);

            // start from the bottom
            // O(n)
            for (int i = heap.HeapSize -1; i >= 0; --i)
            {
                // the largest element occupies position 0
                // so move it to the end
                heap.Swap(0, i);
                
                // reduce the heapsize so that the largest
                // value we just moved is no longer
                // considered by Heapify
                --heap.HeapSize;

                // Re-heapify the remaining values, placing the
                // next largest value at the root of the heap
                heap.Heapify();
            }
        }
    }

}