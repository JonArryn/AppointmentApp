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

            string query = $@"SELECT 
                                        c.{CUSTOMER.CUSTOMER_ID},
                                        c.{CUSTOMER.CUSTOMER_NAME},
                                        CONCAT(a.{ADDRESS.ADDRESS1}, ', ', 
                                               a.{ADDRESS.ADDRESS2}, ', ', 
                                               ci.{CITY.CITY_NAME}, ', ',
                                               a.{ADDRESS.POSTAL_CODE}, ', ',
                                               co.{COUNTRY.COUNTRY_NAME}
                                              ) AS fullAddress,                          
                                        a.{ADDRESS.PHONE}

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
                        reader.Close();
                    }

                }
            }
            catch (MySqlException ex)
            {
                throw new Exception($"MySql Error: {ex.Message}", ex);
            }
            return customers;
        }

        public CustomerUpdateDTO GetById(int customerId) 
        {
            string query = $@"
                            SELECT
                                    c.{CUSTOMER.CUSTOMER_ID},
                                    c.{CUSTOMER.CUSTOMER_NAME},
                                    c.{CUSTOMER.ACTIVE},
                                    c.{CUSTOMER.ADDRESS_ID},
                                    a.{ADDRESS.ADDRESS1},
                                    a.{ADDRESS.ADDRESS2},
                                    a.{ADDRESS.CITY_ID},
                                    a.{ADDRESS.POSTAL_CODE},
                                    a.{ADDRESS.PHONE},
                                    ci.{CITY.CITY_NAME},
                                    co.{COUNTRY.COUNTRY_NAME},
                                    co.{COUNTRY.COUNTRY_ID},
                                    c.{CUSTOMER.LAST_UPDATE},
                                    c.{CUSTOMER.LAST_UPDATE_BY}
                            FROM {TABLES.CUSTOMER} c
                            JOIN {TABLES.ADDRESS} a ON c.{CUSTOMER.ADDRESS_ID} = a.{ADDRESS.ADDRESSS_ID}
                            JOIN {TABLES.CITY} ci ON a.{ADDRESS.CITY_ID} = ci.{CITY.CITY_ID}
                            JOIN {TABLES.COUNTRY} co ON ci.{CITY.COUNTRY_ID} = co.{COUNTRY.COUNTRY_ID}
                            WHERE c.{CUSTOMER.CUSTOMER_ID} = @CustomerId
                            ";
            CustomerUpdateDTO customer = new CustomerUpdateDTO();
            try
            {
                using(MySqlCommand command = new MySqlCommand(query, DbConnection.Connection))
                {
                    command.Parameters.AddWithValue("@CustomerId", customerId);
                    using(MySqlDataReader reader = command.ExecuteReader())
                    {

                        if(reader.Read())
                        {
                            customer.CustomerId = reader.GetInt32(CUSTOMER.CUSTOMER_ID);
                            customer.CustomerName = reader.GetString(CUSTOMER.CUSTOMER_NAME);
                            customer.Active = reader.GetBoolean(CUSTOMER.ACTIVE);
                            customer.AddressId = reader.GetInt32(CUSTOMER.ADDRESS_ID);
                            customer.Address = reader.GetString(ADDRESS.ADDRESS1);
                            customer.Address2 = reader.GetString(ADDRESS.ADDRESS2);
                            customer.CityId = reader.GetInt32(ADDRESS.CITY_ID);
                            customer.PostalCode = reader.GetString(ADDRESS.POSTAL_CODE);
                            customer.Phone = reader.GetString(ADDRESS.PHONE);
                            customer.City = reader.GetString(CITY.CITY_NAME);
                            customer.Country = reader.GetString(COUNTRY.COUNTRY_NAME);
                            customer.CountryId = reader.GetInt32(COUNTRY.COUNTRY_ID);
                            customer.LastUpdate = reader.GetDateTime(CUSTOMER.LAST_UPDATE);
                            customer.LastUpdateBy = reader.GetString(CUSTOMER.LAST_UPDATE_BY);
                        }
                    }
                }
            }catch(MySqlException ex)
            {
                throw new Exception($"MySql Error: {ex.Message}", ex);
            }
            return customer;
        }

        public bool Update(CustomerModel customer) 
        { 
            return false; 
        }

        public bool Delete(int customerId) 
        { 
            return false; 
        }
    }
}
