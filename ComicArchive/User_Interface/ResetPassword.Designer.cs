namespace ComicArchive.User_Interface
{
    partial class ResetPassword
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
            this.btnChangePassword = new System.Windows.Forms.Button();
            this.lblNewPwConf = new System.Windows.Forms.Label();
            this.lblOldPw = new System.Windows.Forms.Label();
            this.txtBxPw1 = new System.Windows.Forms.TextBox();
            this.txtBxPw2 = new System.Windows.Forms.TextBox();
            this.lblInfo = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnChangePassword
            // 
            this.btnChangePassword.Location = new System.Drawing.Point(26, 153);
            this.btnChangePassword.Name = "btnChangePassword";
            this.btnChangePassword.Size = new System.Drawing.Size(150, 25);
            this.btnChangePassword.TabIndex = 7;
            this.btnChangePassword.Text = "Change Password";
            this.btnChangePassword.UseVisualStyleBackColor = true;
            this.btnChangePassword.Click += new System.EventHandler(this.btnChangePassword_Click);
            // 
            // lblNewPwConf
            // 
            this.lblNewPwConf.AutoSize = true;
            this.lblNewPwConf.Location = new System.Drawing.Point(23, 111);
            this.lblNewPwConf.Name = "lblNewPwConf";
            this.lblNewPwConf.Size = new System.Drawing.Size(100, 13);
            this.lblNewPwConf.TabIndex = 12;
            this.lblNewPwConf.Text = "Re-enter Password:";
            this.lblNewPwConf.Visible = false;
            // 
            // lblOldPw
            // 
            this.lblOldPw.AutoSize = true;
            this.lblOldPw.Location = new System.Drawing.Point(23, 67);
            this.lblOldPw.Name = "lblOldPw";
            this.lblOldPw.Size = new System.Drawing.Size(56, 13);
            this.lblOldPw.TabIndex = 8;
            this.lblOldPw.Text = "Password:";
            // 
            // txtBxPw1
            // 
            this.txtBxPw1.Location = new System.Drawing.Point(180, 64);
            this.txtBxPw1.Name = "txtBxPw1";
            this.txtBxPw1.PasswordChar = '*';
            this.txtBxPw1.Size = new System.Drawing.Size(195, 20);
            this.txtBxPw1.TabIndex = 10;
            this.txtBxPw1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtBxPw1_KeyDown);
            // 
            // txtBxPw2
            // 
            this.txtBxPw2.Location = new System.Drawing.Point(180, 108);
            this.txtBxPw2.Name = "txtBxPw2";
            this.txtBxPw2.PasswordChar = '*';
            this.txtBxPw2.Size = new System.Drawing.Size(195, 20);
            this.txtBxPw2.TabIndex = 13;
            this.txtBxPw2.Visible = false;
            this.txtBxPw2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtBxPw2_KeyDown);
            // 
            // lblInfo
            // 
            this.lblInfo.AutoSize = true;
            this.lblInfo.Location = new System.Drawing.Point(23, 23);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(179, 13);
            this.lblInfo.TabIndex = 14;
            this.lblInfo.Text = "Enter your old password to continue:";
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(225, 153);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(150, 25);
            this.btnCancel.TabIndex = 15;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // ResetPassword
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(405, 218);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.lblInfo);
            this.Controls.Add(this.btnChangePassword);
            this.Controls.Add(this.lblNewPwConf);
            this.Controls.Add(this.lblOldPw);
            this.Controls.Add(this.txtBxPw1);
            this.Controls.Add(this.txtBxPw2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ResetPassword";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Reset Password";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ResetPassword_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnChangePassword;
        private System.Windows.Forms.Label lblNewPwConf;
        private System.Windows.Forms.Label lblOldPw;
        private System.Windows.Forms.TextBox txtBxPw1;
        private System.Windows.Forms.TextBox txtBxPw2;
        private System.Windows.Forms.Label lblInfo;
        private System.Windows.Forms.Button btnCancel;
    }
}