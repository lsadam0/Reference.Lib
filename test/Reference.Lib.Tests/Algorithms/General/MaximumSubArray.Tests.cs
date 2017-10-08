using Reference.Lib.Algorithms.General;
using Xunit;
using System;


namespace Reference.Lib.Tests.Algorithms.General
{
    public class MaximumSubArrayTests
    {
        private void Execute(Func<int[], int> method)
        {
            var data = new int[8]
            {
                -1, 2, 4, -3, 5, 2, -5, 2
            };

            var res = method(data);

            Assert.Equal(10, res);
        }

        [Fact]
        public void BruteForce_Succeeds()
        {
            Execute(MaximumSubarray.BruteForceSolution);
        }

        [Fact]
        public void Improved_Succeeds()
        {
            Execute(MaximumSubarray.ImprovedSolution);
        }

        [Fact]
        public void Optimal_Succeeds()
        {
            Execute(MaximumSubarray.OptimalSolution);
        }
    }
}