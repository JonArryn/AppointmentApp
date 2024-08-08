﻿using AppointmentApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppointmentApp.Helper
{
    public class CityEventArgs : EventArgs
    {
        public CityReadDTO City { get; set; }

        public CityEventArgs(CityReadDTO city)
        {
            City = city;
        }
    }

    public class CountryEventArgs : EventArgs
    {
        public CountryReadDTO Country { get; set; }

        public CountryEventArgs(CountryReadDTO country)
        {
            Country = country;
        }
    }

    public class CustomerFormErrorEventArgs : EventArgs
    {
        public List<string> Errors { get; set; }

        public CustomerFormErrorEventArgs(List<string> errors)
        {
            Errors = errors;
        }
    }
}
