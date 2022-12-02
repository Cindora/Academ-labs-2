using System;

namespace ExceptionsHandling;

public class Format
{
    public int _Format(string str)
    {
        try
        {
            return int.Parse(str);
        }
        catch (FormatException e) { 
            return -1;
        }
    }
}