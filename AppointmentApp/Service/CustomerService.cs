using AppointmentApp.Constant;
using AppointmentApp.Model;
using AppointmentApp.Repository;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppointmentApp.Service
{
    public class CustomerService
    {
        private readonly UserService _userService;
        public CustomerService(UserService userService) 
        {
            _userService = userService;
        }

        public List<CustomerModel> GetAll()
        {

            List<CustomerModel> customers = new List<CustomerModel>();
            string query = $@"SELECT * FROM {TableConstant.CUSTOMER} WHERE {CustomerColumns.CREATED_BY} = {_userService.Username}";

            try
            {
                using (MySqlCommand command = new MySqlCommand(query, DbConnection.Connection))
                {
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            CustomerModel customer = new CustomerModel
                            {
                                CustomerId = reader.GetInt32(CustomerColumns.CUSTOMER_ID),
                                CustomerName = reader.GetString(CustomerColumns.CUSTOMER_NAME),
                                AddressId = reader.GetInt32(CustomerColumns.ADDRESS_ID),
                                Active = reader.GetBoolean(CustomerColumns.ACTIVE),
                                CreateDate = reader.GetDateTime(CustomerColumns.CREATE_DATE),
                                CreatedBy = reader.GetString(CustomerColumns.CREATED_BY),
                                LastUpdate = reader.GetDateTime(CustomerColumns.LAST_UPDATE),
                                LastUpdateBy = reader.GetString(CustomerColumns.LAST_UPDATE_BY)
                            };
                            customers.Add(customer);
                        }
                    }

                }
            }
            catch (MySqlException ex)
            {
                throw new Exception($"MySql Error: {ex.Message}", ex);
            }
            return customers;
        }
    }
}
