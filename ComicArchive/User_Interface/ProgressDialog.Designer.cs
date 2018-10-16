namespace ComicArchive
{
    partial class ProgressDialog
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
            this.loadProgBar = new System.Windows.Forms.ProgressBar();
            this.lbl_info = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // loadProgBar
            // 
            this.loadProgBar.Location = new System.Drawing.Point(12, 25);
            this.loadProgBar.Name = "loadProgBar";
            this.loadProgBar.Size = new System.Drawing.Size(379, 20);
            this.loadProgBar.TabIndex = 0;
            // 
            // lbl_info
            // 
            this.lbl_info.AutoSize = true;
            this.lbl_info.Location = new System.Drawing.Point(143, 72);
            this.lbl_info.Name = "lbl_info";
            this.lbl_info.Size = new System.Drawing.Size(108, 13);
            this.lbl_info.TabIndex = 1;
            this.lbl_info.Text = "Loading your comic...";
            // 
            // ProgressDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(403, 132);
            this.Controls.Add(this.lbl_info);
            this.Controls.Add(this.loadProgBar);
            this.Name = "ProgressDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Loading...";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ProgressBar loadProgBar;
        private System.Windows.Forms.Label lbl_info;
    }
}