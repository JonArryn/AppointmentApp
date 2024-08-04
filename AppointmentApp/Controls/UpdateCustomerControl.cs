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
        private CustomerReadDTO _selectedCustomer;
        public event EventHandler CustomerUpdated;
        public UpdateCustomerControl(int customerId)
        {
            InitializeComponent();          
            _customerService = ServiceLocator.Instance.CustomerService;
            customerFormPanel.Controls.Add(new CustomerFormControl());
        }

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
