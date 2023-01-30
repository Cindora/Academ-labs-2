using System;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace WeatherGraphic
{
    public class TomorrowIo
    {
        string siteName;
        string apiKey;
        string url;

        Request request;

        public TomorrowIo(Request request)
        {
            siteName = "Tomorrow.io";
            url = "https://api.tomorrow.io/v4/timelines?location=30.2642,59.8944&fields=temperature&timesteps=1d&endTime=nowPlus5d&units=metric&apikey=";
            apiKey = "qX7tcu2J8lZtCtB4G4WToYI3VvzpMzLV";

            this.request = request;
        }

        public double[] GetTemperatureArray()
        {
            request.StartRequest(url + apiKey);

            if (request.Response != null)
            {

            }
            else
            {
                
            }

            return new double[0];
        }

    }
}
