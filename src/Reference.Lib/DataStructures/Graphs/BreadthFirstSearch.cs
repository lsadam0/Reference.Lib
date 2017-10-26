using System;
using System.Collections.Generic;
using System.Linq;
using Reference.Lib.Algorithms.Sorting;

namespace Reference.Lib.DataStructures.Graphs
{
    /// <summary>
    ///     Implements Breadth-First searching of <see cref="IGraph{T}" /> objects
    /// </summary>
    public class BreadthFirstSearch<T>
        where T : IComparable<T>
    {
        public BreadthFirstSearch(IGraph<T> toSearch)
        {
            Graph = toSearch;
        }

        public IGraph<T> Graph { get; }

        public IEnumerable<T> Search(T root)
        {
            if (!Graph.HasVertex(root))
                throw new KeyNotFoundException();

            var visited = new HashSet<T>();
            var queue = new Collections.Queue<T>();

            visited.Add(root);
            queue.Push(root);

            while (!queue.IsEmpty)
            {
                var next = queue.Pop();
                visited.Add(next);
                yield return next;

                var children = Graph.GetOutgoingEdges(next).Select(x => x.Destination).ToArray();
                children.QuickSort();

                foreach (var c in children.Where(x => !visited.Contains(x)))
                    queue.Push(c);
            }
        }
    }
}