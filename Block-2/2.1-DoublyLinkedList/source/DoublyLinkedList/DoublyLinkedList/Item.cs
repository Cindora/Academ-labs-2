using System;

namespace LinkedList
{
    public class Item<T>
    {
        public T data { get; set; }
        public Item<T> Next { get; set; }
        public Item<T> Previous { get; set; }

        public T Data
        {
            get { return data; }
            set
            {
                if (value != null)
                {
                    data = value;
                }
            }
        }

        public Item(T data)
        {
            Data = data;
        }

    }
}