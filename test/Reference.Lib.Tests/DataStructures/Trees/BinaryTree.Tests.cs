using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using Xunit;
using Reference.Lib.DataStructures.Trees;
using Reference.Lib.Test.Utils;

namespace Reference.Lib.Tests.DataStructures.Trees
{
    public class BinaryTreeTests
    {

        private BinaryTree<int> BuildTraversalTree()
        {
            var data = new int[5] { 1, 2, 3, 4, 5 };
            var tree = new BinaryTree<int>();

            tree.Add(data);

            return tree;
        }

        [Fact]
        public void BinaryTree_Traverse_InOrder()
        {
            TraversalTest(
                (tree) => tree.TraversalMethod = TreeTraversalMethod.InOrder,
                new int[5] { 4, 2, 5, 1, 3 }
            );
        }

        [Fact]
        public void BinaryTree_Traverse_PreOrder()
        {
            TraversalTest(
                (tree) => tree.TraversalMethod = TreeTraversalMethod.PreOrder,
                new int[5] { 1, 2, 4, 5, 3 }
            );
        }


        [Fact]
        public void BinaryTree_Traverse_PostOrder()
        {
            TraversalTest(
                (tree) => tree.TraversalMethod = TreeTraversalMethod.PostOrder,
                new int[5] { 4, 5, 2, 3, 1 }
            );
        }


        [Fact]
        public void BinaryTree_Traverse_DepthFirst()
        {
            TraversalTest(
                (tree) => tree.TraversalMethod = TreeTraversalMethod.DepthFirst,
                new int[5] { 1, 2, 4, 5, 3 }
            );
        }

        [Fact]
        public void BinaryTree_Traverse_BreadthFirst()
        {
            TraversalTest(
                (tree) => tree.TraversalMethod = TreeTraversalMethod.BreadthFirst,
                new int[5] { 1, 2, 3, 4, 5 }
            );
        }

        [Fact]
        public void BinaryTree_OptimalHeight_DoesCalculate()
        {
            var tree = BuildTraversalTree();

            Assert.Equal(3, tree.Height);
            Assert.Equal(3, tree.OptimalHeight);
        }

        private void TraversalTest(Action<BinaryTree<int>> setup, int[] expected)
        {
            var tree = BuildTraversalTree();

            setup(tree);
            var traversed = new int[tree.Count];
            
            int x = 0;
            foreach (var item in tree)
            {
                traversed[x] = (item);
                ++x;
            }
            // var traversed = tree// method(tree).Select(x => x.Value).ToArray();

            Assert.NotNull(traversed);
            Assert.True(traversed.ValueEquality(expected), $"Expected: {expected.Format()} Actual: {traversed.Format()}");
        }
    }
}