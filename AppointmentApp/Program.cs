﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using AppointmentApp.Service;

// TODO: Standardize service exception handling on each control and service method for each service

namespace AppointmentApp
{
    internal static class Program
    {

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {

            var serviceLocator = ServiceLocator.Instance;
           
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            DbConnection.OpenConnection();
            Application.Run(new MainView());
            DbConnection.CloseConnection();
        }

    }
}
