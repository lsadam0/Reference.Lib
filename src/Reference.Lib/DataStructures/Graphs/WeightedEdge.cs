using System;

namespace Reference.Lib.DataStructures.Graphs
{
    public class WeightedEdge<TV, TW> : IWeightedEdge<TV, TW>
        where TV : IComparable<TV>
        where TW : IComparable<TW>
    {
        public WeightedEdge(TV origin, TV destination, TW weight)
        {
            Origin = origin;
            Destination = destination;
            Weight = weight;
        }

        public bool IsWeighted => false;

        public TV Origin { get; }

        public TV Destination { get; }

        public TW Weight { get; }
    }
}