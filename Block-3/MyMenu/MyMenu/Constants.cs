using System.Collections.Generic;

namespace MyMenu
{
    public static class Constants
    {
        public enum Food
        {
            Milk, Cheese, Meat, Seafood, Eggs, Potato, Onion, Carrot, Rice, Noodles
        };

        public static string[] Food_Names = { "Milk", "Cheese", "Meat", "Seafood", "Eggs",
            "Potato", "Onion", "Carrot", "Rice", "Noodles" };

        public enum Meals
        {
            Milk_Porridge, Goulash, Pasta, Salad, Bacon_and_Eggs, Seafood_Gumbo
        };

        public static string[] Meals_Names = { "Milk Porridge", "Goulash", "Pasta", "Salad", "Bacon and Eggs", "Seafood Gumbo" };

        public static int[][] Recipes =
        {
            new []{ (int)Meals.Milk_Porridge, (int)Food.Milk, 1000, (int)Food.Rice, 500 },
            new []{ (int)Meals.Goulash, (int)Food.Meat, 1100, (int)Food.Potato, 800, (int)Food.Carrot, 200 },
            new []{ (int)Meals.Pasta, (int)Food.Noodles, 400, (int)Food.Cheese, 50 },
            new []{ (int)Meals.Bacon_and_Eggs, (int)Food.Meat, 200, (int)Food.Eggs, 4 },
            new []{ (int)Meals.Seafood_Gumbo, (int)Food.Seafood, 1000, (int)Food.Onion, 300 }
        };


        public static string[][] MenuStr = { new string[] { "Моё меню" },
            new string[] {"Главная страница", "Выберите желаемое действие:", "Открыть хранилище продуктов", "Показать рецепты блюд","Составить быстрое меню на день" },
            new string[]{ "Хранилище продуктов", "Выберите желаемое действие:", "Добавить продукт в хранилище", "Удалить продукт из хранилища", "Текущее хранилище:"},
            new string[] { "Хранилище продуктов", "Введите данные продукта:", "Название: ", "Тип: ", "Вес(Объём/количество): ", }
        };

        public enum MainMenuChoise { Products_View, Dishes_View, Fast_Day_Menu, NULL };
        public enum ProductsMenuChoise { AddProduct, DelProduct, NULL };

        public enum TimesOfDay { Breakfast, Lunch, Dinner };

        public enum MenuLevel { NULL, GameType, ClassesDescriptions, HeroesPick };

        public static int WindowWidth = Console.WindowWidth;

        public static int WindowHeight = Console.WindowHeight;

        public static ushort Line_Number;

        public static int Healing_Amount = 15;
    }
}
