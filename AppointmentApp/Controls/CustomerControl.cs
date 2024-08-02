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
        public CustomerControl()
        {
            InitializeComponent();          
            _customerService = ServiceLocator.Instance.CustomerService;
            PopulateCustomers();

        }

        private void PopulateCustomers()
        {
            List<CustomerModel> customers = _customerService.GetAll();
            customerGridView.DataSource = customers;
           
        }
    }
}
