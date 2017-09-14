using System;
using System.Text;
using Xunit;

namespace Reference.Lib.Test.Utils 
{

    public static class ExtensionMethods
    {

        public static bool ValueEquality<T>(this T[] source, T[] other)
            where T : IEquatable<T>
        {
            if (source.Length != other.Length)
                return false;

            for (int x = 0; x < source.Length; ++x)
            {
                if (!source[x].Equals(other[x]))
                    return false;
            }

            return true;
        }

        public static string Format<T>(this T[] source)
        {
            if (source.Length == 0)
                return "[]";

            if (source.Length == 1)
                return $"[source[0]]";

            var build = new StringBuilder();
            build.Append("[");
            for (int i = 0; i < source.Length - 1; ++i)
                build.Append($"{source[i]}|");

            build.Append(source[source.Length - 1]);
            build.Append("]");

            return build.ToString();

        }

    }
}