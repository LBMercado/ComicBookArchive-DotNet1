namespace ComicArchive
{
    partial class ComicView
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
            this.btnGoToFirst = new System.Windows.Forms.Button();
            this.btnGoToLast = new System.Windows.Forms.Button();
            this.btnGoToNext = new System.Windows.Forms.Button();
            this.btnGoToPrevious = new System.Windows.Forms.Button();
            this.lblPageNumber = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.btnFinish = new System.Windows.Forms.Button();
            this.panelComicScreen = new System.Windows.Forms.Panel();
            this.picBxComicScreen = new System.Windows.Forms.PictureBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panelComicScreen.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBxComicScreen)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnGoToFirst
            // 
            this.btnGoToFirst.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGoToFirst.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGoToFirst.Location = new System.Drawing.Point(3, 3);
            this.btnGoToFirst.Name = "btnGoToFirst";
            this.btnGoToFirst.Size = new System.Drawing.Size(172, 95);
            this.btnGoToFirst.TabIndex = 1;
            this.btnGoToFirst.Text = "|<";
            this.btnGoToFirst.UseVisualStyleBackColor = true;
            this.btnGoToFirst.Click += new System.EventHandler(this.btnGoToFirst_Click);
            // 
            // btnGoToLast
            // 
            this.btnGoToLast.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGoToLast.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGoToLast.Location = new System.Drawing.Point(537, 3);
            this.btnGoToLast.Name = "btnGoToLast";
            this.btnGoToLast.Size = new System.Drawing.Size(172, 95);
            this.btnGoToLast.TabIndex = 2;
            this.btnGoToLast.Text = ">|";
            this.btnGoToLast.UseVisualStyleBackColor = true;
            this.btnGoToLast.Click += new System.EventHandler(this.btnGoToLast_Click);
            // 
            // btnGoToNext
            // 
            this.btnGoToNext.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGoToNext.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGoToNext.Location = new System.Drawing.Point(359, 3);
            this.btnGoToNext.Name = "btnGoToNext";
            this.btnGoToNext.Size = new System.Drawing.Size(172, 95);
            this.btnGoToNext.TabIndex = 3;
            this.btnGoToNext.Text = ">";
            this.btnGoToNext.UseVisualStyleBackColor = true;
            this.btnGoToNext.Click += new System.EventHandler(this.btnGoToNext_Click);
            // 
            // btnGoToPrevious
            // 
            this.btnGoToPrevious.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGoToPrevious.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGoToPrevious.Location = new System.Drawing.Point(181, 3);
            this.btnGoToPrevious.Name = "btnGoToPrevious";
            this.btnGoToPrevious.Size = new System.Drawing.Size(172, 95);
            this.btnGoToPrevious.TabIndex = 4;
            this.btnGoToPrevious.Text = "<";
            this.btnGoToPrevious.UseVisualStyleBackColor = true;
            this.btnGoToPrevious.Click += new System.EventHandler(this.btnGoToPrevious_Click);
            // 
            // lblPageNumber
            // 
            this.lblPageNumber.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPageNumber.AutoSize = true;
            this.lblPageNumber.Location = new System.Drawing.Point(715, 0);
            this.lblPageNumber.Name = "lblPageNumber";
            this.lblPageNumber.Size = new System.Drawing.Size(194, 101);
            this.lblPageNumber.TabIndex = 5;
            this.lblPageNumber.Text = "Page X of Y";
            // 
            // lblTitle
            // 
            this.lblTitle.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTitle.AutoSize = true;
            this.lblTitle.Location = new System.Drawing.Point(915, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(194, 101);
            this.lblTitle.TabIndex = 6;
            this.lblTitle.Text = "Title";
            // 
            // btnFinish
            // 
            this.btnFinish.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFinish.Location = new System.Drawing.Point(1115, 3);
            this.btnFinish.Name = "btnFinish";
            this.btnFinish.Size = new System.Drawing.Size(173, 95);
            this.btnFinish.TabIndex = 7;
            this.btnFinish.Text = "Finish Reading";
            this.btnFinish.UseVisualStyleBackColor = true;
            this.btnFinish.Click += new System.EventHandler(this.btnFinish_Click);
            // 
            // panelComicScreen
            // 
            this.panelComicScreen.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelComicScreen.Controls.Add(this.picBxComicScreen);
            this.panelComicScreen.Location = new System.Drawing.Point(12, 12);
            this.panelComicScreen.Name = "panelComicScreen";
            this.panelComicScreen.Size = new System.Drawing.Size(1267, 679);
            this.panelComicScreen.TabIndex = 8;
            // 
            // picBxComicScreen
            // 
            this.picBxComicScreen.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.picBxComicScreen.Location = new System.Drawing.Point(13, 12);
            this.picBxComicScreen.MinimumSize = new System.Drawing.Size(1239, 652);
            this.picBxComicScreen.Name = "picBxComicScreen";
            this.picBxComicScreen.Size = new System.Drawing.Size(1239, 652);
            this.picBxComicScreen.TabIndex = 0;
            this.picBxComicScreen.TabStop = false;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 7;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.Controls.Add(this.btnGoToFirst, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnGoToPrevious, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnFinish, 6, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnGoToNext, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblTitle, 5, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnGoToLast, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblPageNumber, 4, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 727);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1291, 101);
            this.tableLayoutPanel1.TabIndex = 9;
            // 
            // ComicView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1291, 828);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.panelComicScreen);
            this.MinimumSize = new System.Drawing.Size(1307, 867);
            this.Name = "ComicView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ComicView";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ComicView_FormClosing);
            this.Load += new System.EventHandler(this.ComicView_Load);
            this.panelComicScreen.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picBxComicScreen)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnGoToFirst;
        private System.Windows.Forms.Button btnGoToLast;
        private System.Windows.Forms.Button btnGoToNext;
        private System.Windows.Forms.Button btnGoToPrevious;
        private System.Windows.Forms.Label lblPageNumber;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button btnFinish;
        private System.Windows.Forms.Panel panelComicScreen;
        private System.Windows.Forms.PictureBox picBxComicScreen;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    }
}