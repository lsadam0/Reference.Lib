using Reference.Lib.DataStructures.Graphs;

namespace Reference.Lib.Tests.DataStructures.Graphs
{
    public class WeightedALGraphTests : UndirectedGraphTests
    {
        protected override IGraph<int> GetGraph()
        {
            return new WeightedAlGraph<int, int>();
        }
    }
}