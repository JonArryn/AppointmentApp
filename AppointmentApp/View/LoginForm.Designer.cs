namespace AppointmentApp
{
    partial class LoginForm
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
            this.dbResetAndSeed = new System.Windows.Forms.Button();
            this.dbResetTables = new System.Windows.Forms.Button();
            this.loginButton = new System.Windows.Forms.Button();
            this.usernameInputText = new System.Windows.Forms.TextBox();
            this.passwordInputText = new System.Windows.Forms.TextBox();
            this.usernameInputLabel = new System.Windows.Forms.Label();
            this.passwordInputLabel = new System.Windows.Forms.Label();
            this.invalidLoginLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // dbResetAndSeed
            // 
            this.dbResetAndSeed.Location = new System.Drawing.Point(16, 15);
            this.dbResetAndSeed.Margin = new System.Windows.Forms.Padding(4);
            this.dbResetAndSeed.Name = "dbResetAndSeed";
            this.dbResetAndSeed.Size = new System.Drawing.Size(205, 28);
            this.dbResetAndSeed.TabIndex = 0;
            this.dbResetAndSeed.Text = "Reset And Seed DB";
            this.dbResetAndSeed.UseVisualStyleBackColor = true;
            this.dbResetAndSeed.Click += new System.EventHandler(this.dbResetAndSeed_Click);
            // 
            // dbResetTables
            // 
            this.dbResetTables.Location = new System.Drawing.Point(229, 15);
            this.dbResetTables.Margin = new System.Windows.Forms.Padding(4);
            this.dbResetTables.Name = "dbResetTables";
            this.dbResetTables.Size = new System.Drawing.Size(205, 28);
            this.dbResetTables.TabIndex = 0;
            this.dbResetTables.Text = "Reset DB Tables";
            this.dbResetTables.UseVisualStyleBackColor = true;
            this.dbResetTables.Click += new System.EventHandler(this.dbResetTables_Click);
            // 
            // loginButton
            // 
            this.loginButton.Location = new System.Drawing.Point(179, 144);
            this.loginButton.Margin = new System.Windows.Forms.Padding(4);
            this.loginButton.Name = "loginButton";
            this.loginButton.Size = new System.Drawing.Size(100, 28);
            this.loginButton.TabIndex = 1;
            this.loginButton.Text = "Login";
            this.loginButton.UseVisualStyleBackColor = true;
            this.loginButton.Click += new System.EventHandler(this.loginButton_Click);
            // 
            // usernameInputText
            // 
            this.usernameInputText.Location = new System.Drawing.Point(144, 87);
            this.usernameInputText.Name = "usernameInputText";
            this.usernameInputText.Size = new System.Drawing.Size(188, 22);
            this.usernameInputText.TabIndex = 2;
            // 
            // passwordInputText
            // 
            this.passwordInputText.Location = new System.Drawing.Point(144, 115);
            this.passwordInputText.Name = "passwordInputText";
            this.passwordInputText.PasswordChar = '*';
            this.passwordInputText.Size = new System.Drawing.Size(188, 22);
            this.passwordInputText.TabIndex = 3;
            // 
            // usernameInputLabel
            // 
            this.usernameInputLabel.AutoSize = true;
            this.usernameInputLabel.Location = new System.Drawing.Point(68, 90);
            this.usernameInputLabel.Name = "usernameInputLabel";
            this.usernameInputLabel.Size = new System.Drawing.Size(70, 16);
            this.usernameInputLabel.TabIndex = 4;
            this.usernameInputLabel.Text = "Username";
            // 
            // passwordInputLabel
            // 
            this.passwordInputLabel.AutoSize = true;
            this.passwordInputLabel.Location = new System.Drawing.Point(71, 118);
            this.passwordInputLabel.Name = "passwordInputLabel";
            this.passwordInputLabel.Size = new System.Drawing.Size(67, 16);
            this.passwordInputLabel.TabIndex = 4;
            this.passwordInputLabel.Text = "Password";
            // 
            // invalidLoginLabel
            // 
            this.invalidLoginLabel.AutoSize = true;
            this.invalidLoginLabel.ForeColor = System.Drawing.Color.Firebrick;
            this.invalidLoginLabel.Location = new System.Drawing.Point(155, 208);
            this.invalidLoginLabel.Name = "invalidLoginLabel";
            this.invalidLoginLabel.Size = new System.Drawing.Size(149, 16);
            this.invalidLoginLabel.TabIndex = 5;
            this.invalidLoginLabel.Text = "User Credentials Invalid";
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(446, 256);
            this.Controls.Add(this.invalidLoginLabel);
            this.Controls.Add(this.passwordInputLabel);
            this.Controls.Add(this.usernameInputLabel);
            this.Controls.Add(this.passwordInputText);
            this.Controls.Add(this.usernameInputText);
            this.Controls.Add(this.loginButton);
            this.Controls.Add(this.dbResetTables);
            this.Controls.Add(this.dbResetAndSeed);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "LoginForm";
            this.Text = "Appointment App by Vale Software";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button dbResetAndSeed;
        private System.Windows.Forms.Button dbResetTables;
        private System.Windows.Forms.Button loginButton;
        private System.Windows.Forms.TextBox usernameInputText;
        private System.Windows.Forms.TextBox passwordInputText;
        private System.Windows.Forms.Label usernameInputLabel;
        private System.Windows.Forms.Label passwordInputLabel;
        private System.Windows.Forms.Label invalidLoginLabel;
    }
}

