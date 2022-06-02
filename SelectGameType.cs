using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Net;
using System.Net.Sockets;

namespace OOP_LAB1
{
    public partial class SelectGameType : Form
    {
        SqlConnection _connection = new SqlConnection("workstation id=OOP-LAB.mssql.somee.com;packet size=4096;user id=eediker_SQLLogin_1;pwd=jkd89i8yei;data source=OOP-LAB.mssql.somee.com;persist security info=False;initial catalog=OOP-LAB");

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
            foreach (Control component in this.Controls)
            {
                component.Visible = false;
            }
            Message.Text += "\n\n\n*****Connection Details are given below*****";
            Message.Text += "\n\nIP Adress   : " + Dns.GetHostEntry(Dns.GetHostName()).AddressList[1].ToString();
            Message.Text += "\nPort Number : " + "47132";
            Message.Visible = true;
            
            int sleepTime = 100;
            Task.Delay(sleepTime).Wait();
            
            _connection.Open();
            SqlCommand command = new SqlCommand("UPDATE Multiplayer SET username=@username WHERE isServer = @isServer", _connection);
            command.Parameters.AddWithValue("@username", SettingsSave.Default.Username);
            command.Parameters.AddWithValue("@isServer", 1);
            command.ExecuteNonQuery();
            _connection.Close();

            MultiplayerGame multiplayerGame = new MultiplayerGame(true, Dns.GetHostEntry(Dns.GetHostName()).AddressList[1],47132);
            Visible = false;
            this.Hide();
            if(!multiplayerGame.IsDisposed)
                multiplayerGame.ShowDialog();
        }

        private void ConnectToGame_Click(object sender, EventArgs e)
        {
            _connection.Open();
            SqlCommand command = new SqlCommand("UPDATE Multiplayer SET username=@username WHERE isServer = @isServer", _connection);
            command.Parameters.AddWithValue("@username", SettingsSave.Default.Username);
            command.Parameters.AddWithValue("@isServer", 0);
            command.ExecuteNonQuery();
            _connection.Close();

            MultiplayerGame multiplayerGame = new MultiplayerGame(false, System.Net.IPAddress.Parse(IPAddress.Text),int.Parse(PortNumber.Text));
            Visible = false;
            this.Hide();
            if (!multiplayerGame.IsDisposed)
                multiplayerGame.ShowDialog();
            Visible = true;
        }
    }
}
