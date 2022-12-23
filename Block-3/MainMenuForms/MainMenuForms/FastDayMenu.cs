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
    public partial class FastDayMenu : Form
    {
        public FastDayMenu()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
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
    }
}
