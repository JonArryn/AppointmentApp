namespace AppointmentApp.Controls
{
    partial class ManageCityControl
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
            this.cityLabel = new System.Windows.Forms.Label();
            this.cityNameTextbox = new System.Windows.Forms.TextBox();
            this.countryLabel = new System.Windows.Forms.Label();
            this.countryComboBox = new System.Windows.Forms.ComboBox();
            this.manageCityTItle = new System.Windows.Forms.Label();
            this.saveEditCityButton = new System.Windows.Forms.Button();
            this.cancelEditCityButton = new System.Windows.Forms.Button();
            this.editCountryLink = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // cityLabel
            // 
            this.cityLabel.AutoSize = true;
            this.cityLabel.Location = new System.Drawing.Point(82, 78);
            this.cityLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.cityLabel.Name = "cityLabel";
            this.cityLabel.Size = new System.Drawing.Size(69, 16);
            this.cityLabel.TabIndex = 0;
            this.cityLabel.Text = "City Name";
            // 
            // cityNameTextbox
            // 
            this.cityNameTextbox.Location = new System.Drawing.Point(158, 75);
            this.cityNameTextbox.Name = "cityNameTextbox";
            this.cityNameTextbox.Size = new System.Drawing.Size(195, 22);
            this.cityNameTextbox.TabIndex = 1;
            this.cityNameTextbox.TextChanged += new System.EventHandler(this.cityNameTextbox_TextChanged);
            // 
            // countryLabel
            // 
            this.countryLabel.AutoSize = true;
            this.countryLabel.Location = new System.Drawing.Point(103, 116);
            this.countryLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.countryLabel.Name = "countryLabel";
            this.countryLabel.Size = new System.Drawing.Size(48, 16);
            this.countryLabel.TabIndex = 0;
            this.countryLabel.Text = "County";
            // 
            // countryComboBox
            // 
            this.countryComboBox.Enabled = false;
            this.countryComboBox.FormattingEnabled = true;
            this.countryComboBox.Location = new System.Drawing.Point(158, 113);
            this.countryComboBox.Name = "countryComboBox";
            this.countryComboBox.Size = new System.Drawing.Size(195, 24);
            this.countryComboBox.TabIndex = 2;
            this.countryComboBox.SelectedValueChanged += new System.EventHandler(this.countryComboBox_SelectedValueChanged);
            // 
            // manageCityTItle
            // 
            this.manageCityTItle.AutoSize = true;
            this.manageCityTItle.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.manageCityTItle.Location = new System.Drawing.Point(4, 4);
            this.manageCityTItle.Name = "manageCityTItle";
            this.manageCityTItle.Size = new System.Drawing.Size(114, 24);
            this.manageCityTItle.TabIndex = 3;
            this.manageCityTItle.Text = "Manage City";
            // 
            // saveEditCityButton
            // 
            this.saveEditCityButton.Location = new System.Drawing.Point(278, 183);
            this.saveEditCityButton.Name = "saveEditCityButton";
            this.saveEditCityButton.Size = new System.Drawing.Size(75, 23);
            this.saveEditCityButton.TabIndex = 4;
            this.saveEditCityButton.Text = "Save";
            this.saveEditCityButton.UseVisualStyleBackColor = true;
            this.saveEditCityButton.Click += new System.EventHandler(this.saveEditCityButton_Click);
            // 
            // cancelEditCityButton
            // 
            this.cancelEditCityButton.ForeColor = System.Drawing.Color.Firebrick;
            this.cancelEditCityButton.Location = new System.Drawing.Point(85, 183);
            this.cancelEditCityButton.Name = "cancelEditCityButton";
            this.cancelEditCityButton.Size = new System.Drawing.Size(75, 23);
            this.cancelEditCityButton.TabIndex = 4;
            this.cancelEditCityButton.Text = "Cancel";
            this.cancelEditCityButton.UseVisualStyleBackColor = true;
            this.cancelEditCityButton.Click += new System.EventHandler(this.cancelEditCityButton_Click);
            // 
            // editCountryLink
            // 
            this.editCountryLink.AutoSize = true;
            this.editCountryLink.Location = new System.Drawing.Point(359, 116);
            this.editCountryLink.Name = "editCountryLink";
            this.editCountryLink.Size = new System.Drawing.Size(78, 16);
            this.editCountryLink.TabIndex = 5;
            this.editCountryLink.TabStop = true;
            this.editCountryLink.Text = "Edit Country";
            this.editCountryLink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.editCountryLink_LinkClicked);
            // 
            // ManageCityControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.editCountryLink);
            this.Controls.Add(this.cancelEditCityButton);
            this.Controls.Add(this.saveEditCityButton);
            this.Controls.Add(this.manageCityTItle);
            this.Controls.Add(this.countryComboBox);
            this.Controls.Add(this.cityNameTextbox);
            this.Controls.Add(this.countryLabel);
            this.Controls.Add(this.cityLabel);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ManageCityControl";
            this.Size = new System.Drawing.Size(472, 230);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label cityLabel;
        private System.Windows.Forms.TextBox cityNameTextbox;
        private System.Windows.Forms.Label countryLabel;
        private System.Windows.Forms.ComboBox countryComboBox;
        private System.Windows.Forms.Label manageCityTItle;
        private System.Windows.Forms.Button saveEditCityButton;
        private System.Windows.Forms.Button cancelEditCityButton;
        private System.Windows.Forms.LinkLabel editCountryLink;
    }
}
