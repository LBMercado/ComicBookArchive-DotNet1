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
using ComicArchive.Business_Logic;
using ComicArchive.Application_Interface;

namespace ComicArchive.User_Interface
{
    public partial class AdminUI : Form
    {
        //data members
        private Login ui_login;
        private Admin loggedAdmin;
        private ExtendedAccountAccess accountReader;
        private ComicAccess comicReader;
        private Admin[] adminAccts;
        private User[] userAccts;
        private ComicBook[] comicBooks;
        private const string accountFileName = @"accounts.xml";
        private const string cbRecordsFileName = @"cbInfo.xml";
        private const string cbResourceDirectory = @"Resources/comicbooks";

        //progress dialog members
        private ProgressDialog progDialog;
        private BackgroundWorker bgWorker;
        bool backgroundProcessDone;

        public AdminUI(Login ui_login, Admin admin)
        {
            InitializeComponent();
            //set data members
            this.ui_login = ui_login;
            this.loggedAdmin = admin;
            lblAdminName.Text = admin.Username;
            accountReader = new ExtendedAccountAccess(accountFileName);
            comicReader = new ComicAccess(cbRecordsFileName);
            backgroundProcessDone = true;

            //ui setup
            tbCtrlSearch_HideTabPages();
            txtBxDateAdded.ReadOnly = true;

            //users tab
            UserInfo_Refresh();
            tbCtrlSearch_ShowTabPageUser();

            //comics tab
            string comicArchiveDir = Path.Combine(Directory.GetCurrentDirectory(), cbResourceDirectory);
            //create resource directory, as assurance
            Directory.CreateDirectory(comicArchiveDir);
            lstViewAvailableComics_Refresh();
        }

        #region Event Handling
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
            accountReader.WriteAdminAccount(loggedAdmin.Username, loggedAdmin.Password);
        }
        //2
        public delegate void AddUserHandler(object sender, AddUserArgs e);

        public class AddUserArgs : EventArgs
        {
            public User NewUser { get; set; }
            public Admin NewAdmin { get; set; }
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
            UserInfo_Refresh();
        }
        //3
        public delegate void UsernameChangedHandler(object sender, UsernameChangedArgs e);

        public class UsernameChangedArgs : EventArgs
        {
            public Admin adminUser { get; set; }
        }

        public void EventTrigger_UsernameChanged(object source, UsernameChangedArgs e)
        {
            if (e.adminUser != null)
            {
                Trace.WriteLine("UsernameChanged event triggered!\nAdmin Username changed! " + loggedAdmin.Username + " -> " + e.adminUser.Username);

                //refresh values to reflect changes
                loggedAdmin = accountReader.GetAdminAccount(e.adminUser.Username, e.adminUser.Password);
                lblAdminName.Text = loggedAdmin.Username;

                //refresh admin accounts list to reflect changes
                adminAccts = accountReader.ReadAllAdminAccounts();
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
            public User modifiedUser { get; set; }
        }

        public void EventTrigger_UserModified(object source, UserModifiedArgs e)
        {
            if (e.modifiedUser != null)
            {
                Trace.WriteLine("UserModified event triggered!\nUser details have been modified!");
                //refresh values to reflect changes
                UserInfo_Refresh();

                //reset labels and disable button
                UserInfo_Enabled(false);
            }
            else
            {
                Trace.WriteLine("UserModified event triggered!\nNo changes were made to the user.");
            }

        }
        //Progress Reporting for Import Comics
        public void FileTransfer_ReportProgress(object sender, ProgressArgs e)
        {
            progDialog.SetMaximumValueAsync(e.TotalRecords);
            progDialog.UpdateProgressAsync(e.TotalProcessed);
            progDialog.SetDescriptionAsync(e.Description);
            backgroundProcessDone = e.IsDoneProcessing;

            if (backgroundProcessDone)
                progDialog.BeginInvoke(new Action(() => progDialog.Close()));
        }
        public delegate void ReportProgressEventHandler(object sender, ProgressArgs args);

        public event ReportProgressEventHandler ReportProgress;

        public class ProgressArgs : EventArgs
        {
            public int TotalProcessed { get; set; }
            public int TotalRecords { get; set; }
            public string Description { get; set; }
            public bool IsDoneProcessing { get; set; }
        }
        //END
        #endregion
        #region Users Tab
        private void UserInfo_Refresh()
        {
            adminAccts = accountReader.ReadAllAdminAccounts();
            userAccts = accountReader.ReadAllUserAccounts();
            lstViewUsers_FillWithSearchCriteria("", true, false);
            lblUserCount.Text = "Total Number of Users: " + accountReader.Count.ToString();
        }

        private void UserInfo_Enabled(bool enabled)
        {
            //reset or set controls for user info
            if (!enabled)
            {
                lblUserId.Hide();
                lblUsername.Hide();
                lbl_IsAdmin.Hide();
                lblUserPassword.Hide();
            }
            else
            {
                lblUserId.Show();
                lblUsername.Show();
                lbl_IsAdmin.Show();
                lblUserPassword.Show();
            }

            lstViewUserComics.Visible = false;
            lblSavedComicsCount.Visible = false;
            btnDeleteUser.Enabled = enabled;
            btnModifyUser.Enabled = enabled;
        }

        private void UserComics_Show(User userAcc)
        {
            lstViewUserComics.Items.Clear();
            lstViewUserComics.Visible = true;
            lblSavedComicsCount.Visible = true;
            ComicLibrary comLib = userAcc.MyComicLibrary;

            //show in list view the imported comics
            foreach (var com in comLib.GetAllComicBooks())
            {
                lstViewUserComics.Items.Add(Path.GetFileName(com.GetArchivePath()));
            }

            //show quantity of imported comics
            lblSavedComicsCount.Text = "Num. of Saved Comics: " + comLib.Count;
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
                    UserInfo_Enabled(true);

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
                        btnModifyUser.Enabled = !userAcc.IsAdmin;
                        //user comics imported only for users
                        UserComics_Show(userAcc);                        
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
                            btnModifyUser.Enabled = !adminAcc.IsAdmin;
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
                UserInfo_Enabled(false);
            }
        }

        private void lstViewUsers_FillWithSearchCriteria(string searchVal, bool filterByUsername, bool useExactMatch)
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

        private void SearchUser_CriteriaSearchEvent(object sender, EventArgs e)
        {
            lstViewUsers_FillWithSearchCriteria(txtBxSearchUser.Text, rdBtnSearchByUsername.Checked, chkBxSearchUserMatchCase.Checked);
            //reset labels and disable delete button
            UserInfo_Enabled(false);
        }

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            AdminUI_AddUser ui_adminAddUser = new AdminUI_AddUser(this, accountReader);
            ui_adminAddUser.AddUserEvent += new AddUserHandler(EventTrigger_AddUser);
            ui_adminAddUser.ShowDialog();
        }

        private void btnModifyUser_Click(object sender, EventArgs e)
        {
            int userId = int.Parse(lblUserId.Text.Substring(9));

            AdminUI_ModifyUser ui_modUser = new AdminUI_ModifyUser(userId, accountReader);
            ui_modUser.UserModifiedEvent += new UserModifiedHandler(EventTrigger_UserModified);
            ui_modUser.ShowDialog();
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
                if (accountReader.RemoveAccount(selectedUsername, selectedPassword))
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
                UserInfo_Refresh();

                //reset labels and disable button
                UserInfo_Enabled(false);
            }
            else
                return;
        }

        
        #endregion
        #region Comics Tab

        /// <summary>
        /// reread available comics
        /// </summary>
        private void lstViewAvailableComics_Refresh()
        {
            //reset cache comic books and clear items
            comicBooks = null;
            lstViewAvailableComics.Items.Clear();

            //update the comic book archives into the view
            //cache each into comic book records
            List<Business_Logic.ComicBook> cbList = new List<Business_Logic.ComicBook>();

            foreach (var file in Directory.GetFiles(Path.Combine(Directory.GetCurrentDirectory(), "Resources", "comicbooks")))
            {
                lstViewAvailableComics.Items.Add(Path.GetFileName(file));

                string cbFullPath = "";
                Business_Logic.ComicBook cb;
                try
                {
                    //get full path of comic book archive
                    cbFullPath = Path.GetFullPath(Path.Combine(@"Resources", @"comicbooks", Path.GetFileName(file)));

                    //get comicbook instance
                    cb = comicReader.GetComicBook(cbFullPath);
                    if (cb == null)
                        throw new InvalidOperationException("Comic book records is empty.");
                }
                catch (InvalidOperationException exc)
                {
                    Trace.WriteLine("Exception thrown: " + exc.Message);
                    Trace.WriteLine("Comic book selected with archive path: <" + cbFullPath + "> does not exist in the comic book records. Initialized the comic book.");
                    comicReader.InitializeNewComicBook(cbFullPath);
                    cb = comicReader.GetComicBook(cbFullPath);
                }

                //add comic book to list
                cbList.Add(cb);
            }

            comicBooks = cbList.ToArray();
        }

        private void SearchComic_CriteriaSearchEvent(object sender, EventArgs e)
        {
            lstViewAvailableComics_FillWithSearchCriteria(txtBxSearchComic.Text.Trim());
        }

        private void lstViewAvailableComics_FillWithSearchCriteria(string searchVal)
        {
            //reset list view
            lstViewAvailableComics.Items.Clear();

            //filter by comic title, subtitle, and issue
            if (rdBtnComicHeaders.Checked)
            {
                //exact match, case sensitive
                if (chkBxSearchComicMatchCase.Checked)
                {
                    foreach (var cb in comicBooks)
                    {
                        if (cb.ComicTitle == searchVal ||
                            cb.ComicSubTitle == searchVal ||
                            cb.ComicIssue == searchVal)
                        {
                            lstViewAvailableComics.Items.Add(Path.GetFileName(cb.GetArchivePath()));
                        }
                    }
                }
                //check for substring existence, case insensitive
                else
                {
                    foreach (var cb in comicBooks)
                    {
                        if (cb.ComicTitle.ToLower().Contains(searchVal.ToLower()) ||
                            cb.ComicSubTitle.ToLower().Contains(searchVal.ToLower()) ||
                            cb.ComicIssue.ToLower().Contains(searchVal.ToLower()))
                        {
                            lstViewAvailableComics.Items.Add(Path.GetFileName(cb.GetArchivePath()));
                        }
                    }
                }
            }
            //filter by author/s
            else if (rdBtnAuthors.Checked)
            {
                //exact match, case sensitive
                if (chkBxSearchComicMatchCase.Checked)
                {
                    foreach (var cb in comicBooks)
                    {
                        //empty authors, don't bother checking, don't add
                        if (cb.ComicAuthors != null &&
                            cb.ComicAuthors.Where(author => author == searchVal).Count() != 0)
                        {
                            lstViewAvailableComics.Items.Add(Path.GetFileName(cb.GetArchivePath()));
                        }
                    }
                }
                //check for substring existence, case insensitive
                else
                {
                    foreach (var cb in comicBooks)
                    {
                        //empty authors, don't bother checking, don't add
                        if (cb.ComicAuthors != null &&
                            cb.ComicAuthors.Any(author => author.ToLower().Contains(searchVal.ToLower())))
                        {
                            lstViewAvailableComics.Items.Add(Path.GetFileName(cb.GetArchivePath()));
                        }
                    }
                }
            }
            //filter by genre
            else if (rdBtnGenre.Checked)
            {
                //exact match, case sensitive
                if (chkBxSearchComicMatchCase.Checked)
                {
                    foreach (var cb in comicBooks)
                    {

                        //empty genres, don't bother checking, don't add
                        if (cb.ComicGenres != null &&
                            cb.ComicGenres.Any(genre => genre == searchVal))
                        {
                            lstViewAvailableComics.Items.Add(Path.GetFileName(cb.GetArchivePath()));
                        }
                    }
                }
                //check for substring existence, case insensitive
                else
                {
                    foreach (var cb in comicBooks)
                    {
                        //empty genres, don't bother checking, don't add
                        if (cb.ComicGenres != null &&
                            cb.ComicGenres.Any(genre => genre.ToLower().Contains(searchVal.ToLower())))
                        {
                            lstViewAvailableComics.Items.Add(Path.GetFileName(cb.GetArchivePath()));
                        }
                    }
                }
            }
            //filter by publisher
            else
            {
                //exact match, case sensitive
                if (chkBxSearchComicMatchCase.Checked)
                {
                    foreach (var cb in comicBooks)
                    {
                        if (cb.Publisher == searchVal)
                        {
                            lstViewAvailableComics.Items.Add(Path.GetFileName(cb.GetArchivePath()));
                        }
                    }
                }
                //check for substring existence, case insensitive
                else
                {
                    foreach (var cb in comicBooks)
                    {
                        if (cb.Publisher.ToLower().Contains(searchVal.ToLower()))
                        {
                            lstViewAvailableComics.Items.Add(Path.GetFileName(cb.GetArchivePath()));
                        }
                    }
                }
            }

            //sort values based on checked sort order
            //sort by date added
            if (rdBtnSortDateAdded.Checked)
            {
                List<string> cbPathList = new List<string>();
                for (int i = 0; i < lstViewAvailableComics.Items.Count; i++)
                {
                    cbPathList.Add(lstViewAvailableComics.Items[i].Text);
                }

                //clear the control again
                lstViewAvailableComics.Items.Clear();
                cbPathList = cbPathList
                    .OrderBy(
                    path => comicReader.GetComicBook(Path.GetFullPath(Path.Combine(@"Resources", @"comicbooks", Path.GetFileName(path)))).ComicDateAdded
                    ).ToList();

                //readd to control
                foreach (var cbPath in cbPathList)
                {
                    lstViewAvailableComics.Items.Add(cbPath);
                }
            }
            //sort by date released
            else
            {
                List<string> cbPathList = new List<string>();
                for (int i = 0; i < lstViewAvailableComics.Items.Count; i++)
                {
                    cbPathList.Add(lstViewAvailableComics.Items[i].Text);
                }

                //clear the control again
                lstViewAvailableComics.Items.Clear();
                cbPathList = cbPathList
                    .OrderBy(
                    path => comicReader.GetComicBook(Path.GetFullPath(Path.Combine(@"Resources", @"comicbooks", Path.GetFileName(path)))).ComicDateReleased
                    ).ToList();

                //readd to control
                foreach (var cbPath in cbPathList)
                {
                    lstViewAvailableComics.Items.Add(cbPath);
                }
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
                ComicBook selectedComic;
                selectedComic = comicReader.GetComicBook(cbFullPath);

                //enable textboxes/labels
                ComicInfo_Enabled(true);

                //set values in textboxes/labels
                ComicInfo_SetValues(selectedComic);
            }
            //highlight selection disappeared from lstViewAvailableComics
            else
            {
                Trace.WriteLine("Selection Index Changed: " + "NULL");
                //hide the controls and disable the textboxes
                ComicInfo_Enabled(false);
            }
        }

        private void ComicInfo_Enabled(bool enabled)
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

            //reset cover 
            if (picBxComicCover.Image != null)
            {
                picBxComicCover.Image.Dispose();
                picBxComicCover.Image = null;
            }

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

        private void ComicInfo_SetValues(ComicBook cb)
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

            if (cb.ComicGenres != null)
            {
                txtBxGenre.ResetText();
                txtBxGenre.Text = string.Join(",", cb.ComicGenres);
            }

            txtBxPublisher.Text = cb.Publisher;

            lblViewCount.Text = "# of Views: " + cb.ViewCount.ToString();
            lblAvgRating.Text = "Average Rating: " + cb.Rating.ToString();
            lblNumPages.Text = "# of Pages: "+ cb.PageCount.ToString() + " Pages";

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

            //genres must be correctly separated, it can be empty
            string[] genres = txtBxGenre.Text.Split(',');

            genres = genres.Select(s => s.Trim()).ToArray();

            if (txtBxGenre.Text.Trim() != "" &&
                genres.Any(author => author.Length == 0))
            {
                MessageBox.Show("Null genres are not allowed.", "Input Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                return;
            }

            //no need to check publisher, they can be empty 
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
                selectedComic.ComicGenres = genres;
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
                    ComicInfo_Enabled(false);
                }
                else
                {
                    Trace.WriteLine("Comic book with archivePath: <" + selectedComic.GetArchivePath() + "> failed to be deleted.");
                    MessageBox.Show("Failed to delete comic book.", "Delete Comic Book",
                    MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                }

            }
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

            //start of background thread stuff
            progDialog = new ProgressDialog();
            backgroundProcessDone = false;
            bgWorker = new BackgroundWorker
            {
                WorkerReportsProgress = true,
                WorkerSupportsCancellation = true
            };

            bgWorker.DoWork += delegate (object s, DoWorkEventArgs args)
            {
                //copy each archive to resources folder
                //intitialize a comic book record for each archive path
                List<Business_Logic.ComicBook> comicBookList = new List<Business_Logic.ComicBook>();
                int progress = 0;
                foreach (var path in archivePaths)
                {
                    string copiedCbPath = Path.Combine(comicArchiveDir, Path.GetFileName(path));
                    if (!File.Exists(copiedCbPath))
                        File.Copy(path, copiedCbPath);
                    comicReader.InitializeNewComicBook(copiedCbPath);
                    progress++;
                    //report progress on file transfer
                    ReportProgress?.Invoke(this, new ProgressArgs
                    {
                        TotalProcessed = progress,
                        TotalRecords = archivePaths.Count(),
                        Description = "Importing comic books.",
                        IsDoneProcessing = false
                    });
                }
                //report that file transfer is done.
                ReportProgress?.Invoke(this, new ProgressArgs
                {
                    TotalProcessed = progress,
                    TotalRecords = archivePaths.Count(),
                    Description = "Importing comic books.",
                    IsDoneProcessing = true
                });
            };

            ReportProgress += FileTransfer_ReportProgress;

            bgWorker.RunWorkerAsync();
            progDialog.ShowDialog();
            //end of background thread stuff

            while (!backgroundProcessDone) ;

            //update listViewAvailableComics
            lstViewAvailableComics_Refresh();
        }

        #endregion
        #region Admin_Form
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
            {
                tbCtrlSearch.TabPages.Add(tbPgSearchUser);
                rdBtnSearchById.Checked = true;
                chkBxSearchUserMatchCase.Checked = false;
            }

            if (tbCtrlSearch.TabPages.Contains(tbPgSearchComic))
                tbCtrlSearch.TabPages.Remove(tbPgSearchComic);
        }

        private void tbCtrlSearch_ShowTabPageComic()
        {
            if (!tbCtrlSearch.TabPages.Contains(tbPgSearchComic))
            {
                tbCtrlSearch.TabPages.Add(tbPgSearchComic);
                rdBtnComicHeaders.Checked = true;
                chkBxSearchComicMatchCase.Checked = false;
                rdBtnSortDateAdded.Checked = true;
            }

            if (tbCtrlSearch.TabPages.Contains(tbPgSearchUser))
                tbCtrlSearch.TabPages.Remove(tbPgSearchUser);
        }

        private void tbCtrlAdmin_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tbCtrlAdmin.SelectedTab == tbPgUsers)
                tbCtrlSearch_ShowTabPageUser();
            else
                tbCtrlSearch_ShowTabPageComic();
        }

        private void btnChangePassword_Click(object sender, EventArgs e)
        {
            ResetPasswordUI ui_rstPass = new ResetPasswordUI(loggedAdmin.Password);
            ui_rstPass.PasswordChangedEvent += new PasswordChangedHandler(EventTrigger_ChangePassword);
            ui_rstPass.ShowDialog();
        }

        private void btnChangeUsername_Click(object sender, EventArgs e)
        {
            ResetUsernameUI ui_rstUser = new ResetUsernameUI(loggedAdmin, accountReader);
            ui_rstUser.UsernameChangedEvent += new UsernameChangedHandler(EventTrigger_UsernameChanged);
            ui_rstUser.ShowDialog();
        }
        #endregion
    }
}
