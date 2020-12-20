namespace BDenis3_C969_Project
{
    partial class AddAppointment
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
            this.buttonCancelApptAdd = new System.Windows.Forms.Button();
            this.buttonSaveAppt = new System.Windows.Forms.Button();
            this.comboCustomers = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.comboUsers = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textAppointmentTitle = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textApptDescription = new System.Windows.Forms.TextBox();
            this.dtpStartTime = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.dtpStopTime = new System.Windows.Forms.DateTimePicker();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.textApptType = new System.Windows.Forms.TextBox();
            this.textAppointmentID = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // buttonCancelApptAdd
            // 
            this.buttonCancelApptAdd.Location = new System.Drawing.Point(239, 321);
            this.buttonCancelApptAdd.Name = "buttonCancelApptAdd";
            this.buttonCancelApptAdd.Size = new System.Drawing.Size(75, 23);
            this.buttonCancelApptAdd.TabIndex = 10;
            this.buttonCancelApptAdd.Text = "&Cancel";
            this.buttonCancelApptAdd.UseVisualStyleBackColor = true;
            this.buttonCancelApptAdd.Click += new System.EventHandler(this.ButtonCancelApptAdd_Click);
            // 
            // buttonSaveAppt
            // 
            this.buttonSaveAppt.Location = new System.Drawing.Point(122, 321);
            this.buttonSaveAppt.Name = "buttonSaveAppt";
            this.buttonSaveAppt.Size = new System.Drawing.Size(75, 23);
            this.buttonSaveAppt.TabIndex = 9;
            this.buttonSaveAppt.Text = "&Save";
            this.buttonSaveAppt.UseVisualStyleBackColor = true;
            this.buttonSaveAppt.Click += new System.EventHandler(this.ButtonSaveAppt_Click);
            // 
            // comboCustomers
            // 
            this.comboCustomers.FormattingEnabled = true;
            this.comboCustomers.Location = new System.Drawing.Point(87, 42);
            this.comboCustomers.MaxLength = 44;
            this.comboCustomers.Name = "comboCustomers";
            this.comboCustomers.Size = new System.Drawing.Size(411, 21);
            this.comboCustomers.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Customer";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 80);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Representative";
            // 
            // comboUsers
            // 
            this.comboUsers.FormattingEnabled = true;
            this.comboUsers.Location = new System.Drawing.Point(122, 77);
            this.comboUsers.MaxLength = 49;
            this.comboUsers.Name = "comboUsers";
            this.comboUsers.Size = new System.Drawing.Size(376, 21);
            this.comboUsers.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 114);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Appointment Title";
            // 
            // textAppointmentTitle
            // 
            this.textAppointmentTitle.Location = new System.Drawing.Point(122, 111);
            this.textAppointmentTitle.MaxLength = 254;
            this.textAppointmentTitle.Name = "textAppointmentTitle";
            this.textAppointmentTitle.Size = new System.Drawing.Size(376, 20);
            this.textAppointmentTitle.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 146);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Description";
            // 
            // textApptDescription
            // 
            this.textApptDescription.Location = new System.Drawing.Point(122, 143);
            this.textApptDescription.Multiline = true;
            this.textApptDescription.Name = "textApptDescription";
            this.textApptDescription.Size = new System.Drawing.Size(376, 57);
            this.textApptDescription.TabIndex = 4;
            // 
            // dtpStartTime
            // 
            this.dtpStartTime.CustomFormat = "MM/dd/yyyy hh:mm tt";
            this.dtpStartTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpStartTime.Location = new System.Drawing.Point(122, 265);
            this.dtpStartTime.Name = "dtpStartTime";
            this.dtpStartTime.Size = new System.Drawing.Size(376, 20);
            this.dtpStartTime.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(16, 271);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(55, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Start Time";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(16, 299);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(52, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "End Time";
            // 
            // dtpStopTime
            // 
            this.dtpStopTime.CustomFormat = "MM/dd/yyyy hh:mm tt";
            this.dtpStopTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpStopTime.Location = new System.Drawing.Point(122, 293);
            this.dtpStopTime.Name = "dtpStopTime";
            this.dtpStopTime.Size = new System.Drawing.Size(376, 20);
            this.dtpStopTime.TabIndex = 8;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(15, 13);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(164, 20);
            this.label8.TabIndex = 11;
            this.label8.Text = "Appointment Creation";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(12, 212);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(93, 13);
            this.label9.TabIndex = 0;
            this.label9.Text = "Appointment Type";
            // 
            // textApptType
            // 
            this.textApptType.Location = new System.Drawing.Point(122, 209);
            this.textApptType.Name = "textApptType";
            this.textApptType.Size = new System.Drawing.Size(376, 20);
            this.textApptType.TabIndex = 5;
            // 
            // textAppointmentID
            // 
            this.textAppointmentID.Enabled = false;
            this.textAppointmentID.Location = new System.Drawing.Point(400, 11);
            this.textAppointmentID.Name = "textAppointmentID";
            this.textAppointmentID.Size = new System.Drawing.Size(97, 20);
            this.textAppointmentID.TabIndex = 12;
            // 
            // AddAppointment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(510, 356);
            this.Controls.Add(this.textAppointmentID);
            this.Controls.Add(this.textApptType);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.dtpStopTime);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.dtpStartTime);
            this.Controls.Add(this.textApptDescription);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textAppointmentTitle);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.comboUsers);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboCustomers);
            this.Controls.Add(this.buttonSaveAppt);
            this.Controls.Add(this.buttonCancelApptAdd);
            this.Name = "AddAppointment";
            this.Text = "Add an Appointment";
            this.Load += new System.EventHandler(this.AddAppointment_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonCancelApptAdd;
        private System.Windows.Forms.Button buttonSaveAppt;
        private System.Windows.Forms.ComboBox comboCustomers;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboUsers;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textAppointmentTitle;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textApptDescription;
        private System.Windows.Forms.DateTimePicker dtpStartTime;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker dtpStopTime;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox textApptType;
        public System.Windows.Forms.TextBox textAppointmentID;
    }
}