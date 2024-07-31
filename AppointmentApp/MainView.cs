using AppointmentApp.Database;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppointmentApp
{
    public partial class MainView : Form
    {
        public MainView()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataTable table = DbConnection.connection.GetSchema("Databases");
            DbHelper.ResetAndSeedDatabase();
        }

        private void dbResetAndSeed_Click(object sender, EventArgs e)
        {
            DbHelper.ResetAndSeedDatabase();
        }

        private void dbResetTables_Click(object sender, EventArgs e)
        {
            DbHelper.ResetDatabaseTables();
        }
    }
}
