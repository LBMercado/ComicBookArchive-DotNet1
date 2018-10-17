using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace ComicArchive
{
    public partial class Login : Form
    {
        //data members
        Data_Access.AccountAccess acctAcc;
        private const string accountFileName = "accounts.xml";

        public Login()
        {
            InitializeComponent();
            acctAcc = new Data_Access.AccountAccess(accountFileName);
        }

        public static bool ValidateInput(string usern, string passw)
        {
            //Check if usern and passw are both empty strings
            if (usern == "" || passw == "")
            {
                MessageBox.Show("Username or Password cannot be empty.", "Login", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            //Check if username is at least 6 characters
            //Check if passw is at least 6 characters, consists of letters, numbers, or underscore
            if (usern.Length < 6 || passw.Length < 6)
            {
                MessageBox.Show("Username or Password must be at least 6 characters long.", "Login", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (!passw.All(ch => char.IsLetterOrDigit(ch) || ch.Equals('_')))
            {
                MessageBox.Show("Password must consist of letters and numbers or underscore.", "Login", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        private void lnkLblSignUp_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

            if (btnSignIn.Text == "Sign In")
            {
                btnSignIn.Text = "Sign Up";
                lblSign.Text = "Already have an account?";
                lnkLblSignUp.Text = "Sign in now.";
                lblConfPw.Enabled = true;
                lblConfPw.Visible = true;
                txtBxConfPw.ResetText();
                txtBxConfPw.Enabled = true;
                txtBxConfPw.Visible = true;                

            }
            else
            {
                btnSignIn.Text = "Sign In";
                lblSign.Text = "Don't have an account?";
                lnkLblSignUp.Text = "Sign up now.";
                lblConfPw.Enabled = false;
                lblConfPw.Visible = false;
                txtBxConfPw.ResetText();
                txtBxConfPw.Enabled = false;
                txtBxConfPw.Visible = false;

            }
            
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSignIn_Click(object sender, EventArgs e)
        {
            string userName = txtBxUser.Text.Trim();
            string passWord = txtBxPass.Text.Trim();
            string confPW = txtBxConfPw.Text.Trim();

            acctAcc.SetAccount(userName, passWord);

            //Check first if input is valid
            if (!ValidateInput(userName, passWord))
            {
                return;
            }

            //Sign In
            if (btnSignIn.Text == "Sign In")
            {
                //Verify login details
                if (acctAcc.IsValidAccount())
                {
                    //distinguish between user and admin account,
                    //start with user account first
                    var account = acctAcc.GetUserAccount();
                    if (account == null)
                    {
                        //get admin account
                        var adminAccount = acctAcc.GetAdminAccount();

                        if (adminAccount == null)
                        {
                            Exception exc = new Exception("Unknown error encountered. Unable to get account of User/Admin.");
                            throw exc;
                        }
                        MessageBox.Show("Admin verified, welcome " + adminAccount.Username + '!', "Login", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        //admin window here
                        User_Interface.Admin ui_admin = new User_Interface.Admin(this, adminAccount);
                        txtBxUser.ResetText();
                        txtBxPass.ResetText();
                        this.Hide();
                        ui_admin.Show();
                    }
                    else
                    {
                        MessageBox.Show("Login success!", "Login", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        //Instantiate the MainMenu
                        MainMenu ui_main = new MainMenu(this);
                        txtBxUser.ResetText();
                        txtBxPass.ResetText();
                        this.Hide();
                        ui_main.Show();
                    }
                }
                //If no match, inform user
                else
                {
                    MessageBox.Show("Incorrect username or password entered.", "Login", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtBxPass.Focus();
                    txtBxPass.SelectAll();
                }
            }
            //Sign Up
            else
            {
                //Verify login details
                if (acctAcc.AccountExists())
                {
                    MessageBox.Show("Username is already used. Please enter a new one.", "Sign Up", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtBxUser.Focus();
                    txtBxUser.SelectAll();
                    return;
                }
                else if (confPW != passWord)
                {
                    MessageBox.Show("Passwords don't match.", "Login", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtBxConfPw.ResetText();
                    txtBxPass.Focus();
                    txtBxPass.SelectAll();
                    return;
                }
                //If no match, create account and inform user
                else
                {
                    acctAcc.WriteUserAccount();
                    MessageBox.Show("Account creation success!", "Sign Up", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtBxPass.ResetText();
                    txtBxPass.Focus();

                    btnSignIn.Text = "Sign In";
                    lblSign.Text = "Don't have an account?";
                    lnkLblSignUp.Text = "Sign up now.";
                    lblConfPw.Enabled = false;
                    lblConfPw.Visible = false;
                    txtBxConfPw.ResetText();
                    txtBxConfPw.Enabled = false;
                    txtBxConfPw.Visible = false;
                }
            }
        }

        private void txtBxPass_KeyDown(object sender, KeyEventArgs e)
        {
            if (lblConfPw.Visible == false && e.KeyCode == Keys.Enter)
            {
                btnSignIn_Click(this, new EventArgs());
            }
        }

        private void txtBxConfPw_KeyDown(object sender, KeyEventArgs e)
        {
            if (lblConfPw.Visible == true && e.KeyCode == Keys.Enter)
            {
                btnSignIn_Click(this, new EventArgs());
            }
        }
    }
}
