using AppointmentApp.Constant;
using AppointmentApp.Model;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppointmentApp.Service
{
    public class AppointmentService
    {
        private UserService _userService;
        public AppointmentService(UserService userService)
        {
            _userService = userService;
        }
        public List<AppointmentReadDTO> GetAllAppointments(string startDate = null, string endDate = null)
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
                            AND
                                    c.{CUSTOMER.ACTIVE} = 1
                            ";
            if(startDate != null && endDate != null)
            {
                query += $@"AND
                            a.{APPOINTMENT.START} BETWEEN @StartDate AND @EndDate";
            }
            try
            {
                using (MySqlCommand command = new MySqlCommand(query, DbConnection.Connection))
                {
                    command.Parameters.AddWithValue("@UserId", _userService.UserID);
                    if (startDate != null && endDate != null)
                    {
                        command.Parameters.AddWithValue("@StartDate", DateTime.Parse(startDate).ToUniversalTime());
                        command.Parameters.AddWithValue("@EndDate", DateTime.Parse(endDate).ToUniversalTime());
                    }
                    
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
        public bool UpdateAppointment(AppointmentUpdateDTO appointment)
        {
            string query = $@"
                            UPDATE {TABLES.APPOINTMENT}
                            SET
                                {APPOINTMENT.CUSTOMER_ID} = @CustomerId,
                                {APPOINTMENT.TITLE} = @Title,
                                {APPOINTMENT.DESCRIPTION} = @Description,
                                {APPOINTMENT.TYPE} = @Type,
                                {APPOINTMENT.START} = @Start,
                                {APPOINTMENT.END} = @End,
                                {APPOINTMENT.LAST_UPDATE} = @LastUpdate,
                                {APPOINTMENT.LAST_UPDATE_BY} = @LastUpdateBy    
                            WHERE
                                {APPOINTMENT.APPOINTMENT_ID} = @AppointmentId;
                            ";
            try
            {
                using (MySqlCommand command = new MySqlCommand(query, DbConnection.Connection))
                {
                    command.Parameters.AddWithValue("@CustomerId", appointment.CustomerId);
                    command.Parameters.AddWithValue("@Title", appointment.Title);
                    command.Parameters.AddWithValue("@Description", appointment.Description);
                    command.Parameters.AddWithValue("@Type", appointment.Type);
                    command.Parameters.AddWithValue("@Start", appointment.Start.ToUniversalTime());
                    command.Parameters.AddWithValue("@End", appointment.End.ToUniversalTime());
                    command.Parameters.AddWithValue("@LastUpdate", DateTime.UtcNow);
                    command.Parameters.AddWithValue("@LastUpdateBy", _userService.Username);
                    command.Parameters.AddWithValue("@AppointmentId", appointment.AppointmentId);

                    return command.ExecuteNonQuery() > 0;
                }
            }
            catch (MySqlException ex)
            {
                throw new Exception($"MySql Error: {ex.Message}", ex);
            }
        }

        public int CreateAppointment(AppointmentCreateDTO appointment)
        {
            string query = $@"
                            INSERT INTO {TABLES.APPOINTMENT}     
                                 (
                                    {APPOINTMENT.CUSTOMER_ID},
                                    {APPOINTMENT.USER_ID},
                                    {APPOINTMENT.TITLE},
                                    {APPOINTMENT.DESCRIPTION},
                                    {APPOINTMENT.TYPE},
                                    {APPOINTMENT.START},
                                    {APPOINTMENT.END},
                                    {APPOINTMENT.CREATE_DATE},
                                    {APPOINTMENT.CREATED_BY},
                                    {APPOINTMENT.LAST_UPDATE},
                                    {APPOINTMENT.LAST_UPDATE_BY},
                                    {APPOINTMENT.LOCATION},
                                    {APPOINTMENT.CONTACT},
                                    {APPOINTMENT.URL}
                                 )
                            VALUES                                        
                                 (
                                    @CustomerId,
                                    @UserId,
                                    @Title,
                                    @Description,
                                    @Type,
                                    @Start,
                                    @End,
                                    @CreateDate,
                                    @CreatedBy,
                                    @LastUpdate,
                                    @LastUpdateBy,
                                    @Location,
                                    @Contact,
                                    @Url
                                 );
                            SELECT LAST_INSERT_ID();
                            ";
            try
            {
                using (MySqlCommand command = new MySqlCommand(query, DbConnection.Connection))
                {
                    command.Parameters.AddWithValue("@CustomerId", appointment.CustomerId);
                    command.Parameters.AddWithValue("@UserId", _userService.UserID);
                    command.Parameters.AddWithValue("@Title", appointment.Title);
                    command.Parameters.AddWithValue("@Description", appointment.Description);
                    command.Parameters.AddWithValue("@Type", appointment.Type);
                    command.Parameters.AddWithValue("@Start", appointment.Start.ToUniversalTime());
                    command.Parameters.AddWithValue("@End", appointment.End.ToUniversalTime());
                    command.Parameters.AddWithValue("@CreateDate", DateTime.UtcNow);
                    command.Parameters.AddWithValue("@CreatedBy", _userService.Username);
                    command.Parameters.AddWithValue("@LastUpdate", DateTime.UtcNow);
                    command.Parameters.AddWithValue("@LastUpdateBy", _userService.Username);
                    // UNUESD
                    command.Parameters.AddWithValue("@Location", "NotUsed");
                    command.Parameters.AddWithValue("@Contact", "NotUsed");
                    command.Parameters.AddWithValue("@Url", "NotUsed");
                    return Convert.ToInt32(command.ExecuteScalar());
                    
                }
            }catch(MySqlException ex)
            {
                throw new Exception($"MySql Error: {ex.Message}", ex);
            }
        }

        public bool DeleteAppointment(int appointmentId)
        {
            string query = $@"
                            DELETE FROM {TABLES.APPOINTMENT}
                            WHERE
                                {APPOINTMENT.APPOINTMENT_ID} = @AppointmentId;
                            ";
            try
            {
                using (MySqlCommand command = new MySqlCommand(query, DbConnection.Connection))
                {
                    command.Parameters.AddWithValue("@AppointmentId", appointmentId);
                    return command.ExecuteNonQuery() > 0;
                }
            }
            catch (MySqlException ex)
            {
                throw new Exception($"MySql Error: {ex.Message}", ex);
            }
        }

        public int GetAppointmentCountByDateRange(string startDate, string endDate, int? excludeApptId = null) 
        {
            string query = $@"
                            SELECT COUNT(*)                                    
                                   
                            FROM
                                    {TABLES.APPOINTMENT} a
                            JOIN
                                    {TABLES.CUSTOMER} c ON a.{APPOINTMENT.CUSTOMER_ID} = c.{CUSTOMER.CUSTOMER_ID}
                            JOIN    
                                    {TABLES.USER} u ON a.{APPOINTMENT.USER_ID} = u.{USER.USER_ID}
                            WHERE   
                                    a.{APPOINTMENT.USER_ID} = @UserId
                            AND
                                    c.{CUSTOMER.ACTIVE} = 1
                            AND 
                                  ( a.{APPOINTMENT.START} BETWEEN @StartDate AND @EndDate
                            OR      
                                    a.{APPOINTMENT.END} BETWEEN @StartDate AND @EndDate
                                  )
                            ";
            if(excludeApptId.HasValue)
            {
                query += $"AND a.{APPOINTMENT.APPOINTMENT_ID} != @ExcludeApptId";
            }
            try
            {
                using (MySqlCommand command = new MySqlCommand(query, DbConnection.Connection))
                {
                    if(excludeApptId.HasValue)
                    {
                        command.Parameters.AddWithValue("@ExcludeApptId", excludeApptId.Value);
                    }
                    command.Parameters.AddWithValue("@UserId", _userService.UserID);
                    command.Parameters.AddWithValue("@StartDate", DateTime.Parse(startDate).ToUniversalTime());
                    command.Parameters.AddWithValue("@EndDate", DateTime.Parse(endDate).ToUniversalTime());
                    return Convert.ToInt32(command.ExecuteScalar());
                }
            }catch (MySqlException ex)
            {
                string message = $"MySql Error: {ex.Message}";
                if(ex.InnerException != null)
                {
                   message += $" - InnerException: {ex.InnerException.Message}";
                }
                throw new Exception(message);
            }
        }

    }
}
