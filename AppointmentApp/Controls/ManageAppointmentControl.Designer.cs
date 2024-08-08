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
            this.backToApptsButton = new System.Windows.Forms.Button();
            this.apptFormPanel = new System.Windows.Forms.Panel();
            this.formErrorListLabel = new System.Windows.Forms.Label();
            this.apptLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // apptLayoutPanel
            // 
            this.apptLayoutPanel.ColumnCount = 3;
            this.apptLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20.89249F));
            this.apptLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 64.50304F));
            this.apptLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.5F));
            this.apptLayoutPanel.Controls.Add(this.backToApptsButton, 0, 0);
            this.apptLayoutPanel.Controls.Add(this.apptFormPanel, 1, 1);
            this.apptLayoutPanel.Controls.Add(this.formErrorListLabel, 0, 1);
            this.apptLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.apptLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.apptLayoutPanel.Name = "apptLayoutPanel";
            this.apptLayoutPanel.RowCount = 2;
            this.apptLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 39F));
            this.apptLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.apptLayoutPanel.Size = new System.Drawing.Size(986, 462);
            this.apptLayoutPanel.TabIndex = 4;
            // 
            // backToApptsButton
            // 
            this.backToApptsButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.backToApptsButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.backToApptsButton.Location = new System.Drawing.Point(3, 13);
            this.backToApptsButton.Name = "backToApptsButton";
            this.backToApptsButton.Size = new System.Drawing.Size(123, 23);
            this.backToApptsButton.TabIndex = 2;
            this.backToApptsButton.Text = "Back To Appointments";
            this.backToApptsButton.UseVisualStyleBackColor = true;
            // 
            // apptFormPanel
            // 
            this.apptFormPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.apptFormPanel.Location = new System.Drawing.Point(209, 42);
            this.apptFormPanel.Name = "apptFormPanel";
            this.apptFormPanel.Size = new System.Drawing.Size(630, 417);
            this.apptFormPanel.TabIndex = 3;
            // 
            // formErrorListLabel
            // 
            this.formErrorListLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.formErrorListLabel.AutoSize = true;
            this.formErrorListLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.formErrorListLabel.ForeColor = System.Drawing.Color.Firebrick;
            this.formErrorListLabel.Location = new System.Drawing.Point(3, 242);
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
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel apptLayoutPanel;
        private System.Windows.Forms.Button backToApptsButton;
        private System.Windows.Forms.Panel apptFormPanel;
        private System.Windows.Forms.Label formErrorListLabel;
    }
}
