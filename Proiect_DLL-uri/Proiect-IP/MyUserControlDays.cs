/**************************************************************************
 *                                                                        *
 *  File:        INotesRepository.cs                                      *
 *  Copyright:   (c) 2023, Boaca Madalina-Elena                           *
 *  Description: Clasa pentru o casuta cu data                            *
 *                                                                        *
 *  This code and information is provided "as is" without warranty of     *
 *  any kind, either expressed or implied, including but not limited      *
 *  to the implied warranties of merchantability or fitness for a         *
 *  particular purpose. You are free to use this source code in your      *
 *  applications as long as the original copyright notice is included.    *
 *                                                                        *
 **************************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IP_Proiect
{
     /// <summary>
     /// Control-ul din biblioteca nu memora si data
     /// </summary>
    public partial class MyUserControlDays : UserControlDays
    {
        private string _date;

        public string Date
        {
            get { return _date; }
            set { _date = value; }
        }
    }
}
