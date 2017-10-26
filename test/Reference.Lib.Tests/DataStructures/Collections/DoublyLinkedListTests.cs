using System.Collections.Generic;
using Xunit;
using Reference.Lib.DataStructures.Collections;

namespace Reference.Lib.Tests.DataStructures.Collections
{
    public class DoublyLinkedListTests : LinkedListTestBase<DoublyLinkedList<int>, DoublyLinkedListNode<int>>
    {
        protected override DoublyLinkedList<int> CreateList()
        {
            return new DoublyLinkedList<int>();
        }


        protected override void IsInOrder(DoublyLinkedList<int> list, int expectedCount, HashSet<int> contains)
        {
            base.IsInOrder(list, expectedCount, contains);

            IDoublyLinkedListNode<int> current = list.Tail;
            var value = int.MaxValue;
            var count = 0;
            while (current != null)
            {
                Assert.True(current.Value < value);
                value = current.Value;
                current = current.Last;
                ++count;
            }

            Assert.Equal(expectedCount, count);
        }
    }
}