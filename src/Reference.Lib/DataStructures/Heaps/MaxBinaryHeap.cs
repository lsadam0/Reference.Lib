using System.Collections.Generic;

namespace Reference.Lib.DataStructures.Heaps
{
    public class MaxBinaryHeap<T> : BinaryHeap<T>
    {
        public MaxBinaryHeap()
        {
        }

        public MaxBinaryHeap(params T[] data) : base(data)
        {
        }

        public MaxBinaryHeap(IList<T> data) : base(data)
        {
        }

        internal override bool HeapProperty(T a, T b)
        {
            return Comparer.Compare(a, b) >= 0;
        }
    }
}