using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static MyMenu.Constants;

namespace MyMenu
{
    class App
    {
        static void Main(string[] args)
        {
            MenuLevel MenuLevel = MenuLevel.GameType;
            do
            {
                if (MenuLevel == MenuLevel.GameType)
                {
                    Menus.MainMenu();
                    MenuLevel = MenuLevel.NULL;
                }
            } while (MenuLevel != MenuLevel.NULL);
        }
    }
}
