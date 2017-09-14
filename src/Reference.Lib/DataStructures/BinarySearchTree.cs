using System;
using System.Collections.Generic;
using System.Collections;

namespace Reference.Lib.DataStructures
{
    /// <summary>
    ///     A Binary Tree is not the same as a BST
    /// </summary>
    public class BinarySearchTree<T> : BinaryTree<T>
    {
        private IComparer<T> comparer;

        public BinarySearchTree() : base()
        {
            this.comparer = Comparer<T>.Default;
        }

        public BinarySearchTree(T[] data) : this()
        {
            this.Add(data);
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
                base.SetAsLeftChild(previous, value);
            else
                base.SetAsRightChild(previous, value);
        }



    }
}