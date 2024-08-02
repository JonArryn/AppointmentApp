
using AppointmentApp.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppointmentApp.Helper
{
    public class ServiceLocator
    {
        private static ServiceLocator _instance;
        public static ServiceLocator Instance => _instance ?? (_instance = new ServiceLocator());

        public UserService UserService { get; }
        public CustomerService CustomerService { get; }

        private ServiceLocator()
        {
            // Initialize your services and repositories here
            UserService = new UserService();
            CustomerService = new CustomerService(UserService);
        }
    }
}
