using System.Collections.Generic;

namespace Reference.Lib.DataStructures.Trees
{
    public abstract class ArrayBasedBinaryTree<T>
    {
        protected IList<T> Store;

        protected IComparer<T> Comparer;

        protected ArrayBasedBinaryTree()
        {
            Store = new List<T>();
            Comparer = Comparer<T>.Default;
        }

        protected ArrayBasedBinaryTree(IList<T> data)
        {
            Store = data;
            Comparer = Comparer<T>.Default;
        }

        internal T GetElement(int idx)
        {
            return Store[idx];
        }

        internal int GetLeftIndex(int root)
        {
            return 2 * root + 1;
        }

        internal int GetRightIndex(int root)
        {
            return 2 * (root + 1);
        }

        internal int GetParentIndex(int child)
        {
            return IsLeftChild(child) ? child / 2 : child / 2 - 1;
        }

        /// <summary>
        ///     Left Nodes are always within an odd index
        /// </summary>
        internal bool IsLeftChild(int index)
        {
            return index != 0 && !IsRightChild(index);
        }

        /// <summary>
        ///     Right nodes are always within an even index
        /// </summary>
        internal bool IsRightChild(int index)
        {
            return index != 0 && index % 2 == 0;
        }
    }
}