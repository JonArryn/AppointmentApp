namespace AppointmentApp.Controls
{
    partial class UpdateCustomerControl
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
            this.saveUpdateCustomerButton = new System.Windows.Forms.Button();
            this.customerLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.cancelUpdateCustomerButton = new System.Windows.Forms.Button();
            this.customerFormPanel = new System.Windows.Forms.Panel();
            this.customerLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // saveUpdateCustomerButton
            // 
            this.saveUpdateCustomerButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.saveUpdateCustomerButton.Location = new System.Drawing.Point(847, 13);
            this.saveUpdateCustomerButton.Name = "saveUpdateCustomerButton";
            this.saveUpdateCustomerButton.Size = new System.Drawing.Size(109, 23);
            this.saveUpdateCustomerButton.TabIndex = 2;
            this.saveUpdateCustomerButton.Text = "Save";
            this.saveUpdateCustomerButton.UseVisualStyleBackColor = true;
            // 
            // customerLayoutPanel
            // 
            this.customerLayoutPanel.ColumnCount = 3;
            this.customerLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 13.38742F));
            this.customerLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 72.00811F));
            this.customerLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.5F));
            this.customerLayoutPanel.Controls.Add(this.saveUpdateCustomerButton, 2, 0);
            this.customerLayoutPanel.Controls.Add(this.cancelUpdateCustomerButton, 0, 0);
            this.customerLayoutPanel.Controls.Add(this.customerFormPanel, 1, 1);
            this.customerLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.customerLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.customerLayoutPanel.Name = "customerLayoutPanel";
            this.customerLayoutPanel.RowCount = 2;
            this.customerLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 39F));
            this.customerLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.customerLayoutPanel.Size = new System.Drawing.Size(989, 462);
            this.customerLayoutPanel.TabIndex = 3;
            // 
            // cancelUpdateCustomerButton
            // 
            this.cancelUpdateCustomerButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cancelUpdateCustomerButton.ForeColor = System.Drawing.Color.Firebrick;
            this.cancelUpdateCustomerButton.Location = new System.Drawing.Point(3, 13);
            this.cancelUpdateCustomerButton.Name = "cancelUpdateCustomerButton";
            this.cancelUpdateCustomerButton.Size = new System.Drawing.Size(91, 23);
            this.cancelUpdateCustomerButton.TabIndex = 2;
            this.cancelUpdateCustomerButton.Text = "Cancel";
            this.cancelUpdateCustomerButton.UseVisualStyleBackColor = true;
            this.cancelUpdateCustomerButton.Click += new System.EventHandler(this.cancelUpdateCustomerButton_Click);
            // 
            // customerFormPanel
            // 
            this.customerFormPanel.AutoSize = true;
            this.customerFormPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.customerFormPanel.Location = new System.Drawing.Point(135, 42);
            this.customerFormPanel.Name = "customerFormPanel";
            this.customerFormPanel.Size = new System.Drawing.Size(706, 417);
            this.customerFormPanel.TabIndex = 3;
            // 
            // UpdateCustomerControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.Controls.Add(this.customerLayoutPanel);
            this.Name = "UpdateCustomerControl";
            this.Size = new System.Drawing.Size(989, 462);
            this.customerLayoutPanel.ResumeLayout(false);
            this.customerLayoutPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button saveUpdateCustomerButton;
        private System.Windows.Forms.TableLayoutPanel customerLayoutPanel;
        private System.Windows.Forms.Button cancelUpdateCustomerButton;
        private System.Windows.Forms.Panel customerFormPanel;
    }
}
