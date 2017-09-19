using System;
using Reference.Lib.DataStructures.Trees;

namespace Reference.Lib.DataStructures.Heaps
{
    public class BinaryHeapNode<T> : BinaryTreeNode<T>
    {
        public BinaryHeapNode<T> Parent
        {
            get;
            internal set;
        }

        public BinaryHeapNode(T value, int height, BinaryHeapNode<T> parent) : base(value, height)
        {
            Height = height;
        }

    }
}