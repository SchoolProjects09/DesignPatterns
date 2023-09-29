using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SunriseSunsetLib;

namespace SunriseSunsetTests
{
    [TestClass]
    public class UnitTest1
    {

        [TestMethod]
        public void CallApiTest()
        {
            //Arrange
            SunriseSunsetApi api = new SunriseSunsetApi();
            double lat = 45.321627;
            double lon = -122.766609;
            DateTime date = new DateTime(2020, 11, 7);

            //Act
            SunriseSunsetResults results = api.CallApi(lat, lon, date);

            //Assert
            Assert.AreEqual("11/7/2020 7:00:21 AM", results.sunrise.ToString());
        }
    }
}
