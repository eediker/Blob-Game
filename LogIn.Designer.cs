namespace OOP_LAB1
{
    partial class LogIn
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.UsernameField = new System.Windows.Forms.TextBox();
            this.PasswordField = new System.Windows.Forms.TextBox();
            this.LogInButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.label1.Location = new System.Drawing.Point(238, 166);
            this.label1.Name = "label1";
            this.label1.Padding = new System.Windows.Forms.Padding(5);
            this.label1.Size = new System.Drawing.Size(71, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Username :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.label2.Location = new System.Drawing.Point(238, 205);
            this.label2.Name = "label2";
            this.label2.Padding = new System.Windows.Forms.Padding(5);
            this.label2.Size = new System.Drawing.Size(72, 23);
            this.label2.TabIndex = 1;
            this.label2.Text = "Password : ";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // UsernameField
            // 
            this.UsernameField.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.UsernameField.Location = new System.Drawing.Point(327, 166);
            this.UsernameField.Name = "UsernameField";
            this.UsernameField.Size = new System.Drawing.Size(147, 20);
            this.UsernameField.TabIndex = 2;
            this.UsernameField.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // PasswordField
            // 
            this.PasswordField.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.PasswordField.Location = new System.Drawing.Point(327, 205);
            this.PasswordField.Name = "PasswordField";
            this.PasswordField.PasswordChar = '*';
            this.PasswordField.Size = new System.Drawing.Size(147, 20);
            this.PasswordField.TabIndex = 3;
            this.PasswordField.TextChanged += new System.EventHandler(this.PasswordField_TextChanged);
            // 
            // LogInButton
            // 
            this.LogInButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.LogInButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LogInButton.Location = new System.Drawing.Point(327, 264);
            this.LogInButton.Name = "LogInButton";
            this.LogInButton.Size = new System.Drawing.Size(147, 23);
            this.LogInButton.TabIndex = 4;
            this.LogInButton.Text = "LOG-IN";
            this.LogInButton.UseVisualStyleBackColor = true;
            this.LogInButton.Click += new System.EventHandler(this.LogInButton_Click);
            this.LogInButton.KeyDown += new System.Windows.Forms.KeyEventHandler(this.LogInButton_KeyDown);
            // 
            // LogIn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.LogInButton);
            this.Controls.Add(this.PasswordField);
            this.Controls.Add(this.UsernameField);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.Name = "LogIn";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "LOG-IN PAGE";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox UsernameField;
        private System.Windows.Forms.TextBox PasswordField;
        private System.Windows.Forms.Button LogInButton;
    }
}

