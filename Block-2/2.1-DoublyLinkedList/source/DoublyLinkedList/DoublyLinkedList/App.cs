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
            var list = new DoublyLinkedList<String>();
            for (var i = 0; i < 10; i++)
            {
                list.AddLast("a" + i.ToString());
            }
            var result = 0;




            Console.WriteLine();


        }
    }
}