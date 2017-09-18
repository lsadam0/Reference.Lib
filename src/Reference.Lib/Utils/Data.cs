using System;

namespace Reference.Lib.Utils
{
    public static class Data
    {
        public static int[] Range(int from, int to)
        {
            if (from >= to) throw new ArgumentException();
            // 1,2,3
            // 
            var size = Math.Abs(to - (from - 1));
            // int size = 
            var res = new int[size];

            for (var b = 0; b < res.Length; ++b)
            {
                res[b] = from;
                ++from;
            }


            return res;
        }

        public static int[] Simple(int size)
        {
            var result = new int[size];

            for (var i = 1; i < size; ++i)
                result[i - 1] = i;

            return result;
        }

        public static int[] Generate(int size, int min = -1000, int max = 1000)
        {
            var result = new int[size];

            var rand = new Random();

            for (var i = 0; i < size; ++i)
                result[i] = rand.Next(min, max);

            return result;
        }

        public static SortEntity[] GenerateEntities(int size, int min = -1000, int max = 1000)
        {
            var result = new SortEntity[size];

            var rand = new Random();

            var i = 0;

            while (i < size)
            {
                var next = new SortEntity(rand.Next(min, max));

                result[i] = next;
                ++i;

                if (i >= size || i % 4 != 0) continue;
                result[i] = next;
                ++i;
            }

            return result;
        }

        public static void Print<T>(T[] data)
            where T : IComparable<T>
        {
            Console.WriteLine(string.Join("|", data));
        }
    }
}