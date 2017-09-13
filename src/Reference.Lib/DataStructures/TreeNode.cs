using System;
using System.Collections.Generic;
using System.Linq;

namespace Reference.Lib.DataStructures
{

    internal struct TreeNode
    {
        public int? LeftIndex { get; }

        public int? RightIndex { get; }

        public int Children { get; }

        /// <summary>
        /// Has no children
        /// </summary>
        public bool IsLeaf => Children == 0;

        /// <summary>
        /// Has two children
        /// </summary>
        public bool IsFull => Children == 2 || IsLeaf;

        public bool IsDegenerate => Children == 1;
        public bool HasLeftChild => LeftIndex != null;

        public bool HasRightChild => RightIndex != null;

        public int RootIndex { get; }
        public TreeNode(int root, int? left, int? right)
        {
            RootIndex = root;
            LeftIndex = left;
            RightIndex = right;

            if (left != null && right != null)
                Children = 2;
            else if (left != null || right != null)
                Children = 1;
            else
                Children = 0;


        }
    }
}