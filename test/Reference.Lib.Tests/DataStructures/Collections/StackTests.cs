using Reference.Lib.DataStructures.Collections;
using Xunit;


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
            for (int i = 1; i < 6; ++i)
            {
                var item = stack.Pop();

                Assert.Equal(i, item);
                Assert.Equal(5 - i, stack.Count);
                ++count;
            }

            Assert.Equal(5, count);
            Assert.True(stack.IsEmpty);

        }

    }
}