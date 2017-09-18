using System;
using System.Collections.Generic;

namespace Reference.Lib.DataStructures
{
    public class BinaryTree<T>
    {
        private static readonly Func<BinaryTreeNode<T>, bool> IsFullDelegate = node => node.IsFull;

        private static readonly Func<BinaryTreeNode<T>, bool> IsDegenerateDelegate =
            node => node.IsDegenerate || node.IsLeaf;

        private static readonly Func<int?, BinaryTreeNode<T>, bool> IsPerfectDelegate = (leafHeight, node) =>
        {
            if (!node.IsLeaf)
                return node.Children == 2;

            if (leafHeight == null)
            {
                leafHeight = node.Height;
                return true;
            }

            return node.Height == (int) leafHeight;
        };

        public int Count { get; protected set; }
        public BinaryTreeNode<T> Root { get; private set; }

        public bool IsEmpty => Root == null;


        /// <summary>
        ///     A tree is Degenerate if every node has one child
        /// </summary>
        /// <returns>true if the entire Tree is degenerate; otherwise false</returns>
        public bool IsDegenerate => Root == null
            ? false
            : VerifyProperty(IsDegenerateDelegate, Root);

        /// <summary>
        ///     A Tree is full if every node has either 0 or 2 children
        /// </summary>
        /// <returns>true if Tree is full; otherwise false</returns>
        public bool IsFull => Root == null
            ? false
            : VerifyProperty(IsFullDelegate, Root);


        /// <summary>
        ///     A 'Complete' tree has the property that every level,
        ///     possibly excluding the last level, is completely filled.
        ///     All nodes in the last level must be as far left as possible.
        /// </summary>
        /// <returns></returns>
        public bool IsComplete
        {
            get
            {
                var last = Height - 1;
                var final = false;

                foreach (var node in BreadthFirstTraversal())
                    if (node.Height == last)
                        if (!final)
                        {
                            if (node.Children != 2)
                                final = true;
                        }
                        else
                        {
                            if (!node.IsLeaf)
                                return false;
                        }
                    else if (node.Height < last)
                        if (node.Children < 2)
                            return false;

                return true;
            }
        }


        public int Height { get; internal set; }

        /// <summary>
        ///     A 'Balanced' tree has the minimum possible height
        /// </summary>
        /// <returns></returns>
        public bool IsHeightBalanced => Height <= OptimalHeight;


        public int OptimalHeight => (int) Math.Log(Count, 2) + 1;

        /// <summary>
        ///     A 'Perfect' tree has the property that all interior nodes
        ///     have two children and all leaves have the same depth/level
        /// </summary>
        /// <returns></returns>
        public bool IsPerfect
        {
            get
            {
                int? leftHeight = null;

                Func<BinaryTreeNode<T>, bool> method = node => IsPerfectDelegate(leftHeight, node);

                return VerifyProperty(method, Root);
            }
        }


        public virtual void Add(T value)
        {
            if (Root == null)
            {
                SetRoot(value);
                return;
            }

            foreach (var node in BreadthFirstTraversal())
                if (node.Children < 2)
                {
                    if (!node.HasLeftChild)
                        SetAsLeftChild(node, value);
                    else
                        SetAsRightChild(node, value);

                    break;
                }
        }


        public void Add(params T[] values)
        {
            foreach (var value in values)
                Add(value);
        }

        public void Clear()
        {
            Count = 0;
            Root = null;
        }

        private bool VerifyProperty(Func<BinaryTreeNode<T>, bool> method, BinaryTreeNode<T> node)
        {
            if (node == null)
                return true;

            if (!method(node))
                return false;

            return VerifyProperty(method, node.Left) && VerifyProperty(method, node.Right);
        }

        protected void SetRoot(T value)
        {
            Root = new BinaryTreeNode<T>(value);
            Root.Height = 1;
            ++Count;
        }

        protected void SetAsLeftChild(BinaryTreeNode<T> parent, T child)
        {
            parent.Left = new BinaryTreeNode<T>(child, parent.Height + 1);
            ++Count;

            if (parent.Left.Height > Height)
                Height = parent.Left.Height;
        }

        protected void SetAsRightChild(BinaryTreeNode<T> parent, T child)
        {
            parent.Right = new BinaryTreeNode<T>(child, parent.Height + 1);
            ++Count;

            if (parent.Right.Height > Height)
                Height = parent.Right.Height;
        }

        /// <summary>
        ///     InOrder (Left, Root, Right)
        ///     1
        ///     /     \
        ///     2       3
        ///     /   \
        ///     4     5
        ///     Output: 4,2,5,1,3
        /// </summary>
        /// <returns></returns>
        public IEnumerable<BinaryTreeNode<T>> InOrderTraversal()
        {
            return InOrder(Root);
        }

        /// <summary>
        ///     PreOrder (Root, Left, Right)
        ///     1
        ///     /     \
        ///     2       3
        ///     /   \
        ///     4     5
        ///     Output: 1,2,4,5,3
        /// </summary>
        /// <returns></returns>
        public IEnumerable<BinaryTreeNode<T>> PreOrderTraversal()
        {
            return DepthFirstTraversal();
        }

        /// <summary>
        ///     PostOrder (Left, Right, Root)
        ///     1
        ///     /     \
        ///     2       3
        ///     /   \
        ///     4     5
        ///     Output: 4,5,2,3,1
        /// </summary>
        /// <returns></returns>
        public IEnumerable<BinaryTreeNode<T>> PostOrderTraversal()
        {
            return PostOrder(Root);
        }

        private IEnumerable<BinaryTreeNode<T>> PostOrder(BinaryTreeNode<T> root)
        {
            if (root == null)
                yield break;

            if (root.HasLeftChild)
                foreach (var left in PostOrder(root.Left))
                    yield return left;


            if (root.HasRightChild)
                foreach (var right in PostOrder(root.Right))
                    yield return right;

            yield return root;
        }


        private IEnumerable<BinaryTreeNode<T>> InOrder(BinaryTreeNode<T> root)
        {
            if (root == null)
                yield break;

            if (root.HasLeftChild)
                foreach (var left in InOrder(root.Left))
                    yield return left;

            yield return root;

            if (root.HasRightChild)
                foreach (var right in InOrder(root.Right))
                    yield return right;
        }


        public IEnumerable<BinaryTreeNode<T>> BreadthFirstTraversal()
        {
            if (Root == null)
                yield break;

            var queue = new Queue<BinaryTreeNode<T>>();
            queue.Enqueue(Root);

            while (queue.Count > 0)
            {
                var current = queue.Dequeue();

                yield return current;

                if (current.HasLeftChild)
                    queue.Enqueue(current.Left);

                if (current.HasRightChild)
                    queue.Enqueue(current.Right);
            }
        }

        public IEnumerable<BinaryTreeNode<T>> DepthFirstTraversal()
        {
            if (Root == null)
                yield break;

            var stack = new Stack<BinaryTreeNode<T>>();
            stack.Push(Root);

            while (stack.Count > 0)
            {
                var current = stack.Pop();

                yield return current;

                // LIFO
                if (current.HasRightChild)
                    stack.Push(current.Right);

                if (current.HasLeftChild)
                    stack.Push(current.Left);
            }
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