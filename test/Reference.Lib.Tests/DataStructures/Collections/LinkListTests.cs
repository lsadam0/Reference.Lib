using Reference.Lib.DataStructures.Collections;
using Xunit;


namespace Reference.Lib.Tests.DataStructures.Collections
{
    public class LinkedListTests : LinkedListTestBase<LinkedList<int>, LinkedListNode<int>>
    {
        protected override LinkedList<int> CreateList()
        {
            return new LinkedList<int>();
        }
    }
}