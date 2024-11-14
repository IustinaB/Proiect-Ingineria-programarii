using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IP_Proiect
{
    public partial class UserControlDays : UserControl
    {
        
        public UserControlDays()
        {
            InitializeComponent();
        }
        
        public void Days(int day)
        {
            //in fiecare panel va fi un label ce va contine fiecare zi din luna
            labelDays.Text = day+" ";
        }

    }
}
