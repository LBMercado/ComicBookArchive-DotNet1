namespace ComicArchive.User_Interface
{
    partial class Admin_AddUser
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
            this.txtBxName = new System.Windows.Forms.TextBox();
            this.lblName = new System.Windows.Forms.Label();
            this.lblPassword = new System.Windows.Forms.Label();
            this.txtBxPassword = new System.Windows.Forms.TextBox();
            this.txtBxPasswordConf = new System.Windows.Forms.TextBox();
            this.lblPasswordConf = new System.Windows.Forms.Label();
            this.chkBxIsAdmin = new System.Windows.Forms.CheckBox();
            this.btnAddUser = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lbl_Info = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtBxName
            // 
            this.txtBxName.Location = new System.Drawing.Point(224, 27);
            this.txtBxName.Name = "txtBxName";
            this.txtBxName.Size = new System.Drawing.Size(354, 20);
            this.txtBxName.TabIndex = 0;
            this.txtBxName.TextChanged += new System.EventHandler(this.txtBxInputs_TextChanged);
            this.txtBxName.Leave += new System.EventHandler(this.txtBxInputs_TextChanged);
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(43, 34);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(38, 13);
            this.lblName.TabIndex = 1;
            this.lblName.Text = "Name:";
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Location = new System.Drawing.Point(43, 76);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(56, 13);
            this.lblPassword.TabIndex = 2;
            this.lblPassword.Text = "Password:";
            // 
            // txtBxPassword
            // 
            this.txtBxPassword.Location = new System.Drawing.Point(224, 69);
            this.txtBxPassword.Name = "txtBxPassword";
            this.txtBxPassword.PasswordChar = '*';
            this.txtBxPassword.Size = new System.Drawing.Size(354, 20);
            this.txtBxPassword.TabIndex = 3;
            this.txtBxPassword.TextChanged += new System.EventHandler(this.txtBxInputs_TextChanged);
            this.txtBxPassword.Leave += new System.EventHandler(this.txtBxInputs_TextChanged);
            // 
            // txtBxPasswordConf
            // 
            this.txtBxPasswordConf.Location = new System.Drawing.Point(224, 119);
            this.txtBxPasswordConf.Name = "txtBxPasswordConf";
            this.txtBxPasswordConf.PasswordChar = '*';
            this.txtBxPasswordConf.Size = new System.Drawing.Size(354, 20);
            this.txtBxPasswordConf.TabIndex = 4;
            this.txtBxPasswordConf.TextChanged += new System.EventHandler(this.txtBxInputs_TextChanged);
            this.txtBxPasswordConf.Leave += new System.EventHandler(this.txtBxInputs_TextChanged);
            // 
            // lblPasswordConf
            // 
            this.lblPasswordConf.AutoSize = true;
            this.lblPasswordConf.Location = new System.Drawing.Point(43, 126);
            this.lblPasswordConf.Name = "lblPasswordConf";
            this.lblPasswordConf.Size = new System.Drawing.Size(100, 13);
            this.lblPasswordConf.TabIndex = 5;
            this.lblPasswordConf.Text = "Re-enter Password:";
            // 
            // chkBxIsAdmin
            // 
            this.chkBxIsAdmin.AutoSize = true;
            this.chkBxIsAdmin.Location = new System.Drawing.Point(224, 154);
            this.chkBxIsAdmin.Name = "chkBxIsAdmin";
            this.chkBxIsAdmin.Size = new System.Drawing.Size(103, 17);
            this.chkBxIsAdmin.TabIndex = 6;
            this.chkBxIsAdmin.Text = "Create as Admin";
            this.chkBxIsAdmin.UseVisualStyleBackColor = true;
            this.chkBxIsAdmin.CheckedChanged += new System.EventHandler(this.chkBxIsAdmin_CheckedChanged);
            // 
            // btnAddUser
            // 
            this.btnAddUser.Location = new System.Drawing.Point(224, 243);
            this.btnAddUser.Name = "btnAddUser";
            this.btnAddUser.Size = new System.Drawing.Size(175, 39);
            this.btnAddUser.TabIndex = 7;
            this.btnAddUser.Text = "Add User";
            this.btnAddUser.UseVisualStyleBackColor = true;
            this.btnAddUser.Click += new System.EventHandler(this.btnAddUser_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.panel1.Controls.Add(this.btnCancel);
            this.panel1.Controls.Add(this.lbl_Info);
            this.panel1.Controls.Add(this.lblName);
            this.panel1.Controls.Add(this.btnAddUser);
            this.panel1.Controls.Add(this.lblPassword);
            this.panel1.Controls.Add(this.chkBxIsAdmin);
            this.panel1.Controls.Add(this.lblPasswordConf);
            this.panel1.Controls.Add(this.txtBxPasswordConf);
            this.panel1.Controls.Add(this.txtBxName);
            this.panel1.Controls.Add(this.txtBxPassword);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(614, 299);
            this.panel1.TabIndex = 8;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(403, 243);
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
            this.lbl_Info.Location = new System.Drawing.Point(221, 198);
            this.lbl_Info.Name = "lbl_Info";
            this.lbl_Info.Size = new System.Drawing.Size(66, 13);
            this.lbl_Info.TabIndex = 8;
            this.lbl_Info.Text = "NULL_INFO";
            // 
            // Admin_AddUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(638, 323);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Admin_AddUser";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add User";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Admin_AddUser_FormClosing);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtBxName;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.TextBox txtBxPassword;
        private System.Windows.Forms.TextBox txtBxPasswordConf;
        private System.Windows.Forms.Label lblPasswordConf;
        private System.Windows.Forms.CheckBox chkBxIsAdmin;
        private System.Windows.Forms.Button btnAddUser;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lbl_Info;
        private System.Windows.Forms.Button btnCancel;
    }
}