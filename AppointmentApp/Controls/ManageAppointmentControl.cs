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
using AppointmentApp.Helper;

namespace AppointmentApp.Controls
{
    public partial class ManageAppointmentControl : UserControl
    {
        private readonly bool _isNewAppointment;

        private CustomerService _customerService;
        private AppointmentService _appointmentService;

        private List<CustomerReadDTO> _customerList;
        private CustomerReadDTO _currentCustomer;
        private AppointmentReadDTO _appointment;
 
        public ManageAppointmentControl(AppointmentReadDTO appointment = null)
        {
            InitializeComponent();
            _isNewAppointment = appointment == null;
            _appointment = appointment;
            if(_isNewAppointment)
            {
                _appointment = new AppointmentReadDTO();
            }
            _customerService = ServiceLocator.Instance.CustomerService;
            _appointmentService = ServiceLocator.Instance.AppointmentService;
            SetFormStyles();
            PopulateForm();
            SubscribeToEvents();

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

        private void SubscribeToEvents()
        {
            EventMediator.Instance.Subscribe(APPT_EVENTS.APPT_FORM_INVALID, HandleFormErrors);
        }

        // SETTERS //

        private void SetCurrentCustomer(int customerId)
        {
                _currentCustomer = _customerList.Find(c => c.CustomerId == customerId);
                this.apptCustomerComboBox.SelectedValue = customerId;
        }

        private void SetEndTime()
        {
            int minutes = Int32.Parse(this.apptDurationUpDown.Value.ToString());
            DateTime endTime = _appointment.Start.AddMinutes(minutes);
            _appointment.End = endTime;
        }

        // EVENT MEDIATOR HANDLERS //

        private void HandleFormErrors(object data)
        {
            var errorList = (List<string>)data;
            this.formErrorListLabel.Visible = true;
            this.formErrorListLabel.Text = string.Join("\n", errorList);
            
        }


        // BUTTON EVENTS //
        private void backToApptsButton_Click(object sender, EventArgs e)
        {
            EventMediator.Instance.Publish(APPT_EVENTS.CANCEL_MANAGE_APPT);
        }

        private void apptSaveButton_Click(object sender, EventArgs e)
        {
            AppointmentCreateDTO newAppointment = new AppointmentCreateDTO
            {
                CustomerId = _currentCustomer.CustomerId,
                Title = _appointment.Title,
                Description = _appointment.Description,
                Type = _appointment.Type,
                Start = _appointment.Start,
                End = _appointment.End
            };
            if(ValidateForm(newAppointment) > 0)
            {
                return;
            }
            if (_isNewAppointment)
            {
                try
                {
                    _appointmentService.CreateAppointment(newAppointment);
                    var confirm = Messages.ShowInfo("Appointment Created", "Appointment Saved!");
                    if (confirm == DialogResult.OK) { EventMediator.Instance.Publish(APPT_EVENTS.APPT_CREATED); };
                }
                catch (Exception ex)
                {
                    Messages.ShowError("Error Creating Appointment", ex.Message);
                }
            }
            else
            {
                AppointmentUpdateDTO updatedAppointment = new AppointmentUpdateDTO
                {
                    AppointmentId = _appointment.AppointmentId,
                    CustomerId = _currentCustomer.CustomerId,
                    Title = _appointment.Title,
                    Description = _appointment.Description,
                    Type = _appointment.Type,
                    Start = _appointment.Start,
                    End = _appointment.End
                };
                try
                {
                    _appointmentService.UpdateAppointment(updatedAppointment);
                    var confirm = Messages.ShowInfo("Appointment Updated", "Appointment Updated!");
                    if(confirm == DialogResult.OK) { EventMediator.Instance.Publish(APPT_EVENTS.APPT_UPDATED); };
                }
                catch (Exception ex)
                {
                    Messages.ShowError("Error Updating Appointment", ex.Message);
                }
            }
        }

        private void changeCustomerLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.apptCustomerComboBox.Enabled = true;
        }

        private void apptCancelButton_Click(object sender, EventArgs e)
        {
            EventMediator.Instance.Publish(APPT_EVENTS.CANCEL_MANAGE_APPT);
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
        private void apptCustomerComboBox_SelectedValueChanged(object sender, EventArgs e)
        {
            _currentCustomer = (CustomerReadDTO)this.apptCustomerComboBox.SelectedItem;

        }

        private void apptTypeTextBox_TextChanged(object sender, EventArgs e)
        {
            _appointment.Type = this.apptTypeTextBox.Text;
        }



        // DATE PICKER EVENTS //

        private void startTimePicker_ValueChanged(object sender, EventArgs e)
        {
            _appointment.Start = this.startTimePicker.Value;
            SetEndTime();
        }

        private void apptDurationUpDown_ValueChanged(object sender, EventArgs e)
        {
            SetEndTime();
        }

        // HELPERS //

        private int ValidateForm(AppointmentCreateDTO appointment)
        {
            AppointmentFormValidator validator = new AppointmentFormValidator(appointment);
            List<string> errors = validator.ValidateApptForm();
            if (errors.Count > 0)
            {
                EventMediator.Instance.Publish(APPT_EVENTS.APPT_FORM_INVALID, errors);
            }
            return errors.Count;
        }


    }
}
