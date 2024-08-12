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
    public class ReportService
    {
        public ReportService() { }

        public List<string> GetAppointmentTypes() 
        {
            string query = $"SELECT DISTINCT type FROM {TABLES.APPOINTMENT}";
            List<string> types = new List<string>();
            try
            {
                using (MySqlCommand command = new MySqlCommand(query, DbConnection.Connection))
                {
                    using(MySqlDataReader reader = command.ExecuteReader())
                    {
                        while(reader.Read())
                        {
                            types.Add(reader.GetString("type"));
                        }
                    }
                }
            }catch(MySqlException ex)
            {
                throw new Exception("My Sql Error: " + ex.Message);
            }
            return types;
        }
        public int GetAppointmentCountByType(string appointmentType, DateTime monthStart, DateTime monthEnd) 
        {

            string query = $@"  SELECT COUNT(*) 
                                FROM       {TABLES.APPOINTMENT} a
                                JOIN       {TABLES.CUSTOMER} c ON a.{APPOINTMENT.CUSTOMER_ID} = c.{CUSTOMER.CUSTOMER_ID}
                                WHERE      a.{APPOINTMENT.TYPE}     = @AppointmentType
                                AND        a.{APPOINTMENT.START}   >= @MonthStart 
                                AND        a.{APPOINTMENT.END}     <= @MonthEnd
                                AND c.{CUSTOMER.ACTIVE} = 1;
                            ";
            try
            {
                using (MySqlCommand command = new MySqlCommand(query, DbConnection.Connection))
                {
                    command.Parameters.AddWithValue("@AppointmentType", appointmentType);
                    command.Parameters.AddWithValue("@MonthStart", monthStart.ToUniversalTime().ToString("yyyy-MM-dd HH:mm:ss"));
                    command.Parameters.AddWithValue("@MonthEnd", monthEnd.ToUniversalTime().ToString("yyyy-MM-dd HH:mm:ss"));
                    object typeCount = command.ExecuteScalar();
                    if (typeCount != null)
                    {
                        return Convert.ToInt32(typeCount);
                    }
                    else
                    {
                        return 0;
                    }
                }
            }catch(MySqlException ex)
            {
                string errorMessage = "MySql Error: " + ex.Message;
                if (ex.InnerException != null)
                {
                    errorMessage += " | Inner Exception: " + ex.InnerException.Message;
                }
                throw new Exception(errorMessage, ex);
            }
          
        }
        public List<UserDTO> GetAllUsers() 
        {
            string query = $"SELECT {USER.USER_ID}, {USER.USER_NAME} FROM {TABLES.USER}";
            List<UserDTO> users = new List<UserDTO>();
            try
            {
                using (MySqlCommand command = new MySqlCommand(query, DbConnection.Connection))
                {
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            users.Add(new UserDTO
                            {
                                UserId = reader.GetInt32(USER.USER_ID),
                                UserName = reader.GetString(USER.USER_NAME)
                            });
                        }
                    }
                }
            }catch(MySqlException ex) 
            { 
                throw new Exception("My Sql Error: " + ex.Message); 
            }
            return users;
        }
        public List<AppointmentReportDTO> GetAppointmentsByUser(int userId) 
        {
            string query = $@"  SELECT 
                                  c.{CUSTOMER.CUSTOMER_NAME},
                                  a.{APPOINTMENT.TYPE}, 
                                  a.{APPOINTMENT.START}
                                FROM 
                                    {TABLES.APPOINTMENT} a
                                JOIN 
                                    {TABLES.CUSTOMER} c ON a.{APPOINTMENT.CUSTOMER_ID} = c.{CUSTOMER.CUSTOMER_ID}
                                JOIN 
                                    {TABLES.USER} u ON a.{APPOINTMENT.USER_ID} = u.{USER.USER_ID}
                                WHERE 
                                  a.{APPOINTMENT.USER_ID} = @UserId
                                AND 
                                  c.{CUSTOMER.ACTIVE} = @Active;
                            ";
            List<AppointmentReportDTO> appointments = new List<AppointmentReportDTO>();
            try
            {
                using (MySqlCommand command = new MySqlCommand(query, DbConnection.Connection))
                {
                    command.Parameters.AddWithValue("@UserId", userId);
                    command.Parameters.AddWithValue("@Active", true);
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            appointments.Add(new AppointmentReportDTO
                            {
                                CustomerName = reader.GetString(CUSTOMER.CUSTOMER_NAME),
                                Type = reader.GetString(APPOINTMENT.TYPE),
                                Start = reader.GetDateTime(APPOINTMENT.START).ToLocalTime()
                            });
                        }
                    }
                }
            }catch(MySqlException ex)
            {
                throw new Exception("My Sql Error: " + ex.Message);
            }
            return appointments;
        }
        public List<CustomerReportDTO> GetAllCustomers()
        {
            string query = $@"
                                SELECT 
                                    {CUSTOMER.CUSTOMER_ID},
                                    {CUSTOMER.CUSTOMER_NAME}
                                FROM 
                                    {TABLES.CUSTOMER}
                                WHERE {CUSTOMER.ACTIVE} = 1;
                            ";

            List<CustomerReportDTO> customers = new List<CustomerReportDTO>();
            try
            {
                using (MySqlCommand command = new MySqlCommand(query, DbConnection.Connection))
                {
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            customers.Add(new CustomerReportDTO
                            {
                                CustomerId = reader.GetInt32(CUSTOMER.CUSTOMER_ID),
                                CustomerName = reader.GetString(CUSTOMER.CUSTOMER_NAME)
                            });
                        }
                    }
                }
            }catch(MySqlException ex)
            {
                throw new Exception("My Sql Error: " + ex.Message);
            }
            return customers;
        }
        public int GetAppointmentCountByCustomer(int customerId) 
        {
            string query = $@"  SELECT COUNT(*) 
                                FROM {TABLES.APPOINTMENT}
                                WHERE {APPOINTMENT.CUSTOMER_ID} = @CustomerId;
                            ";
            try
            {
                using (MySqlCommand command = new MySqlCommand(query, DbConnection.Connection))
                {
                    command.Parameters.AddWithValue("@CustomerId", customerId);
                    object typeCount = command.ExecuteScalar();
                    if (typeCount != null)
                    {
                        return Convert.ToInt32(typeCount);
                    }
                    else
                    {
                        return 0;
                    }
                }
            }catch(MySqlException ex)
            {
                throw new Exception("My Sql Error: " + ex.Message);
            }
        }
    }
}
