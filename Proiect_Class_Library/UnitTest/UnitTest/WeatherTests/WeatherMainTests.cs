#region Headers
/**************************************************************************
 *                                                                        *
 *  File:       WeatherMainTests.cs                                       *
 *  Copyright:   (c) 2023, Gabriel Pojoga                                 *
 *  E-mail:      gabriel.pojoga@student.tuiasi.ro                         *
 *  Description: Test class for the methods of the WeatherMain.cs         *
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
#endregion

namespace API.Tests
{
    [TestClass()]
    public class WeatherMainTests
    {
        #region Test Initialization
        private Weather _weather;
        private GeocodingLoc _geocodingLoc;

        [TestInitialize]
        public void TestInitialize()
        {
            _weather = new Weather();
            _geocodingLoc = new GeocodingLoc();
        }
        #endregion

        #region Tests
        /// <summary>
        /// Se testeaza daca primeste un raspuns valid cand se trimite un input corect 
        /// </summary>
        [TestMethod()]
        public void WeatherForCity_ValidInput_CorrectResponse()
        {
            // Date de intrare
            string city = "Iasi";
            string date = "2023-05-30";

            // Functia de testat
            Coordinates[] coordinates = _geocodingLoc.GetLocationCoord(city);
            WeatherData weatherData = _weather.GetWeatherData(coordinates[0].Latitude, coordinates[0].Longitude, date);

            // Verificare
            Assert.IsNotNull(weatherData);
        }

        /// <summary>
        /// Se testeaza daca primeste un raspuns valid cand se trimite un input gresit 
        /// </summary>
        [TestMethod()]
        public void WeatherForCity_InvalidInput_CorrectResponse()
        {
            // Date de intrare
            string city = "Iasi";
            string date = "";

            // Functia de testat
            Coordinates[] coordinates = _geocodingLoc.GetLocationCoord(city);
            WeatherData weatherData = _weather.GetWeatherData(coordinates[0].Latitude, coordinates[0].Longitude, date);

            // Verificare
            Assert.IsNotNull(weatherData);
            Assert.Fail();
        }
        #endregion
    }
}