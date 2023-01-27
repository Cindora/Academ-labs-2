using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace MainMenuForms
{
    public partial class DelProduct : Form
    {
        List<Product> ProductList;
        List<Dish> DishList;
        public DelProduct(List<Product> ProductList, List<Dish> DishList)
        {
            this.ProductList = ProductList;
            this.DishList = DishList;
            InitializeComponent();
            dishListLabel.Text = Program.DisplayProducts(ProductList);
        }

        private void DelProduct_Load(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            ProductsMenu ProdMenu = new ProductsMenu(ProductList, DishList);
            ProdMenu.FormClosed += (s, args) => this.Close();
            ProdMenu.Show();
            ProdMenu.Focus();
        }

        private void commandResult_Click(object sender, EventArgs e)
        {

        }

        private void dishListLabel_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                int ID = int.Parse(textBox1.Text);

                ProductList.RemoveAt(ID - 1);

                dishListLabel.Text = Program.DisplayProducts(ProductList);
                textBox1.Text = "";
                commandResult.Text = "Продукт успешно удалён.";
            }
            catch
            {
                commandResult.Text = "Вы ввели некорректные данные.";
            }
        }
    }
}
