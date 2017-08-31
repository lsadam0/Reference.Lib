using System;

namespace Reference.Lib.Algorithms.General
{
    public class MaximumSubarray
    {
        /// <summary>
        ///     O(n^3)
        ///     This solution iterates through every possible sub-array,
        ///     requiring three nested loops.
        /// </summary>
        public static int BruteForceSolution(int[] input)
        {
            int largest = 0;

            for (int x = 0; x < input.Length; ++x)
            for (int y = x; y < input.Length; ++y)
            {
                int sum = 0;

                for (int z = x; z <= y; ++z)
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
            int largest = 0;

            for (int x = 0; x < input.Length; ++x)
            {
                int sum = 0;
                for (int y = x; y < input.Length; ++y)
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
            int largest = 0;
            int sum = 0;

            for (int x = 0; x < input.Length; ++x)
            {
                sum = Math.Max(input[x], sum + input[x]);
                largest = Math.Max(largest, sum);
            }

            return largest;
        }
    }
}