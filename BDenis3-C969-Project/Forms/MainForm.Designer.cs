namespace BDenis3_C969_Project
{
    partial class MainForm
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
            this.buttonAddCustomer = new System.Windows.Forms.Button();
            this.buttonEditCustomer = new System.Windows.Forms.Button();
            this.monthCalendar1 = new System.Windows.Forms.MonthCalendar();
            this.buttonDeleteCustomer = new System.Windows.Forms.Button();
            this.radioDaily = new System.Windows.Forms.RadioButton();
            this.radioWeekly = new System.Windows.Forms.RadioButton();
            this.dgAppointments = new System.Windows.Forms.DataGridView();
            this.buttonAddAppointment = new System.Windows.Forms.Button();
            this.buttonEditAppointment = new System.Windows.Forms.Button();
            this.buttonCancelAppointment = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgAppointments)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonAddCustomer
            // 
            this.buttonAddCustomer.Location = new System.Drawing.Point(12, 50);
            this.buttonAddCustomer.Name = "buttonAddCustomer";
            this.buttonAddCustomer.Size = new System.Drawing.Size(98, 37);
            this.buttonAddCustomer.TabIndex = 1;
            this.buttonAddCustomer.Text = "A&dd Customer";
            this.buttonAddCustomer.UseVisualStyleBackColor = true;
            this.buttonAddCustomer.Click += new System.EventHandler(this.ButtonAddCustomer_Click);
            // 
            // buttonEditCustomer
            // 
            this.buttonEditCustomer.Location = new System.Drawing.Point(12, 93);
            this.buttonEditCustomer.Name = "buttonEditCustomer";
            this.buttonEditCustomer.Size = new System.Drawing.Size(98, 37);
            this.buttonEditCustomer.TabIndex = 2;
            this.buttonEditCustomer.Text = "&Edit Customer";
            this.buttonEditCustomer.UseVisualStyleBackColor = true;
            this.buttonEditCustomer.Click += new System.EventHandler(this.ButtonEditCustomer_Click);
            // 
            // monthCalendar1
            // 
            this.monthCalendar1.Location = new System.Drawing.Point(12, 185);
            this.monthCalendar1.Name = "monthCalendar1";
            this.monthCalendar1.TabIndex = 7;
            // 
            // buttonDeleteCustomer
            // 
            this.buttonDeleteCustomer.Location = new System.Drawing.Point(12, 136);
            this.buttonDeleteCustomer.Name = "buttonDeleteCustomer";
            this.buttonDeleteCustomer.Size = new System.Drawing.Size(98, 37);
            this.buttonDeleteCustomer.TabIndex = 3;
            this.buttonDeleteCustomer.Text = "De&lete Customer";
            this.buttonDeleteCustomer.UseVisualStyleBackColor = true;
            this.buttonDeleteCustomer.Click += new System.EventHandler(this.ButtonDeleteCustomer_Click);
            // 
            // radioDaily
            // 
            this.radioDaily.AutoSize = true;
            this.radioDaily.Location = new System.Drawing.Point(12, 359);
            this.radioDaily.Name = "radioDaily";
            this.radioDaily.Size = new System.Drawing.Size(78, 17);
            this.radioDaily.TabIndex = 8;
            this.radioDaily.TabStop = true;
            this.radioDaily.Text = "Show Daily";
            this.radioDaily.UseVisualStyleBackColor = true;
            this.radioDaily.CheckedChanged += new System.EventHandler(this.RadioDaily_CheckedChanged);
            // 
            // radioWeekly
            // 
            this.radioWeekly.AutoSize = true;
            this.radioWeekly.Location = new System.Drawing.Point(155, 359);
            this.radioWeekly.Name = "radioWeekly";
            this.radioWeekly.Size = new System.Drawing.Size(84, 17);
            this.radioWeekly.TabIndex = 9;
            this.radioWeekly.TabStop = true;
            this.radioWeekly.Text = "Show Week";
            this.radioWeekly.UseVisualStyleBackColor = true;
            this.radioWeekly.CheckedChanged += new System.EventHandler(this.RadioWeekly_CheckedChanged);
            // 
            // dgAppointments
            // 
            this.dgAppointments.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgAppointments.Location = new System.Drawing.Point(262, 55);
            this.dgAppointments.Name = "dgAppointments";
            this.dgAppointments.Size = new System.Drawing.Size(526, 321);
            this.dgAppointments.TabIndex = 7;
            // 
            // buttonAddAppointment
            // 
            this.buttonAddAppointment.Location = new System.Drawing.Point(116, 50);
            this.buttonAddAppointment.Name = "buttonAddAppointment";
            this.buttonAddAppointment.Size = new System.Drawing.Size(123, 37);
            this.buttonAddAppointment.TabIndex = 4;
            this.buttonAddAppointment.Text = "&Add Appointment";
            this.buttonAddAppointment.UseVisualStyleBackColor = true;
            this.buttonAddAppointment.Click += new System.EventHandler(this.ButtonAddAppointment_Click);
            // 
            // buttonEditAppointment
            // 
            this.buttonEditAppointment.Location = new System.Drawing.Point(116, 93);
            this.buttonEditAppointment.Name = "buttonEditAppointment";
            this.buttonEditAppointment.Size = new System.Drawing.Size(123, 37);
            this.buttonEditAppointment.TabIndex = 5;
            this.buttonEditAppointment.Text = "Edi&t Appointment";
            this.buttonEditAppointment.UseVisualStyleBackColor = true;
            this.buttonEditAppointment.Click += new System.EventHandler(this.ButtonEditAppointment_Click);
            // 
            // buttonCancelAppointment
            // 
            this.buttonCancelAppointment.Location = new System.Drawing.Point(116, 136);
            this.buttonCancelAppointment.Name = "buttonCancelAppointment";
            this.buttonCancelAppointment.Size = new System.Drawing.Size(123, 37);
            this.buttonCancelAppointment.TabIndex = 6;
            this.buttonCancelAppointment.Text = "&Cancel Appointment";
            this.buttonCancelAppointment.UseVisualStyleBackColor = true;
            this.buttonCancelAppointment.Click += new System.EventHandler(this.ButtonCancelAppointment_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.buttonCancelAppointment);
            this.Controls.Add(this.buttonEditAppointment);
            this.Controls.Add(this.buttonAddAppointment);
            this.Controls.Add(this.dgAppointments);
            this.Controls.Add(this.radioWeekly);
            this.Controls.Add(this.radioDaily);
            this.Controls.Add(this.buttonDeleteCustomer);
            this.Controls.Add(this.monthCalendar1);
            this.Controls.Add(this.buttonEditCustomer);
            this.Controls.Add(this.buttonAddCustomer);
            this.Name = "MainForm";
            this.Text = "Client Scheduling Application";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgAppointments)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button buttonAddCustomer;
        private System.Windows.Forms.Button buttonEditCustomer;
        private System.Windows.Forms.MonthCalendar monthCalendar1;
        private System.Windows.Forms.Button buttonDeleteCustomer;
        private System.Windows.Forms.RadioButton radioDaily;
        private System.Windows.Forms.RadioButton radioWeekly;
        private System.Windows.Forms.DataGridView dgAppointments;
        private System.Windows.Forms.Button buttonAddAppointment;
        private System.Windows.Forms.Button buttonEditAppointment;
        private System.Windows.Forms.Button buttonCancelAppointment;
    }
}