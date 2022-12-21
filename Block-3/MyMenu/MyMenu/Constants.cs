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
            Milk_Porridge, Goulash, Pasta, Bacon_and_Eggs, Seafood_Gumbo
        };

        public static int[][] Recipes =
        {
            new []{ (int)Food.Milk, 1000, (int)Food.Rice, 500}, //Milk Porridge
            new []{ (int)Food.Meat, 1100, (int)Food.Potato, 800, (int)Food.Carrot, 200 }, //Goulash
            new []{ (int)Food.Noodles, 400, (int)Food.Cheese, 50 }, //Pasta
            new []{ (int)Food.Meat, 200, (int)Food.Eggs, 4 }, //Bacon_and_Eggs
            new []{ (int)Food.Seafood, 1000, (int)Food.Onion, 300} //Seafood_Gumbo
        };


        public static string[][] MenuStr = { new string[] { "Моё меню" },
            new string[] {"Главная страница", "Выберите желаемое действие:", "Открыть хранилище продуктов", "Показать блюда и рецепты","Составить быстрое меню на день" },
            new string[]{ "Хранилище продуктов", "Выберите желаемое действие:", "Добавить продукт", "Изменить вес продукта", "Удалить продукт", "Текущее хранилище:"},
            new string[] { "Хранилище продуктов", "Введите данные продукта:", "Название: ", "Тип: ", "Вес(Объём/количество): ", },
            new string[] { "Хранилище продуктов", "Удаление продукта", "Укажите номер продукта: " },
            new string[] { "Хранилище продуктов", "Изменение продукта", "Укажите номер продукта и его новый вес(X, Y): " },
            new string[]{ "Блюда и рецепты", "Выберите желаемое действие:", "Добавить рецепт", "Удалить рецепт", "Показать доступные блюда", "База рецептов:" },
            new string[] { "Блюда и рецепты", "Введите рецепт блюда:", "Название: ", "Рецепт(Продукты, их количество): ", },
            new string[] { "Блюда и рецепты", "Удаление рецепта блюда", "Укажите номер рецепта: " },
        };

        public enum ProductsMenuChoise { AddProduct, ChangeProduct, DelProduct, NULL };

        public enum DishesMenuChoise { AddDish, DelDish, ViewAvailableDishes, NULL };

        public enum TimesOfDay { Breakfast, Lunch, Dinner };

        public enum MenuLevel { NULL, MainMenu, ProductsMenu, DishesMenu, Fast_Day_Menu };

        public static int WindowWidth = Console.WindowWidth;

        public static int WindowHeight = Console.WindowHeight;

        public static ushort Line_Number;

        public static int Healing_Amount = 15;

        public static int cursor_X = WindowWidth / 2 - 14;
    }
}
