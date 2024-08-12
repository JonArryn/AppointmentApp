using AppointmentApp.Model;
using AppointmentApp.Service;
using AppointmentApp.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace AppointmentApp.Controls
{
    public partial class ReportControl : UserControl
    {
        private bool _isInitializing;

        private ReportService _reportService;

        private List<string> _apptTypes;
        private List<UserDTO> _users;
        private List<CustomerReportDTO> _customers;

        private int _appointmentTypeCount;
        private int _appointmentCount;


        public ReportControl()
        {
            InitializeComponent();
            _isInitializing = true;
            _reportService = ServiceLocator.Instance.ReportService;
            PopulateData();
            SetStyles();

            _isInitializing = false;
        }

        private void SetStyles()
        {
            this.apptByMonthDatePicker.Format = DateTimePickerFormat.Custom;
            this.apptByMonthDatePicker.CustomFormat = "MM yyyy";
            this.apptByMonthDatePicker.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
        }

        private void PopulateData() 
        {
            _apptTypes = _reportService.GetAppointmentTypes();
            _users = _reportService.GetAllUsers();
            _customers = _reportService.GetAllCustomers();

            _apptTypes.Insert(0, "Select Appointment Type");
            this.apptTypeComboBox.DataSource = _apptTypes;
            this.apptTypeComboBox.SelectedIndex = 0;

            _users.Insert(0, new UserDTO { UserId = 0, UserName = "Select User" });
            this.consultantComboBox.DataSource = _users;
            this.consultantComboBox.ValueMember = "UserId";
            this.consultantComboBox.DisplayMember = "UserName";
            this.consultantComboBox.SelectedIndex = 0;

            _customers.Insert(0, new CustomerReportDTO { CustomerId = 0, CustomerName = "Select Customer" });
            this.customerComboBox.DataSource = _customers;
            this.customerComboBox.ValueMember = "CustomerId";
            this.customerComboBox.DisplayMember = "CustomerName";
            this.customerComboBox.SelectedIndex = 0;
        }

        // COMBO BOX EVENTS //

        private void HandleApptmentByTypeChange()
        {
            if (_isInitializing) { return; }
            if (this.apptTypeComboBox.SelectedIndex == 0) { this.typeCountText.Text = "0"; return; }

            DateTime startOfMonth = new DateTime(
                this.apptByMonthDatePicker.Value.Year,
                this.apptByMonthDatePicker.Value.Month,
                1, 0, 0, 0);

            DateTime endOfMonth = new DateTime(
                this.apptByMonthDatePicker.Value.Year,
                this.apptByMonthDatePicker.Value.Month,
                DateTime.DaysInMonth(this.apptByMonthDatePicker.Value.Year, this.apptByMonthDatePicker.Value.Month),
                23, 59, 59);

            string selectedApptType = this.apptTypeComboBox.SelectedItem.ToString();
            try
            {
                _appointmentTypeCount = _reportService.GetAppointmentCountByType(selectedApptType, startOfMonth, endOfMonth);
                this.typeCountText.Text = _appointmentTypeCount.ToString();
            }
            catch (Exception ex)
            {
                Messages.ShowError("Error", ex.Message);
            }
        }

        private void apptTypeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            HandleApptmentByTypeChange();

        }

        private void consultantComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_isInitializing) { return; }
            if (this.consultantComboBox.SelectedIndex == 0) { this.consultantApptsGridView.DataSource = null; return; }

            UserDTO selectedUser = (UserDTO)this.consultantComboBox.SelectedItem;
            List<AppointmentReportDTO> appointments = _reportService.GetAppointmentsByUser(selectedUser.UserId);
            this.consultantApptsGridView.DataSource= appointments;


        }

        private void customerComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_isInitializing || this.customerComboBox.SelectedIndex == 0) { return; }
            CustomerReportDTO selectedCustomer = (CustomerReportDTO)this.customerComboBox.SelectedItem;
            
            this.customerAppointmentCountText.Text = _reportService.GetAppointmentCountByCustomer(selectedCustomer.CustomerId).ToString();
        }

        private void apptByMonthDatePicker_ValueChanged(object sender, EventArgs e)
        {
            HandleApptmentByTypeChange();
        }
    }
}
