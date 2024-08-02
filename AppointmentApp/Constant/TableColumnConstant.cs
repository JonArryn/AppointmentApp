using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppointmentApp.Constant
{
        public static class UserColumns
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

        public static class CustomerColumns
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
    
}
