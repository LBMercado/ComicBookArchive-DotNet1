namespace ComicArchive.User_Interface
{
    partial class Admin
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.tbCtrlAdmin = new System.Windows.Forms.TabControl();
            this.tbPgUsers = new System.Windows.Forms.TabPage();
            this.lstViewUsers = new System.Windows.Forms.ListView();
            this.col_Id = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lbl_IsAdmin = new System.Windows.Forms.Label();
            this.lblUserId = new System.Windows.Forms.Label();
            this.lblSavedComicsCount = new System.Windows.Forms.Label();
            this.lblUserPassword = new System.Windows.Forms.Label();
            this.lblUsername = new System.Windows.Forms.Label();
            this.lblUserCount = new System.Windows.Forms.Label();
            this.flowLayoutPanelUsers = new System.Windows.Forms.FlowLayoutPanel();
            this.btnAddUser = new System.Windows.Forms.Button();
            this.btnModifyUser = new System.Windows.Forms.Button();
            this.btnDeleteUser = new System.Windows.Forms.Button();
            this.lblUserComicsList = new System.Windows.Forms.Label();
            this.lblUsersList = new System.Windows.Forms.Label();
            this.lstViewUserComics = new System.Windows.Forms.ListView();
            this.colSavedComicName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tbPgComics = new System.Windows.Forms.TabPage();
            this.lblViewCount = new System.Windows.Forms.Label();
            this.lblAvgRating = new System.Windows.Forms.Label();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnEditComic = new System.Windows.Forms.Button();
            this.btnDeleteComic = new System.Windows.Forms.Button();
            this.btnImportComic = new System.Windows.Forms.Button();
            this.tblLayoutPanelComicinfo = new System.Windows.Forms.TableLayoutPanel();
            this.txtBxGenre = new System.Windows.Forms.TextBox();
            this.txtBxAuthors = new System.Windows.Forms.TextBox();
            this.txtBxDateReleased = new System.Windows.Forms.TextBox();
            this.txtBxDateAdded = new System.Windows.Forms.TextBox();
            this.txtBxComicIssue = new System.Windows.Forms.TextBox();
            this.txtBxComicSubTitle = new System.Windows.Forms.TextBox();
            this.lblAuthors = new System.Windows.Forms.Label();
            this.lblGenre = new System.Windows.Forms.Label();
            this.lblComicTitle = new System.Windows.Forms.Label();
            this.lblSynopsis = new System.Windows.Forms.Label();
            this.lblComicSubTitle = new System.Windows.Forms.Label();
            this.lblDateReleased = new System.Windows.Forms.Label();
            this.lbl_Issue = new System.Windows.Forms.Label();
            this.lblDateAdded = new System.Windows.Forms.Label();
            this.richTxtBxSynopsis = new System.Windows.Forms.RichTextBox();
            this.txtBxComicTitle = new System.Windows.Forms.TextBox();
            this.lblPublisher = new System.Windows.Forms.Label();
            this.txtBxPublisher = new System.Windows.Forms.TextBox();
            this.picBxComicCover = new System.Windows.Forms.PictureBox();
            this.lblAvailableComics = new System.Windows.Forms.Label();
            this.lstViewAvailableComics = new System.Windows.Forms.ListView();
            this.colAvailableComicBookName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.grpBxAdminInfo = new System.Windows.Forms.GroupBox();
            this.btnChangeUsername = new System.Windows.Forms.Button();
            this.btnSignOut = new System.Windows.Forms.Button();
            this.btnChangePassword = new System.Windows.Forms.Button();
            this.lblAdminName = new System.Windows.Forms.Label();
            this.grpBxDate = new System.Windows.Forms.GroupBox();
            this.lblRunningTime = new System.Windows.Forms.Label();
            this.lblDateToday = new System.Windows.Forms.Label();
            this.tbCtrlSearch = new System.Windows.Forms.TabControl();
            this.tbPgSearchUser = new System.Windows.Forms.TabPage();
            this.txtBxSearchUser = new System.Windows.Forms.TextBox();
            this.grpBxSearchUserOptions = new System.Windows.Forms.GroupBox();
            this.chkBxSearchUserMatchCase = new System.Windows.Forms.CheckBox();
            this.rdBtnSearchByUsername = new System.Windows.Forms.RadioButton();
            this.rdBtnSearchById = new System.Windows.Forms.RadioButton();
            this.tbPgSearchComic = new System.Windows.Forms.TabPage();
            this.grpBxSortOptions = new System.Windows.Forms.GroupBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.rdBtnSortDateReleased = new System.Windows.Forms.RadioButton();
            this.rdBtnSortDateAdded = new System.Windows.Forms.RadioButton();
            this.txtBxSearchComic = new System.Windows.Forms.TextBox();
            this.grpBxSearchComic = new System.Windows.Forms.GroupBox();
            this.rdBtnGenre = new System.Windows.Forms.RadioButton();
            this.rdBtnPublisher = new System.Windows.Forms.RadioButton();
            this.chkBxSearchComicMatchCase = new System.Windows.Forms.CheckBox();
            this.rdBtnAuthors = new System.Windows.Forms.RadioButton();
            this.rdBtnComicHeaders = new System.Windows.Forms.RadioButton();
            this.dateTimer = new System.Windows.Forms.Timer(this.components);
            this.tbCtrlAdmin.SuspendLayout();
            this.tbPgUsers.SuspendLayout();
            this.flowLayoutPanelUsers.SuspendLayout();
            this.tbPgComics.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.tblLayoutPanelComicinfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBxComicCover)).BeginInit();
            this.grpBxAdminInfo.SuspendLayout();
            this.grpBxDate.SuspendLayout();
            this.tbCtrlSearch.SuspendLayout();
            this.tbPgSearchUser.SuspendLayout();
            this.grpBxSearchUserOptions.SuspendLayout();
            this.tbPgSearchComic.SuspendLayout();
            this.grpBxSortOptions.SuspendLayout();
            this.grpBxSearchComic.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbCtrlAdmin
            // 
            this.tbCtrlAdmin.Controls.Add(this.tbPgUsers);
            this.tbCtrlAdmin.Controls.Add(this.tbPgComics);
            this.tbCtrlAdmin.Location = new System.Drawing.Point(256, 12);
            this.tbCtrlAdmin.Name = "tbCtrlAdmin";
            this.tbCtrlAdmin.SelectedIndex = 0;
            this.tbCtrlAdmin.Size = new System.Drawing.Size(813, 780);
            this.tbCtrlAdmin.TabIndex = 0;
            this.tbCtrlAdmin.SelectedIndexChanged += new System.EventHandler(this.tbCtrlAdmin_SelectedIndexChanged);
            // 
            // tbPgUsers
            // 
            this.tbPgUsers.BackColor = System.Drawing.Color.DarkGray;
            this.tbPgUsers.Controls.Add(this.lstViewUsers);
            this.tbPgUsers.Controls.Add(this.lbl_IsAdmin);
            this.tbPgUsers.Controls.Add(this.lblUserId);
            this.tbPgUsers.Controls.Add(this.lblSavedComicsCount);
            this.tbPgUsers.Controls.Add(this.lblUserPassword);
            this.tbPgUsers.Controls.Add(this.lblUsername);
            this.tbPgUsers.Controls.Add(this.lblUserCount);
            this.tbPgUsers.Controls.Add(this.flowLayoutPanelUsers);
            this.tbPgUsers.Controls.Add(this.lblUserComicsList);
            this.tbPgUsers.Controls.Add(this.lblUsersList);
            this.tbPgUsers.Controls.Add(this.lstViewUserComics);
            this.tbPgUsers.Location = new System.Drawing.Point(4, 22);
            this.tbPgUsers.Name = "tbPgUsers";
            this.tbPgUsers.Padding = new System.Windows.Forms.Padding(3);
            this.tbPgUsers.Size = new System.Drawing.Size(805, 754);
            this.tbPgUsers.TabIndex = 0;
            this.tbPgUsers.Text = "Users";
            // 
            // lstViewUsers
            // 
            this.lstViewUsers.BackColor = System.Drawing.SystemColors.Control;
            this.lstViewUsers.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.col_Id,
            this.colName});
            this.lstViewUsers.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lstViewUsers.Location = new System.Drawing.Point(9, 68);
            this.lstViewUsers.MultiSelect = false;
            this.lstViewUsers.Name = "lstViewUsers";
            this.lstViewUsers.Size = new System.Drawing.Size(380, 492);
            this.lstViewUsers.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.lstViewUsers.TabIndex = 13;
            this.lstViewUsers.TabStop = false;
            this.lstViewUsers.UseCompatibleStateImageBehavior = false;
            this.lstViewUsers.View = System.Windows.Forms.View.Details;
            this.lstViewUsers.SelectedIndexChanged += new System.EventHandler(this.lstViewUsers_SelectedIndexChanged);
            // 
            // col_Id
            // 
            this.col_Id.Text = "ID";
            this.col_Id.Width = 179;
            // 
            // colName
            // 
            this.colName.Text = "Username";
            this.colName.Width = 179;
            // 
            // lbl_IsAdmin
            // 
            this.lbl_IsAdmin.AutoSize = true;
            this.lbl_IsAdmin.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lbl_IsAdmin.Location = new System.Drawing.Point(416, 576);
            this.lbl_IsAdmin.Name = "lbl_IsAdmin";
            this.lbl_IsAdmin.Size = new System.Drawing.Size(53, 13);
            this.lbl_IsAdmin.TabIndex = 12;
            this.lbl_IsAdmin.Text = "Is Admin: ";
            this.lbl_IsAdmin.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.lbl_IsAdmin.Visible = false;
            // 
            // lblUserId
            // 
            this.lblUserId.AutoSize = true;
            this.lblUserId.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lblUserId.Location = new System.Drawing.Point(6, 576);
            this.lblUserId.Name = "lblUserId";
            this.lblUserId.Size = new System.Drawing.Size(49, 13);
            this.lblUserId.TabIndex = 11;
            this.lblUserId.Text = "User ID: ";
            this.lblUserId.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.lblUserId.Visible = false;
            // 
            // lblSavedComicsCount
            // 
            this.lblSavedComicsCount.AutoSize = true;
            this.lblSavedComicsCount.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lblSavedComicsCount.Location = new System.Drawing.Point(416, 602);
            this.lblSavedComicsCount.Name = "lblSavedComicsCount";
            this.lblSavedComicsCount.Size = new System.Drawing.Size(121, 13);
            this.lblSavedComicsCount.TabIndex = 10;
            this.lblSavedComicsCount.Text = "Num. of Saved Comics: ";
            this.lblSavedComicsCount.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.lblSavedComicsCount.Visible = false;
            // 
            // lblUserPassword
            // 
            this.lblUserPassword.AutoSize = true;
            this.lblUserPassword.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lblUserPassword.Location = new System.Drawing.Point(6, 628);
            this.lblUserPassword.Name = "lblUserPassword";
            this.lblUserPassword.Size = new System.Drawing.Size(59, 13);
            this.lblUserPassword.TabIndex = 9;
            this.lblUserPassword.Text = "Password: ";
            this.lblUserPassword.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.lblUserPassword.Visible = false;
            // 
            // lblUsername
            // 
            this.lblUsername.AutoSize = true;
            this.lblUsername.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lblUsername.Location = new System.Drawing.Point(4, 602);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(61, 13);
            this.lblUsername.TabIndex = 8;
            this.lblUsername.Text = "Username: ";
            this.lblUsername.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.lblUsername.Visible = false;
            // 
            // lblUserCount
            // 
            this.lblUserCount.AutoSize = true;
            this.lblUserCount.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lblUserCount.Location = new System.Drawing.Point(6, 16);
            this.lblUserCount.Name = "lblUserCount";
            this.lblUserCount.Size = new System.Drawing.Size(119, 13);
            this.lblUserCount.TabIndex = 7;
            this.lblUserCount.Text = "Total Number of Users: ";
            // 
            // flowLayoutPanelUsers
            // 
            this.flowLayoutPanelUsers.Controls.Add(this.btnAddUser);
            this.flowLayoutPanelUsers.Controls.Add(this.btnModifyUser);
            this.flowLayoutPanelUsers.Controls.Add(this.btnDeleteUser);
            this.flowLayoutPanelUsers.Location = new System.Drawing.Point(77, 668);
            this.flowLayoutPanelUsers.Name = "flowLayoutPanelUsers";
            this.flowLayoutPanelUsers.Size = new System.Drawing.Size(665, 49);
            this.flowLayoutPanelUsers.TabIndex = 6;
            // 
            // btnAddUser
            // 
            this.btnAddUser.Location = new System.Drawing.Point(3, 3);
            this.btnAddUser.Name = "btnAddUser";
            this.btnAddUser.Size = new System.Drawing.Size(215, 39);
            this.btnAddUser.TabIndex = 4;
            this.btnAddUser.Text = "Add a User";
            this.btnAddUser.UseVisualStyleBackColor = true;
            this.btnAddUser.Click += new System.EventHandler(this.btnAddUser_Click);
            // 
            // btnModifyUser
            // 
            this.btnModifyUser.Enabled = false;
            this.btnModifyUser.Location = new System.Drawing.Point(224, 3);
            this.btnModifyUser.Name = "btnModifyUser";
            this.btnModifyUser.Size = new System.Drawing.Size(215, 39);
            this.btnModifyUser.TabIndex = 5;
            this.btnModifyUser.Text = "Modify Selected User";
            this.btnModifyUser.UseVisualStyleBackColor = true;
            this.btnModifyUser.Click += new System.EventHandler(this.btnModifyUser_Click);
            // 
            // btnDeleteUser
            // 
            this.btnDeleteUser.Enabled = false;
            this.btnDeleteUser.Location = new System.Drawing.Point(445, 3);
            this.btnDeleteUser.Name = "btnDeleteUser";
            this.btnDeleteUser.Size = new System.Drawing.Size(215, 39);
            this.btnDeleteUser.TabIndex = 1;
            this.btnDeleteUser.Text = "Delete Selected User";
            this.btnDeleteUser.UseVisualStyleBackColor = true;
            this.btnDeleteUser.Click += new System.EventHandler(this.btnDeleteUser_Click);
            // 
            // lblUserComicsList
            // 
            this.lblUserComicsList.AutoSize = true;
            this.lblUserComicsList.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lblUserComicsList.Location = new System.Drawing.Point(448, 35);
            this.lblUserComicsList.Name = "lblUserComicsList";
            this.lblUserComicsList.Size = new System.Drawing.Size(143, 13);
            this.lblUserComicsList.TabIndex = 3;
            this.lblUserComicsList.Text = "List of Saved Comics of User";
            this.lblUserComicsList.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.lblUserComicsList.Visible = false;
            // 
            // lblUsersList
            // 
            this.lblUsersList.AutoSize = true;
            this.lblUsersList.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lblUsersList.Location = new System.Drawing.Point(149, 35);
            this.lblUsersList.Name = "lblUsersList";
            this.lblUsersList.Size = new System.Drawing.Size(48, 13);
            this.lblUsersList.TabIndex = 1;
            this.lblUsersList.Text = "User List";
            this.lblUsersList.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lstViewUserComics
            // 
            this.lstViewUserComics.BackColor = System.Drawing.SystemColors.Control;
            this.lstViewUserComics.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colSavedComicName});
            this.lstViewUserComics.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lstViewUserComics.Location = new System.Drawing.Point(419, 68);
            this.lstViewUserComics.MultiSelect = false;
            this.lstViewUserComics.Name = "lstViewUserComics";
            this.lstViewUserComics.Size = new System.Drawing.Size(380, 492);
            this.lstViewUserComics.TabIndex = 2;
            this.lstViewUserComics.UseCompatibleStateImageBehavior = false;
            this.lstViewUserComics.View = System.Windows.Forms.View.Details;
            this.lstViewUserComics.Visible = false;
            // 
            // colSavedComicName
            // 
            this.colSavedComicName.Text = "Comic Book Name";
            this.colSavedComicName.Width = 370;
            // 
            // tbPgComics
            // 
            this.tbPgComics.BackColor = System.Drawing.Color.DarkGray;
            this.tbPgComics.Controls.Add(this.lblViewCount);
            this.tbPgComics.Controls.Add(this.lblAvgRating);
            this.tbPgComics.Controls.Add(this.flowLayoutPanel1);
            this.tbPgComics.Controls.Add(this.tblLayoutPanelComicinfo);
            this.tbPgComics.Controls.Add(this.picBxComicCover);
            this.tbPgComics.Controls.Add(this.lblAvailableComics);
            this.tbPgComics.Controls.Add(this.lstViewAvailableComics);
            this.tbPgComics.Location = new System.Drawing.Point(4, 22);
            this.tbPgComics.Name = "tbPgComics";
            this.tbPgComics.Padding = new System.Windows.Forms.Padding(3);
            this.tbPgComics.Size = new System.Drawing.Size(805, 754);
            this.tbPgComics.TabIndex = 1;
            this.tbPgComics.Text = "Comics";
            // 
            // lblViewCount
            // 
            this.lblViewCount.AutoSize = true;
            this.lblViewCount.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lblViewCount.Location = new System.Drawing.Point(332, 193);
            this.lblViewCount.Name = "lblViewCount";
            this.lblViewCount.Size = new System.Drawing.Size(63, 13);
            this.lblViewCount.TabIndex = 32;
            this.lblViewCount.Text = "# of Views: ";
            this.lblViewCount.Visible = false;
            // 
            // lblAvgRating
            // 
            this.lblAvgRating.AutoSize = true;
            this.lblAvgRating.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lblAvgRating.Location = new System.Drawing.Point(332, 159);
            this.lblAvgRating.Name = "lblAvgRating";
            this.lblAvgRating.Size = new System.Drawing.Size(87, 13);
            this.lblAvgRating.TabIndex = 31;
            this.lblAvgRating.Text = "Average Rating: ";
            this.lblAvgRating.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.lblAvgRating.Visible = false;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.btnEditComic);
            this.flowLayoutPanel1.Controls.Add(this.btnDeleteComic);
            this.flowLayoutPanel1.Controls.Add(this.btnImportComic);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(60, 604);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(205, 137);
            this.flowLayoutPanel1.TabIndex = 30;
            // 
            // btnEditComic
            // 
            this.btnEditComic.Enabled = false;
            this.btnEditComic.Location = new System.Drawing.Point(3, 3);
            this.btnEditComic.Name = "btnEditComic";
            this.btnEditComic.Size = new System.Drawing.Size(197, 37);
            this.btnEditComic.TabIndex = 31;
            this.btnEditComic.Text = "Edit Comic Book Details";
            this.btnEditComic.UseVisualStyleBackColor = true;
            this.btnEditComic.Click += new System.EventHandler(this.btnEditComic_Click);
            // 
            // btnDeleteComic
            // 
            this.btnDeleteComic.Enabled = false;
            this.btnDeleteComic.Location = new System.Drawing.Point(3, 46);
            this.btnDeleteComic.Name = "btnDeleteComic";
            this.btnDeleteComic.Size = new System.Drawing.Size(197, 37);
            this.btnDeleteComic.TabIndex = 30;
            this.btnDeleteComic.Text = "Delete Comic Book";
            this.btnDeleteComic.UseVisualStyleBackColor = true;
            this.btnDeleteComic.Click += new System.EventHandler(this.btnDeleteComic_Click);
            // 
            // btnImportComic
            // 
            this.btnImportComic.Location = new System.Drawing.Point(3, 89);
            this.btnImportComic.Name = "btnImportComic";
            this.btnImportComic.Size = new System.Drawing.Size(197, 37);
            this.btnImportComic.TabIndex = 29;
            this.btnImportComic.Text = "Import a Comic Book (.cbz/.cbr)";
            this.btnImportComic.UseVisualStyleBackColor = true;
            this.btnImportComic.Click += new System.EventHandler(this.btnImportComic_Click);
            // 
            // tblLayoutPanelComicinfo
            // 
            this.tblLayoutPanelComicinfo.ColumnCount = 2;
            this.tblLayoutPanelComicinfo.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tblLayoutPanelComicinfo.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tblLayoutPanelComicinfo.Controls.Add(this.txtBxGenre, 1, 8);
            this.tblLayoutPanelComicinfo.Controls.Add(this.txtBxAuthors, 1, 7);
            this.tblLayoutPanelComicinfo.Controls.Add(this.txtBxDateReleased, 1, 4);
            this.tblLayoutPanelComicinfo.Controls.Add(this.txtBxDateAdded, 1, 3);
            this.tblLayoutPanelComicinfo.Controls.Add(this.txtBxComicIssue, 1, 2);
            this.tblLayoutPanelComicinfo.Controls.Add(this.txtBxComicSubTitle, 1, 1);
            this.tblLayoutPanelComicinfo.Controls.Add(this.lblAuthors, 0, 7);
            this.tblLayoutPanelComicinfo.Controls.Add(this.lblGenre, 0, 8);
            this.tblLayoutPanelComicinfo.Controls.Add(this.lblComicTitle, 0, 0);
            this.tblLayoutPanelComicinfo.Controls.Add(this.lblSynopsis, 0, 5);
            this.tblLayoutPanelComicinfo.Controls.Add(this.lblComicSubTitle, 0, 1);
            this.tblLayoutPanelComicinfo.Controls.Add(this.lblDateReleased, 0, 4);
            this.tblLayoutPanelComicinfo.Controls.Add(this.lbl_Issue, 0, 2);
            this.tblLayoutPanelComicinfo.Controls.Add(this.lblDateAdded, 0, 3);
            this.tblLayoutPanelComicinfo.Controls.Add(this.richTxtBxSynopsis, 0, 6);
            this.tblLayoutPanelComicinfo.Controls.Add(this.txtBxComicTitle, 1, 0);
            this.tblLayoutPanelComicinfo.Controls.Add(this.lblPublisher, 0, 9);
            this.tblLayoutPanelComicinfo.Controls.Add(this.txtBxPublisher, 1, 9);
            this.tblLayoutPanelComicinfo.Location = new System.Drawing.Point(335, 229);
            this.tblLayoutPanelComicinfo.Name = "tblLayoutPanelComicinfo";
            this.tblLayoutPanelComicinfo.RowCount = 10;
            this.tblLayoutPanelComicinfo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.090909F));
            this.tblLayoutPanelComicinfo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.090909F));
            this.tblLayoutPanelComicinfo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.090909F));
            this.tblLayoutPanelComicinfo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.090909F));
            this.tblLayoutPanelComicinfo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.090909F));
            this.tblLayoutPanelComicinfo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 4.545455F));
            this.tblLayoutPanelComicinfo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 22.72727F));
            this.tblLayoutPanelComicinfo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.090909F));
            this.tblLayoutPanelComicinfo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.090909F));
            this.tblLayoutPanelComicinfo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.090909F));
            this.tblLayoutPanelComicinfo.Size = new System.Drawing.Size(464, 519);
            this.tblLayoutPanelComicinfo.TabIndex = 28;
            // 
            // txtBxGenre
            // 
            this.txtBxGenre.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtBxGenre.Location = new System.Drawing.Point(129, 425);
            this.txtBxGenre.Name = "txtBxGenre";
            this.txtBxGenre.Size = new System.Drawing.Size(332, 20);
            this.txtBxGenre.TabIndex = 34;
            // 
            // txtBxAuthors
            // 
            this.txtBxAuthors.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtBxAuthors.Location = new System.Drawing.Point(129, 378);
            this.txtBxAuthors.Name = "txtBxAuthors";
            this.txtBxAuthors.Size = new System.Drawing.Size(332, 20);
            this.txtBxAuthors.TabIndex = 33;
            // 
            // txtBxDateReleased
            // 
            this.txtBxDateReleased.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtBxDateReleased.Location = new System.Drawing.Point(129, 191);
            this.txtBxDateReleased.Name = "txtBxDateReleased";
            this.txtBxDateReleased.Size = new System.Drawing.Size(332, 20);
            this.txtBxDateReleased.TabIndex = 32;
            // 
            // txtBxDateAdded
            // 
            this.txtBxDateAdded.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtBxDateAdded.Location = new System.Drawing.Point(129, 144);
            this.txtBxDateAdded.Name = "txtBxDateAdded";
            this.txtBxDateAdded.Size = new System.Drawing.Size(332, 20);
            this.txtBxDateAdded.TabIndex = 31;
            // 
            // txtBxComicIssue
            // 
            this.txtBxComicIssue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtBxComicIssue.Location = new System.Drawing.Point(129, 97);
            this.txtBxComicIssue.Name = "txtBxComicIssue";
            this.txtBxComicIssue.Size = new System.Drawing.Size(332, 20);
            this.txtBxComicIssue.TabIndex = 30;
            // 
            // txtBxComicSubTitle
            // 
            this.txtBxComicSubTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtBxComicSubTitle.Location = new System.Drawing.Point(129, 50);
            this.txtBxComicSubTitle.Name = "txtBxComicSubTitle";
            this.txtBxComicSubTitle.Size = new System.Drawing.Size(332, 20);
            this.txtBxComicSubTitle.TabIndex = 29;
            // 
            // lblAuthors
            // 
            this.lblAuthors.AutoSize = true;
            this.lblAuthors.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblAuthors.Location = new System.Drawing.Point(3, 375);
            this.lblAuthors.Name = "lblAuthors";
            this.lblAuthors.Size = new System.Drawing.Size(120, 47);
            this.lblAuthors.TabIndex = 27;
            this.lblAuthors.Text = "Author/s: \r\n(Separate with commas)";
            // 
            // lblGenre
            // 
            this.lblGenre.AutoSize = true;
            this.lblGenre.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblGenre.Location = new System.Drawing.Point(3, 422);
            this.lblGenre.Name = "lblGenre";
            this.lblGenre.Size = new System.Drawing.Size(120, 47);
            this.lblGenre.TabIndex = 26;
            this.lblGenre.Text = "Genre: ";
            // 
            // lblComicTitle
            // 
            this.lblComicTitle.AutoSize = true;
            this.lblComicTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblComicTitle.Location = new System.Drawing.Point(3, 0);
            this.lblComicTitle.Name = "lblComicTitle";
            this.lblComicTitle.Size = new System.Drawing.Size(120, 47);
            this.lblComicTitle.TabIndex = 20;
            this.lblComicTitle.Text = "Comic Title: ";
            // 
            // lblSynopsis
            // 
            this.lblSynopsis.AutoSize = true;
            this.tblLayoutPanelComicinfo.SetColumnSpan(this.lblSynopsis, 2);
            this.lblSynopsis.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblSynopsis.Location = new System.Drawing.Point(3, 235);
            this.lblSynopsis.Name = "lblSynopsis";
            this.lblSynopsis.Size = new System.Drawing.Size(458, 23);
            this.lblSynopsis.TabIndex = 24;
            this.lblSynopsis.Text = "Synopsis: ";
            // 
            // lblComicSubTitle
            // 
            this.lblComicSubTitle.AutoSize = true;
            this.lblComicSubTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblComicSubTitle.Location = new System.Drawing.Point(3, 47);
            this.lblComicSubTitle.Name = "lblComicSubTitle";
            this.lblComicSubTitle.Size = new System.Drawing.Size(120, 47);
            this.lblComicSubTitle.TabIndex = 19;
            this.lblComicSubTitle.Text = "Comic Subtitle:";
            // 
            // lblDateReleased
            // 
            this.lblDateReleased.AutoSize = true;
            this.lblDateReleased.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDateReleased.Location = new System.Drawing.Point(3, 188);
            this.lblDateReleased.Name = "lblDateReleased";
            this.lblDateReleased.Size = new System.Drawing.Size(120, 47);
            this.lblDateReleased.TabIndex = 23;
            this.lblDateReleased.Text = "Date Released: ";
            // 
            // lbl_Issue
            // 
            this.lbl_Issue.AutoSize = true;
            this.lbl_Issue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_Issue.Location = new System.Drawing.Point(3, 94);
            this.lbl_Issue.Name = "lbl_Issue";
            this.lbl_Issue.Size = new System.Drawing.Size(120, 47);
            this.lbl_Issue.TabIndex = 21;
            this.lbl_Issue.Text = "Issue: ";
            // 
            // lblDateAdded
            // 
            this.lblDateAdded.AutoSize = true;
            this.lblDateAdded.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDateAdded.Location = new System.Drawing.Point(3, 141);
            this.lblDateAdded.Name = "lblDateAdded";
            this.lblDateAdded.Size = new System.Drawing.Size(120, 47);
            this.lblDateAdded.TabIndex = 22;
            this.lblDateAdded.Text = "Date Added: ";
            // 
            // richTxtBxSynopsis
            // 
            this.tblLayoutPanelComicinfo.SetColumnSpan(this.richTxtBxSynopsis, 2);
            this.richTxtBxSynopsis.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTxtBxSynopsis.Location = new System.Drawing.Point(3, 261);
            this.richTxtBxSynopsis.Name = "richTxtBxSynopsis";
            this.richTxtBxSynopsis.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.richTxtBxSynopsis.Size = new System.Drawing.Size(458, 111);
            this.richTxtBxSynopsis.TabIndex = 25;
            this.richTxtBxSynopsis.Text = "";
            // 
            // txtBxComicTitle
            // 
            this.txtBxComicTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtBxComicTitle.Location = new System.Drawing.Point(129, 3);
            this.txtBxComicTitle.Name = "txtBxComicTitle";
            this.txtBxComicTitle.Size = new System.Drawing.Size(332, 20);
            this.txtBxComicTitle.TabIndex = 28;
            // 
            // lblPublisher
            // 
            this.lblPublisher.AutoSize = true;
            this.lblPublisher.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblPublisher.Location = new System.Drawing.Point(3, 469);
            this.lblPublisher.Name = "lblPublisher";
            this.lblPublisher.Size = new System.Drawing.Size(120, 50);
            this.lblPublisher.TabIndex = 35;
            this.lblPublisher.Text = "Publisher: ";
            // 
            // txtBxPublisher
            // 
            this.txtBxPublisher.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtBxPublisher.Location = new System.Drawing.Point(129, 472);
            this.txtBxPublisher.Name = "txtBxPublisher";
            this.txtBxPublisher.Size = new System.Drawing.Size(332, 20);
            this.txtBxPublisher.TabIndex = 36;
            // 
            // picBxComicCover
            // 
            this.picBxComicCover.BackColor = System.Drawing.Color.WhiteSmoke;
            this.picBxComicCover.Location = new System.Drawing.Point(485, 14);
            this.picBxComicCover.Name = "picBxComicCover";
            this.picBxComicCover.Size = new System.Drawing.Size(200, 200);
            this.picBxComicCover.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picBxComicCover.TabIndex = 27;
            this.picBxComicCover.TabStop = false;
            // 
            // lblAvailableComics
            // 
            this.lblAvailableComics.AutoSize = true;
            this.lblAvailableComics.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lblAvailableComics.Location = new System.Drawing.Point(107, 28);
            this.lblAvailableComics.Name = "lblAvailableComics";
            this.lblAvailableComics.Size = new System.Drawing.Size(118, 13);
            this.lblAvailableComics.TabIndex = 5;
            this.lblAvailableComics.Text = "List of Available Comics";
            this.lblAvailableComics.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.lblAvailableComics.Visible = false;
            // 
            // lstViewAvailableComics
            // 
            this.lstViewAvailableComics.BackColor = System.Drawing.SystemColors.Control;
            this.lstViewAvailableComics.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colAvailableComicBookName});
            this.lstViewAvailableComics.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lstViewAvailableComics.Location = new System.Drawing.Point(9, 57);
            this.lstViewAvailableComics.MultiSelect = false;
            this.lstViewAvailableComics.Name = "lstViewAvailableComics";
            this.lstViewAvailableComics.Size = new System.Drawing.Size(320, 539);
            this.lstViewAvailableComics.TabIndex = 4;
            this.lstViewAvailableComics.UseCompatibleStateImageBehavior = false;
            this.lstViewAvailableComics.View = System.Windows.Forms.View.Details;
            this.lstViewAvailableComics.SelectedIndexChanged += new System.EventHandler(this.lstViewAvailableComics_SelectedIndexChanged);
            // 
            // colAvailableComicBookName
            // 
            this.colAvailableComicBookName.Text = "Comic Book Name";
            this.colAvailableComicBookName.Width = 320;
            // 
            // grpBxAdminInfo
            // 
            this.grpBxAdminInfo.Controls.Add(this.btnChangeUsername);
            this.grpBxAdminInfo.Controls.Add(this.btnSignOut);
            this.grpBxAdminInfo.Controls.Add(this.btnChangePassword);
            this.grpBxAdminInfo.Controls.Add(this.lblAdminName);
            this.grpBxAdminInfo.Location = new System.Drawing.Point(12, 12);
            this.grpBxAdminInfo.Name = "grpBxAdminInfo";
            this.grpBxAdminInfo.Size = new System.Drawing.Size(200, 137);
            this.grpBxAdminInfo.TabIndex = 0;
            this.grpBxAdminInfo.TabStop = false;
            this.grpBxAdminInfo.Text = "Admin";
            // 
            // btnChangeUsername
            // 
            this.btnChangeUsername.Location = new System.Drawing.Point(0, 50);
            this.btnChangeUsername.Name = "btnChangeUsername";
            this.btnChangeUsername.Size = new System.Drawing.Size(200, 23);
            this.btnChangeUsername.TabIndex = 4;
            this.btnChangeUsername.Text = "Change Username";
            this.btnChangeUsername.UseVisualStyleBackColor = true;
            this.btnChangeUsername.Click += new System.EventHandler(this.btnChangeUsername_Click);
            // 
            // btnSignOut
            // 
            this.btnSignOut.Location = new System.Drawing.Point(0, 108);
            this.btnSignOut.Name = "btnSignOut";
            this.btnSignOut.Size = new System.Drawing.Size(200, 23);
            this.btnSignOut.TabIndex = 3;
            this.btnSignOut.Text = "Sign Out";
            this.btnSignOut.UseVisualStyleBackColor = true;
            this.btnSignOut.Click += new System.EventHandler(this.btnSignOut_Click);
            // 
            // btnChangePassword
            // 
            this.btnChangePassword.Location = new System.Drawing.Point(0, 79);
            this.btnChangePassword.Name = "btnChangePassword";
            this.btnChangePassword.Size = new System.Drawing.Size(200, 23);
            this.btnChangePassword.TabIndex = 2;
            this.btnChangePassword.Text = "Change Password";
            this.btnChangePassword.UseVisualStyleBackColor = true;
            this.btnChangePassword.Click += new System.EventHandler(this.btnChangePassword_Click);
            // 
            // lblAdminName
            // 
            this.lblAdminName.AutoSize = true;
            this.lblAdminName.Location = new System.Drawing.Point(58, 27);
            this.lblAdminName.Name = "lblAdminName";
            this.lblAdminName.Size = new System.Drawing.Size(79, 13);
            this.lblAdminName.TabIndex = 1;
            this.lblAdminName.Text = "ADMIN_NAME";
            this.lblAdminName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // grpBxDate
            // 
            this.grpBxDate.Controls.Add(this.lblRunningTime);
            this.grpBxDate.Controls.Add(this.lblDateToday);
            this.grpBxDate.Location = new System.Drawing.Point(12, 155);
            this.grpBxDate.Name = "grpBxDate";
            this.grpBxDate.Size = new System.Drawing.Size(200, 85);
            this.grpBxDate.TabIndex = 2;
            this.grpBxDate.TabStop = false;
            this.grpBxDate.Text = "Good Day Admin!";
            // 
            // lblRunningTime
            // 
            this.lblRunningTime.AutoSize = true;
            this.lblRunningTime.Location = new System.Drawing.Point(6, 55);
            this.lblRunningTime.Name = "lblRunningTime";
            this.lblRunningTime.Size = new System.Drawing.Size(92, 13);
            this.lblRunningTime.TabIndex = 1;
            this.lblRunningTime.Text = "TIME_CURRENT";
            // 
            // lblDateToday
            // 
            this.lblDateToday.AutoSize = true;
            this.lblDateToday.Location = new System.Drawing.Point(6, 28);
            this.lblDateToday.Name = "lblDateToday";
            this.lblDateToday.Size = new System.Drawing.Size(79, 13);
            this.lblDateToday.TabIndex = 0;
            this.lblDateToday.Text = "DATE_TODAY";
            // 
            // tbCtrlSearch
            // 
            this.tbCtrlSearch.Controls.Add(this.tbPgSearchUser);
            this.tbCtrlSearch.Controls.Add(this.tbPgSearchComic);
            this.tbCtrlSearch.Location = new System.Drawing.Point(12, 263);
            this.tbCtrlSearch.Name = "tbCtrlSearch";
            this.tbCtrlSearch.SelectedIndex = 0;
            this.tbCtrlSearch.Size = new System.Drawing.Size(238, 525);
            this.tbCtrlSearch.TabIndex = 13;
            // 
            // tbPgSearchUser
            // 
            this.tbPgSearchUser.BackColor = System.Drawing.Color.LightGray;
            this.tbPgSearchUser.Controls.Add(this.txtBxSearchUser);
            this.tbPgSearchUser.Controls.Add(this.grpBxSearchUserOptions);
            this.tbPgSearchUser.Location = new System.Drawing.Point(4, 22);
            this.tbPgSearchUser.Name = "tbPgSearchUser";
            this.tbPgSearchUser.Padding = new System.Windows.Forms.Padding(3);
            this.tbPgSearchUser.Size = new System.Drawing.Size(230, 499);
            this.tbPgSearchUser.TabIndex = 0;
            this.tbPgSearchUser.Text = "Users";
            // 
            // txtBxSearchUser
            // 
            this.txtBxSearchUser.Location = new System.Drawing.Point(6, 117);
            this.txtBxSearchUser.Name = "txtBxSearchUser";
            this.txtBxSearchUser.Size = new System.Drawing.Size(218, 20);
            this.txtBxSearchUser.TabIndex = 1;
            this.txtBxSearchUser.TextChanged += new System.EventHandler(this.txtBxSearchUser_TextChanged);
            // 
            // grpBxSearchUserOptions
            // 
            this.grpBxSearchUserOptions.Controls.Add(this.chkBxSearchUserMatchCase);
            this.grpBxSearchUserOptions.Controls.Add(this.rdBtnSearchByUsername);
            this.grpBxSearchUserOptions.Controls.Add(this.rdBtnSearchById);
            this.grpBxSearchUserOptions.Location = new System.Drawing.Point(6, 6);
            this.grpBxSearchUserOptions.Name = "grpBxSearchUserOptions";
            this.grpBxSearchUserOptions.Size = new System.Drawing.Size(218, 92);
            this.grpBxSearchUserOptions.TabIndex = 0;
            this.grpBxSearchUserOptions.TabStop = false;
            this.grpBxSearchUserOptions.Text = "Search Options";
            // 
            // chkBxSearchUserMatchCase
            // 
            this.chkBxSearchUserMatchCase.AutoSize = true;
            this.chkBxSearchUserMatchCase.Location = new System.Drawing.Point(6, 65);
            this.chkBxSearchUserMatchCase.Name = "chkBxSearchUserMatchCase";
            this.chkBxSearchUserMatchCase.Size = new System.Drawing.Size(83, 17);
            this.chkBxSearchUserMatchCase.TabIndex = 2;
            this.chkBxSearchUserMatchCase.Text = "Match Case";
            this.chkBxSearchUserMatchCase.UseVisualStyleBackColor = true;
            this.chkBxSearchUserMatchCase.CheckedChanged += new System.EventHandler(this.txtBxSearchUser_TextChanged);
            // 
            // rdBtnSearchByUsername
            // 
            this.rdBtnSearchByUsername.AutoSize = true;
            this.rdBtnSearchByUsername.Location = new System.Drawing.Point(6, 42);
            this.rdBtnSearchByUsername.Name = "rdBtnSearchByUsername";
            this.rdBtnSearchByUsername.Size = new System.Drawing.Size(126, 17);
            this.rdBtnSearchByUsername.TabIndex = 1;
            this.rdBtnSearchByUsername.TabStop = true;
            this.rdBtnSearchByUsername.Text = "Filter using Username";
            this.rdBtnSearchByUsername.UseVisualStyleBackColor = true;
            this.rdBtnSearchByUsername.CheckedChanged += new System.EventHandler(this.rdBtnSearchOption_CheckedChanged);
            // 
            // rdBtnSearchById
            // 
            this.rdBtnSearchById.AutoSize = true;
            this.rdBtnSearchById.Location = new System.Drawing.Point(6, 19);
            this.rdBtnSearchById.Name = "rdBtnSearchById";
            this.rdBtnSearchById.Size = new System.Drawing.Size(89, 17);
            this.rdBtnSearchById.TabIndex = 0;
            this.rdBtnSearchById.TabStop = true;
            this.rdBtnSearchById.Text = "Filter using ID";
            this.rdBtnSearchById.UseVisualStyleBackColor = true;
            this.rdBtnSearchById.CheckedChanged += new System.EventHandler(this.rdBtnSearchOption_CheckedChanged);
            // 
            // tbPgSearchComic
            // 
            this.tbPgSearchComic.BackColor = System.Drawing.Color.LightGray;
            this.tbPgSearchComic.Controls.Add(this.grpBxSortOptions);
            this.tbPgSearchComic.Controls.Add(this.txtBxSearchComic);
            this.tbPgSearchComic.Controls.Add(this.grpBxSearchComic);
            this.tbPgSearchComic.Location = new System.Drawing.Point(4, 22);
            this.tbPgSearchComic.Name = "tbPgSearchComic";
            this.tbPgSearchComic.Padding = new System.Windows.Forms.Padding(3);
            this.tbPgSearchComic.Size = new System.Drawing.Size(230, 499);
            this.tbPgSearchComic.TabIndex = 1;
            this.tbPgSearchComic.Text = "Comics";
            // 
            // grpBxSortOptions
            // 
            this.grpBxSortOptions.Controls.Add(this.checkBox2);
            this.grpBxSortOptions.Controls.Add(this.rdBtnSortDateReleased);
            this.grpBxSortOptions.Controls.Add(this.rdBtnSortDateAdded);
            this.grpBxSortOptions.Location = new System.Drawing.Point(6, 172);
            this.grpBxSortOptions.Name = "grpBxSortOptions";
            this.grpBxSortOptions.Size = new System.Drawing.Size(218, 66);
            this.grpBxSortOptions.TabIndex = 6;
            this.grpBxSortOptions.TabStop = false;
            this.grpBxSortOptions.Text = "Sort Options";
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(5, 177);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(83, 17);
            this.checkBox2.TabIndex = 2;
            this.checkBox2.Text = "Match Case";
            this.checkBox2.UseVisualStyleBackColor = true;
            // 
            // rdBtnSortDateReleased
            // 
            this.rdBtnSortDateReleased.AutoSize = true;
            this.rdBtnSortDateReleased.Location = new System.Drawing.Point(8, 42);
            this.rdBtnSortDateReleased.Name = "rdBtnSortDateReleased";
            this.rdBtnSortDateReleased.Size = new System.Drawing.Size(133, 17);
            this.rdBtnSortDateReleased.TabIndex = 3;
            this.rdBtnSortDateReleased.TabStop = true;
            this.rdBtnSortDateReleased.Text = "Sort By Date Released";
            this.rdBtnSortDateReleased.UseVisualStyleBackColor = true;
            // 
            // rdBtnSortDateAdded
            // 
            this.rdBtnSortDateAdded.AutoSize = true;
            this.rdBtnSortDateAdded.Location = new System.Drawing.Point(8, 17);
            this.rdBtnSortDateAdded.Name = "rdBtnSortDateAdded";
            this.rdBtnSortDateAdded.Size = new System.Drawing.Size(119, 17);
            this.rdBtnSortDateAdded.TabIndex = 0;
            this.rdBtnSortDateAdded.TabStop = true;
            this.rdBtnSortDateAdded.Text = "Sort By Date Added";
            this.rdBtnSortDateAdded.UseVisualStyleBackColor = true;
            this.rdBtnSortDateAdded.CheckedChanged += new System.EventHandler(this.SearchComic_CriteriaSearchEvent);
            // 
            // txtBxSearchComic
            // 
            this.txtBxSearchComic.Location = new System.Drawing.Point(5, 258);
            this.txtBxSearchComic.Name = "txtBxSearchComic";
            this.txtBxSearchComic.Size = new System.Drawing.Size(218, 20);
            this.txtBxSearchComic.TabIndex = 3;
            this.txtBxSearchComic.TextChanged += new System.EventHandler(this.SearchComic_CriteriaSearchEvent);
            // 
            // grpBxSearchComic
            // 
            this.grpBxSearchComic.Controls.Add(this.rdBtnGenre);
            this.grpBxSearchComic.Controls.Add(this.rdBtnPublisher);
            this.grpBxSearchComic.Controls.Add(this.chkBxSearchComicMatchCase);
            this.grpBxSearchComic.Controls.Add(this.rdBtnAuthors);
            this.grpBxSearchComic.Controls.Add(this.rdBtnComicHeaders);
            this.grpBxSearchComic.Location = new System.Drawing.Point(6, 6);
            this.grpBxSearchComic.Name = "grpBxSearchComic";
            this.grpBxSearchComic.Size = new System.Drawing.Size(218, 160);
            this.grpBxSearchComic.TabIndex = 2;
            this.grpBxSearchComic.TabStop = false;
            this.grpBxSearchComic.Text = "Search Options";
            // 
            // rdBtnGenre
            // 
            this.rdBtnGenre.AutoSize = true;
            this.rdBtnGenre.Location = new System.Drawing.Point(6, 69);
            this.rdBtnGenre.Name = "rdBtnGenre";
            this.rdBtnGenre.Size = new System.Drawing.Size(107, 17);
            this.rdBtnGenre.TabIndex = 5;
            this.rdBtnGenre.TabStop = true;
            this.rdBtnGenre.Text = "Filter using Genre";
            this.rdBtnGenre.UseVisualStyleBackColor = true;
            this.rdBtnGenre.CheckedChanged += new System.EventHandler(this.SearchComic_CriteriaSearchEvent);
            // 
            // rdBtnPublisher
            // 
            this.rdBtnPublisher.AutoSize = true;
            this.rdBtnPublisher.Location = new System.Drawing.Point(6, 96);
            this.rdBtnPublisher.Name = "rdBtnPublisher";
            this.rdBtnPublisher.Size = new System.Drawing.Size(121, 17);
            this.rdBtnPublisher.TabIndex = 4;
            this.rdBtnPublisher.TabStop = true;
            this.rdBtnPublisher.Text = "Filter using Publisher";
            this.rdBtnPublisher.UseVisualStyleBackColor = true;
            this.rdBtnPublisher.CheckedChanged += new System.EventHandler(this.SearchComic_CriteriaSearchEvent);
            // 
            // chkBxSearchComicMatchCase
            // 
            this.chkBxSearchComicMatchCase.AutoSize = true;
            this.chkBxSearchComicMatchCase.Location = new System.Drawing.Point(6, 129);
            this.chkBxSearchComicMatchCase.Name = "chkBxSearchComicMatchCase";
            this.chkBxSearchComicMatchCase.Size = new System.Drawing.Size(83, 17);
            this.chkBxSearchComicMatchCase.TabIndex = 2;
            this.chkBxSearchComicMatchCase.Text = "Match Case";
            this.chkBxSearchComicMatchCase.UseVisualStyleBackColor = true;
            this.chkBxSearchComicMatchCase.CheckedChanged += new System.EventHandler(this.SearchComic_CriteriaSearchEvent);
            // 
            // rdBtnAuthors
            // 
            this.rdBtnAuthors.AutoSize = true;
            this.rdBtnAuthors.Location = new System.Drawing.Point(6, 43);
            this.rdBtnAuthors.Name = "rdBtnAuthors";
            this.rdBtnAuthors.Size = new System.Drawing.Size(109, 17);
            this.rdBtnAuthors.TabIndex = 1;
            this.rdBtnAuthors.TabStop = true;
            this.rdBtnAuthors.Text = "Filter using Author";
            this.rdBtnAuthors.UseVisualStyleBackColor = true;
            this.rdBtnAuthors.CheckedChanged += new System.EventHandler(this.SearchComic_CriteriaSearchEvent);
            // 
            // rdBtnComicHeaders
            // 
            this.rdBtnComicHeaders.AutoSize = true;
            this.rdBtnComicHeaders.Location = new System.Drawing.Point(6, 19);
            this.rdBtnComicHeaders.Name = "rdBtnComicHeaders";
            this.rdBtnComicHeaders.Size = new System.Drawing.Size(168, 17);
            this.rdBtnComicHeaders.TabIndex = 0;
            this.rdBtnComicHeaders.TabStop = true;
            this.rdBtnComicHeaders.Text = "Filter using Title/Subtitle/Issue";
            this.rdBtnComicHeaders.UseVisualStyleBackColor = true;
            this.rdBtnComicHeaders.CheckedChanged += new System.EventHandler(this.SearchComic_CriteriaSearchEvent);
            // 
            // dateTimer
            // 
            this.dateTimer.Enabled = true;
            this.dateTimer.Tick += new System.EventHandler(this.dateTimer_Tick);
            // 
            // Admin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1081, 804);
            this.Controls.Add(this.tbCtrlSearch);
            this.Controls.Add(this.grpBxDate);
            this.Controls.Add(this.grpBxAdminInfo);
            this.Controls.Add(this.tbCtrlAdmin);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(984, 691);
            this.Name = "Admin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Admin";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Admin_FormClosed);
            this.tbCtrlAdmin.ResumeLayout(false);
            this.tbPgUsers.ResumeLayout(false);
            this.tbPgUsers.PerformLayout();
            this.flowLayoutPanelUsers.ResumeLayout(false);
            this.tbPgComics.ResumeLayout(false);
            this.tbPgComics.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.tblLayoutPanelComicinfo.ResumeLayout(false);
            this.tblLayoutPanelComicinfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBxComicCover)).EndInit();
            this.grpBxAdminInfo.ResumeLayout(false);
            this.grpBxAdminInfo.PerformLayout();
            this.grpBxDate.ResumeLayout(false);
            this.grpBxDate.PerformLayout();
            this.tbCtrlSearch.ResumeLayout(false);
            this.tbPgSearchUser.ResumeLayout(false);
            this.tbPgSearchUser.PerformLayout();
            this.grpBxSearchUserOptions.ResumeLayout(false);
            this.grpBxSearchUserOptions.PerformLayout();
            this.tbPgSearchComic.ResumeLayout(false);
            this.tbPgSearchComic.PerformLayout();
            this.grpBxSortOptions.ResumeLayout(false);
            this.grpBxSortOptions.PerformLayout();
            this.grpBxSearchComic.ResumeLayout(false);
            this.grpBxSearchComic.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tbCtrlAdmin;
        private System.Windows.Forms.TabPage tbPgUsers;
        private System.Windows.Forms.TabPage tbPgComics;
        private System.Windows.Forms.GroupBox grpBxAdminInfo;
        private System.Windows.Forms.Button btnChangePassword;
        private System.Windows.Forms.Label lblAdminName;
        private System.Windows.Forms.Label lblUserComicsList;
        private System.Windows.Forms.Label lblUsersList;
        private System.Windows.Forms.ListView lstViewUserComics;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelUsers;
        private System.Windows.Forms.Button btnAddUser;
        private System.Windows.Forms.Button btnModifyUser;
        private System.Windows.Forms.Button btnDeleteUser;
        private System.Windows.Forms.GroupBox grpBxDate;
        private System.Windows.Forms.Label lblRunningTime;
        private System.Windows.Forms.Label lblDateToday;
        private System.Windows.Forms.Label lblUserCount;
        private System.Windows.Forms.Label lbl_IsAdmin;
        private System.Windows.Forms.Label lblUserId;
        private System.Windows.Forms.Label lblSavedComicsCount;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.TabControl tbCtrlSearch;
        private System.Windows.Forms.TabPage tbPgSearchUser;
        private System.Windows.Forms.TextBox txtBxSearchUser;
        private System.Windows.Forms.GroupBox grpBxSearchUserOptions;
        private System.Windows.Forms.RadioButton rdBtnSearchByUsername;
        private System.Windows.Forms.RadioButton rdBtnSearchById;
        private System.Windows.Forms.TabPage tbPgSearchComic;
        private System.Windows.Forms.CheckBox chkBxSearchUserMatchCase;
        private System.Windows.Forms.Button btnSignOut;
        private System.Windows.Forms.Timer dateTimer;
        private System.Windows.Forms.ListView lstViewUsers;
        private System.Windows.Forms.ColumnHeader col_Id;
        private System.Windows.Forms.ColumnHeader colName;
        private System.Windows.Forms.Label lblUserPassword;
        private System.Windows.Forms.Button btnChangeUsername;
        private System.Windows.Forms.Label lblAvailableComics;
        private System.Windows.Forms.ListView lstViewAvailableComics;
        private System.Windows.Forms.TextBox txtBxSearchComic;
        private System.Windows.Forms.GroupBox grpBxSearchComic;
        private System.Windows.Forms.CheckBox chkBxSearchComicMatchCase;
        private System.Windows.Forms.RadioButton rdBtnAuthors;
        private System.Windows.Forms.RadioButton rdBtnComicHeaders;
        private System.Windows.Forms.TableLayoutPanel tblLayoutPanelComicinfo;
        private System.Windows.Forms.Label lblAuthors;
        private System.Windows.Forms.Label lblComicTitle;
        private System.Windows.Forms.Label lblSynopsis;
        private System.Windows.Forms.Label lblComicSubTitle;
        private System.Windows.Forms.Label lblDateReleased;
        private System.Windows.Forms.Label lbl_Issue;
        private System.Windows.Forms.Label lblDateAdded;
        private System.Windows.Forms.RichTextBox richTxtBxSynopsis;
        private System.Windows.Forms.PictureBox picBxComicCover;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button btnEditComic;
        private System.Windows.Forms.Button btnDeleteComic;
        private System.Windows.Forms.Button btnImportComic;
        private System.Windows.Forms.TextBox txtBxGenre;
        private System.Windows.Forms.TextBox txtBxAuthors;
        private System.Windows.Forms.TextBox txtBxDateReleased;
        private System.Windows.Forms.TextBox txtBxDateAdded;
        private System.Windows.Forms.TextBox txtBxComicIssue;
        private System.Windows.Forms.TextBox txtBxComicSubTitle;
        private System.Windows.Forms.Label lblGenre;
        private System.Windows.Forms.TextBox txtBxComicTitle;
        private System.Windows.Forms.ColumnHeader colSavedComicName;
        private System.Windows.Forms.ColumnHeader colAvailableComicBookName;
        private System.Windows.Forms.RadioButton rdBtnPublisher;
        private System.Windows.Forms.GroupBox grpBxSortOptions;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.RadioButton rdBtnSortDateReleased;
        private System.Windows.Forms.RadioButton rdBtnSortDateAdded;
        private System.Windows.Forms.Label lblPublisher;
        private System.Windows.Forms.TextBox txtBxPublisher;
        private System.Windows.Forms.Label lblViewCount;
        private System.Windows.Forms.Label lblAvgRating;
        private System.Windows.Forms.RadioButton rdBtnGenre;
    }
}