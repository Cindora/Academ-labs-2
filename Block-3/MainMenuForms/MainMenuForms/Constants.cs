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

        public static int[][] Recipes =
        {
            new []{ (int)Food.Milk, 400, (int)Food.Rice, 150}, //Milk Porridge
            new []{ (int)Food.Meat, 530, (int)Food.Potato, 240, (int)Food.Carrot, 110 }, //Goulash
            new []{ (int)Food.Noodles, 270, (int)Food.Cheese, 30 }, //Pasta
            new []{ (int)Food.Meat, 160, (int)Food.Eggs, 60 }, //Bacon_and_Eggs
            new []{ (int)Food.Seafood, 400, (int)Food.Onion, 100} //Seafood_Gumbo
        };
    }
}
