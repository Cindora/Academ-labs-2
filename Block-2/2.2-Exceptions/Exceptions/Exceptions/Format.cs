using System;

namespace Exceptions;

public class Format
{
    public void _Format(string str)
    {
        try
        {
            var res = int.Parse(str);
        }
        catch (FormatException e) { Console.WriteLine(e.Message); }
    }
}