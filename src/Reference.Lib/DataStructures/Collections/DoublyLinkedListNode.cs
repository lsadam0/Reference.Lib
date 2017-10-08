namespace Reference.Lib.DataStructures.Collections
{
    public class DoublyLinkedListNode<T> : LinkedListNode<T>, IDoublyLinkedListNode<T>
    {
        public DoublyLinkedListNode(T value, DoublyLinkedListNode<T> next) : base(value, next)
        {
        }

        public IDoublyLinkedListNode<T> Last { get; internal set; }
    }
}