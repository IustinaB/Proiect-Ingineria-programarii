#region Headers
/**************************************************************************
 *                                                                        *
 *  File:        RecordTests.cs                                           *
 *  Copyright:   (c) 2023, Gabriel Pojoga                                 *
 *  E-mail:      gabriel.pojoga@student.tuiasi.ro                         *
 *  Description: Test class for the methods of the Record.cs              *
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


namespace Persistence.Tests
{
    [TestClass()]
    public class RecordTests
    {
        #region Tests
        [TestMethod()]
        public void RecordTest()
        {
            // Date de intrare test
            string title = "Test Title";
            string content = "Test Content";
            string data = "2023-05-22";
            string location = "Test Location";
            string weather = "Test Weather";

            // Functia de testat
            Record record = new Record(title, content, data, location, weather);

            // Verificare
            Assert.AreEqual(title, record.Title);
            Assert.AreEqual(content, record.Content);
            Assert.AreEqual(data, record.Data);
            Assert.AreEqual(location, record.Location);
            Assert.AreEqual(weather, record.Weather);
        }

        [TestMethod()]
        public void RecordTest_JSON()
        {
            // Date de intrare test
            int id = 1;
            string title = "Test Title";
            string content = "Test Content";
            string data = "2023-05-22";
            string location = "Test Location";
            string weather = "Test Weather";

            // Functia de testat
            Record record = new Record(id, title, content, data, location, weather);

            // Verificare
            Assert.AreEqual(id, record.ID);
            Assert.AreEqual(title, record.Title);
            Assert.AreEqual(content, record.Content);
            Assert.AreEqual(data, record.Data);
            Assert.AreEqual(location, record.Location);
            Assert.AreEqual(weather, record.Weather);
        }

        [TestMethod()]
        public void ToStringTest()
        {
            // Data de intrare
            int id = 1;
            string title = "Test Title";
            string content = "Test Content";
            string data = "2023-05-22";
            string location = "Test Location";
            string weather = "Test Weather";

            Record record = new Record(id, title, content, data, location, weather);

            // Functia de testat
            string result = record.ToString();

            // Verificare
            string expected = $"ID= {id}\n title= {title}\n content= {content}\n data= {data}\n location= {location}\n";
            Assert.AreEqual(expected, result);
        }
        #endregion
    }
}