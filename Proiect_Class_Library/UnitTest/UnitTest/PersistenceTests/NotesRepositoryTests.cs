#region Headers
/**************************************************************************
 *                                                                        *
 *  File:        NotesRepositoryTests.cs                                  *
 *  Copyright:   (c) 2023, Gabriel Pojoga                                 *
 *  E-mail:      gabriel.pojoga@student.tuiasi.ro                         *
 *  Description: Test class for the methods of the                        *
 *               NotesRepositoryTests.cs                                  *
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
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Data.SQLite;
#endregion

namespace Persistence.Tests
{
    [TestClass()]
    public class NotesRepositoryTests
    {
        #region Tests Initialization
        private NotesRepository _notesRepository;

        /// <summary>
        /// Initializeaza conexiunea la baza de date
        /// </summary>
        [TestInitialize]
        public void TestInitialize()
        {
            _notesRepository = new NotesRepository();

            // Acceseaza si modifica campurile private folosind System.Reflection
            var connectionField = typeof(NotesRepository).GetField("_sqlConnection", BindingFlags.Instance | BindingFlags.NonPublic);
            var commandField = typeof(NotesRepository).GetField("_command", BindingFlags.Instance | BindingFlags.NonPublic);

            // Creeaza o conexiune SQL si o atribuie campului _sqlConnection din clasa de testare
            var newConnection = new SQLiteConnection("Data Source=your_database_file.db");
            connectionField.SetValue(_notesRepository, newConnection);

            // Creeaza o comanda SQL si o atribuie campului _command din clasa de testare
            var newCommand = newConnection.CreateCommand();
            commandField.SetValue(_notesRepository, newCommand);
        }

        /// <summary>
        /// Elibereaza resursele daca este cazul
        /// </summary>
        [TestCleanup]
        public void TestCleanup()
        {
            var connectionField = typeof(NotesRepository).GetField("_sqlConnection", BindingFlags.Instance | BindingFlags.NonPublic);
            var connection = (SQLiteConnection)connectionField.GetValue(_notesRepository);

            connection?.Dispose();
        }
        #endregion

        #region Tests
        /// <summary>
        /// Apeleaza functia CreateTable
        /// Daca functia arunca o eroare, testul pica
        /// </summary>
        [TestMethod()]
        public void CreateTableTest()
        {
            try
            {
                // Functia de testare
                _notesRepository.CreateTable();
            }
            catch
            {
                // Verificare
                Assert.Fail();
            }
        }

        /// <summary>
        /// Testul trece daca o notita este unica nou adaugata
        /// Daca se ruleaza testele de mai multe ori, se arunca eroare de tipul <UniqueDBRecordException>
        /// Daca se arunca altfel de eroare, testul pica
        /// </summary>
        [TestMethod()]
        public void AddNotesTest()
        {
            // Date de intrare test
            int id = 1;
            string title = "Test Title";
            string content = "Test Content";
            string data = "2023-05-22";
            string location = "Test Location";
            string weather = "Test Weather";
            Record record = new Record(id, title, content, data, location, weather);

            try
            {
                // Functia de testare
                _notesRepository.AddNotes(record);
            }
            catch (UniqueDBRecordException ex)
            {
                // Verificare
                Assert.AreEqual("Exista deja o astfel de inregistrare in baza de date!", ex.Message);
            }
            catch
            {
                // Verificare
                Assert.Fail();
            }
        }

        /// <summary>
        /// Apeleaza GetAllNotes si verifica daca rezultatul nu e null
        /// Daca se arunca o eroare testul pica
        /// </summary>
        [TestMethod()]
        public void GetAllNotesTest()
        {
            // Date de intrare test
            Record[] records;

            try
            {
                // Functia de testat
                records = _notesRepository.GetAllNotes();
                // Verificare
                Assert.IsNotNull(records);
            }
            catch
            {
                // Verificare
                Assert.Fail();
            }
        }

        /// <summary>
        /// Apeleaza GetBotesByDate si verifica daca rezultatul nu e null
        /// Daca se arunca o eroare testul pica
        /// </summary>
        [TestMethod()]
        public void GetNotesByDateTest()
        {
            // Date de intrare test
            string data = "2023-05-22";

            Record[] records;

            try
            {
                // Functia de testat
                records = _notesRepository.GetNotesByDate(data);
                // Verificare
                Assert.IsNotNull(records);
            }
            catch
            {
                // Verificare
                Assert.Fail();
            }
        }

        /// <summary>
        /// Apeleaza UpdateNote si verifica daca modificarea a fost efectuata sau se arunca o eroare <UniqueDBRecordException>
        /// Daca se arunca o eroare testul pica
        /// </summary>
        [TestMethod()]
        public void UpdateNoteTest()
        {
            // Date de intrare test
            int id = 1;
            string title = "Test Title";
            string content = "Test Content";
            string data = "2023-05-22";
            string location = "Test Location";
            string weather = "Test Weather";
            Record record = new Record(id, title, content, data, location, weather);

            try
            {
                // Functia de testat
                _notesRepository.UpdateNote(record);
            }
            catch (Exception ex)
            {
                // Verificare
                Assert.AreEqual(typeof(UniqueDBRecordException), ex.GetType());
                Assert.AreEqual("Exista deja o astfel de inregistrare in baza de date!", ex.Message);
            }
        }

        /// <summary>
        /// Testul pica daca ID-ul respectiv nu exista
        /// </summary>
        [TestMethod()]
        public void GetNoteByIDTest()
        {
            // Date de intrare test
            int id = 1;
            Record recordCheck;

            try
            {
                // Functia de testat
                recordCheck = _notesRepository.GetNoteByID(id);
                Assert.AreEqual(id, recordCheck.ID, recordCheck.ToString());
            }
            catch
            {
                // Verificare
                Assert.Fail();
            }
        }

        /// <summary>
        /// Apeleaza GetAllDates si verifica daca se returneaza un null
        /// Daca se arunca o eroare testul pica
        /// </summary>
        [TestMethod()]
        public void GetAllDatesTest()
        {
            try
            {
                // Functia de testat
                List<string> dates = new List<string>();
                dates = _notesRepository.GetAllDates();
                Assert.IsNotNull(dates);
            }
            catch
            {
                // Verificare
                Assert.Fail();
            }
        }

        /// <summary>
        /// Apeleaza DeleteNote
        /// Daca se arunca o eroare testul pica
        /// </summary>
        [TestMethod()]
        public void DeleteNoteTest()
        {
            // Date de intrare test
            int id = 1;

            try
            {
                // Functia de testat
                _notesRepository.DeleteNote(id);
            }
            catch
            {
                // Verificare
                Assert.Fail();
            }
        }

        /// <summary>
        /// Apeleaza DeleteAllNotesTest
        /// Daca se arunca o eroare testul pica
        /// </summary>
        [TestMethod()]
        public void DeleteAllNotesTest()
        {
            try
            {
                // Functia de testat
                _notesRepository.DeleteAllNotes();
            }
            catch
            {
                // Verificare
                Assert.Fail();
            }
        }
        #endregion
    }
}