using System;
using System.Collections.Generic;

namespace Exceptions;

public class IndexOutOfRange
{
    public void _IndexOutOfRange(int count)
    {
        try
        {
            var list = new List<int>();
            for (int i = 0; i < count; i++)
                list.Add(i);

            Console.WriteLine(list[count]);
        }
        catch (Exception e) { Console.WriteLine(e.Message); }
    }
}