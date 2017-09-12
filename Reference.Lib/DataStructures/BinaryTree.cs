using System;
using System.Collections.Generic;
using System.Linq;

namespace Reference.Lib.DataStructures
{


    public class BinaryTree<T>
    {
        public int Count { get; protected set; }
        public BinaryTreeNode<T> Root { get; protected set; }

        public bool IsEmpty => Root == null;


        public bool IsDegenerate => throw new Exception();

        /// <summary>
        ///   A Tree is full if every node has either 0 or 2 children
        /// </summary>
        /// <returns>true if Tree is full; otherwise false</returns>
        public bool IsFull => Root != null
        ? IsFullAt(Root)
        : false;

        public bool IsComplete => throw new Exception();

        public int Height => throw new Exception();

        public bool IsHeightBalanced => throw new Exception();

        public bool IsPerfect => throw new Exception();


        private bool IsFullAt(BinaryTreeNode<T> node)
        {

            var count = GetChildCount(node);

            if (count == 1)
                return false;

            if (count == 0)
                return true;

            return IsFullAt(node.Left) && IsFullAt(node.Right);
        }

        protected int GetChildCount(BinaryTreeNode<T> node)
        {
            if (node.Left == null && node.Right == null)
                return 0;

            if (node.Left != null && node.Right != null)
                return 2;

            return 1;
        }
    }
    /* 
    public class BinaryTree<T>
        where T : IComparable<T>
    {
        private const byte InitialTreeSize = 31;
        private const byte GrowthFactor = 2;
        private const byte MinSize = 1;
        protected int? _maxIndex = null;
        private int _count = 0;

        /// <summary>
        ///     Determines if a valid element exists
        ///     in the corresponding index in Tree.
        ///     Since T has no class restriction, we cannot depend on 'null'
        ///     to signify the absence of an element.  An array of type T[]
        ///     is initialized with default(T) for all slots, but default(T)
        ///     can be a valid value within our dataset. For example, default(int) == 0.
        /// </summary>
        protected readonly HashSet<int> Indices = new HashSet<int>();

        protected T[] Tree;

        protected BinaryTree() => Initialize();

        public int Height
        {
            get
            {
                var max = MaxNodeIndex;
                if (max == null) return 0;
                if (max == 0) return 1;
                return GetHeightForIndex((int)max);
            }
        }

        public void Add(params T[] data)
        {
            foreach (var e in data)
                Add(e);
        }

        public abstract void Add(T e);

        public int Count => (int)_count;

        /// <summary>
        /// Determine Tree Depth that can be handled
        /// without invoking a <see cref="Grow"/> operation
        /// </summary>
        /// <returns>Alloted Tree Height</returns>
        internal int AllottedHeight => (int)Math.Log(Tree.Length, GrowthFactor) + 1;

        internal int NextSize => (int)Tree.Length * GrowthFactor + 1;

        internal int GetStartingIndexForHeight(int height) => (int)Math.Pow(GrowthFactor, height - 1) - 1;

        internal int GetHeightForIndex(int index) => (int)Math.Log(index + 1, GrowthFactor) + 1;

        internal int PreviousSize => (int)Math.Max(MinSize, Math.Pow(GrowthFactor, AllottedHeight - 1) - 1);

        public void Clear() => Initialize();

        public void Initialize()
        {
            Tree = new T[InitialTreeSize];
            Indices.Clear();
            _maxIndex = null;
            _count = 0;
        }

        protected void SetNode(T value, int index)
        {
            if (_maxIndex == null || index > _maxIndex)
                _maxIndex = index;
                
            if (!(index < Tree.Length))
                Grow();

            ++_count;

            if (!Indices.Contains(index))
                Indices.Add(index);

            Tree[index] = value;
        }

        protected void Grow()
        {
            var temp = new T[NextSize];
            Array.Copy(Tree, temp, Tree.Length);
            Tree = temp;
        }

        protected T GetNode(int index) => index < Tree.Length ? Tree[index] : default(T);

        protected int GetLeftIndex(int root) => 2 * root + 1;

        protected int GetRightIndex(int root) => 2 * (root + 1);

        /// <summary>
        ///     Left Nodes are always within an odd index
        /// </summary>
        protected bool IsLeftChild(int index) => index != 0 && !IsRightChild(index); //index % 2 > 0;

        /// <summary>
        ///     Right nodes are always within an even index
        /// </summary>
        protected bool IsRightChild(int index) => index != 0 && index % 2 == 0;

        protected int GetParentIndex(int child) => IsLeftChild(child) ? child / 2 : child / 2 - 1;

        /// <summary>
        ///     Find the max node index
        /// </summary>
        /// <returns>null if no indicies, otherwise the maximum index</returns>
        protected int? MaxNodeIndex => _maxIndex;

        internal TreeNode GetTreeNode(int i)
        {
            var l = GetLeftIndex(i);
            var r = GetRightIndex(i);

            return new TreeNode(
                i,
                ExistsAt(l) ? (int?)l : null,
                ExistsAt(r) ? (int?)r : null
            );
        }

        /// <summary>
        ///     Determine if an element exists in the specified index
        ///     Since T has no class restriction, we cannot depend on 'null'
        ///     to signify the absence of an element.  An array of type T[]
        ///     is initialized with default(T) for all slots, but default(T)
        ///     can be a valid value within our dataset. For example, default(int) == 0.
        /// </summary>
        /// <param name="idx">tree array index</param>
        /// <returns>true if a valid element of type T exists at that index</returns>
        protected virtual bool ExistsAt(int index) => _maxIndex != null && index <= _maxIndex && index < Tree.Length && Indices.Contains(index);

        /// <summary>
        ///   A Tree is full if every node has either 0 or 2 children
        /// </summary>
        /// <returns>true if Tree is full; otherwise false</returns>
        public bool IsFull => IsFullAt(0);

        private bool IsFullAt(int i)
        {
            if (!ExistsAt(i)) return true;

            var node = GetTreeNode(i);

            if (!node.IsFull)
                return false;
            if (node.IsLeaf)
                return true;
            else
                return IsFullAt((int)node.LeftIndex)
                    && IsFullAt((int)node.RightIndex);
        }

        public bool IsEmpty => _maxIndex == null || _maxIndex < 0;

        /// <summary>
        ///     A 'Perfect' tree has the property that all interior nodes
        ///     have two children and all leaves have the same depth/level
        /// </summary>
        /// <returns></returns>
        public bool IsPerfect => IsPerfectAt(0, Height);

        private bool IsPerfectAt(int i, int lastLevel)
        {
            if (!ExistsAt(i)) return true;

            var node = GetTreeNode(i);

            if (node.IsLeaf)
                return GetHeightForIndex(i) == lastLevel;
            else
                return node.IsFull;
        }

        private int ExpectItemsInLevel(int level) => (int)Math.Pow(2, (int)level - 1);

        /// <summary>
        ///     A 'Complete' tree has the property that every level,
        ///     possibly excluding the last level, is completely filled.
        ///     All nodes in the last level must be as far left as possible.
        /// 
        /// </summary>
        /// <returns></returns>
        public bool IsComplete => IsCompleteAt(0, Height) && IsPackedLeft(Height);

        private bool IsPackedLeft(int level)
        {
            var start = GetStartingIndexForHeight(level);
            var width = this.ExpectItemsInLevel(level);

            bool missed = false;
            for (int i = start; i < (start + width); ++i)
            {
                if (!ExistsAt(i))
                {
                    missed = true;
                    continue;
                }

                if (missed)
                    return false;
            }

            return true;
        }
        private bool IsCompleteAt(int index, int lastLevel)
        {

            if (GetHeightForIndex(index) == lastLevel - 1)
                return true;

            if (!ExistsAt(index))
                return true;

            var node = GetTreeNode(index);

            var res = node.Children == 2
                && IsCompleteAt((int)node.LeftIndex, lastLevel)
                && IsCompleteAt((int)node.RightIndex, lastLevel);

            return res;
        }
        public int GetHeightForNode(int i)
        {
            var children = GetTreeNode(i);
            return 1 +
             Math.Max(
                 children.HasLeftChild ? GetHeightForNode((int)children.LeftIndex) : 0,
                 children.HasRightChild ? GetHeightForNode((int)children.RightIndex) : 0);
        }

        /// <summary>
        ///     A 'Balanced' tree has the minimum possible height
        /// </summary>
        /// <returns></returns>
        public bool IsHeightBalanced => IsTreeHeightBalanced(GetTreeNode(0));

        private bool IsTreeHeightBalanced(TreeNode root)
        {

            if (!ExistsAt(root.RootIndex)) return true;

            var left = root.HasLeftChild
                ? GetHeightForNode((int)root.LeftIndex)
                : 0;

            var right = root.HasRightChild
                ? GetHeightForNode((int)root.RightIndex)
                : 0;

            return
                Math.Abs(left - right) <= 1
                && (!root.HasLeftChild || IsTreeHeightBalanced(GetTreeNode((int)root.LeftIndex)))
                && (!root.HasRightChild || IsTreeHeightBalanced(GetTreeNode((int)root.RightIndex)));

        }
        /// <summary>
        ///     A tree is Degenerate if each node has exactly one child
        /// </summary>
        /// <returns>true if tree is Degenerate; otherwise false</returns>
        public bool IsDegenerate => IsDegenerateAt(0);

        private bool IsDegenerateAt(int i)
        {
            if (!ExistsAt(i)) return true;

            var node = GetTreeNode(i);

            if (node.Children > 0 && !node.IsDegenerate)
                return false;

            if (node.IsLeaf)
                return true;
            if (node.HasLeftChild)
                return IsDegenerateAt((int)node.LeftIndex);
            else
                return IsDegenerateAt((int)node.RightIndex);
        }

        public T[] Peek() => Tree;
    }*/
}