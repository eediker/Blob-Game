namespace OOP_LAB1
{
    partial class Settings
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
            this.DifficultyLevel = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.Height = new System.Windows.Forms.TextBox();
            this.Width = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.Custom = new System.Windows.Forms.RadioButton();
            this.Hard = new System.Windows.Forms.RadioButton();
            this.Normal = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.Easy = new System.Windows.Forms.RadioButton();
            this.Shapes = new System.Windows.Forms.Panel();
            this.Round = new System.Windows.Forms.CheckBox();
            this.Triangle = new System.Windows.Forms.CheckBox();
            this.Square = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.Save = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.Yellow = new System.Windows.Forms.CheckBox();
            this.Red = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.Blue = new System.Windows.Forms.CheckBox();
            this.DifficultyLevel.SuspendLayout();
            this.Shapes.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // DifficultyLevel
            // 
            this.DifficultyLevel.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.DifficultyLevel.Controls.Add(this.label4);
            this.DifficultyLevel.Controls.Add(this.Height);
            this.DifficultyLevel.Controls.Add(this.Width);
            this.DifficultyLevel.Controls.Add(this.label3);
            this.DifficultyLevel.Controls.Add(this.Custom);
            this.DifficultyLevel.Controls.Add(this.Hard);
            this.DifficultyLevel.Controls.Add(this.Normal);
            this.DifficultyLevel.Controls.Add(this.label1);
            this.DifficultyLevel.Controls.Add(this.Easy);
            this.DifficultyLevel.Location = new System.Drawing.Point(61, 117);
            this.DifficultyLevel.Name = "DifficultyLevel";
            this.DifficultyLevel.Size = new System.Drawing.Size(200, 188);
            this.DifficultyLevel.TabIndex = 0;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(112, 142);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Height";
            this.label4.Visible = false;
            // 
            // Height
            // 
            this.Height.Location = new System.Drawing.Point(105, 158);
            this.Height.Name = "Height";
            this.Height.Size = new System.Drawing.Size(52, 20);
            this.Height.TabIndex = 7;
            this.Height.Text = "9";
            this.Height.Visible = false;
            // 
            // Width
            // 
            this.Width.Location = new System.Drawing.Point(48, 158);
            this.Width.Name = "Width";
            this.Width.Size = new System.Drawing.Size(51, 20);
            this.Width.TabIndex = 6;
            this.Width.Text = "9";
            this.Width.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(58, 142);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Width";
            this.label3.Visible = false;
            // 
            // Custom
            // 
            this.Custom.AutoSize = true;
            this.Custom.Location = new System.Drawing.Point(15, 110);
            this.Custom.Name = "Custom";
            this.Custom.Size = new System.Drawing.Size(60, 17);
            this.Custom.TabIndex = 4;
            this.Custom.TabStop = true;
            this.Custom.Text = "Custom";
            this.Custom.UseVisualStyleBackColor = true;
            this.Custom.CheckedChanged += new System.EventHandler(this.Custom_CheckedChanged);
            // 
            // Hard
            // 
            this.Hard.AutoSize = true;
            this.Hard.Location = new System.Drawing.Point(15, 86);
            this.Hard.Name = "Hard";
            this.Hard.Size = new System.Drawing.Size(48, 17);
            this.Hard.TabIndex = 3;
            this.Hard.TabStop = true;
            this.Hard.Text = "Hard";
            this.Hard.UseVisualStyleBackColor = true;
            this.Hard.CheckedChanged += new System.EventHandler(this.Hard_CheckedChanged);
            // 
            // Normal
            // 
            this.Normal.AutoSize = true;
            this.Normal.Location = new System.Drawing.Point(15, 62);
            this.Normal.Name = "Normal";
            this.Normal.Size = new System.Drawing.Size(58, 17);
            this.Normal.TabIndex = 2;
            this.Normal.TabStop = true;
            this.Normal.Text = "Normal";
            this.Normal.UseVisualStyleBackColor = true;
            this.Normal.CheckedChanged += new System.EventHandler(this.Normal_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(58, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Difficulty Level";
            // 
            // Easy
            // 
            this.Easy.AutoSize = true;
            this.Easy.Checked = true;
            this.Easy.Location = new System.Drawing.Point(15, 39);
            this.Easy.Name = "Easy";
            this.Easy.Size = new System.Drawing.Size(48, 17);
            this.Easy.TabIndex = 0;
            this.Easy.TabStop = true;
            this.Easy.Text = "Easy";
            this.Easy.UseVisualStyleBackColor = true;
            this.Easy.CheckedChanged += new System.EventHandler(this.Easy_CheckedChanged);
            // 
            // Shapes
            // 
            this.Shapes.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.Shapes.Controls.Add(this.Round);
            this.Shapes.Controls.Add(this.Triangle);
            this.Shapes.Controls.Add(this.Square);
            this.Shapes.Controls.Add(this.label2);
            this.Shapes.Location = new System.Drawing.Point(314, 117);
            this.Shapes.Name = "Shapes";
            this.Shapes.Size = new System.Drawing.Size(200, 188);
            this.Shapes.TabIndex = 1;
            // 
            // Round
            // 
            this.Round.AutoSize = true;
            this.Round.Location = new System.Drawing.Point(25, 111);
            this.Round.Name = "Round";
            this.Round.Size = new System.Drawing.Size(58, 17);
            this.Round.TabIndex = 6;
            this.Round.Text = "Round";
            this.Round.UseVisualStyleBackColor = true;
            // 
            // Triangle
            // 
            this.Triangle.AutoSize = true;
            this.Triangle.Location = new System.Drawing.Point(25, 74);
            this.Triangle.Name = "Triangle";
            this.Triangle.Size = new System.Drawing.Size(64, 17);
            this.Triangle.TabIndex = 5;
            this.Triangle.Text = "Triangle";
            this.Triangle.UseVisualStyleBackColor = true;
            // 
            // Square
            // 
            this.Square.AutoSize = true;
            this.Square.Location = new System.Drawing.Point(25, 40);
            this.Square.Name = "Square";
            this.Square.Size = new System.Drawing.Size(60, 17);
            this.Square.TabIndex = 4;
            this.Square.Text = "Square";
            this.Square.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(78, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Shapes";
            // 
            // Save
            // 
            this.Save.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.Save.Location = new System.Drawing.Point(378, 343);
            this.Save.Name = "Save";
            this.Save.Size = new System.Drawing.Size(75, 23);
            this.Save.TabIndex = 2;
            this.Save.Text = "Save";
            this.Save.UseVisualStyleBackColor = false;
            this.Save.Click += new System.EventHandler(this.Save_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.GrayText;
            this.panel1.Controls.Add(this.Yellow);
            this.panel1.Controls.Add(this.Red);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.Blue);
            this.panel1.Location = new System.Drawing.Point(562, 117);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 186);
            this.panel1.TabIndex = 4;
            // 
            // Yellow
            // 
            this.Yellow.AutoSize = true;
            this.Yellow.Location = new System.Drawing.Point(27, 111);
            this.Yellow.Name = "Yellow";
            this.Yellow.Size = new System.Drawing.Size(57, 17);
            this.Yellow.TabIndex = 3;
            this.Yellow.Text = "Yellow";
            this.Yellow.UseVisualStyleBackColor = true;
            // 
            // Red
            // 
            this.Red.AutoSize = true;
            this.Red.Location = new System.Drawing.Point(27, 74);
            this.Red.Name = "Red";
            this.Red.Size = new System.Drawing.Size(46, 17);
            this.Red.TabIndex = 2;
            this.Red.Text = "Red";
            this.Red.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(81, 13);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(36, 13);
            this.label5.TabIndex = 1;
            this.label5.Text = "Colors";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // Blue
            // 
            this.Blue.AutoSize = true;
            this.Blue.Location = new System.Drawing.Point(27, 39);
            this.Blue.Name = "Blue";
            this.Blue.Size = new System.Drawing.Size(47, 17);
            this.Blue.TabIndex = 0;
            this.Blue.Text = "Blue";
            this.Blue.UseVisualStyleBackColor = true;
            // 
            // Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.Save);
            this.Controls.Add(this.Shapes);
            this.Controls.Add(this.DifficultyLevel);
            this.Name = "Settings";
            this.Text = "Settings";
            this.DifficultyLevel.ResumeLayout(false);
            this.DifficultyLevel.PerformLayout();
            this.Shapes.ResumeLayout(false);
            this.Shapes.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel DifficultyLevel;
        private System.Windows.Forms.RadioButton Easy;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton Normal;
        private System.Windows.Forms.RadioButton Hard;
        private System.Windows.Forms.Panel Shapes;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button Save;
        private System.Windows.Forms.RadioButton Custom;
        private System.Windows.Forms.CheckBox Square;
        private System.Windows.Forms.CheckBox Round;
        private System.Windows.Forms.CheckBox Triangle;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox Height;
        private System.Windows.Forms.TextBox Width;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox Blue;
        private System.Windows.Forms.CheckBox Yellow;
        private System.Windows.Forms.CheckBox Red;
    }
}