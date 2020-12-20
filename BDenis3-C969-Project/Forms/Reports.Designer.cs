namespace BDenis3_C969_Project
{
    partial class Reports
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
            this.buttonTypeByMonth = new System.Windows.Forms.Button();
            this.labelReportingHeader = new System.Windows.Forms.Label();
            this.buttonSchedulePerConsultant = new System.Windows.Forms.Button();
            this.buttonPerCustomer = new System.Windows.Forms.Button();
            this.buttonClose = new System.Windows.Forms.Button();
            this.textReport = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // buttonTypeByMonth
            // 
            this.buttonTypeByMonth.Location = new System.Drawing.Point(16, 49);
            this.buttonTypeByMonth.Name = "buttonTypeByMonth";
            this.buttonTypeByMonth.Size = new System.Drawing.Size(220, 43);
            this.buttonTypeByMonth.TabIndex = 0;
            this.buttonTypeByMonth.Text = "Appointment Types by Month";
            this.buttonTypeByMonth.UseVisualStyleBackColor = true;
            this.buttonTypeByMonth.Click += new System.EventHandler(this.ButtonTypeByMonth_Click);
            // 
            // labelReportingHeader
            // 
            this.labelReportingHeader.AutoSize = true;
            this.labelReportingHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelReportingHeader.Location = new System.Drawing.Point(13, 13);
            this.labelReportingHeader.Name = "labelReportingHeader";
            this.labelReportingHeader.Size = new System.Drawing.Size(162, 24);
            this.labelReportingHeader.TabIndex = 0;
            this.labelReportingHeader.Text = "Reporting Options";
            // 
            // buttonSchedulePerConsultant
            // 
            this.buttonSchedulePerConsultant.Location = new System.Drawing.Point(16, 110);
            this.buttonSchedulePerConsultant.Name = "buttonSchedulePerConsultant";
            this.buttonSchedulePerConsultant.Size = new System.Drawing.Size(220, 43);
            this.buttonSchedulePerConsultant.TabIndex = 0;
            this.buttonSchedulePerConsultant.Text = "Appointment Schedule per Consultant";
            this.buttonSchedulePerConsultant.UseVisualStyleBackColor = true;
            this.buttonSchedulePerConsultant.Click += new System.EventHandler(this.ButtonSchedulePerConsultant_Click);
            // 
            // buttonPerCustomer
            // 
            this.buttonPerCustomer.Location = new System.Drawing.Point(16, 172);
            this.buttonPerCustomer.Name = "buttonPerCustomer";
            this.buttonPerCustomer.Size = new System.Drawing.Size(220, 43);
            this.buttonPerCustomer.TabIndex = 0;
            this.buttonPerCustomer.Text = "Appointments per Customer";
            this.buttonPerCustomer.UseVisualStyleBackColor = true;
            this.buttonPerCustomer.Click += new System.EventHandler(this.ButtonPerCustomer_Click);
            // 
            // buttonClose
            // 
            this.buttonClose.Location = new System.Drawing.Point(17, 415);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(75, 23);
            this.buttonClose.TabIndex = 2;
            this.buttonClose.Text = "Close";
            this.buttonClose.UseVisualStyleBackColor = true;
            this.buttonClose.Click += new System.EventHandler(this.ButtonClose_Click);
            // 
            // textReport
            // 
            this.textReport.Location = new System.Drawing.Point(255, 49);
            this.textReport.Multiline = true;
            this.textReport.Name = "textReport";
            this.textReport.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textReport.Size = new System.Drawing.Size(625, 389);
            this.textReport.TabIndex = 3;
            // 
            // Reports
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(892, 450);
            this.Controls.Add(this.textReport);
            this.Controls.Add(this.buttonClose);
            this.Controls.Add(this.labelReportingHeader);
            this.Controls.Add(this.buttonPerCustomer);
            this.Controls.Add(this.buttonSchedulePerConsultant);
            this.Controls.Add(this.buttonTypeByMonth);
            this.Name = "Reports";
            this.Text = "Reporting";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonTypeByMonth;
        private System.Windows.Forms.Label labelReportingHeader;
        private System.Windows.Forms.Button buttonSchedulePerConsultant;
        private System.Windows.Forms.Button buttonPerCustomer;
        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.TextBox textReport;
    }
}