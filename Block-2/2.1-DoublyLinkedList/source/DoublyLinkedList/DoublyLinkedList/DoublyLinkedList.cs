using System;
using System.CodeDom;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LinkedList
{
    public class DoublyLinkedList<T> : IEnumerable<T>
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

        public DoublyLinkedList(IEnumerable<T> list)
        {
            Count = 0;
            foreach (var item in list)
            {
                AddLast(item);
            }
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
                    if (i == Count)
                        Last = item;
                    Count++;
                    return;
                }
                current = current.Next;
            }
        }

        public void AddBefore(Item<T> node, T data)
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
                    item.Previous = current.Previous;
                    if (current.Previous != null)
                    { current.Previous.Next = item; }
                    current.Previous = item;
                    item.Next = current;
                    Count++;
                    if (i == 0)
                        First = item;
                    return;
                }
                current = current.Next;
            }
        }

        public void AddFirst(T data)
        {
            var item = new Item<T>(data);

            if (Count == 0)
            {
                First = item;
                Last = First;
                item.Next = First;
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

        public void AddLast(Item<T> node)
        {
            if (null == First) // Если список пустой.
            {
                First = node;
                Last = node;
                Last.Next = First;
            }
            else
            {
                node.Next = First;
                Last.Next = node;
                Last = node;
            }

            Count += 1;
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
            DoublyLinkedList<T> list = (DoublyLinkedList<T>)obj;

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

        public bool Remove(T data)
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
                        return true;
                    }

                    current = current.Next;
                }
            }
            return false;
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

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)this).GetEnumerator();
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            var current = First;

            while (current != null)
            {
                yield return current.Data;
                current = current.Next;
            }
        }


    }

    public static class ListExtensions
    {
        public static bool _Any<TSource>(this IEnumerable<TSource> list)
        {
            return list.Select(item => item != null).FirstOrDefault();
        }

        public static int _Count<TSource>(this IEnumerable<TSource> list)
        {
            var count = 0;
            foreach (var item in list)
            {
                if (item != null)
                {
                    count++;
                }
            }
            return count;
        }

        public static TSource _ElementAt<TSource>(this IEnumerable<TSource> list, Int32 index)
        {
            var i = 0;
            foreach (var item in list)
            {
                if (i == index)
                {
                    return item;
                }

                i++;
            }

            throw new ArgumentOutOfRangeException();
        }

        public static TSource _ElementAtOrDefault<TSource>(this IEnumerable<TSource> list, Int32 index)
        {
            var i = 0;
            foreach (var item in list)
            {
                if (i == index)
                {
                    return item;
                }
                i++;
            }
            return default;
        }

        public static TSource _First<TSource>(this IEnumerable<TSource> list)
        {
            foreach (var item in list)
            {
                return item;
            }

            throw new ArgumentNullException();
        }

        public static TSource _FirstOrDefault<TSource>(this IEnumerable<TSource> list)
        {
            foreach (var item in list)
            {
                return item;
            }
            return default;
        }

        public static TSource _Last<TSource>(this IEnumerable<TSource> list)
        {
            TSource tmpItem = default;
            var count = 0;
            foreach (var item in list)
            {
                tmpItem = item;
                count++;
            }

            return count != 0 ? tmpItem : throw new ArgumentNullException();
        }

        
        public static TSource _LastOrDefault<TSource>(this IEnumerable<TSource> list)
        {
            TSource tmpItem = default;
            var count = 0;
            foreach (var item in list)
            {
                tmpItem = item;
                count++;
            }
            return count != 0 ? tmpItem : default;
        }

        public static TSource _Max<TSource>(this IEnumerable<TSource> list) where TSource : IComparable
        {
            if (list._Any())
            {
                var max = list.First();
                foreach (var item in list)
                {
                    if (item.CompareTo(max) == 1)
                    {
                        max = item;
                    }
                }

                return max;
            }
            throw new ArgumentNullException();
        }

        public static TSource _Min<TSource>(this IEnumerable<TSource> list) where TSource : IComparable
        {
            if (list._Any())
            {
                var min = list.First();
                foreach (var item in list)
                {
                    if (item.CompareTo(min) == -1)
                    {
                        min = item;
                    }
                }

                return min;
            }
            throw new ArgumentNullException();
        }

        public static IEnumerable<TSource> _Reverse<TSource>(this IEnumerable<TSource> list)
        {
            var tmpList = new DoublyLinkedList<TSource>();
            foreach (var item in list)
            {
                tmpList.AddFirst(item);
            }
            return tmpList;
        }

    }
}