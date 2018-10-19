namespace ComicArchive
{
    partial class HomeUI
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
            this.lstBxComics = new System.Windows.Forms.ListBox();
            this.lblInfo = new System.Windows.Forms.Label();
            this.btnClearCache = new System.Windows.Forms.Button();
            this.lblNumPages = new System.Windows.Forms.Label();
            this.lblViewCount = new System.Windows.Forms.Label();
            this.lblAvgRating = new System.Windows.Forms.Label();
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
            this.tblLayoutPanelComicinfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBxComicCover)).BeginInit();
            this.SuspendLayout();
            // 
            // lstBxComics
            // 
            this.lstBxComics.FormattingEnabled = true;
            this.lstBxComics.Location = new System.Drawing.Point(103, 140);
            this.lstBxComics.Name = "lstBxComics";
            this.lstBxComics.Size = new System.Drawing.Size(200, 368);
            this.lstBxComics.TabIndex = 1;
            this.lstBxComics.SelectedIndexChanged += new System.EventHandler(this.lstBxComics_SelectedIndexChanged);
            this.lstBxComics.DoubleClick += new System.EventHandler(this.lstBxComics_DoubleClick);
            // 
            // lblInfo
            // 
            this.lblInfo.AutoSize = true;
            this.lblInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInfo.Location = new System.Drawing.Point(22, 617);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(404, 16);
            this.lblInfo.TabIndex = 13;
            this.lblInfo.Text = "Double click on a comic in the comic list to begin reading.";
            // 
            // btnClearCache
            // 
            this.btnClearCache.Location = new System.Drawing.Point(25, 666);
            this.btnClearCache.Name = "btnClearCache";
            this.btnClearCache.Size = new System.Drawing.Size(75, 23);
            this.btnClearCache.TabIndex = 14;
            this.btnClearCache.Text = "Clear Cache";
            this.btnClearCache.UseVisualStyleBackColor = true;
            this.btnClearCache.Click += new System.EventHandler(this.btnClearCache_Click);
            // 
            // lblNumPages
            // 
            this.lblNumPages.AutoSize = true;
            this.lblNumPages.ForeColor = System.Drawing.Color.Black;
            this.lblNumPages.Location = new System.Drawing.Point(449, 77);
            this.lblNumPages.Name = "lblNumPages";
            this.lblNumPages.Size = new System.Drawing.Size(65, 13);
            this.lblNumPages.TabIndex = 38;
            this.lblNumPages.Text = "# of Pages: ";
            this.lblNumPages.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblViewCount
            // 
            this.lblViewCount.AutoSize = true;
            this.lblViewCount.ForeColor = System.Drawing.Color.Black;
            this.lblViewCount.Location = new System.Drawing.Point(449, 149);
            this.lblViewCount.Name = "lblViewCount";
            this.lblViewCount.Size = new System.Drawing.Size(63, 13);
            this.lblViewCount.TabIndex = 37;
            this.lblViewCount.Text = "# of Views: ";
            this.lblViewCount.Visible = false;
            // 
            // lblAvgRating
            // 
            this.lblAvgRating.AutoSize = true;
            this.lblAvgRating.ForeColor = System.Drawing.Color.Black;
            this.lblAvgRating.Location = new System.Drawing.Point(449, 115);
            this.lblAvgRating.Name = "lblAvgRating";
            this.lblAvgRating.Size = new System.Drawing.Size(87, 13);
            this.lblAvgRating.TabIndex = 36;
            this.lblAvgRating.Text = "Average Rating: ";
            this.lblAvgRating.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.lblAvgRating.Visible = false;
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
            this.tblLayoutPanelComicinfo.Location = new System.Drawing.Point(452, 238);
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
            this.tblLayoutPanelComicinfo.TabIndex = 35;
            // 
            // txtBxGenre
            // 
            this.txtBxGenre.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtBxGenre.Location = new System.Drawing.Point(129, 425);
            this.txtBxGenre.Name = "txtBxGenre";
            this.txtBxGenre.ReadOnly = true;
            this.txtBxGenre.Size = new System.Drawing.Size(332, 20);
            this.txtBxGenre.TabIndex = 34;
            // 
            // txtBxAuthors
            // 
            this.txtBxAuthors.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtBxAuthors.Location = new System.Drawing.Point(129, 378);
            this.txtBxAuthors.Name = "txtBxAuthors";
            this.txtBxAuthors.ReadOnly = true;
            this.txtBxAuthors.Size = new System.Drawing.Size(332, 20);
            this.txtBxAuthors.TabIndex = 33;
            // 
            // txtBxDateReleased
            // 
            this.txtBxDateReleased.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtBxDateReleased.Location = new System.Drawing.Point(129, 191);
            this.txtBxDateReleased.Name = "txtBxDateReleased";
            this.txtBxDateReleased.ReadOnly = true;
            this.txtBxDateReleased.Size = new System.Drawing.Size(332, 20);
            this.txtBxDateReleased.TabIndex = 32;
            // 
            // txtBxDateAdded
            // 
            this.txtBxDateAdded.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtBxDateAdded.Location = new System.Drawing.Point(129, 144);
            this.txtBxDateAdded.Name = "txtBxDateAdded";
            this.txtBxDateAdded.ReadOnly = true;
            this.txtBxDateAdded.Size = new System.Drawing.Size(332, 20);
            this.txtBxDateAdded.TabIndex = 31;
            // 
            // txtBxComicIssue
            // 
            this.txtBxComicIssue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtBxComicIssue.Location = new System.Drawing.Point(129, 97);
            this.txtBxComicIssue.Name = "txtBxComicIssue";
            this.txtBxComicIssue.ReadOnly = true;
            this.txtBxComicIssue.Size = new System.Drawing.Size(332, 20);
            this.txtBxComicIssue.TabIndex = 30;
            // 
            // txtBxComicSubTitle
            // 
            this.txtBxComicSubTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtBxComicSubTitle.Location = new System.Drawing.Point(129, 50);
            this.txtBxComicSubTitle.Name = "txtBxComicSubTitle";
            this.txtBxComicSubTitle.ReadOnly = true;
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
            this.lblGenre.Text = "Genre/s: \r\n(Separate with commas)";
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
            this.richTxtBxSynopsis.ReadOnly = true;
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
            this.txtBxComicTitle.ReadOnly = true;
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
            this.txtBxPublisher.ReadOnly = true;
            this.txtBxPublisher.Size = new System.Drawing.Size(332, 20);
            this.txtBxPublisher.TabIndex = 36;
            // 
            // picBxComicCover
            // 
            this.picBxComicCover.BackColor = System.Drawing.Color.WhiteSmoke;
            this.picBxComicCover.Location = new System.Drawing.Point(710, 12);
            this.picBxComicCover.Name = "picBxComicCover";
            this.picBxComicCover.Size = new System.Drawing.Size(200, 200);
            this.picBxComicCover.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picBxComicCover.TabIndex = 34;
            this.picBxComicCover.TabStop = false;
            // 
            // HomeUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1000, 800);
            this.ControlBox = false;
            this.Controls.Add(this.lblNumPages);
            this.Controls.Add(this.lblViewCount);
            this.Controls.Add(this.lblAvgRating);
            this.Controls.Add(this.tblLayoutPanelComicinfo);
            this.Controls.Add(this.picBxComicCover);
            this.Controls.Add(this.btnClearCache);
            this.Controls.Add(this.lblInfo);
            this.Controls.Add(this.lstBxComics);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "HomeUI";
            this.Text = "Home";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.tblLayoutPanelComicinfo.ResumeLayout(false);
            this.tblLayoutPanelComicinfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBxComicCover)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ListBox lstBxComics;
        private System.Windows.Forms.Label lblInfo;
        private System.Windows.Forms.Button btnClearCache;
        private System.Windows.Forms.Label lblNumPages;
        private System.Windows.Forms.Label lblViewCount;
        private System.Windows.Forms.Label lblAvgRating;
        private System.Windows.Forms.TableLayoutPanel tblLayoutPanelComicinfo;
        private System.Windows.Forms.TextBox txtBxGenre;
        private System.Windows.Forms.TextBox txtBxAuthors;
        private System.Windows.Forms.TextBox txtBxDateReleased;
        private System.Windows.Forms.TextBox txtBxDateAdded;
        private System.Windows.Forms.TextBox txtBxComicIssue;
        private System.Windows.Forms.TextBox txtBxComicSubTitle;
        private System.Windows.Forms.Label lblAuthors;
        private System.Windows.Forms.Label lblGenre;
        private System.Windows.Forms.Label lblComicTitle;
        private System.Windows.Forms.Label lblSynopsis;
        private System.Windows.Forms.Label lblComicSubTitle;
        private System.Windows.Forms.Label lblDateReleased;
        private System.Windows.Forms.Label lbl_Issue;
        private System.Windows.Forms.Label lblDateAdded;
        private System.Windows.Forms.RichTextBox richTxtBxSynopsis;
        private System.Windows.Forms.TextBox txtBxComicTitle;
        private System.Windows.Forms.Label lblPublisher;
        private System.Windows.Forms.TextBox txtBxPublisher;
        private System.Windows.Forms.PictureBox picBxComicCover;
    }
}

