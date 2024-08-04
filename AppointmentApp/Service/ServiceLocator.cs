
using AppointmentApp.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            UserService = new UserService();
            TranslationService = new TranslationService();
            CustomerService = new CustomerService(UserService);
            AddressService = new AddressService();
            CountryService = new CountryService();
            CityService = new CityService();
        }
    }
}
