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
    public partial class ChangeProduct : Form
    {
        List<Product> ProductList;
        List<Dish> DishList;
        public ChangeProduct(List<Product> ProductList, List<Dish> DishList)
        {
            this.ProductList = ProductList;
            this.DishList = DishList;
            InitializeComponent();
            dishListLabel.Text = Program.DisplayProducts(ProductList);
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void ChangeProduct_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                int ID = int.Parse(textBox1.Text);
                int Weight = int.Parse(textBox2.Text);
                if (Weight <= 0)
                    ProductList.RemoveAt(ID - 1);
                else
                    ProductList[ID - 1].Weight = Weight;

                dishListLabel.Text = Program.DisplayProducts(ProductList);
                textBox1.Text = "";
                textBox2.Text = "";
                commandResult.Text = "Продукт успешно изменён.";
            }
            catch
            {
                commandResult.Text = "Вы ввели некорректные данные.";
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            ProductsMenu ProdMenu = new ProductsMenu(ProductList, DishList);
            ProdMenu.FormClosed += (s, args) => this.Close();
            ProdMenu.Show();
            ProdMenu.Focus();
        }
    }
}
