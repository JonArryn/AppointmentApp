using AppointmentApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppointmentApp.Constant;
using MySql.Data.MySqlClient;
using AppointmentApp.Database;
using System.IO;

namespace AppointmentApp.Service
{
    public class UserService
    {
        public int UserID { get; private set; }
        public string Username { get; private set; }

        public bool IsLoggedIn => UserID > 0;

        public void StartSession(string userName, string password)
        {

            UserDTO user = Login(userName, password);
            if(user != null)
            {
                UserID = user.UserId;
                Username = user.UserName;
            }
     

        }

        private void EndSession()
        {  
            UserID = 0;
            Username = string.Empty;
        }

        private UserDTO Login(string userName, string password)
        {

            try
            {

                string sql = $@"SELECT * FROM {TABLES.USER} WHERE {USER.USER_NAME} = @Username AND {USER.PASSWORD} = @Password";

                using (MySqlCommand loginCommand = new MySqlCommand(sql, DbConnection.Connection))
                {
                    loginCommand.Parameters.AddWithValue("@Username", userName);
                    loginCommand.Parameters.AddWithValue("@Password", password);

                    using (MySqlDataReader reader = loginCommand.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            var user = new UserDTO
                            {
                                UserId = reader.GetInt32("userID"),
                                UserName = reader.GetString("userName"),
                            };
                            return user;
                        }
                        else
                        {
                            return null;
                        }
                    }
                }

            }
            catch (MySqlException ex)
            {
                throw new Exception($"MySql Error: {ex.Message}", ex);
            }


        }

       
    }
}
