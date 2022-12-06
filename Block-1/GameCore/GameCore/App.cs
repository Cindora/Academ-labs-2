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
            MenuLevel MenuLevel = MenuLevel.GameType;
            do
            {
                if (MenuLevel == MenuLevel.GameType)
                {
                    if (Menus.GameType() != GameType.NULL)
                    {
                        MenuLevel = MenuLevel.ClassesDescriptions;
                    }
                    else
                    {
                        MenuLevel = MenuLevel.NULL;
                    }
                }

                if (MenuLevel == MenuLevel.ClassesDescriptions)
                {
                    key = Menus.ClassesDescriptions();
                    if (key != ConsoleKey.Escape)
                    {
                        //MenuLevel = MenuLevel.HeroesPick;
                        Menus.HeroesPick(key);
                    }
                    else
                    {
                        MenuLevel = MenuLevel.GameType;
                    }
                }
            } while (MenuLevel != MenuLevel.NULL);
            
        }
    }
}
