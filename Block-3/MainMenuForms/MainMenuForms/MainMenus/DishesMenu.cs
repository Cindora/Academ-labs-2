using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MainMenuForms
{
    public partial class DishesMenu : Form
    {
        List<Product> ProductList;
        List<Dish> DishList;
        public DishesMenu(List<Product> ProductList, List<Dish> DishList)
        {
            this.ProductList = ProductList;
            this.DishList = DishList;
            InitializeComponent();
            dishListLabel.Text = Program.DisplayDishes(DishList);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            MainMenu Main = new MainMenu(ProductList, DishList);
            Main.FormClosed += (s, args) => this.Close();
            Main.Show();
            Main.Focus();
        }

        private void DishesMenu_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            AddDish AddDish = new AddDish(ProductList, DishList);
            AddDish.FormClosed += (s, args) => this.Close();
            AddDish.Show();
            AddDish.Focus();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            DelDish DelDish = new DelDish(ProductList, DishList);
            DelDish.FormClosed += (s, args) => this.Close();
            DelDish.Show();
            DelDish.Focus();
        }

        private void dishListLabel_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            AvailableDishes AvailableDishes = new AvailableDishes(ProductList, DishList);
            AvailableDishes.FormClosed += (s, args) => this.Close();
            AvailableDishes.Show();
            AvailableDishes.Focus();
        }
    }
}
