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
        }


        public void Add(params T[] values)
        {
            foreach (var value in values)
                Add(value);
        }
        public void Add(T value)
        {
            if (Root == null)
            {
                this.Root = new BinaryTreeNode<T>(value);
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
                previous.Left = new BinaryTreeNode<T>(value);
            else
                previous.Right = new BinaryTreeNode<T>(value);

            ++Count;

        }

        public void Clear()
        {
            Root = null;
            Count = 0;
        }

    }
}