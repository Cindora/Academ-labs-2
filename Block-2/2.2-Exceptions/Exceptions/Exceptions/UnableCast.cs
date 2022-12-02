using System;

namespace Exceptions;

public class UnableCast
{
    public void _UnableCast()
    {
        try
        {
            Object _object = new Object();
            Table personId = (Table)_object;
        }
        catch (Exception e) { Console.WriteLine(e.Message); }
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