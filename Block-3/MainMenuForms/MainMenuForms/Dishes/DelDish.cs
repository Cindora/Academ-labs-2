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
    public partial class DelDish : Form
    {
        List<Product> ProductList;
        List<Dish> DishList;
        public DelDish(List<Product> ProductList, List<Dish> DishList)
        {
            this.ProductList = ProductList;
            this.DishList = DishList;
            InitializeComponent();
            dishListLabel.Text = Program.DisplayDishes(DishList);
        }

        private void DelDish_Load(object sender, EventArgs e)
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

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                int ID = int.Parse(textBox1.Text);

                DishList.RemoveAt(ID - 1);

                dishListLabel.Text = Program.DisplayDishes(DishList);
                textBox1.Text = "";
                commandResult.Text = "Блюдо успешно удалено.";
            }
            catch
            {
                commandResult.Text = "Вы ввели некорректные данные.";
            }
        }
    }
}
