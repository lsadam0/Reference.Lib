using System;
using System.Collections.Generic;
using System.Linq;

namespace Reference.Lib.DataStructures.Graphs
{
    public sealed class DirectedAlGraph<T> : IGraph<T>
        where T : IComparable<T>
    {
        private readonly IDictionary<T, HashSet<T>> _al = new Dictionary<T, HashSet<T>>();

        public bool IsDirected => true;

        public bool IsWeighted => false;

        public int EdgesCount { get; private set; }

        public int VerticesCount => _al.Keys.Count;
        public IEnumerable<T> Vertices => _al.Keys.Select(x => x);

        public IEnumerable<IEdge<T>> Edges => _al.SelectMany(x => x.Value.Select(y => new Edge<T>(x.Key, y)));

        public bool AddEdge(T origin, T destination)
        {
            if (Equals(origin, destination)) return false;

            if (!AddVertex(origin))
                if (_al[origin].Contains(destination)) return false;

            AddVertex(destination);

            _al[origin].Add(destination);
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


        public IEnumerable<IEdge<T>> GetIncomingEdges(T vertex)
        {
            EnforceHasVertex(vertex);

            foreach (var kvp in _al.Where(x => !Equals(x.Key, vertex)))
                if (kvp.Value.Contains(vertex))
                    yield return new Edge<T>(kvp.Key, vertex);
        }

        public IEnumerable<IEdge<T>> GetOutgoingEdges(T vertex)
        {
            EnforceHasVertex(vertex);

            foreach (var e in _al[vertex])
                yield return new Edge<T>(vertex, e);
        }

        public bool HasEdge(T origin, T destination)
        {
            return HasVertex(origin)
                   && _al[origin].Contains(destination);
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
            if (!_al.ContainsKey(vertex)) return false;

            // remove all edges to this vertex
            var incomingEdges = 0;
            foreach (var e in _al)
                if (e.Value.Contains(vertex))
                {
                    e.Value.Remove(vertex);
                    ++incomingEdges;
                }

            var entry = _al[vertex];
            _al.Remove(vertex);

            EdgesCount -= entry.Count + incomingEdges;
            return true;
        }

        private void EnforceHasVertex(T vertex)
        {
            if (!HasVertex(vertex))
                throw new KeyNotFoundException();
        }


        public bool AreAdjacent(T a, T b)
        {
          if (!HasVertex(a) || !HasVertex(b)) return false;

          return _al[a].Contains(b);
        }
    }
}