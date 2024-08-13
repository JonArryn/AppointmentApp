using AppointmentApp.Constant;
using AppointmentApp.Helper;
using AppointmentApp.EventManager;
using AppointmentApp.Model;
using AppointmentApp.Service;
using Org.BouncyCastle.Ocsp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace AppointmentApp.Controls
{
    public partial class AppointmentControl : UserControl
    {
        private readonly bool _isInitializing;

        private AppointmentService _appointmentService;

        private List<AppointmentReadDTO> _appointments;
        private object _dateRangeList = new[] {
            new { Key = 0, Value = "All Appointments" },
            new { Key = 1, Value = "Current Month" },
            new { Key = 2, Value = "Current Week" },
            new { Key = 3, Value = "Day" }
        };

        private AppointmentReadDTO _selectedAppointment;

        public AppointmentControl()
        {
            InitializeComponent();
            _isInitializing = true;
            _appointmentService = ServiceLocator.Instance.AppointmentService;
            PopulateDateRanges();
            PopulateAppointments();
            SetInitialStyling();
            _isInitializing = false;
            
        }

        // INITIALIZERS //

        public AppointmentReadDTO GetSelectedAppointment()
        {

           return _selectedAppointment;
        }

        private void PopulateAppointments(string startDate = null, string endDate = null) 
        {

            try
            {
                _appointments = _appointmentService.GetAllAppointments(startDate, endDate);
                this.appointmentGridView.AutoGenerateColumns = false;
                this.appointmentGridView.DataSource = _appointments;

            }
            catch (Exception ex) 
            {
                Messages.ShowError("Populate Appointments Error", $"There was an error retrieving appointment data: {ex.Message}");
            }
        }

        private void PopulateDateRanges()
        {
            this.apptRangeComboBox.DataSource = _dateRangeList;
            this.apptRangeComboBox.DisplayMember = "Value";
            this.apptRangeComboBox.ValueMember = "Key";
            this.apptRangeComboBox.SelectedValue = 0;
        }

        // SETTERS //

        private void SetInitialStyling()
        {
            this.chooseCalendarDayLabel.Visible = false;
            this.chooseCalendarDayPicker.Visible = false;
            this.chooseCalendarDayPicker.Format = DateTimePickerFormat.Custom;
            this.chooseCalendarDayPicker.CustomFormat = "MM/dd/yyyy";
        }

        // EVENT HANDLERS //
        private void HandleDateRangeChanged()
        {
            var date = DateTime.Now;

            var range = this.apptRangeComboBox.SelectedValue;

            switch (range)
            {
                case 0:
                    PopulateAppointments();
                    break;
                case 1:
                    var firstDayOfMonth = new DateTime(date.Year, date.Month, 1);
                    var lastDayOfMonth = firstDayOfMonth.AddMonths(1).AddSeconds(-1);
                    PopulateAppointments(firstDayOfMonth.ToString(), lastDayOfMonth.ToString());
                    break;
                case 2:
                    var firstDayOfWeek = date.AddDays(-(int)date.DayOfWeek);
                    var lastDayOfWeek = firstDayOfWeek.AddDays(7).AddSeconds(-1);
                    PopulateAppointments(firstDayOfWeek.ToString(), lastDayOfWeek.ToString());
                    break;
                case 3:
                    HandleShowDayPicker();
                    break;
            }
            
        }

        private void HandleShowDayPicker()
        {
            this.chooseCalendarDayPicker.Visible = true;
            this.chooseCalendarDayLabel.Visible = true;
        }

        // LOCAL EVENTS //

        private void updateAppointmentButton_Click(object sender, EventArgs e)
        {
            EventMediator.Instance.Publish(APPT_EVENTS.MANAGE_APPT);
        }

        private void newAppointmentButton_Click(object sender, EventArgs e)
        {
            EventMediator.Instance.Publish(APPT_EVENTS.CREATE_APPT);
        }

        private void appointmentGridView_SelectionChanged(object sender, EventArgs e)
        {
            _selectedAppointment = (AppointmentReadDTO)this.appointmentGridView.CurrentRow.DataBoundItem;
        }

        private void deleteAppointmentButton_Click(object sender, EventArgs e)
        {
            var confirm = Messages.ShowQuestion("Delete Appointment", "Are you sure you want to delete this appointment?");
            if (confirm == DialogResult.No) 
            {
                return;
            };
            try
            {
                _appointmentService.DeleteAppointment(_selectedAppointment.AppointmentId);
                EventMediator.Instance.Publish(APPT_EVENTS.APPT_UPDATED);

            }
            catch(Exception ex)
            {
                Messages.ShowError("Delete Appointment Error", $"There was an error deleting the appointment: {ex.Message}");
            }
        }

        private void apptRangeComboBox_SelectedValueChanged(object sender, EventArgs e)
        {
            if (!_isInitializing)
            {
                HandleDateRangeChanged();
            }
        }

        private void chooseCalendarDayPicker_ValueChanged(object sender, EventArgs e)
        {
            var dayStart = this.chooseCalendarDayPicker.Value.Date;
            Console.WriteLine(dayStart);
            var dayEnd = dayStart.AddDays(1).AddSeconds(-1);
            Console.WriteLine(dayEnd);
            PopulateAppointments(dayStart.ToString(), dayEnd.ToString());
        }
    }
}
