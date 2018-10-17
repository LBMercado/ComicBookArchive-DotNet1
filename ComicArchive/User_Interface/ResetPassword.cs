using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static ComicArchive.User_Interface.Admin;

namespace ComicArchive.User_Interface
{
    public partial class ResetPassword : Form
    {
        //data members
        private string password;
        public event PasswordChangedHandler PasswordChangedEvent;

        public ResetPassword(string password)
        {
            InitializeComponent();
            this.password = password;
            btnChangePassword.Text = "Verify Password";
        }

        private void btnChangePassword_Click(object sender, EventArgs e)
        {
            //confirm old password
            if (txtBxPw1.Text != password && !txtBxPw2.Visible)
            {
                lblInfo.Text = "Incorrect password entered.";
                txtBxPw1.SelectAll();
                txtBxPw1.Focus();
            }
            else if (txtBxPw1.Text == password && !txtBxPw2.Visible)
            {
                lblInfo.Text = "Enter your new password.";
                txtBxPw2.Visible = true;
                lblNewPwConf.Visible = true;
                btnChangePassword.Text = "Change Password";
                txtBxPw1.ResetText();
                txtBxPw1.Focus();
            }
            else if (txtBxPw1.Text.Trim().Length < 6)
            {
                lblInfo.Text = "Passwords must be at least six characters long.";
                txtBxPw1.SelectAll();
                txtBxPw2.ResetText();
                txtBxPw1.Focus();
            }
            else if (txtBxPw1.Text != txtBxPw2.Text)
            {
                lblInfo.Text = "Passwords don't match.";
                txtBxPw1.SelectAll();
                txtBxPw2.ResetText();
                txtBxPw1.Focus();
            }
            else
            {
                MessageBox.Show("Password changed!", "Reset Password", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                this.password = txtBxPw1.Text;
                this.Close();
            }
        }

        private void ResetPassword_FormClosing(object sender, FormClosingEventArgs e)
        {
            PasswordChangedEvent(this, new PasswordChangedArgs() { password = this.password });
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtBxPw1_KeyDown(object sender, KeyEventArgs e)
        {
            if (!txtBxPw2.Visible && e.KeyCode == Keys.Enter)
            {
                btnChangePassword_Click(this, new EventArgs());
            }
        }

        private void txtBxPw2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnChangePassword_Click(this, new EventArgs());
            }
        }
    }
}
