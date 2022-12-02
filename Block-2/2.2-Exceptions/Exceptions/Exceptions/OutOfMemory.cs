using System;
using System.Text;


namespace Exceptions
{
    public class OutOfMemory
    {
        public void _OutOfMemory()
        {
            StringBuilder stringBuilder = new StringBuilder(7, 7);
            stringBuilder.Append("Hello");
            try
            {
                stringBuilder.Insert(0, "World!", 1);
            }
            catch (Exception e) { Console.WriteLine(e.Message); }
        }
    }
}
