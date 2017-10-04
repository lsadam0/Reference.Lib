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
        public void QuickSort_DoesSort() => Execute((e) => e.QuickSort());
        
        [Fact]
        public void TopDownMergeSort_DoesSort() => Execute((e) => e.TopDownMergeSort());
        
        [Fact]
        public void HeapSort_DoesSort() => Execute((e) => e.HeapSort());

        
    }
}