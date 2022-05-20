namespace OOP_LAB1
{
    partial class MainGame
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
            this.SettingsButton = new System.Windows.Forms.Button();
            this.ShowUserProfile = new System.Windows.Forms.Button();
            this.AdminPanelButton = new System.Windows.Forms.Button();
            this.AboutScreenButton = new System.Windows.Forms.Button();
            this.ShowBestScore = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // SettingsButton
            // 
            this.SettingsButton.Location = new System.Drawing.Point(1257, 41);
            this.SettingsButton.Name = "SettingsButton";
            this.SettingsButton.Size = new System.Drawing.Size(119, 23);
            this.SettingsButton.TabIndex = 0;
            this.SettingsButton.Text = "Settings";
            this.SettingsButton.UseVisualStyleBackColor = true;
            this.SettingsButton.Click += new System.EventHandler(this.SettingsButton_Click);
            // 
            // ShowUserProfile
            // 
            this.ShowUserProfile.Location = new System.Drawing.Point(1257, 12);
            this.ShowUserProfile.Name = "ShowUserProfile";
            this.ShowUserProfile.Size = new System.Drawing.Size(119, 23);
            this.ShowUserProfile.TabIndex = 1;
            this.ShowUserProfile.Text = "Profile";
            this.ShowUserProfile.UseVisualStyleBackColor = true;
            this.ShowUserProfile.Click += new System.EventHandler(this.ShowUserProfile_Click);
            // 
            // AdminPanelButton
            // 
            this.AdminPanelButton.Location = new System.Drawing.Point(1255, 99);
            this.AdminPanelButton.Name = "AdminPanelButton";
            this.AdminPanelButton.Size = new System.Drawing.Size(121, 23);
            this.AdminPanelButton.TabIndex = 2;
            this.AdminPanelButton.Text = "Admin Panel";
            this.AdminPanelButton.UseVisualStyleBackColor = true;
            this.AdminPanelButton.Click += new System.EventHandler(this.AdminPanelButton_Click);
            // 
            // AboutScreenButton
            // 
            this.AboutScreenButton.Location = new System.Drawing.Point(1257, 70);
            this.AboutScreenButton.Name = "AboutScreenButton";
            this.AboutScreenButton.Size = new System.Drawing.Size(119, 23);
            this.AboutScreenButton.TabIndex = 3;
            this.AboutScreenButton.Text = "About Screen";
            this.AboutScreenButton.UseVisualStyleBackColor = true;
            this.AboutScreenButton.Click += new System.EventHandler(this.AboutScreenButton_Click);
            // 
            // ShowBestScore
            // 
            this.ShowBestScore.AutoSize = true;
            this.ShowBestScore.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.ShowBestScore.Location = new System.Drawing.Point(1267, 191);
            this.ShowBestScore.Name = "ShowBestScore";
            this.ShowBestScore.Size = new System.Drawing.Size(109, 46);
            this.ShowBestScore.TabIndex = 4;
            this.ShowBestScore.Text = "none";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(1257, 165);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(119, 26);
            this.label1.TabIndex = 5;
            this.label1.Text = "Best Score";
            // 
            // MainGame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1390, 650);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ShowBestScore);
            this.Controls.Add(this.AboutScreenButton);
            this.Controls.Add(this.AdminPanelButton);
            this.Controls.Add(this.ShowUserProfile);
            this.Controls.Add(this.SettingsButton);
            this.Name = "MainGame";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Game";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button SettingsButton;
        private System.Windows.Forms.Button ShowUserProfile;
        private System.Windows.Forms.Button AdminPanelButton;
        private System.Windows.Forms.Button AboutScreenButton;
        private System.Windows.Forms.Label ShowBestScore;
        private System.Windows.Forms.Label label1;
    }
}