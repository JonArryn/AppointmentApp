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
    public partial class ManageCustomerControl : UserControl
    {
        private bool _isNewCustomer;

        private CustomerService _customerService;
        private CustomerFullReadDTO _selectedCustomer;
        private CustomerFormControl _customerFormControl;

        public event EventHandler CustomerUpdated;
        public event EventHandler CancelUpdateCustomer;
        public ManageCustomerControl(int? customerId = null)
        {
            InitializeComponent();
            _isNewCustomer = customerId == null;
            _customerService = ServiceLocator.Instance.CustomerService;
            if(customerId.HasValue)
            {
                _selectedCustomer = _customerService.GetById(customerId.Value);
                _customerFormControl = new CustomerFormControl(_selectedCustomer);
            }
            else
            {
                _customerFormControl = new CustomerFormControl();
            }

            _customerFormControl.Dock = DockStyle.Fill;
            customerFormPanel.Controls.Add(_customerFormControl);
            _customerFormControl.CustomerUpdated += _customerFormControl_CustomerUpdated;
            _customerFormControl.CancelUpdateCustomer += _customerFormControl_CancelUpdateCustomer;
                    
        }

        private void CancelAndClose()
        {
            var response = Messages.ShowQuestion("Cancel Manage Customer", "Are you sure you want to cancel managing the customer?");
            if (response == DialogResult.Yes)
            {
                CancelUpdateCustomer?.Invoke(this, EventArgs.Empty);
            }
        }

        // EVENT HANDLERS

        private void _customerFormControl_CustomerUpdated(object sender, EventArgs e)
        {
            CustomerUpdated?.Invoke(this, EventArgs.Empty);
        }

        private void _customerFormControl_CancelUpdateCustomer(object sender, EventArgs e)
        {
            CancelAndClose();
        }


        // LOCAL EVENTS //

        private void cancelUpdateCustomerButton_Click(object sender, EventArgs e)
        {
            CancelAndClose();
        }
    }
}
