using System;

namespace Reference.Lib.DataStructures.Graphs
{
    public interface IWeightedEdge<T, W> : IEdge<T>
        where T : IComparable<T>
        where W : IComparable<W>
    {
        W Weight { get; }
    }
}