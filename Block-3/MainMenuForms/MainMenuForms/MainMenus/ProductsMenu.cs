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
    public partial class ProductsMenu : Form
    {
        List<Product> ProductList;
        List<Dish> DishList;
        public ProductsMenu(List<Product> ProductList, List<Dish> DishList)
        {
            this.ProductList = ProductList;
            this.DishList = DishList;
            InitializeComponent();

            string output = "";
            int i = 1;
            foreach (Product product in ProductList)
            {
                output += $"{i++} | {product.Name} ({Food_Names[product.ID]}), кол-во: {product.Weight}\n";
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

        private void ProductsMenu_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            AddProduct AddProduct = new AddProduct(ProductList, DishList);
            AddProduct.FormClosed += (s, args) => this.Close();
            AddProduct.Show();
            AddProduct.Focus();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            ChangeProduct ChangeProduct = new ChangeProduct(ProductList, DishList);
            ChangeProduct.FormClosed += (s, args) => this.Close();
            ChangeProduct.Show();
            ChangeProduct.Focus();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            DelProduct DelProduct = new DelProduct(ProductList, DishList);
            DelProduct.FormClosed += (s, args) => this.Close();
            DelProduct.Show();
            DelProduct.Focus();
        }
    }
}
