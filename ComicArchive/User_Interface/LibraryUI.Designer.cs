namespace ComicArchive.User_Interface
{
    partial class LibraryUI
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnRate = new System.Windows.Forms.Button();
            this.rdBtnRate5 = new System.Windows.Forms.RadioButton();
            this.rdBtnRate4 = new System.Windows.Forms.RadioButton();
            this.rdBtnRate3 = new System.Windows.Forms.RadioButton();
            this.rdBtnRate2 = new System.Windows.Forms.RadioButton();
            this.rdBtnRate1 = new System.Windows.Forms.RadioButton();
            this.lblMyLib = new System.Windows.Forms.Label();
            this.lstBxSavedComics = new System.Windows.Forms.ListBox();
            this.lstBxAvailableComics = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnImport = new System.Windows.Forms.Button();
            this.btnRemove = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnRate);
            this.groupBox1.Controls.Add(this.rdBtnRate5);
            this.groupBox1.Controls.Add(this.rdBtnRate4);
            this.groupBox1.Controls.Add(this.rdBtnRate3);
            this.groupBox1.Controls.Add(this.rdBtnRate2);
            this.groupBox1.Controls.Add(this.rdBtnRate1);
            this.groupBox1.Location = new System.Drawing.Point(630, 166);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(213, 140);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Rate";
            // 
            // btnRate
            // 
            this.btnRate.Location = new System.Drawing.Point(81, 20);
            this.btnRate.Name = "btnRate";
            this.btnRate.Size = new System.Drawing.Size(120, 23);
            this.btnRate.TabIndex = 5;
            this.btnRate.Text = "Rate";
            this.btnRate.UseVisualStyleBackColor = true;
            this.btnRate.Click += new System.EventHandler(this.btnRate_Click);
            // 
            // rdBtnRate5
            // 
            this.rdBtnRate5.AutoSize = true;
            this.rdBtnRate5.Location = new System.Drawing.Point(6, 111);
            this.rdBtnRate5.Name = "rdBtnRate5";
            this.rdBtnRate5.Size = new System.Drawing.Size(31, 17);
            this.rdBtnRate5.TabIndex = 4;
            this.rdBtnRate5.TabStop = true;
            this.rdBtnRate5.Text = "5";
            this.rdBtnRate5.UseVisualStyleBackColor = true;
            this.rdBtnRate5.CheckedChanged += new System.EventHandler(this.rdBtnRate_CheckedChanged);
            // 
            // rdBtnRate4
            // 
            this.rdBtnRate4.AutoSize = true;
            this.rdBtnRate4.Location = new System.Drawing.Point(6, 88);
            this.rdBtnRate4.Name = "rdBtnRate4";
            this.rdBtnRate4.Size = new System.Drawing.Size(31, 17);
            this.rdBtnRate4.TabIndex = 3;
            this.rdBtnRate4.TabStop = true;
            this.rdBtnRate4.Text = "4";
            this.rdBtnRate4.UseVisualStyleBackColor = true;
            this.rdBtnRate4.CheckedChanged += new System.EventHandler(this.rdBtnRate_CheckedChanged);
            // 
            // rdBtnRate3
            // 
            this.rdBtnRate3.AutoSize = true;
            this.rdBtnRate3.Location = new System.Drawing.Point(6, 65);
            this.rdBtnRate3.Name = "rdBtnRate3";
            this.rdBtnRate3.Size = new System.Drawing.Size(31, 17);
            this.rdBtnRate3.TabIndex = 2;
            this.rdBtnRate3.TabStop = true;
            this.rdBtnRate3.Text = "3";
            this.rdBtnRate3.UseVisualStyleBackColor = true;
            this.rdBtnRate3.CheckedChanged += new System.EventHandler(this.rdBtnRate_CheckedChanged);
            // 
            // rdBtnRate2
            // 
            this.rdBtnRate2.AutoSize = true;
            this.rdBtnRate2.Location = new System.Drawing.Point(6, 42);
            this.rdBtnRate2.Name = "rdBtnRate2";
            this.rdBtnRate2.Size = new System.Drawing.Size(31, 17);
            this.rdBtnRate2.TabIndex = 1;
            this.rdBtnRate2.TabStop = true;
            this.rdBtnRate2.Text = "2";
            this.rdBtnRate2.UseVisualStyleBackColor = true;
            this.rdBtnRate2.CheckedChanged += new System.EventHandler(this.rdBtnRate_CheckedChanged);
            // 
            // rdBtnRate1
            // 
            this.rdBtnRate1.AutoSize = true;
            this.rdBtnRate1.Location = new System.Drawing.Point(6, 19);
            this.rdBtnRate1.Name = "rdBtnRate1";
            this.rdBtnRate1.Size = new System.Drawing.Size(31, 17);
            this.rdBtnRate1.TabIndex = 0;
            this.rdBtnRate1.TabStop = true;
            this.rdBtnRate1.Text = "1";
            this.rdBtnRate1.UseVisualStyleBackColor = true;
            this.rdBtnRate1.CheckedChanged += new System.EventHandler(this.rdBtnRate_CheckedChanged);
            // 
            // lblMyLib
            // 
            this.lblMyLib.AutoSize = true;
            this.lblMyLib.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMyLib.Location = new System.Drawing.Point(139, 113);
            this.lblMyLib.Name = "lblMyLib";
            this.lblMyLib.Size = new System.Drawing.Size(190, 39);
            this.lblMyLib.TabIndex = 9;
            this.lblMyLib.Text = "My Library";
            // 
            // lstBxSavedComics
            // 
            this.lstBxSavedComics.FormattingEnabled = true;
            this.lstBxSavedComics.Location = new System.Drawing.Point(146, 166);
            this.lstBxSavedComics.Name = "lstBxSavedComics";
            this.lstBxSavedComics.Size = new System.Drawing.Size(461, 199);
            this.lstBxSavedComics.TabIndex = 8;
            this.lstBxSavedComics.SelectedIndexChanged += new System.EventHandler(this.lstBxSavedComics_SelectedIndexChanged);
            // 
            // lstBxAvailableComics
            // 
            this.lstBxAvailableComics.FormattingEnabled = true;
            this.lstBxAvailableComics.Location = new System.Drawing.Point(146, 465);
            this.lstBxAvailableComics.Name = "lstBxAvailableComics";
            this.lstBxAvailableComics.Size = new System.Drawing.Size(461, 199);
            this.lstBxAvailableComics.TabIndex = 13;
            this.lstBxAvailableComics.SelectedIndexChanged += new System.EventHandler(this.lstBxAvailableComics_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(139, 395);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(301, 39);
            this.label1.TabIndex = 14;
            this.label1.Text = "Available Comics";
            // 
            // btnImport
            // 
            this.btnImport.Enabled = false;
            this.btnImport.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnImport.Location = new System.Drawing.Point(457, 383);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(67, 51);
            this.btnImport.TabIndex = 15;
            this.btnImport.Text = "^";
            this.btnImport.UseVisualStyleBackColor = true;
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // btnRemove
            // 
            this.btnRemove.Enabled = false;
            this.btnRemove.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRemove.Location = new System.Drawing.Point(540, 383);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(67, 51);
            this.btnRemove.TabIndex = 16;
            this.btnRemove.Text = "v";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // LibraryUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1000, 800);
            this.ControlBox = false;
            this.Controls.Add(this.btnRemove);
            this.Controls.Add(this.btnImport);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lstBxAvailableComics);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lblMyLib);
            this.Controls.Add(this.lstBxSavedComics);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LibraryUI";
            this.Text = "Library";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.LibraryUI_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnRate;
        private System.Windows.Forms.RadioButton rdBtnRate5;
        private System.Windows.Forms.RadioButton rdBtnRate4;
        private System.Windows.Forms.RadioButton rdBtnRate3;
        private System.Windows.Forms.RadioButton rdBtnRate2;
        private System.Windows.Forms.RadioButton rdBtnRate1;
        private System.Windows.Forms.Label lblMyLib;
        private System.Windows.Forms.ListBox lstBxSavedComics;
        private System.Windows.Forms.ListBox lstBxAvailableComics;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnImport;
        private System.Windows.Forms.Button btnRemove;
    }
}