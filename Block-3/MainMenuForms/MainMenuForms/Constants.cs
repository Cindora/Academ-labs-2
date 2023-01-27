namespace MainMenuForms
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
            new []{ (int)Food.Milk, 400, (int)Food.Rice, 150}, //Milk Porridge
            new []{ (int)Food.Meat, 530, (int)Food.Potato, 240, (int)Food.Carrot, 110 }, //Goulash
            new []{ (int)Food.Noodles, 270, (int)Food.Cheese, 30 }, //Pasta
            new []{ (int)Food.Meat, 160, (int)Food.Eggs, 60 }, //Bacon_and_Eggs
            new []{ (int)Food.Seafood, 400, (int)Food.Onion, 100} //Seafood_Gumbo
        };


        public static string[][] MenuStr = { new string[] { "Моё меню" },
            new string[] {"Главная страница", "Выберите желаемое действие:", "Открыть хранилище продуктов", "Показать блюда и рецепты","Составить быстрое меню на день" },
            new string[]{ "Хранилище продуктов", "Выберите желаемое действие:", "Добавить продукт", "Изменить вес продукта", "Удалить продукт", "Текущее хранилище:"},
            new string[] { "Хранилище продуктов", "Ввод информации о продукте:", "Название: ", "Тип: ", "Вес(Объём/количество): ", },
            new string[] { "Хранилище продуктов", "Удаление продукта", "Укажите номер продукта: " },
            new string[] { "Хранилище продуктов", "Изменение продукта", "Укажите номер продукта и его новый вес(X, Y): " },
            new string[]{ "Блюда и рецепты", "Выберите желаемое действие:", "Добавить рецепт", "Удалить рецепт", "Показать доступные блюда", "База рецептов:" },
            new string[] { "Блюда и рецепты", "Введите рецепт блюда", "Название: ", "Рецепт(Продукты, их количество): ", },
            new string[] { "Блюда и рецепты", "Удаление рецепта блюда", "Укажите номер рецепта: " },
            new string[] { "Блюда и рецепты", "Доступные для приготовления блюда"},
            new string[] { "Быстрое меню", "Блюда на день:"}
        };

        public enum ProductsMenuChoise { AddProduct, ChangeProduct, DelProduct, NULL };

        public enum DishesMenuChoise { AddDish, DelDish, ViewAvailableDishes, NULL };

        public enum TimesOfDay { Breakfast, Lunch, Dinner };

        public enum MenuLevel { NULL, MainMenu, ProductsMenu, DishesMenu, Fast_Day_Menu };
    }
}
