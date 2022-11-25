using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedList
{
    class App
    {
        static void Main()
        {
            var el1 = new Item<int>(11);
            var el2 = new Item<int>(22);
            var el3 = new Item<int>(22);
            var el4 = new Item<int>(44);
            var el5 = new Item<int>(22);
            var el6 = new Item<int>(44);

            var list = new DoublyLinkedList<int>();
            var list2 = new DoublyLinkedList<int>();

            list.Add(el1);
            list.Add(el2);
            list.Add(el3);
            list.Add(el4);
            list.Add(el5);
            list.Add(el6);




        }
    }
}