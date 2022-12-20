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
            Console.SetCursorPosition(WindowWidth / 2 - MenuStr[0][Line_Number].Length / 2 + 1, Line_Number);
            Console.WriteLine(MenuStr[0][Line_Number]);
        }
        static void SecondHead(int ID)
        {
            Line_Number = 2;
            Console.SetCursorPosition(WindowWidth / 2 - MenuStr[ID][0].Length / 2, Line_Number);
            Console.Write(MenuStr[ID][0]);

            Line_Number += 2;
            Console.SetCursorPosition(WindowWidth / 2 - MenuStr[1][1].Length / 2, Line_Number);
            Console.Write(MenuStr[ID][1]);
            Line_Number += 2;
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

            SecondHead(1);

            for (int i = 2; i < 5; i++)
            {
                Console.SetCursorPosition(cursor_X, Line_Number++);
                Console.Write($"{i - 1}: {MenuStr[1][i]}.");
            }
            Footer();

            ConsoleKey cur_key;
            do
            {
                cur_key = Console.ReadKey().Key;
                switch (cur_key)
                {
                    case ConsoleKey.D1:
                        return MainMenuChoise.Products_View;
                    case ConsoleKey.D2:
                        return MainMenuChoise.Dishes_View;
                    case ConsoleKey.D3:
                        return MainMenuChoise.Fast_Day_Menu;
                    case ConsoleKey.Escape:
                        break;
                    default:
                        Footer();
                        break;
                }
            } while (cur_key != ConsoleKey.Escape);
            return MainMenuChoise.NULL;
        }

        public static ProductsMenuChoise ProductsMenu(List<Product> ProductList)
        {
            Header();

            SecondHead(2);


            for (int i = 2; i < 4; i++)
            {
                Console.SetCursorPosition(cursor_X, Line_Number++);
                Console.Write($"{i - 1}: {MenuStr[2][i]}.");
            }

            Console.SetCursorPosition(cursor_X, ++Line_Number);
            Console.Write(MenuStr[2][MenuStr[2].Length - 1]);

            DisplayProducts(ProductList);

            Footer();

            ConsoleKey cur_key;
            do
            {
                cur_key = Console.ReadKey().Key;
                switch (cur_key)
                {
                    case ConsoleKey.D1:
                        return ProductsMenuChoise.AddProduct;
                    case ConsoleKey.D2:
                        return ProductsMenuChoise.DelProduct;
                    case ConsoleKey.Escape:
                        break;
                    default:
                        Footer();
                        break;
                }
            } while (cur_key != ConsoleKey.Escape);
            return ProductsMenuChoise.NULL;
        }

        public static int GetProductID()
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
                    case ConsoleKey.D5:
                    case ConsoleKey.D6:
                    case ConsoleKey.D7:
                    case ConsoleKey.D8:
                    case ConsoleKey.D9:
                        return (int)cur_key - 49; ;
                    case ConsoleKey.Escape:
                        break;
                    default:
                        Footer();
                        break;
                }
            } while (cur_key != ConsoleKey.Escape);
            return -1;
        }


        public static Product GetProductData()
        {
            Header();

            SecondHead(3);

            Footer();
            try
            {
                Console.SetCursorPosition(cursor_X, Line_Number++);
                Console.Write(MenuStr[3][2]);
                string ProductName = Console.ReadLine();
                if (ProductName.Length < 1)
                    throw new ArgumentException();

                Console.SetCursorPosition(cursor_X, Line_Number++);
                Console.Write(MenuStr[3][3]);
                Console.SetCursorPosition(0, Line_Number++);
                for (int i = 0; i < Food_Names.Length; i++)
                {
                    Console.Write($"{i + 1}: {Food_Names[i]} | ");
                }
                int ProductID = int.Parse(Console.ReadLine()) - 1;
                if (ProductID < 0 || ProductID > 9)
                    throw new ArgumentException();

                Console.SetCursorPosition(cursor_X, Line_Number++);
                Console.Write(MenuStr[3][4]);
                int ProductWeight = int.Parse(Console.ReadLine());
                if (ProductWeight <= 0)
                    throw new ArgumentException();


                return new Product(ProductName, ProductID, ProductWeight);
            }
            catch (Exception e)
            {
                Console.WriteLine("Вы ввели некорректные данные.");
                PressAnyButton();
                return null;
            }
        }

        public static void DisplayProducts(List<Product> ProductList)
        {
            foreach (Product product in ProductList)
            {
                Console.SetCursorPosition(cursor_X, ++Line_Number);
                Console.Write($"{product.Name} ({Food_Names[product.ID]}), кол-во: {product.Weight}");
            }
        }
    }
}
