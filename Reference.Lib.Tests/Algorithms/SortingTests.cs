using System;
using Reference.Lib.Algorithms.Sorting;
using Reference.Lib.Utils;
using Xunit;

namespace Reference.Lib.Test.Algorithms.Sorting
{
    public class SortingTests
    {
        [Fact]
        public void TopDownMergeSort_DoesSort()
        {
            Execute(TopDownMergeSort<SortEntity>.Sort);
        }

        [Fact]
        public void QuickSort_DoesSort()
        {
            Execute(QuickSort<SortEntity>.Sort);
        }

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
    }
}