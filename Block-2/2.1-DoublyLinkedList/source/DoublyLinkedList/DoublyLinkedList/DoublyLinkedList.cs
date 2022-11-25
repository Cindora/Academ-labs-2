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
        public Item<T> Head { get; set; }
        public Item<T> Tail { get; set; }
        public int Count { get; set; }


        public DoublyLinkedList()
        {
            Head = null;
            Tail = null;
            Count = 0;
        }

        public DoublyLinkedList(T data)
        {
            var item = new Item<T>(data);
            Head = item;
            Tail = null;
            Count = 1;
        }
    }
}