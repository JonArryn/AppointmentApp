namespace AppointmentApp.Controls
{
    partial class ReportControl
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.appointmentTypesByMonthGroupBox = new System.Windows.Forms.GroupBox();
            this.apptByMonthDatePicker = new System.Windows.Forms.DateTimePicker();
            this.typeCountText = new System.Windows.Forms.Label();
            this.typeCountLabel = new System.Windows.Forms.Label();
            this.apptTypeLabel = new System.Windows.Forms.Label();
            this.apptTypeComboBox = new System.Windows.Forms.ComboBox();
            this.consultantScheduleGroupBox = new System.Windows.Forms.GroupBox();
            this.consultantApptsGridView = new System.Windows.Forms.DataGridView();
            this.consultantComboBox = new System.Windows.Forms.ComboBox();
            this.selectConsultantLabel = new System.Windows.Forms.Label();
            this.customerApptCountGroupBox = new System.Windows.Forms.GroupBox();
            this.customerAppointmentCountText = new System.Windows.Forms.Label();
            this.customerComboBox = new System.Windows.Forms.ComboBox();
            this.customerAppointmentCountLabel = new System.Windows.Forms.Label();
            this.selectCustomerLabel = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.appointmentTypesByMonthGroupBox.SuspendLayout();
            this.consultantScheduleGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.consultantApptsGridView)).BeginInit();
            this.customerApptCountGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.appointmentTypesByMonthGroupBox, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.consultantScheduleGroupBox, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.customerApptCountGroupBox, 0, 2);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 27.27273F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 48.05195F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 24.89178F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(900, 462);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // appointmentTypesByMonthGroupBox
            // 
            this.appointmentTypesByMonthGroupBox.Controls.Add(this.apptByMonthDatePicker);
            this.appointmentTypesByMonthGroupBox.Controls.Add(this.typeCountText);
            this.appointmentTypesByMonthGroupBox.Controls.Add(this.typeCountLabel);
            this.appointmentTypesByMonthGroupBox.Controls.Add(this.apptTypeLabel);
            this.appointmentTypesByMonthGroupBox.Controls.Add(this.apptTypeComboBox);
            this.appointmentTypesByMonthGroupBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.appointmentTypesByMonthGroupBox.Location = new System.Drawing.Point(3, 3);
            this.appointmentTypesByMonthGroupBox.Name = "appointmentTypesByMonthGroupBox";
            this.appointmentTypesByMonthGroupBox.Size = new System.Drawing.Size(844, 112);
            this.appointmentTypesByMonthGroupBox.TabIndex = 0;
            this.appointmentTypesByMonthGroupBox.TabStop = false;
            this.appointmentTypesByMonthGroupBox.Text = "Appointment Types by Month";
            // 
            // apptByMonthDatePicker
            // 
            this.apptByMonthDatePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.apptByMonthDatePicker.Location = new System.Drawing.Point(125, 27);
            this.apptByMonthDatePicker.Name = "apptByMonthDatePicker";
            this.apptByMonthDatePicker.Size = new System.Drawing.Size(175, 22);
            this.apptByMonthDatePicker.TabIndex = 1;
            this.apptByMonthDatePicker.ValueChanged += new System.EventHandler(this.apptByMonthDatePicker_ValueChanged);
            // 
            // typeCountText
            // 
            this.typeCountText.AutoSize = true;
            this.typeCountText.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.typeCountText.Location = new System.Drawing.Point(633, 51);
            this.typeCountText.Name = "typeCountText";
            this.typeCountText.Size = new System.Drawing.Size(24, 25);
            this.typeCountText.TabIndex = 2;
            this.typeCountText.Text = "0";
            // 
            // typeCountLabel
            // 
            this.typeCountLabel.AutoSize = true;
            this.typeCountLabel.Location = new System.Drawing.Point(473, 55);
            this.typeCountLabel.Name = "typeCountLabel";
            this.typeCountLabel.Size = new System.Drawing.Size(154, 16);
            this.typeCountLabel.TabIndex = 1;
            this.typeCountLabel.Text = "Appointment Type Count";
            // 
            // apptTypeLabel
            // 
            this.apptTypeLabel.AutoSize = true;
            this.apptTypeLabel.Location = new System.Drawing.Point(2, 58);
            this.apptTypeLabel.Name = "apptTypeLabel";
            this.apptTypeLabel.Size = new System.Drawing.Size(117, 16);
            this.apptTypeLabel.TabIndex = 1;
            this.apptTypeLabel.Text = "Appointment Type";
            // 
            // apptTypeComboBox
            // 
            this.apptTypeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.apptTypeComboBox.FormattingEnabled = true;
            this.apptTypeComboBox.Location = new System.Drawing.Point(125, 55);
            this.apptTypeComboBox.Name = "apptTypeComboBox";
            this.apptTypeComboBox.Size = new System.Drawing.Size(175, 24);
            this.apptTypeComboBox.TabIndex = 2;
            this.apptTypeComboBox.SelectedIndexChanged += new System.EventHandler(this.apptTypeComboBox_SelectedIndexChanged);
            // 
            // consultantScheduleGroupBox
            // 
            this.consultantScheduleGroupBox.Controls.Add(this.consultantApptsGridView);
            this.consultantScheduleGroupBox.Controls.Add(this.consultantComboBox);
            this.consultantScheduleGroupBox.Controls.Add(this.selectConsultantLabel);
            this.consultantScheduleGroupBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.consultantScheduleGroupBox.Location = new System.Drawing.Point(3, 128);
            this.consultantScheduleGroupBox.Name = "consultantScheduleGroupBox";
            this.consultantScheduleGroupBox.Size = new System.Drawing.Size(844, 215);
            this.consultantScheduleGroupBox.TabIndex = 0;
            this.consultantScheduleGroupBox.TabStop = false;
            this.consultantScheduleGroupBox.Text = "Consultant Appointments";
            // 
            // consultantApptsGridView
            // 
            this.consultantApptsGridView.AllowUserToAddRows = false;
            this.consultantApptsGridView.AllowUserToDeleteRows = false;
            this.consultantApptsGridView.AllowUserToResizeRows = false;
            this.consultantApptsGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.consultantApptsGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.consultantApptsGridView.Location = new System.Drawing.Point(288, 12);
            this.consultantApptsGridView.Name = "consultantApptsGridView";
            this.consultantApptsGridView.ReadOnly = true;
            this.consultantApptsGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.consultantApptsGridView.Size = new System.Drawing.Size(439, 197);
            this.consultantApptsGridView.TabIndex = 0;
            // 
            // consultantComboBox
            // 
            this.consultantComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.consultantComboBox.FormattingEnabled = true;
            this.consultantComboBox.Location = new System.Drawing.Point(6, 100);
            this.consultantComboBox.Name = "consultantComboBox";
            this.consultantComboBox.Size = new System.Drawing.Size(236, 24);
            this.consultantComboBox.TabIndex = 3;
            this.consultantComboBox.SelectedIndexChanged += new System.EventHandler(this.consultantComboBox_SelectedIndexChanged);
            // 
            // selectConsultantLabel
            // 
            this.selectConsultantLabel.AutoSize = true;
            this.selectConsultantLabel.Location = new System.Drawing.Point(3, 81);
            this.selectConsultantLabel.Name = "selectConsultantLabel";
            this.selectConsultantLabel.Size = new System.Drawing.Size(110, 16);
            this.selectConsultantLabel.TabIndex = 1;
            this.selectConsultantLabel.Text = "Select Consultant";
            // 
            // customerApptCountGroupBox
            // 
            this.customerApptCountGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.customerApptCountGroupBox.Controls.Add(this.customerAppointmentCountText);
            this.customerApptCountGroupBox.Controls.Add(this.customerComboBox);
            this.customerApptCountGroupBox.Controls.Add(this.customerAppointmentCountLabel);
            this.customerApptCountGroupBox.Controls.Add(this.selectCustomerLabel);
            this.customerApptCountGroupBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.customerApptCountGroupBox.Location = new System.Drawing.Point(3, 353);
            this.customerApptCountGroupBox.Name = "customerApptCountGroupBox";
            this.customerApptCountGroupBox.Size = new System.Drawing.Size(844, 106);
            this.customerApptCountGroupBox.TabIndex = 0;
            this.customerApptCountGroupBox.TabStop = false;
            this.customerApptCountGroupBox.Text = "Customer Appointment Counts";
            // 
            // customerAppointmentCountText
            // 
            this.customerAppointmentCountText.AutoSize = true;
            this.customerAppointmentCountText.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.customerAppointmentCountText.Location = new System.Drawing.Point(445, 48);
            this.customerAppointmentCountText.Name = "customerAppointmentCountText";
            this.customerAppointmentCountText.Size = new System.Drawing.Size(24, 25);
            this.customerAppointmentCountText.TabIndex = 2;
            this.customerAppointmentCountText.Text = "0";
            // 
            // customerComboBox
            // 
            this.customerComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.customerComboBox.FormattingEnabled = true;
            this.customerComboBox.Location = new System.Drawing.Point(6, 49);
            this.customerComboBox.Name = "customerComboBox";
            this.customerComboBox.Size = new System.Drawing.Size(236, 24);
            this.customerComboBox.TabIndex = 4;
            this.customerComboBox.SelectedIndexChanged += new System.EventHandler(this.customerComboBox_SelectedIndexChanged);
            // 
            // customerAppointmentCountLabel
            // 
            this.customerAppointmentCountLabel.AutoSize = true;
            this.customerAppointmentCountLabel.Location = new System.Drawing.Point(320, 52);
            this.customerAppointmentCountLabel.Name = "customerAppointmentCountLabel";
            this.customerAppointmentCountLabel.Size = new System.Drawing.Size(119, 16);
            this.customerAppointmentCountLabel.TabIndex = 1;
            this.customerAppointmentCountLabel.Text = "Appointment Count";
            // 
            // selectCustomerLabel
            // 
            this.selectCustomerLabel.AutoSize = true;
            this.selectCustomerLabel.Location = new System.Drawing.Point(3, 30);
            this.selectCustomerLabel.Name = "selectCustomerLabel";
            this.selectCustomerLabel.Size = new System.Drawing.Size(105, 16);
            this.selectCustomerLabel.TabIndex = 1;
            this.selectCustomerLabel.Text = "Select Customer";
            // 
            // ReportControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "ReportControl";
            this.Size = new System.Drawing.Size(850, 466);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.appointmentTypesByMonthGroupBox.ResumeLayout(false);
            this.appointmentTypesByMonthGroupBox.PerformLayout();
            this.consultantScheduleGroupBox.ResumeLayout(false);
            this.consultantScheduleGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.consultantApptsGridView)).EndInit();
            this.customerApptCountGroupBox.ResumeLayout(false);
            this.customerApptCountGroupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.GroupBox appointmentTypesByMonthGroupBox;
        private System.Windows.Forms.GroupBox consultantScheduleGroupBox;
        private System.Windows.Forms.GroupBox customerApptCountGroupBox;
        private System.Windows.Forms.ComboBox apptTypeComboBox;
        private System.Windows.Forms.Label typeCountLabel;
        private System.Windows.Forms.Label apptTypeLabel;
        private System.Windows.Forms.Label typeCountText;
        private System.Windows.Forms.DataGridView consultantApptsGridView;
        private System.Windows.Forms.ComboBox consultantComboBox;
        private System.Windows.Forms.Label selectConsultantLabel;
        private System.Windows.Forms.ComboBox customerComboBox;
        private System.Windows.Forms.Label selectCustomerLabel;
        private System.Windows.Forms.Label customerAppointmentCountText;
        private System.Windows.Forms.Label customerAppointmentCountLabel;
        private System.Windows.Forms.DateTimePicker apptByMonthDatePicker;
    }
}
