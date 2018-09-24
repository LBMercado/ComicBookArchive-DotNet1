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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnGoToFirst = new System.Windows.Forms.Button();
            this.btnGoToLast = new System.Windows.Forms.Button();
            this.btnGoToNext = new System.Windows.Forms.Button();
            this.btnGoToPrevious = new System.Windows.Forms.Button();
            this.lblPageNumber = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.btnFinish = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1583, 640);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // btnGoToFirst
            // 
            this.btnGoToFirst.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGoToFirst.Location = new System.Drawing.Point(519, 703);
            this.btnGoToFirst.Name = "btnGoToFirst";
            this.btnGoToFirst.Size = new System.Drawing.Size(75, 23);
            this.btnGoToFirst.TabIndex = 1;
            this.btnGoToFirst.Text = "|<";
            this.btnGoToFirst.UseVisualStyleBackColor = true;
            // 
            // btnGoToLast
            // 
            this.btnGoToLast.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGoToLast.Location = new System.Drawing.Point(828, 703);
            this.btnGoToLast.Name = "btnGoToLast";
            this.btnGoToLast.Size = new System.Drawing.Size(75, 23);
            this.btnGoToLast.TabIndex = 2;
            this.btnGoToLast.Text = ">|";
            this.btnGoToLast.UseVisualStyleBackColor = true;
            // 
            // btnGoToNext
            // 
            this.btnGoToNext.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGoToNext.Location = new System.Drawing.Point(728, 703);
            this.btnGoToNext.Name = "btnGoToNext";
            this.btnGoToNext.Size = new System.Drawing.Size(75, 23);
            this.btnGoToNext.TabIndex = 3;
            this.btnGoToNext.Text = ">";
            this.btnGoToNext.UseVisualStyleBackColor = true;
            // 
            // btnGoToPrevious
            // 
            this.btnGoToPrevious.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGoToPrevious.Location = new System.Drawing.Point(625, 703);
            this.btnGoToPrevious.Name = "btnGoToPrevious";
            this.btnGoToPrevious.Size = new System.Drawing.Size(75, 23);
            this.btnGoToPrevious.TabIndex = 4;
            this.btnGoToPrevious.Text = "<";
            this.btnGoToPrevious.UseVisualStyleBackColor = true;
            // 
            // lblPageNumber
            // 
            this.lblPageNumber.AutoSize = true;
            this.lblPageNumber.Location = new System.Drawing.Point(970, 692);
            this.lblPageNumber.Name = "lblPageNumber";
            this.lblPageNumber.Size = new System.Drawing.Size(64, 13);
            this.lblPageNumber.TabIndex = 5;
            this.lblPageNumber.Text = "Page X of Y";
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Location = new System.Drawing.Point(1210, 692);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(27, 13);
            this.lblTitle.TabIndex = 6;
            this.lblTitle.Text = "Title";
            // 
            // btnFinish
            // 
            this.btnFinish.Location = new System.Drawing.Point(1471, 736);
            this.btnFinish.Name = "btnFinish";
            this.btnFinish.Size = new System.Drawing.Size(124, 23);
            this.btnFinish.TabIndex = 7;
            this.btnFinish.Text = "Finish Reading";
            this.btnFinish.UseVisualStyleBackColor = true;
            // 
            // ComicView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1607, 771);
            this.Controls.Add(this.btnFinish);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lblPageNumber);
            this.Controls.Add(this.btnGoToPrevious);
            this.Controls.Add(this.btnGoToNext);
            this.Controls.Add(this.btnGoToLast);
            this.Controls.Add(this.btnGoToFirst);
            this.Controls.Add(this.pictureBox1);
            this.Name = "ComicView";
            this.Text = "ComicView";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnGoToFirst;
        private System.Windows.Forms.Button btnGoToLast;
        private System.Windows.Forms.Button btnGoToNext;
        private System.Windows.Forms.Button btnGoToPrevious;
        private System.Windows.Forms.Label lblPageNumber;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button btnFinish;
    }
}