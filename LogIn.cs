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
            if (!System.Text.RegularExpressions.Regex.IsMatch(UsernameField.Text, "^[a-zA-Z ]"))
            {
                MessageBox.Show("This textbox accepts only alphabetical characters");
                UsernameField.Text.Remove(UsernameField.Text.Length - 1);
            }
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
                Output output = new Output("UserSettings");
                output.GiveOutput(UsernameField.Text + "," + PasswordField.Text + ",");
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
                Console.WriteLine(e.ToString());
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

        //private void clear_Click(object sender, EventArgs e)
        //{
        //    PasswordField.PasswordChar = default;



        //}

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                PasswordField.PasswordChar = '\0';
            }
            else
            {
                PasswordField.PasswordChar = '*';
            }
            
        }
    }
}
