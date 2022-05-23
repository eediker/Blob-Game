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
            this.label2 = new System.Windows.Forms.Label();
            this.ShowScore = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // SettingsButton
            // 
            this.SettingsButton.Location = new System.Drawing.Point(1676, 50);
            this.SettingsButton.Margin = new System.Windows.Forms.Padding(4);
            this.SettingsButton.Name = "SettingsButton";
            this.SettingsButton.Size = new System.Drawing.Size(159, 28);
            this.SettingsButton.TabIndex = 0;
            this.SettingsButton.Text = "Settings";
            this.SettingsButton.UseVisualStyleBackColor = true;
            this.SettingsButton.Click += new System.EventHandler(this.SettingsButton_Click);
            // 
            // ShowUserProfile
            // 
            this.ShowUserProfile.Location = new System.Drawing.Point(1676, 15);
            this.ShowUserProfile.Margin = new System.Windows.Forms.Padding(4);
            this.ShowUserProfile.Name = "ShowUserProfile";
            this.ShowUserProfile.Size = new System.Drawing.Size(159, 28);
            this.ShowUserProfile.TabIndex = 1;
            this.ShowUserProfile.Text = "Profile";
            this.ShowUserProfile.UseVisualStyleBackColor = true;
            this.ShowUserProfile.Click += new System.EventHandler(this.ShowUserProfile_Click);
            // 
            // AdminPanelButton
            // 
            this.AdminPanelButton.Location = new System.Drawing.Point(1673, 122);
            this.AdminPanelButton.Margin = new System.Windows.Forms.Padding(4);
            this.AdminPanelButton.Name = "AdminPanelButton";
            this.AdminPanelButton.Size = new System.Drawing.Size(161, 28);
            this.AdminPanelButton.TabIndex = 2;
            this.AdminPanelButton.Text = "Admin Panel";
            this.AdminPanelButton.UseVisualStyleBackColor = true;
            this.AdminPanelButton.Click += new System.EventHandler(this.AdminPanelButton_Click);
            // 
            // AboutScreenButton
            // 
            this.AboutScreenButton.Location = new System.Drawing.Point(1676, 86);
            this.AboutScreenButton.Margin = new System.Windows.Forms.Padding(4);
            this.AboutScreenButton.Name = "AboutScreenButton";
            this.AboutScreenButton.Size = new System.Drawing.Size(159, 28);
            this.AboutScreenButton.TabIndex = 3;
            this.AboutScreenButton.Text = "About Screen";
            this.AboutScreenButton.UseVisualStyleBackColor = true;
            this.AboutScreenButton.Click += new System.EventHandler(this.AboutScreenButton_Click);
            // 
            // ShowBestScore
            // 
            this.ShowBestScore.AutoSize = true;
            this.ShowBestScore.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.ShowBestScore.Location = new System.Drawing.Point(1689, 235);
            this.ShowBestScore.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.ShowBestScore.Name = "ShowBestScore";
            this.ShowBestScore.Size = new System.Drawing.Size(137, 58);
            this.ShowBestScore.TabIndex = 4;
            this.ShowBestScore.Text = "none";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(1676, 203);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(147, 31);
            this.label1.TabIndex = 5;
            this.label1.Text = "Best Score";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.Location = new System.Drawing.Point(1693, 316);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 31);
            this.label2.TabIndex = 6;
            this.label2.Text = "Score";
            // 
            // ShowScore
            // 
            this.ShowScore.AutoSize = true;
            this.ShowScore.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.ShowScore.Location = new System.Drawing.Point(1689, 361);
            this.ShowScore.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.ShowScore.Name = "ShowScore";
            this.ShowScore.Size = new System.Drawing.Size(137, 58);
            this.ShowScore.TabIndex = 7;
            this.ShowScore.Text = "none";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(1676, 158);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(158, 23);
            this.button1.TabIndex = 8;
            this.button1.Text = "Logout";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // MainGame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1853, 800);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.ShowScore);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ShowBestScore);
            this.Controls.Add(this.AboutScreenButton);
            this.Controls.Add(this.AdminPanelButton);
            this.Controls.Add(this.ShowUserProfile);
            this.Controls.Add(this.SettingsButton);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "MainGame";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Game";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainGame_FormClosing);
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
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label ShowScore;
        private System.Windows.Forms.Button button1;
    }
}