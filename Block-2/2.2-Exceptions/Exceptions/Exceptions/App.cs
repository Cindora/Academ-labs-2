using System;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;
using System.Security.Cryptography.X509Certificates;
using System.Security.Principal;
using Microsoft.VisualBasic;

namespace Exceptions
{
    class App
    {
        static void Main()
        {
            Console.WriteLine("1. Index out of range");
            var argument = new IndexOutOfRange();
            argument._IndexOutOfRange(2);

            Console.WriteLine("\n2. Divide by zero");
            var divide = new DivideByZero();
            divide._DivideByZero(2, 0);
            
            Console.WriteLine("\n3. Index Outside the Bounds");
            var index = new IndexOutsideTheBounds();
            index._IndexOutsideTheBounds(2);

            Console.WriteLine("\n4. Unable cast");
            var cast = new UnableCast();
            cast._UnableCast();

            Console.WriteLine("\n5. Value null");
            var valuenull = new ValueNull();
            valuenull._ValueNull();

            Console.WriteLine("\n6. Overflow");
            var overflow = new Overflow();
            overflow._Overflow();

            Console.WriteLine("\n7. Format");
            var format = new Format();
            format._Format("Hello!");
            
            Console.WriteLine("\n8. Incompatible Type");
            var type = new IncompatibleType();
            type._IncompatibleType();

            Console.WriteLine("\n9. Out Of Memory");
            var memory = new OutOfMemory();
            memory._OutOfMemory();


        }
    }
}