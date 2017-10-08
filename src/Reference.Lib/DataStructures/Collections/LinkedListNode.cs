namespace Reference.Lib.DataStructures.Collections
{
    public class LinkedListNode<T> : ILinkedListNode<T>
    {
        public LinkedListNode(T value, ILinkedListNode<T> next)
        {
            Value = value;
            Next = next;
        }

        public T Value { get; }

        public virtual ILinkedListNode<T> Next { get; internal set; }
    }
}