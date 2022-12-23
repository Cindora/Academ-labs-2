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
    public partial class ProductsMenu : Form
    {
        public ProductsMenu()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            MainMenu Main = new MainMenu();
            Main.FormClosed += (s, args) => this.Close();
            Main.Show();
            Main.Focus();
        }

        private void ProductsMenu_Load(object sender, EventArgs e)
        {

        }
    }
}
