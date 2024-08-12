using AppointmentApp.Constant;
using AppointmentApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppointmentApp.Helper
{
    public class CustomerFormValidator
    {
        List<string> errors { get; set; }

        string CustomerName { get; set; }
        string Address { get; set; }
        string Address2 { get; set; }
        string Phone { get; set; }
        int CityId { get; set; }
        string PostalCode { get; set; }


        public CustomerFormValidator(CustomerCreateDTO customerData)
        {
            errors = new List<string>();
            CustomerName = customerData.CustomerName;
            Address = customerData.Address;
            Address2 = customerData.Address2;
            Phone = customerData.Phone;
            CityId = customerData.CityId;
            PostalCode = customerData.PostalCode;

        }

        public List<string> ValidateCustomerForm()
        {
            if (string.IsNullOrWhiteSpace(CustomerName))
            {
                errors.Add("Customer Name is required");
            }
            if (!string.IsNullOrWhiteSpace(CustomerName) && CustomerName.Length > 45)
            {
                errors.Add("Customer Name must be 50 characters or less");
            }
            if (string.IsNullOrWhiteSpace(Address))
            {
                errors.Add("Address is required");
            }
            if(!string.IsNullOrWhiteSpace(Address) && Address.Length > 50)
            {
                errors.Add("Address must be 50 characters or less");
            }
            if(!string.IsNullOrWhiteSpace(Address2) && Address2.Length > 50)
            {
                errors.Add("Address must be 50 characters or less");
            }
            if (string.IsNullOrWhiteSpace(Phone))
            {
                errors.Add("Phone is required");
            }
            if (!string.IsNullOrWhiteSpace(Phone))
            {
                if (!System.Text.RegularExpressions.Regex.IsMatch(Phone, @"^[\d-]+$"))
                {
                    errors.Add("Phone number must contain only numbers and dashes.");
                }
            }

            if (!string.IsNullOrWhiteSpace(Phone) && Phone.Length > 20)
            {
                errors.Add("Phone must be 20 characters or less");
            }
            if(CityId <= 0)
            {
                errors.Add("City is required");
            }
            if (string.IsNullOrWhiteSpace(PostalCode))
            {
                errors.Add("Postal Code is required");
            }
            if(!string.IsNullOrWhiteSpace(PostalCode) && PostalCode.Length > 10)
            {
                errors.Add("Postal Code must be 10 characters or less");
            }
            return errors;

        }
        
    }
}
