using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StockReportStrategies;

namespace StrategyTests
{
    [TestClass]
    public class FilterStrategyTests
    {
        [DataTestMethod]
        [DataRow(100, 200, true)]
        [DataRow(200, 100, true)]
        [DataRow(100, 100, false)]
        public void HighSwing_Include_ReturnsExpected(int open, int close, bool expected)
        {
            //Arrange
            HighDailySwing highSwing = new HighDailySwing();
            TradingDay day = new TradingDay(default(DateTime), open, 0, 0, close, 0);
            //Act
            bool result = highSwing.Include(day);
            //Assert
            Assert.AreEqual(expected, result);
        }

        [DataTestMethod]
        [DataRow(30000000, true)]
        [DataRow(10000000, false)]
        public void HighVolume_Include_ReturnsExpected(int volume, bool expected)
        {
            //Arrange
            HighVolume highVolume = new HighVolume();
            TradingDay day = new TradingDay(default(DateTime), 0, 0, 0, 0, volume);
            //Act
            bool result = highVolume.Include(day);
            //Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void Original_ParseRow_ReturnsExpected()
        {
            //Arrange
            const string Data = "24-Oct-05,10216.11,10411.57,10219.15,10385,21977900,10385";
            TradingDay expected = new TradingDay(DateTime.Parse("24-Oct-05"),
                10216.11, 10411.57, 10219.15, 10385, 21977900);

            OriginalCsvParser parser = new OriginalCsvParser();

            //Act
            TradingDay result = parser.ParseRow(Data);

            //Assert
            Assert.AreEqual(expected.ToString(), result.ToString());
        }

        [TestMethod]
        public void Google_ParseRow_ReturnsTradingDay()
        {
            //Arrange
            const string Data = "2019-10-03,1180.000000,1189.060059,1162.430054,1187.829956,1187.829956,1621200";
            TradingDay expected = new TradingDay(DateTime.Parse("2019-10-03"), 
                1180.000000, 1189.060059, 1162.430054, 1187.829956, 1621200);

            GoogleCsvParser parser = new GoogleCsvParser();

            //Act
            TradingDay result = parser.ParseRow(Data);

            //Assert
            Assert.AreEqual(expected.ToString(), result.ToString());
        }
    }
}
