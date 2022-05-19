using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;
using System.Security.Cryptography;
using System.Data.SqlClient;

namespace OOP_LAB1
{
    public partial class AdminPanel : Form
    {
        SqlConnection _connection = new SqlConnection("Data Source=LENOVO-PC\\MSSQLSRVR;Initial Catalog=Kullanıcılar;Integrated Security=True");
        public AdminPanel()
        {
            InitializeComponent();
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

        private void AddNewUser_Click(object sender, EventArgs e)
        {
            _connection.Open();
            SqlCommand read = new SqlCommand("SELECT * FROM Kullanıclar Where username =@P1", _connection);
            read.Parameters.AddWithValue("@P1", AddUsernameField.Text);
            SqlDataReader reader = read.ExecuteReader();

            if (reader.Read())
            {
                MessageBox.Show("There is a user with this information");
                reader.Close();
                _connection.Close();
            }
            else
            {
                SqlCommand insert = new SqlCommand("INSERT INTO Kullanıclar(username,password,name_surname,phone_number,address,city,country,email,score) VALUES (@username,@password,@name_surname,@phone_number,@address,@city,@country,@email,@score)", _connection);
                insert.Parameters.AddWithValue("@username", AddUsernameField.Text);
                insert.Parameters.AddWithValue("@password", Sha256Hash(AddPasswordField.Text));
                insert.Parameters.AddWithValue("@name_surname", AddNameField.Text);
                insert.Parameters.AddWithValue("@phone_number", AddPhoneField.Text);
                insert.Parameters.AddWithValue("@address", AddAddressField.Text);
                insert.Parameters.AddWithValue("@city", AddCityField.Text);
                insert.Parameters.AddWithValue("@country", AddCountryField.Text);
                insert.Parameters.AddWithValue("@email", AddEmailField.Text);
                insert.Parameters.AddWithValue("@score", 0);

                reader.Close();
                insert.ExecuteNonQuery();
                _connection.Close();
                MessageBox.Show("Succesfully Created a new user");
            }
        }
        private void DeleteAnUser_Click(object sender, EventArgs e)
        {
            //_connection.Open();
            
            
            //    if(MessageBox.Show("Are you sure want to delete this user ?", "This cant be undone", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            //    {
            //        SqlCommand cmd = new SqlCommand("DELETE FROM Kullancılar where username = @username", _connection);
            //        cmd.Parameters.AddWithValue("@username", RemoveUsernameField.Text);
            //        cmd.ExecuteNonQuery();
            //    }

            //_connection.Close();
        }

        private void UpdateUserInfo_Click(object sender, EventArgs e)
        {

            


        }

        private void UpdateFindUser_Click(object sender, EventArgs e)
        {
            if (UpdateUsernameField.Text == "user" || UpdateUsernameField.Text == "admin")
            {
                MessageBox.Show("You cant update these preregistered users!");
                return;
            }

            _connection.Open();

            SqlCommand cmd = new SqlCommand("SELECT * FROM Kullanıclar Where username =@P1", _connection);
            cmd.Parameters.AddWithValue("@P1", UsernameField.Text);
            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                UpdateUsernameField.Text = reader["username"].ToString();
                UpdateNameField.Text = reader["name_surname"].ToString();
                UpdatePhoneField.Text = reader["phone_number"].ToString();
                UpdateAddressField.Text = reader["address"].ToString();
                UpdateCityField.Text = reader["city"].ToString();
                UpdateCountryField.Text = reader["country"].ToString();
                UpdateEmailField.Text = reader["email"].ToString();

                SettingsSave.Default.Save();
                reader.Close();
                _connection.Close();
            }
            else
            {
                MessageBox.Show("No user found with this username");
            }
        }

        private void AdminPanel_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'kullanıcılarDataSet.Kullanıclar' table. You can move, or remove it, as needed.
            this.kullanıclarTableAdapter.Fill(this.kullanıcılarDataSet.Kullanıclar);
            // TODO: This line of code loads data into the 'kullanıcılarDataSet.Kullanıclar' table. You can move, or remove it, as needed.
            this.kullanıclarTableAdapter.Fill(this.kullanıcılarDataSet.Kullanıclar);

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
