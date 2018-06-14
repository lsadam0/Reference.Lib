using Xunit;

using Reference.Lib.DataStructures.Collections;

namespace Reference.Lib.Tests.DataStructures.Collections
{
    public class StackTests
    {
        [Fact]
        public void Stack_IsInOrder()
        {
            var stack = new Stack<int>();
            stack.Push(5, 4, 3, 2, 1);

            var count = 0;
            for (var i = 1; i < 6; ++i)
            {
                var item = stack.Pop();

                Assert.Equal(i, item);
                Assert.Equal(5 - i, stack.Count);
                ++count;
            }

            Assert.Equal(5, count);
            Assert.True(stack.IsEmpty);
        }

        [Fact]
        public void Stack_DoesEnumerate()
        {
            var items = new int[6] { 5, 4, 3, 2, 1, 0 };
            var stack = new Stack<int>(items);
            Assert.True(stack.Count == items.Length);

            var count = 0;
            foreach (var item in stack)
            {
                Assert.Equal(item, count);
                ++count;
            }
            Assert.Equal(count, items.Length);
            Assert.True(stack.IsEmpty);
        }
    }
}