using System;

namespace Exceptions;

public class ValueNull
{
    public void _ValueNull()
    {
        try
        {
            string[] _null = null;
            string _empty = " ";
            var res = string.Join(_empty, _null);
        }
        catch (ArgumentNullException e) { Console.WriteLine(e.Message); }

    }
}