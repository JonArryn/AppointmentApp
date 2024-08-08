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
        private ManageCustomerControl _manageCustomerControl;
        private AppointmentControl _appointmentControl;



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
                _customerControl.CreateCustomer += CustomerControl_CreateCustomer;
                
            }
        }

        private void LoadAppointmentControl()
        {
            if(this.appointmentsTab.Controls.Count == 0)
            {
                _appointmentControl = new AppointmentControl { Dock = DockStyle.Fill };
                this.appointmentsTab.Controls.Add(_appointmentControl);
            }
        }

        // EVENT SUBSCRIPTION HANDLERS //
        private void LoginControl_LoginSuccessful(object sender, EventArgs e)
        {
            _loginControl.Visible = false;
            this.mainLayoutPanel.Visible = true;
            LoadCustomerControl();
            
        }

        private void CustomerControl_UpdateCustomer(object sender, EventArgs e)
        {
           
            this.customersTab.Controls.Clear();
            _manageCustomerControl = new ManageCustomerControl(_customerControl.GetSelectedCustomerId());
            this.customersTab.Controls.Add(_manageCustomerControl);
            _manageCustomerControl.Dock = DockStyle.Fill;
            _customerControl = null;
            _manageCustomerControl.CustomerUpdated += ManageCustomerControl_CustomerUpdated;
            _manageCustomerControl.CancelUpdateCustomer += ManageCustomerControl_CancelUpdateCustomer;
        }

        private void ManageCustomerControl_CustomerUpdated(object sender, EventArgs e)
        {
            this.customersTab.Controls.Clear();
            _manageCustomerControl = null;
            LoadCustomerControl();
        }

        private void ManageCustomerControl_CancelUpdateCustomer(object sender, EventArgs e)
        {
            this.customersTab.Controls.Clear();
            _manageCustomerControl = null;
            LoadCustomerControl();
        }

        private void CustomerControl_CreateCustomer(object sender, EventArgs e)
        {

            this.customersTab.Controls.Clear();
            _manageCustomerControl = new ManageCustomerControl(){Dock = DockStyle.Fill};
            this.customersTab.Controls.Add(_manageCustomerControl);
            _customerControl = null;
            _manageCustomerControl.CustomerUpdated += ManageCustomerControl_CustomerUpdated;
            _manageCustomerControl.CancelUpdateCustomer += ManageCustomerControl_CancelUpdateCustomer;
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

        private void mainTabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(this.mainTabControl.SelectedTab == this.appointmentsTab)
            {
                LoadAppointmentControl();
            }
        }
    }
}
