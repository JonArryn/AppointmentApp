﻿using AppointmentApp.Constant;
using AppointmentApp.Controls;
using AppointmentApp.Database;
using AppointmentApp.EventManager;
using AppointmentApp.Model;
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


namespace AppointmentApp
{

    public partial class MainView : Form
    {

        private LoginControl _loginControl;
        private CustomerControl _customerControl;
        private AppointmentControl _appointmentControl;
        private ManageAppointmentControl _manageAppointmentControl;
        private ManageCustomerControl _manageCustomerControl;



        public MainView()
        {
            InitializeComponent();
            this.mainLayoutPanel.Visible = false;
            InitializeLoginControl();
            SubscribeToEvents();
        }

        private void SubscribeToEvents()
        {
            EventMediator.Instance.Subscribe(LOGIN_EVENTS.LOGIN_SUCCESSFUL, HandleLoginSuccessful);

            EventMediator.Instance.Subscribe(CUSTOMER_EVENTS.MANAGE_CUSTOMER, HandleManageCustomer);
            EventMediator.Instance.Subscribe(CUSTOMER_EVENTS.CUSTOMER_UPDATED, HandleCustomerUpdated);
            EventMediator.Instance.Subscribe(CUSTOMER_EVENTS.CANCEL_MANAGE_CUSTOMER, HandleCustomerUpdated);
            EventMediator.Instance.Subscribe(CUSTOMER_EVENTS.CREATE_CUSTOMER, HandleCreateCustomer);
            EventMediator.Instance.Subscribe(CUSTOMER_EVENTS.CUSTOMER_CREATED, HandleCustomerUpdated);

            EventMediator.Instance.Subscribe(APPT_EVENTS.APPT_CREATED, HandleAppointmentUpdated);
            EventMediator.Instance.Subscribe(APPT_EVENTS.APPT_UPDATED, HandleAppointmentUpdated);
            EventMediator.Instance.Subscribe(APPT_EVENTS.CREATE_APPT, HandleCreateAppointment);
            EventMediator.Instance.Subscribe(APPT_EVENTS.MANAGE_APPT, HandleManageAppointment);
            EventMediator.Instance.Subscribe(APPT_EVENTS.CANCEL_MANAGE_APPT, HandleAppointmentUpdated);
        }

        // INITIALIZE CONTROLS //
        private void InitializeLoginControl()
        {
            _loginControl = new LoginControl();
            _loginControl.Dock = DockStyle.Fill;
            this.Controls.Add(_loginControl);
        }

        private void LoadCustomerControl()
        {
            if (this.customersTab.Controls.Count == 0)
            {
                _customerControl = new CustomerControl { Dock = DockStyle.Fill };
                this.customersTab.Controls.Add(_customerControl);
                
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

        // EVENT MEDIATOR HANDLERS //

        private void HandleLoginSuccessful(object data = null)
        {
            _loginControl.Visible = false;
            this.mainLayoutPanel.Visible = true;
            LoadCustomerControl();
            AppointmentService appointmentService = ServiceLocator.Instance.AppointmentService;
           List<AppointmentReadDTO> upcomingAppointments = appointmentService.GetAllAppointments(DateTime.Now.ToString(), DateTime.Now.AddMinutes(15).ToString());
            if(upcomingAppointments.Count > 0)
            {
                Messages.ShowInfo("Upcoming Appointments", "You have an appointment in the next 15 minutes.");
            }
        }

        private void HandleCreateCustomer(object data = null)
        {
            this.customersTab.Controls.Clear();
            _manageCustomerControl = new ManageCustomerControl() { Dock = DockStyle.Fill };
            this.customersTab.Controls.Add(_manageCustomerControl);
            _customerControl = null;
        }

        private void HandleManageCustomer(object data = null)
        {
            this.customersTab.Controls.Clear();
            _manageCustomerControl = new ManageCustomerControl(_customerControl.GetSelectedCustomerId());
            this.customersTab.Controls.Add(_manageCustomerControl);
            _manageCustomerControl.Dock = DockStyle.Fill;
            _customerControl = null;
        }

        private void HandleCustomerUpdated(object data = null)
        {
            this.customersTab.Controls.Clear();
            _manageCustomerControl = null;
            LoadCustomerControl();
        }

        private void HandleAppointmentUpdated(object data = null)
        {
            this.appointmentsTab.Controls.Clear();
            _manageAppointmentControl = null;
            LoadAppointmentControl();

        }

        private void HandleManageAppointment(object data = null)
        {
            var appointment = _appointmentControl.GetSelectedAppointment();
            this.appointmentsTab.Controls.Clear();
            _manageAppointmentControl = new ManageAppointmentControl(appointment) { Dock = DockStyle.Fill };
            this.appointmentsTab.Controls.Add(_manageAppointmentControl);
            _appointmentControl = null;
        }

        private void HandleCreateAppointment(object data = null)
        {
            this.appointmentsTab.Controls.Clear();
            _manageAppointmentControl = new ManageAppointmentControl() { Dock = DockStyle.Fill };
            this.appointmentsTab.Controls.Add(_manageAppointmentControl);
            _appointmentControl = null;
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
