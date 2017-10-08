using Reference.Lib.DataStructures.Collections;
using Xunit;
using System.Collections.Generic;

namespace Reference.Lib.Tests.DataStructures.Collections
{
    public abstract class LinkedListTestBase<L, N>
        where L : LinkedListBase<int, N>
        where N : class, ILinkedListNode<int>
    {
        protected abstract L CreateList();

        [Fact]
        public void LinkedList_DoesRemoveHead()
        {
            var list = CreateList();
            list.AddFirst(1);
            list.AddLast(2);
            list.AddLast(3);

            IsInOrder(list, 3, CompleteSet);

            list.Remove(1);

            IsInOrder(list, 2, new HashSet<int>() { 2, 3});
        }

        [Fact]
        public void LinkedList_DoesRemoveTail()
        {
            var list = CreateList();
            list.AddFirst(1);
            list.AddLast(2);
            list.AddLast(3);

            IsInOrder(list, 3, CompleteSet);

            list.Remove(3);

            IsInOrder(list, 2, new HashSet<int>() { 1, 2 });
        }

        [Fact]
        public void LinkedList_DoesAddFirst()
        {
            var list = CreateList();
            list.AddFirst(2);
            var expectedHead = list.AddFirst(1);

            IsInOrder(list, 2, new HashSet<int>() { 1, 2 });
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
        
            IsInOrder(list, 2, new HashSet<int>() { 1, 2});
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
            IsInOrder(list, 3, CompleteSet);
        }

        [Fact]
        public void LinkedList_DoesAddAfter()
        {
            var list = CreateList();
            list.AddFirst(3);
            var target = list.AddFirst(1);

            list.AddAfter(target, 2);
            IsInOrder(list, 3, CompleteSet);
        }

        [Fact]
        public void LinkedList_DoesRemove()
        {
            var list = CreateList();
            list.AddFirst(1);
            list.AddLast(3);
            list.AddLast(2);

            list.Remove(3);
            IsInOrder(list, 2, new HashSet<int>() { 1, 2});
        }

        protected HashSet<int> CompleteSet = new HashSet<int>() { 1,2,3};
        protected virtual void IsInOrder(L list, int expectedCount, HashSet<int> contains)
        {
            var n = -1;
            var count = 0;
            foreach (var value in list)
            {
                Assert.True(value > n);
                Assert.True(contains.Contains(value));
                n = value;
                ++count;
            }
            Assert.Equal(expectedCount, count);
            Assert.Equal(expectedCount, list.Count);
        }
    }
}