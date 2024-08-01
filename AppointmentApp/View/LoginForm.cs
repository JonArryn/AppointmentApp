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

// TODO: Handle exceptions properly - the repo and service both do some exceptions, but we need to ensure we have a consistent way of understanding where exceptions are caught
// TODO: handle showing the login error message
// TODO: add translations and culture detection junk

namespace AppointmentApp
{
    public partial class LoginForm : Form
    {
        private readonly UserService _userService;
        public LoginForm(UserService userService)
        {
            InitializeComponent();
            _userService = userService;
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
                MessageBox.Show("Invalid username or password");
            }

            
        }
    }
}
