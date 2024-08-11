using AppointmentApp.Constant;
using AppointmentApp.Database;
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

        private void loginButton_Click(object sender, EventArgs e)
        {
            string userName = usernameInputText.Text;
            string password = passwordInputText.Text;

            _userService = ServiceLocator.Instance.UserService;

            _userService.StartSession(userName, password);

            if (_userService.IsLoggedIn)
            {
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

    }
}
