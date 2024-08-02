namespace AppointmentApp
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
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.mainPanel = new System.Windows.Forms.Panel();
            this.appointmentsButton = new System.Windows.Forms.Button();
            this.resportsButton = new System.Windows.Forms.Button();
            this.customersButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(689, 590);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(323, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "You Have Successfully Reached The App - Congrats";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 587);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(193, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Exit Application";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // mainPanel
            // 
            this.mainPanel.BackColor = System.Drawing.SystemColors.Window;
            this.mainPanel.Location = new System.Drawing.Point(12, 81);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(1000, 500);
            this.mainPanel.TabIndex = 2;
            // 
            // appointmentsButton
            // 
            this.appointmentsButton.Location = new System.Drawing.Point(118, 52);
            this.appointmentsButton.Name = "appointmentsButton";
            this.appointmentsButton.Size = new System.Drawing.Size(107, 23);
            this.appointmentsButton.TabIndex = 4;
            this.appointmentsButton.Text = "Appointments";
            this.appointmentsButton.UseVisualStyleBackColor = true;
            // 
            // resportsButton
            // 
            this.resportsButton.Location = new System.Drawing.Point(231, 52);
            this.resportsButton.Name = "resportsButton";
            this.resportsButton.Size = new System.Drawing.Size(107, 23);
            this.resportsButton.TabIndex = 5;
            this.resportsButton.Text = "Reports";
            this.resportsButton.UseVisualStyleBackColor = true;
            // 
            // customersButton
            // 
            this.customersButton.Location = new System.Drawing.Point(12, 52);
            this.customersButton.Name = "customersButton";
            this.customersButton.Size = new System.Drawing.Size(100, 23);
            this.customersButton.TabIndex = 6;
            this.customersButton.Text = "Customers";
            this.customersButton.UseVisualStyleBackColor = true;
            // 
            // MainView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(1034, 625);
            this.Controls.Add(this.customersButton);
            this.Controls.Add(this.resportsButton);
            this.Controls.Add(this.appointmentsButton);
            this.Controls.Add(this.mainPanel);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "MainView";
            this.Text = "Appointment App by Vale Software";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel mainPanel;
        private System.Windows.Forms.Button appointmentsButton;
        private System.Windows.Forms.Button resportsButton;
        private System.Windows.Forms.Button customersButton;
    }
}

