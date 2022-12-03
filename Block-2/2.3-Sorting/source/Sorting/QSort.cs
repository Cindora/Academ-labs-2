using Sorting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sorting
{
    public class GenericQuickSort
    {
        public void QuickSort<T>(T[] list) where T : IComparable<T>
        {
            QSort(list, 0, list.Length - 1);
        }

        private static void QSort<T>(T[] array, int firstIndex, int lastIndex) where T : IComparable<T>
        {
            if (firstIndex >= lastIndex) return;
            int c = Swap(array, firstIndex, lastIndex);
            QSort(array, firstIndex, c - 1);
            QSort(array, c + 1, lastIndex);
        }

        private static int Swap<T>(T[] array, int firstIndex, int lastIndex) where T : IComparable<T>
        {
            int i = firstIndex;
            for (int j = firstIndex; j <= lastIndex; j++)
            {
                if (array[j].CompareTo(array[lastIndex]) <= 0)
                {
                    T t = array[i];
                    array[i] = array[j];
                    array[j] = t;
                    i++;
                }
            }
            return i - 1;
        }

        public void Display<T>(IEnumerable<T> list)
        {
            foreach (var item in list)
                Console.Write (item+" ");
        }
    }
}