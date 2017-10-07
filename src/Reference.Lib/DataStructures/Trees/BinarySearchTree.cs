using System.Collections.Generic;

namespace Reference.Lib.DataStructures.Trees
{
    public class BinarySearchTree<T> : BinaryTree<T>, IEnumerable<T>
    {
        protected readonly IComparer<T> comparer;

        public BinarySearchTree()
        {
            comparer = Comparer<T>.Default;
        }

        public BinarySearchTree(T[] data)
            : this()
        {
            Add(data);
        }


        public override void Add(T value)
        {
            if (Root == null)
            {
                SetRoot(value);
                return;
            }

            var current = Root;
            var previous = Root;
            var lastWasLeftPath = false;

            while (current != null)
            {
                var res = comparer.Compare(value, current.Value);

                previous = current;

                lastWasLeftPath = res <= 0;

                current = lastWasLeftPath
                    ? current.Left
                    : current.Right;
            }

            if (lastWasLeftPath)
                SetAsLeftChild(previous, value);
            else
                SetAsRightChild(previous, value);
        }
    }
}