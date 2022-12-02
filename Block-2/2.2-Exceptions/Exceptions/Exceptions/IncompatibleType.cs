using System;

namespace Exceptions;

public class IncompatibleType
{
    public void _IncompatibleType()
    {
        string type = string.Empty;
        try
        {
            object[] array = (object[])("an|error".Split('|'));
            type = array.GetType().Name;
            array[0] = new object();
            Console.WriteLine(string.Format("{0}, {1}", type, string.Join(" ", array)));
        }
        catch (Exception e) { Console.WriteLine(e.Message); }
    }
}