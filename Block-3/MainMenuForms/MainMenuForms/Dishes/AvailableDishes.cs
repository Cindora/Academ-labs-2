using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace MainMenuForms
{
    public partial class AvailableDishes : Form
    {
        List<Product> ProductList;
        List<Dish> DishList;
        public AvailableDishes(List<Product> ProductList, List<Dish> DishList)
        {
            this.ProductList = ProductList;
            this.DishList = DishList;
            InitializeComponent();
        }

        private void AvailableDishes_Load(object sender, EventArgs e)
        {
            string output = "";

            if (ProductList.Any())
            {
                int j = 1;
                bool isAvail;

                foreach (Dish dish in DishList)
                {
                    var tmpRecipe = dish.ShowRecipe();

                    for (int i = 0; i < tmpRecipe.Length / 2; i++)
                    {
                        tmpRecipe[i * 2 + 1] -= ProductList[0].Print_Total_Weight_By_ID(tmpRecipe[i * 2]);
                    }

                    isAvail = true;
                    for (int k = 0; k < tmpRecipe.Length / 2; k++)
                    {
                        if (tmpRecipe[k * 2 + 1] > 0)
                        {
                            isAvail = false;
                            break;
                        }
                    }

                    if (isAvail)
                    {
                        output += $"{j++} | {dish.Name}, общий вес порции: {dish.Weight}\n";
                    }
                }
            }

            dishListLabel.Text = output;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            DishesMenu DishMenu = new DishesMenu(ProductList, DishList);
            DishMenu.FormClosed += (s, args) => this.Close();
            DishMenu.Show();
            DishMenu.Focus();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
