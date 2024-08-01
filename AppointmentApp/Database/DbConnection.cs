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
       public static MySqlConnection Connection { get; set; }



        public static void OpenConnection()
        {
           string connectionString = ConfigurationManager.ConnectionStrings["localdb"].ConnectionString;
            try
            {
                Connection = new MySqlConnection(connectionString);
                Connection.Open();

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
                if (Connection != null)
                {
                    Connection.Close();
                }
                Connection = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
           
        }
    }
}
