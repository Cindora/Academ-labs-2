using System;

namespace Exceptions;

public class IndexOutsideTheBounds
{
    public void _IndexOutsideTheBounds(int count)
    {
        try
        {
            var array = new int[count];
            for (int i = 0; i <= count; i++)
                array[i] = i;
        }
        catch (IndexOutOfRangeException e) { Console.WriteLine(e.Message); }
    }
}