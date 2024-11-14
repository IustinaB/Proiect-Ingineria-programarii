#region Headers
/**************************************************************************
 *                                                                        *
 *  File:        GeocodingLocTests.cs                                     *
 *  Copyright:   (c) 2023, Gabriel Pojoga                                 *
 *  E-mail:      gabriel.pojoga@student.tuiasi.ro                         *
 *  Description: Test class for the methods of the                        *
 *               GeocodingLocTests.cs                                     *
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
    public class GeocodingLocTests
    {
        #region Test Initialization
        private GeocodingLoc _geocodingLoc;

        [TestInitialize]
        public void TestInitialize()
        {
            _geocodingLoc = new GeocodingLoc();
        }
        #endregion

        #region Tests
        /// <summary>
        /// Se testeaza daca primeste un raspuns valid cand se trimite un input corect 
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public void GetStringGeo_ValidLocation_ReturnsNonEmptyString()
        {
            // Date de intrare
            string location = "Iasi";

            // Functia de testat
            string response;
            // Implementat astfel intrucat functia de testat este un Task asincron
            var task = Task.Run(() => _geocodingLoc.GetStringGeo(location));
            task.Wait();

            response = task.Result;
            // Verificare
            Assert.IsNotNull(response);
            Assert.IsTrue(!string.IsNullOrEmpty(response));
        }

        /// <summary>
        /// Se testeaza daca primeste un raspuns valid cand se trimite un input corect 
        /// </summary>
        [TestMethod]
        public void GetLocationCoord_ValidLocation_ReturnsCoordinatesArray()
        {
            // Date de intrare
            string location = "Botoșani";

            // Functia de testat
            Coordinates[] result;
            // Implementat astfel intrucat functia de testat este un Task asincron
            var task = Task.Run(() => _geocodingLoc.GetLocationCoord(location));
            task.Wait();

            result = task.Result;

            // Verificare
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Length > 0);
        }
        #endregion
    }
}