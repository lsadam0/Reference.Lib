using System;

namespace Reference.Lib.DataStructures.Graphs
{
    public interface IEdge<TV>
        where TV : IComparable<TV>
    {
        bool IsWeighted { get; }

        TV Origin { get; }

        TV Destination { get; }
    }
}