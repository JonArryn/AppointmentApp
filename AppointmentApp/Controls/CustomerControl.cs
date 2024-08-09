using AppointmentApp.Constant;
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

namespace AppointmentApp.Controls
{
    public partial class CustomerControl : UserControl
    {
        private CustomerService _customerService;
        private CustomerReadDTO _selectedCustomer;


        public CustomerControl()
        {
            InitializeComponent();          
            _customerService = ServiceLocator.Instance.CustomerService;
            
            PopulateCustomers();

        }

        public int GetSelectedCustomerId()
        {
            return _selectedCustomer.CustomerId;
        }

        // INITIALIZERS //

        private void PopulateCustomers()
        {
            List<CustomerReadDTO> customers = _customerService.GetAllCustomers();
            this.customerGridView.AutoGenerateColumns = false;
            customerGridView.DataSource = customers;
           
        }

        // GRID VIEW EVENT HANDLERS //

        private void customerGridView_SelectionChanged(object sender, EventArgs e)
        {
            _selectedCustomer = (CustomerReadDTO)customerGridView.CurrentRow.DataBoundItem;
        }

        // BUTTON CLICK EVENT HANDLERS //

        private void updateCustomerButton_Click(object sender, EventArgs e)
        {
           EventMediator.Instance.Publish(CUSTOMER_EVENTS.MANAGE_CUSTOMER, this);
        }

        private void deleteCustomerButton_Click(object sender, EventArgs e)
        {
           var result = Messages.ShowQuestion("Confirm Customer Delete", $"Are you sure you want to delete this customer {_selectedCustomer.CustomerName}? ");
            if(result == DialogResult.Yes)
            {
                _customerService.DeleteCustomer(_selectedCustomer.CustomerId);
                PopulateCustomers();
            }
        }

        private void newCustomerButton_Click(object sender, EventArgs e)
        {
            EventMediator.Instance.Publish(CUSTOMER_EVENTS.CREATE_CUSTOMER);
        }
    }
}
