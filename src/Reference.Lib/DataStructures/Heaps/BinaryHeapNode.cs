using Reference.Lib.DataStructures.Trees;

namespace Reference.Lib.DataStructures.Heaps
{
    public class BinaryHeapNode<T> : BinaryTreeNode<T>
    {
        public BinaryHeapNode(T value, int height) : base(value, height)
        {
            Height = height;
        }

        public BinaryHeapNode<T> Parent { get; internal set; }
    }
}