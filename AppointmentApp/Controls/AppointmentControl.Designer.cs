namespace AppointmentApp.Controls
{
    partial class AppointmentControl
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.appointmentLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.appointmentGridView = new System.Windows.Forms.DataGridView();
            this.newAppointmentButton = new System.Windows.Forms.Button();
            this.updateAppointmentButton = new System.Windows.Forms.Button();
            this.deleteAppointmentButton = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.allApptsButton = new System.Windows.Forms.Button();
            this.currentWeekApptsButton = new System.Windows.Forms.Button();
            this.currentMonthApptsButton = new System.Windows.Forms.Button();
            this.apptTitle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.apptCustomer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.apptDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.apptType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.apptStart = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.apptEnd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.appointmentLayoutPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.appointmentGridView)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // appointmentLayoutPanel
            // 
            this.appointmentLayoutPanel.ColumnCount = 3;
            this.appointmentLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 13.40142F));
            this.appointmentLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 72.08341F));
            this.appointmentLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.51516F));
            this.appointmentLayoutPanel.Controls.Add(this.appointmentGridView, 0, 2);
            this.appointmentLayoutPanel.Controls.Add(this.newAppointmentButton, 2, 0);
            this.appointmentLayoutPanel.Controls.Add(this.updateAppointmentButton, 0, 0);
            this.appointmentLayoutPanel.Controls.Add(this.deleteAppointmentButton, 1, 0);
            this.appointmentLayoutPanel.Controls.Add(this.tableLayoutPanel1, 1, 1);
            this.appointmentLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.appointmentLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.appointmentLayoutPanel.Name = "appointmentLayoutPanel";
            this.appointmentLayoutPanel.RowCount = 3;
            this.appointmentLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.appointmentLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.appointmentLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.appointmentLayoutPanel.Size = new System.Drawing.Size(986, 462);
            this.appointmentLayoutPanel.TabIndex = 4;
            // 
            // appointmentGridView
            // 
            this.appointmentGridView.AllowUserToAddRows = false;
            this.appointmentGridView.AllowUserToDeleteRows = false;
            this.appointmentGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.appointmentGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.appointmentGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.apptTitle,
            this.apptCustomer,
            this.apptDescription,
            this.apptType,
            this.apptStart,
            this.apptEnd});
            this.appointmentLayoutPanel.SetColumnSpan(this.appointmentGridView, 3);
            this.appointmentGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.appointmentGridView.Location = new System.Drawing.Point(3, 83);
            this.appointmentGridView.Name = "appointmentGridView";
            this.appointmentGridView.ReadOnly = true;
            this.appointmentGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.appointmentGridView.Size = new System.Drawing.Size(980, 376);
            this.appointmentGridView.TabIndex = 0;
            // 
            // newAppointmentButton
            // 
            this.newAppointmentButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.newAppointmentButton.Location = new System.Drawing.Point(874, 14);
            this.newAppointmentButton.Name = "newAppointmentButton";
            this.newAppointmentButton.Size = new System.Drawing.Size(109, 23);
            this.newAppointmentButton.TabIndex = 2;
            this.newAppointmentButton.Text = "New Appointment";
            this.newAppointmentButton.UseVisualStyleBackColor = true;
            // 
            // updateAppointmentButton
            // 
            this.updateAppointmentButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.updateAppointmentButton.Location = new System.Drawing.Point(3, 14);
            this.updateAppointmentButton.Name = "updateAppointmentButton";
            this.updateAppointmentButton.Size = new System.Drawing.Size(103, 23);
            this.updateAppointmentButton.TabIndex = 1;
            this.updateAppointmentButton.Text = "Update Selected";
            this.updateAppointmentButton.UseVisualStyleBackColor = true;
            // 
            // deleteAppointmentButton
            // 
            this.deleteAppointmentButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.deleteAppointmentButton.ForeColor = System.Drawing.Color.Firebrick;
            this.deleteAppointmentButton.Location = new System.Drawing.Point(135, 14);
            this.deleteAppointmentButton.Name = "deleteAppointmentButton";
            this.deleteAppointmentButton.Size = new System.Drawing.Size(91, 23);
            this.deleteAppointmentButton.TabIndex = 2;
            this.deleteAppointmentButton.Text = "Delete Selected";
            this.deleteAppointmentButton.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.Controls.Add(this.allApptsButton, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.currentWeekApptsButton, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.currentMonthApptsButton, 2, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(135, 43);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(704, 34);
            this.tableLayoutPanel1.TabIndex = 3;
            // 
            // allApptsButton
            // 
            this.allApptsButton.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.allApptsButton.Location = new System.Drawing.Point(116, 5);
            this.allApptsButton.Name = "allApptsButton";
            this.allApptsButton.Size = new System.Drawing.Size(115, 23);
            this.allApptsButton.TabIndex = 0;
            this.allApptsButton.Text = "All Appointments";
            this.allApptsButton.UseVisualStyleBackColor = true;
            // 
            // currentWeekApptsButton
            // 
            this.currentWeekApptsButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.currentWeekApptsButton.Location = new System.Drawing.Point(293, 5);
            this.currentWeekApptsButton.Name = "currentWeekApptsButton";
            this.currentWeekApptsButton.Size = new System.Drawing.Size(115, 23);
            this.currentWeekApptsButton.TabIndex = 0;
            this.currentWeekApptsButton.Text = "Current Week";
            this.currentWeekApptsButton.UseVisualStyleBackColor = true;
            // 
            // currentMonthApptsButton
            // 
            this.currentMonthApptsButton.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.currentMonthApptsButton.Location = new System.Drawing.Point(471, 5);
            this.currentMonthApptsButton.Name = "currentMonthApptsButton";
            this.currentMonthApptsButton.Size = new System.Drawing.Size(115, 23);
            this.currentMonthApptsButton.TabIndex = 0;
            this.currentMonthApptsButton.Text = "Current Month";
            this.currentMonthApptsButton.UseVisualStyleBackColor = true;
            // 
            // apptTitle
            // 
            this.apptTitle.DataPropertyName = "Title";
            this.apptTitle.HeaderText = "Title";
            this.apptTitle.Name = "apptTitle";
            this.apptTitle.ReadOnly = true;
            // 
            // apptCustomer
            // 
            this.apptCustomer.DataPropertyName = "CustomerName";
            this.apptCustomer.HeaderText = "Customer";
            this.apptCustomer.Name = "apptCustomer";
            this.apptCustomer.ReadOnly = true;
            // 
            // apptDescription
            // 
            this.apptDescription.DataPropertyName = "Description";
            this.apptDescription.HeaderText = "Description";
            this.apptDescription.Name = "apptDescription";
            this.apptDescription.ReadOnly = true;
            // 
            // apptType
            // 
            this.apptType.DataPropertyName = "Type";
            this.apptType.HeaderText = "Type";
            this.apptType.Name = "apptType";
            this.apptType.ReadOnly = true;
            // 
            // apptStart
            // 
            this.apptStart.DataPropertyName = "Start";
            dataGridViewCellStyle1.Format = "g";
            dataGridViewCellStyle1.NullValue = null;
            this.apptStart.DefaultCellStyle = dataGridViewCellStyle1;
            this.apptStart.HeaderText = "Start Time";
            this.apptStart.Name = "apptStart";
            this.apptStart.ReadOnly = true;
            // 
            // apptEnd
            // 
            this.apptEnd.DataPropertyName = "End";
            dataGridViewCellStyle2.Format = "g";
            dataGridViewCellStyle2.NullValue = null;
            this.apptEnd.DefaultCellStyle = dataGridViewCellStyle2;
            this.apptEnd.HeaderText = "End Time";
            this.apptEnd.Name = "apptEnd";
            this.apptEnd.ReadOnly = true;
            // 
            // AppointmentControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.appointmentLayoutPanel);
            this.Name = "AppointmentControl";
            this.Size = new System.Drawing.Size(986, 462);
            this.appointmentLayoutPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.appointmentGridView)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel appointmentLayoutPanel;
        private System.Windows.Forms.DataGridView appointmentGridView;
        private System.Windows.Forms.Button newAppointmentButton;
        private System.Windows.Forms.Button updateAppointmentButton;
        private System.Windows.Forms.Button deleteAppointmentButton;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button allApptsButton;
        private System.Windows.Forms.Button currentWeekApptsButton;
        private System.Windows.Forms.Button currentMonthApptsButton;
        private System.Windows.Forms.DataGridViewTextBoxColumn apptTitle;
        private System.Windows.Forms.DataGridViewTextBoxColumn apptCustomer;
        private System.Windows.Forms.DataGridViewTextBoxColumn apptDescription;
        private System.Windows.Forms.DataGridViewTextBoxColumn apptType;
        private System.Windows.Forms.DataGridViewTextBoxColumn apptStart;
        private System.Windows.Forms.DataGridViewTextBoxColumn apptEnd;
    }
}
