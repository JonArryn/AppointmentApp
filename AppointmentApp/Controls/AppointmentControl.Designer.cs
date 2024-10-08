﻿namespace AppointmentApp.Controls
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.appointmentLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.appointmentGridView = new System.Windows.Forms.DataGridView();
            this.apptTitle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.apptCustomer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.apptDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.apptType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.apptStart = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.apptEnd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.newAppointmentButton = new System.Windows.Forms.Button();
            this.updateAppointmentButton = new System.Windows.Forms.Button();
            this.deleteAppointmentButton = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.apptRangeComboBox = new System.Windows.Forms.ComboBox();
            this.dateRangeLabel = new System.Windows.Forms.Label();
            this.chooseCalendarDayPicker = new System.Windows.Forms.DateTimePicker();
            this.chooseCalendarDayLabel = new System.Windows.Forms.Label();
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
            this.appointmentGridView.SelectionChanged += new System.EventHandler(this.appointmentGridView_SelectionChanged);
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
            dataGridViewCellStyle3.Format = "g";
            dataGridViewCellStyle3.NullValue = null;
            this.apptStart.DefaultCellStyle = dataGridViewCellStyle3;
            this.apptStart.HeaderText = "Start Time";
            this.apptStart.Name = "apptStart";
            this.apptStart.ReadOnly = true;
            // 
            // apptEnd
            // 
            this.apptEnd.DataPropertyName = "End";
            dataGridViewCellStyle4.Format = "g";
            dataGridViewCellStyle4.NullValue = null;
            this.apptEnd.DefaultCellStyle = dataGridViewCellStyle4;
            this.apptEnd.HeaderText = "End Time";
            this.apptEnd.Name = "apptEnd";
            this.apptEnd.ReadOnly = true;
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
            this.newAppointmentButton.Click += new System.EventHandler(this.newAppointmentButton_Click);
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
            this.updateAppointmentButton.Click += new System.EventHandler(this.updateAppointmentButton_Click);
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
            this.deleteAppointmentButton.Click += new System.EventHandler(this.deleteAppointmentButton_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 153F));
            this.tableLayoutPanel1.Controls.Add(this.apptRangeComboBox, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.dateRangeLabel, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.chooseCalendarDayPicker, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.chooseCalendarDayLabel, 2, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(135, 43);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(704, 34);
            this.tableLayoutPanel1.TabIndex = 3;
            // 
            // apptRangeComboBox
            // 
            this.apptRangeComboBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.apptRangeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.apptRangeComboBox.FormattingEnabled = true;
            this.apptRangeComboBox.Location = new System.Drawing.Point(191, 6);
            this.apptRangeComboBox.Name = "apptRangeComboBox";
            this.apptRangeComboBox.Size = new System.Drawing.Size(167, 21);
            this.apptRangeComboBox.TabIndex = 0;
            this.apptRangeComboBox.SelectedValueChanged += new System.EventHandler(this.apptRangeComboBox_SelectedValueChanged);
            // 
            // dateRangeLabel
            // 
            this.dateRangeLabel.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.dateRangeLabel.AutoSize = true;
            this.dateRangeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateRangeLabel.Location = new System.Drawing.Point(100, 9);
            this.dateRangeLabel.Name = "dateRangeLabel";
            this.dateRangeLabel.Size = new System.Drawing.Size(80, 16);
            this.dateRangeLabel.TabIndex = 1;
            this.dateRangeLabel.Text = "Date Range";
            // 
            // chooseCalendarDayPicker
            // 
            this.chooseCalendarDayPicker.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.chooseCalendarDayPicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.chooseCalendarDayPicker.Location = new System.Drawing.Point(560, 7);
            this.chooseCalendarDayPicker.Name = "chooseCalendarDayPicker";
            this.chooseCalendarDayPicker.Size = new System.Drawing.Size(132, 20);
            this.chooseCalendarDayPicker.TabIndex = 2;
            this.chooseCalendarDayPicker.ValueChanged += new System.EventHandler(this.chooseCalendarDayPicker_ValueChanged);
            // 
            // chooseCalendarDayLabel
            // 
            this.chooseCalendarDayLabel.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.chooseCalendarDayLabel.AutoSize = true;
            this.chooseCalendarDayLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chooseCalendarDayLabel.Location = new System.Drawing.Point(468, 9);
            this.chooseCalendarDayLabel.Name = "chooseCalendarDayLabel";
            this.chooseCalendarDayLabel.Size = new System.Drawing.Size(78, 16);
            this.chooseCalendarDayLabel.TabIndex = 3;
            this.chooseCalendarDayLabel.Text = "Day to View";
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
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel appointmentLayoutPanel;
        private System.Windows.Forms.DataGridView appointmentGridView;
        private System.Windows.Forms.Button newAppointmentButton;
        private System.Windows.Forms.Button updateAppointmentButton;
        private System.Windows.Forms.Button deleteAppointmentButton;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.DataGridViewTextBoxColumn apptTitle;
        private System.Windows.Forms.DataGridViewTextBoxColumn apptCustomer;
        private System.Windows.Forms.DataGridViewTextBoxColumn apptDescription;
        private System.Windows.Forms.DataGridViewTextBoxColumn apptType;
        private System.Windows.Forms.DataGridViewTextBoxColumn apptStart;
        private System.Windows.Forms.DataGridViewTextBoxColumn apptEnd;
        private System.Windows.Forms.ComboBox apptRangeComboBox;
        private System.Windows.Forms.Label dateRangeLabel;
        private System.Windows.Forms.DateTimePicker chooseCalendarDayPicker;
        private System.Windows.Forms.Label chooseCalendarDayLabel;
    }
}
