﻿
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
        public AppointmentService AppointmentService { get; }

        private ServiceLocator()
        {
            try
            {
                UserService = new UserService();
                TranslationService = new TranslationService();
                AddressService = new AddressService(UserService);
                CustomerService = new CustomerService(UserService, AddressService);
                CountryService = new CountryService(UserService);
                CityService = new CityService(UserService);
                AppointmentService = new AppointmentService(UserService);
            }catch(StackOverflowException ex)
            {
                Console.WriteLine($"ServiceLocator initialization failed: {ex.Message}");
                Console.WriteLine($"Stack Trace:\n{ex.StackTrace}");
                throw;
            }

        }
    }
}
