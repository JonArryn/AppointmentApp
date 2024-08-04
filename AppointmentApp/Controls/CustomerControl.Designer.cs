namespace AppointmentApp.Controls
{
    partial class CustomerControl
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
            this.customerGridView = new System.Windows.Forms.DataGridView();
            this.customerName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.customerAddress = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.customerPhone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.updateCustomerButton = new System.Windows.Forms.Button();
            this.deleteCustomerButton = new System.Windows.Forms.Button();
            this.newCustomerButton = new System.Windows.Forms.Button();
            this.customerLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.customerGridView)).BeginInit();
            this.customerLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // customerGridView
            // 
            this.customerGridView.AllowUserToAddRows = false;
            this.customerGridView.AllowUserToDeleteRows = false;
            this.customerGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.customerGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.customerGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.customerGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.customerName,
            this.customerAddress,
            this.customerPhone});
            this.customerLayoutPanel.SetColumnSpan(this.customerGridView, 3);
            this.customerGridView.Location = new System.Drawing.Point(3, 42);
            this.customerGridView.Name = "customerGridView";
            this.customerGridView.ReadOnly = true;
            this.customerGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.customerGridView.Size = new System.Drawing.Size(980, 417);
            this.customerGridView.TabIndex = 0;
            this.customerGridView.SelectionChanged += new System.EventHandler(this.customerGridView_SelectionChanged);
            // 
            // customerName
            // 
            this.customerName.DataPropertyName = "customerName";
            this.customerName.HeaderText = "Name";
            this.customerName.Name = "customerName";
            this.customerName.ReadOnly = true;
            // 
            // customerAddress
            // 
            this.customerAddress.DataPropertyName = "Address";
            this.customerAddress.HeaderText = "Address";
            this.customerAddress.Name = "customerAddress";
            this.customerAddress.ReadOnly = true;
            // 
            // customerPhone
            // 
            this.customerPhone.DataPropertyName = "phone";
            this.customerPhone.HeaderText = "Phone Number";
            this.customerPhone.Name = "customerPhone";
            this.customerPhone.ReadOnly = true;
            // 
            // updateCustomerButton
            // 
            this.updateCustomerButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.updateCustomerButton.Location = new System.Drawing.Point(3, 13);
            this.updateCustomerButton.Name = "updateCustomerButton";
            this.updateCustomerButton.Size = new System.Drawing.Size(103, 23);
            this.updateCustomerButton.TabIndex = 1;
            this.updateCustomerButton.Text = "Update Selected";
            this.updateCustomerButton.UseVisualStyleBackColor = true;
            this.updateCustomerButton.Click += new System.EventHandler(this.updateCustomerButton_Click);
            // 
            // deleteCustomerButton
            // 
            this.deleteCustomerButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.deleteCustomerButton.ForeColor = System.Drawing.Color.Firebrick;
            this.deleteCustomerButton.Location = new System.Drawing.Point(135, 13);
            this.deleteCustomerButton.Name = "deleteCustomerButton";
            this.deleteCustomerButton.Size = new System.Drawing.Size(91, 23);
            this.deleteCustomerButton.TabIndex = 2;
            this.deleteCustomerButton.Text = "Delete Selected";
            this.deleteCustomerButton.UseVisualStyleBackColor = true;
            this.deleteCustomerButton.Click += new System.EventHandler(this.deleteCustomerButton_Click);
            // 
            // newCustomerButton
            // 
            this.newCustomerButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.newCustomerButton.Location = new System.Drawing.Point(874, 13);
            this.newCustomerButton.Name = "newCustomerButton";
            this.newCustomerButton.Size = new System.Drawing.Size(109, 23);
            this.newCustomerButton.TabIndex = 2;
            this.newCustomerButton.Text = "New Customer";
            this.newCustomerButton.UseVisualStyleBackColor = true;
            // 
            // customerLayoutPanel
            // 
            this.customerLayoutPanel.ColumnCount = 3;
            this.customerLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 13.38742F));
            this.customerLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 72.00811F));
            this.customerLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.5F));
            this.customerLayoutPanel.Controls.Add(this.customerGridView, 0, 1);
            this.customerLayoutPanel.Controls.Add(this.newCustomerButton, 2, 0);
            this.customerLayoutPanel.Controls.Add(this.updateCustomerButton, 0, 0);
            this.customerLayoutPanel.Controls.Add(this.deleteCustomerButton, 1, 0);
            this.customerLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.customerLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.customerLayoutPanel.Name = "customerLayoutPanel";
            this.customerLayoutPanel.RowCount = 2;
            this.customerLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 39F));
            this.customerLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.customerLayoutPanel.Size = new System.Drawing.Size(986, 462);
            this.customerLayoutPanel.TabIndex = 3;
            // 
            // CustomerControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.Controls.Add(this.customerLayoutPanel);
            this.Name = "CustomerControl";
            this.Size = new System.Drawing.Size(986, 462);
            ((System.ComponentModel.ISupportInitialize)(this.customerGridView)).EndInit();
            this.customerLayoutPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView customerGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn customerName;
        private System.Windows.Forms.DataGridViewTextBoxColumn customerAddress;
        private System.Windows.Forms.DataGridViewTextBoxColumn customerPhone;
        private System.Windows.Forms.Button updateCustomerButton;
        private System.Windows.Forms.Button deleteCustomerButton;
        private System.Windows.Forms.Button newCustomerButton;
        private System.Windows.Forms.TableLayoutPanel customerLayoutPanel;
    }
}
