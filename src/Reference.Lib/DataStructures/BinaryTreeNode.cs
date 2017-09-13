namespace Reference.Lib.DataStructures
{
    public class BinaryTreeNode<T>
    {

        public BinaryTreeNode(T value)
        {
            this.Value = value;
        }

        public BinaryTreeNode<T> Left { get; internal set; }

        public BinaryTreeNode<T> Right { get; internal set; }

        public T Value { get; internal set; }


    }
}