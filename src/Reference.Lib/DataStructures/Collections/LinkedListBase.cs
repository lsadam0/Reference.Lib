using System.Collections;
using System.Collections.Generic;

namespace Reference.Lib.DataStructures.Collections
{
    public abstract class LinkedListBase<TV, TN> : IEnumerable<TV>
        where TN : class, ILinkedListNode<TV>
    {
        protected readonly IComparer<TV> Comparer;
        internal TN Head;

        internal TN Tail;

        protected LinkedListBase(TV[] items): this() 
        {
            foreach (var item in items)
                this.AddLast(item);
        }


        protected LinkedListBase()
        {
            Comparer = Comparer<TV>.Default;
        }

        public bool HasNodes => Head != null && Tail != null;

        public int Count { get; private set; }

        public IEnumerator<TV> GetEnumerator()
        {
            if (!HasNodes) yield break;

            ILinkedListNode<TV> node = Head;

            while (node != null)
            {
                yield return node.Value;
                node = node.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public TN AddFirst(TV value)
        {
            var first = CreateNodeFor(value);

            if (!HasNodes)
                InitialAdd(first);
            else
                AddBefore(Head, first);

            return first;
        }

        public TN AddLast(TV value)
        {
            var last = CreateNodeFor(value);

            if (!HasNodes)
                InitialAdd(last);
            else
                AddAfter(Tail, last);
                
            return last;
        }


        protected abstract TN GetPredecessorOf(TN node);

        private void InitialAdd(TN node)
        {
            Head = node;
            Tail = node;
            ++Count;
        }

        protected abstract TN CreateNodeFor(TV value);


        public void AddBefore(TN existing, TV value)
        {
            AddBefore(existing, CreateNodeFor(value));
        }

        public void AddAfter(TN existing, TV value)
        {
            AddAfter(existing, CreateNodeFor(value));
        }

        public void AddBefore(TN existing, TN toAdd)
        {
            var predecessor = GetPredecessorOf(existing);
            AddNodeBefore(existing, toAdd, predecessor);
            if (existing == Head)
                Head = toAdd;
            ++Count;
        }

        public void AddAfter(TN existing, TN toAdd)
        {
            AddNodeAfter(existing, toAdd);

            if (existing == Tail)
                Tail = toAdd;
            ++Count;
        }

        protected abstract void AddNodeBefore(TN existing, TN toAdd, TN predecessor);

        protected abstract void AddNodeAfter(TN existing, TN toAdd);


        public ILinkedListNode<TV> RemoveLast()
        {
            var res = Tail;
            Remove(Tail);
            return res;
        }

        protected TN Find(TV value)
        {
            var current = Head;

            while (current != null)
            {
                if (Comparer.Compare(current.Value, value) == 0)
                    return current;

                current = (TN) current.Next;
            }
            return null;
        }

        public bool Remove(TV value)
        {
            var node = Find(value);

            return Remove(node);
        }

        public bool Remove(TN toRemove)
        {
            if (toRemove == null)
                return false;

            var predecessor = GetPredecessorOf(toRemove);

            if (Head == toRemove)
                Head = (TN) toRemove.Next;
            else if (Tail == toRemove)
                Tail = predecessor;

            RemoveNode(predecessor, toRemove);
            --Count;
            return true;
        }

        protected abstract void RemoveNode(TN predecessor, TN toRemove);
    }
}