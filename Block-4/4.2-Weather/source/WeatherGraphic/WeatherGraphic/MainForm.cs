using Newtonsoft.Json.Linq;
using SmartFormat.Core.Output;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

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

            //chart1.Series[0].Points.AddXY(i, outputY);

            for (int i = 0; i<6; i++)
            {
                var Y = (tomorrowIoSite.temperature[i] + openWeatherMapSite.temperature[i]) / 2;
                chart1.Series[0].Points.AddY(Y);
            }
            
        }
        
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }
    }
}
