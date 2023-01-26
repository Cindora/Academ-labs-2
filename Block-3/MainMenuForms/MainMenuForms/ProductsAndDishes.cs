using MainMenuForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MainMenuForms
{
    public class Product
    {
        public string Name;
        public int ID;
        public int Weight;
        public static int[] Total_Weight = new int[50];

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

        public void Minus_Total_Weight_By_ID(int ID, int WeightChange)
        {
            Total_Weight[ID] -= WeightChange;
            if (Total_Weight[ID] < 0)
                Total_Weight[ID] = 0;
        }
    }

    public class Dish
    {
        public string Name;
        public int Weight;
        private int[] Recipe;

        public Dish(string Name, int[] Recipe)
        {
            this.Name = Name;
            for (int i = 0; i < Recipe.Length / 2; i++)
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
