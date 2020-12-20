using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Resources;
using System.Globalization;
using MySql.Data.MySqlClient;
using System.Configuration;

namespace BDenis3_C969_Project
{
    public partial class Login : Form
    {
        private ResourceManager rm = new ResourceManager(typeof(BDenis3_C969_Project.strings));
        
        public Login()
        {
            InitializeComponent();
            SetStrings();
        }

        private void ButtonCancelLogin_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void SetStrings()
        {
            labelWelcomeMessage.Text = rm.GetString("WelcomeString", CultureInfo.CurrentCulture);
            labelLoginID.Text = rm.GetString("UsernameString", CultureInfo.CurrentCulture);
            labelPassword.Text = rm.GetString("PasswordString", CultureInfo.CurrentCulture);
            buttonCancelLogin.Text = rm.GetString("CancelString", CultureInfo.CurrentCulture);
            buttonLogin.Text = rm.GetString("LoginString", CultureInfo.CurrentCulture);
            this.Text = rm.GetString("FormCaptionString", CultureInfo.CurrentCulture);
        }

        private void ButtonLogin_Click(object sender, EventArgs e)
        {
            ProcessLogin();
        }

        private void ButtonLogin_KeyPress(object sender, KeyPressEventArgs e)
        {
            ProcessLogin();
        }

        private void ProcessLogin()
        {
            // Make sure that the user provided a username and password - if they didn't throw a messagebox and stop processing.
            if (textboxUsername.Text.Length == 0 || textboxPassword.Text.Length == 0)
            {
                MessageBox.Show(rm.GetString("MissingUsernameOrPassword", CultureInfo.CurrentCulture));
            }
            else
            {
                // Connect to the database, retrievea list of users where the username matches the value in the textbox (case insensitive)
                Dal DataLayer = new Dal();

                DataTable userinfo = Dal.RunSQLCommand("SELECT * FROM user WHERE UserNAME ='" + textboxUsername.Text.ToLower() + "'");

                // If the number of rows returned is 0, the database doesn't know about this user, throw an invalid login message
                if (userinfo.Rows.Count == 0)
                {
                    MessageBox.Show(rm.GetString("LoginErrorString", CultureInfo.CurrentCulture));
                }
                // If the number of rows returned is more than 1, something is wrong with the database because there should only be one username that matches - throw an exception
                else if (userinfo.Rows.Count > 1)
                {
                    throw new ArgumentOutOfRangeException("Contact support - multiple user accounts found with the same name");
                }
                else
                {
                    // Check the password in the database against the one provided by the user
                    if (userinfo.Rows[0]["password"].ToString() != textboxPassword.Text.ToString())
                    {
                        // if it doesn't match, display a login error about bad username or password - don't want to give away which one was wrong for security reasons 
                        MessageBox.Show(rm.GetString("LoginErrorString", CultureInfo.CurrentCulture));
                    }
                    else
                    {
                        // Hide the login form
                        this.Hide();
                        MainForm main = new MainForm
                        {
                            LoginID = Convert.ToInt32(userinfo.Rows[0]["userId"].ToString()),
                            LoginName = userinfo.Rows[0]["userName"].ToString()
                        };
                        main.Show();
                    }
                }
            }
        }
    }
}
