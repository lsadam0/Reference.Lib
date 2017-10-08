using Reference.Lib.DataStructures.Trees;
using Xunit;

namespace Reference.Lib.Test.DataStructures.Trees
{
    public class ArrayBasedBinaryTreeTests
    {
        [Fact]
        public void GetLeftIndex_IsCorrect()
        {
            var left = new TestTree().GetLeftIndex(1);

            Assert.Equal(3, left);
        }

        [Fact]
        public void GetRightIndex_IsCorrect()
        {
            var right = new TestTree().GetRightIndex(1);

            Assert.Equal(4, right);
        }

        [Fact]
        public void GetParentIndex_IsCorrect()
        {
            var tree = new TestTree();
            var parent = tree.GetParentIndex(4);
            Assert.Equal(1, parent);
            parent = tree.GetParentIndex(3);
            Assert.Equal(1, parent);
        }

        [Fact]
        public void IsLeftChild_IsCorrect()
        {
            var isLeft = new TestTree().IsLeftChild(3);
            Assert.True(isLeft);
        }

        [Fact]
        public void IsRightChild_IsCorrect()
        {
            var isRight = new TestTree().IsRightChild(4);
            Assert.True(isRight);
        }

        private class TestTree : ArrayBasedBinaryTree<int>
        {
        }
    }
}