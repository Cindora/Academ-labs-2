using System;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using SmartFormat.Core.Output;
using System.IO;

namespace WeatherGraphic
{
    public class TomorrowIo
    {
        public string siteName;
        public double[] temperature = new double[6];

        string apiKey;
        string url;
        Request request;
         
        public TomorrowIo(Request request)
        {
            siteName = "Tomorrow.io";
            url = "https://api.tomorrow.io/v4/timelines?location=59.8944,30.2642&fields=temperature&timesteps=1d&endTime=nowPlus5d&units=metric&apikey=";
            apiKey = "qX7tcu2J8lZtCtB4G4WToYI3VvzpMzLV";

            this.request = request;
        }

        public void GetTemperatureArray()
        {
            request.StartRequest(url + apiKey);

            if (request.Response != null)
            {
                var parsedRequest = JObject.Parse(request.Response);
                var data = parsedRequest["data"]["timelines"][0]["intervals"];

                int i = 0;
                foreach (var values in data)
                {
                    temperature[i++] = Convert.ToDouble(values["values"]["temperature"]);
                }
            }
            else
            {
                for (int i= 0; i < temperature.Length; i++)
                {
                    temperature[i] = -9999;
                }
            }
        }
    }

    public class OpenWeatherMap
    {
        public string siteName;
        public double[] temperature = new double[6];

        string apiKey;
        string url;
        Request request;

        public OpenWeatherMap(Request request)
        {
            siteName = "OpenWeatherMap.org";
            url = "https://api.openweathermap.org/data/2.5/forecast?lat=59.8944&lon=30.2642&appid=";
            apiKey = "9263a45a865eb9eaf08a8ee1f38fa190";

            this.request = request;
        }

        public void GetTemperatureArray()
        {
            request.StartRequest(url + apiKey);

            if (request.Response != null)
            {
                var parsedRequest = JObject.Parse(request.Response)["list"];

                //var id = Math.Round(Convert.ToDouble(parsedRequest[15]["main"]["temp"]) - 273.15, 2);

                for (int i = 0; i < 6; i++)
                {
                    temperature[i] = Math.Round(Convert.ToDouble(parsedRequest[i * 6]["main"]["temp"]) - 273.15, 2);
                }

                //var data = parsedRequest["data"]["timelines"][0]["intervals"];

                //int i = 0;
                //foreach (var values in data)
                //{
                //    temperature[i++] = Convert.ToDouble(values["values"]["temperature"]);
                //}
            }
            else
            {
                for (int i = 0; i < temperature.Length; i++)
                {
                    temperature[i] = -9999;
                }
            }

        }

    }
}
