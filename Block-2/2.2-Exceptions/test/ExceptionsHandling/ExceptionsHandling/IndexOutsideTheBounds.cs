using System;

namespace ExceptionsHandling;

public class IndexOutsideTheBounds
{
    public int _IndexOutsideTheBounds(int max_count, int count)
    {
        try
        {
            var array = new int[max_count];
            for (int i = 0; i < count; i++)
            {
                array[i] = i;
                Console.WriteLine(array[i]);
            }
            return 0;
        }
        catch (IndexOutOfRangeException e) {
            return -1;    
        }
    }
}