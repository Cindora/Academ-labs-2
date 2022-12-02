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
        catch (Exception e) { Console.WriteLine(e.Message); }
    }
}