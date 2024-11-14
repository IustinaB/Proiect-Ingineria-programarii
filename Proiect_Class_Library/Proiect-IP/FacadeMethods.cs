/**************************************************************************
 *                                                                        *
 *  File:        FacadeMethods.cs                                         *
 *  Copyright:   (c) 2023, Boaca Madalina-Elena                           *
 *  E-mail:      madalina-elena.boaca@student.tuiasi.ro                   *
 *  Description: Acest fisier contine clasa pentru legarea prin           *
 *               intermediul sablonului fatada a interfetei de nivelul de *
 *               API si cel de persistenta.                               *
 **************************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Persistence;
using API;

namespace IP_Proiect
{
    /// <summary>
    /// Clasa care face legatura interfetei cu modulul de persistenta si API-ul
    /// </summary>
    class FacadeMethods
    {
        private INotesRepository _notesRepository;
        private WeatherMain _weatherMain;
        private WeatherData _weatherData;

        public FacadeMethods()
        {
            _notesRepository = new NotesRepository();
        }
        /// <summary>
        /// Metoda care creaza baza de date(daca ea nu exista)
        /// </summary>
        public void CreateTable()
        {
            _notesRepository.CreateTable();
        }

        /// <summary>
        /// Metoda care adauga continutul unei note in baza de date
        /// </summary>
        /// <param name="title"></param>
        /// <param name="content"></param>
        /// <param name="data"></param>
        /// <param name="location"></param>
        /// <param name="weather"></param>
        public void AddNotes(string title, string content, string data, string location, string weather)
        {
            _notesRepository.AddNotes(new Record(title,content,data,location,weather));
        }

        /// <summary>
        /// Metoda care returnează toate notitele din baza de date.
        /// </summary>
        /// <returns>Un dictionar cu notitele si id-ul lor.</returns>
        public Dictionary<int, String> GetAllNotes()
        {
            Record[] listOfAllNotes = _notesRepository.GetAllNotes();
            Dictionary<int,String> dictOfNotes = new Dictionary<int, string>();

            foreach (Record record in listOfAllNotes)
            {
                string weather = $"{Environment.NewLine}Weather:{Environment.NewLine}{record.Weather}";
                string note = $"Title: {record.Title}{Environment.NewLine}Date: {record.Data}{Environment.NewLine}Location: {record.Location}{Environment.NewLine}Content: {record.Content}{weather}";
                dictOfNotes.Add(record.ID, note);
            }
            return dictOfNotes;
        }

        /// <summary>
        /// Metoda care returnează toate notitele din baza de date dintr-o anumita data.
        /// </summary>
        /// <param name="date">Data de la care se doresc inregistrarile.</param>
        /// <returns>Un dictionar ce contine inregistrarile din baza de date, cu data specificata.</returns>
        public Dictionary<int, String> GetNotesByDate(in string date)
        {
            Record[] listOfAllNotes = _notesRepository.GetNotesByDate(date);
            Dictionary<int, String> dictOfNotes = new Dictionary<int, string>();

            foreach (Record record in listOfAllNotes)
            {
                string weather = $"{Environment.NewLine}Weather:{Environment.NewLine}{record.Weather}{Environment.NewLine}";
                string note = $"Title: {record.Title}{Environment.NewLine}Date: {record.Data}{Environment.NewLine}Location: {record.Location}{Environment.NewLine}Content: {record.Content}{weather}";
                dictOfNotes.Add(record.ID, note);
            }
            return dictOfNotes;
        }

        /// <summary>
        /// Metoda care returnează o notita cu un anumit ID.
        /// </summary>
        /// <param name="id">ID-ul notei.</param>
        /// <returns>Notita</returns>

        public List<String> GetNoteByID(in int id)
        {
            Record record = _notesRepository.GetNoteByID(id);
            List<String> list =  new List<String>();
            list.Add(record.ID.ToString());
            list.Add(record.Title);
            list.Add(record.Content);
            list.Add(record.Data);
            list.Add(record.Location);
            list.Add(record.Weather);
            return list;
        }

        /// <summary>
        /// Metoda care actualizeaza o anumite inregistrare din baza de date.
        /// </summary>
        /// <param name="title">Titlul</param>
        /// <param name="content">Continutul</param>
        /// <param name="data">Data activitati</param>
        /// <param name="location">Locatia</param>
        /// <param name="weather">Vremea</param>
        public void UpdateNote(int id,string title, string content, string data, string location, string weather)
        {
            _notesRepository.UpdateNote(new Record(id,title,content,data,location,weather));
        }

        /// <summary>
        /// Metoda care sterge o inregistrare din baza de date.
        /// </summary>
        /// <param name="id">Identificatorul notei de sters.</param>
        public void DeleteNote(in int id)
        {
            _notesRepository.DeleteNote(id);
        }

        /// <summary>
        /// Metoda care sterge toate inregistrarile din baza de date.
        /// </summary>
        public void DeleteAllNotes()
        {
            _notesRepository.DeleteAllNotes();
        }

        /// <summary>
        /// Functie care returneaza vremea
        /// </summary>
        /// <param name="location">Locatia</param>
        /// <param name="year">Anul</param>
        /// <param name="month">Luna</param>
        /// <param name="day">Ziua</param>
        /// <returns></returns>
        public string GetWeather(in string location, in string year, in string month, in string day)
        {
            try
            {
                _weatherMain = new WeatherMain();
                _weatherData = _weatherMain.WeatherForCity(location, year + "-" + month + "-" + day);// "2023-05-03"
                                                                                                     //WeatherData weatherData = weatherMain.weatherForCity("Harlau", "2023-05-03");

                //string weather = "The weather will have the following parameters:\n";
                if(_weatherData == null)
                    throw new Exception("We're sorry, but the website we're querying for weather information is not responding. Please try again later.");
                string weather = "\tDescriptions: " + WeatherCodes.weatherDescriptions[_weatherData.Daily.WeatherCode[0]] + "\r\n\t";
                weather += "Maximum temperature: " + _weatherData.Daily.Temperature2mMax[0] + "\r\n\t";
                weather += "Minimum temperature: " + _weatherData.Daily.Temperature2mMin[0] + "\r\n";
                //weather += "You want to change?\n";

                return weather;
            }
            catch (System.NullReferenceException)
            {
                // Tratează excepția System.NullReferenceException
                throw new Exception("We're sorry, but the website we're querying for weather information is not responding. Please try again later.");
            }
            catch (Exception)
            {
                throw new Exception("We're sorry, but the website we're querying for weather information is not responding. Please try again later.");
            }
        }
    }
}
