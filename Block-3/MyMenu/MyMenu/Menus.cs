using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static MyMenu.Constants;

namespace MyMenu
{
    class Menus
    {
        static void Header()
        {
            Line_Number = 0;
            Console.Clear();
            Console.SetCursorPosition(WindowWidth / 3, Line_Number);
            for (int i = 0; i < WindowWidth / 3; i++)
            {
                Console.Write("_");
            }
            Console.SetCursorPosition(WindowWidth / 2 - MenuStr[0].Length / 2, Line_Number);
            Console.WriteLine(MenuStr[Line_Number]);
        }
        public static void Footer()
        {
            Console.SetCursorPosition(0, WindowHeight - 1);
            Console.Write("ESC чтобы вернуться. ");
            Console.SetCursorPosition(20, WindowHeight - 1);
        }

        public static void PressAnyButton()
        {
            Console.SetCursorPosition(0, WindowHeight - 2);
            Console.Write("Для продолжения нажмите любую кнопку. ");
            Console.ReadKey();
        }

        public static MainMenuChoise MainMenu()
        {
            Header();
            Console.SetCursorPosition(WindowWidth / 2 - MenuStr[1].Length / 2, 2);
            Console.WriteLine(MenuStr[1]);
            Console.SetCursorPosition(WindowWidth / 2 - MenuStr[3].Length / 2, 4);
            Console.WriteLine(MenuStr[3]);
            for (int i = 4; i < 7; i++)
            {
                Console.SetCursorPosition(WindowWidth / 2 - 14, 1 + i);
                Console.WriteLine($"{i - 3}: {MenuStr[i]}.");
            }
            Footer();

            ConsoleKey cur_key;
            do
            {
                cur_key = Console.ReadKey().Key;
                switch (cur_key)
                {
                    case ConsoleKey.D1:
                        return Constants.MainMenuChoise.Products_View;
                    case ConsoleKey.D2:
                        return Constants.MainMenuChoise.Dishes_View;
                    case ConsoleKey.D3:
                        return Constants.MainMenuChoise.Fast_Day_Menu;
                    case ConsoleKey.Escape:
                        break;
                    default:
                        Footer();
                        break;
                }
            } while (cur_key != ConsoleKey.Escape);
            return Constants.MainMenuChoise.NULL;
        }

        
    }
}
