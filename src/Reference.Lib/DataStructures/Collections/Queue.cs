using System;

namespace Reference.Lib.DataStructures.Collections
{
    public class Queue<T>
    {
        private readonly LinkedList<T> _items = new LinkedList<T>();
        public bool IsEmpty => !_items.HasNodes;
        public int Count => _items.Count;

        public void Push(T item)
        {
            _items.AddLast(item);
        }

        public T Pop()
        {
            if (IsEmpty)
                throw new Exception("Empty");

            var res = _items.Head;
            _items.Remove(res);
            return res.Value;
        }

        public T Peek()
        {
            if (IsEmpty)
                throw new Exception("Empty");

            return _items.Head.Value;
        }
    }
}