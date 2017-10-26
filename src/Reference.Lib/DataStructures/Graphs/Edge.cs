using System;

namespace Reference.Lib.DataStructures.Graphs
{
    public class Edge<TV> : IEdge<TV>
        where TV : IComparable<TV>
    {
        public Edge(TV source, TV destination)
        {
            Origin = source;
            Destination = destination;
        }

        public bool IsWeighted => false;

        public TV Origin { get; }

        public TV Destination { get; }
    }
}