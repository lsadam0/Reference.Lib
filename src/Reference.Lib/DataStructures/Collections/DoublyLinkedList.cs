namespace Reference.Lib.DataStructures.Collections
{
    public class DoublyLinkedList<T> : LinkedListBase<T, DoublyLinkedListNode<T>>
    {
        protected override DoublyLinkedListNode<T> GetPredecessorOf(DoublyLinkedListNode<T> node)
        {
            return node.Last as DoublyLinkedListNode<T>;
        }

        protected override void AddNodeAfter(
            DoublyLinkedListNode<T> node,
            DoublyLinkedListNode<T> value)
        {
            value.Next = node.Next;
            value.Last = node;
            node.Next = value;

            if (value.Next != null)
                ((DoublyLinkedListNode<T>) value.Next).Last = value;
        }

        protected override void AddNodeBefore(DoublyLinkedListNode<T> node, DoublyLinkedListNode<T> value,
            DoublyLinkedListNode<T> predecessor)
        {
            value.Next = node;
            value.Last = node.Last;
            node.Last = value;

            if (predecessor != null)
                predecessor.Next = value;
            // ancestor
        }

        protected override DoublyLinkedListNode<T> CreateNodeFor(T value)
        {
            var res = new DoublyLinkedListNode<T>(value, null);
            return res;
        }

        protected override void RemoveNode(DoublyLinkedListNode<T> predecessor, DoublyLinkedListNode<T> toRemove)
        {
            var successor = toRemove.Next;

            if (predecessor != null)
                predecessor.Next = successor;

            if (successor != null)
                ((DoublyLinkedListNode<T>) successor).Last = predecessor;

            toRemove.Next = null;
            toRemove.Last = null;
        }
    }
}