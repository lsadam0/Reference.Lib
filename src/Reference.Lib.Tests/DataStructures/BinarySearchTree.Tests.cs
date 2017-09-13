using System;
using Xunit;
using Reference.Lib.DataStructures;

namespace Reference.Lib.Tests.DataStructures 
{
      public class BinarySearchTreeTests
    {

        private BinarySearchTree<int> BuildDefaultTree()
        {
            var tree = new BinarySearchTree<int>();

            //       10
            //    9       12
            // 8    10   11  13
            //
            // 1   
            // 3   
            // 7     
            // 15
            // 31
            //

            var set = new int[7] { 10, 9, 12, 8, 10, 11, 13 };
            tree.Add(set);
            return tree;
        }

        [Fact]
        public void Count_DoesTrackAdditions()
        {
            var tree = BuildDefaultTree();


            Assert.Equal<int>(7, tree.Count);
            tree.Add(9);
            Assert.Equal<int>(8, tree.Count);
        }

        [Fact]
        public void Empty_DoesIdentifyEmptyTree()
        {
            var tree = BuildDefaultTree();
            Assert.False(tree.IsEmpty);

            tree.Clear();
            Assert.True(tree.IsEmpty);

            tree = new BinarySearchTree<int>();
            Assert.True(tree.IsEmpty);
        }




        [Fact]
        public void IsPerfect_DoesIdentifyPerfect()
        {
            var tree = BuildDefaultTree();

            Assert.True(tree.IsPerfect);
        }

        [Fact]
        public void IsBalanced_DoesIdentifyBalanced()
        {
            var tree = new BinarySearchTree<int>();
            Assert.True(tree.IsHeightBalanced);

            tree = BuildDefaultTree();
            Assert.True(tree.IsHeightBalanced);

            tree.Add(7);
            Assert.True(tree.IsHeightBalanced);

            tree.Add(6);
            Assert.False(tree.IsHeightBalanced);

        }

        [Fact]
        public void PreviousHeight_DoesComputePreviousHeight()
        {
            var tree = new BinarySearchTree<int>();

            Assert.Equal<int>(0, tree.Height);

            tree.Add(10);
            Assert.Equal<int>(1, tree.Height);

            tree.Add(5);
            Assert.Equal<int>(2, tree.Height);

            tree.Add(6);
            Assert.Equal<int>(3, tree.Height);

            tree.Add(7);
            Assert.Equal<int>(4, tree.Height);
        }



        [Fact]
        public void IsDegenerate_DoesIdentifyDegenerateTree()
        {
            var tree = new BinarySearchTree<int>();

            for (int i = 10; i >= 0; --i)
                tree.Add(i);

            Assert.True(tree.IsDegenerate);

            // Cause Node with value 5 to have a Right child
            tree.Add(6);
            Assert.False(tree.IsDegenerate);
        }

        [Fact]
        public void IsFull_DoesIdentifyFullTree()
        {
            //         100
            //     50       110
            //  40     90
            //      80    95
            //

            var tree = new BinarySearchTree<int>();
            tree.Add(100, 110, 50, 40, 90, 80, 95);

            { }
            Assert.True(tree.IsFull, "Initial");
            tree = BuildDefaultTree();
            Assert.True(tree.IsFull, "Default Tree");

            tree.Add(15);
            Assert.False(tree.IsFull, "Value 15");

            tree.Add(13);
            Assert.True(tree.IsFull, "Value 13");
        }

        [Fact]
        public void IsComplete_DoesIdentifyComplete()
        {
            var tree = BuildDefaultTree();
            Assert.True(tree.IsComplete);

            tree.Add(2);
            Assert.True(tree.IsComplete, "2");

            tree.Add(9);
            Assert.True(tree.IsComplete, "9");

            tree.Add(11);
            Assert.False(tree.IsComplete, "11");
        }
    }
}