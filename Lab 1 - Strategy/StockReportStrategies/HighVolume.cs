using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockReportStrategies
{
    public class HighVolume : IFilterStrategy
    {
        private int maxVolume = 20000000;
        public HighVolume() { }

        public HighVolume(int volume) { maxVolume = volume; }

        public bool Include(TradingDay day)
        {
            return day.Volume > maxVolume;
        }
    }
}
