using System;
using System.Collections;
using System.Collections.Generic;

namespace Reference.Lib.DataStructures.Trees
{
    public class BinaryTree<T> : IEnumerable<T>
    {
        public TreeTraversalMethod TraversalMethod { get; set; } = TreeTraversalMethod.BreadthFirst;

        public int Count { get; protected set; }
        public BinaryTreeNode<T> Root { get; private set; }

        public bool IsEmpty => Root == null;

        /// <summary>
        ///     A tree is Degenerate if every node has one child
        /// </summary>
        /// <returns>true if the entire Tree is degenerate; otherwise false</returns>
        public bool IsDegenerate => Root != null && VerifyProperty(IsDegenerateDelegate, Root);

        /// <summary>
        ///     A Tree is full if every node has either 0 or 2 children
        /// </summary>
        /// <returns>true if Tree is full; otherwise false</returns>
        public bool IsFull => Root != null && VerifyProperty(IsFullDelegate, Root);


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


        public bool IsHeightBalanced => Height <= OptimalHeight;

        /// <summary>
        ///     * Left & RIght sub-tree heights differ by 1, at most
        ///     * Left sub-tree is balanced
        ///     * Right sub-tree is balanced
        /// </summary>
        /// <returns></returns>
        public bool IsBalanced => IsBalancedNode(Root);

        public int OptimalHeight => (int) Math.Log(Count, 2) + 1;

        /// <summary>
        ///     A 'Perfect' tree has the property that all interior nodes
        ///     have two children and all leaves have the same depth/level
        /// </summary>
        /// <returns></returns>
        public bool IsPerfect => IsFull && IsComplete;
      
        public virtual IEnumerator<T> GetEnumerator()
        {
            if (Root == null)
                yield break;

            Func<IEnumerable<BinaryTreeNode<T>>> method;
            switch (TraversalMethod)
            {
                case TreeTraversalMethod.InOrder:
                    method = InOrderTraversal;
                    break;
                case TreeTraversalMethod.PreOrder:
                    method = PreOrderTraversal;
                    break;
                case TreeTraversalMethod.PostOrder:
                    method = PostOrderTraversal;
                    break;
                case TreeTraversalMethod.BreadthFirst:
                    method = BreadthFirstTraversal;
                    break;
                default:
                    method = DepthFirstTraversal;
                    break;
            }

            foreach (var res in method())
                yield return res.Value;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        private bool IsBalancedNode(BinaryTreeNode<T> node)
        {
            if (node == null) return true;

            // this fails to get correct height
            var leftH = node.HasLeftChild ? GetTreeHeightFrom(node.Left) : 0;
            var rightH = node.HasRightChild ? GetTreeHeightFrom(node.Right) : 0;

            return Math.Abs(leftH - rightH) <= 1 && IsBalancedNode(node.Right) && IsBalancedNode(node.Left);
        }

        protected int GetTreeHeightFrom(BinaryTreeNode<T> node)
        {
            var offset = node.Height;
            var max = 0;

            foreach (var child in InOrder(node))
            {
                var adjusted = child.Height - offset;
                max = adjusted > max ? adjusted : max;
            }

            return max;
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
            Root = new BinaryTreeNode<T>(value) {Height = 1};
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
        ///     Output: 4,2,5,1,
        /// </summary>
        /// <returns></returns>
        protected IEnumerable<BinaryTreeNode<T>> InOrderTraversal()
        {
            return InOrder(Root);
        }

        /// <summary>
        ///     PreOrder (Root, Left, Right)
        ///     Output: 1,2,4,5,3
        /// </summary>
        /// <returns></returns>
        protected IEnumerable<BinaryTreeNode<T>> PreOrderTraversal()
        {
            return DepthFirstTraversal();
        }

        /// <summary>
        ///     PostOrder (Left, Right, Root)
        ///     Output: 4,5,2,3,1
        /// </summary>
        /// <returns></returns>
        protected IEnumerable<BinaryTreeNode<T>> PostOrderTraversal()
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


        protected IEnumerable<BinaryTreeNode<T>>
            BreadthFirstTraversal()
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

        protected IEnumerable<BinaryTreeNode<T>> DepthFirstTraversal()
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

        private static bool IsFullDelegate(BinaryTreeNode<T> node)
        {
            return node.IsFull;
        }

        private static bool IsDegenerateDelegate(BinaryTreeNode<T> node)
        {
            return node.IsDegenerate || node.IsLeaf;
        }


        private static bool IsPerfectDelegate(int? leafHeight, BinaryTreeNode<T> node)
        {
            if (!node.IsLeaf)
                return node.Children == 2;

            if (leafHeight == null)
                return true;

            return node.Height == (int) leafHeight;
        }
    }
}