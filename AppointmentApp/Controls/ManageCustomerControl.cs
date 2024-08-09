using AppointmentApp.Constant;
using AppointmentApp.Database;
using AppointmentApp.EventManager;
using AppointmentApp.Helper;
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

        public ManageCustomerControl(int? customerId = null)
        {
            InitializeComponent();
            _isNewCustomer = customerId == null;
            _customerService = ServiceLocator.Instance.CustomerService;
            this.formErrorListLabel.Visible = false;
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
            SubscribeToEvents();
                    
        }

        private void SubscribeToEvents()
        {
            EventMediator.Instance.Subscribe(CUSTOMER_EVENTS.CUSTOMER_FORM_INVALID, HandleFormInvalid);
        }

        // EVENT MEDIATOR PUBLISHERS //

        private void cancelUpdateCustomerButton_Click(object sender, EventArgs e)
        {
            EventMediator.Instance.Publish(CUSTOMER_EVENTS.CANCEL_MANAGE_CUSTOMER);
        }

        // EVENT HANDLERS //

        private void HandleFormInvalid(object data)
        {
            var errors = (List<string>)data;

            this.formErrorListLabel.Visible = true;
            this.formErrorListLabel.Text = string.Join("\n", errors);
        }

    }
}
