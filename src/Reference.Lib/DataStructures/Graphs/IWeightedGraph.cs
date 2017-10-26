using System;
using System.Collections.Generic;

namespace Reference.Lib.DataStructures.Graphs
{
    public interface IWeightedGraph<TV, TW> : IGraph<TV>
        where TV : IComparable<TV>
        where TW : IComparable<TW>
    {
        new IEnumerable<IWeightedEdge<TV, TW>> Edges { get; }

        bool AddEdge(TV origin, TV destination, TW weight);

        new IEnumerable<IWeightedEdge<TV, TW>> GetIncomingEdges(TV vertex);

        new IEnumerable<IWeightedEdge<TV, TW>> GetOutgoingEdges(TV vertex);

        void UpdateEdgeWeight(TV origin, TV destination, TW weight);
    }
}