using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using ComicArchive.Data_Access;
using System.IO;

namespace ComicArchive.User_Interface
{
    public partial class Admin : Form
    {
        //data members
        private Login ui_login;
        private Business_Logic.Admin loggedAdmin;
        private AccountAccess accountReader;
        private ComicAccess comicReader;
        private Business_Logic.Admin[] adminAccts;
        private Business_Logic.User[] userAccts;
        private const string accountFileName = "accounts.xml";
        private const string cbRecordsFileName = "cbInfo.xml";

        public Admin(Login ui_login, Business_Logic.Admin admin)
        {
            InitializeComponent();

            this.ui_login = ui_login;
            this.loggedAdmin = admin;
            lblAdminName.Text = admin.Username;
            tbCtrlSearch_HideTabPages();
            tbCtrlSearch_ShowTabPageUser();
            accountReader = new AccountAccess(accountFileName);
            comicReader = new ComicAccess(cbRecordsFileName);

            //fill the listViewUserList with user names
            //filter list by id by default
            adminAccts = accountReader.GetAllAdminAccounts();
            userAccts = accountReader.GetAllUserAccounts();
            lblUserCount.Text += accountReader.Count.ToString();
            rdBtnSearchById.Checked = true;
            txtBxDateAdded.ReadOnly = true;
            lstViewAvailableComics_Refresh();
        }

        //START
        //events, event handlers, args, methods
        //1
        public delegate void PasswordChangedHandler(object sender, PasswordChangedArgs e);

        public class PasswordChangedArgs : EventArgs
        {
            public string password { get; set; }
        }

        public void EventTrigger_ChangePassword(object source, PasswordChangedArgs e)
        {
            Trace.WriteLine("ChangePassword event triggered!\nAdmin Password changed! " + loggedAdmin.Password + " -> " + e.password);
            loggedAdmin.Password = e.password;
            accountReader.SetAccount(loggedAdmin.Username, loggedAdmin.Password);
            accountReader.WriteAdminAccount();
        }
        //2
        public delegate void AddUserHandler(object sender, AddUserArgs e);

        public class AddUserArgs : EventArgs
        {
            public Business_Logic.User NewUser { get; set; }
            public Business_Logic.Admin NewAdmin { get; set; }
        }

        public void EventTrigger_AddUser(object source, AddUserArgs e)
        {
            if (e.NewAdmin == null & e.NewUser == null)
                Trace.WriteLine("AddUser event triggered! No new user added.");
            else if (e.NewUser != null)
            {
                Trace.WriteLine("AddUser event triggered! New user added!\n" + "Name: " + e.NewUser.Username +
                "\nPassword: " + e.NewUser.Password + "\nID: " + e.NewUser.Id.ToString());
            }
            else
            {
                Trace.WriteLine("AddUser event triggered! New user added!\n" + "Name: " + e.NewAdmin.Username +
                "\nPassword: " + e.NewAdmin.Password + "\nID: " + e.NewAdmin.Id.ToString());
            }

            //refresh values to reflect changes
            adminAccts = accountReader.GetAllAdminAccounts();
            userAccts = accountReader.GetAllUserAccounts();
            lstViewUsers_fillValues("", true, false);
            lblUserCount.Text = "Total Number of Users: " + accountReader.Count.ToString();
        }
        //3
        public delegate void UsernameChangedHandler(object sender, UsernameChangedArgs e);

        public class UsernameChangedArgs : EventArgs
        {
            public Business_Logic.Admin adminUser { get; set; }
        }

        public void EventTrigger_UsernameChanged(object source, UsernameChangedArgs e)
        {
            if (e.adminUser != null)
            {
                Trace.WriteLine("UsernameChanged event triggered!\nAdmin Username changed! " + loggedAdmin.Username + " -> " + e.adminUser.Username);
                accountReader.SetAccount(e.adminUser.Username, e.adminUser.Password);

                //refresh values to reflect changes
                loggedAdmin = accountReader.GetAdminAccount();
                lblAdminName.Text = loggedAdmin.Username;

                //refresh admin accounts list to reflect changes
                adminAccts = accountReader.GetAllAdminAccounts();
            }
            else
            {
                Trace.WriteLine("UsernameChanged event triggered!\nNo changes were made.");
            }

        }
        //4
        public delegate void UserModifiedHandler(object sender, UserModifiedArgs e);

        public class UserModifiedArgs : EventArgs
        {
            public Business_Logic.User modifiedUser { get; set; }
        }

        public void EventTrigger_UserModified(object source, UserModifiedArgs e)
        {
            if (e.modifiedUser != null)
            {
                Trace.WriteLine("UserModified event triggered!\nUser details have been modified!");
            }
            else
            {
                Trace.WriteLine("UserModified event triggered!\nNo changes were made to the user.");
            }

        }
        //END

        private void btnSignOut_Click(object sender, EventArgs e)
        {
            ui_login.Show();
            this.Close();
        }

        private void Admin_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (!ui_login.Visible)
                ui_login.Close();
        }

        private void dateTimer_Tick(object sender, EventArgs e)
        {
            lblDateToday.Text = DateTime.Now.ToShortDateString();
            lblRunningTime.Text = DateTime.Now.ToLongTimeString();
        }

        private void tbCtrlSearch_HideTabPages()
        {
            tbCtrlSearch.TabPages.Remove(tbPgSearchUser);
            tbCtrlSearch.TabPages.Remove(tbPgSearchComic);
        }

        private void tbCtrlSearch_ShowTabPageUser()
        {
            if (!tbCtrlSearch.TabPages.Contains(tbPgSearchUser))
                tbCtrlSearch.TabPages.Add(tbPgSearchUser);
            if (tbCtrlSearch.TabPages.Contains(tbPgSearchComic))
                tbCtrlSearch.TabPages.Remove(tbPgSearchComic);
        }

        private void tbCtrlSearch_ShowTabPageComic()
        {
            if (!tbCtrlSearch.TabPages.Contains(tbPgSearchComic))
                tbCtrlSearch.TabPages.Add(tbPgSearchComic);
            if (tbCtrlSearch.TabPages.Contains(tbPgSearchUser))
                tbCtrlSearch.TabPages.Remove(tbPgSearchUser);
        }

        private void lstViewUsers_fillValues(string searchVal, bool filterByUsername, bool useExactMatch)
        {
            //clear data items in listview
            lstViewUsers.Items.Clear();
            searchVal = searchVal.Trim();

            foreach (var adminAcct in adminAccts)
            {
                if (adminAcct.Id != loggedAdmin.Id)
                {
                    //filter by username, exact match
                    if (filterByUsername && useExactMatch)
                    {
                        if (adminAcct.Username == searchVal)
                        {
                            lstViewUsers.Items.Add(new ListViewItem(
                        new string[] { adminAcct.Id.ToString(), adminAcct.Username }
                                    ));
                        }
                    }
                    //filter by username, no match case, case insensitive
                    else if (filterByUsername && !useExactMatch)
                    {
                        if (adminAcct.Username.ToLower().Contains(searchVal.ToLower()))
                        {
                            lstViewUsers.Items.Add(new ListViewItem(
                        new string[] { adminAcct.Id.ToString(), adminAcct.Username }
                                    ));
                        }
                    }
                    //filter by id, exact match
                    else if (!filterByUsername && useExactMatch)
                    {
                        if (adminAcct.Id.ToString() == searchVal)
                        {
                            lstViewUsers.Items.Add(new ListViewItem(
                        new string[] { adminAcct.Id.ToString(), adminAcct.Username }
                                    ));
                        }
                    }
                    //filter by id, no match case, case insensitive
                    else
                    {
                        if (adminAcct.Id.ToString().Contains(searchVal))
                        {
                            lstViewUsers.Items.Add(new ListViewItem(
                        new string[] { adminAcct.Id.ToString(), adminAcct.Username }
                                    ));
                        }
                    }
                }
            }
            foreach (var userAcct in userAccts)
            {
                //filter by username, exact match
                if (filterByUsername && useExactMatch)
                {
                    if (userAcct.Username == searchVal)
                    {
                        lstViewUsers.Items.Add(new ListViewItem(
                    new string[] { userAcct.Id.ToString(), userAcct.Username }
                                ));
                    }
                }
                //filter by username, no match case, case insensitive
                else if (filterByUsername && !useExactMatch)
                {
                    if (userAcct.Username.ToLower().Contains(searchVal.ToLower()))
                    {
                        lstViewUsers.Items.Add(new ListViewItem(
                    new string[] { userAcct.Id.ToString(), userAcct.Username }
                                ));
                    }
                }
                //filter by id, exact match
                else if (!filterByUsername && useExactMatch)
                {
                    if (userAcct.Id.ToString() == searchVal)
                    {
                        lstViewUsers.Items.Add(new ListViewItem(
                    new string[] { userAcct.Id.ToString(), userAcct.Username }
                                ));
                    }
                }
                //filter by id, no match case, case insensitive
                else
                {
                    if (userAcct.Id.ToString().Contains(searchVal))
                    {
                        lstViewUsers.Items.Add(new ListViewItem(
                    new string[] { userAcct.Id.ToString(), userAcct.Username }
                                ));
                    }
                }
            }
        }

        private void txtBxSearchUser_TextChanged(object sender, EventArgs e)
        {
            lstViewUsers_fillValues(txtBxSearchUser.Text, rdBtnSearchByUsername.Checked, chkBxSearchUserMatchCase.Checked);
            //reset labels and disable delete button
            lblUserId.Hide();
            lblUsername.Hide();
            lbl_IsAdmin.Hide();
            lblUserPassword.Hide();
            btnDeleteUser.Enabled = false;
            btnModifyUser.Enabled = false;
        }

        private void btnChangePassword_Click(object sender, EventArgs e)
        {
            ResetPassword ui_rstPass = new ResetPassword(loggedAdmin.Password);
            ui_rstPass.PasswordChangedEvent += new PasswordChangedHandler(EventTrigger_ChangePassword);
            ui_rstPass.ShowDialog();
        }

        private void tbCtrlAdmin_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tbCtrlAdmin.SelectedTab == tbPgUsers)
                tbCtrlSearch_ShowTabPageUser();
            else
                tbCtrlSearch_ShowTabPageComic();
        }

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            Admin_AddUser ui_adminAddUser = new Admin_AddUser(this, accountReader);
            ui_adminAddUser.AddUserEvent += new AddUserHandler(EventTrigger_AddUser);
            ui_adminAddUser.ShowDialog();
        }

        private void btnDeleteUser_Click(object sender, EventArgs e)
        {
            //get the corresponding user from the labels
            string selectedUsername = lblUsername.Text.Substring(10);
            string selectedPassword = lblUserPassword.Text.Substring(10);

            //check if selected user is super admin, you cannot delete a super admin
            if (selectedUsername == "admin_super")
            {
                MessageBox.Show("Super admins cannot be removed.", "Remove User", MessageBoxButtons.OK,
                        MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                return;
            }

            //ask for confirmation first before proceeding
            DialogResult response = MessageBox.Show("Are you sure you want to delete this user?", "Confirm Delete",
                MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2);

            if (response == DialogResult.Yes)
            {
                //remove user
                accountReader.SetAccount(selectedUsername, selectedPassword);
                if (accountReader.RemoveAccount())
                {
                    MessageBox.Show("User successfully removed.", "Remove User", MessageBoxButtons.OK,
                        MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                }
                else
                {
                    Trace.WriteLine("Failed to remove user: <" + selectedUsername + "> with password: <" + selectedPassword + ">");
                    MessageBox.Show("Failed to remove user", "Remove User", MessageBoxButtons.OK,
                        MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                }
                //refresh values to reflect changes
                adminAccts = accountReader.GetAllAdminAccounts();
                userAccts = accountReader.GetAllUserAccounts();
                lstViewUsers_fillValues("", true, false);
                lblUserCount.Text = "Total Number of Users: " + accountReader.Count.ToString();

                //reset labels and disable button
                lblUserId.Hide();
                lblUsername.Hide();
                lbl_IsAdmin.Hide();
                lblUserPassword.Hide();
                btnDeleteUser.Enabled = false;
                btnModifyUser.Enabled = false;
            }
            else
                return;
        }

        private void lstViewUsers_SelectedIndexChanged(object sender, EventArgs e)
        {
            //highligh selection made in lstViewUsers

            if (lstViewUsers.SelectedIndices.Count != 0)
            {
                Trace.WriteLine("Selection Index Changed: " + lstViewUsers.SelectedIndices[0].ToString());
                int selectedIndex = lstViewUsers.SelectedIndices[0];
                string selectedItem = lstViewUsers.Items[selectedIndex].Text;

                //enable the labels and buttons if they aren't yet
                if (!lblUserId.Visible)
                {
                    lblUserId.Show();
                    lblUsername.Show();
                    lbl_IsAdmin.Show();
                    lblUserPassword.Show();
                    btnDeleteUser.Enabled = true;
                }
                Trace.WriteLine("User list item selected: " + selectedItem);

                //get the corresponding user from the userAccts/adminAccts
                bool userFound = false;
                //start with user accounts first
                foreach (var userAcc in userAccts)
                {
                    if (userAcc.Id.ToString() == selectedItem)
                    {
                        lblUserId.Text = "User ID: " + userAcc.Id.ToString();
                        lblUsername.Text = "Username: " + userAcc.Username;
                        lblUserPassword.Text = "Password: " + userAcc.Password;
                        lbl_IsAdmin.Text = "Is Admin: " + userAcc.IsAdmin;
                        //modify button only for users, not admins
                        btnModifyUser.Enabled = true;
                        userFound = true;
                        break;
                    }
                }
                //if user is already found, no need to check for admin
                if (!userFound)
                {
                    foreach (var adminAcc in adminAccts)
                    {
                        if (adminAcc.Id.ToString() == selectedItem)
                        {
                            lblUserId.Text = "User ID: " + adminAcc.Id.ToString();
                            lblUsername.Text = "Username: " + adminAcc.Username;
                            lblUserPassword.Text = "Password: " + adminAcc.Password;
                            lbl_IsAdmin.Text = "Is Admin: " + adminAcc.IsAdmin;
                            userFound = true;
                            break;
                        }
                    }
                }
            }
            //highlight selection disappeared from lstViewUsers
            else
            {
                Trace.WriteLine("Selection Index Changed: " + "NULL");
                //reset labels and disable button
                lblUserId.Hide();
                lblUsername.Hide();
                lbl_IsAdmin.Hide();
                lblUserPassword.Hide();
                btnDeleteUser.Enabled = false;
                btnModifyUser.Enabled = false;
            }
        }

        private void rdBtnSearchOption_CheckedChanged(object sender, EventArgs e)
        {
            lstViewUsers_fillValues(txtBxSearchUser.Text, rdBtnSearchByUsername.Checked, chkBxSearchUserMatchCase.Checked);
            //reset labels and disable delete button
            lblUserId.Hide();
            lblUsername.Hide();
            lbl_IsAdmin.Hide();
            lblUserPassword.Hide();
            btnDeleteUser.Enabled = false;
            btnModifyUser.Enabled = false;
        }

        private void btnChangeUsername_Click(object sender, EventArgs e)
        {
            ResetUsername ui_rstUser = new ResetUsername(loggedAdmin, accountReader);
            ui_rstUser.UsernameChangedEvent += new UsernameChangedHandler(EventTrigger_UsernameChanged);
            ui_rstUser.ShowDialog();
        }

        private void btnModifyUser_Click(object sender, EventArgs e)
        {
            int userId = int.Parse(lblUserId.Text.Substring(10));

            Admin_ModifyUser ui_modUser = new Admin_ModifyUser(userId, accountReader);
            ui_modUser.UserModifiedEvent += new UserModifiedHandler(EventTrigger_UserModified);
            ui_modUser.ShowDialog();
        }

        private void btnImportComic_Click(object sender, EventArgs e)
        {
            //ask user to import a cbr/cbz archive using file dialog
            OpenFileDialog fileDlg = new OpenFileDialog();
            fileDlg.InitialDirectory = Directory.GetCurrentDirectory();
            fileDlg.RestoreDirectory = true;
            fileDlg.Title = "Select Comic Book Archive";
            fileDlg.Filter = "CBR/CBZ archive (*.cbr,*.cbz)|*.cbr;*.cbz";
            fileDlg.CheckFileExists = true;
            fileDlg.Multiselect = true;
            fileDlg.ShowDialog();

            string[] archivePaths = fileDlg.FileNames;
            string comicArchiveDir = Path.Combine(Directory.GetCurrentDirectory(), "Resources", "comicbooks");
            //create directory, as assurance
            Directory.CreateDirectory(comicArchiveDir);

            //copy each archive to resources folder
            //create a comic book records instance for each archive path
            List<Business_Logic.ComicBook> comicBookList = new List<Business_Logic.ComicBook>();
            foreach (var path in archivePaths)
            {
                string copiedCbPath = Path.Combine(comicArchiveDir, Path.GetFileName(path));
                if (!File.Exists(copiedCbPath))
                    File.Copy(path, copiedCbPath);
                Business_Logic.ComicBook newComicBook = new Business_Logic.ComicBook();
                newComicBook.SetArchivePath(copiedCbPath);
                newComicBook.ComicTitle = Path.GetFileNameWithoutExtension(path);
                newComicBook.ComicSubTitle = "";
                newComicBook.ComicIssue = "";
                newComicBook.ComicDateAdded = DateTime.Now;
                newComicBook.ComicDateReleased = DateTime.Now;
                newComicBook.ComicSynopsis = "";
                newComicBook.ComicGenre = "";
                newComicBook.Publisher = "";
                newComicBook.AvgRating = 0;
                newComicBook.ViewCount = 0;
                comicBookList.Add(newComicBook);
            }

            //write records to XML file
            foreach (Business_Logic.ComicBook book in comicBookList)
            {
                comicReader.WriteComicBookRecord(book);
            }
            //update listViewAvailableComics
            lstViewAvailableComics_Refresh();

        }

        /// <summary>
        /// reread available comics
        /// </summary>
        private void lstViewAvailableComics_Refresh()
        {
            //clear items
            lstViewAvailableComics.Items.Clear();

            //update the comic book archives into the view
            foreach (var file in Directory.GetFiles(Path.Combine(Directory.GetCurrentDirectory(), "Resources", "comicbooks")))
            {
                lstViewAvailableComics.Items.Add(Path.GetFileName(file));
            }
        }

        private void lstViewAvailableComics_SelectedIndexChanged(object sender, EventArgs e)
        {
            //highligh selection made in lstViewAvailableComics
            if (lstViewAvailableComics.SelectedIndices.Count != 0)
            {
                Trace.WriteLine("Selection Index Changed: " + lstViewAvailableComics.SelectedIndices[0].ToString());
                int selectedIndex = lstViewAvailableComics.SelectedIndices[0];
                string selectedItem = lstViewAvailableComics.Items[selectedIndex].Text;

                string cbFullPath = Path.GetFullPath(Path.Combine(@"Resources", @"comicbooks", selectedItem));
                Business_Logic.ComicBook selectedComic;
                try
                {
                    //get comicbook instance
                    selectedComic = comicReader.GetComicBook(cbFullPath);
                    if (selectedComic == null)
                        throw new InvalidOperationException("Comic book records is empty.");
                }
                catch(InvalidOperationException exc)
                {
                    Trace.WriteLine("Exception thrown: " + exc.Message);
                    Trace.WriteLine("Comic book selected with archive path: <" + cbFullPath + "> does not exist in the comic book records. Initialized the comic book.");
                    comicReader.InitializeNewComicBook(cbFullPath);
                    selectedComic = comicReader.GetComicBook(cbFullPath);
                }

                //enable textboxes/labels
                ComicInfo_Enable(true);

                //set values in textboxes/labels
                ComicInfo_SetValues(selectedComic);
            }
            //highlight selection disappeared from lstViewAvailableComics
            else
            {
                Trace.WriteLine("Selection Index Changed: " + "NULL");
                //hide the controls and disable the textboxes
                ComicInfo_Enable(false);
            }
        }

        private void ComicInfo_Enable(bool enabled)
        {
            //reset text
            txtBxComicTitle.ResetText();
            txtBxComicSubTitle.ResetText();
            txtBxComicIssue.ResetText();
            txtBxDateAdded.ResetText();
            txtBxDateReleased.ResetText();
            richTxtBxSynopsis.ResetText();
            txtBxAuthors.ResetText();
            txtBxGenre.ResetText();
            txtBxPublisher.ResetText();

            //enable/disable
            btnDeleteComic.Enabled = enabled;
            btnEditComic.Enabled = enabled;
            txtBxComicTitle.Enabled = enabled;
            txtBxComicSubTitle.Enabled = enabled;
            txtBxComicIssue.Enabled = enabled;
            txtBxDateReleased.Enabled = enabled;
            txtBxDateAdded.Enabled = enabled;
            richTxtBxSynopsis.Enabled = enabled;
            txtBxAuthors.Enabled = enabled;
            txtBxGenre.Enabled = enabled;
            txtBxPublisher.Enabled = enabled;
            lblViewCount.Visible = enabled;
            lblAvgRating.Visible = enabled;
        }

        private void ComicInfo_SetValues(Business_Logic.ComicBook cb)
        {
            txtBxComicTitle.Text = cb.ComicTitle;
            txtBxComicSubTitle.Text = cb.ComicSubTitle;
            txtBxComicIssue.Text = cb.ComicIssue;
            txtBxDateAdded.Text = cb.ComicDateAdded.ToShortDateString();
            txtBxDateReleased.Text = cb.ComicDateReleased.ToShortDateString();
            richTxtBxSynopsis.Text = cb.ComicSynopsis;

            if (cb.ComicAuthors != null)
            {
                txtBxAuthors.ResetText();
                txtBxAuthors.Text = string.Join(",", cb.ComicAuthors);
            }

            txtBxGenre.Text = cb.ComicGenre;
            txtBxPublisher.Text = cb.Publisher;

            lblViewCount.Text = "# of Views: " + cb.ViewCount.ToString();
            lblAvgRating.Text = "Average Rating: " + cb.AvgRating.ToString();

            if (picBxComicCover.Image != null)
                picBxComicCover.Image.Dispose();
            picBxComicCover.Image = comicReader.GetComicFrontCover(cb.GetArchivePath());
        }

        private void btnEditComic_Click(object sender, EventArgs e)
        {
            //get and check each value
            string title = txtBxComicTitle.Text.Trim();

            if (title.Length == 0)
            {
                MessageBox.Show("Comic Title cannot be empty.", "Input Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                return;
            }
            //no need to check subtitle/issue, they can be empty
            string subtitle = txtBxComicSubTitle.Text.Trim();
            string issue = txtBxComicIssue.Text.Trim();

            //check if date can be parsed, is valid
            string dateReleased = txtBxDateReleased.Text.Trim();

            //parsed time must not contain an exact time (hours, mins, seconds)
            if (!DateTime.TryParse(dateReleased, out DateTime dateRel) && dateRel.TimeOfDay.TotalSeconds == 0)
            {
                MessageBox.Show("Invalid date inputted in Date Released entry.", "Input Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                return;
            }

            //no need to check synopsis, they can be empty
            string synopsis = richTxtBxSynopsis.Text;

            //authors must be correctly separated
            string[] authors = txtBxAuthors.Text.Split(',');

            authors = authors.Select(s => s.Trim()).ToArray();

            if (authors.Where(author => author.Length == 0).Count() != 0)
            {
                MessageBox.Show("Null authors are not allowed.", "Input Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                return;
            }

            //no need to check genre/publisher, they can be empty 
            string genre = txtBxGenre.Text;
            string publisher = txtBxPublisher.Text;

            //confirm username change
            DialogResult response = MessageBox.Show("Save changes made to comic book?", "Edit Comic Book",
                MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2);

            if (response == DialogResult.Yes)
            {
                //get comic book selected and update
                int selectedIndex = lstViewAvailableComics.SelectedIndices[0];
                string selectedItem = lstViewAvailableComics.Items[selectedIndex].Text;

                string cbFullPath = Path.GetFullPath(Path.Combine(@"Resources", @"comicbooks", selectedItem));

                //get comicbook instance
                Business_Logic.ComicBook selectedComic = comicReader.GetComicBook(cbFullPath);

                //set new values
                selectedComic.ComicTitle = title;
                selectedComic.ComicSubTitle = subtitle;
                selectedComic.ComicIssue = issue;
                selectedComic.ComicDateReleased = dateRel;
                selectedComic.ComicSynopsis = synopsis;
                selectedComic.ComicAuthors = authors;
                selectedComic.ComicGenre = genre;
                selectedComic.Publisher = publisher;

                //write to file
                if (comicReader.UpdateComicBookRecord(selectedComic))
                {
                    MessageBox.Show("Successfully modified comic information!", "Edit Comic Book",
                    MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);

                    ComicInfo_SetValues(selectedComic);
                }
                else
                {
                    Trace.WriteLine("Comic book with archivePath: <" + selectedComic.GetArchivePath() + "> failed to be modified.");
                    MessageBox.Show("Failed to modify comic book.", "Edit Comic Book",
                    MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                }
                
            }
        }

        private void btnDeleteComic_Click(object sender, EventArgs e)
        {
            //confirm username change
            DialogResult response = MessageBox.Show("Delete selected comic book?", "Delete Comic Book",
                MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2);

            if (response == DialogResult.Yes)
            {
                //get comic book selected and update
                int selectedIndex = lstViewAvailableComics.SelectedIndices[0];
                string selectedItem = lstViewAvailableComics.Items[selectedIndex].Text;

                string cbFullPath = Path.GetFullPath(Path.Combine(@"Resources", @"comicbooks", selectedItem));

                //get comicbook instance
                Business_Logic.ComicBook selectedComic = comicReader.GetComicBook(cbFullPath);

                //delete
                if (comicReader.RemoveComicBookRecord(selectedComic.GetArchivePath()))
                {
                    MessageBox.Show("Successfully deleted comic book!", "Delete Comic Book",
                    MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);

                    //delete archive in Resources/comicbook directory
                    File.Delete(selectedComic.GetArchivePath());

                    //refresh values
                    lstViewAvailableComics_Refresh();
                    ComicInfo_Enable(false);
                }
                else
                {
                    Trace.WriteLine("Comic book with archivePath: <" + selectedComic.GetArchivePath() + "> failed to be deleted.");
                    MessageBox.Show("Failed to delete comic book.", "Delete Comic Book",
                    MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                }

            }
        }
    }
}
