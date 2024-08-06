using AppointmentApp.Database;
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

namespace AppointmentApp.Controls
{
    public partial class UpdateCustomerControl : UserControl
    {
        private CustomerService _customerService;
        private CustomerUpdateDTO _selectedCustomer;
        private CustomerFormControl _customerFormControl;

        public event EventHandler CustomerUpdated;
        public UpdateCustomerControl(int customerId)
        {
            InitializeComponent();          
            _customerService = ServiceLocator.Instance.CustomerService;
            _selectedCustomer = _customerService.GetById(customerId);
            _customerFormControl = new CustomerFormControl(_selectedCustomer);
            _customerFormControl.Dock = DockStyle.Fill;
            customerFormPanel.Controls.Add(_customerFormControl);

        }

        // DATA ACCESS //

        public CustomerModel GetCustomer(int Id) 
        {
            return null;
        }

        // LOCAL EVENTS //

        private void cancelUpdateCustomerButton_Click(object sender, EventArgs e)
        {
            var response = Messages.ShowQuestion("Cancel Update Customer", "Are you sure you want to cancel updating the customer?");
            if (response == DialogResult.Yes) 
            {
                CustomerUpdated?.Invoke(this, EventArgs.Empty);
            }
        }
    }
}
