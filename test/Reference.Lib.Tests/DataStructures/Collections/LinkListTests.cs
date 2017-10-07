using System;
using Reference.Lib.DataStructures.Collections;
using Xunit;

namespace Reference.Lib.Tests.DataStructures.Collections
{
    public class LinkedListTests
    {
        [Fact]
        public void LinkedList_DoesAddFirst()
        {
            var list = new LinkedList<int>();
            list.AddFirst(2);
            list.AddFirst(1);

            IsInOrder(list);
        }

        [Fact]
        public void LinkedList_DoesAddLast()
        {
            var list = new LinkedList<int>();
            list.AddLast(1);
            list.AddLast(2);

            IsInOrder(list);
        }

        [Fact]
        public void LinkedList_DoesAddBefore()
        {
            var list = new LinkedList<int>();
            
            var target = list.AddFirst(3);
            list.AddFirst(1);

            list.AddBefore(target, 2);
            IsInOrder(list);
        }

        [Fact]
        public void LinkedList_DoesAddAfter()
        {
            var list = new LinkedList<int>();
            list.AddFirst(3);
            var target = list.AddFirst(1);

            list.AddAfter(target, 2);
            IsInOrder(list);
        }

        [Fact]
        public void LinkedList_DoesRemove()
        {
            var list = new LinkedList<int>();
            list.AddFirst(1);
            list.AddLast(3);
            list.AddLast(2);

            list.Remove(3);
            IsInOrder(list);
        }

        private void IsInOrder(LinkedList<int> list)
        {
            var n = -1;

            foreach (var value in list)
            {
                Assert.True(value > n);
                n = value;
            }
        }

    }
    
}