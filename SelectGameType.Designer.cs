namespace OOP_LAB1
{
    partial class SelectGameType
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
            this.SinglePlayer = new System.Windows.Forms.Button();
            this.HostAGame = new System.Windows.Forms.Button();
            this.IPAddress = new System.Windows.Forms.TextBox();
            this.ConnectToGame = new System.Windows.Forms.Button();
            this.PortNumber = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.Message = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // SinglePlayer
            // 
            this.SinglePlayer.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.SinglePlayer.Location = new System.Drawing.Point(231, 144);
            this.SinglePlayer.Name = "SinglePlayer";
            this.SinglePlayer.Size = new System.Drawing.Size(352, 41);
            this.SinglePlayer.TabIndex = 0;
            this.SinglePlayer.Text = "SİNGLE PLAYER";
            this.SinglePlayer.UseVisualStyleBackColor = true;
            this.SinglePlayer.Click += new System.EventHandler(this.SinglePlayer_Click);
            // 
            // HostAGame
            // 
            this.HostAGame.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.HostAGame.Location = new System.Drawing.Point(231, 215);
            this.HostAGame.Name = "HostAGame";
            this.HostAGame.Size = new System.Drawing.Size(352, 41);
            this.HostAGame.TabIndex = 1;
            this.HostAGame.Text = "HOST A GAME";
            this.HostAGame.UseVisualStyleBackColor = true;
            this.HostAGame.Click += new System.EventHandler(this.HostAGame_Click);
            // 
            // IPAddress
            // 
            this.IPAddress.Location = new System.Drawing.Point(231, 338);
            this.IPAddress.Name = "IPAddress";
            this.IPAddress.Size = new System.Drawing.Size(131, 20);
            this.IPAddress.TabIndex = 2;
            // 
            // ConnectToGame
            // 
            this.ConnectToGame.Location = new System.Drawing.Point(445, 338);
            this.ConnectToGame.Name = "ConnectToGame";
            this.ConnectToGame.Size = new System.Drawing.Size(138, 20);
            this.ConnectToGame.TabIndex = 3;
            this.ConnectToGame.Text = "CONNECT TO A GAME";
            this.ConnectToGame.UseVisualStyleBackColor = true;
            this.ConnectToGame.Click += new System.EventHandler(this.ConnectToGame_Click);
            // 
            // PortNumber
            // 
            this.PortNumber.Location = new System.Drawing.Point(368, 338);
            this.PortNumber.Name = "PortNumber";
            this.PortNumber.Size = new System.Drawing.Size(71, 20);
            this.PortNumber.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(259, 322);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "IP ADDRESS";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(382, 322);
            this.label2.Name = "label2";
            this.label2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label2.Size = new System.Drawing.Size(37, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "PORT";
            // 
            // Message
            // 
            this.Message.AutoSize = true;
            this.Message.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.Message.Location = new System.Drawing.Point(268, 194);
            this.Message.Name = "Message";
            this.Message.Size = new System.Drawing.Size(289, 18);
            this.Message.TabIndex = 7;
            this.Message.Text = "Waiting for opponent to connect to game...";
            // 
            // SelectGameType
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.Message);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.PortNumber);
            this.Controls.Add(this.ConnectToGame);
            this.Controls.Add(this.IPAddress);
            this.Controls.Add(this.HostAGame);
            this.Controls.Add(this.SinglePlayer);
            this.Name = "SelectGameType";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SelectGameType";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button SinglePlayer;
        private System.Windows.Forms.Button HostAGame;
        private System.Windows.Forms.TextBox IPAddress;
        private System.Windows.Forms.Button ConnectToGame;
        private System.Windows.Forms.TextBox PortNumber;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label Message;
    }
}