namespace BDenis3_C969_Project
{
    partial class Login
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
            this.labelWelcomeMessage = new System.Windows.Forms.Label();
            this.labelLoginID = new System.Windows.Forms.Label();
            this.textboxUsername = new System.Windows.Forms.TextBox();
            this.labelPassword = new System.Windows.Forms.Label();
            this.textboxPassword = new System.Windows.Forms.TextBox();
            this.buttonCancelLogin = new System.Windows.Forms.Button();
            this.buttonLogin = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelWelcomeMessage
            // 
            this.labelWelcomeMessage.AutoSize = true;
            this.labelWelcomeMessage.Location = new System.Drawing.Point(12, 9);
            this.labelWelcomeMessage.Name = "labelWelcomeMessage";
            this.labelWelcomeMessage.Size = new System.Drawing.Size(35, 13);
            this.labelWelcomeMessage.TabIndex = 0;
            this.labelWelcomeMessage.Text = "label1";
            // 
            // labelLoginID
            // 
            this.labelLoginID.AutoSize = true;
            this.labelLoginID.Location = new System.Drawing.Point(13, 46);
            this.labelLoginID.Name = "labelLoginID";
            this.labelLoginID.Size = new System.Drawing.Size(35, 13);
            this.labelLoginID.TabIndex = 1;
            this.labelLoginID.Text = "label1";
            // 
            // textboxUsername
            // 
            this.textboxUsername.Location = new System.Drawing.Point(93, 46);
            this.textboxUsername.Name = "textboxUsername";
            this.textboxUsername.Size = new System.Drawing.Size(225, 20);
            this.textboxUsername.TabIndex = 2;
            // 
            // labelPassword
            // 
            this.labelPassword.AutoSize = true;
            this.labelPassword.Location = new System.Drawing.Point(12, 81);
            this.labelPassword.Name = "labelPassword";
            this.labelPassword.Size = new System.Drawing.Size(35, 13);
            this.labelPassword.TabIndex = 3;
            this.labelPassword.Text = "label1";
            // 
            // textboxPassword
            // 
            this.textboxPassword.Location = new System.Drawing.Point(93, 81);
            this.textboxPassword.Name = "textboxPassword";
            this.textboxPassword.Size = new System.Drawing.Size(225, 20);
            this.textboxPassword.TabIndex = 4;
            this.textboxPassword.UseSystemPasswordChar = true;
            // 
            // buttonCancelLogin
            // 
            this.buttonCancelLogin.Location = new System.Drawing.Point(93, 136);
            this.buttonCancelLogin.Name = "buttonCancelLogin";
            this.buttonCancelLogin.Size = new System.Drawing.Size(75, 23);
            this.buttonCancelLogin.TabIndex = 5;
            this.buttonCancelLogin.Text = "button1";
            this.buttonCancelLogin.UseVisualStyleBackColor = true;
            this.buttonCancelLogin.Click += new System.EventHandler(this.ButtonCancelLogin_Click);
            // 
            // buttonLogin
            // 
            this.buttonLogin.Location = new System.Drawing.Point(243, 136);
            this.buttonLogin.Name = "buttonLogin";
            this.buttonLogin.Size = new System.Drawing.Size(75, 23);
            this.buttonLogin.TabIndex = 6;
            this.buttonLogin.Text = "button1";
            this.buttonLogin.UseVisualStyleBackColor = true;
            this.buttonLogin.Click += new System.EventHandler(this.ButtonLogin_Click);
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(341, 185);
            this.Controls.Add(this.buttonLogin);
            this.Controls.Add(this.buttonCancelLogin);
            this.Controls.Add(this.textboxPassword);
            this.Controls.Add(this.labelPassword);
            this.Controls.Add(this.textboxUsername);
            this.Controls.Add(this.labelLoginID);
            this.Controls.Add(this.labelWelcomeMessage);
            this.Name = "Login";
            this.Text = "Appointment Scheduler - Login";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelWelcomeMessage;
        private System.Windows.Forms.Label labelLoginID;
        private System.Windows.Forms.TextBox textboxUsername;
        private System.Windows.Forms.Label labelPassword;
        private System.Windows.Forms.TextBox textboxPassword;
        private System.Windows.Forms.Button buttonCancelLogin;
        private System.Windows.Forms.Button buttonLogin;
    }
}

