/**************************************************************************
 *                                                                        *
 *  File:        INotesRepository.cs                                      *
 *  Copyright:   (c) 2023, Boaca Madalina-Elena                           *
 *  E-mail:      madalina-elena.boaca@student.tuiasi.ro                   *
 *  Description: Interfata pentru operatiunile cu baza de date.           *
 *               Utila mai ales la o trecere eventuala la alt tip de baza *
 *               de date.                                                 *                                 
 *                                                                        *
 **************************************************************************/

using System.Collections.Generic;


namespace Persistence
{
    /// <summary>
    /// Interfata pentru efectuarea operatiilor cu baza de date
    /// </summary>
    public interface INotesRepository
    {
        /// <summary>
        /// Metoda care creaza baza de date(daca ea nu exista)
        /// </summary>
        void CreateTable();

        /// <summary>
        /// Metoda care adauga continutul unei note in baza de date
        /// </summary>
        /// <param name="record">Contine ca obiect datele de introdus.</param>
        void AddNotes(in Record record);

        /// <summary>
        /// Metoda care returnează toate notitele din baza de date.
        /// </summary>
        /// <returns>Un vector ce contine continutul bazai de date.</returns>
        Record[] GetAllNotes();

        /// <summary>
        /// Metoda care returnează toate notitele din baza de date dintr-o anumita data.
        /// </summary>
        /// <param name="date">Data de la care se doresc inregistrarile.</param>
        /// <returns>Un vector ce contine inregistrarile din baza de date, cu data specificata.</returns>
       Record[] GetNotesByDate(in string date);

        /// <summary>
        /// Metoda care returnează o notita cu un anumit ID.
        /// </summary>
        /// <param name="id">ID-ul notei.</param>
        /// <returns>Notita</returns>
        Record GetNoteByID(in int id);

        /// <summary>
        /// Metoda care actualizeaza o anumite inregistrare din baza de date.
        /// </summary>
        /// <param name="record">Element cu noile date.</param>
        void UpdateNote(in Record record);

        /// <summary>
        /// Metoda care sterge o inregistrare din baza de date.
        /// </summary>
        /// <param name="id">Identificatorul notei de sters.</param>
        void DeleteNote(in int id);

        /// <summary>
        /// Metoda care sterge toate inregistrarile din baza de date.
        /// </summary>
        void DeleteAllNotes();

        /// <summary>
        /// Metoda care returnează toate datele distincte din baza de date.
        /// </summary>
        List<string> GetAllDates();
    }
}
