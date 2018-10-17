﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ComicArchive.Data_Access;
using static ComicArchive.User_Interface.Admin;

namespace ComicArchive.User_Interface
{
    public partial class Admin_AddUser : Form
    {
        //data members
        private Admin ui_admin;
        private AccountAccess acctReader;
        public event AddUserHandler AddUserEvent;
        private Business_Logic.Admin newAdmin;
        private Business_Logic.User newUser;

        public Admin_AddUser(Admin ui_admin, AccountAccess acctReader)
        {
            InitializeComponent();

            //set data members
            this.ui_admin = ui_admin;
            this.acctReader = acctReader;
            this.newAdmin = null;
            this.newUser = null;

            //UI setup
            lbl_Info.ResetText();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Admin_AddUser_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (newUser == null && newAdmin == null)
                AddUserEvent(this, new AddUserArgs() { NewUser = null, NewAdmin = null });
            else if (newAdmin == null)
            {
                AddUserEvent(this, new AddUserArgs() { NewUser = newUser, NewAdmin = null });
            }
            else
            {
                AddUserEvent(this, new AddUserArgs() { NewUser = null, NewAdmin = newAdmin });
            }
        }

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            string username = txtBxName.Text.Trim();
            string password = txtBxPassword.Text.Trim();
            string passwordConf = txtBxPasswordConf.Text.Trim();

            acctReader.SetAccount(username, password);
            if (username == "" ||
                password == "" ||
                username.Length < 6 ||
                password.Length < 6)
            {
                lbl_Info.Text = "Username and password must be at least 6 characters long.";
            }
            else if (acctReader.AccountExists())
            {
                lbl_Info.Text = "Username is already used. Please enter another.";
            }
            else if(password != passwordConf)
            {
                lbl_Info.Text = "Passwords don't match.";
            }
            else
            {
                if (chkBxIsAdmin.Checked)
                {
                    acctReader.WriteAdminAccount();
                    lbl_Info.ForeColor = Color.Green;
                    lbl_Info.Text = "New admin successfully added!";
                    MessageBox.Show("New admin successfully added!", "Add User", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    this.newAdmin = acctReader.GetAdminAccount();
                    this.Close();
                }
                else
                {
                    acctReader.WriteUserAccount();
                    lbl_Info.ForeColor = Color.Green;
                    lbl_Info.Text = "New user successfully added!";
                    MessageBox.Show("New user successfully added!", "Add User", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    this.newUser = acctReader.GetUserAccount();
                    this.Close();
                }
                
            }
        }

        private void txtBxInputs_TextChanged(object sender, EventArgs e)
        {
            string username = txtBxName.Text.Trim();
            string password = txtBxPassword.Text.Trim();
            string passwordConf = txtBxPasswordConf.Text.Trim();
            lbl_Info.ForeColor = Color.DarkRed;

            acctReader.SetAccount(username, password);
            if (username == "" ||
                password == "" ||
                username.Length < 6 ||
                password.Length < 6)
            {
                lbl_Info.Text = "Username and password must be at least 6 characters long.";
            }
            else if (acctReader.AccountExists())
            {
                lbl_Info.Text = "Username is already used. Please enter another.";
            }
            else if (password != passwordConf)
            {
                lbl_Info.Text = "Passwords don't match.";
            }
            else
            {
                if (chkBxIsAdmin.Checked)
                {
                    lbl_Info.ForeColor = Color.Green;
                    lbl_Info.Text = "New admin can be added.";
                }
                else
                {
                    lbl_Info.ForeColor = Color.Green;
                    lbl_Info.Text = "New user can be added.";
                }
            }
        }

        private void chkBxIsAdmin_CheckedChanged(object sender, EventArgs e)
        {
            txtBxInputs_TextChanged(this, e);
        }
    }
}