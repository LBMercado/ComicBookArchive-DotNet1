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
using static ComicArchive.User_Interface.AdminUI;

namespace ComicArchive.User_Interface
{
    public partial class AdminUI_ModifyUser : Form
    {
        //data members
        private int userId;
        private Business_Logic.User thisUser;
        private AccountAccess acctReader;
        public event UserModifiedHandler UserModifiedEvent;
        bool userHasBeenModified;
        bool userModifiedAndSaved;

        public AdminUI_ModifyUser(int userId, AccountAccess acctReader)
        {
            InitializeComponent();

            //set data members
            this.userId = userId;
            this.acctReader = acctReader;
            thisUser = acctReader.GetUserAccount(userId);
            userHasBeenModified = false;
            userModifiedAndSaved = false;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {

            //confirm exit if there are unsaved changes
            if (userHasBeenModified)
            {
                DialogResult response = MessageBox.Show("Your changes have not been saved. Exit?", "Modify User",
                MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2);

                if (response == DialogResult.Yes)
                {
                    userHasBeenModified = false;
                    this.Close();
                }
                    
            }
            else
            {
                this.Close();
            }
                
            
        }

        private void Admin_ModifyUser_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!userHasBeenModified && !userModifiedAndSaved)
            {
                UserModifiedEvent(this, new UserModifiedArgs() { modifiedUser = null});
            }
            else
            {
                UserModifiedEvent(this, new UserModifiedArgs() { modifiedUser = this.thisUser });
            }
        }

        private void Admin_ModifyUser_Load(object sender, EventArgs e)
        {
            //load values into textboxes
            txtBxName.Text = thisUser.Username;
            txtBxPassword.Text = thisUser.Password;
        }

        private void NameAndPassword_TextChanged(object sender, EventArgs e)
        {
            lbl_Info.ResetText();
            lbl_Info.ForeColor = Color.DarkRed;
            string modifiedUsername = txtBxName.Text.Trim();
            string modifiedPassword = txtBxPassword.Text.Trim();
            if (modifiedUsername != thisUser.Username ||
                modifiedPassword != thisUser.Password)
            {
                if (modifiedPassword.Length < 6 ||
                    modifiedUsername.Length < 6)
                {
                    lbl_Info.Text = "Username or Password must be at least 6 characters long.";
                    return;
                }
                //input checking
                if (acctReader.AccountExists(modifiedUsername) && modifiedUsername != thisUser.Username)
                {
                    lbl_Info.Text = "That username is already used.";
                }
                else
                {
                    userHasBeenModified = true;
                    lbl_Info.Text = "User has been modified.";
                    lbl_Info.ForeColor = Color.Yellow;
                }
            }
            else
            {
                userHasBeenModified = false;
                lbl_Info.Text = "";
            }
        }

        private void btnModifyUser_Click(object sender, EventArgs e)
        {
            if (userHasBeenModified)
            {
                //write changes to XML accounts file
                acctReader.UpdateAccount(thisUser.Id, txtBxName.Text.Trim(), txtBxPassword.Text.Trim());
                //update the user
                thisUser = acctReader.GetUserAccount(thisUser.Id);
                userHasBeenModified = false;

                MessageBox.Show("User has been modified!", "Modify User",
                MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                userModifiedAndSaved = true;
                this.Close();
            }
        }
    }
}
