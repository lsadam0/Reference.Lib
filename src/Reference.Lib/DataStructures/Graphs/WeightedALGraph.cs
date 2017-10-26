using System;
using System.Collections.Generic;
using System.Linq;

namespace Reference.Lib.DataStructures.Graphs
{
    public class WeightedAlGraph<TV, TW> : IWeightedGraph<TV, TW>
        where TV : IComparable<TV>
        where TW : IComparable<TW>
    {
        private readonly IDictionary<TV, Dictionary<TV, TW>> _al = new Dictionary<TV, Dictionary<TV, TW>>();

        public IEnumerable<IWeightedEdge<TV, TW>> Edges => _al.SelectMany(
            x => x.Value.Select(y => new WeightedEdge<TV, TW>(x.Key, y.Key, y.Value)));

        public bool IsDirected => false;
        public bool IsWeighted => true;

        public int EdgesCount { get; private set; }

        public int VerticesCount => _al.Keys.Count;
        public IEnumerable<TV> Vertices => _al.Keys.Select(x => x);

        IEnumerable<IEdge<TV>> IGraph<TV>.Edges => Edges;

        public bool AddEdge(TV origin, TV destination, TW weight)
        {
            if (!AddVertex(origin))
                if (_al[origin].ContainsKey(destination)) return false;

            AddVertex(destination);
            _al[origin][destination] = weight;
            _al[destination][origin] = weight;
            ++EdgesCount;
            return true;
        }

        public bool AddEdge(TV origin, TV destination)
        {
            return AddEdge(origin, destination, default(TW));
        }

        public bool AddVertex(TV vertex)
        {
            if (_al.ContainsKey(vertex)) return false;
            _al[vertex] = new Dictionary<TV, TW>();
            return true;
        }

        public void AddVertices(IEnumerable<TV> vertices)
        {
            foreach (var v in vertices)
                AddVertex(v);
        }

        public void Clear()
        {
            _al.Clear();
            EdgesCount = 0;
        }

        public IEnumerable<IWeightedEdge<TV, TW>> GetIncomingEdges(TV vertex)
        {
            foreach (var kvp in _al
                .Where(x => !Equals(x.Key, vertex)) // filter self
                .Where(x => x.Value.ContainsKey(vertex)))
                yield return new WeightedEdge<TV, TW>(kvp.Key, vertex, kvp.Value[vertex]);
        }

        public IEnumerable<IWeightedEdge<TV, TW>> GetOutgoingEdges(TV vertex)
        {
            foreach (var kvp in _al[vertex])
                yield return new WeightedEdge<TV, TW>(vertex, kvp.Key, kvp.Value);
        }

        public bool HasEdge(TV origin, TV destination)
        {
            if (!_al.ContainsKey(origin)) return false;
            return _al[origin].ContainsKey(destination);
        }

        public bool HasVertex(TV vertex)
        {
            return _al.ContainsKey(vertex);
        }

        public bool RemoveEdge(TV origin, TV destination)
        {
            if (!HasEdge(origin, destination)) return false;

            _al[origin].Remove(destination);
            _al[destination].Remove(origin);
            --EdgesCount;
            return true;
        }

        public bool RemoveVertex(TV vertex)
        {
            if (!_al.ContainsKey(vertex)) return false;

            var toRemove = _al[vertex];
            _al.Remove(vertex);
            EdgesCount -= toRemove.Values.Count;

            foreach (var v in toRemove.Keys)
                _al[v].Remove(vertex);
            return true;
        }

        public void UpdateEdgeWeight(TV firsT, TV secondVertex, TW weight)
        {
            EnforceHasVertex(firsT);
            EnforceHasVertex(secondVertex);
            EnforceHasEdge(firsT, secondVertex);

            _al[firsT][secondVertex] = weight;
        }

        IEnumerable<IEdge<TV>> IGraph<TV>.GetIncomingEdges(TV vertex)
        {
            return GetIncomingEdges(vertex);
        }

        IEnumerable<IEdge<TV>> IGraph<TV>.GetOutgoingEdges(TV vertex)
        {
            return GetOutgoingEdges(vertex);
        }

        private void EnforceHasVertex(TV vertex)
        {
            if (!_al.ContainsKey(vertex))
                throw new KeyNotFoundException();
        }

        private void EnforceHasEdge(TV origin, TV destination)
        {
            EnforceHasVertex(origin);
            EnforceHasVertex(destination);

            if (!_al[origin].ContainsKey(destination))
                throw new KeyNotFoundException();
        }
    }
}