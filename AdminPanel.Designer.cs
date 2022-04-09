namespace OOP_LAB1
{
    partial class AdminPanel
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
            this.ListUsers = new System.Windows.Forms.Button();
            this.AddNewUser = new System.Windows.Forms.Button();
            this.UpdateUserInfo = new System.Windows.Forms.Button();
            this.DeleteAnUser = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ListUsers
            // 
            this.ListUsers.Location = new System.Drawing.Point(249, 104);
            this.ListUsers.Name = "ListUsers";
            this.ListUsers.Size = new System.Drawing.Size(140, 30);
            this.ListUsers.TabIndex = 35;
            this.ListUsers.Text = "List Users";
            this.ListUsers.UseVisualStyleBackColor = true;
            this.ListUsers.Click += new System.EventHandler(this.ListUsers_Click);
            // 
            // AddNewUser
            // 
            this.AddNewUser.Location = new System.Drawing.Point(249, 241);
            this.AddNewUser.Name = "AddNewUser";
            this.AddNewUser.Size = new System.Drawing.Size(140, 30);
            this.AddNewUser.TabIndex = 36;
            this.AddNewUser.Text = "Add New User";
            this.AddNewUser.UseVisualStyleBackColor = true;
            this.AddNewUser.Click += new System.EventHandler(this.AddNewUser_Click);
            // 
            // UpdateUserInfo
            // 
            this.UpdateUserInfo.Location = new System.Drawing.Point(249, 174);
            this.UpdateUserInfo.Name = "UpdateUserInfo";
            this.UpdateUserInfo.Size = new System.Drawing.Size(140, 30);
            this.UpdateUserInfo.TabIndex = 37;
            this.UpdateUserInfo.Text = "Update User Info";
            this.UpdateUserInfo.UseVisualStyleBackColor = true;
            // 
            // DeleteAnUser
            // 
            this.DeleteAnUser.Location = new System.Drawing.Point(249, 318);
            this.DeleteAnUser.Name = "DeleteAnUser";
            this.DeleteAnUser.Size = new System.Drawing.Size(140, 30);
            this.DeleteAnUser.TabIndex = 38;
            this.DeleteAnUser.Text = "Delete A User";
            this.DeleteAnUser.UseVisualStyleBackColor = true;
            // 
            // AdminPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.DeleteAnUser);
            this.Controls.Add(this.UpdateUserInfo);
            this.Controls.Add(this.AddNewUser);
            this.Controls.Add(this.ListUsers);
            this.Name = "AdminPanel";
            this.Text = "AdminPanel";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button ListUsers;
        private System.Windows.Forms.Button AddNewUser;
        private System.Windows.Forms.Button UpdateUserInfo;
        private System.Windows.Forms.Button DeleteAnUser;
    }
}