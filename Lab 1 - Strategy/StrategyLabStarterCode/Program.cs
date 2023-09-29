using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StockReportStrategies;

namespace StockReportStrategies
{
    class Program
    {
        private static void ReportTradingDays(StockMarket tradingDays, IFilterStrategy strategy)
        {
            foreach (TradingDay day in tradingDays.GetTradingDays())
            {
                if (strategy.Include(day))
                    Console.WriteLine(day.ToString());
            }
        }

        static void Main(string[] args)
        {
            IParsingStrategy Original = new OriginalCsvParser();
            IParsingStrategy Google = new GoogleCsvParser();

            StockMarket tradingDays = new StockMarket(@"..\..\stockData.csv", Original);
            StockMarket tradingDays2 = new StockMarket(@"..\..\GOOG.csv", Google);
            
            IFilterStrategy highswing = new HighDailySwing();
            IFilterStrategy highswing2 = new HighDailySwing(0.05);

            IFilterStrategy highvolume = new HighVolume();
            IFilterStrategy highvolume2 = new HighVolume(2000000);

            ReportTradingDays(tradingDays, highswing);
            Console.WriteLine("-------------------------------");
            ReportTradingDays(tradingDays2, highswing2);
            Console.WriteLine("-------------------------------");
            ReportTradingDays(tradingDays, highvolume);
            Console.WriteLine("-------------------------------");
            ReportTradingDays(tradingDays2, highvolume2);

            //Prevent the console window from closing during debugging. 
            Console.ReadLine();
        }        
    }
}
