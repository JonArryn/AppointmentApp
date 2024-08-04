using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppointmentApp.Dialogs
{
    public partial class ManageEntityDialog : Form
    {
        public ManageEntityDialog(string dialogTitle, UserControl control)
        {
            InitializeComponent();
            this.Text = dialogTitle;
            this.Controls.Add(control);
            control.Dock = DockStyle.Fill;
            this.Size = new Size(control.Width + 20, control.Height + 40);

        }
    }
}
