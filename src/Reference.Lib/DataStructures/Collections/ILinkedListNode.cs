namespace Reference.Lib.DataStructures.Collections
{
    public interface ILinkedListNode<out TV>
    {
        TV Value { get; }

        ILinkedListNode<TV> Next { get; }
    }
}