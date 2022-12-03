using System;

namespace ExceptionsHandling;

public class Overflow
{
    public int _Overflow(int number, int plus_num)
    {
        try
        {
            int res = checked(number + plus_num);
            return res;
        }
        catch (OverflowException e) { 
            return -1;
        }
    }
}