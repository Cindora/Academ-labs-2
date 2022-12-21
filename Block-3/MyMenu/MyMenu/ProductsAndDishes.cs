using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MyMenu
{
    public class Product
    {
        public string Name;
        public int ID;
        public int Weight;
        public static int[] Total_Weight = new int[Enum.GetNames(typeof(Constants.Food)).Length];
        
        public Product(string Name, int ID, int Weight)
        {
            this.Name = Name;
            this.ID = ID;
            this.Weight = Weight;
            Total_Weight[ID] += Weight;
        }

        public int Print_Total_Weight_By_ID(int ID)
        {
            return Total_Weight[ID];
        }
    }

    public class Dish
    {
        public string Name;
        public int Weight;
        private int[] Recipe;

        public Dish(string Name,  int[] Recipe)
        {
            this.Name = Name;
            for (int i = 0; i<Recipe.Length/2; i++)
            {
                Weight += Recipe[i * 2 + 1];
            }
            this.Recipe = Recipe;
        }
        public int[] ShowRecipe()
        {
            return Recipe;
        }
    }
}
