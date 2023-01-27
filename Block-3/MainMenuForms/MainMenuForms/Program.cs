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
    }
}
