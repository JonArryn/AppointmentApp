using AppointmentApp.EventManager;
using AppointmentApp.Constant;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AppointmentApp.Model;
using AppointmentApp.Service;
using AppointmentApp.Database;

namespace AppointmentApp.Controls
{
    public partial class ManageAppointmentControl : UserControl
    {
        private readonly bool _isNewAppointment;

        private CustomerService _customerService;

        private List<CustomerReadDTO> _customerList;
        private CustomerReadDTO _currentCustomer;

        private AppointmentReadDTO _appointment;
 
        public ManageAppointmentControl(AppointmentReadDTO appointment = null)
        {
            InitializeComponent();
            _appointment = appointment;
            _isNewAppointment = appointment == null;
            _customerService = ServiceLocator.Instance.CustomerService;
            SetFormStyles();
            PopulateForm();

        }

        // INITIALIZERS //

        private void SetFormStyles()
        {
            this.apptLayoutPanel.Dock = DockStyle.Fill;
            this.apptFormPanel.Dock = DockStyle.Fill;
            this.formErrorListLabel.Visible = false;
            this.startTimePicker.Format = DateTimePickerFormat.Custom;
            this.startTimePicker.CustomFormat = "MM/dd/yyyy hh:mm";

            if(_isNewAppointment)
            {
                this.changeCustomerLink.Visible = false;
                this.manageApptLabel.Text = "Create Appointment";
            }
            else
            {
                this.apptCustomerComboBox.Enabled = false;
                this.manageApptLabel.Text = "Update Appointment";
            }
        }

        private void PopulateForm()
        {
            PopulateCustomers();
            if (_isNewAppointment)
            {
                SetCurrentCustomer(_customerList[0].CustomerId);
            }
            else
            {
                SetCurrentCustomer(_appointment.CustomerId);
                this.apptTitleTextBox.Text = _appointment.Title;
                this.apptDescriptionTextBox.Text = _appointment.Description;
                this.apptTypeTextBox.Text = _appointment.Type;
                this.startTimePicker.Value = _appointment.Start;
            }

        }

        private void PopulateCustomers()
        {
            try
            {
                _customerList = _customerService.GetAllCustomers();
                this.apptCustomerComboBox.DataSource = _customerList;
                this.apptCustomerComboBox.DisplayMember = "CustomerName";
                this.apptCustomerComboBox.ValueMember = "CustomerId";

            }
            catch (Exception ex) 
            {
                Messages.ShowError("Error Retrieving Customer List", ex.Message);
            }
            
        }

        // SETTERS //

        private void SetCurrentCustomer(int customerId)
        {
                _currentCustomer = _customerList.Find(c => c.CustomerId == customerId);
                this.apptCustomerComboBox.SelectedValue = customerId;
        }

        private void SetEndTime(int minutes)
        {
            DateTime endTime = _appointment.Start.AddMinutes(minutes);
            _appointment.End = endTime;
        }


        // BUTTON EVENTS //
        private void backToApptsButton_Click(object sender, EventArgs e)
        {
            EventMediator.Instance.Publish(APPT_EVENTS.CANCEL_MANAGE_APPT);
        }

        private void apptSaveButton_Click(object sender, EventArgs e)
        {
            if (_isNewAppointment)
            {

            }
        }

        private void changeCustomerLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.apptCustomerComboBox.Enabled = true;
        }

        private void apptCustomerComboBox_SelectedValueChanged(object sender, EventArgs e)
        {
            _currentCustomer = (CustomerReadDTO)this.apptCustomerComboBox.SelectedItem;

        }


        // TEXT FIELD EVENTS //


        private void apptTitleTextBox_TextChanged(object sender, EventArgs e)
        {
            _appointment.Title = this.apptTitleTextBox.Text;
        }

        private void apptDescriptionTextBox_TextChanged(object sender, EventArgs e)
        {
            _appointment.Description = this.apptDescriptionTextBox.Text;
        }

        private void apptTypeTextBox_TextChanged(object sender, EventArgs e)
        {
            _appointment.Type = this.apptTypeTextBox.Text;
        }



        // DATE PICKER EVENTS //

        private void startTimePicker_ValueChanged(object sender, EventArgs e)
        {
            _appointment.Start = this.startTimePicker.Value;
        }

        private void apptDurationUpDown_ValueChanged(object sender, EventArgs e)
        {
            int minutes = Int32.Parse(this.apptDurationUpDown.Value.ToString());
            SetEndTime(minutes);
        }
    }
}
