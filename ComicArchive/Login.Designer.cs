namespace ComicArchive
{
    partial class Login
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
            this.btnSignIn = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.lblSign = new System.Windows.Forms.Label();
            this.lblUser = new System.Windows.Forms.Label();
            this.lblPass = new System.Windows.Forms.Label();
            this.txtBxUser = new System.Windows.Forms.TextBox();
            this.txtBxPass = new System.Windows.Forms.TextBox();
            this.txtBxConfPw = new System.Windows.Forms.TextBox();
            this.lblConfPw = new System.Windows.Forms.Label();
            this.lblDesc = new System.Windows.Forms.Label();
            this.lnkLblSignUp = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // btnSignIn
            // 
            this.btnSignIn.Location = new System.Drawing.Point(172, 275);
            this.btnSignIn.Name = "btnSignIn";
            this.btnSignIn.Size = new System.Drawing.Size(75, 23);
            this.btnSignIn.TabIndex = 0;
            this.btnSignIn.Text = "Sign In";
            this.btnSignIn.UseVisualStyleBackColor = true;
            this.btnSignIn.Click += new System.EventHandler(this.btnSignIn_Click);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(281, 275);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 23);
            this.btnExit.TabIndex = 2;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // lblSign
            // 
            this.lblSign.AutoSize = true;
            this.lblSign.Location = new System.Drawing.Point(169, 237);
            this.lblSign.Name = "lblSign";
            this.lblSign.Size = new System.Drawing.Size(122, 13);
            this.lblSign.TabIndex = 3;
            this.lblSign.Text = "Don\'t have an account?";
            // 
            // lblUser
            // 
            this.lblUser.AutoSize = true;
            this.lblUser.Location = new System.Drawing.Point(67, 69);
            this.lblUser.Name = "lblUser";
            this.lblUser.Size = new System.Drawing.Size(58, 13);
            this.lblUser.TabIndex = 4;
            this.lblUser.Text = "Username:";
            // 
            // lblPass
            // 
            this.lblPass.AutoSize = true;
            this.lblPass.Location = new System.Drawing.Point(67, 119);
            this.lblPass.Name = "lblPass";
            this.lblPass.Size = new System.Drawing.Size(56, 13);
            this.lblPass.TabIndex = 5;
            this.lblPass.Text = "Password:";
            // 
            // txtBxUser
            // 
            this.txtBxUser.Location = new System.Drawing.Point(172, 69);
            this.txtBxUser.Name = "txtBxUser";
            this.txtBxUser.Size = new System.Drawing.Size(263, 20);
            this.txtBxUser.TabIndex = 6;
            // 
            // txtBxPass
            // 
            this.txtBxPass.Location = new System.Drawing.Point(172, 119);
            this.txtBxPass.Name = "txtBxPass";
            this.txtBxPass.PasswordChar = '*';
            this.txtBxPass.Size = new System.Drawing.Size(263, 20);
            this.txtBxPass.TabIndex = 7;
            // 
            // txtBxConfPw
            // 
            this.txtBxConfPw.Enabled = false;
            this.txtBxConfPw.Location = new System.Drawing.Point(172, 173);
            this.txtBxConfPw.Name = "txtBxConfPw";
            this.txtBxConfPw.PasswordChar = '*';
            this.txtBxConfPw.Size = new System.Drawing.Size(263, 20);
            this.txtBxConfPw.TabIndex = 9;
            this.txtBxConfPw.Visible = false;
            // 
            // lblConfPw
            // 
            this.lblConfPw.AutoSize = true;
            this.lblConfPw.Enabled = false;
            this.lblConfPw.Location = new System.Drawing.Point(67, 173);
            this.lblConfPw.Name = "lblConfPw";
            this.lblConfPw.Size = new System.Drawing.Size(94, 13);
            this.lblConfPw.TabIndex = 8;
            this.lblConfPw.Text = "Confirm Password:";
            this.lblConfPw.Visible = false;
            // 
            // lblDesc
            // 
            this.lblDesc.AutoSize = true;
            this.lblDesc.Location = new System.Drawing.Point(26, 22);
            this.lblDesc.Name = "lblDesc";
            this.lblDesc.Size = new System.Drawing.Size(184, 13);
            this.lblDesc.TabIndex = 10;
            this.lblDesc.Text = "Welcome to the Comic Book Archive!";
            // 
            // lnkLblSignUp
            // 
            this.lnkLblSignUp.AutoSize = true;
            this.lnkLblSignUp.Location = new System.Drawing.Point(297, 237);
            this.lnkLblSignUp.Name = "lnkLblSignUp";
            this.lnkLblSignUp.Size = new System.Drawing.Size(69, 13);
            this.lnkLblSignUp.TabIndex = 11;
            this.lnkLblSignUp.TabStop = true;
            this.lnkLblSignUp.Text = "Sign up now.";
            this.lnkLblSignUp.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkLblSignUp_LinkClicked);
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(477, 360);
            this.Controls.Add(this.lnkLblSignUp);
            this.Controls.Add(this.lblDesc);
            this.Controls.Add(this.txtBxConfPw);
            this.Controls.Add(this.lblConfPw);
            this.Controls.Add(this.txtBxPass);
            this.Controls.Add(this.txtBxUser);
            this.Controls.Add(this.lblPass);
            this.Controls.Add(this.lblUser);
            this.Controls.Add(this.lblSign);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnSignIn);
            this.Name = "Login";
            this.Text = "Login";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSignIn;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Label lblSign;
        private System.Windows.Forms.Label lblUser;
        private System.Windows.Forms.Label lblPass;
        private System.Windows.Forms.TextBox txtBxUser;
        private System.Windows.Forms.TextBox txtBxPass;
        private System.Windows.Forms.TextBox txtBxConfPw;
        private System.Windows.Forms.Label lblConfPw;
        private System.Windows.Forms.Label lblDesc;
        private System.Windows.Forms.LinkLabel lnkLblSignUp;
    }
}