using AppointmentApp.Database;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

// TODO: by closing the window via the "X" the applicaiton is still running but all windows are closed
// TODO: add database reset and seed buttons to main form
// TODO: Inject the singleton userService to this form and figure out how to do that with a form that's not in the Program.cs file

namespace AppointmentApp
{

    public partial class MainView : Form
    {
        public MainView()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
