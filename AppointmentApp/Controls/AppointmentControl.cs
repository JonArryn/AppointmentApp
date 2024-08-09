using AppointmentApp.Constant;
using AppointmentApp.Database;
using AppointmentApp.EventManager;
using AppointmentApp.Model;
using AppointmentApp.Service;
using Org.BouncyCastle.Ocsp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


// REQ: Create Appointments
// REQ: Update Existing Appointments
// REQ: Delete Existing Appointments
// REQ: Appointments must be associated with a customerId
// REQ: Appointments must be associated with a userId
// REQ: Minimum data in put for appointments should be type, customer, schedule time, user id
// REQ: Calendar view of appointments is required (Can be a list)
// REQ: Calendar View a list of all appointments
// REQ: Calendar View a list of appointments for the current week
// REQ: Calendar View a list of appointments for the current month
// OPT: Calendar can go out further or have custom dates, but it must be easy to see all, current week, and current month appts.
// REQ: Appointment controls must detect time zone and convert the UTC times to the detected local time zone (DateTime class)
// REQ: Set business hours and throw exceptions if appointments are scheduled outside of business hours
// REQ: User must be notified if an appointment overlaps with another appointment for the given user
// REQ: User must be notified if an appointment begins within 15 minutes of login time (Do not use the database current time?)

namespace AppointmentApp.Controls
{
    public partial class AppointmentControl : UserControl
    {
        private AppointmentService _appointmentService;

        private List<AppointmentReadDTO> _appointments;

        private AppointmentReadDTO _selectedAppointment;

        public AppointmentControl()
        {
            InitializeComponent();
            _appointmentService = ServiceLocator.Instance.AppointmentService;

            PopulateAppointments();
            
        }

        // INITIALIZERS //

        public AppointmentReadDTO GetSelectedAppointment()
        {

           return _selectedAppointment;
        }

        private void PopulateAppointments() 
        {
            try
            {
                _appointments = _appointmentService.GetAllAppointments();
                this.appointmentGridView.AutoGenerateColumns = false;
                this.appointmentGridView.DataSource = _appointments;

            }
            catch (Exception ex) 
            {
                Messages.ShowError("Populate Appointments Error", $"There was an error retrieving appointment data: {ex.Message}");
            }
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
    }
}
