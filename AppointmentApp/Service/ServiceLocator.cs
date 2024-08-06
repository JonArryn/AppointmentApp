
using AppointmentApp.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppointmentApp.Service
{
    public class ServiceLocator
    {
        private static ServiceLocator _instance;
        public static ServiceLocator Instance => _instance ?? (_instance = new ServiceLocator());

        public UserService UserService { get; }
        public CustomerService CustomerService { get; }
        public TranslationService TranslationService { get; }
        public CountryService CountryService { get; }
        public CityService CityService { get; }
        public AddressService AddressService { get; }

        private ServiceLocator()
        {
            try
            {
                UserService = new UserService();
                TranslationService = new TranslationService();
                CustomerService = new CustomerService(UserService);
                AddressService = new AddressService(UserService);
                CountryService = new CountryService(UserService);
                CityService = new CityService(UserService);
            }catch(StackOverflowException ex)
            {
                Console.WriteLine($"ServiceLocator initialization failed: {ex.Message}");
                Console.WriteLine($"Stack Trace:\n{ex.StackTrace}");
                throw;
            }

        }
    }
}
