using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ComicArchive.Data_Access;
using System.Diagnostics;
using static ComicArchive.User_Interface.AdminUI;

namespace ComicArchive.User_Interface
{
    public partial class ResetUsernameUI : Form
    {
        //data members
        private Business_Logic.Admin adminUser;
        private AccountAccess acctReader;
        public event UsernameChangedHandler UsernameChangedEvent;
        bool usernameChanged;

        public ResetUsernameUI(Business_Logic.Admin adminUser, AccountAccess acctReader)
        {
            InitializeComponent();

            //set data members
            this.adminUser = adminUser;
            this.acctReader = acctReader;
            usernameChanged = false;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnVerify_Click(object sender, EventArgs e)
        {
            string input = txtBxInput.Text.Trim();

            //password entering phase
            if (lbl_Input.Text == "Password: ")
            {
                if (input.Length < 6)
                {
                    lbl_Info.Text = "Password must be at least 6 characters long.";
                    lbl_Info.ForeColor = Color.DarkRed;
                }
                else if (input != adminUser.Password)
                {
                    lbl_Info.Text = "Incorrect password entered.";
                    lbl_Info.ForeColor = Color.DarkRed;
                }
                else
                {
                    lbl_Info.Text = "Enter your new username.";
                    lbl_Input.Text = "New username: ";
                    lbl_Info.ForeColor = Color.Black;
                }
            }
            //username entering phase
            else
            {
                if (input.Length < 6)
                {
                    lbl_Info.Text = "Username must be at least 6 characters long.";
                    lbl_Info.ForeColor = Color.DarkRed;
                }
                else if (acctReader.AccountExists(input))
                {
                    lbl_Info.Text = "Username is already used. Please enter another.";
                    lbl_Info.ForeColor = Color.DarkRed;
                }
                else
                {
                    lbl_Info.Text = "Enter your new username.";
                    lbl_Info.ForeColor = Color.Black;

                    //confirm username change
                    DialogResult response = MessageBox.Show("Change username?", "Reset Username",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2);

                    if (response == DialogResult.Yes)
                    {
                        //change username
                        if (acctReader.UpdateAccount(adminUser.Id, input, adminUser.Password))
                        {
                            adminUser = acctReader.GetAdminAccount(input, adminUser.Password);
                            MessageBox.Show("Username changed!", "Reset Username", MessageBoxButtons.OK,
                                MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);

                            lbl_Info.Text = "Username successfully changed!";
                            lbl_Info.ForeColor = Color.Green;
                            usernameChanged = true;

                            this.Close();
                        }
                        else
                        {
                            Trace.WriteLine("Failed to update new username: " + adminUser.Username +
                                ", with password: " + adminUser.Password + ", and ID: " + adminUser.Id);
                            MessageBox.Show("Failed to change username.", "Reset Username", MessageBoxButtons.OK,
                                MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                            lbl_Info.Text = "Enter your new username.";
                            lbl_Info.ForeColor = Color.Black;
                        }
                    }
                }
            }
        }

        private void txtBxInput_TextChanged(object sender, EventArgs e)
        {
            string input = txtBxInput.Text.Trim();

            //password entering phase
            if (lbl_Input.Text == "Password: ")
            {
                if (input.Length < 6)
                {
                    lbl_Info.Text = "Password must be at least 6 characters long.";
                    lbl_Info.ForeColor = Color.DarkRed;
                }
                else if (input != adminUser.Password)
                {
                    lbl_Info.Text = "Incorrect password entered.";
                    lbl_Info.ForeColor = Color.DarkRed;
                }
                else
                {
                    lbl_Info.Text = "Enter your password to continue.";
                    lbl_Info.ForeColor = Color.Black;
                }
            }
            //username entering phase
            else
            {
                if (input.Length < 6)
                {
                    lbl_Info.Text = "Username must be at least 6 characters long.";
                    lbl_Info.ForeColor = Color.DarkRed;
                }
                else if (acctReader.AccountExists(input))
                {
                    lbl_Info.Text = "Username is already used. Please enter another.";
                    lbl_Info.ForeColor = Color.DarkRed;
                }
                else
                {
                    lbl_Info.Text = "Enter your new username.";
                    lbl_Info.ForeColor = Color.Black;
                }
            }
        }

        private void ResetUsername_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (usernameChanged)
                UsernameChangedEvent(this, new UsernameChangedArgs() { adminUser = this.adminUser});
            else
                UsernameChangedEvent(this, new UsernameChangedArgs() { adminUser = null });
        }

        private void txtBxInput_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnVerify_Click(this, new EventArgs());
            }
        }
    }
}
