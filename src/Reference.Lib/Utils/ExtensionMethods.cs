using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Reference.Lib.Utils
{
    public static class ExtensionMethods
    {
        public static T[] Grow<T>(this T[] source, int nextSize)
        {
            var temp = new T[nextSize];
            Array.Copy(source, temp, source.Length);
            return temp;
        }

        public static string Print<T>(this T[] source)
        {
            var bu = new StringBuilder();

            // bu.AppendLine(string.Join(string.Empty, source.Select(x => "_")));
            bu.Append("|");
            bu.Append(string.Join("|", source));
            //  bu.AppendLine(string.Join(string.Empty, source.Select(x => "_")));
            return bu.ToString();
        }

        public static void Swap<T>(this IList<T> source, int a, int b)
        {
            if (a == b) return;
            if (a >= source.Count || b >= source.Count)
                throw new ArgumentException("One or both args exceed array length");

            var temp = source[a];
            source[a] = source[b];
            source[b] = temp;
        }

        public static bool IsSorted<T>(this T[] data)
            where T : IComparable<T>
        {
            // O(n)
            for (var i = 1; i < data.Length; ++i)
                if (data[i - 1].CompareTo(data[i]) > 0)
                    return false;
            return true;
        }

        /// <summary>
        ///     Both collections contain the same elements
        /// </summary>
        /// <param name="sorted"></param>
        /// <param name="unsorted"></param>
        /// <returns></returns>
        public static bool IsValid<T>(this T[] sorted, T[] unsorted)
        {
            // have same length
            if (unsorted.Length != sorted.Length) return false;

            var a = new HashSet<T>(unsorted.Distinct());
            var b = new HashSet<T>(sorted.Distinct());

            // have same distinct count
            if (a.Count != b.Count) return false;

            a.IntersectWith(b);

            // intersection of distinct has the same size as distinct
            return a.Count == b.Count;
        }
    }
}