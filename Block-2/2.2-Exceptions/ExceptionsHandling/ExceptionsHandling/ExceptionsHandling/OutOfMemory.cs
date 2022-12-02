using System;
using System.Text;


namespace ExceptionsHandling
{
    public class OutOfMemory
    {
        public int _OutOfMemory(int max_capacity, string str)
        {
            StringBuilder stringBuilder = new StringBuilder(0, max_capacity);
            try
            {
                stringBuilder.Append(str);
                Console.WriteLine(stringBuilder.ToString());
                return 0;
            }
            catch (OutOfMemoryException e) { 
                return -1; 
            }
        }
    }
}
