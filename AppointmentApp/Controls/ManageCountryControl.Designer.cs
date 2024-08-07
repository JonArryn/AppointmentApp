namespace AppointmentApp.Controls
{
    partial class ManageCountryControl
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
            this.manageCountryTItle = new System.Windows.Forms.Label();
            this.countryLabel = new System.Windows.Forms.Label();
            this.countryNameTextbox = new System.Windows.Forms.TextBox();
            this.saveEditCountryButton = new System.Windows.Forms.Button();
            this.cancelEditCountryButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // manageCountryTItle
            // 
            this.manageCountryTItle.AutoSize = true;
            this.manageCountryTItle.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.manageCountryTItle.Location = new System.Drawing.Point(4, 0);
            this.manageCountryTItle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.manageCountryTItle.Name = "manageCountryTItle";
            this.manageCountryTItle.Size = new System.Drawing.Size(149, 24);
            this.manageCountryTItle.TabIndex = 3;
            this.manageCountryTItle.Text = "Manage Country";
            // 
            // countryLabel
            // 
            this.countryLabel.AutoSize = true;
            this.countryLabel.Location = new System.Drawing.Point(67, 93);
            this.countryLabel.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.countryLabel.Name = "countryLabel";
            this.countryLabel.Size = new System.Drawing.Size(92, 16);
            this.countryLabel.TabIndex = 0;
            this.countryLabel.Text = "Country Name";
            // 
            // countryNameTextbox
            // 
            this.countryNameTextbox.Location = new System.Drawing.Point(166, 90);
            this.countryNameTextbox.Margin = new System.Windows.Forms.Padding(4);
            this.countryNameTextbox.Name = "countryNameTextbox";
            this.countryNameTextbox.Size = new System.Drawing.Size(195, 22);
            this.countryNameTextbox.TabIndex = 1;
            this.countryNameTextbox.TextChanged += new System.EventHandler(this.countryNameTextbox_TextChanged);
            // 
            // saveEditCountryButton
            // 
            this.saveEditCountryButton.Location = new System.Drawing.Point(312, 173);
            this.saveEditCountryButton.Name = "saveEditCountryButton";
            this.saveEditCountryButton.Size = new System.Drawing.Size(75, 23);
            this.saveEditCountryButton.TabIndex = 4;
            this.saveEditCountryButton.Text = "Save";
            this.saveEditCountryButton.UseVisualStyleBackColor = true;
            this.saveEditCountryButton.Click += new System.EventHandler(this.saveEditCountryButton_Click);
            // 
            // cancelEditCountryButton
            // 
            this.cancelEditCountryButton.ForeColor = System.Drawing.Color.Firebrick;
            this.cancelEditCountryButton.Location = new System.Drawing.Point(118, 173);
            this.cancelEditCountryButton.Name = "cancelEditCountryButton";
            this.cancelEditCountryButton.Size = new System.Drawing.Size(75, 23);
            this.cancelEditCountryButton.TabIndex = 4;
            this.cancelEditCountryButton.Text = "Cancel";
            this.cancelEditCountryButton.UseVisualStyleBackColor = true;
            this.cancelEditCountryButton.Click += new System.EventHandler(this.cancelEditCountryButton_Click);
            // 
            // ManageCountryControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.manageCountryTItle);
            this.Controls.Add(this.cancelEditCountryButton);
            this.Controls.Add(this.countryNameTextbox);
            this.Controls.Add(this.saveEditCountryButton);
            this.Controls.Add(this.countryLabel);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ManageCountryControl";
            this.Size = new System.Drawing.Size(472, 230);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label manageCountryTItle;
        private System.Windows.Forms.Label countryLabel;
        private System.Windows.Forms.TextBox countryNameTextbox;
        private System.Windows.Forms.Button saveEditCountryButton;
        private System.Windows.Forms.Button cancelEditCountryButton;
    }
}
