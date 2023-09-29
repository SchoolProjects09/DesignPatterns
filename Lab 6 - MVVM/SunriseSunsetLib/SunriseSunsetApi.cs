using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace SunriseSunsetLib
{
    public class SunriseSunsetApi
    {
        private const string API_URL = "https://api.sunrise-sunset.org/json?lat={0}&lng={1}&date={2}&formatted=0";


        public SunriseSunsetResults CallApi(double lat, double lon, DateTime date)
        {
            string url = string.Format(API_URL, lat, lon, date.ToString("yyyy-MM-dd"));

            string json;
            using (WebClient webClient = new WebClient())
            {
                json = webClient.DownloadString(url);
            }

            SunriseSunsetData data = JsonConvert.DeserializeObject<SunriseSunsetData>(json);

            if (data.status == "OK")
            {
                return data.results;
            }
            return null;
        }
    }
}
