using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using static MainMenuForms.Constants;

namespace MainMenuForms
{
    class Program
    {
        static void Main()
        {
            var ProductList = new List<Product>();

            ProductList.Add(new Product("Молоко «Эконива»", 0, 200));
            ProductList.Add(new Product("Свинина «Мираторг»", 2, 50));
            ProductList.Add(new Product("Сыр «Добров»", 1, 45));
            ProductList.Add(new Product("Картофель «Беларусь»", 5, 970));
            ProductList.Add(new Product("Морковь «Фруктовощи»", 7, 700));
            ProductList.Add(new Product("Курица «Петровская птицефабрика»", 2, 530));
            ProductList.Add(new Product("Яйца «Петровская птицефабрика»", 4, 150));
            ProductList.Add(new Product("Макароны «Хлебный дом»", 9, 450));
            ProductList.Add(new Product("Рис «Мистраль»", 8, 800));


            var DishList = new List<Dish>();
            DishList.Add(new Dish("Молочная каша", Constants.Recipes[0]));
            DishList.Add(new Dish("Гуляш", Constants.Recipes[1]));
            DishList.Add(new Dish("Паста", Constants.Recipes[2]));
            DishList.Add(new Dish("Яйца с беконом", Constants.Recipes[3]));
            DishList.Add(new Dish("Гамбо", Constants.Recipes[4]));


            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainMenu(ProductList, DishList));
        }

        public static string DisplayProducts(List<Product> ProductList)
        {
            string output = "";
            int i = 1;
            foreach (Product product in ProductList)
            {
                output += $"{i++} | {product.Name} ({Food_Names[product.ID]}), кол-во: {product.Weight}\n";
            }
            return output;
        }

        public static string DisplayDishes(List<Dish> DishList)
        {
            string output = "";
            int i = 1;
            foreach (Dish dish in DishList)
            {
                output += $"{i++} | {dish.Name}, вес порции: {dish.Weight};   ";
                if (i % 2 != 0)
                    output += '\n';
            }
            return output;
        }

        public static void ViewAvailableDishes(List<Dish> DishList, List<Product> ProductList)
        {
            if (ProductList.Any())
            {
                int j = 1;
                bool isAvail;

                foreach (Dish dish in DishList)
                {
                    var tmpRecipe = dish.ShowRecipe();

                    for (int i = 0; i < tmpRecipe.Length / 2; i++)
                    {
                        tmpRecipe[i * 2 + 1] -= ProductList[0].Print_Total_Weight_By_ID(tmpRecipe[i * 2]);
                    }

                    isAvail = true;
                    for (int k = 0; k < tmpRecipe.Length / 2; k++)
                    {
                        if (tmpRecipe[k * 2 + 1] > 0)
                        {
                            isAvail = false;
                            break;
                        }
                    }

                    if (isAvail)
                    {
                        
                        Console.Write($"{j++} | {dish.Name}, общий вес порции: {dish.Weight}");
                    }
                }
            }
        }

        public static void FastDayMenu(List<Dish> DishList, List<Product> ProductList)
        {
            if (ProductList.Any())
            {
                int j = 1;
                int DayDishesWeight = 0;
                bool isAvail;

                foreach (Dish dish in DishList)
                {
                    var tmpRecipe = dish.ShowRecipe();

                    isAvail = true;
                    for (int i = 0; i < tmpRecipe.Length / 2; i++)
                    {
                        tmpRecipe[i * 2 + 1] -= ProductList[0].Print_Total_Weight_By_ID(tmpRecipe[i * 2]);

                        if (tmpRecipe[i * 2 + 1] > 0)
                        {
                            isAvail = false;
                            break;
                        }
                    }


                    if (isAvail)
                    {
                        
                        Console.Write($"{j++} | {dish.Name}.");
                        DayDishesWeight += dish.Weight;

                        if (DayDishesWeight >= 1000)
                        {
                            
                            Console.Write($" Общий вес блюд: {DayDishesWeight}.");
                            break;
                        }
                    }
                }
                if (DayDishesWeight < 1000)
                {
                    
                    Console.Write("Не удалось составить полноценное меню.");
                    
                    Console.Write("Добавьте больше продуктов в хранилище и попробуйте снова.");
                }
            }

        }

        public static void DisplayDishRecipe(Dish dish)
        {
            for (int i = 0; i < dish.ShowRecipe().Length / 2; i++)
            {
                Console.Write($"  - {Food_Names[dish.ShowRecipe()[i * 2]]} - {dish.ShowRecipe()[i * 2 + 1]}");
            }
           
        }

        public static void RemoveDishes(List<Dish> DishList)
        {
            try
            {

               
                DisplayDishes(DishList);

                Console.Write(MenuStr[8][2]);

                int ID = int.Parse(Console.ReadLine());


                DishList.RemoveAt(ID - 1);
            }
            catch
            {
                Console.WriteLine("Вы ввели некорректные данные.");
            }
        }
    }

    
}
