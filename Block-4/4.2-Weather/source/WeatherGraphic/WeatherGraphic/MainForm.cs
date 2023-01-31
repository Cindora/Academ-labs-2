using Newtonsoft.Json.Linq;
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
        OpenWeatherMap openWeatherMapSite = new OpenWeatherMap(new Request());

        public MainForm()
        {
            InitializeComponent();
            tomorrowIoSite.GetTemperatureArray();
            openWeatherMapSite.GetTemperatureArray();

            string output = "";
            output += $"\t\t\t{tomorrowIoSite.siteName}: {string.Join("  ", tomorrowIoSite.temperature)}\n";
            output += $"{openWeatherMapSite.siteName}: {string.Join("  ", openWeatherMapSite.temperature)}\n";

            label1.Text = output;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
