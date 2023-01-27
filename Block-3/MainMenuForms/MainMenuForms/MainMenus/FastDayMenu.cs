using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace MainMenuForms
{
    public partial class FastDayMenu : Form
    {
        List<Product> ProductList;
        List<Dish> DishList;
        public FastDayMenu(List<Product> ProductList, List<Dish> DishList)
        {
            this.ProductList = ProductList;
            this.DishList = DishList;
            InitializeComponent();

            string output = "";

            if (ProductList.Any())
            {
                int j = 1;
                int DayDishesWeight = 0;
                bool isAvail;

                foreach (Dish dish in DishList)
                {
                    var tmpRecipe = dish.ShowRecipe();

                    isAvail = true;
                    for (int i = 0; i < tmpRecipe.Length / 2; i++)
                    {
                        tmpRecipe[i * 2 + 1] -= ProductList[0].Print_Total_Weight_By_ID(tmpRecipe[i * 2]);

                        if (tmpRecipe[i * 2 + 1] > 0)
                        {
                            isAvail = false;
                            break;
                        }
                    }

                    if (isAvail)
                    {
                        output+=$"{j++} | {dish.Name}.\n";
                        DayDishesWeight += dish.Weight;

                        if (DayDishesWeight >= 1000)
                        {
                            output+=$" Общий вес блюд: {DayDishesWeight}.";
                            break;
                        }
                    }
                }
                if (DayDishesWeight < 1000)
                {
                    output = "Не удалось составить полноценное меню.\n" +
                        "Добавьте больше продуктов в хранилище и\n" +
                        "попробуйте снова.";
                }
            }
            else
            {
                output = "Не удалось составить полноценное меню.\n" +
                        "Добавьте больше продуктов в хранилище и\n" +
                        "попробуйте снова.";
            }

            dishListLabel.Text = output;
        }
        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            MainMenu Main = new MainMenu(ProductList, DishList);
            Main.FormClosed += (s, args) => this.Close();
            Main.Show();
            Main.Focus();
        }

        private void FastDayMenu_Load(object sender, EventArgs e)
        {

        }

        private void dishListLabel_Click(object sender, EventArgs e)
        {

        }
    }
}
