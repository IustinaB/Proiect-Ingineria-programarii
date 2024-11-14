/**************************************************************************
 *                                                                        *
 *  File:        NotesRepository.cs                                       *
 *  Copyright:   (c) 2023, Boaca Madalina-Elena                           *
 *  E-mail:      madalina-elena.boaca@student.tuiasi.ro                   *
 *  Description: Clasa concreta ce implementeaza lucrul cu baza de date   *                                 
 *               am folosit SQLite datorita necesitatilor restranse pentru*
 *               aceasta varianta a aplicatiei. In aceasta clasa          *
 *               sunt implementate operatii CRUD.                         *
 **************************************************************************/

using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Text.RegularExpressions;
using System.IO;

namespace Persistence
{
    /// <summary>
    /// Clasa pentru efectuarea operatiilor cu baza de date
    /// </summary>
    public class NotesRepository : INotesRepository
    {
        #region Private Proprietes
        private SQLiteConnection _sqlConnection;
        private SQLiteCommand _command;
        #endregion

        #region Constructors
        /// <summary>
        /// Constructorul clasei pentru operatii cu baza de date
        /// </summary>
        public NotesRepository()
        {
            bool isNewDatabase = !File.Exists("Resources/notes.db");
            _sqlConnection = new SQLiteConnection(@"Data Source = Resources/notes.db; Version = 3; New = " + isNewDatabase + "; Compress = True;");
            _command = _sqlConnection.CreateCommand();
        }

        #endregion

        #region Public Methods
        /// <summary>
        /// Metoda care creaza baza de date(daca ea nu exista)
        /// </summary>
        public void CreateTable()
        {
            try
            {
                _sqlConnection.Open();

                string sqlString = "CREATE TABLE IF NOT EXISTS NotesWeather (id INTEGER PRIMARY KEY AUTOINCREMENT," +
                    " title VARCHAR(50), content VARCHAR(200), data VARCHAR(20), location VARCHAR(20),weather TEXT, UNIQUE(title,content,data,location))";
                _command.CommandText = sqlString;
                _command.ExecuteNonQuery();
            }
            catch (Exception exception)
            {
                throw exception;
            }
            finally
            {
                _sqlConnection.Close();
            }
        }

        /// <summary>
        /// Metoda care adauga continutul unei note in baza de date
        /// </summary>
        /// <param name="record">Contine ca obiect datele de introdus.</param>
        public void AddNotes(in Record record)
        {
            try
            {
                _sqlConnection.Open();

                string sqlString = "INSERT INTO NotesWeather (id, title, content, data, location,weather) VALUES(null,@title,@content,@data,@location,@weather)";
                _command.CommandText = sqlString;
                _command.Parameters.Add(new SQLiteParameter("@title", record.Title));
                _command.Parameters.Add(new SQLiteParameter("@content", record.Content));
                _command.Parameters.Add(new SQLiteParameter("@data", record.Data));
                _command.Parameters.Add(new SQLiteParameter("@location", record.Location));
                _command.Parameters.Add(new SQLiteParameter("@weather", record.Weather));
                _command.ExecuteNonQuery();
            }
            catch (SQLiteException exception)
            {
                if (exception.Message.Contains("UNIQUE"))
                {
                    throw new UniqueDBRecordException("Exista deja o astfel de inregistrare in baza de date!");
                }

            }
            catch (Exception exception)
            {
                throw exception;
            }
            finally
            {
                _sqlConnection.Close();
            }
        }

        /// <summary>
        /// Metoda care returnează toate notitele din baza de date.
        /// </summary>
        /// <returns>O Lista ce contine continutul bazai de date.</returns>
        public Record[] GetAllNotes()
        {
            SQLiteDataReader sqliteDatareader = null;
            int id;
            string title;
            string data;
            string location;
            string content;
            string weather;
            List<Record> listOfRecord = new List<Record>();

            try
            {
                _sqlConnection.Open();

                _command.CommandText = "SELECT * FROM NotesWeather";

                sqliteDatareader = _command.ExecuteReader();
                while (sqliteDatareader.Read())
                {
                    //id, title, content, data, location
                    id = sqliteDatareader.GetInt32(0);
                    title = sqliteDatareader.GetString(1);
                    content = sqliteDatareader.GetString(2);
                    data = sqliteDatareader.GetString(3);
                    location = sqliteDatareader.GetString(4);
                    weather = sqliteDatareader.GetString(5);
                    Record readRecord = new Record(id, title, content, data, location, weather);
                    listOfRecord.Add(readRecord);
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                sqliteDatareader.Close();
                _sqlConnection.Close();
            }

            return listOfRecord.ToArray();
        }


        /// <summary>
        /// Metoda care returnează toate notitele din baza de date dintr-o anumita data.
        /// </summary>
        /// <param name="date">Data de la care se doresc inregistrarile.</param>
        /// <returns>O lista ce contine inregistrarile din baza de date, cu data specificata.</returns>
        public Record[] GetNotesByDate(in string date)
        {
            SQLiteDataReader sqliteDatareader = null;
            int id;
            string title;
            string data;
            string location;
            string content;
            string weather;
            List<Record> listOfRecord = new List<Record>();

            try
            {
                _sqlConnection.Open();

                _command.CommandText = "SELECT * FROM NotesWeather WHERE data = @data";
                _command.Parameters.Add(new SQLiteParameter("@data", date));

                sqliteDatareader = _command.ExecuteReader();
                while (sqliteDatareader.Read())
                {
                    //id, title, content, data, location
                    id = sqliteDatareader.GetInt32(0);
                    title = sqliteDatareader.GetString(1);
                    content = sqliteDatareader.GetString(2);
                    data = sqliteDatareader.GetString(3);
                    location = sqliteDatareader.GetString(4);
                    weather = sqliteDatareader.GetString(5);
                    Record readRecord = new Record(id, title, content, data, location, weather);
                    listOfRecord.Add(readRecord);
                }
            }
            catch (Exception e)
            {
                //nu am ce sa ii fac
                throw e;
            }
            finally
            {
                sqliteDatareader.Close();
                _sqlConnection.Close();
            }

            return listOfRecord.ToArray();
        }

        /// <summary>
        /// Metoda care actualizeaza o anumite inregistrare din baza de date.
        /// </summary>
        /// <param name="record">Obiect cu noile date.</param>
        public void UpdateNote(in Record record)
        {
            try
            {
                _sqlConnection.Open();

                string sqlString = "UPDATE NotesWeather set title=@title,content=@content,data=@data,location=@location,weather=@weather where id=@id";
                _command.CommandText = sqlString;
                _command.Parameters.Add(new SQLiteParameter("@id", record.ID));
                _command.Parameters.Add(new SQLiteParameter("@title", record.Title));
                _command.Parameters.Add(new SQLiteParameter("@content", record.Content));
                _command.Parameters.Add(new SQLiteParameter("@data", record.Data));
                _command.Parameters.Add(new SQLiteParameter("@location", record.Location));
                _command.Parameters.Add(new SQLiteParameter("@weather", record.Weather));
                _command.ExecuteNonQuery();
            }
            catch (System.Data.SQLite.SQLiteException exception)
            {
                if (exception.Message.Contains("UNIQUE"))
                {
                    throw new UniqueDBRecordException("Exista deja o astfel de inregistrare in baza de date!");
                }
            }
            finally
            {
                _sqlConnection.Close();
            }
        }

        /// <summary>
        /// Metoda care sterge o inregistrare din baza de date.
        /// </summary>
        /// <param name="id">Identificatorul notei de sters.</param>
        public void DeleteNote(in int id)
        {
            try
            {
                _sqlConnection.Open();
                string sqlString = "DELETE FROM NotesWeather WHERE id=@id";
                _command.CommandText = sqlString;
                _command.Parameters.Add(new SQLiteParameter("@id", id));
                _command.ExecuteNonQuery();
            }
            catch (Exception exception)
            {
                throw exception;
            }
            finally
            {
                _sqlConnection.Close();
            }
        }

        /// <summary>
        /// Metoda care sterge toate inregistrarile din baza de date.
        /// </summary>
        public void DeleteAllNotes()
        {
            try
            {
                _sqlConnection.Open();
                string sqlString = "DELETE FROM NotesWeather";
                _command.CommandText = sqlString;
                _command.ExecuteNonQuery();
            }
            catch (Exception exception)
            {
                throw exception;
            }
            finally
            {
                _sqlConnection.Close();
            }
        }

        /// <summary>
        /// Metoda returneaza o nota pe baza id-ului.
        /// </summary>
        /// <returns>Nota cu acel ID</returns>
        public Record GetNoteByID(in int id)
        {
            SQLiteDataReader sqliteDatareader = null;
            string title;
            string data;
            string location;
            string content;
            string weather;

            try
            {
                _sqlConnection.Open();

                _command.CommandText = "SELECT * FROM NotesWeather WHERE id = @id";
                _command.Parameters.Add(new SQLiteParameter("@id", id));

                sqliteDatareader = _command.ExecuteReader();
                if (sqliteDatareader.Read())
                {
                    title = sqliteDatareader.GetString(1);
                    content = sqliteDatareader.GetString(2);
                    data = sqliteDatareader.GetString(3);
                    location = sqliteDatareader.GetString(4);
                    weather = sqliteDatareader.GetString(5);
                    Record readRecord = new Record(id, title, content, data, location, weather);
                    return readRecord;
                }
            }
            catch (Exception)
            {
                return new Record();
            }
            finally
            {
                if (sqliteDatareader != null)
                    sqliteDatareader.Close();
                _sqlConnection.Close();
            }
            return new Record();
        }

        /// <summary>
        /// Functia care extrage toate datele in care am notite
        /// </summary>
        /// <returns>Lista de date</returns>
        public List<string> GetAllDates()
        {
            SQLiteDataReader sqliteDatareader = null;
            string date;

            List<string> listOfDate = new List<string>();

            try
            {
                _sqlConnection.Open();

                _command.CommandText = "SELECT DISTINCT data FROM NotesWeather";

                sqliteDatareader = _command.ExecuteReader();
                while (sqliteDatareader.Read())
                {
                    date = sqliteDatareader.GetString(0);
                    listOfDate.Add(date);
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                sqliteDatareader.Close();
                _sqlConnection.Close();
            }

            return listOfDate;
        } 
        #endregion
    }
}