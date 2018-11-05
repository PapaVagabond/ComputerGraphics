using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolyEditor
{

    class CyclicList<T> : IEnumerable<T>
    {
        protected Node First { get; set; }
        public int Count { get; set; }

        public CyclicList()
        {
            First = null;
            Count = 0;
        }

        public CyclicList(IEnumerable<T> elements) : base()
        {
            foreach (T elem in elements)
                this.Add(elem);
        }

        public void Add(T elem)
        {
            if (First == null)
            {
                First = new Node(elem);
                First.Previous = First.Next = First;
            }
            else
            {
                Node newNode = new Node(elem, First.Previous, First);
                First.Previous.Next = newNode;
                First.Previous = newNode;
            }
            Count++;
        }

        // Inserts element before specified index
        public void Insert(int index, T elem)
        {
            if (index < 0 || index > Count)
                throw new ArgumentOutOfRangeException();
            Node it = First;
            for (int i = 0; i < index; i++)
                it = it.Next;
            Node newNode = new Node(elem, it.Previous, it);
            it.Previous.Next = newNode;
            it.Previous = newNode;
            Count++;
        }

        public IEnumerator<T> ElementsFrom(int k)
        {
            Node it = First;
            for (int i = 0; i < k; i++)
                it = it.Next;
            for(int i=0;i<Count;i++)
            {
                yield return it.Item;
                it = it.Next;
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            Node it = First;
            for(int i=0;i<Count;i++)
            {
                yield return it.Item;
                it = it.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        protected class Node
        {
            public Node Previous { get; set; }
            public Node Next { get; set; }
            public T Item { get; set; }

            public Node(T item, Node prev = null, Node next = null)
            {
                Item = item;
                Next = next;
                Previous = prev;
            }
        }
    }
}
