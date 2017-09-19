using System;
using Reference.Lib.Algorithms.Sorting;
using Reference.Lib.Utils;
using Xunit;

namespace Reference.Lib.Test.Algorithms.Sorting
{
    public class SortingTests
    {
        private void Execute(Action<SortEntity[]> method)
        {
            var testData = TestUtils.GetEntityTestData();
            var reference = new SortEntity[testData.Length];
            Array.Copy(testData, reference, testData.Length);
            method(testData);

            Assert.True(testData.IsSorted());
            Assert.True(testData.IsValid(reference));
            Assert.False(reference.IsSorted());
        }

        [Fact]
        public void QuickSort_DoesSort()
        {
            Execute(QuickSort<SortEntity>.Sort);
        }

        [Fact]
        public void TopDownMergeSort_DoesSort()
        {
            Execute(TopDownMergeSort<SortEntity>.Sort);
        }

        [Fact]
        public void HeapSort_DoesSort()
        {
            var testData = TestUtils.GetEntityTestData();
            var reference = new SortEntity[testData.Length];
            Array.Copy(testData, reference, testData.Length);
           
            var res = HeapSort<SortEntity>.Sort(testData);

            Assert.True(res.IsSorted());
            Assert.True(res.IsValid(reference));
            Assert.False(reference.IsSorted());
        }
    }
}