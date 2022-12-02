using System;
using System.Collections.Generic;

namespace ExceptionsHandling;

public class IndexOutOfRange
{
    public int _IndexOutOfRange(int count, int index)
    {
        try
        {
            var list = new List<int>();
            for (int i = 0; i < count; i++)
                list.Add(i);

            return(list[index]);
        }
        catch (ArgumentOutOfRangeException e) { 
            Console.WriteLine(e.Message);
            return(-1);
        }
    }
}