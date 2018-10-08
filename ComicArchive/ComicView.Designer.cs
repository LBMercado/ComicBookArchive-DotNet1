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
            this.panelComicScreen.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBxComicScreen)).BeginInit();
            this.SuspendLayout();
            // 
            // btnGoToFirst
            // 
            this.btnGoToFirst.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGoToFirst.Location = new System.Drawing.Point(153, 729);
            this.btnGoToFirst.Name = "btnGoToFirst";
            this.btnGoToFirst.Size = new System.Drawing.Size(75, 23);
            this.btnGoToFirst.TabIndex = 1;
            this.btnGoToFirst.Text = "|<";
            this.btnGoToFirst.UseVisualStyleBackColor = true;
            // 
            // btnGoToLast
            // 
            this.btnGoToLast.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGoToLast.Location = new System.Drawing.Point(462, 729);
            this.btnGoToLast.Name = "btnGoToLast";
            this.btnGoToLast.Size = new System.Drawing.Size(75, 23);
            this.btnGoToLast.TabIndex = 2;
            this.btnGoToLast.Text = ">|";
            this.btnGoToLast.UseVisualStyleBackColor = true;
            // 
            // btnGoToNext
            // 
            this.btnGoToNext.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGoToNext.Location = new System.Drawing.Point(362, 729);
            this.btnGoToNext.Name = "btnGoToNext";
            this.btnGoToNext.Size = new System.Drawing.Size(75, 23);
            this.btnGoToNext.TabIndex = 3;
            this.btnGoToNext.Text = ">";
            this.btnGoToNext.UseVisualStyleBackColor = true;
            this.btnGoToNext.Click += new System.EventHandler(this.btnGoToNext_Click);
            // 
            // btnGoToPrevious
            // 
            this.btnGoToPrevious.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGoToPrevious.Location = new System.Drawing.Point(259, 729);
            this.btnGoToPrevious.Name = "btnGoToPrevious";
            this.btnGoToPrevious.Size = new System.Drawing.Size(75, 23);
            this.btnGoToPrevious.TabIndex = 4;
            this.btnGoToPrevious.Text = "<";
            this.btnGoToPrevious.UseVisualStyleBackColor = true;
            this.btnGoToPrevious.Click += new System.EventHandler(this.btnGoToPrevious_Click);
            // 
            // lblPageNumber
            // 
            this.lblPageNumber.AutoSize = true;
            this.lblPageNumber.Location = new System.Drawing.Point(604, 718);
            this.lblPageNumber.Name = "lblPageNumber";
            this.lblPageNumber.Size = new System.Drawing.Size(64, 13);
            this.lblPageNumber.TabIndex = 5;
            this.lblPageNumber.Text = "Page X of Y";
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Location = new System.Drawing.Point(844, 718);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(27, 13);
            this.lblTitle.TabIndex = 6;
            this.lblTitle.Text = "Title";
            // 
            // btnFinish
            // 
            this.btnFinish.Location = new System.Drawing.Point(1105, 762);
            this.btnFinish.Name = "btnFinish";
            this.btnFinish.Size = new System.Drawing.Size(124, 23);
            this.btnFinish.TabIndex = 7;
            this.btnFinish.Text = "Finish Reading";
            this.btnFinish.UseVisualStyleBackColor = true;
            this.btnFinish.Click += new System.EventHandler(this.btnFinish_Click);
            // 
            // panelComicScreen
            // 
            this.panelComicScreen.Controls.Add(this.picBxComicScreen);
            this.panelComicScreen.Location = new System.Drawing.Point(12, 12);
            this.panelComicScreen.Name = "panelComicScreen";
            this.panelComicScreen.Size = new System.Drawing.Size(1267, 679);
            this.panelComicScreen.TabIndex = 8;
            // 
            // picBxComicScreen
            // 
            this.picBxComicScreen.Location = new System.Drawing.Point(13, 12);
            this.picBxComicScreen.Name = "picBxComicScreen";
            this.picBxComicScreen.Size = new System.Drawing.Size(1239, 652);
            this.picBxComicScreen.TabIndex = 0;
            this.picBxComicScreen.TabStop = false;
            // 
            // ComicView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1291, 828);
            this.Controls.Add(this.panelComicScreen);
            this.Controls.Add(this.btnFinish);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lblPageNumber);
            this.Controls.Add(this.btnGoToPrevious);
            this.Controls.Add(this.btnGoToNext);
            this.Controls.Add(this.btnGoToLast);
            this.Controls.Add(this.btnGoToFirst);
            this.Name = "ComicView";
            this.Text = "ComicView";
            this.panelComicScreen.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picBxComicScreen)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

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
    }
}