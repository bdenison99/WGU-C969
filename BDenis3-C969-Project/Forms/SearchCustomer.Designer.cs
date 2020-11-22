namespace BDenis3_C969_Project
{
    partial class SearchCustomer
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
            this.dgCustomerSearch = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonSearchCancel = new System.Windows.Forms.Button();
            this.buttonSearchExecute = new System.Windows.Forms.Button();
            this.textSearchValue = new System.Windows.Forms.TextBox();
            this.buttonSearchEdit = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgCustomerSearch)).BeginInit();
            this.SuspendLayout();
            // 
            // dgCustomerSearch
            // 
            this.dgCustomerSearch.AllowUserToAddRows = false;
            this.dgCustomerSearch.AllowUserToDeleteRows = false;
            this.dgCustomerSearch.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgCustomerSearch.Location = new System.Drawing.Point(12, 80);
            this.dgCustomerSearch.MultiSelect = false;
            this.dgCustomerSearch.Name = "dgCustomerSearch";
            this.dgCustomerSearch.ReadOnly = true;
            this.dgCustomerSearch.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgCustomerSearch.Size = new System.Drawing.Size(776, 358);
            this.dgCustomerSearch.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(8, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(141, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Search Customers";
            // 
            // buttonSearchCancel
            // 
            this.buttonSearchCancel.Location = new System.Drawing.Point(12, 46);
            this.buttonSearchCancel.Name = "buttonSearchCancel";
            this.buttonSearchCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonSearchCancel.TabIndex = 1;
            this.buttonSearchCancel.Text = "&Cancel";
            this.buttonSearchCancel.UseVisualStyleBackColor = true;
            this.buttonSearchCancel.Click += new System.EventHandler(this.ButtonSearchCancel_Click);
            // 
            // buttonSearchExecute
            // 
            this.buttonSearchExecute.Location = new System.Drawing.Point(198, 45);
            this.buttonSearchExecute.Name = "buttonSearchExecute";
            this.buttonSearchExecute.Size = new System.Drawing.Size(75, 23);
            this.buttonSearchExecute.TabIndex = 3;
            this.buttonSearchExecute.Text = "&Search";
            this.buttonSearchExecute.UseVisualStyleBackColor = true;
            this.buttonSearchExecute.Click += new System.EventHandler(this.ButtonSearchExecute_Click);
            // 
            // textSearchValue
            // 
            this.textSearchValue.Location = new System.Drawing.Point(283, 46);
            this.textSearchValue.Name = "textSearchValue";
            this.textSearchValue.Size = new System.Drawing.Size(505, 20);
            this.textSearchValue.TabIndex = 4;
            // 
            // buttonSearchEdit
            // 
            this.buttonSearchEdit.Location = new System.Drawing.Point(103, 46);
            this.buttonSearchEdit.Name = "buttonSearchEdit";
            this.buttonSearchEdit.Size = new System.Drawing.Size(75, 23);
            this.buttonSearchEdit.TabIndex = 2;
            this.buttonSearchEdit.Text = "&Edit";
            this.buttonSearchEdit.UseVisualStyleBackColor = true;
            this.buttonSearchEdit.Click += new System.EventHandler(this.ButtonSearchEdit_Click);
            // 
            // SearchCustomer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.buttonSearchEdit);
            this.Controls.Add(this.textSearchValue);
            this.Controls.Add(this.buttonSearchExecute);
            this.Controls.Add(this.buttonSearchCancel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgCustomerSearch);
            this.Name = "SearchCustomer";
            this.Text = "Searching For Customer";
            ((System.ComponentModel.ISupportInitialize)(this.dgCustomerSearch)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgCustomerSearch;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonSearchCancel;
        private System.Windows.Forms.Button buttonSearchExecute;
        private System.Windows.Forms.TextBox textSearchValue;
        public System.Windows.Forms.Button buttonSearchEdit;
    }
}