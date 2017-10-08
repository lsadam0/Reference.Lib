using Reference.Lib.DataStructures.Collections;
using Xunit;


namespace Reference.Lib.Tests.DataStructures.Collections
{
    public class DoublyLinkedListTests : LinkedListTestBase<DoublyLinkedList<int>, DoublyLinkedListNode<int>>
    {
        protected override DoublyLinkedList<int> CreateList()
        {
            return new DoublyLinkedList<int>();
        }
    }
}