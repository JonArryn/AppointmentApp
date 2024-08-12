namespace AppointmentApp.Controls
{
    partial class LoginControl
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
            this.dbResetAndSeed = new System.Windows.Forms.Button();
            this.dbResetTables = new System.Windows.Forms.Button();
            this.loginButton = new System.Windows.Forms.Button();
            this.usernameInputText = new System.Windows.Forms.TextBox();
            this.passwordInputText = new System.Windows.Forms.TextBox();
            this.usernameInputLabel = new System.Windows.Forms.Label();
            this.passwordInputLabel = new System.Windows.Forms.Label();
            this.invalidLoginLabel = new System.Windows.Forms.Label();
            this.currentLocationLabel = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.exitAppButton = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dbResetAndSeed
            // 
            this.dbResetAndSeed.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.dbResetAndSeed.Location = new System.Drawing.Point(7, 455);
            this.dbResetAndSeed.Margin = new System.Windows.Forms.Padding(5);
            this.dbResetAndSeed.Name = "dbResetAndSeed";
            this.dbResetAndSeed.Size = new System.Drawing.Size(273, 34);
            this.dbResetAndSeed.TabIndex = 0;
            this.dbResetAndSeed.Text = "Reset And Seed DB";
            this.dbResetAndSeed.UseVisualStyleBackColor = true;
            this.dbResetAndSeed.Visible = false;
            this.dbResetAndSeed.Click += new System.EventHandler(this.dbResetAndSeed_Click);
            // 
            // dbResetTables
            // 
            this.dbResetTables.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.dbResetTables.Location = new System.Drawing.Point(718, 455);
            this.dbResetTables.Margin = new System.Windows.Forms.Padding(5);
            this.dbResetTables.Name = "dbResetTables";
            this.dbResetTables.Size = new System.Drawing.Size(271, 34);
            this.dbResetTables.TabIndex = 0;
            this.dbResetTables.Text = "Reset DB Tables";
            this.dbResetTables.UseVisualStyleBackColor = true;
            this.dbResetTables.Visible = false;
            this.dbResetTables.Click += new System.EventHandler(this.dbResetTables_Click);
            // 
            // loginButton
            // 
            this.loginButton.Location = new System.Drawing.Point(143, 252);
            this.loginButton.Margin = new System.Windows.Forms.Padding(5);
            this.loginButton.Name = "loginButton";
            this.loginButton.Size = new System.Drawing.Size(133, 34);
            this.loginButton.TabIndex = 3;
            this.loginButton.TabStop = false;
            this.loginButton.Text = "Login";
            this.loginButton.UseVisualStyleBackColor = true;
            this.loginButton.Click += new System.EventHandler(this.loginButton_Click);
            // 
            // usernameInputText
            // 
            this.usernameInputText.Location = new System.Drawing.Point(92, 137);
            this.usernameInputText.Margin = new System.Windows.Forms.Padding(4);
            this.usernameInputText.Name = "usernameInputText";
            this.usernameInputText.Size = new System.Drawing.Size(249, 22);
            this.usernameInputText.TabIndex = 1;
            this.usernameInputText.TextChanged += new System.EventHandler(this.usernameInputText_TextChanged);
            this.usernameInputText.KeyDown += new System.Windows.Forms.KeyEventHandler(this.usernameInputText_KeyDown);
            // 
            // passwordInputText
            // 
            this.passwordInputText.Location = new System.Drawing.Point(92, 191);
            this.passwordInputText.Margin = new System.Windows.Forms.Padding(4);
            this.passwordInputText.Name = "passwordInputText";
            this.passwordInputText.PasswordChar = '*';
            this.passwordInputText.Size = new System.Drawing.Size(249, 22);
            this.passwordInputText.TabIndex = 2;
            this.passwordInputText.TextChanged += new System.EventHandler(this.passwordInputText_TextChanged);
            this.passwordInputText.KeyDown += new System.Windows.Forms.KeyEventHandler(this.passwordInputText_KeyDown);
            // 
            // usernameInputLabel
            // 
            this.usernameInputLabel.AutoSize = true;
            this.usernameInputLabel.Location = new System.Drawing.Point(89, 117);
            this.usernameInputLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.usernameInputLabel.Name = "usernameInputLabel";
            this.usernameInputLabel.Size = new System.Drawing.Size(70, 16);
            this.usernameInputLabel.TabIndex = 4;
            this.usernameInputLabel.Text = "Username";
            // 
            // passwordInputLabel
            // 
            this.passwordInputLabel.AutoSize = true;
            this.passwordInputLabel.Location = new System.Drawing.Point(88, 168);
            this.passwordInputLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.passwordInputLabel.Name = "passwordInputLabel";
            this.passwordInputLabel.Size = new System.Drawing.Size(67, 16);
            this.passwordInputLabel.TabIndex = 4;
            this.passwordInputLabel.Text = "Password";
            // 
            // invalidLoginLabel
            // 
            this.invalidLoginLabel.AutoSize = true;
            this.invalidLoginLabel.ForeColor = System.Drawing.Color.Firebrick;
            this.invalidLoginLabel.Location = new System.Drawing.Point(89, 81);
            this.invalidLoginLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.invalidLoginLabel.Name = "invalidLoginLabel";
            this.invalidLoginLabel.Size = new System.Drawing.Size(149, 16);
            this.invalidLoginLabel.TabIndex = 5;
            this.invalidLoginLabel.Text = "User Credentials Invalid";
            // 
            // currentLocationLabel
            // 
            this.currentLocationLabel.AutoSize = true;
            this.currentLocationLabel.Location = new System.Drawing.Point(91, 316);
            this.currentLocationLabel.Name = "currentLocationLabel";
            this.currentLocationLabel.Size = new System.Drawing.Size(109, 16);
            this.currentLocationLabel.TabIndex = 6;
            this.currentLocationLabel.Text = "Current Location :";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 28.97384F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 42.75654F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 28.16901F));
            this.tableLayoutPanel1.Controls.Add(this.panel1, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.dbResetTables, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.dbResetAndSeed, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.exitAppButton, 2, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.4031F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 87.5969F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(994, 494);
            this.tableLayoutPanel1.TabIndex = 7;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.loginButton);
            this.panel1.Controls.Add(this.currentLocationLabel);
            this.panel1.Controls.Add(this.usernameInputText);
            this.panel1.Controls.Add(this.invalidLoginLabel);
            this.panel1.Controls.Add(this.passwordInputText);
            this.panel1.Controls.Add(this.usernameInputLabel);
            this.panel1.Controls.Add(this.passwordInputLabel);
            this.panel1.Location = new System.Drawing.Point(291, 64);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(419, 427);
            this.panel1.TabIndex = 0;
            // 
            // exitAppButton
            // 
            this.exitAppButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.exitAppButton.ForeColor = System.Drawing.Color.Firebrick;
            this.exitAppButton.Location = new System.Drawing.Point(770, 13);
            this.exitAppButton.Margin = new System.Windows.Forms.Padding(5);
            this.exitAppButton.Name = "exitAppButton";
            this.exitAppButton.Size = new System.Drawing.Size(167, 34);
            this.exitAppButton.TabIndex = 0;
            this.exitAppButton.Text = "Exit Application";
            this.exitAppButton.UseVisualStyleBackColor = true;
            this.exitAppButton.Click += new System.EventHandler(this.exitAppButton_Click);
            // 
            // LoginControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "LoginControl";
            this.Size = new System.Drawing.Size(1000, 500);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

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
        private System.Windows.Forms.Label currentLocationLabel;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button exitAppButton;
    }
}
