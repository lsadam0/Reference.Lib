using System;

namespace Reference.Lib.Algorithms.Sorting
{
    public static class TopDownMergeSort<T>
        where T : IComparable<T>
    {
        /// <summary>
        ///     Runtime: O(n log n) Memory: Ω(n)
        /// </summary>
        /// <param name="data"></param>
        public static void Sort(T[] data)
        {
            var buffer = new T[data.Length];

            Array.Copy(data, buffer, data.Length);
            SplitAndMerge(buffer, data, 0, buffer.Length);
        }


        /// <summary>
        ///     Recursively bisect source and merge sections in sorted order
        /// </summary>
        /// <param name="source">Array to read data from</param>
        /// <param name="target">Array to be merged into</param>
        /// <param name="left">Index of the start of the left sub-collection</param>
        /// <param name="right">Index of the end of the right sub-collection</param>
        private static void SplitAndMerge(T[] source, T[] target, int left, int right)
        {
            if (right - left < 2) return; // set size < 2, nothing to do

            int mid = (right + left) / 2; // find midpoint

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
        private static void Merge(T[] source, T[] target, int left, int mid, int right)
        {
            int l = left;
            int r = mid;

            // n
            for (int i = left; i < right; ++i)
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