using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static GameCore.Constants;

namespace GameCore
{
    class App
    {
        
        static void Main(string[] args)
        {
            string key;
            do
            {
                Menus.Menu();
                key = Menus.Descriptions();
                Console.ReadKey();
            } while (key != "Escape");
        }
    }
}
