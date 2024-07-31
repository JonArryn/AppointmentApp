using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppointmentApp
{
    
    public class DbConnection
    {
       public static MySqlConnection connection { get; set; }



        public static void OpenConnection()
        {
           string connectionString = ConfigurationManager.ConnectionStrings["localdb"].ConnectionString;
            try
            {
                connection = new MySqlConnection(connectionString);
                connection.Open();

            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (Exception ex) 
            {
                MessageBox.Show(ex.Message);
            }
           
        }

        public static void CloseConnection() 
        {
            try
            {
                if (connection != null)
                {
                    connection.Close();
                }
                connection = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
           
        }
    }
}
