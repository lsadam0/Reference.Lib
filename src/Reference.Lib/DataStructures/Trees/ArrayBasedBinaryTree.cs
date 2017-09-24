using System;
using System.Collections.Generic;

namespace Reference.Lib.DataStructures.Trees
{

    public abstract class ArrayBasedBinaryTree<T>
    {

        protected IList<T> _store;

        protected IComparer<T> Comparer;

        internal T GetElement(int idx) => _store[idx];

        protected ArrayBasedBinaryTree()
        {
            _store = new List<T>();
            Comparer = Comparer<T>.Default;
        }

        protected ArrayBasedBinaryTree(IList<T> data)
        {
            _store = data;
            Comparer = Comparer<T>.Default;
        }

        internal int GetLeftIndex(int root) => 2 * root + 1;
        internal int GetRightIndex(int root) => 2 * (root + 1);

        internal int GetParentIndex(int child) => IsLeftChild(child) ? child / 2 : child / 2 - 1;

        /// <summary>
        ///     Left Nodes are always within an odd index
        /// </summary>
        internal bool IsLeftChild(int index) => index != 0 && !IsRightChild(index); //index % 2 > 0;

        /// <summary>
        ///     Right nodes are always within an even index
        /// </summary>
        internal bool IsRightChild(int index) => index != 0 && index % 2 == 0;
    }

}