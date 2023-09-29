using SunriseSunsetLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SunriseSunsetWPF
{
    public class MainModel
    {
        public SunriseSunsetResults GetData(double lat, double lon, DateTime date)
        {
            SunriseSunsetApi api = new SunriseSunsetApi();

            return api.CallApi(lat, lon, date);
        }
    }
}
