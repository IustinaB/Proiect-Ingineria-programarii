/**************************************************************************
 *                                                                        *
 *  File:        Record.cs                                                *
 *  Copyright:   (c) 2023, Boaca Madalina-Elena                           *
 *  E-mail:      madalina-elena.boaca@student.tuiasi.ro                   *
 *  Description: Acest fisier contine clasa ce descrie structura unei     *
 *               inregistrari din baza de date folosita la transmiterea   *
 *               cererilor si raspunsurilor catre nivelul de persistenta. *
 **************************************************************************/

using System.Text.Json.Serialization;

namespace Persistence
{
    /// <summary>
    /// Clasa ce reda structura obiectelor in baza de date
    /// </summary>
    public class Record
    {

        #region Constructors
        /// <summary>
        /// Constructor 
        /// </summary>
        /// <param name="title">Titlul notitei.</param>
        /// <param name="content">Continutul notitei.</param>
        /// <param name="data">Data la care este planificata activitatea.</param>
        /// <param name="location">Locatia unde se va desfasura activitatea.</param>
        public Record( string title, string content, string data, string location,string weather)
        {
            Title = title;
            Content = content;
            Data = data;
            Location = location;
           Weather = weather;
        }


        /// <summary>
        /// Constructor, poate fi folosit si la deserializare
        /// </summary>
        /// <param name="id">Identificatorul notitei din baza de date.</param>
        /// <param name="title">Titlul notitei.</param>
        /// <param name="content">Continutul notitei.</param>
        /// <param name="data">Data la care este planificata activitatea.</param>
        /// <param name="location">Locatia unde se va desfasura activitatea.</param>
        [JsonConstructorAttribute]
        public Record(int id, string title, string content, string data, string location,string weather)
        {
           ID = id;
           Title = title;
            Content = content;
           Data = data;
            Location = location;
           Weather = weather;
        }
        

        /// <summary>
        /// Constructor 
        /// </summary>
        public Record()
        {

        }
        #endregion

        #region Getter-Setter
        public int ID
        {
            set; get;
        }
        public string Title
        {
            set; get;
        }
        public string Content
        {
            set; get;
        }
        public string Data
        {
            set; get;
        }
        public string Location
        {
            set;get;
        }

        public string Weather
        {
            set; get;
        }
        #endregion

        #region Show
        /// <summary>
        /// Afisarea mai facila a informatiilor, utila la debug
        /// </summary>
        public override string ToString()
        {
            return $"ID= {ID}\n title= {Title}\n content= {Content}\n data= {Data}\n location= {Location}\n" ;
        }
        #endregion
    }
}
