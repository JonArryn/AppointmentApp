namespace AppointmentApp.Controls
{
    partial class ManageCustomerControl
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        private void InitializeComponent()
        {
            this.customerLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.backToCustomersButton = new System.Windows.Forms.Button();
            this.customerFormPanel = new System.Windows.Forms.Panel();
            this.customerLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // customerLayoutPanel
            // 
            this.customerLayoutPanel.ColumnCount = 3;
            this.customerLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15.41582F));
            this.customerLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 69.97971F));
            this.customerLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.5F));
            this.customerLayoutPanel.Controls.Add(this.backToCustomersButton, 0, 0);
            this.customerLayoutPanel.Controls.Add(this.customerFormPanel, 1, 1);
            this.customerLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.customerLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.customerLayoutPanel.Name = "customerLayoutPanel";
            this.customerLayoutPanel.RowCount = 2;
            this.customerLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 39F));
            this.customerLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.customerLayoutPanel.Size = new System.Drawing.Size(986, 462);
            this.customerLayoutPanel.TabIndex = 3;
            // 
            // backToCustomersButton
            // 
            this.backToCustomersButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.backToCustomersButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.backToCustomersButton.Location = new System.Drawing.Point(3, 13);
            this.backToCustomersButton.Name = "backToCustomersButton";
            this.backToCustomersButton.Size = new System.Drawing.Size(123, 23);
            this.backToCustomersButton.TabIndex = 2;
            this.backToCustomersButton.Text = "Back To Customers";
            this.backToCustomersButton.UseVisualStyleBackColor = true;
            this.backToCustomersButton.Click += new System.EventHandler(this.cancelUpdateCustomerButton_Click);
            // 
            // customerFormPanel
            // 
            this.customerFormPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.customerFormPanel.Location = new System.Drawing.Point(155, 42);
            this.customerFormPanel.Name = "customerFormPanel";
            this.customerFormPanel.Size = new System.Drawing.Size(684, 417);
            this.customerFormPanel.TabIndex = 3;
            // 
            // ManageCustomerControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.customerLayoutPanel);
            this.Name = "ManageCustomerControl";
            this.Size = new System.Drawing.Size(986, 462);
            this.customerLayoutPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TableLayoutPanel customerLayoutPanel;
        private System.Windows.Forms.Button backToCustomersButton;
        private System.Windows.Forms.Panel customerFormPanel;
    }
}