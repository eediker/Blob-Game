namespace OOP_LAB1
{
    partial class MultiplayerGame
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
            this.WhoseTurn = new System.Windows.Forms.Label();
            this.Player1 = new System.Windows.Forms.Label();
            this.Player2 = new System.Windows.Forms.Label();
            this.Player1Score = new System.Windows.Forms.Label();
            this.Player2Score = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // WhoseTurn
            // 
            this.WhoseTurn.AutoSize = true;
            this.WhoseTurn.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.WhoseTurn.Location = new System.Drawing.Point(132, 416);
            this.WhoseTurn.Name = "WhoseTurn";
            this.WhoseTurn.Size = new System.Drawing.Size(92, 31);
            this.WhoseTurn.TabIndex = 0;
            this.WhoseTurn.Text = "label1";
            // 
            // Player1
            // 
            this.Player1.AutoSize = true;
            this.Player1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.Player1.Location = new System.Drawing.Point(563, 95);
            this.Player1.Name = "Player1";
            this.Player1.Size = new System.Drawing.Size(113, 31);
            this.Player1.TabIndex = 1;
            this.Player1.Text = "Player 1";
            // 
            // Player2
            // 
            this.Player2.AutoSize = true;
            this.Player2.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.Player2.Location = new System.Drawing.Point(563, 149);
            this.Player2.Name = "Player2";
            this.Player2.Size = new System.Drawing.Size(113, 31);
            this.Player2.TabIndex = 2;
            this.Player2.Text = "Player 2";
            // 
            // Player1Score
            // 
            this.Player1Score.AutoSize = true;
            this.Player1Score.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.Player1Score.Location = new System.Drawing.Point(698, 95);
            this.Player1Score.Name = "Player1Score";
            this.Player1Score.Size = new System.Drawing.Size(29, 31);
            this.Player1Score.TabIndex = 3;
            this.Player1Score.Text = "0";
            // 
            // Player2Score
            // 
            this.Player2Score.AutoSize = true;
            this.Player2Score.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.Player2Score.Location = new System.Drawing.Point(698, 149);
            this.Player2Score.Name = "Player2Score";
            this.Player2Score.Size = new System.Drawing.Size(29, 31);
            this.Player2Score.TabIndex = 4;
            this.Player2Score.Text = "0";
            // 
            // MultiplayerGame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(812, 487);
            this.Controls.Add(this.Player2Score);
            this.Controls.Add(this.Player1Score);
            this.Controls.Add(this.Player2);
            this.Controls.Add(this.Player1);
            this.Controls.Add(this.WhoseTurn);
            this.Name = "MultiplayerGame";
            this.Text = "MultiplayerGame";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MultiplayerGame_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label WhoseTurn;
        private System.Windows.Forms.Label Player1;
        private System.Windows.Forms.Label Player2;
        private System.Windows.Forms.Label Player1Score;
        private System.Windows.Forms.Label Player2Score;
    }
}