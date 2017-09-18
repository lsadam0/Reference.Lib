using System;

namespace Reference.Lib.Algorithms.General
{
    /// <summary>
    ///     Given an array of n values, find the consecutive
    ///     sequence with the largest possible sum
    /// </summary>
    public class MaximumSubarray
    {
        /// <summary>
        ///     O(n^3)
        ///     This solution iterates through every possible sub-array,
        ///     requiring three nested loops.
        /// </summary>
        public static int BruteForceSolution(int[] input)
        {
            var largest = 0;

            for (var x = 0; x < input.Length; ++x)
            for (var y = x; y < input.Length; ++y)
            {
                var sum = 0;

                for (var z = x; z <= y; ++z)
                    sum += input[z];

                largest = Math.Max(sum, largest);
            }

            return largest;
        }


        /// <summary>
        ///     O(n^2)
        /// </summary>
        public static int ImprovedSolution(int[] input)
        {
            var largest = 0;

            for (var x = 0; x < input.Length; ++x)
            {
                var sum = 0;
                for (var y = x; y < input.Length; ++y)
                {
                    sum += input[y];
                    largest = Math.Max(sum, largest);
                }
            }

            return largest;
        }

        /// <summary>
        ///     O(n)
        /// </summary>
        public static int OptimalSolution(int[] input)
        {
            var largest = 0;
            var sum = 0;

            for (var x = 0; x < input.Length; ++x)
            {
                sum = Math.Max(input[x], sum + input[x]);
                largest = Math.Max(largest, sum);
            }

            return largest;
        }
    }
}