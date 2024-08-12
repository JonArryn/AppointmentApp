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
using AppointmentApp.Helper;
using AppointmentApp.Helper;

namespace AppointmentApp.Controls
{
    public partial class ManageAppointmentControl : UserControl
    {
        private readonly bool _isNewAppointment;
        private readonly bool _isInitializing;

        private CustomerService _customerService;
        private AppointmentService _appointmentService;

        private List<CustomerReadDTO> _customerList;
        private CustomerReadDTO _currentCustomer;
        private AppointmentReadDTO _appointment;

        private DateTime _businessHoursStart;
        private DateTime _businessHoursEnd;

        private List<AppointmentReadDTO> _overlappingAppointments;


        public ManageAppointmentControl(AppointmentReadDTO appointment = null)
        {
            InitializeComponent();
            _isInitializing = true;
            _isNewAppointment = appointment == null;
            _appointment = appointment;
            if(_isNewAppointment)
            {
                _appointment = new AppointmentReadDTO();
            }
            _customerService = ServiceLocator.Instance.CustomerService;
            _appointmentService = ServiceLocator.Instance.AppointmentService;
            SetFormStyles();
            SubscribeToEvents();
            SetBusinessHours();
            PopulateForm();
            _isInitializing = false;

        }

        // INITIALIZERS //

        private void SetFormStyles()
        {
            this.apptLayoutPanel.Dock = DockStyle.Fill;
            this.apptFormPanel.Dock = DockStyle.Fill;
            this.formErrorListLabel.Visible = false;
            this.startTimePicker.Format = DateTimePickerFormat.Custom;
            this.startTimePicker.CustomFormat = "MM/dd/yyyy hh:mm tt";

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
                this.startTimePicker.Value = DateTime.Now.AddMinutes(5);
                if (_customerList.Count < 1)
                {
                    Messages.ShowError("No Customers Found", "No customers found in the database. Please add a customer before creating an appointment.");
                    return;
                }
                SetCurrentCustomer(_customerList[0].CustomerId);
                
            }
            else
            {
                SetCurrentCustomer(_appointment.CustomerId);
                this.apptTitleTextBox.Text = _appointment.Title;
                this.apptDescriptionTextBox.Text = _appointment.Description;
                this.apptTypeTextBox.Text = _appointment.Type;
                this.startTimePicker.Value = _appointment.Start;
                TimeSpan duration = _appointment.End - _appointment.Start;
                decimal totalMinutes = (decimal)duration.TotalMinutes;
                Console.WriteLine(totalMinutes);
                this.apptDurationUpDown.Value = totalMinutes;
            }

        }

        private void PopulateCustomers()
        {
            try
            {
                List<CustomerReadDTO> customers = _customerService.GetAllCustomers();
                if (customers.Count < 1) 
                {
                    _customerList = new List<CustomerReadDTO>();
                    return;
                }
                _customerList = customers;
                this.apptCustomerComboBox.DataSource = _customerList;
                this.apptCustomerComboBox.DisplayMember = "CustomerName";
                this.apptCustomerComboBox.ValueMember = "CustomerId";

            }
            catch (Exception ex) 
            {
                Messages.ShowError("Error Retrieving Customer List", ex.Message);
            }
            
        }

        private void SetBusinessHours()
        {

            TimeZoneInfo easternZone = TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time");

            DateTime today = DateTime.Today;

            DateTime businessHoursStartEastern = new DateTime(today.Year, today.Month, today.Day, 8, 0, 0, DateTimeKind.Unspecified);
            _businessHoursStart = TimeZoneInfo.ConvertTime(businessHoursStartEastern, easternZone);

            DateTime businessHoursEndEastern = new DateTime(today.Year, today.Month, today.Day, 17, 0, 0, DateTimeKind.Unspecified);
            _businessHoursEnd = TimeZoneInfo.ConvertTime(businessHoursEndEastern, easternZone);

        }

        private void SubscribeToEvents()
        {
            EventMediator.Instance.Subscribe(APPT_EVENTS.APPT_FORM_INVALID, HandleFormErrors);
            EventMediator.Instance.Subscribe(APPT_EVENTS.APPT_BIZ_HOURS, HandleBizHourError);
            EventMediator.Instance.Subscribe(APPT_EVENTS.APPT_OVERLAPS, HandleOverlapError);
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

        private void HandleBizHourError(object data)
        {
            Messages.ShowError("Appointment Outside Business Hours", "Appointment must be scheduled between 8:00 AM and 5:00 PM.");
        }
        private void HandleOverlapError(object data)
        {
            Messages.ShowError("Appointment Overlaps", "Appointment time overlaps with 1 or more existing appointments.");
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
            if(CheckOverlaps(newAppointment.Start.ToString(), newAppointment.End.ToString(), _appointment.AppointmentId) > 0)
            {
                return;
            }
            if(!IsWIthinBusinessHours(newAppointment))
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
            _appointment.Title = this.apptTitleTextBox.Text.Trim();
        }

        private void apptDescriptionTextBox_TextChanged(object sender, EventArgs e)
        {
            _appointment.Description = this.apptDescriptionTextBox.Text.Trim();
        }
        private void apptCustomerComboBox_SelectedValueChanged(object sender, EventArgs e)
        {
            _currentCustomer = (CustomerReadDTO)this.apptCustomerComboBox.SelectedItem;

        }

        private void apptTypeTextBox_TextChanged(object sender, EventArgs e)
        {
            _appointment.Type = this.apptTypeTextBox.Text.Trim();
        }



        // DATE PICKER EVENTS //

        private void startTimePicker_ValueChanged(object sender, EventArgs e)
        {
            if(_isInitializing)
            {
                return;
            }
            _appointment.Start = this.startTimePicker.Value;
            SetEndTime();
        }

        private void apptDurationUpDown_ValueChanged(object sender, EventArgs e)
        {
            if(_isInitializing)
            {
                return;
            }
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

        private int CheckOverlaps(string startTime, string endTime, int? appointmentId = null)
        {
            List<AppointmentReadDTO> overlappingAppointments = _appointmentService.GetAllAppointments(startTime, endTime);
            if (appointmentId.HasValue)
            {
                overlappingAppointments.RemoveAll(a => a.AppointmentId == appointmentId);
            }
            if (overlappingAppointments.Count > 0)
            {
                Messages.ShowError("Appointment Overlaps", "Appointment time overlaps with one or more existing appointments.");
            }
            return overlappingAppointments.Count;
        }

        private bool IsWIthinBusinessHours(AppointmentCreateDTO appointment)
        {
            TimeSpan apptStart = appointment.Start.TimeOfDay;
            TimeSpan apptEnd = appointment.End.TimeOfDay;
            TimeSpan localBizHourStart = _businessHoursStart.ToLocalTime().TimeOfDay;
            TimeSpan localBizHourEnd = _businessHoursEnd.ToLocalTime().TimeOfDay;

            bool isInsideBizHours = apptStart >= localBizHourStart && apptEnd <= localBizHourEnd;
            if (!isInsideBizHours)
            {
                Messages.ShowError("Appointment Outside Business Hours", "Appointment must be scheduled between 8:00 AM and 5:00 PM EST. Check the appointment start time and appointment duration. Appointment duration cannot push appointment end time beyond business hours.");
                return false;
            }else
            {
                return true;
            }

        }

       


    }
}
