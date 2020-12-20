namespace BDenis3_C969_Project
{
    partial class AddCustomer
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
            this.labelAddNewCustomerForm = new System.Windows.Forms.Label();
            this.labelCustomerID = new System.Windows.Forms.Label();
            this.textCustomerID = new System.Windows.Forms.TextBox();
            this.labelCustomerName = new System.Windows.Forms.Label();
            this.textCustomerName = new System.Windows.Forms.TextBox();
            this.checkActiveCustomer = new System.Windows.Forms.CheckBox();
            this.labelStreetAddress = new System.Windows.Forms.Label();
            this.textStreetAddress = new System.Windows.Forms.TextBox();
            this.textStreetAddress2 = new System.Windows.Forms.TextBox();
            this.labelCity = new System.Windows.Forms.Label();
            this.textCityName = new System.Windows.Forms.TextBox();
            this.labelCountry = new System.Windows.Forms.Label();
            this.textCountryName = new System.Windows.Forms.TextBox();
            this.labelPostalCode = new System.Windows.Forms.Label();
            this.textPostalCode = new System.Windows.Forms.TextBox();
            this.buttonCancelAddCustomer = new System.Windows.Forms.Button();
            this.buttonSaveNewCustomer = new System.Windows.Forms.Button();
            this.labelPhone = new System.Windows.Forms.Label();
            this.textPhone = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // labelAddNewCustomerForm
            // 
            this.labelAddNewCustomerForm.AutoSize = true;
            this.labelAddNewCustomerForm.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelAddNewCustomerForm.Location = new System.Drawing.Point(25, 35);
            this.labelAddNewCustomerForm.Name = "labelAddNewCustomerForm";
            this.labelAddNewCustomerForm.Size = new System.Drawing.Size(146, 20);
            this.labelAddNewCustomerForm.TabIndex = 0;
            this.labelAddNewCustomerForm.Text = "Add New Customer";
            // 
            // labelCustomerID
            // 
            this.labelCustomerID.AutoSize = true;
            this.labelCustomerID.Location = new System.Drawing.Point(26, 114);
            this.labelCustomerID.Name = "labelCustomerID";
            this.labelCustomerID.Size = new System.Drawing.Size(65, 13);
            this.labelCustomerID.TabIndex = 0;
            this.labelCustomerID.Text = "Customer ID";
            // 
            // textCustomerID
            // 
            this.textCustomerID.Enabled = false;
            this.textCustomerID.Location = new System.Drawing.Point(146, 110);
            this.textCustomerID.Name = "textCustomerID";
            this.textCustomerID.Size = new System.Drawing.Size(100, 20);
            this.textCustomerID.TabIndex = 1;
            // 
            // labelCustomerName
            // 
            this.labelCustomerName.AutoSize = true;
            this.labelCustomerName.Location = new System.Drawing.Point(26, 149);
            this.labelCustomerName.Name = "labelCustomerName";
            this.labelCustomerName.Size = new System.Drawing.Size(101, 13);
            this.labelCustomerName.TabIndex = 0;
            this.labelCustomerName.Text = "Customer Full Name";
            // 
            // textCustomerName
            // 
            this.textCustomerName.Location = new System.Drawing.Point(146, 146);
            this.textCustomerName.Name = "textCustomerName";
            this.textCustomerName.Size = new System.Drawing.Size(295, 20);
            this.textCustomerName.TabIndex = 3;
            this.textCustomerName.TextChanged += new System.EventHandler(this.FieldChanged);
            // 
            // checkActiveCustomer
            // 
            this.checkActiveCustomer.AutoSize = true;
            this.checkActiveCustomer.Checked = true;
            this.checkActiveCustomer.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkActiveCustomer.Location = new System.Drawing.Point(269, 113);
            this.checkActiveCustomer.Name = "checkActiveCustomer";
            this.checkActiveCustomer.Size = new System.Drawing.Size(172, 17);
            this.checkActiveCustomer.TabIndex = 2;
            this.checkActiveCustomer.Text = "Check this if customer is active";
            this.checkActiveCustomer.UseVisualStyleBackColor = true;
            // 
            // labelStreetAddress
            // 
            this.labelStreetAddress.AutoSize = true;
            this.labelStreetAddress.Location = new System.Drawing.Point(26, 187);
            this.labelStreetAddress.Name = "labelStreetAddress";
            this.labelStreetAddress.Size = new System.Drawing.Size(76, 13);
            this.labelStreetAddress.TabIndex = 0;
            this.labelStreetAddress.Text = "Street Address";
            // 
            // textStreetAddress
            // 
            this.textStreetAddress.Location = new System.Drawing.Point(146, 184);
            this.textStreetAddress.Name = "textStreetAddress";
            this.textStreetAddress.Size = new System.Drawing.Size(295, 20);
            this.textStreetAddress.TabIndex = 4;
            this.textStreetAddress.TextChanged += new System.EventHandler(this.FieldChanged);
            // 
            // textStreetAddress2
            // 
            this.textStreetAddress2.Location = new System.Drawing.Point(146, 219);
            this.textStreetAddress2.Name = "textStreetAddress2";
            this.textStreetAddress2.Size = new System.Drawing.Size(295, 20);
            this.textStreetAddress2.TabIndex = 5;
            this.textStreetAddress2.TextChanged += new System.EventHandler(this.FieldChanged);
            // 
            // labelCity
            // 
            this.labelCity.AutoSize = true;
            this.labelCity.Location = new System.Drawing.Point(26, 258);
            this.labelCity.Name = "labelCity";
            this.labelCity.Size = new System.Drawing.Size(24, 13);
            this.labelCity.TabIndex = 0;
            this.labelCity.Text = "City";
            // 
            // textCityName
            // 
            this.textCityName.Location = new System.Drawing.Point(146, 255);
            this.textCityName.Name = "textCityName";
            this.textCityName.Size = new System.Drawing.Size(295, 20);
            this.textCityName.TabIndex = 6;
            this.textCityName.TextChanged += new System.EventHandler(this.FieldChanged);
            // 
            // labelCountry
            // 
            this.labelCountry.AutoSize = true;
            this.labelCountry.Location = new System.Drawing.Point(26, 294);
            this.labelCountry.Name = "labelCountry";
            this.labelCountry.Size = new System.Drawing.Size(43, 13);
            this.labelCountry.TabIndex = 0;
            this.labelCountry.Text = "Country";
            // 
            // textCountryName
            // 
            this.textCountryName.Location = new System.Drawing.Point(146, 291);
            this.textCountryName.Name = "textCountryName";
            this.textCountryName.Size = new System.Drawing.Size(295, 20);
            this.textCountryName.TabIndex = 7;
            this.textCountryName.TextChanged += new System.EventHandler(this.FieldChanged);
            // 
            // labelPostalCode
            // 
            this.labelPostalCode.AutoSize = true;
            this.labelPostalCode.Location = new System.Drawing.Point(26, 330);
            this.labelPostalCode.Name = "labelPostalCode";
            this.labelPostalCode.Size = new System.Drawing.Size(64, 13);
            this.labelPostalCode.TabIndex = 0;
            this.labelPostalCode.Text = "Postal Code";
            // 
            // textPostalCode
            // 
            this.textPostalCode.Location = new System.Drawing.Point(146, 327);
            this.textPostalCode.Name = "textPostalCode";
            this.textPostalCode.Size = new System.Drawing.Size(295, 20);
            this.textPostalCode.TabIndex = 8;
            this.textPostalCode.TextChanged += new System.EventHandler(this.FieldChanged);
            // 
            // buttonCancelAddCustomer
            // 
            this.buttonCancelAddCustomer.Location = new System.Drawing.Point(146, 405);
            this.buttonCancelAddCustomer.Name = "buttonCancelAddCustomer";
            this.buttonCancelAddCustomer.Size = new System.Drawing.Size(100, 36);
            this.buttonCancelAddCustomer.TabIndex = 10;
            this.buttonCancelAddCustomer.Text = "&Cancel";
            this.buttonCancelAddCustomer.UseVisualStyleBackColor = true;
            this.buttonCancelAddCustomer.Click += new System.EventHandler(this.ButtonCancelAddCustomer_Click);
            // 
            // buttonSaveNewCustomer
            // 
            this.buttonSaveNewCustomer.Location = new System.Drawing.Point(314, 405);
            this.buttonSaveNewCustomer.Name = "buttonSaveNewCustomer";
            this.buttonSaveNewCustomer.Size = new System.Drawing.Size(127, 36);
            this.buttonSaveNewCustomer.TabIndex = 11;
            this.buttonSaveNewCustomer.Text = "&Save Customer";
            this.buttonSaveNewCustomer.UseVisualStyleBackColor = true;
            this.buttonSaveNewCustomer.Click += new System.EventHandler(this.ButtonSaveNewCustomer_Click);
            // 
            // labelPhone
            // 
            this.labelPhone.AutoSize = true;
            this.labelPhone.Location = new System.Drawing.Point(26, 363);
            this.labelPhone.Name = "labelPhone";
            this.labelPhone.Size = new System.Drawing.Size(38, 13);
            this.labelPhone.TabIndex = 0;
            this.labelPhone.Text = "Phone";
            // 
            // textPhone
            // 
            this.textPhone.Location = new System.Drawing.Point(146, 363);
            this.textPhone.Name = "textPhone";
            this.textPhone.Size = new System.Drawing.Size(295, 20);
            this.textPhone.TabIndex = 9;
            this.textPhone.TextChanged += new System.EventHandler(this.FieldChanged);
            // 
            // AddCustomer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(467, 453);
            this.Controls.Add(this.textPhone);
            this.Controls.Add(this.labelPhone);
            this.Controls.Add(this.buttonSaveNewCustomer);
            this.Controls.Add(this.buttonCancelAddCustomer);
            this.Controls.Add(this.textPostalCode);
            this.Controls.Add(this.labelPostalCode);
            this.Controls.Add(this.textCountryName);
            this.Controls.Add(this.labelCountry);
            this.Controls.Add(this.textCityName);
            this.Controls.Add(this.labelCity);
            this.Controls.Add(this.textStreetAddress2);
            this.Controls.Add(this.textStreetAddress);
            this.Controls.Add(this.labelStreetAddress);
            this.Controls.Add(this.checkActiveCustomer);
            this.Controls.Add(this.textCustomerName);
            this.Controls.Add(this.labelCustomerName);
            this.Controls.Add(this.textCustomerID);
            this.Controls.Add(this.labelCustomerID);
            this.Controls.Add(this.labelAddNewCustomerForm);
            this.Name = "AddCustomer";
            this.Text = "Adding New Customer";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelAddNewCustomerForm;
        private System.Windows.Forms.Label labelCustomerID;
        private System.Windows.Forms.TextBox textCustomerID;
        private System.Windows.Forms.Label labelCustomerName;
        private System.Windows.Forms.TextBox textCustomerName;
        private System.Windows.Forms.CheckBox checkActiveCustomer;
        private System.Windows.Forms.Label labelStreetAddress;
        private System.Windows.Forms.TextBox textStreetAddress;
        private System.Windows.Forms.TextBox textStreetAddress2;
        private System.Windows.Forms.Label labelCity;
        private System.Windows.Forms.TextBox textCityName;
        private System.Windows.Forms.Label labelCountry;
        private System.Windows.Forms.TextBox textCountryName;
        private System.Windows.Forms.Label labelPostalCode;
        private System.Windows.Forms.TextBox textPostalCode;
        private System.Windows.Forms.Button buttonCancelAddCustomer;
        private System.Windows.Forms.Button buttonSaveNewCustomer;
        private System.Windows.Forms.Label labelPhone;
        private System.Windows.Forms.TextBox textPhone;

    }
}