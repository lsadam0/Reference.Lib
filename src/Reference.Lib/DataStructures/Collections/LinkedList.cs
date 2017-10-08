namespace Reference.Lib.DataStructures.Collections
{
    public class LinkedList<T> : LinkedListBase<T, LinkedListNode<T>>
    {
        protected override void AddNodeAfter(LinkedListNode<T> node, LinkedListNode<T> value)
        {
            value.Next = node.Next;
            node.Next = value;
        }

        protected override void AddNodeBefore(LinkedListNode<T> node, LinkedListNode<T> value,
            LinkedListNode<T> predecessor)
        {
            if (predecessor != null)
                predecessor.Next = value;

            value.Next = node;
            // ancestor
        }

        protected override LinkedListNode<T> CreateNodeFor(T value)
        {
            var res = new LinkedListNode<T>(value, null);
            return res;
        }

        protected override LinkedListNode<T> GetPredecessorOf(LinkedListNode<T> node)
        {
            var current = Head;

            while (current != null && current.Next != node)
                current = current.Next as LinkedListNode<T>;

            return current;
        }

        protected override void RemoveNode(LinkedListNode<T> predecessor, LinkedListNode<T> toRemove)
        {
            if (predecessor != null)
                predecessor.Next = toRemove.Next;

            toRemove.Next = null;
        }
    }
}