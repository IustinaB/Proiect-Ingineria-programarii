#region Headers
/**************************************************************************
 *                                                                        *
 *  File:        Form1Tests.cs                                            *
 *  Copyright:   (c) 2023, Gabriel Pojoga                                 *
 *  E-mail:      gabriel.pojoga@student.tuiasi.ro                         *
 *  Description: Test class for the methods of the Forms1.cs              *
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

namespace IP_Proiect.Tests
{
    #region Tests
    [TestClass()]
    public class Form1Tests
    {
        /// <summary>
        /// Testul va esua intrucat complexitatea este prea mare
        /// </summary>
        [TestMethod()]
        public void Form1Test()
        {
            try
            {
                // Functia de testat
                Form1 form1Test = new Form1();
            }
            catch
            {
                // Verificare
                Assert.Fail();
            }
        }
    }
    #endregion
}