using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppointmentApp.Constant
{
    public static class LOGIN_EVENTS
    {
        public const string LOGIN_SUCCESSFUL = "LoginSuccessful";
    }

    public static class APPT_EVENTS
    {
        public const string MANAGE_APPT = "ManageAppointment";
        public const string CANCEL_MANAGE_APPT = "ManageAppointmentCanceled";
        public const string APPT_UPDATED = "AppointmentUpdated";
        public const string CREATE_APPT = "CreateAppointment";
    }

    public static class CUSTOMER_EVENTS
    {
        public const string MANAGE_CUSTOMER = "ManageCustomer";
        public const string CREATE_CUSTOMER = "CreateCustomer";
        public const string CUSTOMER_UPDATED = "CustomerUpdated";
        public const string CUSTOMER_CREATED = "CustomerCreated";
        public const string CANCEL_MANAGE_CUSTOMER = "ManageCustomerCanceled";
        public const string CUSTOMER_FORM_INVALID = "CustomerFormInvalid";
    }

    public static class CITY_EVENTS
    {
        public const string CITY_CREATED = "CityCreated";
        public const string CITY_UPDATED = "CityUpdated";
    }

    public static class COUNTRY_EVENTS
    {
        public const string COUNTRY_CREATED = "CountryCreated";
        public const string COUNTRY_UPDATED = "CountryUpdated";
    }
}
