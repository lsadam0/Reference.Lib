using System;
using System.Linq;
using System.Collections.Generic;
using Reference.Lib.DataStructures.Trees;

namespace Reference.Lib.DataStructures.Heaps
{
    public abstract class BinaryHeap<T> : ArrayBasedBinaryTree<T>
    {
        public bool IsValidHeap => HasHeapProperty(0);

        public int HeapSize { get; internal set; } = 0;

        /// <summary>
        /// Initialize empty heap
        /// </summary>
        /// <returns></returns>
        protected BinaryHeap() : base()
        {

        }

        /// <summary>
        /// Initialize heap using data, and invoke BuildHeap
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        protected BinaryHeap(params T[] data) : base(data)
        {
            HeapSize = _store.Count;
            BuildHeap();
        }

        protected BinaryHeap(IList<T> data) : base(data)
        {
            HeapSize = _store.Count;
            BuildHeap();
        }


        /// <summary>
        /// O(n log n)
        /// </summary>
        private void BuildHeap()
        {
            for (int i = IndexOfFirstNonLeafNode; i >= 0; --i)
                Heapify(i);
        }

        /// <summary>
        /// Because a heap is a complete binary tree,
        /// the index of the first non-leaf node is 
        /// given by the below formula
        /// </summary>
        /// <returns></returns>
        private int IndexOfFirstNonLeafNode => (int)(HeapSize / 2) - 1;

        /// <summary>
        /// Heap property comparison method.  Should be
        /// overridden according to the type of heap desired
        /// </summary>
        /// <param name="root"></param>
        /// <param name="child"></param>
        /// <returns>true if the Heap property is maintained for root -> child</returns>
        internal abstract bool HeapProperty(T root, T child);

        /// <summary>
        /// Recursively determine if a sub-tree maintains
        /// the heap property
        /// </summary>
        /// <param name="root"></param>
        /// <returns>true if the sub-tree maintains the heap property</returns>    
        private bool HasHeapProperty(int root)
        {
            if (!ElementExists(root))
                return true;

            var leftIdx = GetLeftIndex(root);
            var rightIdx = GetRightIndex(root);

            T value = GetElement(root);

            if (HasLeftChild(root))
                if (!HeapProperty(value, GetElement(leftIdx)))
                    return false;


            if (HasRightChild(root))
                if (!HeapProperty(value, GetElement(rightIdx)))
                    return false;


            return HasHeapProperty(leftIdx) && HasHeapProperty(rightIdx);
        }



        private bool HasLeftChild(int root) => ElementExists(GetLeftIndex(root));
        private bool HasRightChild(int root) => ElementExists(GetRightIndex(root));

        private bool ElementExists(int idx)
        {
            if (idx >= HeapSize || idx < 0)
                return false;

            return true;
        }

        public void Add(params T[] values)
        {
            foreach (var value in values)
                Add(value);
        }

        public void Add(T value)
        {
            // add to end of the store
            _store.Add(value);
            // heap has increased in size
            ++HeapSize;
            // ensure our added value occupies it's
            // correct position in the heap
            BubbleUp(HeapSize - 1);

        }

        /// <summary>
        /// O(log n)
        /// </summary>
        public void Heapify() => Heapify(0);


        /// <summary>
        /// O(log n)
        /// </summary>
        /// <param name="index"></param>
        public void Heapify(int index)
        {
            if (!ElementExists(index))
                return;

            var rootIndex = index;
            T rootValue = GetElement(index);

            if (HasLeftChild(index))
            {
                var left = GetElement(GetLeftIndex(index));

                if (HeapProperty(left, rootValue))
                {
                    rootIndex = GetLeftIndex(index);
                    rootValue = left;
                }
            }

            if (HasRightChild(index))
            {
                var right = GetElement(GetRightIndex(index));

                if (HeapProperty(right, rootValue))
                {
                    rootIndex = GetRightIndex(index);
                    rootValue = right;
                }
            }

            if (rootIndex != index)
            {
                Swap(index, rootIndex);
                Heapify(rootIndex);
            }
        }

        private void BubbleUp(int idx)
        {
            if (!ElementExists(idx))
                return;

            var parent = GetParentIndex(idx);

            if (!ElementExists(parent))
                return;


            if (!HeapProperty(GetElement(parent), GetElement(idx)))
            {
                // heap property not maintained
                Swap(parent, idx);
                BubbleUp(parent);
            }
        }

        public void Swap(int x, int y)
        {
            var buffer = GetElement(x);

            _store[x] = _store[y];
            _store[y] = buffer;
        }

        public T[] ToArray() => _store.ToArray();

    }
}