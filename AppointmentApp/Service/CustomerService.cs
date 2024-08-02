using AppointmentApp.Constant;
using AppointmentApp.Model;
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

        public List<CustomerReadDTO> GetAll()
        {

            List<CustomerReadDTO> customers = new List<CustomerReadDTO>();
            /*string query = $@"SELECT * FROM {TABLES.CUSTOMER} WHERE {CUSTOMER.CREATED_BY} = @Username";*/

            string query = $@"SELECT 
                            {CUSTOMER.CUSTOMER_ID},
                            {CUSTOMER.CUSTOMER_NAME},
                            CONCAT(a.{ADDRESS.ADDRESS1}, ',', 
                                   a.{ADDRESS.ADDRESS2}, ', ', 
                                   ci.{CITY.CITY_NAME}, ', ',
                                   a.{ADDRESS.POSTAL_CODE}, ', ',
                                   co.{COUNTRY.COUNTRY_NAME}
                                  ) AS fullAddress,                          
                            {ADDRESS.PHONE},

                       FROM {TABLES.CUSTOMER} c

                       JOIN {TABLES.ADDRESS} a ON c.{CUSTOMER.ADDRESS_ID} = a.{ADDRESS.ADDRESSS_ID}

                       JOIN {TABLES.CITY} ci ON a.{ADDRESS.CITY_ID} = ci.{CITY.CITY_ID}

                       JOIN {TABLES.COUNTRY} co ON ci.{CITY.COUNTRY_ID} = co.{COUNTRY.COUNTRY_ID}

                       WHERE c.{CUSTOMER.CREATED_BY} = @Username
                                                    ";
            try
            {
                using (MySqlCommand command = new MySqlCommand(query, DbConnection.Connection))
                {
                    command.Parameters.AddWithValue("@Username", _userService.Username);
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            CustomerReadDTO customer = new CustomerReadDTO
                            {
                                CustomerId = reader.GetInt32(CUSTOMER.CUSTOMER_ID),
                                CustomerName = reader.GetString(CUSTOMER.CUSTOMER_NAME),
                                Address = reader.GetString("fullAddress"),
                                Phone = reader.GetString(ADDRESS.PHONE)
                            
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
