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

        private LoginControl _loginControl;
        private CustomerControl _customerControl;
        private UpdateCustomerControl _updateCustomerControl;



        public MainView()
        {
            InitializeComponent();
            this.mainLayoutPanel.Visible = false;
            InitializeLoginControl();
        }
        // INITIALIZE CONTROLS //
        private void InitializeLoginControl()
        {
            _loginControl = new LoginControl();
            _loginControl.Dock = DockStyle.Fill;
            this.Controls.Add(_loginControl);
            _loginControl.LoginSuccessful += LoginControl_LoginSuccessful;
        }

        private void LoadCustomerControl()
        {
            if (this.customersTab.Controls.Count == 0)
            {
                _customerControl = new CustomerControl { Dock = DockStyle.Fill };
                this.customersTab.Controls.Add(_customerControl);
                _customerControl.UpdateCustomer += CustomerControl_UpdateCustomer;
                
            }
        }

        // EVENT HANDLERS //
        private void LoginControl_LoginSuccessful(object sender, EventArgs e)
        {
            _loginControl.Visible = false;
            this.mainLayoutPanel.Visible = true;
            LoadCustomerControl();
        }

        private void CustomerControl_UpdateCustomer(object sender, EventArgs e)
        {
           
            this.customersTab.Controls.Clear();
            _updateCustomerControl = new UpdateCustomerControl(_customerControl.GetSelectedCustomerId());
            _customerControl = null;
            this.customersTab.Controls.Add(_updateCustomerControl);
            _updateCustomerControl.CustomerUpdated += UpdateCustomerControl_CustomerUpdated;
        }

        private void UpdateCustomerControl_CustomerUpdated(object sender, EventArgs e)
        {
            this.customersTab.Controls.Clear();
            _updateCustomerControl = null;
            LoadCustomerControl();
        }

        // LOCAL EVENTS //

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
