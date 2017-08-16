using System;
using ReferenceLib.Algorithms.Sorting;
using ReferenceLib.Utils;
using Xunit;

namespace ReferenceLib.Test.Algorithms.Sorting
{
    public class SortingTests
    {
        [Fact]
        public void TopDownMergeSort_Sorts()
        {
            Execute(TopDownMergeSort<SortEntity>.Sort);
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