using System;

namespace Reference.Lib.DataStructures.Graphs
{

    public interface IEdge<T>
    where T : IComparable<T>
    {
        bool IsWeighted { get; }

        T Source { get; }

        T Destination { get; }
    }

    public class Edge<T> : IEdge<T>
        where T : IComparable<T>
    {
        public Edge(T source, T destination)
        {
            Source = source;
            Destination = destination;
        }

        public bool IsWeighted => false;

        public T Source { get; }

        public T Destination { get; }

    }
}