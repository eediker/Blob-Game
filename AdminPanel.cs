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

        public void LoadTheData()
        {
            _connection.Open();
            

            SqlCommand command = new SqlCommand("SELECT * FROM Kullanıcılar",_connection);
            SqlDataAdapter adapter = new SqlDataAdapter(command);

            DataTable tablo = new DataTable();
            adapter.Fill(tablo);


            // Loading the data for datagriedview component
            UserLists.DataSource = tablo;

            
            // Loading the data for listview component
            for(int i = 0; i < tablo.Rows.Count; i++)
            {
                listView1.Items.Add(tablo.Rows[i]["username"].ToString());
                listView1.Items[i].SubItems.Add(tablo.Rows[i]["password"].ToString());
                listView1.Items[i].SubItems.Add(tablo.Rows[i]["name_surname"].ToString());
                listView1.Items[i].SubItems.Add(tablo.Rows[i]["phone_number"].ToString());
                listView1.Items[i].SubItems.Add(tablo.Rows[i]["address"].ToString());
                listView1.Items[i].SubItems.Add(tablo.Rows[i]["city"].ToString());
                listView1.Items[i].SubItems.Add(tablo.Rows[i]["country"].ToString());
                listView1.Items[i].SubItems.Add(tablo.Rows[i]["email"].ToString());
                listView1.Items[i].SubItems.Add(tablo.Rows[i]["score"].ToString());

            }

            _connection.Close();
        }

        private void AddNewUser_Click(object sender, EventArgs e)
        {
            _connection.Open();
            SqlCommand read = new SqlCommand("SELECT * FROM Kullanıcılar Where username =@P1", _connection);
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
                SqlCommand insert = new SqlCommand("INSERT INTO Kullanıcılar(username,password,name_surname,phone_number,address,city,country,email,score) VALUES (@username,@password,@name_surname,@phone_number,@address,@city,@country,@email,@score)", _connection);
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
            LoadTheData();
        }

        private void DeleteAnUser_Click(object sender, EventArgs e)
        {

            try
            {
                _connection.Open();
                SqlCommand command = new SqlCommand("DELETE FROM Kullanıcılar WHERE username=@username", _connection);
                command.Parameters.AddWithValue("@username", listView1.SelectedItems[0].Text);
                command.ExecuteNonQuery();
                MessageBox.Show(listView1.SelectedItems[0].Text + "  silindi.");
                listView1.Items.Clear();
                _connection.Close();
                LoadTheData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void AdminPanel_Load(object sender, EventArgs e)
        {
            LoadTheData();
        }

        private void UpdateUserInfo_Click(object sender, EventArgs e)
        {
            try
            {
                _connection.Open();
                SqlCommand command = new SqlCommand("UPDATE Kullanıcılar SET password = @password , name_surname = @name_surname, phone_number = @phone_number , address = @address , city = @city , country = @country , email = @email WHERE username = @username", _connection);
                command.Parameters.AddWithValue("@username", UpdateUsernameField.Text);
                command.Parameters.AddWithValue("@password", Sha256Hash(UpdatePasswordField.Text));
                command.Parameters.AddWithValue("@name_surname", UpdateNameField.Text);
                command.Parameters.AddWithValue("@phone_number", UpdatePhoneField.Text);
                command.Parameters.AddWithValue("@address", UpdateAddressField.Text);
                command.Parameters.AddWithValue("@city", UpdateCityField.Text);
                command.Parameters.AddWithValue("@country", UpdateCountryField.Text);
                command.Parameters.AddWithValue("@email", UpdateEmailField.Text);
                command.ExecuteNonQuery();
                _connection.Close();
                MessageBox.Show("User Informations updated.");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void FindUser_Click(object sender, EventArgs e)
        {
            _connection.Open();
            if(UsernameField.Text == "user" || UsernameField.Text == "admin")
            {
                MessageBox.Show("This user cannot be modified!");
                _connection.Close();
                return;
            }

            SqlCommand cmd = new SqlCommand("SELECT * FROM Kullanıcılar Where username =@P1", _connection);
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
            }
            else
            {
                MessageBox.Show("No user with this information");
            }
            reader.Close();
            _connection.Close();

        }
    }
}
