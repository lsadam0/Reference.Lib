using Reference.Lib.DataStructures.Collections;
using Xunit;
using System;


namespace Reference.Lib.Tests.DataStructures.Collections
{
    public class DoublyLinkedListTests : LinkedListTestBase<DoublyLinkedList<int>, DoublyLinkedListNode<int>>
    {
        protected override DoublyLinkedList<int> CreateList()
        {
            return new DoublyLinkedList<int>();
        }


       
        protected override void IsInOrder(DoublyLinkedList<int> list, int expectedCount, System.Collections.Generic.HashSet<int> contains)
        {
            base.IsInOrder(list, expectedCount, contains);

            IDoublyLinkedListNode<int> current = list.Tail;
            var value = Int32.MaxValue;
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