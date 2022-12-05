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
            ConsoleKey key;
            int Is_Hero_Picked = -1;
            do
            {
                Menus.Menu();
                key = Menus.ClassesDescriptions();
                if (key!=ConsoleKey.Escape)
                {
                    Is_Hero_Picked = Menus.HeroesPick(key);
                }
                
            } while (key != ConsoleKey.Escape && Is_Hero_Picked == -1);
        }
    }
}
