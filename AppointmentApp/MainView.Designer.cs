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
            this.dbResetAndSeed = new System.Windows.Forms.Button();
            this.dbResetTables = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // dbResetAndSeed
            // 
            this.dbResetAndSeed.Location = new System.Drawing.Point(12, 12);
            this.dbResetAndSeed.Name = "dbResetAndSeed";
            this.dbResetAndSeed.Size = new System.Drawing.Size(154, 23);
            this.dbResetAndSeed.TabIndex = 0;
            this.dbResetAndSeed.Text = "Reset And Seed DB";
            this.dbResetAndSeed.UseVisualStyleBackColor = true;
            this.dbResetAndSeed.Click += new System.EventHandler(this.dbResetAndSeed_Click);
            // 
            // dbResetTables
            // 
            this.dbResetTables.Location = new System.Drawing.Point(634, 12);
            this.dbResetTables.Name = "dbResetTables";
            this.dbResetTables.Size = new System.Drawing.Size(154, 23);
            this.dbResetTables.TabIndex = 0;
            this.dbResetTables.Text = "Reset DB Tables";
            this.dbResetTables.UseVisualStyleBackColor = true;
            this.dbResetTables.Click += new System.EventHandler(this.dbResetTables_Click);
            // 
            // MainView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dbResetTables);
            this.Controls.Add(this.dbResetAndSeed);
            this.Name = "MainView";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button dbResetAndSeed;
        private System.Windows.Forms.Button dbResetTables;
    }
}

