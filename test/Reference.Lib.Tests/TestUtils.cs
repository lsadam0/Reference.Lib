using Reference.Lib.Utils;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;
using System.Diagnostics.Tracing;

namespace Reference.Lib.Test
{
    public static class TestUtils
    {
        public static int[] GetTestData()
        {
            return new int[] {4, 1, 3, 2, 16, 9, 10, 14, 8, 7};
        }

        public static SortEntity[] GetEntityTestData()
        {
            return GetTestData().Select(x => new SortEntity(x)).ToArray();
        }

        public static bool IsSorted<T>(T[] data)
            where T : IComparable<T>
        {
            for (int i = 1; i < data.Length; ++i)
                if (data[i - 1].CompareTo(data[i]) > 0)
                    return false;
            return true;
        }

        public static bool IsValid<T>(T[] unsorted, T[] sorted)
        {
            if (unsorted.Length != sorted.Length) return false;

            var a = new HashSet<T>(unsorted.Distinct());
            var b = new HashSet<T>(sorted.Distinct());

            if (a.Count() != b.Count()) return false;

            a.IntersectWith(b);

            return a.Count() == b.Count();
        }

        public static void Print<T>(T[] data)
            where T : IComparable<T>
        {
            Trace.WriteLine(string.Join(",", data));
        }
    }
}