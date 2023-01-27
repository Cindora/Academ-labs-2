using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace MainMenuForms
{
    public partial class MainMenu : Form
    {
        List<Product> ProductList;
        List<Dish> DishList;
        public MainMenu(List<Product> ProductList, List<Dish> DishList)
        {
            this.ProductList = ProductList;
            this.DishList = DishList;
            InitializeComponent(); 
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void MainMenu_Load(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            ProductsMenu ProdMenu = new ProductsMenu(ProductList, DishList);
            ProdMenu.FormClosed += (s, args) => this.Close();
            ProdMenu.Show();
            ProdMenu.Focus();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            DishesMenu DishMenu = new DishesMenu(ProductList, DishList);
            DishMenu.FormClosed += (s, args) => this.Close();
            DishMenu.Show();
            DishMenu.Focus();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            FastDayMenu FastMenu = new FastDayMenu(ProductList, DishList);
            FastMenu.FormClosed += (s, args) => this.Close();
            FastMenu.Show();
            FastMenu.Focus();
        }

        
    }
}
