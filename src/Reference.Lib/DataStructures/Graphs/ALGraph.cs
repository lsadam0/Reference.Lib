using System;
using System.Collections.Generic;
using System.Linq;

namespace Reference.Lib.DataStructures.Graphs
{
    public sealed class AlGraph<T> : IGraph<T>
        where T : IComparable<T>
    {
        private readonly IDictionary<T, HashSet<T>> _al = new Dictionary<T, HashSet<T>>();

        public bool IsDirected => false;

        public bool IsWeighted => false;

        public int EdgesCount { get; private set; }

        public int VerticesCount => _al.Keys.Count;

        public IEnumerable<T> Vertices => _al.Keys.Select(x => x);


        public IEnumerable<IEdge<T>> Edges => _al.SelectMany(x => x.Value.Select(y => new Edge<T>(x.Key, y)));

        public bool AddEdge(T origin, T destination)
        {
            // no self-paths
            if (Equals(origin, destination)) return false;

            // ensure origin exists
            if (!AddVertex(origin))
                if (_al[origin].Contains(destination)) return false; // edge already exists

            // ensure destination exists
            AddVertex(destination);

            // add both directions
            _al[origin].Add(destination);
            _al[destination].Add(origin);

            /* We've added two directions, but these two edges
             * only connect origin and destination, so technically
             * these are a single edge.
             */
            ++EdgesCount;
            return true;
        }

        public bool AddVertex(T vertex)
        {
            if (_al.ContainsKey(vertex)) return false;

            _al.Add(vertex, new HashSet<T>());
            return true;
        }

        public void AddVertices(IEnumerable<T> vertices)
        {
            foreach (var v in vertices)
                AddVertex(v);
        }


        public void Clear()
        {
            EdgesCount = 0;
            _al.Clear();
        }

        public bool HasEdge(T origin, T destination)
        {
            return HasVertex(origin)
                   && HasVertex(destination)
                   && _al[origin].Contains(destination)
                   && _al[destination].Contains(origin);
        }

        public bool HasVertex(T vertex)
        {
            return _al.ContainsKey(vertex);
        }


        public bool RemoveEdge(T origin, T destination)
        {
            if (!_al.ContainsKey(origin)) return false;
            if (!_al[origin].Contains(destination)) return false;

            _al[origin].Remove(destination);
            _al[destination].Remove(origin);
            --EdgesCount;
            return true;
        }

        public bool RemoveVertex(T vertex)
        {
            // already removed?
            if (!_al.ContainsKey(vertex)) return false;

            // remove all edges to this vertex
            foreach (var e in _al)
                if (e.Value.Contains(vertex))
                    e.Value.Remove(vertex);

            var entry = _al[vertex];

            // Since we count both directions as a single edge,
            // just reduce the edge count by the number present
            // for the vertex
            EdgesCount -= entry.Count;
            _al.Remove(vertex);

            return true;
        }

        public IEnumerable<IEdge<T>> GetOutgoingEdges(T vertex)
        {
            return GetEdgesFor(vertex);
        }

        public IEnumerable<IEdge<T>> GetIncomingEdges(T vertex)
        {
            return GetEdgesFor(vertex);
        }

        private void EnforceHasVertex(T vertex)
        {
            if (!HasVertex(vertex))
                throw new KeyNotFoundException();
        }


        private IEnumerable<IEdge<T>> GetEdgesFor(T vertex)
        {
            EnforceHasVertex(vertex);

            /* Because each edge addition is symmetrical, the
                set of outgoing and the set of incoming edges
                are the same.  Thus we simply iterate over the set
                contained at the request vertex
             */
            foreach (var edge in _al[vertex])
                yield return new Edge<T>(vertex, edge);
        }

        public bool AreAdjacent(T a, T b)
        {
          if (!HasVertex(a) || !HasVertex(b)) return false;

          return _al[a].Contains(b);
        }
    }
}