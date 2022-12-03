using System;

namespace Exceptions;

public class Overflow
{
    public void _Overflow()
    {
        try
        {
            int number = 2147483647;
            int res = checked(number + 1);
        }
        catch (OverflowException e) { Console.WriteLine(e.Message); }
    }
}