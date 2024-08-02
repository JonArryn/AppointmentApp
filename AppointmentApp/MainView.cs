using AppointmentApp.Controls;
using AppointmentApp.Database;
using AppointmentApp.Service;
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
            LoadControl(new CustomerControl());
        }

        private void LoadControl(UserControl control)
        {
            // Clear existing controls
            mainPanel.Controls.Clear();
            control.Dock = DockStyle.Fill;
            mainPanel.Controls.Add(control);
        }

        private void MainView_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Show confirmation dialog
            var result = Messages.ShowQuestion("Exit Application", "Are you sure you want to exit the application? ALl unsaved work will be lost.");

            if (result == DialogResult.No)
            {
                // Cancel the close event
                e.Cancel = true;
            }
            else
            {
                // Close the application
                Application.Exit();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }


    }
}
