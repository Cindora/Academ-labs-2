using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;
using static MyMenu.Constants;

namespace MyMenu
{
    class App
    {
        static void Main(string[] args)
        {
            MenuLevel MenuLevel = MenuLevel.MainMenu;
            
            var ProductList = new List<Product>();
            
            ProductList.Add(new Product("Молоко «Эконива»", 0, 1200));
            ProductList.Add(new Product("Свинина «Мираторг»", 2, 500));
            ProductList.Add(new Product("Молоко «Простоквашино»", 0, 970));
            ProductList.Add(new Product("Морковь «Фруктовощи»", 7, 700));
            ProductList.Add(new Product("Курица «Петровская птицефабрика»", 2, 500));

            var DishList = new List<Dish>();
            DishList.Add(new Dish("Молочная каша", Recipes[0]));
            DishList.Add(new Dish("Гуляш", Recipes[1]));
            DishList.Add(new Dish("Паста", Recipes[2]));
            DishList.Add(new Dish("Яйца с беконом", Recipes[3]));
            DishList.Add(new Dish("Гамбо из морепродуктов", Recipes[4]));

            do
            {
                if (MenuLevel == MenuLevel.MainMenu)
                {
                    MenuLevel = Menus.MainMenu();
                }

                if (MenuLevel == MenuLevel.ProductsMenu)
                {
                    switch (Menus.ProductsMenu(ProductList))
                    {
                        case ProductsMenuChoise.AddProduct:
                            var tmp = Menus.GetProductData();
                            if (tmp != null)
                                ProductList.Add(tmp);
                            break;
                        case ProductsMenuChoise.ChangeProduct:
                            Menus.ChangeProduct(ProductList);
                            break;
                        case ProductsMenuChoise.DelProduct:
                            Menus.RemoveProduct(ProductList);
                            break;
                        case ProductsMenuChoise.NULL:
                            MenuLevel = MenuLevel.MainMenu;
                            break;
                    }
                }
                else if (MenuLevel == MenuLevel.DishesMenu)
                {
                    switch (Menus.DishesMenu(DishList))
                    {
                        case DishesMenuChoise.AddDish:
                            var tmp = Menus.GetDishData();
                            if (tmp != null)
                                DishList.Add(tmp);
                            break;
                        case DishesMenuChoise.DelDish:
                            Menus.RemoveDishes(DishList);
                            break;
                        case DishesMenuChoise.ViewAvailableDishes:
                            
                            break;
                        case DishesMenuChoise.NULL:
                            MenuLevel = MenuLevel.MainMenu;
                            break;
                    }
                }
                else if (MenuLevel == MenuLevel.Fast_Day_Menu)
                {
                    MenuLevel = MenuLevel.MainMenu;
                }

            } while (MenuLevel != MenuLevel.NULL);
        }
    }
}
