using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using System.Security.Cryptography;

namespace OOP_LAB1
{
    public partial class LogIn : Form
    {
        public LogIn()
        {
            InitializeComponent();
            UsernameField.Text = SettingsSave.Default.Username;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        static string Sha256Hash(string Data)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(Data));

                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }

        private void LogInButton_Click(object sender, EventArgs e)
        {
            XDocument xmlDoc = XDocument.Load("../../RegisteredUsers.xml");

            var Users = xmlDoc.Descendants("user");
            foreach (var xUser in Users)
            {
                
                
                if (xUser.Element("username").Value == UsernameField.Text
                    &&
                    xUser.Element("password").Value == Sha256Hash(PasswordField.Text))
                {
                    SettingsSave.Default.Username = UsernameField.Text;
                    this.Hide();
                    var MainGame = new MainGame();
                    MainGame.Closed += (s, args) => this.Close();
                    MainGame.ShowDialog();
                    return;
                }
            }
            MessageBox.Show("There is no user found with this informations");
            
        }

        private void PasswordField_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void SignUpButton_Click(object sender, EventArgs e)
        {
            var SignUp = new SignUp();
            SignUp.ShowDialog();
        }

        private void UsernameField_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
