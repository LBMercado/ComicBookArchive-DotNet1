namespace ComicArchive
{
    partial class MainMenu
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
            this.picBxComicFront = new System.Windows.Forms.PictureBox();
            this.lstBxComics = new System.Windows.Forms.ListBox();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblSubTitle = new System.Windows.Forms.Label();
            this.btnSignOut = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.lblNotif = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnSort = new System.Windows.Forms.Button();
            this.txtBxSearch = new System.Windows.Forms.TextBox();
            this.grpBxCategory = new System.Windows.Forms.GroupBox();
            this.rdBtnTitle = new System.Windows.Forms.RadioButton();
            this.rdBtnAuthor = new System.Windows.Forms.RadioButton();
            this.rdBtnYear = new System.Windows.Forms.RadioButton();
            this.lblAuthor = new System.Windows.Forms.Label();
            this.lblReleaseDate = new System.Windows.Forms.Label();
            this.lblInfo = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picBxComicFront)).BeginInit();
            this.grpBxCategory.SuspendLayout();
            this.SuspendLayout();
            // 
            // picBxComicFront
            // 
            this.picBxComicFront.Location = new System.Drawing.Point(361, 28);
            this.picBxComicFront.Name = "picBxComicFront";
            this.picBxComicFront.Size = new System.Drawing.Size(585, 457);
            this.picBxComicFront.TabIndex = 0;
            this.picBxComicFront.TabStop = false;
            // 
            // lstBxComics
            // 
            this.lstBxComics.FormattingEnabled = true;
            this.lstBxComics.Location = new System.Drawing.Point(72, 28);
            this.lstBxComics.Name = "lstBxComics";
            this.lstBxComics.Size = new System.Drawing.Size(147, 459);
            this.lstBxComics.TabIndex = 1;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Location = new System.Drawing.Point(443, 512);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(27, 13);
            this.lblTitle.TabIndex = 2;
            this.lblTitle.Text = "Title";
            // 
            // lblSubTitle
            // 
            this.lblSubTitle.AutoSize = true;
            this.lblSubTitle.Location = new System.Drawing.Point(796, 512);
            this.lblSubTitle.Name = "lblSubTitle";
            this.lblSubTitle.Size = new System.Drawing.Size(42, 13);
            this.lblSubTitle.TabIndex = 3;
            this.lblSubTitle.Text = "Subtitle";
            // 
            // btnSignOut
            // 
            this.btnSignOut.Location = new System.Drawing.Point(756, 665);
            this.btnSignOut.Name = "btnSignOut";
            this.btnSignOut.Size = new System.Drawing.Size(75, 23);
            this.btnSignOut.TabIndex = 4;
            this.btnSignOut.Text = "Sign Out";
            this.btnSignOut.UseVisualStyleBackColor = true;
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(862, 665);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 23);
            this.btnExit.TabIndex = 5;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            // 
            // lblNotif
            // 
            this.lblNotif.AutoSize = true;
            this.lblNotif.Location = new System.Drawing.Point(69, 9);
            this.lblNotif.Name = "lblNotif";
            this.lblNotif.Size = new System.Drawing.Size(60, 13);
            this.lblNotif.TabIndex = 6;
            this.lblNotif.Text = "Notification";
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(72, 547);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 7;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            // 
            // btnSort
            // 
            this.btnSort.Location = new System.Drawing.Point(168, 547);
            this.btnSort.Name = "btnSort";
            this.btnSort.Size = new System.Drawing.Size(75, 23);
            this.btnSort.TabIndex = 8;
            this.btnSort.Text = "Sort";
            this.btnSort.UseVisualStyleBackColor = true;
            // 
            // txtBxSearch
            // 
            this.txtBxSearch.Location = new System.Drawing.Point(72, 512);
            this.txtBxSearch.Name = "txtBxSearch";
            this.txtBxSearch.Size = new System.Drawing.Size(171, 20);
            this.txtBxSearch.TabIndex = 9;
            // 
            // grpBxCategory
            // 
            this.grpBxCategory.Controls.Add(this.rdBtnYear);
            this.grpBxCategory.Controls.Add(this.rdBtnAuthor);
            this.grpBxCategory.Controls.Add(this.rdBtnTitle);
            this.grpBxCategory.Location = new System.Drawing.Point(72, 588);
            this.grpBxCategory.Name = "grpBxCategory";
            this.grpBxCategory.Size = new System.Drawing.Size(200, 100);
            this.grpBxCategory.TabIndex = 10;
            this.grpBxCategory.TabStop = false;
            this.grpBxCategory.Text = "Category";
            // 
            // rdBtnTitle
            // 
            this.rdBtnTitle.AutoSize = true;
            this.rdBtnTitle.Location = new System.Drawing.Point(6, 29);
            this.rdBtnTitle.Name = "rdBtnTitle";
            this.rdBtnTitle.Size = new System.Drawing.Size(45, 17);
            this.rdBtnTitle.TabIndex = 11;
            this.rdBtnTitle.TabStop = true;
            this.rdBtnTitle.Text = "Title";
            this.rdBtnTitle.UseVisualStyleBackColor = true;
            // 
            // rdBtnAuthor
            // 
            this.rdBtnAuthor.AutoSize = true;
            this.rdBtnAuthor.Location = new System.Drawing.Point(6, 63);
            this.rdBtnAuthor.Name = "rdBtnAuthor";
            this.rdBtnAuthor.Size = new System.Drawing.Size(56, 17);
            this.rdBtnAuthor.TabIndex = 12;
            this.rdBtnAuthor.TabStop = true;
            this.rdBtnAuthor.Text = "Author";
            this.rdBtnAuthor.UseVisualStyleBackColor = true;
            // 
            // rdBtnYear
            // 
            this.rdBtnYear.AutoSize = true;
            this.rdBtnYear.Location = new System.Drawing.Point(97, 29);
            this.rdBtnYear.Name = "rdBtnYear";
            this.rdBtnYear.Size = new System.Drawing.Size(90, 17);
            this.rdBtnYear.TabIndex = 13;
            this.rdBtnYear.TabStop = true;
            this.rdBtnYear.Text = "Release Date";
            this.rdBtnYear.UseVisualStyleBackColor = true;
            // 
            // lblAuthor
            // 
            this.lblAuthor.AutoSize = true;
            this.lblAuthor.Location = new System.Drawing.Point(443, 552);
            this.lblAuthor.Name = "lblAuthor";
            this.lblAuthor.Size = new System.Drawing.Size(48, 13);
            this.lblAuthor.TabIndex = 11;
            this.lblAuthor.Text = "Author/s";
            // 
            // lblReleaseDate
            // 
            this.lblReleaseDate.AutoSize = true;
            this.lblReleaseDate.Location = new System.Drawing.Point(656, 552);
            this.lblReleaseDate.Name = "lblReleaseDate";
            this.lblReleaseDate.Size = new System.Drawing.Size(72, 13);
            this.lblReleaseDate.TabIndex = 12;
            this.lblReleaseDate.Text = "Release Date";
            // 
            // lblInfo
            // 
            this.lblInfo.AutoSize = true;
            this.lblInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInfo.Location = new System.Drawing.Point(305, 672);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(404, 16);
            this.lblInfo.TabIndex = 13;
            this.lblInfo.Text = "Double click on a comic in the comic list to begin reading.";
            // 
            // MainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(974, 722);
            this.Controls.Add(this.lblInfo);
            this.Controls.Add(this.lblReleaseDate);
            this.Controls.Add(this.lblAuthor);
            this.Controls.Add(this.grpBxCategory);
            this.Controls.Add(this.txtBxSearch);
            this.Controls.Add(this.btnSort);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.lblNotif);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnSignOut);
            this.Controls.Add(this.lblSubTitle);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lstBxComics);
            this.Controls.Add(this.picBxComicFront);
            this.Name = "MainMenu";
            this.Text = "Comic Archive";
            ((System.ComponentModel.ISupportInitialize)(this.picBxComicFront)).EndInit();
            this.grpBxCategory.ResumeLayout(false);
            this.grpBxCategory.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picBxComicFront;
        private System.Windows.Forms.ListBox lstBxComics;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblSubTitle;
        private System.Windows.Forms.Button btnSignOut;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Label lblNotif;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnSort;
        private System.Windows.Forms.TextBox txtBxSearch;
        private System.Windows.Forms.GroupBox grpBxCategory;
        private System.Windows.Forms.RadioButton rdBtnYear;
        private System.Windows.Forms.RadioButton rdBtnAuthor;
        private System.Windows.Forms.RadioButton rdBtnTitle;
        private System.Windows.Forms.Label lblAuthor;
        private System.Windows.Forms.Label lblReleaseDate;
        private System.Windows.Forms.Label lblInfo;
    }
}

