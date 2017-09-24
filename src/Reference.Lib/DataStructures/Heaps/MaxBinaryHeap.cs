using System;
using System.Collections.Generic;
using Reference.Lib.DataStructures.Trees;

namespace Reference.Lib.DataStructures.Heaps
{
    public class MaxBinaryHeap<T> : BinaryHeap<T>
    {

        public MaxBinaryHeap() : base()
        {}

        public MaxBinaryHeap(params T[] data): base(data)
        {}

        public MaxBinaryHeap(IList<T> data) : base(data)
        {
            
        }

        internal override bool HeapProperty(T a, T b)
        {
            return base.Comparer.Compare(a, b) >= 0;
        }
    }
}