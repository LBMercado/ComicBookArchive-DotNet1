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
using static ComicArchive.User_Interface.Admin;

namespace ComicArchive.User_Interface
{
    public partial class Admin_ModifyUser : Form
    {
        //data members
        private int userId;
        private Business_Logic.User modifiedUser;
        private AccountAccess acctReader;
        public event UserModifiedHandler UserModifiedEvent;
        bool userHasBeenModified;

        public Admin_ModifyUser(int userId, AccountAccess acctReader)
        {
            InitializeComponent();

            //set data members
            this.userId = userId;
            this.acctReader = acctReader;
            modifiedUser = null;
            userHasBeenModified = false;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {

            //confirm exit if there are unsaved changes
            if (userHasBeenModified)
            {
                DialogResult response = MessageBox.Show("Your changes will not be saved. Exit?", "Modify User",
                MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2);

                if (response == DialogResult.Yes)
                    this.Close();
            }
            else
                this.Close();
            
        }

        private void Admin_ModifyUser_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (modifiedUser == null)
            {
                UserModifiedEvent(this, new UserModifiedArgs() { modifiedUser = null});
            }
            else
            {
                UserModifiedEvent(this, new UserModifiedArgs() { modifiedUser = this.modifiedUser });
            }
        }
    }
}
