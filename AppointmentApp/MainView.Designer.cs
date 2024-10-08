﻿namespace AppointmentApp
{
    partial class MainView
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.mainTabControl = new System.Windows.Forms.TabControl();
            this.customersTab = new System.Windows.Forms.TabPage();
            this.appointmentsTab = new System.Windows.Forms.TabPage();
            this.reportsTab = new System.Windows.Forms.TabPage();
            this.mainLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.logoutButton = new System.Windows.Forms.Button();
            this.mainAppLabel = new System.Windows.Forms.Label();
            this.mainTabControl.SuspendLayout();
            this.mainLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainTabControl
            // 
            this.mainLayoutPanel.SetColumnSpan(this.mainTabControl, 3);
            this.mainTabControl.Controls.Add(this.customersTab);
            this.mainTabControl.Controls.Add(this.appointmentsTab);
            this.mainTabControl.Controls.Add(this.reportsTab);
            this.mainTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainTabControl.Location = new System.Drawing.Point(3, 75);
            this.mainTabControl.Name = "mainTabControl";
            this.mainTabControl.SelectedIndex = 0;
            this.mainTabControl.Size = new System.Drawing.Size(994, 584);
            this.mainTabControl.TabIndex = 2;
            this.mainTabControl.SelectedIndexChanged += new System.EventHandler(this.mainTabControl_SelectedIndexChanged);
            // 
            // customersTab
            // 
            this.customersTab.BackColor = System.Drawing.SystemColors.Control;
            this.customersTab.Location = new System.Drawing.Point(4, 25);
            this.customersTab.Name = "customersTab";
            this.customersTab.Padding = new System.Windows.Forms.Padding(3);
            this.customersTab.Size = new System.Drawing.Size(986, 555);
            this.customersTab.TabIndex = 0;
            this.customersTab.Text = "Customers";
            // 
            // appointmentsTab
            // 
            this.appointmentsTab.Location = new System.Drawing.Point(4, 25);
            this.appointmentsTab.Name = "appointmentsTab";
            this.appointmentsTab.Padding = new System.Windows.Forms.Padding(3);
            this.appointmentsTab.Size = new System.Drawing.Size(986, 555);
            this.appointmentsTab.TabIndex = 1;
            this.appointmentsTab.Text = "Appointments";
            this.appointmentsTab.UseVisualStyleBackColor = true;
            // 
            // reportsTab
            // 
            this.reportsTab.Location = new System.Drawing.Point(4, 25);
            this.reportsTab.Name = "reportsTab";
            this.reportsTab.Size = new System.Drawing.Size(986, 555);
            this.reportsTab.TabIndex = 2;
            this.reportsTab.Text = "Reports";
            this.reportsTab.UseVisualStyleBackColor = true;
            // 
            // mainLayoutPanel
            // 
            this.mainLayoutPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.mainLayoutPanel.ColumnCount = 3;
            this.mainLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.mainLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 589F));
            this.mainLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 205F));
            this.mainLayoutPanel.Controls.Add(this.mainTabControl, 0, 1);
            this.mainLayoutPanel.Controls.Add(this.logoutButton, 2, 0);
            this.mainLayoutPanel.Controls.Add(this.mainAppLabel, 0, 0);
            this.mainLayoutPanel.Location = new System.Drawing.Point(22, 12);
            this.mainLayoutPanel.Name = "mainLayoutPanel";
            this.mainLayoutPanel.RowCount = 2;
            this.mainLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.89744F));
            this.mainLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 89.10256F));
            this.mainLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.mainLayoutPanel.Size = new System.Drawing.Size(1000, 662);
            this.mainLayoutPanel.TabIndex = 4;
            // 
            // logoutButton
            // 
            this.logoutButton.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.logoutButton.Location = new System.Drawing.Point(897, 18);
            this.logoutButton.Name = "logoutButton";
            this.logoutButton.Size = new System.Drawing.Size(100, 36);
            this.logoutButton.TabIndex = 1;
            this.logoutButton.Text = "Logout";
            this.logoutButton.UseVisualStyleBackColor = true;
            this.logoutButton.Click += new System.EventHandler(this.logoutButton_Click);
            // 
            // mainAppLabel
            // 
            this.mainAppLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.mainAppLabel.AutoSize = true;
            this.mainAppLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mainAppLabel.Location = new System.Drawing.Point(3, 23);
            this.mainAppLabel.Name = "mainAppLabel";
            this.mainAppLabel.Size = new System.Drawing.Size(176, 25);
            this.mainAppLabel.TabIndex = 3;
            this.mainAppLabel.Text = "Appointment App";
            // 
            // MainView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(1050, 686);
            this.Controls.Add(this.mainLayoutPanel);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "MainView";
            this.Text = "Appointment App by Vale Software";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainView_FormClosing_1);
            this.mainTabControl.ResumeLayout(false);
            this.mainLayoutPanel.ResumeLayout(false);
            this.mainLayoutPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TabControl mainTabControl;
        private System.Windows.Forms.TabPage customersTab;
        private System.Windows.Forms.TabPage appointmentsTab;
        private System.Windows.Forms.TabPage reportsTab;
        private System.Windows.Forms.TableLayoutPanel mainLayoutPanel;
        private System.Windows.Forms.Button logoutButton;
        private System.Windows.Forms.Label mainAppLabel;
    }
}

