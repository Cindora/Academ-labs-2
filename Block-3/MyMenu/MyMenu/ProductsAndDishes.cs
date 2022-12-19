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
        public int ID;
        public int Weight;
        public Constants.TimesOfDay[] TimesOfDay;
        public Dish(string Name, int ID, Product[] Food, Constants.TimesOfDay[] TimesOfDay)
        {
            this.Name = Name;
            this.ID = ID;
            this.TimesOfDay = new Constants.TimesOfDay[TimesOfDay.Length];
            for (int i = 0; i<TimesOfDay.Length; i++)
            {
                this.TimesOfDay[i] = TimesOfDay[i];
            }
        }
    }
}
