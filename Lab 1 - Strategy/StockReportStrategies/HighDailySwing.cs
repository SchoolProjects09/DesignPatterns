using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockReportStrategies
{
    public class HighDailySwing : IFilterStrategy
    {
        private double maxPercent = 0.1;

        public HighDailySwing() { }

        public HighDailySwing(double percentage) { maxPercent = percentage; }

        public bool Include(TradingDay day)
        {
            double swing = day.Open - day.Close;
            double percentageSwing = Math.Abs(swing / day.Open);

            return percentageSwing > maxPercent;
        }
    }
}
