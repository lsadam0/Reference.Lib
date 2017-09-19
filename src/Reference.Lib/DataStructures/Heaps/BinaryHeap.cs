using System;
using System.Linq;
using System.Collections.Generic;
using Reference.Lib.DataStructures.Trees;

namespace Reference.Lib.DataStructures.Heaps
{
    public abstract class BinaryHeap<T> : ArrayBasedBinaryTree<T>
    {
        public bool IsValidHeap => HasHeapProperty(0);

        public int HeapSize { get; private set; } = 0;

        protected BinaryHeap() : base()
        {

        }

        protected BinaryHeap(params T[] data) : base()
        {
            _store = new List<T>(data);
            HeapSize = _store.Count;
            Heapify(HeapSize - 1);
        }

        internal abstract bool Compare(T a, T b);

        private bool HasHeapProperty(int root)
        {
            if (!ElementExists(root))
                return true;

            var leftIdx = GetLeftIndex(root);
            var rightIdx = GetRightIndex(root);

            T value = GetElement(root);

            if (HasLeftChild(root))
                if (!Compare(value, GetElement(leftIdx)))
                    return false;


            if (HasRightChild(root))
                if (!Compare(value, GetElement(rightIdx)))
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
            // _store[HeapSize] = value;
            _store.Add(value);
            ++HeapSize;
            BubbleUp(HeapSize - 1);

        }

        public void Heapfiy() => Heapify(0);

        public void Heapify(int index)
        {
            if (!ElementExists(index))
                return;

            var rootIndex = index;
            T rootValue = GetElement(index);

            if (HasLeftChild(index))
            {
                var left = GetElement(GetLeftIndex(index));

                if (Compare(left, rootValue))
                {
                    rootIndex = GetLeftIndex(index);
                    rootValue = left;
                }
            }

            if (HasRightChild(index))
            {
                var right = GetElement(GetRightIndex(index));

                if (Compare(right, rootValue))
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


            if (!Compare(GetElement(parent), GetElement(idx)))
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