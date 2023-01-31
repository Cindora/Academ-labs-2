using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WeatherGraphic
{
    public partial class MainForm : Form
    {
        TomorrowIo tomorrowIoSite = new TomorrowIo(new Request());
        public MainForm()
        {
            InitializeComponent();
            tomorrowIoSite.GetTemperatureArray();
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
