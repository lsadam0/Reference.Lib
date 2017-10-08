namespace Reference.Lib.DataStructures.Collections
{
    /// <summary>
    ///     LIFO
    /// </summary>
    public class Stack<T>
    {
        private readonly LinkedList<T> _items = new LinkedList<T>();
        public bool IsEmpty => Count < 1;
        public int Count { get; }

        public void Push(T item)
        {
            _items.AddLast(item);
        }

        public T Pop()
        {
            var last = _items.Tail;
            _items.RemoveLast();
            return last.Value;
        }
    }
}