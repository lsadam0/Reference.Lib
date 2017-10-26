
using Reference.Lib.DataStructures.Collections;

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