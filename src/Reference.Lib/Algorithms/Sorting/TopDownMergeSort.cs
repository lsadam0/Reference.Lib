using System;
using System.Collections.Generic;

namespace Reference.Lib.Algorithms.Sorting
{
    public static class TopDownMergeSortExtension
    {
        /// <summary>
        ///     Runtime: O(n log n) Memory: Ω(n)
        /// </summary>
        /// <param name="data"></param>
        public static void TopDownMergeSort<T>(this IList<T> data)
        where T : IComparable<T>

        {
            IList<T> buffer = new List<T>(data);              
            // Array.Copy(data, buffer, data.Length);
            SplitAndMerge(buffer, data, 0, buffer.Count);
        }


        /// <summary>
        ///     Recursively bisect source and merge sections in sorted order
        /// </summary>
        /// <param name="source">Array to read data from</param>
        /// <param name="target">Array to be merged into</param>
        /// <param name="left">Index of the start of the left sub-collection</param>
        /// <param name="right">Index of the end of the right sub-collection</param>
        private static void SplitAndMerge<T>(IList<T> source, IList<T> target, int left, int right)
                where T : IComparable<T>
        {
            if (right - left < 2) return; // set size < 2, nothing to do

            var mid = (right + left) / 2; // find midpoint

            SplitAndMerge(target, source, left, mid); // Left section.  Swap buffer & data 
            SplitAndMerge(target, source, mid, right); // Right section. Swap buffer and data         

            Merge(source, target, left, mid, right); // Merge into target
        }

        /// <summary>
        ///     In-order merge left & right sections of source into target
        /// </summary>
        /// <param name="source">Merged from</param>
        /// <param name="target">Merged into</param>
        /// <param name="left">Start of left sub-collection</param>
        /// <param name="mid">Midpoint of collection division</param>
        /// <param name="right">End of the right sub-collection</param>
        private static void Merge<T>(IList<T> source, IList<T> target, int left, int mid, int right)
                where T : IComparable<T>
        {
            var l = left;
            var r = mid;

            // n
            for (var i = left; i < right; ++i)
                if (
                    l < mid // l has not exceeded middle
                    &&
                    (r >= right // r has exceeded right bounds
                     || source[l].CompareTo(source[r]) <= 0)) // source[l] <= source[r]
                {
                    target[i] = source[l];
                    ++l;
                }
                else
                {
                    target[i] = source[r];
                    ++r;
                }
        }
    }
}