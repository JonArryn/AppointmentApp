using AppointmentApp.Constant;
using AppointmentApp.Helper;
using AppointmentApp.EventManager;
using AppointmentApp.Helper;
using AppointmentApp.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AppointmentApp.Model;

namespace AppointmentApp.Controls
{
    public partial class LoginControl : UserControl
    {
        private UserService _userService;
        private readonly TranslationService _translations;


        public LoginControl()
        {
            InitializeComponent();
           
            _translations = ServiceLocator.Instance.TranslationService;
            this.invalidLoginLabel.Visible = false;
            TranslateLoginForm();
        }

        private void LogIn()
        {
            string userName = usernameInputText.Text;
            string password = passwordInputText.Text;

            _userService = ServiceLocator.Instance.UserService;

            _userService.StartSession(userName, password);

            if (_userService.IsLoggedIn)
            {
                HasUpcomingAppointments();
               
                EventMediator.Instance.Publish(LOGIN_EVENTS.LOGIN_SUCCESSFUL);
                Logger.LogAuthentication(true, _userService.Username);

            }

            if (!_userService.IsLoggedIn)
            {
                this.invalidLoginLabel.Visible = true;
                string login = string.IsNullOrWhiteSpace(_userService.Username) ? this.usernameInputText.Text : _userService.Username;
                Logger.LogAuthentication(false, login);
                return;
            }
        }

        private void loginButton_Click(object sender, EventArgs e)
        {

            LogIn();
        }

        private void TranslateLoginForm()
        {
            Dictionary<string, string> formTranslations;

            if (_translations.CurrentCultureAbv != "en")
            {
                formTranslations = _translations.SpanishLogin;
            }
            else
            {
                formTranslations = _translations.EnglishLogin;
            }

            this.usernameInputLabel.Text = formTranslations["Username"];
            this.passwordInputLabel.Text = formTranslations["Password"];
            this.invalidLoginLabel.Text = formTranslations["InvalidLogin"];
            this.loginButton.Text = formTranslations["Login"];
            this.currentLocationLabel.Text = $"{formTranslations["Location"]}: {_translations.CountryName}";
            this.exitAppButton.Text = formTranslations["ExitApplication"];
        }

        // INVALID LOGIN LABEL

        private void usernameInputText_TextChanged(object sender, EventArgs e)
        {
            this.invalidLoginLabel.Visible = false;
        }

        private void passwordInputText_TextChanged(object sender, EventArgs e)
        {
            this.invalidLoginLabel.Visible = false;
        }

        // DB SEEDERS
        private void dbResetAndSeed_Click(object sender, EventArgs e)
        {
            DbSeeder.ResetAndSeedDatabase();
        }

        private void dbResetTables_Click(object sender, EventArgs e)
        {
            DbSeeder.ResetDatabaseTables();
        }

        private void passwordInputText_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                LogIn();
            }
        }

        private void usernameInputText_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                LogIn();
            }
        }

        private void exitAppButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        // HELPERS //

        private void HasUpcomingAppointments()
        {
            AppointmentService appointmentService = ServiceLocator.Instance.AppointmentService;
            int upcomingAppointments = appointmentService.GetAppointmentCountByDateRange(DateTime.Now.ToString(), DateTime.Now.AddMinutes(15).ToString());
            if (upcomingAppointments > 0)
            {
                    Messages.ShowInfo("Upcoming Apopintments", "You have appointments set to start within the next 15 minutes.");
            }
        }
    }
}
