using System;

namespace ExceptionsHandling;

public class UnableCast
{
    public int _UnableCast(bool _bool)
    {
        try
        {
            Object _object = new Object();
            if (_bool)
            {
                Table personId = (Table)_object;
            }
            return 0;
        }
        catch (InvalidCastException e) { 
            return -1;
        }
    }
}

public class Object
{
    string material;
    public string Material { get; set; }
}

public class Table : Object
{
    string shape;
    public string Shape { get; set; }
}