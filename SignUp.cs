using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.Xml.Linq;
using System.Data.SqlClient;

namespace OOP_LAB1
{
    public partial class SignUp : Form
    {
        SqlConnection _connection = new SqlConnection("Data Source=LENOVO-PC\\MSSQLSRVR;Initial Catalog=Kullanıcılar;Integrated Security=True");
        public SignUp()
        {
            InitializeComponent();
        }

        static string Sha256Hash(string Data)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(Data));
                
                StringBuilder builder = new StringBuilder();
                for(int i = 0;i< bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }

        private void SaveTheUser_Click(object sender, EventArgs e)
        {
            _connection.Open();
            SqlCommand read = new SqlCommand("SELECT * FROM Kullanıcılar Where username =@P1", _connection);
            read.Parameters.AddWithValue("@P1", UsernameField.Text);
            SqlDataReader reader = read.ExecuteReader();

            if (reader.Read())
            {
                MessageBox.Show("There is a user with this information");
                reader.Close();
                _connection.Close();
            }
            else
            {
                SqlCommand insert = new SqlCommand("INSERT INTO Kullanıcılar(username,password,name_surname,phone_number,address,city,country,email,score) VALUES (@username,@password,@name_surname,@phone_number,@address,@city,@country,@email,@score)", _connection);
                insert.Parameters.AddWithValue("@username", UsernameField.Text);
                insert.Parameters.AddWithValue("@password", Sha256Hash(PasswordField.Text));
                insert.Parameters.AddWithValue("@name_surname", NameSurnameField.Text);
                insert.Parameters.AddWithValue("@phone_number", PhoneNumberField.Text);
                insert.Parameters.AddWithValue("@address", AddressField.Text);
                insert.Parameters.AddWithValue("@city", CityField.Text);
                insert.Parameters.AddWithValue("@country", CountryField.Text);
                insert.Parameters.AddWithValue("@email", EmailField.Text);
                insert.Parameters.AddWithValue("@score", 0);

                reader.Close();
                insert.ExecuteNonQuery();
                _connection.Close();
                MessageBox.Show("Succesfully registered");
                this.Hide();
            }


        }
    }
}
