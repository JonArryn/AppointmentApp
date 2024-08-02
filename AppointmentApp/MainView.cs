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

// TODO: Migrate LoginForm to MainView panel

namespace AppointmentApp
{

    public partial class MainView : Form
    {
        private readonly UserService _userService;

        public MainView()
        {
            InitializeComponent();
            _userService = ServiceLocator.Instance.UserService;
            ShowNavigation(false);
            LoadControl(new LoginControl(this));

        }

        private void LoadControl(UserControl control)
        {
            mainPanel.Controls.Clear();
            control.Dock = DockStyle.Fill;
            mainPanel.Controls.Add(control);
        }


        public void LoadMainPanelControl()
        {
            var customerControl = new CustomerControl();
            LoadControl(customerControl);
            ShowNavigation(true);
        }

        private void ShowNavigation(bool showNavigation)
        {
            this.customersButton.Visible = showNavigation;
            this.appointmentsButton.Visible = showNavigation;
            this.reportsButton.Visible = showNavigation;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void MainView_FormClosing_1(object sender, FormClosingEventArgs e)
        {
            var result = Messages.ShowQuestion("Exit Application", "Are you sure you want to exit the application? All unsaved work will be lost.");

            if (result == DialogResult.No)
            {
                e.Cancel = true;
            }
            else
            {
                Application.ExitThread();
            }
        }
    }
}
