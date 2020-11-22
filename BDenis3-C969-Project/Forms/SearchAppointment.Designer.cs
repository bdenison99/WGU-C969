namespace BDenis3_C969_Project
{
    partial class SearchAppointment
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
            this.label1 = new System.Windows.Forms.Label();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonEditAppt = new System.Windows.Forms.Button();
            this.buttonSearchAppt = new System.Windows.Forms.Button();
            this.textApptSearchValue = new System.Windows.Forms.TextBox();
            this.dgAppointments = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgAppointments)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(163, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Search Appointments";
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(17, 50);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 27);
            this.buttonCancel.TabIndex = 1;
            this.buttonCancel.Text = "&Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.ButtonCancel_Click);
            // 
            // buttonEditAppt
            // 
            this.buttonEditAppt.Location = new System.Drawing.Point(110, 50);
            this.buttonEditAppt.Name = "buttonEditAppt";
            this.buttonEditAppt.Size = new System.Drawing.Size(75, 27);
            this.buttonEditAppt.TabIndex = 2;
            this.buttonEditAppt.Text = "&Edit";
            this.buttonEditAppt.UseVisualStyleBackColor = true;
            this.buttonEditAppt.Click += new System.EventHandler(this.ButtonEditAppt_Click);
            // 
            // buttonSearchAppt
            // 
            this.buttonSearchAppt.Location = new System.Drawing.Point(203, 50);
            this.buttonSearchAppt.Name = "buttonSearchAppt";
            this.buttonSearchAppt.Size = new System.Drawing.Size(75, 27);
            this.buttonSearchAppt.TabIndex = 3;
            this.buttonSearchAppt.Text = "&Search";
            this.buttonSearchAppt.UseVisualStyleBackColor = true;
            this.buttonSearchAppt.Click += new System.EventHandler(this.ButtonSearchAppt_Click);
            // 
            // textApptSearchValue
            // 
            this.textApptSearchValue.Location = new System.Drawing.Point(284, 54);
            this.textApptSearchValue.Name = "textApptSearchValue";
            this.textApptSearchValue.Size = new System.Drawing.Size(493, 20);
            this.textApptSearchValue.TabIndex = 4;
            // 
            // dgAppointments
            // 
            this.dgAppointments.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgAppointments.Location = new System.Drawing.Point(17, 84);
            this.dgAppointments.Name = "dgAppointments";
            this.dgAppointments.Size = new System.Drawing.Size(760, 354);
            this.dgAppointments.TabIndex = 5;
            // 
            // SearchAppointment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dgAppointments);
            this.Controls.Add(this.textApptSearchValue);
            this.Controls.Add(this.buttonSearchAppt);
            this.Controls.Add(this.buttonEditAppt);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.label1);
            this.Name = "SearchAppointment";
            this.Text = "Search Appointments";
            ((System.ComponentModel.ISupportInitialize)(this.dgAppointments)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonEditAppt;
        private System.Windows.Forms.Button buttonSearchAppt;
        private System.Windows.Forms.TextBox textApptSearchValue;
        private System.Windows.Forms.DataGridView dgAppointments;
    }
}