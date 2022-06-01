using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OOP_LAB1
{
    public partial class SelectGameType : Form
    {
        public SelectGameType()
        {
            InitializeComponent();
            Message.Visible = false;
        }

        private void SinglePlayer_Click(object sender, EventArgs e)
        {
            this.Hide();
            var MainGame = new MainGame();
            MainGame.Closed += (s, args) => this.Close();
            MainGame.ShowDialog();
        }

        private void HostAGame_Click(object sender, EventArgs e)
        {
            SettingsSave.Default.Diffuculty = "Normal";
            foreach (Control component in this.Controls)
            {
                component.Visible = false;
            }
            Message.Visible = true;




        }

        private void ConnectToGame_Click(object sender, EventArgs e)
        {

        }
    }
}
