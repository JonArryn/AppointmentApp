namespace AppointmentApp.Controls
{
    partial class ManageAppointmentControl
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
            this.apptLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.apptFormPanel = new System.Windows.Forms.Panel();
            this.lengthMinutesLabel = new System.Windows.Forms.Label();
            this.apptDurationUpDown = new System.Windows.Forms.NumericUpDown();
            this.changeCustomerLink = new System.Windows.Forms.LinkLabel();
            this.apptTitleTextBox = new System.Windows.Forms.TextBox();
            this.apptTitleLabel = new System.Windows.Forms.Label();
            this.apptCustomerLabel = new System.Windows.Forms.Label();
            this.apptDescriptionLabel = new System.Windows.Forms.Label();
            this.apptTypeTextBox = new System.Windows.Forms.TextBox();
            this.apptCancelButton = new System.Windows.Forms.Button();
            this.apptCustomerComboBox = new System.Windows.Forms.ComboBox();
            this.appointmentLengthLabel = new System.Windows.Forms.Label();
            this.apptSaveButton = new System.Windows.Forms.Button();
            this.startTimeLabel = new System.Windows.Forms.Label();
            this.apptTypeLabel = new System.Windows.Forms.Label();
            this.apptDescriptionTextBox = new System.Windows.Forms.TextBox();
            this.manageApptLabel = new System.Windows.Forms.Label();
            this.startTimePicker = new System.Windows.Forms.DateTimePicker();
            this.backToApptsButton = new System.Windows.Forms.Button();
            this.formErrorListLabel = new System.Windows.Forms.Label();
            this.apptLayoutPanel.SuspendLayout();
            this.apptFormPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.apptDurationUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // apptLayoutPanel
            // 
            this.apptLayoutPanel.ColumnCount = 3;
            this.apptLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.apptLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.30426F));
            this.apptLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 29.71602F));
            this.apptLayoutPanel.Controls.Add(this.apptFormPanel, 1, 1);
            this.apptLayoutPanel.Controls.Add(this.backToApptsButton, 0, 0);
            this.apptLayoutPanel.Controls.Add(this.formErrorListLabel, 0, 1);
            this.apptLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.apptLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.apptLayoutPanel.Name = "apptLayoutPanel";
            this.apptLayoutPanel.RowCount = 2;
            this.apptLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.apptLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.apptLayoutPanel.Size = new System.Drawing.Size(986, 462);
            this.apptLayoutPanel.TabIndex = 4;
            // 
            // apptFormPanel
            // 
            this.apptFormPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.apptFormPanel.BackColor = System.Drawing.SystemColors.Window;
            this.apptLayoutPanel.SetColumnSpan(this.apptFormPanel, 2);
            this.apptFormPanel.Controls.Add(this.lengthMinutesLabel);
            this.apptFormPanel.Controls.Add(this.apptDurationUpDown);
            this.apptFormPanel.Controls.Add(this.changeCustomerLink);
            this.apptFormPanel.Controls.Add(this.apptTitleTextBox);
            this.apptFormPanel.Controls.Add(this.apptTitleLabel);
            this.apptFormPanel.Controls.Add(this.apptCustomerLabel);
            this.apptFormPanel.Controls.Add(this.apptDescriptionLabel);
            this.apptFormPanel.Controls.Add(this.apptTypeTextBox);
            this.apptFormPanel.Controls.Add(this.apptCancelButton);
            this.apptFormPanel.Controls.Add(this.apptCustomerComboBox);
            this.apptFormPanel.Controls.Add(this.appointmentLengthLabel);
            this.apptFormPanel.Controls.Add(this.apptSaveButton);
            this.apptFormPanel.Controls.Add(this.startTimeLabel);
            this.apptFormPanel.Controls.Add(this.apptTypeLabel);
            this.apptFormPanel.Controls.Add(this.apptDescriptionTextBox);
            this.apptFormPanel.Controls.Add(this.manageApptLabel);
            this.apptFormPanel.Controls.Add(this.startTimePicker);
            this.apptFormPanel.Location = new System.Drawing.Point(200, 43);
            this.apptFormPanel.Name = "apptFormPanel";
            this.apptFormPanel.Size = new System.Drawing.Size(483, 416);
            this.apptFormPanel.TabIndex = 3;
            // 
            // lengthMinutesLabel
            // 
            this.lengthMinutesLabel.AutoSize = true;
            this.lengthMinutesLabel.Location = new System.Drawing.Point(153, 300);
            this.lengthMinutesLabel.Name = "lengthMinutesLabel";
            this.lengthMinutesLabel.Size = new System.Drawing.Size(44, 13);
            this.lengthMinutesLabel.TabIndex = 8;
            this.lengthMinutesLabel.Text = "Minutes";
            // 
            // apptDurationUpDown
            // 
            this.apptDurationUpDown.Location = new System.Drawing.Point(144, 277);
            this.apptDurationUpDown.Name = "apptDurationUpDown";
            this.apptDurationUpDown.Size = new System.Drawing.Size(76, 20);
            this.apptDurationUpDown.TabIndex = 7;
            this.apptDurationUpDown.ValueChanged += new System.EventHandler(this.apptDurationUpDown_ValueChanged);
            // 
            // changeCustomerLink
            // 
            this.changeCustomerLink.AutoSize = true;
            this.changeCustomerLink.Location = new System.Drawing.Point(367, 167);
            this.changeCustomerLink.Name = "changeCustomerLink";
            this.changeCustomerLink.Size = new System.Drawing.Size(91, 13);
            this.changeCustomerLink.TabIndex = 5;
            this.changeCustomerLink.TabStop = true;
            this.changeCustomerLink.Text = "Change Customer";
            this.changeCustomerLink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.changeCustomerLink_LinkClicked);
            // 
            // apptTitleTextBox
            // 
            this.apptTitleTextBox.Location = new System.Drawing.Point(144, 110);
            this.apptTitleTextBox.Name = "apptTitleTextBox";
            this.apptTitleTextBox.Size = new System.Drawing.Size(217, 20);
            this.apptTitleTextBox.TabIndex = 1;
            this.apptTitleTextBox.TextChanged += new System.EventHandler(this.apptTitleTextBox_TextChanged);
            // 
            // apptTitleLabel
            // 
            this.apptTitleLabel.AutoSize = true;
            this.apptTitleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.apptTitleLabel.Location = new System.Drawing.Point(102, 111);
            this.apptTitleLabel.Name = "apptTitleLabel";
            this.apptTitleLabel.Size = new System.Drawing.Size(33, 16);
            this.apptTitleLabel.TabIndex = 0;
            this.apptTitleLabel.Text = "Title";
            // 
            // apptCustomerLabel
            // 
            this.apptCustomerLabel.AutoSize = true;
            this.apptCustomerLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.apptCustomerLabel.Location = new System.Drawing.Point(74, 164);
            this.apptCustomerLabel.Name = "apptCustomerLabel";
            this.apptCustomerLabel.Size = new System.Drawing.Size(64, 16);
            this.apptCustomerLabel.TabIndex = 0;
            this.apptCustomerLabel.Text = "Customer";
            // 
            // apptDescriptionLabel
            // 
            this.apptDescriptionLabel.AutoSize = true;
            this.apptDescriptionLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.apptDescriptionLabel.Location = new System.Drawing.Point(63, 137);
            this.apptDescriptionLabel.Name = "apptDescriptionLabel";
            this.apptDescriptionLabel.Size = new System.Drawing.Size(75, 16);
            this.apptDescriptionLabel.TabIndex = 0;
            this.apptDescriptionLabel.Text = "Description";
            // 
            // apptTypeTextBox
            // 
            this.apptTypeTextBox.Location = new System.Drawing.Point(144, 190);
            this.apptTypeTextBox.Name = "apptTypeTextBox";
            this.apptTypeTextBox.Size = new System.Drawing.Size(218, 20);
            this.apptTypeTextBox.TabIndex = 1;
            this.apptTypeTextBox.TextChanged += new System.EventHandler(this.apptTypeTextBox_TextChanged);
            // 
            // apptCancelButton
            // 
            this.apptCancelButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.apptCancelButton.ForeColor = System.Drawing.Color.Firebrick;
            this.apptCancelButton.Location = new System.Drawing.Point(17, 373);
            this.apptCancelButton.Name = "apptCancelButton";
            this.apptCancelButton.Size = new System.Drawing.Size(75, 23);
            this.apptCancelButton.TabIndex = 4;
            this.apptCancelButton.Text = "Cancel";
            this.apptCancelButton.UseVisualStyleBackColor = true;
            // 
            // apptCustomerComboBox
            // 
            this.apptCustomerComboBox.FormattingEnabled = true;
            this.apptCustomerComboBox.Location = new System.Drawing.Point(144, 163);
            this.apptCustomerComboBox.Name = "apptCustomerComboBox";
            this.apptCustomerComboBox.Size = new System.Drawing.Size(217, 21);
            this.apptCustomerComboBox.TabIndex = 2;
            this.apptCustomerComboBox.SelectedValueChanged += new System.EventHandler(this.apptCustomerComboBox_SelectedValueChanged);
            // 
            // appointmentLengthLabel
            // 
            this.appointmentLengthLabel.AutoSize = true;
            this.appointmentLengthLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.appointmentLengthLabel.Location = new System.Drawing.Point(78, 277);
            this.appointmentLengthLabel.Name = "appointmentLengthLabel";
            this.appointmentLengthLabel.Size = new System.Drawing.Size(57, 16);
            this.appointmentLengthLabel.TabIndex = 0;
            this.appointmentLengthLabel.Text = "Duration";
            // 
            // apptSaveButton
            // 
            this.apptSaveButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.apptSaveButton.Location = new System.Drawing.Point(391, 373);
            this.apptSaveButton.Name = "apptSaveButton";
            this.apptSaveButton.Size = new System.Drawing.Size(75, 23);
            this.apptSaveButton.TabIndex = 4;
            this.apptSaveButton.Text = "Save";
            this.apptSaveButton.UseVisualStyleBackColor = true;
            this.apptSaveButton.Click += new System.EventHandler(this.apptSaveButton_Click);
            // 
            // startTimeLabel
            // 
            this.startTimeLabel.AutoSize = true;
            this.startTimeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.startTimeLabel.Location = new System.Drawing.Point(70, 243);
            this.startTimeLabel.Name = "startTimeLabel";
            this.startTimeLabel.Size = new System.Drawing.Size(68, 16);
            this.startTimeLabel.TabIndex = 0;
            this.startTimeLabel.Text = "Start Time";
            // 
            // apptTypeLabel
            // 
            this.apptTypeLabel.AutoSize = true;
            this.apptTypeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.apptTypeLabel.Location = new System.Drawing.Point(93, 191);
            this.apptTypeLabel.Name = "apptTypeLabel";
            this.apptTypeLabel.Size = new System.Drawing.Size(39, 16);
            this.apptTypeLabel.TabIndex = 0;
            this.apptTypeLabel.Text = "Type";
            // 
            // apptDescriptionTextBox
            // 
            this.apptDescriptionTextBox.Location = new System.Drawing.Point(144, 136);
            this.apptDescriptionTextBox.Name = "apptDescriptionTextBox";
            this.apptDescriptionTextBox.Size = new System.Drawing.Size(217, 20);
            this.apptDescriptionTextBox.TabIndex = 1;
            this.apptDescriptionTextBox.TextChanged += new System.EventHandler(this.apptDescriptionTextBox_TextChanged);
            // 
            // manageApptLabel
            // 
            this.manageApptLabel.AutoSize = true;
            this.manageApptLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.manageApptLabel.Location = new System.Drawing.Point(140, 21);
            this.manageApptLabel.Name = "manageApptLabel";
            this.manageApptLabel.Size = new System.Drawing.Size(191, 24);
            this.manageApptLabel.TabIndex = 0;
            this.manageApptLabel.Text = "Manage Appointment";
            // 
            // startTimePicker
            // 
            this.startTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.startTimePicker.Location = new System.Drawing.Point(144, 239);
            this.startTimePicker.Name = "startTimePicker";
            this.startTimePicker.Size = new System.Drawing.Size(217, 20);
            this.startTimePicker.TabIndex = 3;
            this.startTimePicker.ValueChanged += new System.EventHandler(this.startTimePicker_ValueChanged);
            // 
            // backToApptsButton
            // 
            this.backToApptsButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.backToApptsButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.backToApptsButton.Location = new System.Drawing.Point(3, 14);
            this.backToApptsButton.Name = "backToApptsButton";
            this.backToApptsButton.Size = new System.Drawing.Size(123, 23);
            this.backToApptsButton.TabIndex = 2;
            this.backToApptsButton.Text = "Back To Appointments";
            this.backToApptsButton.UseVisualStyleBackColor = true;
            this.backToApptsButton.Click += new System.EventHandler(this.backToApptsButton_Click);
            // 
            // formErrorListLabel
            // 
            this.formErrorListLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.formErrorListLabel.AutoSize = true;
            this.formErrorListLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.formErrorListLabel.ForeColor = System.Drawing.Color.Firebrick;
            this.formErrorListLabel.Location = new System.Drawing.Point(3, 243);
            this.formErrorListLabel.Name = "formErrorListLabel";
            this.formErrorListLabel.Size = new System.Drawing.Size(77, 16);
            this.formErrorListLabel.TabIndex = 4;
            this.formErrorListLabel.Text = "Form Errors";
            // 
            // ManageAppointmentControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.apptLayoutPanel);
            this.Name = "ManageAppointmentControl";
            this.Size = new System.Drawing.Size(986, 462);
            this.apptLayoutPanel.ResumeLayout(false);
            this.apptLayoutPanel.PerformLayout();
            this.apptFormPanel.ResumeLayout(false);
            this.apptFormPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.apptDurationUpDown)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel apptLayoutPanel;
        private System.Windows.Forms.Button backToApptsButton;
        private System.Windows.Forms.Panel apptFormPanel;
        private System.Windows.Forms.Label formErrorListLabel;
        private System.Windows.Forms.TextBox apptTitleTextBox;
        private System.Windows.Forms.Label apptTitleLabel;
        private System.Windows.Forms.Label apptCustomerLabel;
        private System.Windows.Forms.Label apptDescriptionLabel;
        private System.Windows.Forms.TextBox apptTypeTextBox;
        private System.Windows.Forms.Button apptCancelButton;
        private System.Windows.Forms.ComboBox apptCustomerComboBox;
        private System.Windows.Forms.Label appointmentLengthLabel;
        private System.Windows.Forms.Button apptSaveButton;
        private System.Windows.Forms.Label startTimeLabel;
        private System.Windows.Forms.Label apptTypeLabel;
        private System.Windows.Forms.TextBox apptDescriptionTextBox;
        private System.Windows.Forms.Label manageApptLabel;
        private System.Windows.Forms.DateTimePicker startTimePicker;
        private System.Windows.Forms.LinkLabel changeCustomerLink;
        private System.Windows.Forms.Label lengthMinutesLabel;
        private System.Windows.Forms.NumericUpDown apptDurationUpDown;
    }
}
