using System;
using Reference.Lib.DataStructures.Heaps;

namespace Reference.Lib.Algorithms.Sorting
{

    public static class HeapSort<T>
    {
        public static T[] Sort(T[] data)
        {
            // invokes heapify
            var heap = new MaxBinaryHeap<T>(data);

            for (int i = heap.HeapSize; i > 0; --i)
            {
                heap.Swap(0, i);
                heap.Heapfiy();
            }

            return heap.ToArray();
        }
    }

}