using AppointmentApp.Database;
using AppointmentApp.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;




// TODO: BONUS add logout functionality

namespace AppointmentApp
{
    public partial class LoginForm : Form
    {
        private readonly UserService _userService;
        private readonly Translations _translations;
        public LoginForm(UserService userService, Translations tranlations)
        {
            InitializeComponent();
            this.invalidLoginLabel.Visible = false;
            _userService = userService;
            _translations = tranlations;
            TranslateLoginForm();
        }

        private void TranslateLoginForm()
        {
            Dictionary<string, string> formTranslations;


            
            if (_translations.CurrentCulture != "en" ) {
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
        }

        private void dbResetAndSeed_Click(object sender, EventArgs e)
        {
            DbHelper.ResetAndSeedDatabase();
        }

        private void dbResetTables_Click(object sender, EventArgs e)
        {
            DbHelper.ResetDatabaseTables();
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            string userName = usernameInputText.Text;
            string password = passwordInputText.Text;
 
            _userService.StartSession(userName, password);

            if (_userService.IsLoggedIn)
            {
                Hide();
                new MainView().Show();
            }
            else
            {
                this.invalidLoginLabel.Visible = true;
            }

            
        }

        private void usernameInputText_TextChanged(object sender, EventArgs e)
        {
            this.invalidLoginLabel.Visible = false;
        }

        private void passwordInputText_TextChanged(object sender, EventArgs e)
        {
            this.invalidLoginLabel.Visible = false;
        }
    }
}
