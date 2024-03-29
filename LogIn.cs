﻿using System;
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
        SqlConnection _connection = new SqlConnection("workstation id=OOP-LAB.mssql.somee.com;packet size=4096;user id=eediker_SQLLogin_1;pwd=jkd89i8yei;data source=OOP-LAB.mssql.somee.com;persist security info=False;initial catalog=OOP-LAB");

        bool flag = false;
        public LogIn()
        {
            InitializeComponent();
            UsernameField.Text = SettingsSave.Default.Username;
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
            try
            {
                _connection.Open();

                SqlCommand cmd = new SqlCommand("SELECT * FROM Kullanıcılar Where username =@P1 AND password= @P2 ", _connection);
                cmd.Parameters.AddWithValue("@P1", UsernameField.Text);
                cmd.Parameters.AddWithValue("@P2", Sha256Hash(PasswordField.Text));
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
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
                    var SelectGameType = new SelectGameType();
                    SelectGameType.Closed += (s, args) => this.Close();
                    SelectGameType.ShowDialog();
                }
                else
                {
                    MessageBox.Show("No user with this information");
                    reader.Close();
                    _connection.Close();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
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

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (!flag)
            {
                PasswordField.PasswordChar = default;
                flag = true;
            }
            else
            {
                PasswordField.PasswordChar = '*';
                flag = false;
            }
        }
    }
}
