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
    public partial class CustomerControl : UserControl
    {
        private CustomerService _customerService;
        private CustomerReadDTO _selectedCustomer;
        public event EventHandler UpdateCustomer;
        public CustomerControl()
        {
            InitializeComponent();          
            _customerService = ServiceLocator.Instance.CustomerService;
            
            PopulateCustomers();

        }

        private void PopulateCustomers()
        {
            List<CustomerReadDTO> customers = _customerService.GetAll();
            this.customerGridView.AutoGenerateColumns = false;
            customerGridView.DataSource = customers;
           
        }

        public int GetSelectedCustomerId()
        {
            return _selectedCustomer.CustomerId;
        }

        private void customerGridView_SelectionChanged(object sender, EventArgs e)
        {
            _selectedCustomer = (CustomerReadDTO)customerGridView.CurrentRow.DataBoundItem;
        }

        private void updateCustomerButton_Click(object sender, EventArgs e)
        {
            UpdateCustomer?.Invoke(this, EventArgs.Empty);
        }

        private void deleteCustomerButton_Click(object sender, EventArgs e)
        {
            Messages.ShowWarning("Delete Customer Pressed", _selectedCustomer.CustomerName);
        }
    }
}
