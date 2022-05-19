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
using System.Data.SqlClient;

namespace OOP_LAB1
{
    public partial class LogIn : Form
    {
        SqlConnection _connection = new SqlConnection("Data Source=LENOVO-PC\\MSSQLSRVR;Initial Catalog=Kullanıcılar;Integrated Security=True");
        
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
            _connection.Open();

            SqlCommand cmd = new SqlCommand("SELECT * FROM Kullanıclar Where username =@P1 AND password= @P2 ", _connection);
            cmd.Parameters.AddWithValue("@P1", UsernameField.Text);
            cmd.Parameters.AddWithValue("@P2", Sha256Hash(PasswordField.Text));
            SqlDataReader reader = cmd.ExecuteReader();

            if(reader.Read())
            {
                if(reader["username"].ToString() == UsernameField.Text &&
                    reader["password"].ToString() == Sha256Hash(PasswordField.Text))
                {
                    SettingsSave.Default.Username = reader["username"].ToString();
                    SettingsSave.Default.Password = reader["password"].ToString();
                    SettingsSave.Default.NameSurname = reader["name_surname"].ToString();
                    SettingsSave.Default.PhoneNumber = reader["phone_number"].ToString();
                    SettingsSave.Default.Address = reader["address"].ToString();
                    SettingsSave.Default.City = reader["city"].ToString();
                    SettingsSave.Default.Country = reader["country"].ToString();
                    SettingsSave.Default.Email = reader["email"].ToString();
                    SettingsSave.Default.BestScore = int.Parse(reader["score"].ToString());

                    SettingsSave.Default.Save();
                    _connection.Close();
                    this.Hide();
                    var MainGame = new MainGame();
                    MainGame.Closed += (s, args) => this.Close();
                    MainGame.ShowDialog();
                }
                else
                {
                    MessageBox.Show("No user with this information");
                    reader.Close();
                    _connection.Close();
                }
            }
            else
            {
                MessageBox.Show("No user with this information");
                reader.Close();
                _connection.Close();
            }
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

        private void ShowPassword_Click(object sender, EventArgs e)
        {
            PasswordField.PasswordChar = default;
        }
    }
}
