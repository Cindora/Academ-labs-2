using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static GameCore.Constants;

namespace GameCore
{
    class Menus
    {
        static void Header()
        {
            Line_Number = 0;
            Console.Clear();
            Console.SetCursorPosition(WindowWidth / 3, Line_Number);
            for (int i = 0;i<WindowWidth/3;i++)
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
        public static GameType GameType()
        {
            Header();
            Console.SetCursorPosition(WindowWidth / 2 - MenuStr[1].Length / 2, 2);
            Console.WriteLine(MenuStr[1]);
            Console.SetCursorPosition(WindowWidth / 2 - MenuStr[3].Length / 2, 4);
            Console.WriteLine(MenuStr[3]);
            for (int i = 4; i < 7; i++)
            {
                Console.SetCursorPosition(WindowWidth / 2 - 10, 1 + i);
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
                        return Constants.GameType.PvP;
                    case ConsoleKey.D2:
                        return Constants.GameType.PvE;
                    case ConsoleKey.D3:
                        return Constants.GameType.EvE;
                    case ConsoleKey.Escape:
                        break;
                    default:
                        Footer();
                        break;
                }
            } while (cur_key != ConsoleKey.Escape);
            return Constants.GameType.NULL;
        }

        public static ConsoleKey ClassesDescriptions()
        {
            Header();
            Console.SetCursorPosition(WindowWidth / 2 - MenuStr[2].Length / 2, 2);
            Console.WriteLine(MenuStr[2]);
            for (int i = 0; i < Constants.Classes.Length; i++)
            {
                Console.SetCursorPosition(WindowWidth / 2 - 6, 3 + i);
                Console.WriteLine($"{i + 1}: {Constants.Classes[i]}.");
            }
            Footer();

            ConsoleKey cur_key;
            do
            {
                cur_key = Console.ReadKey().Key;
                switch (cur_key)
                {
                    case ConsoleKey.D1:
                        Header();
                        Vanguard.description();
                        Footer();
                        return cur_key;
                    case ConsoleKey.D2:
                        Header();
                        Assassin.description();
                        Footer();
                        return cur_key;
                    case ConsoleKey.D3:
                        Header();
                        Heavy.description();
                        Footer();
                        return cur_key;
                    case ConsoleKey.D4:
                        Header();
                        Hybrid.description();
                        Footer();
                        return cur_key;
                    case ConsoleKey.Escape:
                        break;
                    default:
                        Footer();
                        break;
                }
            } while (cur_key != ConsoleKey.Escape);
            return cur_key;
        }

        public static int HeroesPick(ConsoleKey key)
        {
            ConsoleKey cur_key;
            do
            {
                cur_key = Console.ReadKey().Key;
                switch (cur_key)
                {
                    case ConsoleKey.D1:
                    case ConsoleKey.D2:
                    case ConsoleKey.D3:
                    case ConsoleKey.D4:
                        return 4 * ((int)key - 49) + (int)cur_key - 49; ;
                    case ConsoleKey.Escape:
                        break;
                    default:
                        Footer();
                        break;
                }
            } while (cur_key != ConsoleKey.Escape);
            return -1;
        }

        public static void DisplayStatus(Hero Hero1, Hero Hero2, int curr_Hero_ID)
        {
            Header();

            int divider = 10;
            int Divided_Width = WindowWidth / divider;
            Hero current_Hero;
            for (int i = 0; i < 2; i++)
            {
                Line_Number = 2;
                int current_width = Divided_Width * (i* divider/2 + 1);

                current_Hero = i == 0 ? Hero1 : Hero2;

                Console.SetCursorPosition(current_width, Line_Number++);

                Console.Write($"Игрок {i+1}");
                if (i == curr_Hero_ID)
                    Console.Write(" (Ваш ход)");

                Console.SetCursorPosition(current_width, Line_Number);
                string HealthDiff = current_Hero.PrevHealthPoints != current_Hero.HealthPoints ?
                    $"{current_Hero.PrevHealthPoints} -> " : "";
                Console.WriteLine($"{current_Hero.Name}, {HealthDiff}{current_Hero.HealthPoints} здоровья.");
                Line_Number += 2;
                Console.SetCursorPosition(current_width, Line_Number++);
                if (i == curr_Hero_ID)
                    Console.Write("1: ");
                Console.Write($"Атаковать ({current_Hero.DamagePoints} урона).");
                Console.SetCursorPosition(current_width, Line_Number);
                if (i == curr_Hero_ID)
                    Console.Write("2: ");
                Console.Write($"Залечить раны (+{Healing_Amount} здоровья).");
                
            }

            Footer();
        }

        public static void Duel_End_Screen(Hero Hero1, Hero Hero2)
        {
            Header();

            Hero current_Hero;
            string Result;


            if (Hero1.isAlive && !Hero2.isAlive)
                Result = "Игрок 1 одержал победу.";
            else if(!Hero1.isAlive && Hero2.isAlive)
                Result = "Игрок 2 одержал победу.";
            else
                Result = "Бой остановлен.";

            int divider = 10;
            int Divided_Width = WindowWidth / divider;
            Line_Number = 2;

            Console.SetCursorPosition(WindowWidth/2- Result.Length/2, Line_Number);
            Console.Write(Result);

            for (int i = 0; i < 2; i++)
            {
                Line_Number = 3;
                int current_width = Divided_Width * (i * divider / 2 + 1);

                current_Hero = i == 0 ? Hero1 : Hero2;

                Console.SetCursorPosition(current_width, Line_Number++);

                Console.Write($"Игрок {i + 1}");
                Console.SetCursorPosition(current_width, Line_Number);
                Console.Write($"{current_Hero.Name}, ");
                if (current_Hero.isAlive)
                    Console.Write($"{current_Hero.HealthPoints} здоровья.");
                else
                    Console.Write("мёртв.");
            }

            Footer();
            Console.ReadKey();
        }
    }
}
