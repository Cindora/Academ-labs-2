using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static MainMenuForms.Constants;

namespace MainMenuForms
{
    public partial class AddDish : Form
    {
        List<Product> ProductList;
        List<Dish> DishList;
        public AddDish(List<Product> ProductList, List<Dish> DishList)
        {
            this.ProductList = ProductList;
            this.DishList = DishList;
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string DishName = textBox1.Text;

                if (DishName.Length < 1)
                    throw new ArgumentException();
               
                string[] recipe = textBox2.Text.Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);

                if (recipe.Length / 2 == 0)
                    throw new ArgumentException();

                int[] Recipe = new int[recipe.Length];
                for (int i = 0; i < recipe.Length / 2; ++i)
                {
                    Recipe[i * 2] = int.Parse(recipe[i * 2]) - 1;
                    Recipe[i * 2 + 1] = int.Parse(recipe[i * 2 + 1]);
                    if (Recipe[i * 2 + 1] <= 0)
                        continue;
                    if (Recipe[i * 2] < 0 || Recipe[i * 2] > Food_Names.Length - 1)
                        throw new ArgumentException();
                }
                

                var tmp = new Dish(DishName, Recipe);

                if (tmp != null)
                {
                    DishList.Add(tmp);
                    label6.Text = "Блюдо успешно добавлено.";
                    textBox1.Text = "";
                    textBox2.Text = "";
                }
                    
                else
                    label6.Text = "Вы ввели некорректные данные.";
            }
            catch (Exception exc)
            {
                label6.Text="Вы ввели некорректные данные.";
            }
        }

        private void AddProduct_Load(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            DishesMenu DishMenu = new DishesMenu(ProductList, DishList);
            DishMenu.FormClosed += (s, args) => this.Close();
            DishMenu.Show();
            DishMenu.Focus();
        }
    }
}
