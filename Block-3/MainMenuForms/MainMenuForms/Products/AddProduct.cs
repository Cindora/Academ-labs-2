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
    public partial class AddProduct : Form
    {
        List<Product> ProductList;
        List<Dish> DishList;
        public AddProduct(List<Product> ProductList, List<Dish> DishList)
        {
            this.ProductList = ProductList;
            this.DishList = DishList;
            InitializeComponent();
        }

        private void AddProduct_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string ProductName = textBox1.Text;

                if (ProductName.Length < 1)
                    throw new ArgumentException();

                int ProductID = int.Parse(textBox2.Text) - 1;
                if (ProductID < 0 || ProductID > 9)
                    throw new ArgumentException();

                int ProductWeight = int.Parse(textBox3.Text);
                if (ProductWeight <= 0)
                    throw new ArgumentException();

                var tmp = new Product(ProductName, ProductID, ProductWeight);

                if (tmp != null)
                {
                    ProductList.Add(tmp);
                    label6.Text = "Продукт успешно добавлен.";
                    textBox1.Text = "";
                    textBox2.Text = "";
                    textBox3.Text = "";
                }
                else
                    label6.Text = "Вы ввели некорректные данные.";
            }
            catch (Exception exc)
            {
                label6.Text = "Вы ввели некорректные данные.";
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
