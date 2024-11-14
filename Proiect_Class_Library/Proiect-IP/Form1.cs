#region Headers
/**************************************************************************
 *                                                                        *
 *  File:        Forms1.cs                                                *
 *  Copyright:   (c) 2023, Iustina-Bianca Bulai                           *
 *  E-mail:      iustina-bianca.bulai@student.tuiasi.ro                   *
 *  Description: Realizarea interfetei grafice, implementarea functiilor  *
 *               de callback pentru butoanele menuButton, buttonHome,     * 
 *               buttonHelp, buttonAbout, buttonNext, buttonPrev          *
 *               si functia displayCalendar()                             *
 *               Implementarea operatiilor de adaugare, modificare,       *
 *               stergere prin functiile corespunzatoare.                 *
 *                                                                        *
 *                                                                        *
 *  Revision:    1.3                                                      *
 *               Reviewer: Gabriel Pojoga                                 *
 *               Reviewer e-mail: gabriel.pojoga@student.tuiasi.ro        *
 *                                                                        *
 *               Schimbare nume functie de callback pentru butonul info   *
 *               din interfata, numele nou: buttonInfo_Click.             *
 *               Functionalitate butonului "Info" pentru deschiderea      *
 *               fisierului NotesApp.chm.                                 *
 *                                                                        *
 *               1.2                                                      *
 *               Reviewer: Madalina-Elena Boaca                           *  
 *               Reviewer e-mail: madalina-elena.boaca@student.tuiasi.ro  *
 *                                                                        *
 *               Modificare structura apeluri prin adaugarea Fatadei      *
 *               pentru cresterea abstractizarii celor doua module.       *
 *               
 *               1.1                                                      *
 *               Reviewer: Madalina-Elena Boaca                           *  
 *               Reviewer e-mail: madalina-elena.boaca@student.tuiasi.ro  *
 *                                                                        *
 *               Implementare vizualizare notite prin adaugarea functiilor*
 *               UserControlDays_Click,listBoxNotes_DrawItem,             *
 *               listBoxAllNotes_DrawItem,buttonGetAll_Click.             *
 *                                                                        *
 *                                                                        *
 **************************************************************************/

#endregion

#region Includes
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
#endregion

namespace IP_Proiect
{
    /// <summary>
    /// Clasa pentru interfata grafica
    /// </summary>
    public partial class Form1 : Form
    {
        //pentru bara de meniu
        bool _isSidebarExpand = true; //initial bara de meniu este extinsa
        bool _isHomeExpand;
        bool _isHelpExpand;

        //pentru calendar
        static DateTime _currentDate = DateTime.Now;
        static int _currentYear = _currentDate.Year;
        static int _currentMonth = _currentDate.Month;

        //pentru modificari asupra unei note
        private Dictionary<int, string> _myDictionaryStringNote;
        private string _selectedText;
        private string _selectedDate;
        private string _selectedDateUC;
        private bool _getAllIsCall;
        MyUserControlDays lastucday; //se va retine obiectul ce contine ultima zi pe care s-a dat click
        int _isSelected = 1; //pentru schimbarea culorii obiectului de tip MyUserControl
        int selectedday; //pentru a sti daca o data este selectata din Calendarul realizat cu UserControlDays

        private FacadeMethods _facadeMethods;

        /// <summary>
        /// Constructor
        /// </summary>
        public Form1()
        {
            InitializeComponent();
            displayCalendar();

            //fatada
            _facadeMethods = new FacadeMethods();
            _facadeMethods.CreateTable();

            //meniu operatie(la selectarea unei anumite date) 
            ContextMenu contextMenu = new ContextMenu();
            MenuItem menuItem = new MenuItem("Edit");
            menuItem.Click += new EventHandler(editItem_Click);
            contextMenu.MenuItems.Add(menuItem);
            menuItem = new MenuItem("Delete");
            menuItem.Click += new EventHandler(deleteItem_Click);
            contextMenu.MenuItems.Add(menuItem);
            listBoxNotes.ContextMenu = contextMenu;

            //listbox pentru toate notele
            ContextMenu contextMenuAll = new ContextMenu();
            MenuItem menuItemAll = new MenuItem("Edit");
            menuItemAll.Click += new EventHandler(editItemAll_Click);
            contextMenuAll.MenuItems.Add(menuItemAll);
            menuItemAll = new MenuItem("Delete");
            menuItemAll.Click += new EventHandler(deleteItemAll_Click);
            contextMenuAll.MenuItems.Add(menuItemAll);
            listBoxAllNotes.ContextMenu = contextMenuAll;
            _myDictionaryStringNote = new Dictionary<int, string>();
        }

        /// <summary>
        /// Metoda pentru expandarea/minimizarea barei de meniu
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void sidebarTimer_Tick(object sender, EventArgs e)
        {
            //metoda pentru extinderea barei de meniu (se apasa pe icon ul de langa meniu)
            if (_isSidebarExpand)
            {
                //bara de meniu expandata, se va minimiza
                sidebarMenu.Width -= 10;
                if (sidebarMenu.Width == sidebarMenu.MinimumSize.Width)
                {
                    _isSidebarExpand = false;
                    sidebarTimer.Stop();
                    //cand se minimizeaza meniul, se va muta si pozitia groupbox ului
                    groupBoxNote.Location = new Point(124, 2);
                    buttonHome.Enabled = false;
                    buttonHelp.Enabled = false;
                    buttonAbout.Enabled = false;
                    buttonDelete.Enabled = false;
                    buttonNew.Enabled = false;
                    buttonModify.Enabled = false;
                    buttonInfo.Enabled = false;
                }
            }
            else
            {
                //bara de meniu minimizata, se va expanda la atingerea icon-ului pentru meniu
                sidebarMenu.Width += 10;
                if (sidebarMenu.Width == sidebarMenu.MaximumSize.Width)
                {
                    _isSidebarExpand = true;
                    sidebarTimer.Stop();
                    groupBoxNote.Location = new Point(176, 2);
                    buttonHome.Enabled = true;
                    buttonHelp.Enabled = true;
                    buttonAbout.Enabled = true;
                    buttonDelete.Enabled = true;
                    buttonNew.Enabled = true;
                    buttonModify.Enabled = true;
                    buttonInfo.Enabled = true;
                }
            }


        }

        /// <summary>
        /// Metoda pentru activarea animatiei barei de meniu la apasarea icon-ului cu 3 linii
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuButton_Click(object sender, EventArgs e)
        {
            //la apasarea butonului, se va modifica dimensiunea barei de meniu
            sidebarTimer.Start();
        }

        /// <summary>
        /// Metoda pentru expandarea/minimizarea butonului de Home
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void homeTimer_Tick(object sender, EventArgs e)
        {
            //metoda pentru extinderea butonului Home
            if (_isHomeExpand)
            {
                panelHome.Height -= 10;
                if (panelHome.Height == panelHome.MinimumSize.Height)
                {
                    _isHomeExpand = false;
                    homeTimer.Stop();
                }
            }
            else
            {
                panelHome.Height += 10;
                if (panelHome.Height == panelHome.MaximumSize.Height)
                {
                    _isHomeExpand = true;
                    homeTimer.Stop();
                }
            }
        }

        /// <summary>
        /// Metoda pentru activarea animatiei butonului de Home
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonHome_Click(object sender, EventArgs e)
        {
            //la apasarea butonului, vor aparea mai multe optiuni din Home
            homeTimer.Start();
        }

        /// <summary>
        /// Metoda pentru expandarea/minimizarea butonului de Help
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void helpTimer_Tick(object sender, EventArgs e)
        {
            if (_isHelpExpand)
            {
                //se minimizeaza
                panelHelp.Height -= 10;
                if (panelHelp.Height == panelHelp.MinimumSize.Height)
                {
                    _isHelpExpand = false;
                    helpTimer.Stop();
                }
            }
            else
            {
                //se extinde
                panelHelp.Height += 10;
                if (panelHelp.Height == panelHelp.MaximumSize.Height)
                {
                    _isHelpExpand = true;
                    helpTimer.Stop();
                }
            }
        }

        /// <summary>
        /// Metoda pentru activarea animatiei la apasarea butonului de Help
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonHelp_Click(object sender, EventArgs e)
        {
            //la apasarea butonului, va aparea optiunea About
            helpTimer.Start();
        }

        /// <summary>
        /// Metoda pentru afisarea calendarului pe interfata
        /// </summary>
        private void displayCalendar()
        {
            //afisare luna, an
            String monthName = DateTimeFormatInfo.CurrentInfo.GetMonthName(_currentMonth);
            labelLunaAn.Text = monthName + " " + _currentYear;

            //prima zi din luna
            DateTime firstday = new DateTime(_currentYear, _currentMonth, 1);

            //numarul de zile din luna curenta
            int days = DateTime.DaysInMonth(_currentYear, _currentMonth);

            //ziua curenta convertita la int
            int currentday = Convert.ToInt32(firstday.DayOfWeek.ToString("d")) + 1;

            for (int i = 1; i < currentday; i++)
            {
                //se adauga obiecte de tip usercontrol goale(aceeasi culoare ca background ul)
                UserControlEmpty ucempty = new UserControlEmpty();

                panelDay.Controls.Add(ucempty);
            }

            for (int i = 1; i <= days; i++)
            {
                //se adauga obiectele de tip usercontrol care vor fi efectiv panel urile cu zilele lunii
                MyUserControlDays ucdays = new MyUserControlDays();
                ucdays.Days(i);

                ucdays.Date = _currentYear + "-" + _currentMonth.ToString().PadLeft(2, '0') + "-" + i.ToString().PadLeft(2, '0');

                //inregistrare callback pentru apasare pe o data
                ucdays.Click += new EventHandler(UserControlDays_Click);
                panelDay.Controls.Add(ucdays);

            }

        }

        /// <summary>
        /// Eveniment declansat la apasarea unei date
        /// </summary>
        /// <param name="sender">Obiectul care a declansat evenimentul</param>
        /// <param name="e">Informatii despre eveniment</param>
        private void UserControlDays_Click(object sender, EventArgs e)
        {
            // vizibilitate contoare
            labelNumberOfNotes.Visible = true;
            listBoxNotes.Visible = true;
            richTextBoxNewNote.Visible = true;
            dateTimePickerNote.Visible = false;
            textBoxLocation.Visible = true;
            textBoxTitle.Visible = true;
            buttonAddNote.Visible = true;
            buttonEditNote.Visible = false;
            listBoxAllNotes.Visible = false;
            labelAllNotes.Visible = false;
            MyUserControlDays selectedDay = (MyUserControlDays)sender;
            _selectedDateUC = selectedDay.Date;

            richTextBoxNewNote.Clear();
            textBoxLocation.Text = "Location";
            textBoxTitle.Text = "Title";

            //modul fix, apar probleme la \n
            listBoxNotes.DrawMode = DrawMode.OwnerDrawVariable;
            listBoxNotes.ItemHeight = 200;//lungme maxima
            listBoxNotes.Items.Clear();

            //selectez tot din acea data
            Dictionary<int, String> myListOfNotes = _facadeMethods.GetNotesByDate(_selectedDateUC);

            //eticheta cu numarul de notite
            labelNumberOfNotes.Text = "The number of notes is " + myListOfNotes.Count;

            labelAllNotes.Text = "The number of notes is " + myListOfNotes.Count;
            //adaugare notite pe interfata
            foreach (String note in myListOfNotes.Values)
            {
                listBoxNotes.Items.Add(note);
                listBoxAllNotes.Items.Add(note);
                try
                {
                    _myDictionaryStringNote = myListOfNotes;
                }
                catch (ArgumentException exception)
                {
                    //nu fac nimic e legata de faptul ca e deja in baza de date
                }
            }

            //font
            Font font = new Font("Arial", 10, FontStyle.Regular);
            listBoxNotes.Font = font;
            listBoxAllNotes.Font = font;

            selectedday = 1; //s-a apasat pe o data din calendarul realizat cu user control

            //schimbarea culorii atunci cand o data este selectata
            if (_isSelected == 1) //cand se da click pentru prima data dupa lansarea in executie a aplicatiei
            {
                lastucday = selectedDay;
                lastucday.BackColor = Color.LightGray;
                _isSelected = 0;

            }
            else
            {
                //cazul in care selectez aceeasi data consecutiv
                if (selectedDay == lastucday)
                {
                    lastucday = selectedDay;
                    lastucday.BackColor = Color.LightGray;
                }
                else
                {
                    selectedDay.BackColor = Color.LightGray;
                    lastucday.BackColor = Color.White;
                }
            }
            //se va retine ultima zi
            lastucday = selectedDay;


        }

        /// <summary>
        /// DrawItem pentru a desena fiecare element manual
        /// </summary>
        /// <param name="sender">Obiectul care a declansat evenimentul</param>
        /// <param name="e">Informatii despre eveniment</param>
        private void listBoxNotes_DrawItem(object sender, DrawItemEventArgs e)
        {
            //fundal
            e.DrawBackground();

            // extragerea textului elementului ListBox
            try
            {
                string text = listBoxNotes.Items[e.Index].ToString();

                // desenare text in ListBox
                e.Graphics.DrawString(text, Font, Brushes.Black, e.Bounds);
                using (Pen pen = new Pen(Color.Black))
                {
                    e.Graphics.DrawLine(pen, e.Bounds.X, e.Bounds.Bottom - 1, e.Bounds.Right, e.Bounds.Bottom - 1);
                }
                // desenare cadru al elementului ListBox(evidentiere mai clara)
                e.DrawFocusRectangle();
            }
            catch (ArgumentOutOfRangeException)
            {
                //nu am elemente
            }
        }

        /// <summary>
        /// DrawItem pentru a desena fiecare element manual
        /// </summary>
        /// <param name="sender">Obiectul care a declansat evenimentul</param>
        /// <param name="e">Informatii despre eveniment</param>
        private void listBoxAllNotes_DrawItem(object sender, DrawItemEventArgs e)
        {
            //fundal
            e.DrawBackground();

            // extragerea textului elementului ListBox
            try
            {
                string text = listBoxAllNotes.Items[e.Index].ToString();

                // desenare text in ListBox
                e.Graphics.DrawString(text, Font, Brushes.Black, e.Bounds);
                using (Pen pen = new Pen(Color.Black))
                {
                    e.Graphics.DrawLine(pen, e.Bounds.X, e.Bounds.Bottom - 1, e.Bounds.Right, e.Bounds.Bottom - 1);
                }
                // desenare cadru al elementului ListBox(evidentiere mai clara)
                e.DrawFocusRectangle();
            }
            catch (ArgumentOutOfRangeException)
            {
                //nu am elemente
            }
        }

        /// <summary>
        /// Metoda apelata la apasarea pe butonul Next
        /// </summary>
        /// <param name="sender">Obiectul care a declansat evenimentul</param>
        /// <param name="e">Informatii despre eveniment</param>
        private void buttonNext_Click(object sender, EventArgs e)
        {
            //calendar
            panelDay.Controls.Clear();
            if (_currentMonth == 12)
            {
                _currentMonth = 0;
                _currentYear++;
            }
            _currentMonth += 1;

            displayCalendar();
        }

        /// <summary>
        /// Metoda apelata atunci cand se apasa pe butonul prev
        /// </summary>
        /// <param name="sender">Obiectul care a declansat evenimentul</param>
        /// <param name="e">Informatii despre eveniment</param>
        private void buttonPrev_Click(object sender, EventArgs e)
        {
            //calendar
            panelDay.Controls.Clear();
            if (_currentMonth == 1)
            {
                //se pune 13, desi sunt 12 luni ca e ceva chestie de la visual
                _currentMonth = 13;
                _currentYear--;

            }
            _currentMonth -= 1;
            displayCalendar();
        }

        /// <summary>
        /// Metoda apelata la apasarea butonului New va determina deschiderea meniului pentru adaugarea unei noi note
        /// </summary>
        /// <param name="sender">Obiectul care a declansat evenimentul</param>
        /// <param name="e">Informatii despre eveniment</param>
        private void buttonNew_Click(object sender, EventArgs e)
        {
            //adaugare notita, momentan le fac vizible ca mai apoi sa facem legatura cu baza de date
            textBoxTitle.Text = "Title";
            richTextBoxNewNote.Visible = true;
            dateTimePickerNote.Visible = true;
            textBoxLocation.Visible = true;
            textBoxTitle.Visible = true;
            buttonAddNote.Visible = true;
            textBoxLocation.Text = "Location";
            listBoxNotes.Visible = false;
            labelNumberOfNotes.Visible = false;
            buttonEditNote.Visible = false;
            richTextBoxNewNote.Text = "";
            listBoxAllNotes.Visible = false;
            labelAllNotes.Visible = false;

            if (selectedday == 1)
            {
                lastucday.BackColor = Color.White;
                selectedday = 0;
            }
        }

        /// <summary>
        /// Metoda care contine procedura de pregatire a inserari in baza de date
        /// </summary>
        /// <param name="sender">Obiectul care a declansat evenimentul</param>
        /// <param name="e">Informatii despre eveniment</param>
        private void buttonAddNote_Click(object sender, EventArgs e)
        {
            // parametri din interfata
            // trebuie sa aiba un anumit format
            string day = dateTimePickerNote.Value.Date.Day.ToString();
            day = day.PadLeft(2, '0');
            string month = dateTimePickerNote.Value.Month.ToString();
            month = month.PadLeft(2, '0');
            string year = dateTimePickerNote.Value.Year.ToString();
            string location = textBoxLocation.Text;
            string title = textBoxTitle.Text;
            string content = richTextBoxNewNote.Text;
            if (selectedday == 0) //apasat pe new
            {
                _selectedDate = year + "-" + month + "-" + day;
            }
            else
            {
                _selectedDate = _selectedDateUC;
            }
            //_selectedDate = year + "-" +  month  + "-"+ day;
            Console.WriteLine(_selectedDate);
            try
            {

                // construire string cu vremea

                labelGet.Visible = true;
                string weather = _facadeMethods.GetWeather(location, year, month, day);
                labelGet.Visible = false;
                //selectarea adaugari sau nu a notei
                DialogResult result = MessageBox.Show("The weather will have the following parameters:\n" + weather + "You want to add?\n", "Weather", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    // acțiunea când utilizatorul apasă butonul "Da"
                    _facadeMethods.AddNotes(title, content, _selectedDate, location, weather);
                    listBoxNotes.Items.Clear();
                    Dictionary<int, string> myListOfNotes;
                    myListOfNotes = _facadeMethods.GetNotesByDate(_selectedDate);

                    labelNumberOfNotes.Text = "Number of notes: " + myListOfNotes.Count;
                    foreach (string record in myListOfNotes.Values)
                    {
                        listBoxNotes.Items.Add(record);
                        listBoxAllNotes.Items.Add(record);
                    }


                    MessageBox.Show("The note has been added successfully!");
                    listBoxNotes.Invalidate();
                    listBoxNotes.Refresh();
                    richTextBoxNewNote.Clear();
                    textBoxLocation.Text = "Location";
                    textBoxTitle.Text = "Title";
                }
                else
                {
                    MessageBox.Show("The note was not added!");
                }

            }
            catch (System.NullReferenceException)
            {
                MessageBox.Show("I'm sorry, but there is no weather forecast for this date.");
                labelGet.Visible = false;
            }
            catch (Exception exception)
            {
                labelGet.Visible = false;
                DialogResult result = MessageBox.Show(exception.Message + "\nHowever, you want to add the note without weather", "Confirmation", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    _facadeMethods.AddNotes(title, content, _selectedDate, location, "");

                    //ca sa se poata vedea notita si daca nu s epot lua datele din API
                    listBoxNotes.Items.Clear();
                    Dictionary<int, string> myListOfNotes;
                    if (!_getAllIsCall)
                        myListOfNotes = _facadeMethods.GetNotesByDate(_selectedDate);
                    else
                        myListOfNotes = _facadeMethods.GetAllNotes();

                    labelNumberOfNotes.Text = "Number of notes: " + myListOfNotes.Count;
                    foreach (string record in myListOfNotes.Values)
                    {
                        listBoxNotes.Items.Add(record);
                    }
                    MessageBox.Show("The note has been added successfully!");
                    listBoxNotes.Invalidate();
                    listBoxNotes.Refresh();
                    richTextBoxNewNote.Clear();
                    textBoxLocation.Text = "Location";
                    textBoxTitle.Text = "Title";
                }
            }
        }

        /// <summary>
        /// Metoda apelata cand se doreste stergerea tuturor notelor
        /// </summary>
        /// <param name="sender">Obiectul care a declansat evenimentul</param>
        /// <param name="e">Informatii despre eveniment</param>
        private void buttonDeleteAll_Click(object sender, EventArgs e)
        {
            //aici ma gandesc sa se ia din baza de date notitele existente si sa se afiseze in groupbox
            //ca mai apoi sa fie modificate
            textBoxTitle.Visible = false;
            richTextBoxNewNote.Visible = false;
            dateTimePickerNote.Visible = false;
            buttonAddNote.Visible = false;
            textBoxLocation.Visible = false;
            listBoxAllNotes.Visible = true;
            labelAllNotes.Visible = true;
            listBoxNotes.Visible = false;
            labelNumberOfNotes.Visible = false;
            listBoxAllNotes.Visible = false;
            labelAllNotes.Visible = false;
            try
            {
                DialogResult result = MessageBox.Show("Are you sure you want to delete everything?", "Delete all", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    _facadeMethods.DeleteAllNotes();
                    listBoxNotes.Items.Clear();
                    listBoxAllNotes.Items.Clear();
                    //reafisare
                    listBoxAllNotes.Invalidate();
                    listBoxAllNotes.Refresh();
                    labelAllNotes.Text = "The number of notes is 0";
                    MessageBox.Show("All notes have been deleted from the database!");
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.ToString());
            }
        }

        /// <summary>
        /// Metoda care afiseaza toate notitele
        /// </summary>
        /// <param name="sender">Obiectul care a declansat evenimentul</param>
        /// <param name="e">Informatii despre eveniment</param>
        private void buttonGetAll_Click(object sender, EventArgs e)
        {
            //sa apara tot asa notitele in groupbox si sa fie posibilitatea de a le sterge, implicit sa dispara si din caledar
            textBoxTitle.Visible = false;
            richTextBoxNewNote.Visible = false;
            dateTimePickerNote.Visible = false;
            buttonAddNote.Visible = false;
            textBoxLocation.Visible = false;
            labelNumberOfNotes.Visible = false;
            //modul fix, apar probleme la \n
            listBoxAllNotes.DrawMode = DrawMode.OwnerDrawVariable;
            listBoxAllNotes.ItemHeight = 255;//lungme maxima
            listBoxAllNotes.Items.Clear();
            listBoxNotes.Visible = false;
            Dictionary<int, string> listOfAllNotes = _facadeMethods.GetAllNotes();
            labelAllNotes.Visible = true;
            buttonEditNote.Visible = false;
            //eticheta cu numarul de notite
            labelAllNotes.Text = "The number of notes is " + listOfAllNotes.Count;
            _getAllIsCall = true;
            //adaugare notite pe interfata
            foreach (KeyValuePair<int, string> record in listOfAllNotes)
            {
                listBoxAllNotes.Items.Add(record.Value);
                try
                {
                    _myDictionaryStringNote.Add(record.Key, record.Value);
                }
                catch (ArgumentException exception)
                {
                    //e legata daca am in lista
                }
            }

            //font
            listBoxAllNotes.Visible = true;
            Font font = new Font("Arial", 10, FontStyle.Regular);
            listBoxAllNotes.Font = font;
        }

        /// <summary>
        /// Metoda apelata cand se doresc informatii despre aplicatie
        /// </summary>
        /// <param name="sender">Obiectul care a declansat evenimentul</param>
        /// <param name="e">Informatii despre eveniment</param>
        private void buttonAbout_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Weather-based scheduler\n" +
                "Version 1.0.0\n" +
                "Course: Software Engineering\n" +
                "(c)2023 Boaca Madalina-Elena, Bulai Iustina-Bianca, Ivanov Alexandru, Pojoga Gabriel");
        }


        /// <summary>
        /// Funcția apelată atunci când se modifica o notita
        /// </summary>
        /// <param name="sender">Obiectul care a declansat evenimentul</param>
        /// <param name="e">Informatii despre eveniment</param>
        private void editItem_Click(object sender, EventArgs e)
        {
            //modificare(aceleasi contoare ca la adaugare doar ca am deja datele in interior si o fac dupa id)
            richTextBoxNewNote.Visible = true;
            dateTimePickerNote.Visible = true;
            textBoxLocation.Visible = true;
            textBoxTitle.Visible = true;
            buttonAddNote.Visible = false;
            buttonEditNote.Visible = true;
            listBoxNotes.Visible = false;
            labelNumberOfNotes.Visible = false;
            listBoxAllNotes.Visible = false;
            labelAllNotes.Visible = false;
            //id-ul notei selectate
            int id = _myDictionaryStringNote.FirstOrDefault(x => x.Value == _selectedText).Key;

            if (id == 0)
            {
                _selectedText += "\r\n";
                id = _myDictionaryStringNote.FirstOrDefault(x => x.Value == _selectedText).Key;
            }
            //notita de modificat
            List<string> record = _facadeMethods.GetNoteByID(id);

            //setare valori
            /*
             list.Add(record.ID.ToString());
             list.Add(record.Title);//1
             list.Add(record.Content);//2
             list.Add(record.Data);//3
             list.Add(record.Location);//4
             list.Add(record.Weather);
             */
            textBoxTitle.Text = record[1];
            textBoxLocation.Text = record[4];
            richTextBoxNewNote.Text = record[2];
            try
            {
                dateTimePickerNote.Value = DateTime.Parse(record[3]);
            }
            catch (Exception ex)
            {

            }
        }

        /// <summary>
        /// Stergerea unui element
        /// </summary>
        /// <param name="sender">Obiectul care a declansat evenimentul</param>
        /// <param name="e">Informatii despre eveniment</param>
        private void deleteItem_Click(object sender, EventArgs e)
        {
            //id-ul notei de sters 
            int id = _myDictionaryStringNote.FirstOrDefault(x => x.Value == _selectedText).Key;
            if (id == 0)
            {
                _selectedText += "\r\n";
                id = _myDictionaryStringNote.FirstOrDefault(x => x.Value == _selectedText).Key;
            }
            if (id == 0)
            {
                _selectedText += "\r\n";
                id = _myDictionaryStringNote.FirstOrDefault(x => x.Value == _selectedText).Key;
            }
            //stergere nota
            _facadeMethods.DeleteNote(id);

            //reafisare
            listBoxNotes.Items.Clear();
            listBoxAllNotes.Items.Clear();
            Dictionary<int, string> myListOfNotes;
            if (!_getAllIsCall)
                myListOfNotes = _facadeMethods.GetNotesByDate(_selectedDate);
            else
                myListOfNotes = _facadeMethods.GetAllNotes();
            labelAllNotes.Text = "Number of notes: " + myListOfNotes.Count;
            labelNumberOfNotes.Text = "Number of notes: " + myListOfNotes.Count;
            foreach (string record in myListOfNotes.Values)
            {
                listBoxAllNotes.Items.Add(record);
                listBoxNotes.Items.Add(record);
            }

            Font font = new Font("Arial", 10, FontStyle.Regular);
            listBoxNotes.Font = font;

            //reafisare
            listBoxNotes.Invalidate();
            listBoxNotes.Refresh();
            listBoxAllNotes.Invalidate();
            listBoxAllNotes.Refresh();
        }

        /// <summary>
        /// Memorare text pe care sunt cu mouse-ul(cel pentru care se apeleaza edit, delete)
        /// </summary>
        /// <param name="sender">Obiectul care a declansat evenimentul</param>
        /// <param name="e">Informatii despre eveniment</param>
        private void listBoxNotes_MouseMove(object sender, MouseEventArgs e)
        {
            int index = listBoxNotes.IndexFromPoint(e.Location);

            if (index >= 0 && index < listBoxNotes.Items.Count)
            {
                string text = listBoxNotes.Items[index].ToString();
                _selectedText = text;
            }
        }

        /// <summary>
        /// Memorare text pe care sunt cu mouse-ul(cel pentru care se apeleaza edit, delete)
        /// </summary>
        /// <param name="sender">Obiectul care a declansat evenimentul</param>
        /// <param name="e">Informatii despre eveniment</param>
        private void listBoxAllNotes_MouseMove(object sender, MouseEventArgs e)
        {
            int index = listBoxAllNotes.IndexFromPoint(e.Location);

            if (index >= 0 && index < listBoxAllNotes.Items.Count)
            {
                string text = listBoxAllNotes.Items[index].ToString();
                _selectedText = text;
            }
        }

        /// <summary>
        /// Editarea unui notite
        /// </summary>
        /// <param name="sender">Obiectul care a declansat evenimentul</param>
        /// <param name="e">Informatii despre eveniment</param>
        private void buttonEditNote_Click(object sender, EventArgs e)
        {
            //date pentru editare
            string day = dateTimePickerNote.Value.Date.Day.ToString();
            day = day.PadLeft(2, '0');
            string month = dateTimePickerNote.Value.Month.ToString();
            month = month.PadLeft(2, '0');
            string year = dateTimePickerNote.Value.Year.ToString();

            string location = textBoxLocation.Text;
            string title = textBoxTitle.Text;
            string content = richTextBoxNewNote.Text;
            string date = year + "-" + month + "-" + day;

            //id-ul notei ce se editeaza
            int id = _myDictionaryStringNote.FirstOrDefault(x => x.Value == _selectedText).Key;
            if (id == 0)
            {
                _selectedText += "\r\n";
                id = _myDictionaryStringNote.FirstOrDefault(x => x.Value == _selectedText).Key;
            }

            try
            {
                labelGet.Visible = true;
                string weather = _facadeMethods.GetWeather(location, year, month, day);
                labelGet.Visible = false;
                DialogResult result = MessageBox.Show("The weather will have the following parameters:\n" + weather + "You want to change?\n", "Weather", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    _facadeMethods.UpdateNote(id, title, content, date, location, weather);
                    MessageBox.Show("The note has been successfully modified!");
                    richTextBoxNewNote.Clear();
                    textBoxLocation.Text = "Location";
                    textBoxTitle.Text = "Title";

                }
                else
                {

                    MessageBox.Show("The grade has not been modified.");
                }
            }
            catch (Exception exception)
            {
                labelGet.Visible = false;
                DialogResult result = MessageBox.Show(exception.Message + "\nHowever, you want to edit the note without weather?", "Confirmation", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    _facadeMethods.UpdateNote(id, title, content, date, location, "");
                    MessageBox.Show("The note has been successfully modified!");
                }
            }
        }

        /// <summary>
        /// Stergerea unui element
        /// </summary>
        /// <param name="sender">Obiectul care a declansat evenimentul</param>
        /// <param name="e">Informatii despre eveniment</param>
        private void deleteItemAll_Click(object sender, EventArgs e)
        {
            //id-ul notei de sters 
            int id = _myDictionaryStringNote.FirstOrDefault(x => x.Value == _selectedText).Key;
            if (id == 0)
            {
                _selectedText += "\r\n";
                id = _myDictionaryStringNote.FirstOrDefault(x => x.Value == _selectedText).Key;
            }

            //stergere nota
            _facadeMethods.DeleteNote(id);

            //reafisare
            listBoxAllNotes.Items.Clear();
            Dictionary<int, string> myListOfNotes;
            if (!_getAllIsCall)
                myListOfNotes = _facadeMethods.GetNotesByDate(_selectedDate);
            else
                myListOfNotes = _facadeMethods.GetAllNotes();
            labelAllNotes.Text = "Number of notes: " + myListOfNotes.Count;
            labelNumberOfNotes.Text = "Number of notes: " + myListOfNotes.Count;
            foreach (string record in myListOfNotes.Values)
            {
                listBoxAllNotes.Items.Add(record);
            }

            Font font = new Font("Arial", 10, FontStyle.Regular);
            listBoxAllNotes.Font = font;

            //reafisare

            listBoxAllNotes.Invalidate();
            listBoxAllNotes.Refresh();
        }

        /// <summary>
        /// Funcția apelată atunci când se modifica o notita
        /// </summary>
        /// <param name="sender">Obiectul care a declansat evenimentul</param>
        /// <param name="e">Informatii despre eveniment</param>
        private void editItemAll_Click(object sender, EventArgs e)
        {
            //modificare(aceleasi contoare ca la adaugare doar ca am deja datele in interior si o fac dupa id)
            richTextBoxNewNote.Visible = true;
            dateTimePickerNote.Visible = true;
            textBoxLocation.Visible = true;
            textBoxTitle.Visible = true;
            buttonAddNote.Visible = false;
            buttonEditNote.Visible = true;
            listBoxNotes.Visible = false;
            labelNumberOfNotes.Visible = false;
            listBoxAllNotes.Visible = false;
            labelAllNotes.Visible = false;
            //id-ul notei selectate
            int id = _myDictionaryStringNote.FirstOrDefault(x => x.Value == _selectedText).Key;
            if (id == 0)
            {
                _selectedText += "\r\n";
                id = _myDictionaryStringNote.FirstOrDefault(x => x.Value == _selectedText).Key;
            }

            //notita de modificat
            List<string> record = _facadeMethods.GetNoteByID(id);

            textBoxTitle.Text = record[1];
            textBoxLocation.Text = record[4];
            richTextBoxNewNote.Text = record[2];
            try
            {
                dateTimePickerNote.Value = DateTime.Parse(record[3]);
            }
            catch (Exception ex)
            {

            }
        }

        /// <summary>
        /// Metoda pentru afisarea help-ului.
        /// </summary>
        /// <param name="sender">Obiectul care a declansat evenimentul</param>
        /// <param name="e">Informatii despre eveniment</param>
        private void buttonInfo_Click(object sender, EventArgs e)
        {
            // deschide folderul din care ruleaza aplicatia, urca un nivel si apoi cauta folderul resources
            string parentDirectory = Directory.GetParent(Directory.GetParent(Application.StartupPath).FullName).FullName;
            string resourcesFolder = Path.Combine(parentDirectory, "Resources");
            string helpFilePath = Path.Combine(resourcesFolder, "NotesApp.chm");
            Help.ShowHelp(this, helpFilePath);
        }
    }
}

