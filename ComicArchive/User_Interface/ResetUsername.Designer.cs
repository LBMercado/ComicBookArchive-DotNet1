namespace ComicArchive.User_Interface
{
    partial class ResetUsername
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
            this.btnCancel = new System.Windows.Forms.Button();
            this.lbl_Info = new System.Windows.Forms.Label();
            this.btnVerify = new System.Windows.Forms.Button();
            this.lbl_Input = new System.Windows.Forms.Label();
            this.txtBxInput = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(224, 154);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(150, 25);
            this.btnCancel.TabIndex = 22;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // lbl_Info
            // 
            this.lbl_Info.AutoSize = true;
            this.lbl_Info.ForeColor = System.Drawing.Color.Black;
            this.lbl_Info.Location = new System.Drawing.Point(22, 24);
            this.lbl_Info.Name = "lbl_Info";
            this.lbl_Info.Size = new System.Drawing.Size(162, 13);
            this.lbl_Info.TabIndex = 21;
            this.lbl_Info.Text = "Enter your password to continue:";
            // 
            // btnVerify
            // 
            this.btnVerify.Location = new System.Drawing.Point(25, 154);
            this.btnVerify.Name = "btnVerify";
            this.btnVerify.Size = new System.Drawing.Size(150, 25);
            this.btnVerify.TabIndex = 16;
            this.btnVerify.Text = "Change Password";
            this.btnVerify.UseVisualStyleBackColor = true;
            this.btnVerify.Click += new System.EventHandler(this.btnVerify_Click);
            // 
            // lbl_Input
            // 
            this.lbl_Input.AutoSize = true;
            this.lbl_Input.Location = new System.Drawing.Point(22, 68);
            this.lbl_Input.Name = "lbl_Input";
            this.lbl_Input.Size = new System.Drawing.Size(59, 13);
            this.lbl_Input.TabIndex = 17;
            this.lbl_Input.Text = "Password: ";
            // 
            // txtBxInput
            // 
            this.txtBxInput.Location = new System.Drawing.Point(179, 65);
            this.txtBxInput.Name = "txtBxInput";
            this.txtBxInput.PasswordChar = '*';
            this.txtBxInput.Size = new System.Drawing.Size(195, 20);
            this.txtBxInput.TabIndex = 18;
            this.txtBxInput.TextChanged += new System.EventHandler(this.txtBxInput_TextChanged);
            this.txtBxInput.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtBxInput_KeyDown);
            // 
            // ResetUsername
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(405, 218);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.lbl_Info);
            this.Controls.Add(this.btnVerify);
            this.Controls.Add(this.lbl_Input);
            this.Controls.Add(this.txtBxInput);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ResetUsername";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Reset Username";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ResetUsername_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lbl_Info;
        private System.Windows.Forms.Button btnVerify;
        private System.Windows.Forms.Label lbl_Input;
        private System.Windows.Forms.TextBox txtBxInput;
    }
}