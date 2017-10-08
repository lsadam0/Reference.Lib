namespace Reference.Lib.DataStructures.Collections
{
    public interface IDoublyLinkedListNode<out T> : ILinkedListNode<T>
    {
        IDoublyLinkedListNode<T> Last { get; }
    }
}