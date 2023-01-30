using System.IO;
using System;
using System.Net;

namespace WeatherGraphic
{
    public class Request
    {
        private HttpWebRequest request;
        public string Response;

        public void StartRequest(string url)
        {
            request = (HttpWebRequest)WebRequest.Create(url);

            try
            {
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                using (Stream stream = response.GetResponseStream())
                {
                    Response = new StreamReader(stream).ReadToEnd();
                }
            }
            catch (Exception e)
            {
                Response = null;
            }
        }
    }
}