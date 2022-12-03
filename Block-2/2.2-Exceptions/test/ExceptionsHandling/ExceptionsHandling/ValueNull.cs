using System;

namespace ExceptionsHandling;

public class ValueNull
{
    public int _ValueNull(string[] str1, string str2)
    {
        try
        {
            string res = string.Join(str2, str1);
            Console.WriteLine(res);
            return 0;
        }
        catch (ArgumentNullException e) { return -1; }
    }
}