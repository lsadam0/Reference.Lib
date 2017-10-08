using Reference.Lib.DataStructures.Collections;
using Xunit;

namespace Reference.Lib.Tests.DataStructures.Collections
{
    public abstract class LinkedListTestBase<L, N>
        where L : LinkedListBase<int, N>
        where N : class, ILinkedListNode<int>
    {
        protected abstract L CreateList();

        [Fact]
        public void LinkedList_DoesAddFirst()
        {
            var list = CreateList();
            list.AddFirst(2);
            var expectedHead = list.AddFirst(1);

            IsInOrder(list, 2);
            Assert.Equal(1, list.Head.Value);
            Assert.Equal(2, list.Tail.Value);
            Assert.Equal(list.Head.Next, list.Tail);
        }

        [Fact]
        public void LinkedList_DoesAddLast()
        {
            var list = CreateList();
            list.AddLast(1);
            list.AddLast(2);
        
            IsInOrder(list, 2);
            Assert.Equal(1, list.Head.Value);
            Assert.Equal(2, list.Tail.Value);
            Assert.Equal(list.Head.Next, list.Tail);
        }

        [Fact]
        public void LinkedList_DoesAddBefore()
        {
            var list = CreateList();

            var target = list.AddFirst(3);
            list.AddFirst(1);

            list.AddBefore(target, 2);
            IsInOrder(list, 3);
        }

        [Fact]
        public void LinkedList_DoesAddAfter()
        {
            var list = CreateList();
            list.AddFirst(3);
            var target = list.AddFirst(1);

            list.AddAfter(target, 2);
            IsInOrder(list, 3);
        }

        [Fact]
        public void LinkedList_DoesRemove()
        {
            var list = CreateList();
            list.AddFirst(1);
            list.AddLast(3);
            list.AddLast(2);

            list.Remove(3);
            IsInOrder(list, 2);
        }

        protected void IsInOrder(L list, int expectedCount)
        {
            var n = -1;
            var count = 0;
            foreach (var value in list)
            {
                Assert.True(value > n);
                n = value;
                ++count;
            }
            Assert.Equal(expectedCount, count);
            Assert.Equal(expectedCount, list.Count);
        }
    }
}