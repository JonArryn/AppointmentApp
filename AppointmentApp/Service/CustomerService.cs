using AppointmentApp.Constant;
using AppointmentApp.Database;
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
        private AddressService _addressService;
        public CustomerService(UserService userService, AddressService addressService) 
        {
            _userService = userService;
            _addressService = addressService;
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
                                    
                                   AND c.{CUSTOMER.ACTIVE} = 1
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

        public CustomerFullReadDTO GetById(int customerId) 
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
            CustomerFullReadDTO customer = new CustomerFullReadDTO();
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


        public int CreateCustomer(CustomerCreateDTO customer)
        {
            using (MySqlTransaction transaction = DbConnection.Connection.BeginTransaction())
            {
                AddressCreateDTO address = new AddressCreateDTO
                {
                    Address = customer.Address,
                    Address2 = customer.Address2,
                    CityId = customer.CityId,
                    PostalCode = customer.PostalCode,
                    Phone = customer.Phone
                };

                int addressId = -1;
                int customerId = -1;

                try
                {
                    addressId = _addressService.CreateAddress(address);
                    if (addressId <= 0)
                    {
                        throw new Exception("Failed to create address.");
                    }

                    string query = $@"INSERT INTO {TABLES.CUSTOMER}
                                     (
                                         {CUSTOMER.CUSTOMER_NAME},
                                         {CUSTOMER.ADDRESS_ID},
                                         {CUSTOMER.ACTIVE},
                                         {CUSTOMER.CREATE_DATE} ,
                                         {CUSTOMER.CREATED_BY},
                                         {CUSTOMER.LAST_UPDATE},
                                         {CUSTOMER.LAST_UPDATE_BY}
                                     )
                                     VALUES
                                     (
                                         @CustomerName,
                                         @AddressId,
                                         @Active,
                                         @CreateDate,
                                         @CreatedBy,
                                         @LastUpdate,
                                         @LastUpdateBy
                                     );
                                     SELECT LAST_INSERT_ID();
                                     ";
                    using (MySqlCommand command = new MySqlCommand(query, DbConnection.Connection))
                    {
                        command.Parameters.AddWithValue("@CustomerName", customer.CustomerName);
                        command.Parameters.AddWithValue("@AddressId", addressId);
                        command.Parameters.AddWithValue("@Active", 1);
                        command.Parameters.AddWithValue("@CreateDate", DateTime.UtcNow);
                        command.Parameters.AddWithValue("@CreatedBy", _userService.Username);
                        command.Parameters.AddWithValue("@LastUpdate", DateTime.UtcNow);
                        command.Parameters.AddWithValue("@LastUpdateBy", _userService.Username);

                        customerId = Convert.ToInt32(command.ExecuteScalar());
                    }

                    if (customerId > 0)
                    {
                        transaction.Commit();
                    }
                    else
                    {
                        transaction.Rollback();
                        throw new Exception("Failed to create customer.");
                    }
                    return customerId;
                }
                catch (MySqlException ex)
                {
                    try
                    {
                        transaction.Rollback();
                    }
                    catch (MySqlException rollbackEx)
                    {
                        throw new Exception($"MySql Error: {rollbackEx.Message}", rollbackEx);
                    }
                    throw new Exception($"MySql Error: {ex.Message}", ex);
                }
            }
        }

        public bool UpdateCustomer(CustomerUpdateDTO customer) 
        {
            string query = $@"
                            UPDATE {TABLES.CUSTOMER}
                            SET
                                {CUSTOMER.CUSTOMER_NAME} = @CustomerName,
                                {CUSTOMER.ACTIVE} = @Active,
                                {CUSTOMER.LAST_UPDATE} = @LastUpdate,
                                {CUSTOMER.LAST_UPDATE_BY} = @LastUpdateBy
                            WHERE
                                {CUSTOMER.CUSTOMER_ID} = @CustomerId;
                            ";
            try
            {
                using(MySqlCommand command = new MySqlCommand(query, DbConnection.Connection))
                {
                    command.Parameters.AddWithValue("@CustomerName", customer.CustomerName);
                    command.Parameters.AddWithValue("@Active", customer.Active);
                    command.Parameters.AddWithValue("@LastUpdate", DateTime.UtcNow);
                    command.Parameters.AddWithValue("@LastUpdateBy", _userService.Username);
                    command.Parameters.AddWithValue("@CustomerId", customer.CustomerId);

                    return command.ExecuteNonQuery() > 0;
                }
            }catch(MySqlException ex)
            {
                throw new Exception($"MySql Error: {ex.Message}", ex);
            }
        }

        public bool UpdateCustomerAndAddress(CustomerUpdateDTO customer) 
        {
            using (MySqlTransaction transaction = DbConnection.Connection.BeginTransaction()) 
            {
                AddressUpdateDTO updatedAddress = new AddressUpdateDTO
                {
                    AddressId = customer.AddressId,
                    Address = customer.Address,
                    Address2 = customer.Address2,
                    CityId = customer.CityId,
                    PostalCode = customer.PostalCode,
                    Phone = customer.Phone
                };

                bool customerUpdated;
                bool addressUpdated;

                try
                {
                    customerUpdated = this.UpdateCustomer(customer);
                    addressUpdated = _addressService.UpdateAddress(updatedAddress);
                    
                   
                   if(customerUpdated && addressUpdated)
                    {
                        transaction.Commit();

                    }
                    else
                    {
                        transaction.Rollback();
                    }
                    return customerUpdated && addressUpdated;
                }
                catch(MySqlException ex)
                {
                    try
                    {
                        transaction.Rollback();
                    }
                    catch(MySqlException rollbackEx)
                    {
                        throw new Exception($"MySql Error: {rollbackEx.Message}", rollbackEx);
                    }
                    
                    throw new Exception($"MySql Error: {ex.Message}", ex);
                }

            }
        }

        public bool DeleteCustomer(int customerId) 
        { 
            string query = $@"
                            UPDATE {TABLES.CUSTOMER}
                            SET
                                {CUSTOMER.ACTIVE} = 0
                            WHERE
                                {CUSTOMER.CUSTOMER_ID} = @CustomerId;
                            ";
            try
            {
                using (MySqlCommand command = new MySqlCommand(query, DbConnection.Connection))
                {
                    command.Parameters.AddWithValue("@CustomerId", customerId);
                    return command.ExecuteNonQuery() > 0;
                }
            }
            catch (MySqlException ex)
            {
                throw new Exception($"MySql Error: {ex.Message}", ex);
            }
        }
    }
}
