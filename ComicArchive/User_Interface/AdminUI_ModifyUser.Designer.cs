namespace ComicArchive.User_Interface
{
    partial class AdminUI_ModifyUser
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
            this.panelUserDetails = new System.Windows.Forms.Panel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lbl_Info = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.btnModifyUser = new System.Windows.Forms.Button();
            this.lblPassword = new System.Windows.Forms.Label();
            this.txtBxName = new System.Windows.Forms.TextBox();
            this.txtBxPassword = new System.Windows.Forms.TextBox();
            this.panelUserDetails.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelUserDetails
            // 
            this.panelUserDetails.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.panelUserDetails.Controls.Add(this.btnCancel);
            this.panelUserDetails.Controls.Add(this.lbl_Info);
            this.panelUserDetails.Controls.Add(this.lblName);
            this.panelUserDetails.Controls.Add(this.btnModifyUser);
            this.panelUserDetails.Controls.Add(this.lblPassword);
            this.panelUserDetails.Controls.Add(this.txtBxName);
            this.panelUserDetails.Controls.Add(this.txtBxPassword);
            this.panelUserDetails.Location = new System.Drawing.Point(12, 12);
            this.panelUserDetails.Name = "panelUserDetails";
            this.panelUserDetails.Size = new System.Drawing.Size(585, 219);
            this.panelUserDetails.TabIndex = 9;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(375, 151);
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
            this.lbl_Info.Location = new System.Drawing.Point(193, 116);
            this.lbl_Info.Name = "lbl_Info";
            this.lbl_Info.Size = new System.Drawing.Size(66, 13);
            this.lbl_Info.TabIndex = 8;
            this.lbl_Info.Text = "NULL_INFO";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(15, 32);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(38, 13);
            this.lblName.TabIndex = 1;
            this.lblName.Text = "Name:";
            // 
            // btnModifyUser
            // 
            this.btnModifyUser.Location = new System.Drawing.Point(196, 151);
            this.btnModifyUser.Name = "btnModifyUser";
            this.btnModifyUser.Size = new System.Drawing.Size(175, 39);
            this.btnModifyUser.TabIndex = 7;
            this.btnModifyUser.Text = "Modify User";
            this.btnModifyUser.UseVisualStyleBackColor = true;
            this.btnModifyUser.Click += new System.EventHandler(this.btnModifyUser_Click);
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Location = new System.Drawing.Point(15, 81);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(56, 13);
            this.lblPassword.TabIndex = 2;
            this.lblPassword.Text = "Password:";
            // 
            // txtBxName
            // 
            this.txtBxName.Location = new System.Drawing.Point(196, 25);
            this.txtBxName.Name = "txtBxName";
            this.txtBxName.Size = new System.Drawing.Size(354, 20);
            this.txtBxName.TabIndex = 0;
            this.txtBxName.TextChanged += new System.EventHandler(this.NameAndPassword_TextChanged);
            // 
            // txtBxPassword
            // 
            this.txtBxPassword.Location = new System.Drawing.Point(196, 74);
            this.txtBxPassword.Name = "txtBxPassword";
            this.txtBxPassword.Size = new System.Drawing.Size(354, 20);
            this.txtBxPassword.TabIndex = 3;
            this.txtBxPassword.TextChanged += new System.EventHandler(this.NameAndPassword_TextChanged);
            // 
            // Admin_ModifyUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(613, 260);
            this.Controls.Add(this.panelUserDetails);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(629, 299);
            this.Name = "Admin_ModifyUser";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Modify User";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Admin_ModifyUser_FormClosing);
            this.Load += new System.EventHandler(this.Admin_ModifyUser_Load);
            this.panelUserDetails.ResumeLayout(false);
            this.panelUserDetails.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelUserDetails;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lbl_Info;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Button btnModifyUser;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.TextBox txtBxName;
        private System.Windows.Forms.TextBox txtBxPassword;
    }
}