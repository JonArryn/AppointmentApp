using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppointmentApp.Constant
{
    public static class APPOINTMENT
    {
        public static readonly string APPOINTMENT_ID = "appointmentId";
        public static readonly string CUSTOMER_ID = "customerId";
        public static readonly string USER_ID = "userId";
        public static readonly string TITLE = "title";
        public static readonly string DESCRIPTION = "description";
        public static readonly string LOCATION = "location";
        public static readonly string CONTACT = "contact";
        public static readonly string TYPE = "type";
        public static readonly string URL = "url";
        public static readonly string START = "start";
        public static readonly string END = "end";
        public static readonly string CREATE_DATE = "createDate";
        public static readonly string CREATED_BY = "createdBy";
        public static readonly string LAST_UPDATE = "lastUpdate";
        public static readonly string LAST_UPDATE_BY = "lastUpdateBy";
    }
    public static class USER
    {
        public static readonly string USER_ID = "userId";
        public static readonly string USER_NAME = "userName";
        public static readonly string PASSWORD = "password";
        public static readonly string ACTIVE = "active";
        public static readonly string CREATE_DATE = "createDate";
        public static readonly string CREATED_BY = "createdBy";
        public static readonly string LAST_UPDATE = "lastUpdate";
        public static readonly string LAST_UPDATE_BY = "lastUpdateBy";
    }

    public static class CUSTOMER
    {
        public static readonly string CUSTOMER_ID = "customerId";
        public static readonly string CUSTOMER_NAME = "customerName";
        public static readonly string ADDRESS_ID = "addressId";
        public static readonly string ACTIVE = "active";
        public static readonly string CREATE_DATE = "createDate";
        public static readonly string CREATED_BY = "createdBy";
        public static readonly string LAST_UPDATE = "lastUpdate";
        public static readonly string LAST_UPDATE_BY = "lastUpdateBy";
    }

    public static class ADDRESS
    {
        public static readonly string ADDRESSS_ID = "addressId";
        public static readonly string ADDRESS1 = "address";
        public static readonly string ADDRESS2 = "address";
        public static readonly string CITY_ID = "cityId";
        public static readonly string POSTAL_CODE = "postalCode";
        public static readonly string PHONE = "phone";
        public static readonly string CREATE_DATE = "createDate";
        public static readonly string CREATED_BY = "createdBy";
        public static readonly string LAST_UPDATE = "lastUpdate";
        public static readonly string LAST_UPDATE_BY = "lastUpdateBy";

    }

    public static class CITY 
    {
        public static readonly string CITY_ID = "cityId";
        public static readonly string CITY_NAME = "city";
        public static readonly string COUNTRY_ID = "countryId";
        public static readonly string CREATE_DATE = "createDate";
        public static readonly string CREATED_BY = "createdBy";
        public static readonly string LAST_UPDATE = "lastUpdate";
        public static readonly string LAST_UPDATE_BY = "lastUpdateBy";
    }

    public static class COUNTRY 
    {
        public static readonly string COUNTRY_ID = "countryId";
        public static readonly string COUNTRY_NAME = "country";
        public static readonly string CREATE_DATE = "createDate";
        public static readonly string CREATED_BY = "createdBy";
        public static readonly string LAST_UPDATE = "lastUpdate";
        public static readonly string LAST_UPDATE_BY = "lastUpdateBy";
    }
    
}
