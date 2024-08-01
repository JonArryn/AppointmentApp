using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using AppointmentApp.Service;

namespace AppointmentApp
{
    internal static class Program
    {
        private static UserService _userService;
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            _userService = new Service.UserService();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            DbConnection.OpenConnection();
            Application.Run(new LoginForm(_userService));
            DbConnection.CloseConnection();
        }
        public static UserService Session => _userService;
    }
}
