#region Headers
/**************************************************************************
 *                                                                        *
 *  File:        WeatherTests.cs                                          *
 *  Copyright:   (c) 2023, Gabriel Pojoga                                 *
 *  E-mail:      gabriel.pojoga@student.tuiasi.ro                         *
 *  Description: Test class for the methods of the Weather.cs             *
 *                                                                        *
 *  Codul și informația sunt oferite așa cum se regăsec și fără vreo      *
 *  garanție de orice fel, fie transmisă sau implicată, inclusiv dar nu   *
 *  limitat la garanțiile implicate de vandabilitate sau pentru un scop   *
 *  specific. Utilizarea codului este open source pentru alte aplicații   *
 *  cu mențiunea păstrării drepturilor de autor originale.                *
 *                                                                        *
 **************************************************************************/
#endregion

#region Includes
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;
#endregion


namespace API.Tests
{
    [TestClass()]
    public class WeatherTests
    {
        #region Test Initialization
        private Weather _weather;

        [TestInitialize]
        public void TestInitialize()
        {
            _weather = new Weather();
        }
        #endregion

        #region Tests
        /// <summary>
        /// Se testeaza daca se primeste un raspuns valid pentru un input valid
        /// </summary>
        [TestMethod()]
        public void GetStringByCoord_ValidInput_CorrectResponse()
        {
            // Date de intrare
            double latitude = 47.15;
            double longitude = 27.58;
            string date = "2023-05-25";

            // Functia de testat
            string response;
            // Implementat astfel intrucat functia de testat este un Task asincron
            var task = Task.Run(() => _weather.GetStringByCoord(latitude, longitude, date));
            task.Wait();

            response = task.Result;

            // Verificare
            Assert.IsNotNull(response);
            Assert.IsFalse(string.IsNullOrEmpty(response));
        }

        /// <summary>
        /// Se testeaza daca se primeste un raspuns valid pentru un input corect
        /// </summary>
        [TestMethod()]
        public void GetStringByCoord_InvalidInput_CorrectResponse()
        {
            // Date de intrare
            double latitude = 47.15;
            double longitude = 27.58;
            string date = "";

            // Functia de testat
            string response;
            // Implementat astfel intrucat functia de testat este un Task asincron
            var task = Task.Run(() => _weather.GetStringByCoord(latitude, longitude, date));
            task.Wait();

            response = task.Result;

            // Verificare
            Assert.IsNull(response);
        }

        /// <summary>
        /// Se testeaza daca se primeste un raspuns valid pentru un input valid
        /// if the actual to expected is less < 1.0 it is acceptable
        /// </summary>
        [TestMethod()]
        public void GetWeatherDataTest_ValidInput_CorrectResponse()
        {
            // Date de intrare
            double latitude = 47.15;
            double longitude = 27.58;
            string date = "2023-05-22";

            // Functia de testat
            WeatherData weatherData = _weather.GetWeatherData(latitude, longitude, date);

            // Verificare
            Assert.IsNotNull(weatherData);
            Assert.AreEqual(latitude, weatherData.Latitude);
            Assert.AreEqual(longitude, weatherData.Longitude);
        }

        /// <summary>
        /// Se testeaza daca se primeste un raspuns valid pentru un input gresit
        /// </summary>
        [TestMethod()]
        public void GetWeatherDataTest_InvalidInput_CorrectResponse()
        {
            // Date de intrare
            double latitude = 47.15;
            double longitude = 27.58;
            string date = "2023-05-22";

            // Functia de testat
            WeatherData weatherData = _weather.GetWeatherData(latitude, longitude, date);

            // Verificare
            Assert.IsNull(weatherData);
        }
        #endregion
    }
}