namespace AppointmentApp.Controls
{
    partial class ManageCustomerControl
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
            this.customerNameLabel = new System.Windows.Forms.Label();
            this.addressLabel = new System.Windows.Forms.Label();
            this.customerNameTextBox = new System.Windows.Forms.TextBox();
            this.addressTextBox = new System.Windows.Forms.TextBox();
            this.address2Label = new System.Windows.Forms.Label();
            this.address2TextBox = new System.Windows.Forms.TextBox();
            this.cityLabel = new System.Windows.Forms.Label();
            this.postalCodeLabel = new System.Windows.Forms.Label();
            this.postalCodeTextBox = new System.Windows.Forms.TextBox();
            this.countryLabel = new System.Windows.Forms.Label();
            this.customerPhoneLabel = new System.Windows.Forms.Label();
            this.customerPhoneTextBox = new System.Windows.Forms.TextBox();
            this.countryComboBox = new System.Windows.Forms.ComboBox();
            this.cityComboBox = new System.Windows.Forms.ComboBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.editCityLabel = new System.Windows.Forms.LinkLabel();
            this.newCityLabel = new System.Windows.Forms.LinkLabel();
            this.editCountryLabel = new System.Windows.Forms.LinkLabel();
            this.newCountryLabel = new System.Windows.Forms.LinkLabel();
            this.saveCustomerButton = new System.Windows.Forms.Button();
            this.cancelSaveCustomerButton = new System.Windows.Forms.Button();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.backToCustomersButton = new System.Windows.Forms.Button();
            this.customerFormPanel = new System.Windows.Forms.Panel();
            this.formErrorListLabel = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.customerFormPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // customerNameLabel
            // 
            this.customerNameLabel.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.customerNameLabel.AutoSize = true;
            this.customerNameLabel.Location = new System.Drawing.Point(4, 16);
            this.customerNameLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.customerNameLabel.Name = "customerNameLabel";
            this.customerNameLabel.Size = new System.Drawing.Size(104, 16);
            this.customerNameLabel.TabIndex = 0;
            this.customerNameLabel.Text = "Customer Name";
            // 
            // addressLabel
            // 
            this.addressLabel.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.addressLabel.AutoSize = true;
            this.addressLabel.Location = new System.Drawing.Point(50, 112);
            this.addressLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.addressLabel.Name = "addressLabel";
            this.addressLabel.Size = new System.Drawing.Size(58, 16);
            this.addressLabel.TabIndex = 0;
            this.addressLabel.Text = "Address";
            // 
            // customerNameTextBox
            // 
            this.customerNameTextBox.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.customerNameTextBox.Location = new System.Drawing.Point(115, 13);
            this.customerNameTextBox.Name = "customerNameTextBox";
            this.customerNameTextBox.Size = new System.Drawing.Size(153, 22);
            this.customerNameTextBox.TabIndex = 1;
            this.customerNameTextBox.TextChanged += new System.EventHandler(this.customerNameTextBox_TextChanged);
            // 
            // addressTextBox
            // 
            this.addressTextBox.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.addressTextBox.Location = new System.Drawing.Point(115, 109);
            this.addressTextBox.Name = "addressTextBox";
            this.addressTextBox.Size = new System.Drawing.Size(210, 22);
            this.addressTextBox.TabIndex = 3;
            this.addressTextBox.TextChanged += new System.EventHandler(this.addressTextBox_TextChanged);
            // 
            // address2Label
            // 
            this.address2Label.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.address2Label.AutoSize = true;
            this.address2Label.Location = new System.Drawing.Point(43, 160);
            this.address2Label.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.address2Label.Name = "address2Label";
            this.address2Label.Size = new System.Drawing.Size(65, 16);
            this.address2Label.TabIndex = 0;
            this.address2Label.Text = "Address2";
            // 
            // address2TextBox
            // 
            this.address2TextBox.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.address2TextBox.Location = new System.Drawing.Point(115, 157);
            this.address2TextBox.Name = "address2TextBox";
            this.address2TextBox.Size = new System.Drawing.Size(210, 22);
            this.address2TextBox.TabIndex = 4;
            this.address2TextBox.TextChanged += new System.EventHandler(this.address2TextBox_TextChanged);
            // 
            // cityLabel
            // 
            this.cityLabel.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.cityLabel.AutoSize = true;
            this.cityLabel.Location = new System.Drawing.Point(79, 208);
            this.cityLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.cityLabel.Name = "cityLabel";
            this.cityLabel.Size = new System.Drawing.Size(29, 16);
            this.cityLabel.TabIndex = 0;
            this.cityLabel.Text = "City";
            // 
            // postalCodeLabel
            // 
            this.postalCodeLabel.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.postalCodeLabel.AutoSize = true;
            this.postalCodeLabel.Location = new System.Drawing.Point(27, 256);
            this.postalCodeLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.postalCodeLabel.Name = "postalCodeLabel";
            this.postalCodeLabel.Size = new System.Drawing.Size(81, 16);
            this.postalCodeLabel.TabIndex = 0;
            this.postalCodeLabel.Text = "Postal Code";
            // 
            // postalCodeTextBox
            // 
            this.postalCodeTextBox.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.postalCodeTextBox.Location = new System.Drawing.Point(115, 253);
            this.postalCodeTextBox.Name = "postalCodeTextBox";
            this.postalCodeTextBox.Size = new System.Drawing.Size(210, 22);
            this.postalCodeTextBox.TabIndex = 6;
            this.postalCodeTextBox.TextChanged += new System.EventHandler(this.postalCodeTextBox_TextChanged);
            // 
            // countryLabel
            // 
            this.countryLabel.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.countryLabel.AutoSize = true;
            this.countryLabel.Location = new System.Drawing.Point(56, 304);
            this.countryLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.countryLabel.Name = "countryLabel";
            this.countryLabel.Size = new System.Drawing.Size(52, 16);
            this.countryLabel.TabIndex = 0;
            this.countryLabel.Text = "Country";
            // 
            // customerPhoneLabel
            // 
            this.customerPhoneLabel.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.customerPhoneLabel.AutoSize = true;
            this.customerPhoneLabel.Location = new System.Drawing.Point(11, 64);
            this.customerPhoneLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.customerPhoneLabel.Name = "customerPhoneLabel";
            this.customerPhoneLabel.Size = new System.Drawing.Size(97, 16);
            this.customerPhoneLabel.TabIndex = 0;
            this.customerPhoneLabel.Text = "Phone Number";
            // 
            // customerPhoneTextBox
            // 
            this.customerPhoneTextBox.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.customerPhoneTextBox.Location = new System.Drawing.Point(115, 61);
            this.customerPhoneTextBox.Name = "customerPhoneTextBox";
            this.customerPhoneTextBox.Size = new System.Drawing.Size(152, 22);
            this.customerPhoneTextBox.TabIndex = 2;
            this.customerPhoneTextBox.TextChanged += new System.EventHandler(this.customerPhoneTextBox_TextChanged);
            // 
            // countryComboBox
            // 
            this.countryComboBox.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.countryComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.countryComboBox.FormattingEnabled = true;
            this.countryComboBox.Location = new System.Drawing.Point(115, 302);
            this.countryComboBox.Name = "countryComboBox";
            this.countryComboBox.Size = new System.Drawing.Size(210, 24);
            this.countryComboBox.TabIndex = 7;
            this.countryComboBox.SelectedValueChanged += new System.EventHandler(this.countryComboBox_SelectedValueChanged);
            // 
            // cityComboBox
            // 
            this.cityComboBox.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cityComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cityComboBox.FormattingEnabled = true;
            this.cityComboBox.Location = new System.Drawing.Point(115, 205);
            this.cityComboBox.Name = "cityComboBox";
            this.cityComboBox.Size = new System.Drawing.Size(210, 24);
            this.cityComboBox.TabIndex = 5;
            this.cityComboBox.SelectedValueChanged += new System.EventHandler(this.cityComboBox_SelectedValueChanged);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.customerNameLabel, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.countryComboBox, 1, 6);
            this.tableLayoutPanel1.Controls.Add(this.cityComboBox, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.countryLabel, 0, 6);
            this.tableLayoutPanel1.Controls.Add(this.postalCodeTextBox, 1, 5);
            this.tableLayoutPanel1.Controls.Add(this.customerNameTextBox, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.customerPhoneLabel, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.postalCodeLabel, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.customerPhoneTextBox, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.addressLabel, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.addressTextBox, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.cityLabel, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.address2Label, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.address2TextBox, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.editCityLabel, 2, 4);
            this.tableLayoutPanel1.Controls.Add(this.newCityLabel, 3, 4);
            this.tableLayoutPanel1.Controls.Add(this.editCountryLabel, 2, 6);
            this.tableLayoutPanel1.Controls.Add(this.newCountryLabel, 3, 6);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(48, 16);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 7;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.49953F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.49953F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.49953F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.49953F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.49953F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.49953F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.49953F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(537, 337);
            this.tableLayoutPanel1.TabIndex = 3;
            // 
            // editCityLabel
            // 
            this.editCityLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.editCityLabel.AutoSize = true;
            this.editCityLabel.Location = new System.Drawing.Point(342, 208);
            this.editCityLabel.Name = "editCityLabel";
            this.editCityLabel.Size = new System.Drawing.Size(55, 16);
            this.editCityLabel.TabIndex = 3;
            this.editCityLabel.TabStop = true;
            this.editCityLabel.Text = "Edit City";
            this.editCityLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.editCityLabel_LinkClicked);
            // 
            // newCityLabel
            // 
            this.newCityLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.newCityLabel.AutoSize = true;
            this.newCityLabel.Location = new System.Drawing.Point(445, 208);
            this.newCityLabel.Name = "newCityLabel";
            this.newCityLabel.Size = new System.Drawing.Size(59, 16);
            this.newCityLabel.TabIndex = 3;
            this.newCityLabel.TabStop = true;
            this.newCityLabel.Text = "New City";
            this.newCityLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.newCityLabel_LinkClicked);
            // 
            // editCountryLabel
            // 
            this.editCountryLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.editCountryLabel.AutoSize = true;
            this.editCountryLabel.Location = new System.Drawing.Point(331, 304);
            this.editCountryLabel.Name = "editCountryLabel";
            this.editCountryLabel.Size = new System.Drawing.Size(78, 16);
            this.editCountryLabel.TabIndex = 3;
            this.editCountryLabel.TabStop = true;
            this.editCountryLabel.Text = "Edit Country";
            this.editCountryLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.editCountryLabel_LinkClicked);
            // 
            // newCountryLabel
            // 
            this.newCountryLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.newCountryLabel.AutoSize = true;
            this.newCountryLabel.Location = new System.Drawing.Point(433, 304);
            this.newCountryLabel.Name = "newCountryLabel";
            this.newCountryLabel.Size = new System.Drawing.Size(82, 16);
            this.newCountryLabel.TabIndex = 3;
            this.newCountryLabel.TabStop = true;
            this.newCountryLabel.Text = "New Country";
            this.newCountryLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.newCountryLabel_LinkClicked);
            // 
            // saveCustomerButton
            // 
            this.saveCustomerButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.saveCustomerButton.Location = new System.Drawing.Point(510, 371);
            this.saveCustomerButton.Name = "saveCustomerButton";
            this.saveCustomerButton.Size = new System.Drawing.Size(75, 23);
            this.saveCustomerButton.TabIndex = 8;
            this.saveCustomerButton.Text = "Save";
            this.saveCustomerButton.UseVisualStyleBackColor = true;
            this.saveCustomerButton.Click += new System.EventHandler(this.saveCustomerButton_Click);
            // 
            // cancelSaveCustomerButton
            // 
            this.cancelSaveCustomerButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cancelSaveCustomerButton.ForeColor = System.Drawing.Color.Firebrick;
            this.cancelSaveCustomerButton.Location = new System.Drawing.Point(48, 371);
            this.cancelSaveCustomerButton.Name = "cancelSaveCustomerButton";
            this.cancelSaveCustomerButton.Size = new System.Drawing.Size(75, 23);
            this.cancelSaveCustomerButton.TabIndex = 9;
            this.cancelSaveCustomerButton.Text = "Cancel";
            this.cancelSaveCustomerButton.UseVisualStyleBackColor = true;
            this.cancelSaveCustomerButton.Click += new System.EventHandler(this.cancelSaveCustomerButton_Click);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 3;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 21F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 65F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14F));
            this.tableLayoutPanel2.Controls.Add(this.backToCustomersButton, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.customerFormPanel, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.formErrorListLabel, 0, 1);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(986, 462);
            this.tableLayoutPanel2.TabIndex = 5;
            // 
            // backToCustomersButton
            // 
            this.backToCustomersButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.backToCustomersButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.backToCustomersButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.backToCustomersButton.Location = new System.Drawing.Point(3, 14);
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
            this.customerFormPanel.Controls.Add(this.tableLayoutPanel1);
            this.customerFormPanel.Controls.Add(this.cancelSaveCustomerButton);
            this.customerFormPanel.Controls.Add(this.saveCustomerButton);
            this.customerFormPanel.Location = new System.Drawing.Point(210, 43);
            this.customerFormPanel.Name = "customerFormPanel";
            this.customerFormPanel.Size = new System.Drawing.Size(634, 416);
            this.customerFormPanel.TabIndex = 3;
            // 
            // formErrorListLabel
            // 
            this.formErrorListLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.formErrorListLabel.AutoSize = true;
            this.formErrorListLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.formErrorListLabel.ForeColor = System.Drawing.Color.Firebrick;
            this.formErrorListLabel.Location = new System.Drawing.Point(3, 243);
            this.formErrorListLabel.Name = "formErrorListLabel";
            this.formErrorListLabel.Size = new System.Drawing.Size(77, 16);
            this.formErrorListLabel.TabIndex = 4;
            this.formErrorListLabel.Text = "Form Errors";
            // 
            // ManageCustomerControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel2);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ManageCustomerControl";
            this.Size = new System.Drawing.Size(986, 462);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.customerFormPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label customerNameLabel;
        private System.Windows.Forms.Label addressLabel;
        private System.Windows.Forms.TextBox customerNameTextBox;
        private System.Windows.Forms.TextBox addressTextBox;
        private System.Windows.Forms.Label address2Label;
        private System.Windows.Forms.TextBox address2TextBox;
        private System.Windows.Forms.Label cityLabel;
        private System.Windows.Forms.Label postalCodeLabel;
        private System.Windows.Forms.TextBox postalCodeTextBox;
        private System.Windows.Forms.Label countryLabel;
        private System.Windows.Forms.Label customerPhoneLabel;
        private System.Windows.Forms.TextBox customerPhoneTextBox;
        private System.Windows.Forms.ComboBox countryComboBox;
        private System.Windows.Forms.ComboBox cityComboBox;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.LinkLabel editCityLabel;
        private System.Windows.Forms.LinkLabel newCityLabel;
        private System.Windows.Forms.LinkLabel editCountryLabel;
        private System.Windows.Forms.LinkLabel newCountryLabel;
        private System.Windows.Forms.Button saveCustomerButton;
        private System.Windows.Forms.Button cancelSaveCustomerButton;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Panel customerFormPanel;
        private System.Windows.Forms.Button backToCustomersButton;
        private System.Windows.Forms.Label formErrorListLabel;
    }
}
