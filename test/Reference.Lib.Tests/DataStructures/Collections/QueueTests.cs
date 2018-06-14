using Xunit;
using System;
using Reference.Lib.DataStructures.Collections;

namespace Reference.Lib.Tests.DataStructures.Collections
{
    public class QueueTests
    {
        [Fact]
        public void Queue_IsInOrder()
        {
            var queue = new Queue<int>();
            queue.Push(1, 2, 3, 4, 5);

            var count = 0;
            for (var i = 1; i < 6; ++i)
            {
                var item = queue.Pop();

                Assert.Equal(i, item);
                Assert.Equal(5 - i, queue.Count);
                ++count;
            }

            Assert.Equal(5, count);
            Assert.True(queue.IsEmpty);
        }

        [Fact]
        public void Queue_DoesEnumerate()
        {
            var items = new int[6] { 0, 1, 2, 3, 4, 5 };
            var queue = new Queue<int>(items);
            Assert.True(queue.Count == items.Length);

            var count = 0;
            foreach (var item in queue)
            {
                Assert.Equal(item, count);
                ++count;
            }
            Assert.Equal(count, items.Length);
            Assert.True(queue.IsEmpty);
        }
    }
}