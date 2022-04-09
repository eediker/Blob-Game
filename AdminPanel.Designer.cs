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
            this.DeleteAnUser = new System.Windows.Forms.Button();
            this.UsernameField = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // ListUsers
            // 
            this.ListUsers.Location = new System.Drawing.Point(164, 46);
            this.ListUsers.Name = "ListUsers";
            this.ListUsers.Size = new System.Drawing.Size(140, 30);
            this.ListUsers.TabIndex = 35;
            this.ListUsers.Text = "List Users";
            this.ListUsers.UseVisualStyleBackColor = true;
            this.ListUsers.Click += new System.EventHandler(this.ListUsers_Click);
            // 
            // AddNewUser
            // 
            this.AddNewUser.Location = new System.Drawing.Point(396, 46);
            this.AddNewUser.Name = "AddNewUser";
            this.AddNewUser.Size = new System.Drawing.Size(140, 30);
            this.AddNewUser.TabIndex = 36;
            this.AddNewUser.Text = "Add New User";
            this.AddNewUser.UseVisualStyleBackColor = true;
            this.AddNewUser.Click += new System.EventHandler(this.AddNewUser_Click);
            // 
            // DeleteAnUser
            // 
            this.DeleteAnUser.Location = new System.Drawing.Point(284, 309);
            this.DeleteAnUser.Name = "DeleteAnUser";
            this.DeleteAnUser.Size = new System.Drawing.Size(140, 30);
            this.DeleteAnUser.TabIndex = 38;
            this.DeleteAnUser.Text = "Delete A User";
            this.DeleteAnUser.UseVisualStyleBackColor = true;
            this.DeleteAnUser.Click += new System.EventHandler(this.DeleteAnUser_Click);
            // 
            // UsernameField
            // 
            this.UsernameField.Location = new System.Drawing.Point(284, 261);
            this.UsernameField.Name = "UsernameField";
            this.UsernameField.Size = new System.Drawing.Size(140, 20);
            this.UsernameField.TabIndex = 39;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(251, 223);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(220, 13);
            this.label1.TabIndex = 40;
            this.label1.Text = "Enter the username which you want to delete";
            // 
            // AdminPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.UsernameField);
            this.Controls.Add(this.DeleteAnUser);
            this.Controls.Add(this.AddNewUser);
            this.Controls.Add(this.ListUsers);
            this.Name = "AdminPanel";
            this.Text = "AdminPanel";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button ListUsers;
        private System.Windows.Forms.Button AddNewUser;
        private System.Windows.Forms.Button DeleteAnUser;
        private System.Windows.Forms.TextBox UsernameField;
        private System.Windows.Forms.Label label1;
    }
}