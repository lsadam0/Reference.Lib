namespace Reference.Lib.DataStructures
{
    public class BinaryTreeNode<T>
    {

        public BinaryTreeNode(T value, int height) : this(value)
        {
            this.Height = height;
        }

        public BinaryTreeNode(T value)
        {
            this.Value = value;
        }

        public BinaryTreeNode<T> Left { get; internal set; }

        public BinaryTreeNode<T> Right { get; internal set; }

        public T Value { get; internal set; }

        /// <summary>
        /// Get child count
        /// </summary>
        /// <returns></returns>
        public int Children
        {
            get
            {
                if (Left == null && Right == null)
                    return 0;

                if (Left != null && Right != null)
                    return 2;

                return 1;
            }
        }
        /// <summary>
        /// Has no children
        /// </summary>
        public bool IsLeaf => Children == 0;

        /// <summary>
        /// Has zero or two children
        /// </summary>
        public bool IsFull => Children == 2 || IsLeaf;

        public bool IsDegenerate => Children == 1;
        public bool HasLeftChild => Left != null;

        public bool HasRightChild => Right != null;

        internal int Height;


    }
}