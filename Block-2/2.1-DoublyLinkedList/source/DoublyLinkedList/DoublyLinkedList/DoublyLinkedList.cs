using System;
using System.CodeDom;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedList
{
    public class DoublyLinkedList<T>
    {
        public Item<T> First { get; set; }
        public Item<T> Last { get; set; }
        public int Count { get; set; }

        public DoublyLinkedList()
        {
            First = null;
            Last = null;
            Count = 0;
        }

        public DoublyLinkedList(T data)
        {
            var item = new Item<T>(data);
            First = item;
            Last = item;
            Count = 1;
        }

        public void Display()
        {
            var current = First;

            for (int i = 0; i < Count; i++)
            {
                Console.WriteLine(current.Data);
                current = current.Next;
            }
        }

        public void Add(Item<T> item)
        {
            if (Count == 0)
            {
                First = item;
                Last = item;
                Count = 1;
                return;
            }

            Last.Next = item;
            item.Previous = Last;
            item.Next = null;
            Last = item;
            Count++;
        }

        public void AddAfter(Item<T> node, T data)
        {
            var item = new Item<T>(data);
            var current = First;

            if (Count == 0)
            {
                throw new ArgumentNullException();
            }

            for (int i = 0; i < Count; i++)
            {
                if (current == node)
                {
                    item.Next = current.Next;
                    if (current.Next != null)
                    { current.Next.Previous = item; }
                    current.Next = item;
                    item.Previous = current;
                    Count++;
                }
                current = current.Next;
            }
        }

        public void AddBefore(Item<T> node, T data)
        {
            var item = new Item<T>(data);
            var current = Last;

            if (Count == 0)
            {
                throw new ArgumentNullException();
            }

            for (int i = 0; i < Count; i++)
            {
                if (current == node)
                {
                    item.Previous = current.Previous;
                    if (current.Previous != null)
                    { current.Previous.Next = item; }
                    current.Previous = item;
                    item.Next = current;
                    Count++;
                }
                current = current.Previous;
            }
        }

        public void AddFirst(T data)
        {
            var item = new Item<T>(data);

            if (Count == 0)
            {
                First = item;
                Last = item;
                Count = 1;
                return;
            }

            item.Next = First;
            item.Previous = null;
            First = item;
            First.Next.Previous = item;
            Count++;
        }

        public void AddLast(T data)
        {
            var item = new Item<T>(data);

            if (Count == 0)
            {
                First = item;
                Last = item;
                Count = 1;
                return;
            }

            item.Previous = Last;
            item.Next = null;
            Last = item;
            Last.Previous.Next = item;
            Count++;
        }

        public void Clear()
        {
            First = null;
            Last = null;
            Count = 0;
        }

        public bool Contains(T data)
        {
            var item = new Item<T>(data);
            var current = First;

            if (Count != 0)
            {
                for (int i = 0; i < Count; i++)
                {
                    if (current.Data.Equals(data))
                    {
                        return true;
                    }

                    current = current.Next;
                }

                return false;
            }
            else
            {
                return false;
            }
        }

        public bool Equals(Object obj)
        {
            DoublyLinkedList<T> list = (DoublyLinkedList<T>) obj;

            var current = First;
            var currentObj = list.First;

            if (Count == list.Count)
            {
                for (int i = 0; i < Count; i++)
                {
                    if (current != currentObj)
                    { return false; }

                    current = current.Next;
                    currentObj = currentObj.Next;
                }

                return true;
            }
            return false;
        }

        public Item<T> Find(T data)
        {
            var current = First;
            for (int i = 0; i < Count; i++)
            {
                if (current.Data.Equals(data))
                {
                    return current;
                }

                current = current.Next;
            }
            return null;
        }

        public Item<T> FindLast(T data)
        {
            var current = Last;
            for (int i = 0; i < Count; i++)
            {
                if (current.Data.Equals(data))
                {
                    return current;
                }

                current = current.Previous;
            }
            return null;
        }

        private void RemoveItem(Item<T> current)
        {
            if (current.Next != null) { current.Next.Previous = current.Previous; }
            if (current.Previous != null) { current.Previous.Next = current.Next; }
            Count--;
        }

        public void Remove(T data)
        {
            if (Count != 0)
            {
                var current = First;
                for (int i = 0; i < Count; i++)
                {
                    if (current.Data.Equals(data))
                    {
                        if (current == First)
                        { First = current.Next; }
                        else if (current == Last)
                        { Last = current.Previous; }
                        RemoveItem(current);
                        return;
                    }

                    current = current.Next;
                }
            }
        }

        public void RemoveFirst()
        {
            if (Count != 0)
            {
                RemoveItem(First);
                First = First.Next;
            }
            return;
        }

        public void RemoveLast()
        {
            if (Count != 0)
            {
                RemoveItem(Last);
                Last = Last.Previous;
            }
            return;
        }


    }
}