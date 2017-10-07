using System.Collections.Generic;

namespace Reference.Lib.DataStructures.Heaps
{
    public class MinBinaryHeap<T> : BinaryHeap<T>
    {
        public MinBinaryHeap()
        {
        }

        public MinBinaryHeap(params T[] data) : base(data)
        {
        }

        public MinBinaryHeap(IList<T> data) : base(data)
        {
        }

        internal override bool HeapProperty(T a, T b)
        {
            return Comparer.Compare(a, b) <= 0;
        }
    }
}