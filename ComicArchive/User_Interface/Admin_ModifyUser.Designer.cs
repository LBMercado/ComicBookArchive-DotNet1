namespace ComicArchive.User_Interface
{
    partial class Admin_ModifyUser
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
            this.panelUserDetails = new System.Windows.Forms.Panel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lbl_Info = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.btnModifyUser = new System.Windows.Forms.Button();
            this.lblPassword = new System.Windows.Forms.Label();
            this.lblPasswordConf = new System.Windows.Forms.Label();
            this.txtBxPasswordConf = new System.Windows.Forms.TextBox();
            this.txtBxName = new System.Windows.Forms.TextBox();
            this.txtBxPassword = new System.Windows.Forms.TextBox();
            this.lblAvailableComicsList = new System.Windows.Forms.Label();
            this.lstViewAvailableComics = new System.Windows.Forms.ListView();
            this.colComicNameAvailable = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panelUserComics = new System.Windows.Forms.Panel();
            this.btnAddComic = new System.Windows.Forms.Button();
            this.lblUserSavedComicsList = new System.Windows.Forms.Label();
            this.lstViewUserSavedComics = new System.Windows.Forms.ListView();
            this.colComicNameSaved = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnRemoveComic = new System.Windows.Forms.Button();
            this.tblLayoutPanelComicinfo = new System.Windows.Forms.TableLayoutPanel();
            this.lblAuthors = new System.Windows.Forms.Label();
            this.lblGenre = new System.Windows.Forms.Label();
            this.lblComicTitle = new System.Windows.Forms.Label();
            this.lblSynopsis = new System.Windows.Forms.Label();
            this.lblComicSubTitle = new System.Windows.Forms.Label();
            this.lblDateReleased = new System.Windows.Forms.Label();
            this.lbl_Issue = new System.Windows.Forms.Label();
            this.lblDateAdded = new System.Windows.Forms.Label();
            this.richTxtBxSynopsis = new System.Windows.Forms.RichTextBox();
            this.picBxComicCover = new System.Windows.Forms.PictureBox();
            this.panelComicInfo = new System.Windows.Forms.Panel();
            this.lblPublisher = new System.Windows.Forms.Label();
            this.panelUserDetails.SuspendLayout();
            this.panelUserComics.SuspendLayout();
            this.tblLayoutPanelComicinfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBxComicCover)).BeginInit();
            this.panelComicInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelUserDetails
            // 
            this.panelUserDetails.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.panelUserDetails.Controls.Add(this.btnCancel);
            this.panelUserDetails.Controls.Add(this.lbl_Info);
            this.panelUserDetails.Controls.Add(this.lblName);
            this.panelUserDetails.Controls.Add(this.btnModifyUser);
            this.panelUserDetails.Controls.Add(this.lblPassword);
            this.panelUserDetails.Controls.Add(this.lblPasswordConf);
            this.panelUserDetails.Controls.Add(this.txtBxPasswordConf);
            this.panelUserDetails.Controls.Add(this.txtBxName);
            this.panelUserDetails.Controls.Add(this.txtBxPassword);
            this.panelUserDetails.Location = new System.Drawing.Point(12, 12);
            this.panelUserDetails.Name = "panelUserDetails";
            this.panelUserDetails.Size = new System.Drawing.Size(585, 306);
            this.panelUserDetails.TabIndex = 9;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(375, 241);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(175, 39);
            this.btnCancel.TabIndex = 9;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // lbl_Info
            // 
            this.lbl_Info.AutoSize = true;
            this.lbl_Info.ForeColor = System.Drawing.Color.DarkRed;
            this.lbl_Info.Location = new System.Drawing.Point(193, 196);
            this.lbl_Info.Name = "lbl_Info";
            this.lbl_Info.Size = new System.Drawing.Size(66, 13);
            this.lbl_Info.TabIndex = 8;
            this.lbl_Info.Text = "NULL_INFO";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(15, 32);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(38, 13);
            this.lblName.TabIndex = 1;
            this.lblName.Text = "Name:";
            // 
            // btnModifyUser
            // 
            this.btnModifyUser.Location = new System.Drawing.Point(196, 241);
            this.btnModifyUser.Name = "btnModifyUser";
            this.btnModifyUser.Size = new System.Drawing.Size(175, 39);
            this.btnModifyUser.TabIndex = 7;
            this.btnModifyUser.Text = "Modify User";
            this.btnModifyUser.UseVisualStyleBackColor = true;
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Location = new System.Drawing.Point(15, 74);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(56, 13);
            this.lblPassword.TabIndex = 2;
            this.lblPassword.Text = "Password:";
            // 
            // lblPasswordConf
            // 
            this.lblPasswordConf.AutoSize = true;
            this.lblPasswordConf.Location = new System.Drawing.Point(15, 124);
            this.lblPasswordConf.Name = "lblPasswordConf";
            this.lblPasswordConf.Size = new System.Drawing.Size(100, 13);
            this.lblPasswordConf.TabIndex = 5;
            this.lblPasswordConf.Text = "Re-enter Password:";
            // 
            // txtBxPasswordConf
            // 
            this.txtBxPasswordConf.Location = new System.Drawing.Point(196, 121);
            this.txtBxPasswordConf.Name = "txtBxPasswordConf";
            this.txtBxPasswordConf.PasswordChar = '*';
            this.txtBxPasswordConf.Size = new System.Drawing.Size(354, 20);
            this.txtBxPasswordConf.TabIndex = 4;
            // 
            // txtBxName
            // 
            this.txtBxName.Location = new System.Drawing.Point(196, 25);
            this.txtBxName.Name = "txtBxName";
            this.txtBxName.Size = new System.Drawing.Size(354, 20);
            this.txtBxName.TabIndex = 0;
            // 
            // txtBxPassword
            // 
            this.txtBxPassword.Location = new System.Drawing.Point(196, 67);
            this.txtBxPassword.Name = "txtBxPassword";
            this.txtBxPassword.PasswordChar = '*';
            this.txtBxPassword.Size = new System.Drawing.Size(354, 20);
            this.txtBxPassword.TabIndex = 3;
            // 
            // lblAvailableComicsList
            // 
            this.lblAvailableComicsList.AutoSize = true;
            this.lblAvailableComicsList.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.lblAvailableComicsList.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lblAvailableComicsList.Location = new System.Drawing.Point(378, 19);
            this.lblAvailableComicsList.Name = "lblAvailableComicsList";
            this.lblAvailableComicsList.Size = new System.Drawing.Size(118, 13);
            this.lblAvailableComicsList.TabIndex = 11;
            this.lblAvailableComicsList.Text = "List of Available Comics";
            this.lblAvailableComicsList.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.lblAvailableComicsList.Visible = false;
            // 
            // lstViewAvailableComics
            // 
            this.lstViewAvailableComics.BackColor = System.Drawing.Color.DimGray;
            this.lstViewAvailableComics.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colComicNameAvailable});
            this.lstViewAvailableComics.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lstViewAvailableComics.Location = new System.Drawing.Point(333, 48);
            this.lstViewAvailableComics.Name = "lstViewAvailableComics";
            this.lstViewAvailableComics.Size = new System.Drawing.Size(226, 444);
            this.lstViewAvailableComics.TabIndex = 10;
            this.lstViewAvailableComics.UseCompatibleStateImageBehavior = false;
            this.lstViewAvailableComics.View = System.Windows.Forms.View.Details;
            // 
            // colComicNameAvailable
            // 
            this.colComicNameAvailable.Text = "Comic Book Name";
            this.colComicNameAvailable.Width = 220;
            // 
            // panelUserComics
            // 
            this.panelUserComics.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.panelUserComics.Controls.Add(this.btnAddComic);
            this.panelUserComics.Controls.Add(this.lblUserSavedComicsList);
            this.panelUserComics.Controls.Add(this.lstViewUserSavedComics);
            this.panelUserComics.Controls.Add(this.btnRemoveComic);
            this.panelUserComics.Controls.Add(this.lblAvailableComicsList);
            this.panelUserComics.Controls.Add(this.lstViewAvailableComics);
            this.panelUserComics.Location = new System.Drawing.Point(12, 324);
            this.panelUserComics.Name = "panelUserComics";
            this.panelUserComics.Size = new System.Drawing.Size(585, 511);
            this.panelUserComics.TabIndex = 10;
            // 
            // btnAddComic
            // 
            this.btnAddComic.Enabled = false;
            this.btnAddComic.Location = new System.Drawing.Point(252, 244);
            this.btnAddComic.Name = "btnAddComic";
            this.btnAddComic.Size = new System.Drawing.Size(75, 65);
            this.btnAddComic.TabIndex = 16;
            this.btnAddComic.Text = "<<";
            this.btnAddComic.UseVisualStyleBackColor = true;
            // 
            // lblUserSavedComicsList
            // 
            this.lblUserSavedComicsList.AutoSize = true;
            this.lblUserSavedComicsList.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.lblUserSavedComicsList.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lblUserSavedComicsList.Location = new System.Drawing.Point(64, 19);
            this.lblUserSavedComicsList.Name = "lblUserSavedComicsList";
            this.lblUserSavedComicsList.Size = new System.Drawing.Size(143, 13);
            this.lblUserSavedComicsList.TabIndex = 15;
            this.lblUserSavedComicsList.Text = "List of Saved Comics of User";
            this.lblUserSavedComicsList.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.lblUserSavedComicsList.Visible = false;
            // 
            // lstViewUserSavedComics
            // 
            this.lstViewUserSavedComics.BackColor = System.Drawing.Color.DimGray;
            this.lstViewUserSavedComics.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colComicNameSaved});
            this.lstViewUserSavedComics.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lstViewUserSavedComics.Location = new System.Drawing.Point(20, 48);
            this.lstViewUserSavedComics.Name = "lstViewUserSavedComics";
            this.lstViewUserSavedComics.Size = new System.Drawing.Size(226, 444);
            this.lstViewUserSavedComics.TabIndex = 14;
            this.lstViewUserSavedComics.UseCompatibleStateImageBehavior = false;
            this.lstViewUserSavedComics.View = System.Windows.Forms.View.Details;
            // 
            // colComicNameSaved
            // 
            this.colComicNameSaved.Text = "Comic Book Name";
            this.colComicNameSaved.Width = 220;
            // 
            // btnRemoveComic
            // 
            this.btnRemoveComic.Enabled = false;
            this.btnRemoveComic.Location = new System.Drawing.Point(252, 144);
            this.btnRemoveComic.Name = "btnRemoveComic";
            this.btnRemoveComic.Size = new System.Drawing.Size(75, 65);
            this.btnRemoveComic.TabIndex = 12;
            this.btnRemoveComic.Text = ">>";
            this.btnRemoveComic.UseVisualStyleBackColor = true;
            // 
            // tblLayoutPanelComicinfo
            // 
            this.tblLayoutPanelComicinfo.ColumnCount = 1;
            this.tblLayoutPanelComicinfo.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tblLayoutPanelComicinfo.Controls.Add(this.lblAuthors, 0, 7);
            this.tblLayoutPanelComicinfo.Controls.Add(this.lblGenre, 0, 7);
            this.tblLayoutPanelComicinfo.Controls.Add(this.lblComicTitle, 0, 0);
            this.tblLayoutPanelComicinfo.Controls.Add(this.lblSynopsis, 0, 5);
            this.tblLayoutPanelComicinfo.Controls.Add(this.lblComicSubTitle, 0, 1);
            this.tblLayoutPanelComicinfo.Controls.Add(this.lblDateReleased, 0, 4);
            this.tblLayoutPanelComicinfo.Controls.Add(this.lbl_Issue, 0, 2);
            this.tblLayoutPanelComicinfo.Controls.Add(this.lblDateAdded, 0, 3);
            this.tblLayoutPanelComicinfo.Controls.Add(this.richTxtBxSynopsis, 0, 6);
            this.tblLayoutPanelComicinfo.Controls.Add(this.lblPublisher, 0, 9);
            this.tblLayoutPanelComicinfo.Location = new System.Drawing.Point(13, 196);
            this.tblLayoutPanelComicinfo.Name = "tblLayoutPanelComicinfo";
            this.tblLayoutPanelComicinfo.RowCount = 10;
            this.tblLayoutPanelComicinfo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.52632F));
            this.tblLayoutPanelComicinfo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.52632F));
            this.tblLayoutPanelComicinfo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.368421F));
            this.tblLayoutPanelComicinfo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.368421F));
            this.tblLayoutPanelComicinfo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.368421F));
            this.tblLayoutPanelComicinfo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.263158F));
            this.tblLayoutPanelComicinfo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 26.31579F));
            this.tblLayoutPanelComicinfo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.368421F));
            this.tblLayoutPanelComicinfo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.52632F));
            this.tblLayoutPanelComicinfo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.368421F));
            this.tblLayoutPanelComicinfo.Size = new System.Drawing.Size(534, 608);
            this.tblLayoutPanelComicinfo.TabIndex = 26;
            // 
            // lblAuthors
            // 
            this.lblAuthors.AutoSize = true;
            this.lblAuthors.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblAuthors.Location = new System.Drawing.Point(3, 493);
            this.lblAuthors.Name = "lblAuthors";
            this.lblAuthors.Size = new System.Drawing.Size(528, 63);
            this.lblAuthors.TabIndex = 27;
            this.lblAuthors.Text = "Author/s: ";
            // 
            // lblGenre
            // 
            this.lblGenre.AutoSize = true;
            this.lblGenre.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblGenre.Location = new System.Drawing.Point(3, 449);
            this.lblGenre.Name = "lblGenre";
            this.lblGenre.Size = new System.Drawing.Size(528, 44);
            this.lblGenre.TabIndex = 26;
            this.lblGenre.Text = "Genre: ";
            // 
            // lblComicTitle
            // 
            this.lblComicTitle.AutoSize = true;
            this.lblComicTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblComicTitle.Location = new System.Drawing.Point(3, 0);
            this.lblComicTitle.Name = "lblComicTitle";
            this.lblComicTitle.Size = new System.Drawing.Size(528, 63);
            this.lblComicTitle.TabIndex = 20;
            this.lblComicTitle.Text = "Comic Title: ";
            // 
            // lblSynopsis
            // 
            this.lblSynopsis.AutoSize = true;
            this.lblSynopsis.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblSynopsis.Location = new System.Drawing.Point(3, 258);
            this.lblSynopsis.Name = "lblSynopsis";
            this.lblSynopsis.Size = new System.Drawing.Size(528, 31);
            this.lblSynopsis.TabIndex = 24;
            this.lblSynopsis.Text = "Synopsis: ";
            // 
            // lblComicSubTitle
            // 
            this.lblComicSubTitle.AutoSize = true;
            this.lblComicSubTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblComicSubTitle.Location = new System.Drawing.Point(3, 63);
            this.lblComicSubTitle.Name = "lblComicSubTitle";
            this.lblComicSubTitle.Size = new System.Drawing.Size(528, 63);
            this.lblComicSubTitle.TabIndex = 19;
            this.lblComicSubTitle.Text = "Comic Subtitle:";
            // 
            // lblDateReleased
            // 
            this.lblDateReleased.AutoSize = true;
            this.lblDateReleased.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDateReleased.Location = new System.Drawing.Point(3, 214);
            this.lblDateReleased.Name = "lblDateReleased";
            this.lblDateReleased.Size = new System.Drawing.Size(528, 44);
            this.lblDateReleased.TabIndex = 23;
            this.lblDateReleased.Text = "Date Released: ";
            // 
            // lbl_Issue
            // 
            this.lbl_Issue.AutoSize = true;
            this.lbl_Issue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_Issue.Location = new System.Drawing.Point(3, 126);
            this.lbl_Issue.Name = "lbl_Issue";
            this.lbl_Issue.Size = new System.Drawing.Size(528, 44);
            this.lbl_Issue.TabIndex = 21;
            this.lbl_Issue.Text = "Issue: ";
            // 
            // lblDateAdded
            // 
            this.lblDateAdded.AutoSize = true;
            this.lblDateAdded.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDateAdded.Location = new System.Drawing.Point(3, 170);
            this.lblDateAdded.Name = "lblDateAdded";
            this.lblDateAdded.Size = new System.Drawing.Size(528, 44);
            this.lblDateAdded.TabIndex = 22;
            this.lblDateAdded.Text = "Date Added: ";
            // 
            // richTxtBxSynopsis
            // 
            this.richTxtBxSynopsis.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTxtBxSynopsis.Location = new System.Drawing.Point(3, 292);
            this.richTxtBxSynopsis.Name = "richTxtBxSynopsis";
            this.richTxtBxSynopsis.ReadOnly = true;
            this.richTxtBxSynopsis.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.richTxtBxSynopsis.Size = new System.Drawing.Size(528, 154);
            this.richTxtBxSynopsis.TabIndex = 25;
            this.richTxtBxSynopsis.Text = "";
            // 
            // picBxComicCover
            // 
            this.picBxComicCover.BackColor = System.Drawing.Color.WhiteSmoke;
            this.picBxComicCover.Location = new System.Drawing.Point(200, 16);
            this.picBxComicCover.Name = "picBxComicCover";
            this.picBxComicCover.Size = new System.Drawing.Size(200, 174);
            this.picBxComicCover.TabIndex = 18;
            this.picBxComicCover.TabStop = false;
            // 
            // panelComicInfo
            // 
            this.panelComicInfo.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.panelComicInfo.Controls.Add(this.tblLayoutPanelComicinfo);
            this.panelComicInfo.Controls.Add(this.picBxComicCover);
            this.panelComicInfo.Location = new System.Drawing.Point(603, 12);
            this.panelComicInfo.Name = "panelComicInfo";
            this.panelComicInfo.Size = new System.Drawing.Size(562, 823);
            this.panelComicInfo.TabIndex = 10;
            // 
            // lblPublisher
            // 
            this.lblPublisher.AutoSize = true;
            this.lblPublisher.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblPublisher.Location = new System.Drawing.Point(3, 556);
            this.lblPublisher.Name = "lblPublisher";
            this.lblPublisher.Size = new System.Drawing.Size(528, 52);
            this.lblPublisher.TabIndex = 28;
            this.lblPublisher.Text = "Publisher: ";
            // 
            // Admin_ModifyUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1175, 848);
            this.Controls.Add(this.panelComicInfo);
            this.Controls.Add(this.panelUserComics);
            this.Controls.Add(this.panelUserDetails);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(662, 373);
            this.Name = "Admin_ModifyUser";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Modify User";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Admin_ModifyUser_FormClosing);
            this.panelUserDetails.ResumeLayout(false);
            this.panelUserDetails.PerformLayout();
            this.panelUserComics.ResumeLayout(false);
            this.panelUserComics.PerformLayout();
            this.tblLayoutPanelComicinfo.ResumeLayout(false);
            this.tblLayoutPanelComicinfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBxComicCover)).EndInit();
            this.panelComicInfo.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelUserDetails;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lbl_Info;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Button btnModifyUser;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.Label lblPasswordConf;
        private System.Windows.Forms.TextBox txtBxPasswordConf;
        private System.Windows.Forms.TextBox txtBxName;
        private System.Windows.Forms.TextBox txtBxPassword;
        private System.Windows.Forms.Label lblAvailableComicsList;
        private System.Windows.Forms.ListView lstViewAvailableComics;
        private System.Windows.Forms.Panel panelUserComics;
        private System.Windows.Forms.Label lblUserSavedComicsList;
        private System.Windows.Forms.ListView lstViewUserSavedComics;
        private System.Windows.Forms.Button btnRemoveComic;
        private System.Windows.Forms.Button btnAddComic;
        private System.Windows.Forms.PictureBox picBxComicCover;
        private System.Windows.Forms.Label lblComicSubTitle;
        private System.Windows.Forms.ColumnHeader colComicNameSaved;
        private System.Windows.Forms.ColumnHeader colComicNameAvailable;
        private System.Windows.Forms.Label lbl_Issue;
        private System.Windows.Forms.Label lblComicTitle;
        private System.Windows.Forms.Label lblDateAdded;
        private System.Windows.Forms.Label lblDateReleased;
        private System.Windows.Forms.RichTextBox richTxtBxSynopsis;
        private System.Windows.Forms.Label lblSynopsis;
        private System.Windows.Forms.TableLayoutPanel tblLayoutPanelComicinfo;
        private System.Windows.Forms.Label lblAuthors;
        private System.Windows.Forms.Label lblGenre;
        private System.Windows.Forms.Panel panelComicInfo;
        private System.Windows.Forms.Label lblPublisher;
    }
}