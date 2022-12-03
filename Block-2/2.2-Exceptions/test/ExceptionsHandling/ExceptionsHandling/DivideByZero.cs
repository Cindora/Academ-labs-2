using System;

namespace ExceptionsHandling;

public class DivideByZero
{
    public int _DivideByZero(int dividend, int divider)
    {
        try
        {
            return dividend / divider;
        }
        catch (DivideByZeroException e) {
            return -1;
        }
    }
}