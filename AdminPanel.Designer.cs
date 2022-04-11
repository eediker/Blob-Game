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
            this.AddNewUser = new System.Windows.Forms.Button();
            this.DeleteTheUser = new System.Windows.Forms.Button();
            this.EmailField = new System.Windows.Forms.TextBox();
            this.CountryField = new System.Windows.Forms.TextBox();
            this.CityField = new System.Windows.Forms.TextBox();
            this.AddressField = new System.Windows.Forms.TextBox();
            this.PhoneNumberField = new System.Windows.Forms.TextBox();
            this.NameSurnameField = new System.Windows.Forms.TextBox();
            this.PasswordField = new System.Windows.Forms.TextBox();
            this.UsernameField = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.UpdateUserInfo = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // AddNewUser
            // 
            this.AddNewUser.Location = new System.Drawing.Point(594, 295);
            this.AddNewUser.Name = "AddNewUser";
            this.AddNewUser.Size = new System.Drawing.Size(140, 30);
            this.AddNewUser.TabIndex = 36;
            this.AddNewUser.Text = "Add New User";
            this.AddNewUser.UseVisualStyleBackColor = true;
            this.AddNewUser.Click += new System.EventHandler(this.AddNewUser_Click);
            // 
            // DeleteTheUser
            // 
            this.DeleteTheUser.Location = new System.Drawing.Point(594, 389);
            this.DeleteTheUser.Name = "DeleteTheUser";
            this.DeleteTheUser.Size = new System.Drawing.Size(140, 30);
            this.DeleteTheUser.TabIndex = 38;
            this.DeleteTheUser.Text = "Delete The User";
            this.DeleteTheUser.UseVisualStyleBackColor = true;
            this.DeleteTheUser.Click += new System.EventHandler(this.DeleteAnUser_Click);
            // 
            // EmailField
            // 
            this.EmailField.Location = new System.Drawing.Point(416, 402);
            this.EmailField.Name = "EmailField";
            this.EmailField.Size = new System.Drawing.Size(123, 20);
            this.EmailField.TabIndex = 54;
            // 
            // CountryField
            // 
            this.CountryField.Location = new System.Drawing.Point(416, 367);
            this.CountryField.Name = "CountryField";
            this.CountryField.Size = new System.Drawing.Size(123, 20);
            this.CountryField.TabIndex = 53;
            // 
            // CityField
            // 
            this.CityField.Location = new System.Drawing.Point(416, 328);
            this.CityField.Name = "CityField";
            this.CityField.Size = new System.Drawing.Size(123, 20);
            this.CityField.TabIndex = 52;
            // 
            // AddressField
            // 
            this.AddressField.Location = new System.Drawing.Point(416, 295);
            this.AddressField.Name = "AddressField";
            this.AddressField.Size = new System.Drawing.Size(123, 20);
            this.AddressField.TabIndex = 51;
            // 
            // PhoneNumberField
            // 
            this.PhoneNumberField.Location = new System.Drawing.Point(169, 399);
            this.PhoneNumberField.Name = "PhoneNumberField";
            this.PhoneNumberField.Size = new System.Drawing.Size(123, 20);
            this.PhoneNumberField.TabIndex = 50;
            // 
            // NameSurnameField
            // 
            this.NameSurnameField.Location = new System.Drawing.Point(169, 367);
            this.NameSurnameField.Name = "NameSurnameField";
            this.NameSurnameField.Size = new System.Drawing.Size(123, 20);
            this.NameSurnameField.TabIndex = 49;
            // 
            // PasswordField
            // 
            this.PasswordField.Location = new System.Drawing.Point(169, 328);
            this.PasswordField.Name = "PasswordField";
            this.PasswordField.Size = new System.Drawing.Size(123, 20);
            this.PasswordField.TabIndex = 48;
            // 
            // UsernameField
            // 
            this.UsernameField.Location = new System.Drawing.Point(169, 295);
            this.UsernameField.Name = "UsernameField";
            this.UsernameField.Size = new System.Drawing.Size(123, 20);
            this.UsernameField.TabIndex = 47;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(348, 409);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(35, 13);
            this.label8.TabIndex = 46;
            this.label8.Text = "E-mail";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(345, 374);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(43, 13);
            this.label7.TabIndex = 45;
            this.label7.Text = "Country";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(348, 335);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(24, 13);
            this.label6.TabIndex = 44;
            this.label6.Text = "City";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(345, 295);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(45, 13);
            this.label5.TabIndex = 43;
            this.label5.Text = "Address";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(67, 406);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(78, 13);
            this.label4.TabIndex = 42;
            this.label4.Text = "Phone Number";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(65, 370);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 13);
            this.label3.TabIndex = 41;
            this.label3.Text = "Name-Surname";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(65, 328);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 40;
            this.label2.Text = "Password";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(65, 295);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 39;
            this.label1.Text = "Username";
            // 
            // UpdateUserInfo
            // 
            this.UpdateUserInfo.Location = new System.Drawing.Point(594, 344);
            this.UpdateUserInfo.Name = "UpdateUserInfo";
            this.UpdateUserInfo.Size = new System.Drawing.Size(140, 27);
            this.UpdateUserInfo.TabIndex = 55;
            this.UpdateUserInfo.Text = "Update User Info";
            this.UpdateUserInfo.UseVisualStyleBackColor = true;
            this.UpdateUserInfo.Click += new System.EventHandler(this.UpdateUserInfo_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(68, 25);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(666, 245);
            this.dataGridView1.TabIndex = 56;
            // 
            // AdminPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.UpdateUserInfo);
            this.Controls.Add(this.EmailField);
            this.Controls.Add(this.CountryField);
            this.Controls.Add(this.CityField);
            this.Controls.Add(this.AddressField);
            this.Controls.Add(this.PhoneNumberField);
            this.Controls.Add(this.NameSurnameField);
            this.Controls.Add(this.PasswordField);
            this.Controls.Add(this.UsernameField);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.DeleteTheUser);
            this.Controls.Add(this.AddNewUser);
            this.Name = "AdminPanel";
            this.Text = "AdminPanel";
            this.Load += new System.EventHandler(this.AdminPanel_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button AddNewUser;
        private System.Windows.Forms.Button DeleteTheUser;
        private System.Windows.Forms.TextBox EmailField;
        private System.Windows.Forms.TextBox CountryField;
        private System.Windows.Forms.TextBox CityField;
        private System.Windows.Forms.TextBox AddressField;
        private System.Windows.Forms.TextBox PhoneNumberField;
        private System.Windows.Forms.TextBox NameSurnameField;
        private System.Windows.Forms.TextBox PasswordField;
        private System.Windows.Forms.TextBox UsernameField;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button UpdateUserInfo;
        private System.Windows.Forms.DataGridView dataGridView1;
    }
}