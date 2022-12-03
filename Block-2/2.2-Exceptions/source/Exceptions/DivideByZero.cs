using System;

namespace Exceptions;

public class DivideByZero
{
    public void _DivideByZero(int dividend, int divider)
    {
        try
        {
            var res = dividend / divider;
        }
        catch (DivideByZeroException e) { Console.WriteLine(e.Message); }
    }
}