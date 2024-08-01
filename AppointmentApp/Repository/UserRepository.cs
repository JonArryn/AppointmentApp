using AppointmentApp.Constant;
using AppointmentApp.Database;
using AppointmentApp.Model;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

// TODO: Switch to using a DTO instead of using the whole model. W

namespace AppointmentApp.Repository
{
    public class UserRepository
    {
        public UserModel Login(string userName, string password) {

            try
            {

                string sql = $@"SELECT * FROM {TableConstant.USER} WHERE {UserColumns.USER_NAME} = @Username AND {UserColumns.PASSWORD} = @Password";

                using (MySqlCommand loginCommand = new MySqlCommand(sql, DbConnection.Connection))
                {
                    loginCommand.Parameters.AddWithValue("@Username", userName);
                    loginCommand.Parameters.AddWithValue("@Password", password);

                    using (MySqlDataReader reader = loginCommand.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                           var user = new UserModel
                            {
                               UserId = reader.GetInt32("userID"),
                               UserName = reader.GetString("userName"),
                               Password = reader.GetString("password"),
                               Active = reader.GetBoolean("active"),
                               CreateDate = reader.GetDateTime("createDate"),
                               CreatedBy = reader.GetString("createdBy"),
                               LastUpdate = reader.GetDateTime("lastUpdate"),
                               LastUpdateBy = reader.GetString("lastUpdateBy")
                           };
                            return user;
                        }else
                        {
                            return null;
                        }
                    }
                }

            } catch (MySqlException ex)
            {
                Messages.ShowError("MySql Error", ex.Message);
                return null;
            }


        }
    }
}
