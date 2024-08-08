using AppointmentApp.Constant;
using AppointmentApp.Model;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppointmentApp.Service
{
    public class AppointmentService
    {
        private readonly UserService _userService;
        public AppointmentService(UserService userService)
        {
            _userService = userService;
        }
        public List<AppointmentReadDTO> GetAllAppointments()
        {
            List<AppointmentReadDTO> appointments = new List<AppointmentReadDTO>();
            string query = $@"
                            SELECT
                                    a.{APPOINTMENT.APPOINTMENT_ID},
                                    a.{APPOINTMENT.CUSTOMER_ID},
                                    c.{CUSTOMER.CUSTOMER_NAME},
                                    c.{CUSTOMER.ACTIVE},
                                    a.{APPOINTMENT.USER_ID},
                                    u.{USER.USER_NAME},
                                    a.{APPOINTMENT.TITLE},
                                    a.{APPOINTMENT.DESCRIPTION},
                                    a.{APPOINTMENT.TYPE},
                                    a.{APPOINTMENT.START},
                                    a.{APPOINTMENT.END}
                            FROM
                                    {TABLES.APPOINTMENT} a
                            JOIN
                                    {TABLES.CUSTOMER} c ON a.{APPOINTMENT.CUSTOMER_ID} = c.{CUSTOMER.CUSTOMER_ID}
                            JOIN    
                                    {TABLES.USER} u ON a.{APPOINTMENT.USER_ID} = u.{USER.USER_ID}
                            WHERE   
                                    a.{APPOINTMENT.USER_ID} = @UserId
                            ";
            
            try
            {
                using (MySqlCommand command = new MySqlCommand(query, DbConnection.Connection))
                {
                    command.Parameters.AddWithValue("@UserId", _userService.UserID);
                    
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            AppointmentReadDTO appointment = new AppointmentReadDTO
                            {
                                AppointmentId = reader.GetInt32(APPOINTMENT.APPOINTMENT_ID),
                                CustomerId = reader.GetInt32(APPOINTMENT.CUSTOMER_ID),
                                CustomerName = reader.GetString(CUSTOMER.CUSTOMER_NAME),
                                CustomerActive = reader.GetBoolean(CUSTOMER.ACTIVE),
                                UserId = reader.GetInt32(APPOINTMENT.USER_ID),
                                UserName = reader.GetString(USER.USER_NAME),
                                Title = reader.GetString(APPOINTMENT.TITLE),
                                Description = reader.GetString(APPOINTMENT.DESCRIPTION),
                                Type = reader.GetString(APPOINTMENT.TYPE),
                                Start = reader.GetDateTime(APPOINTMENT.START).ToLocalTime(),
                                End = reader.GetDateTime(APPOINTMENT.END).ToLocalTime()

                            };
                            appointments.Add(appointment);
                        }
                    }
                }
            }
            catch (MySqlException ex)
            {
                throw new Exception($"MySql Error: {ex.Message}", ex);
            }
           
            return appointments;
        }
    }
}
