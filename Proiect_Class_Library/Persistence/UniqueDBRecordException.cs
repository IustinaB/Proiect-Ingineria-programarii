/**************************************************************************
 *                                                                        *
 *  File:        UniqueDBRecordException.cs                               *
 *  Copyright:   (c) 2023, Boaca Madalina-Elena                           *
 *  E-mail:      madalina-elena.boaca@student.tuiasi.ro                   *
 *  Description: Acest fisier contine clasa pentru exceptia particulara,  *
 *               am presupus ca nu pot fi doua inregistrari cu aceleasi   *
 *               valori.                                                  *
 **************************************************************************/

using System;

namespace Persistence
{
    /// <summary>
    /// Clasa pentru exceptia particulara, imposibilitatea salvari a doua note cu acelasi date.
    /// </summary>
    public class UniqueDBRecordException : Exception 
    {
        public UniqueDBRecordException(in string message) : base(message)
        {

        }
    }
}
