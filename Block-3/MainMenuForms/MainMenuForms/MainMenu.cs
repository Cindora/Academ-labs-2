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
    public partial class MainMenu : Form
    {
        public MainMenu()
        {
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
            ProductsMenu ProdMenu = new ProductsMenu();
            ProdMenu.FormClosed += (s, args) => this.Close();
            ProdMenu.Show();
            ProdMenu.Focus();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            DishesMenu DishMenu = new DishesMenu();
            DishMenu.FormClosed += (s, args) => this.Close();
            DishMenu.Show();
            DishMenu.Focus();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            FastDayMenu FastMenu = new FastDayMenu();
            FastMenu.FormClosed += (s, args) => this.Close();
            FastMenu.Show();
            FastMenu.Focus();
        }

        
    }
}
