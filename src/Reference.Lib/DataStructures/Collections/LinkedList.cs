using System;
using System.Collections;
using System.Collections.Generic;

namespace Reference.Lib.DataStructures.Collections
{

    public class LinkedList<T> : IEnumerable<T>
    {
        protected readonly IComparer<T> Comparer;
        private LinkedListNode<T> _head;
        private LinkedListNode<T> _tail;

        public LinkedList() => Comparer = Comparer<T>.Default;

        public LinkedListNode<T> AddFirst(T value)
        {
            var head = new LinkedListNode<T>(value, _head);
            AddBefore(_head, head);
            return head;
        }

        public LinkedListNode<T> AddLast(T value)
        {
            var last = new LinkedListNode<T>(value, null);
            AddAfter(_tail, last);
            return last;
        }

        public LinkedListNode<T> AddAfter(LinkedListNode<T> node, T value)
        {
            var after = new LinkedListNode<T>(value, null);
            AddAfter(node, after);
            return after;
        }

        public LinkedListNode<T> AddBefore(LinkedListNode<T> node, T value)
        {
            var before = new LinkedListNode<T>(value, null);
            AddBefore(node, before);
            return before;
        }

        private void InitialAdd(LinkedListNode<T> node)
        {
            _head = node;
            _tail = node;
        }
        public void AddAfter(LinkedListNode<T> node, LinkedListNode<T> value)
        {
            if (_tail == null)
            {
                InitialAdd(value);
                return;
            }

            value.Next = node.Next;
            node.Next = value;
        }

        public void AddBefore(LinkedListNode<T> node, LinkedListNode<T> value)
        {
            if (_head == null)
            {
                InitialAdd(value);
                return;
            }

            value.Next = node;
            if (node == _head)
            {
                _head = value;
                return;
            }

            var predecessor = _head;

            while (predecessor.Next != node && predecessor.Next != null)
            {
                predecessor = predecessor.Next;
            }

            predecessor.Next = value;

        }

        /// <summary>
        /// Remove first instance of value
        /// </summary>
        /// <param name="value">to be removed</param>
        public bool Remove(T value)
        {
            if (_head == null) return false;

            if (Comparer.Compare(_head.Value, value) == 0)
            {
                _head = _head.Next;
                return true;
            }

            var previous = _head;
            var current = _head.Next;

            while (current.Next != null)
            {
                if (Comparer.Compare(current.Value, value) == 0)
                {
                    previous.Next = current.Next;
                    return true;
                }

                previous = current;
                current = current.Next;
            }

            return false;

        }

        public IEnumerator<T> GetEnumerator()
        {
            var node = this._head;

            while (node != null)
            {
                yield return node.Value;
                node = node.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}