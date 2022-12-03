using System;

namespace ExceptionsHandling;

public class IncompatibleType
{
    public int _IncompatibleType()
    {
        string type = string.Empty;
        try
        {
            object[] array = (object[])("an|error".Split('|'));
            type = array.GetType().Name;
            array[0] = new object();
            Console.WriteLine(string.Format("{0}, {1}", type, string.Join(" ", array)));
            return 0;
        }
        catch (ArrayTypeMismatchException e) { 
            Console.WriteLine(e.Message);
            return (-1);
        }
    }
}