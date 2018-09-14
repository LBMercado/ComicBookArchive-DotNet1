using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ComicArchive
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
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
                txtBxConfPw.Enabled = true;
                txtBxConfPw.Visible = true;

                string userName = txtBxUser.Text;
                string passWord = txtBxPass.Text;

                //Verify login details

                //If no match, inform user, else...

                //Instantiate the MainMenu

            }
            else
            {
                btnSignIn.Text = "Sign In";
                lblSign.Text = "Don't have an account?";
                lnkLblSignUp.Text = "Sign up now.";
                lblConfPw.Enabled = false;
                lblConfPw.Visible = false;
                txtBxConfPw.Enabled = false;
                txtBxConfPw.Visible = false;

                string userName = txtBxUser.Text;
                string passWord = txtBxPass.Text;
                string confPW = txtBxConfPw.Text;

                //Verify if login details already exist in database

                //If no match, inform user, else...

                //Add login details to database

                //Instantiate the MainMenu

            }
            
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
