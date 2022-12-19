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
        public DateTime ExpirationDate;
        
        public Product(string Name, int ID, int Weight, DateTime ExpirationDate)
        {
            this.Name = Name;
            this.ID = ID;
            this.Weight = Weight;
            Total_Weight[ID] += Weight;
            this.ExpirationDate = ExpirationDate;
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
        DateTime ExpirationDate;
        public Constants.TimesOfDay[] TimesOfDay;
        public Dish(string Name, int ID, Product[] Food, Constants.TimesOfDay[] TimesOfDay)
        {
            this.Name = Name;
            this.ID = ID;
            ExpirationDate = Food[0].ExpirationDate;
            foreach (var x in Food)
            {
                Weight += x.Weight;
                if  (ExpirationDate > x.ExpirationDate)
                    ExpirationDate = x.ExpirationDate;
            }
            this.TimesOfDay = new Constants.TimesOfDay[TimesOfDay.Length];
            for (int i = 0; i<TimesOfDay.Length; i++)
            {
                this.TimesOfDay[i] = TimesOfDay[i];
            }
        }
    }
}
