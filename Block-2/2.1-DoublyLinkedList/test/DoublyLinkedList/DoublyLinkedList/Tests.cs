using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Net.Http;
using System.Runtime.InteropServices;
using LinkedList;
using NUnit.Framework;
using NUnit.Framework.Interfaces;

namespace DoublyLinkedListTests
{
    [TestFixture]
    public class DoublyLinkedListTests
    {
        public string[] InputStr { get; set; }
        public float[] InputFloat { get; set; }

        public DoublyLinkedListTests()
        {
            try
            {
                string[] input = File.ReadLines("../../../test.txt").Skip(1).First().Split(' ');
                string[] inputstr = new string[5];
                for (int i = 0; i < 5; i++)
                {
                    inputstr[i] = input[i];
                }
                InputStr = inputstr;
                float[] inputfloat = new float[5];
                for (int i = 5; i < 10; i++)
                {
                    inputfloat[i - 5] = float.Parse(input[i]);
                }
                InputFloat = inputfloat;
            }
            catch
            {
                throw new Exception();
            }
        }

        [Test]
        //DoublyLinkedList(IEnumerable<T> list)
        public void DoublyLinkedList()
        {

            var itemList = new List<float>();
            itemList.Add(InputFloat[0]);
            itemList.Add(InputFloat[1]);
            itemList.Add(InputFloat[2]);

            var list = new DoublyLinkedList<float>(itemList);

            Assert.AreEqual(3, list.Count);
            Assert.AreEqual(true, list.Contains(InputFloat[0]));
            Assert.AreEqual(true, list.Contains(InputFloat[1]));
            Assert.AreEqual(true, list.Contains(InputFloat[2]));
        }


        [Test]
        //AddAfter(LinkedListNode<T>, T)
        public void AddAfter()
        {
            var list = new DoublyLinkedList<float>();
            try
            {
                list.AddAfter(list.First, InputFloat[0]);
            }
            catch (Exception e)
            {
                var x = new ArgumentNullException();
                Assert.AreEqual(x.GetType(), e.GetType());
            }
        }

        [Test]
        //AddAfter(LinkedListNode<T>, T)
        public void AddAfter2()
        {
            var list = new DoublyLinkedList<float>();

            list.AddLast(InputFloat[0]);
            list.AddAfter(list.First, InputFloat[1]);
            list.AddAfter(list.First.Next, InputFloat[2]);
            list.AddAfter(list.First.Next.Next, InputFloat[3]);

            Assert.AreEqual(4, list.Count);
            Assert.AreEqual(InputFloat[0], list.First.Data);
            Assert.AreEqual(InputFloat[1], list.First.Next.Data);
            Assert.AreEqual(InputFloat[2], list.First.Next.Next.Data);
            Assert.AreEqual(InputFloat[3], list.First.Next.Next.Next.Data);

        }


        [Test]
        //AddBefore(LinkedListNode<T>, T)
        public void AddBefore()
        {
            var list = new DoublyLinkedList<float>();
            var node = new Item<float>(InputFloat[0]);
            try
            {
                list.AddBefore(node, list.First.Data);
            }
            catch (Exception e)
            {
                var x = new NullReferenceException();
                Assert.AreEqual(x.GetType(), e.GetType());
            }
        }

        [Test]
        //AddFirst(T)
        public void AddFirst()
        {
            var list = new DoublyLinkedList<float>();

            list.AddFirst(InputFloat[0]);
            list.AddFirst(InputFloat[1]);
            list.AddFirst(InputFloat[2]);

            Assert.AreEqual(InputFloat[2], list.First.Data);
            Assert.AreEqual(InputFloat[1], list.First.Next.Data);
            Assert.AreEqual(InputFloat[0], list.Last.Data);
            Assert.AreEqual(list.First, list.Last.Previous.Previous);
            Assert.AreEqual(3, list.Count);
        }

        [Test]
        //Contains(T)
        public void Contains()
        {
            var list = new DoublyLinkedList<float>();
            var containsResult = list.Contains(InputFloat[0]);
            Assert.AreEqual(false, containsResult);
        }

        [Test]
        //Contains(T)
        public void Contains2()
        {
            var list = new DoublyLinkedList<float>();
            list.AddLast(InputFloat[0]);

            var containsResult = list.Contains(InputFloat[0]);

            Assert.AreEqual(1, list.Count);
            Assert.AreEqual(true, containsResult);
        }

        [Test]
        //Clear()
        public void Clear()
        {
            var list = new DoublyLinkedList<string>();

            list.AddLast(InputStr[0]);
            list.AddLast(InputStr[1]);
            list.AddLast(InputStr[2]);
            list.Clear();

            Assert.AreEqual(0, list.Count);
        }

        [Test]
        //AddLast(T) 
        public void AddLast()
        {
            var list = new DoublyLinkedList<string>();

            list.AddLast(InputStr[0]);
            var containsResult = list.Contains(InputStr[0]);

            Assert.AreEqual(1, list.Count);
            Assert.AreEqual(true, containsResult);
        }

        [Test]
        //AddLast(T) 
        public void AddLast2()
        {
            var list = new DoublyLinkedList<string>();
            list.AddLast(InputStr[0]);
            list.AddLast(InputStr[1]);
            var containsResult = list.Contains(InputStr[1]);

            Assert.AreEqual(2, list.Count);
            Assert.AreEqual(true, containsResult);
        }


        [Test]
        //Equals(Object) 
        public void Equals()
        {
            var list = new DoublyLinkedList<float>();
            list.AddLast(InputFloat[0]);
            var newList = new DoublyLinkedList<float>();
            newList.AddLast(InputFloat[0]);

            var result = list.Equals(newList);

            Assert.AreEqual(false, result);

        }

        [Test]
        //Equals(Object) 
        public void Equals2()
        {
            var list = new DoublyLinkedList<float>();
            list.AddLast(InputFloat[0]);
            var newList = new DoublyLinkedList<float>();
            newList.AddLast(InputFloat[1]);

            var result = list.Equals(newList);

            Assert.AreEqual(false, result);
        }

        [Test]
        //Equals(Object) 
        public void Equals3()
        {
            var list1 = new DoublyLinkedList<float>();
            var list2 = new DoublyLinkedList<float>();
            var node = new Item<float>(InputFloat[0]);
            list1.AddLast(node);
            list2.AddLast(node);


            var result = list1.Equals(list2);

            Assert.AreEqual(true, result);
        }

        [Test]
        //Find(T)
        public void Find()
        {
            var list = new DoublyLinkedList<string>();

            var result = list.Find(InputStr[0]);

            Assert.AreEqual(null, result);
        }

        [Test]
        //Find(T)
        public void Find2()
        {
            var list = new DoublyLinkedList<string>();
            list.AddLast(InputStr[0]);

            var result = list.Find(InputStr[1]);

            Assert.AreEqual(null, result);
        }

        [Test]
        //Find(T)
        public void Find3()
        {
            var list = new DoublyLinkedList<string>();
            list.AddLast(InputStr[0]);
            list.AddLast(InputStr[1]);
            list.AddLast(InputStr[1]);

            var result = list.Find(InputStr[1]);

            Assert.AreEqual(list.First.Next, result);
        }

        [Test]
        //Remove(T) 
        public void Remove()
        {
            var list = new DoublyLinkedList<float>();

            var deleteResult = list.Remove(InputFloat[0]);

            Assert.AreEqual(false, deleteResult);
        }

        [Test]
        //Remove(T) 
        public void Remove2()
        {
            var list = new DoublyLinkedList<float>();
            list.AddLast(InputFloat[0]);

            var deleteResult = list.Remove(InputFloat[0]);

            Assert.AreEqual(true, deleteResult);
        }

        [Test]
        //RemoveFirst()
        public void RemoveFirst()
        {
            var list = new DoublyLinkedList<float>();

            list.RemoveFirst();

            Assert.AreEqual(null, list.First);
        }

        [Test]
        //RemoveFirst()
        public void RemoveFirst2()
        {
            var list = new DoublyLinkedList<float>();
            for (var i = 0; i < 5; i++)
            {
                list.AddLast(InputFloat[i]);
            }

            list.RemoveFirst();

            Assert.AreEqual(4, list.Count);
            Assert.AreEqual(InputFloat[1], list.First.Data);
            Assert.AreEqual(InputFloat[2], list.First.Next.Data);
            Assert.AreEqual(InputFloat[4], list.Last.Data);
        }

        [Test]
        //RemoveLast()
        public void RemoveLast()
        {
            var list = new DoublyLinkedList<float>();

            list.RemoveLast();

            Assert.AreEqual(null, list.Last);
        }

        [Test]
        //RemoveLast()
        public void RemoveLast2()
        {
            var list = new DoublyLinkedList<float>();
            for (var i = 0; i < 4; i++)
            {
                list.AddLast(InputFloat[i]);
            }

            list.RemoveLast();

            Assert.AreEqual(3, list.Count);
            Assert.AreEqual(InputFloat[0], list.First.Data);
            Assert.AreEqual(InputFloat[1], list.First.Next.Data);
            Assert.AreEqual(InputFloat[2], list.Last.Data);
        }

        [Test]
        //FindLast(T) 
        public void FindLast()
        {
            var list = new DoublyLinkedList<float>();
            for (var i = 0; i < 4; i++)
            {
                list.AddLast(InputFloat[i]);
            }

            var result = list.FindLast(InputFloat[4]);

            Assert.AreEqual(null, result);
        }

        [Test]
        //FindLast(T) 
        public void FindLast2()
        {
            var list = new DoublyLinkedList<float>();
            for (var i = 0; i < 5; i++)
            {
                list.AddLast(InputFloat[i]);
            }

            list.AddLast(InputFloat[4]);

            var result = list.FindLast(InputFloat[4]);

            Assert.AreEqual(list.Last, result);
        }


        [Test]
        //IEnumerator
        public void IEnumerator()
        {
            var list = new DoublyLinkedList<float>();
            list.AddLast(InputFloat[0]);
            list.AddLast(InputFloat[1]);
            list.AddLast(InputFloat[2]);

            var array = new float[] { InputFloat[0], InputFloat[1], InputFloat[2] };
            var i = 0;

            foreach (var item in list)
            {
                Assert.AreEqual(array[i], item);
                i += 1;
            }
        }


        [Test]
        //Any<TSource>(IEnumerable<TSource>) 
        public void Any()
        {
            var list = new DoublyLinkedList<float>();

            var result = list._Any();

            Assert.AreEqual(false, result);
        }

        [Test]
        //Any<TSource>(IEnumerable<TSource>) 
        public void Any1()
        {
            var list = new DoublyLinkedList<float>();
            list.AddLast(InputFloat[0]);

            var result = list._Any();

            Assert.AreEqual(true, result);
        }

        [Test]
        //Count<TSource>(IEnumerable<TSource>) 
        public void Count()
        {
            var list = new DoublyLinkedList<String>();
            for (var i = 0; i < 5; i++)
            {
                list.AddLast(InputStr[i]);
            }

            var result = list._Count();

            Assert.AreEqual(5, result);
        }

        [Test]
        //ElementAt<TSource>(IEnumerable<TSource>, float32) 
        public void ElementAt()
        {
            var list = new DoublyLinkedList<float>();

            try
            {
                list._ElementAt(1);
            }
            catch (Exception e)
            {
                var x = new ArgumentOutOfRangeException();
                Assert.AreEqual(x.GetType(), e.GetType());
            }
        }

        [Test]
        //ElementAt<TSource>(IEnumerable<TSource>, float32) 
        public void ElementAt2()
        {
            var list = new DoublyLinkedList<float>();
            for (var i = 0; i < 5; i++)
            {
                list.AddLast(InputFloat[i]);
            }

            var result = list._ElementAt(3);

            Assert.AreEqual(InputFloat[3], result);
        }

        [Test]
        //ElementAtOrDefault<TSource>(IEnumerable<TSource>, float32) 
        public void ElementAtOrDefault()
        {
            var list = new DoublyLinkedList<float>();

            var result = list._ElementAtOrDefault(3);

            Assert.AreEqual(0, result);
        }

        [Test]
        //ElementAtOrDefault<TSource>(IEnumerable<TSource>, float32) 
        public void ElementAtOrDefault2()
        {
            var list = new DoublyLinkedList<float>();
            for (var i = 0; i < 5; i++)
            {
                list.AddLast(InputFloat[i]);
            }

            var result = list._ElementAt(3);

            Assert.AreEqual(InputFloat[3], result);
        }

        [Test]
        //First<TSource>(IEnumerable<TSource>) 
        public void First()
        {
            var list = new DoublyLinkedList<float>();
            for (var i = 0; i < 4; i++)
            {
                list.AddLast(InputFloat[i]);
            }

            var result = list._First();

            Assert.AreEqual(InputFloat[0], result);
        }

        [Test]
        //FirstOrDefault<TSource>(IEnumerable<TSource>) 
        public void FirstOrDefault()
        {
            var list = new DoublyLinkedList<float>();

            var result = list._FirstOrDefault();

            Assert.AreEqual(0, result);
        }

        [Test]
        //Last<TSource>(IEnumerable<TSource>) 
        public void Last()
        {
            var list = new DoublyLinkedList<float>();
            for (var i = 0; i < 5; i++)
            {
                list.AddLast(InputFloat[i]);
            }

            var result = list._Last();

            Assert.AreEqual(InputFloat[4], result);
        }

        [Test]
        //LastOrDefault<TSource>(IEnumerable<TSource>) 
        public void LastOrDefault()
        {
            var list = new DoublyLinkedList<float>();

            var result = list._LastOrDefault();

            Assert.AreEqual(0, result);
        }

        [Test]
        //LastOrDefault<TSource>(IEnumerable<TSource>) 
        public void LastOrDefault2()
        {
            var list = new DoublyLinkedList<float>();
            for (var i = 0; i < 5; i++)
            {
                list.AddLast(InputFloat[i]);
            }

            var result = list._LastOrDefault();

            Assert.AreEqual(InputFloat[4], result);
        }


        [Test]
        //Max<TSource>(IEnumerable<TSource>)
        public void Max()
        {
            var list = new DoublyLinkedList<float>();
            for (var i = 0; i < 4; i++)
            {
                list.AddLast(InputFloat[i]);
            }
            list.AddLast(InputFloat[4]);

            var result = list._Max();

            Assert.AreEqual(InputFloat.Max(), result);
        }

        [Test]
        //Min<TSource>(IEnumerable<TSource>)
        public void Min()
        {
            var list = new DoublyLinkedList<float>();
            for (var i = 0; i < 5; i++)
            {
                list.AddLast(InputFloat[i]);
            }

            var result = list._Min();
            Assert.AreEqual(InputFloat.Min(), result);
        }

        [Test]
        //Reverse<TSource>(IEnumerable<TSource>)
        public void Reverse()
        {
            var list0 = new DoublyLinkedList<float>();
            for (var i = 0; i < 4; i++)
            {
                list0.AddLast(InputFloat[i]);
            }

            var list = (DoublyLinkedList<float>)list0._Reverse();

            Assert.AreEqual(4, list.Count);
            Assert.AreEqual(InputFloat[3], list.First.Data);
            Assert.AreEqual(InputFloat[2], list.First.Next.Data);
            Assert.AreEqual(InputFloat[1], list.First.Next.Next.Data);
            Assert.AreEqual(InputFloat[0], list.Last.Data);
        }
    }
}