using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using Xunit;
using Reference.Lib.DataStructures.Trees;
using Reference.Lib.Test.Utils;
using Reference.Lib.DataStructures.Heaps;

namespace Reference.Lib.Tests.DataStructures.Heaps
{
    public class BinaryHeapTests
    {
        [Fact]
        public void MaxBinaryHeap_HasHeapMethod()
        {
            var test = new MaxBinaryHeap<int>();

            Assert.True(test.Compare(10, 9));
        }


        [Fact]
        public void MinBinaryHeap_HasHeapMethod()
        {
            var test = new MinBinaryHeap<int>();

            Assert.True(test.Compare(9, 10));
        }

        [Fact]
        public void MaxBinaryHeap_IsValidHeap()
        {
            var heap = new MaxBinaryHeap<int>();

            heap.Add(1,2,3,4,5,6,7,8,9,10);


            Assert.Equal(10, heap.HeapSize);
            Assert.True(heap.IsValidHeap);
        }


        [Fact]
        public void MinBinaryHeap_IsValidHeap()
        {
            var heap = new MaxBinaryHeap<int>();

            heap.Add(10,9,8,7,6,5,4,3,2,1);

            Assert.Equal(10, heap.HeapSize);
            Assert.True(heap.IsValidHeap);
        }

        [Fact]
        public void BinaryHeap_DoesHeapify()
        {
            var heap = new MaxBinaryHeap<int>(1,2,3,4,5,6,7,8,9,10);

            Assert.Equal(10, heap.HeapSize);
            Assert.True(heap.IsValidHeap);
        }
    }
}