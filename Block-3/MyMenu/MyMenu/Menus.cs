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
            Console.SetCursorPosition(WindowWidth / 2 - MenuStr[ID][1].Length / 2, Line_Number);
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

        public static MenuLevel MainMenu()
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
                        return MenuLevel.ProductsMenu;
                    case ConsoleKey.D2:
                        return MenuLevel.DishesMenu;
                    case ConsoleKey.D3:
                        return MenuLevel.Fast_Day_Menu;
                    case ConsoleKey.Escape:
                        break;
                    default:
                        Footer();
                        break;
                }
            } while (cur_key != ConsoleKey.Escape);
            return MenuLevel.NULL;
        }

        public static ProductsMenuChoise ProductsMenu(List<Product> ProductList)
        {
            Header();

            SecondHead(2);


            for (int i = 2; i < 5; i++)
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
                        return ProductsMenuChoise.ChangeProduct;
                    case ConsoleKey.D3:
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
            try
            {
                Header();

                SecondHead(3);

                Footer();

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

        public static void ChangeProduct(List<Product> ProductList)
        {
            try
            {
                Header();

                SecondHead(5);

                Footer();

                Line_Number++;
                DisplayProducts(ProductList);

                Line_Number = 6;
                Console.SetCursorPosition(cursor_X, Line_Number++);
                Console.Write(MenuStr[5][2]);
                
                string[] str = Console.ReadLine().Split(new char[] { ' ', ','}, StringSplitOptions.RemoveEmptyEntries);

                int ID = int.Parse(str[0]);
                int Weight = int.Parse(str[1]);
                if (Weight <= 0)
                    ProductList.RemoveAt(ID - 1);
                else
                    ProductList[ID - 1].Weight = Weight;
            }
            catch
            {
                Console.WriteLine("Вы ввели некорректные данные.");
                PressAnyButton();
            }
        }

        public static void RemoveProduct(List<Product> ProductList)
        {
            try
            {
                Header();

                SecondHead(4);

                Footer();

                Line_Number++;
                DisplayProducts(ProductList);

                Line_Number = 6;
                Console.SetCursorPosition(cursor_X, Line_Number++);
                Console.Write(MenuStr[4][2]);

                int ID = int.Parse(Console.ReadLine());
                
                
                ProductList.RemoveAt(ID-1);
            }
            catch
            {
                Console.WriteLine("Вы ввели некорректные данные.");
                PressAnyButton();
            }
        }

        public static void DisplayProducts(List<Product> ProductList)
        {
            int i = 1;
            foreach (Product product in ProductList)
            {
                Console.SetCursorPosition(cursor_X, ++Line_Number);
                Console.Write($"{i++} | {product.Name} ({Food_Names[product.ID]}), кол-во: {product.Weight}");
            }
        }

        public static DishesMenuChoise DishesMenu(List<Dish> DishList)
        {
            Header();

            SecondHead(6);


            for (int i = 2; i < 5; i++)
            {
                Console.SetCursorPosition(cursor_X, Line_Number++);
                Console.Write($"{i - 1}: {MenuStr[6][i]}.");
            }

            Console.SetCursorPosition(cursor_X, ++Line_Number);
            Console.Write(MenuStr[6][MenuStr[6].Length - 1]);

            DisplayDishes(DishList, false);

            Footer();

            ConsoleKey cur_key;
            do
            {
                cur_key = Console.ReadKey().Key;
                switch (cur_key)
                {
                    case ConsoleKey.D1:
                        return DishesMenuChoise.AddDish;
                    case ConsoleKey.D2:
                        return DishesMenuChoise.DelDish;
                    case ConsoleKey.D3:
                        return DishesMenuChoise.ViewAvailableDishes;
                    case ConsoleKey.Escape:
                        break;
                    default:
                        Footer();
                        break;
                }
            } while (cur_key != ConsoleKey.Escape);
            return DishesMenuChoise.NULL;
        }

        public static Dish GetDishData()
        {
            try
            {
                Header();

                SecondHead(7);

                Footer();

                Console.SetCursorPosition(cursor_X, Line_Number++);
                Console.Write(MenuStr[7][2]);
                string DishName = Console.ReadLine();
                if (DishName.Length < 1)
                    throw new ArgumentException();
                Line_Number += 2;
                Console.SetCursorPosition(0, Line_Number);
                for (int i = 0; i < Food_Names.Length; i++)
                {
                    Console.Write($"{i + 1}: {Food_Names[i]} | ");
                }
                Line_Number -= 2;
                Console.SetCursorPosition(cursor_X, Line_Number);
                Console.Write(MenuStr[7][3]);

                string[] recipe = Console.ReadLine().Split(new char[] { ' ', ','}, StringSplitOptions.RemoveEmptyEntries);

                if (recipe.Length / 2 == 0)
                    throw new ArgumentException();

                int[] Recipe = new int[recipe.Length];
                for (int i = 0; i < recipe.Length/2; ++i)
                {
                    Recipe[i*2] = int.Parse(recipe[i*2]) - 1;
                    Recipe[i*2+1] = int.Parse(recipe[i*2+1]);
                    if (Recipe[i * 2 + 1] <= 0)
                        continue;
                    if (Recipe[i * 2] < 0 || Recipe[i * 2] > Food_Names.Length - 1)
                        throw new ArgumentException();
                }
                
                return new Dish(DishName, Recipe);
            }
            catch (Exception e)
            {
                Console.WriteLine("Вы ввели некорректные данные.");
                PressAnyButton();
                return null;
            }
        }

        public static void DisplayDishes(List<Dish> DishList, bool DisplayRecipes)
        {
            int i = 1;
            foreach (Dish dish in DishList)
            {
                Console.SetCursorPosition(cursor_X, ++Line_Number);
                Console.Write($"{i++} | {dish.Name}, общий вес порции: {dish.Weight}");
                if (DisplayRecipes)
                    DisplayDishRecipe(dish);

            }
        }

        public static void DisplayDishRecipe(Dish dish)
        {
                for (int i = 0; i < dish.ShowRecipe().Length / 2; i++)
                {
                    Console.SetCursorPosition(cursor_X, ++Line_Number);
                    Console.Write($"  - {Food_Names[dish.ShowRecipe()[i * 2]]} - {dish.ShowRecipe()[i * 2 + 1]}");
                }
                Line_Number++;
        }

        public static void RemoveDishes(List<Dish> DishList)
        {
            try
            {
                Header();

                SecondHead(8);

                Footer();

                Line_Number++;
                DisplayDishes(DishList, false);

                Line_Number = 6;
                Console.SetCursorPosition(cursor_X, Line_Number++);
                Console.Write(MenuStr[8][2]);

                int ID = int.Parse(Console.ReadLine());


                DishList.RemoveAt(ID - 1);
            }
            catch
            {
                Console.WriteLine("Вы ввели некорректные данные.");
                PressAnyButton();
            }
        }
    }
}
