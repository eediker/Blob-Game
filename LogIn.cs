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
    public partial class LogIn : Form
    {
        public LogIn()
        {
            InitializeComponent();
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

        private void LogInButton_Click(object sender, EventArgs e)
        {
            User user = new User();
            Admin admin = new Admin();
            bool Flag = 
                (UsernameField.Text == user.Username && PasswordField.Text == user.Password)
                ||
                (UsernameField.Text == admin.Password && PasswordField.Text == admin.Password);

            if (Flag)
            {
                this.Hide();
                var MainGame = new MainGame();
                MainGame.Closed += (s, args) => this.Close();
                MainGame.Show();
            }
            else
            {
                MessageBox.Show("There is no user found with this informations");
            }
        }

        private void PasswordField_TextChanged(object sender, EventArgs e)
        {

        }

        private void LogInButton_KeyDown(object sender, KeyEventArgs e)
        {
                if ((UsernameField.Text == "user" && PasswordField.Text == "user") ||
                (UsernameField.Text == "admin" && PasswordField.Text == "admin")
                )
                {
                    this.Hide();
                    var MainGame = new MainGame();
                    MainGame.Closed += (s, args) => this.Close();
                    MainGame.Show();
                }
                else
                {
                    MessageBox.Show("There is no user found with this informations");
                }
        }
    }
}
