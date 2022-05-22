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
using System.Xml;
using System.Security.Cryptography;
using System.Data.SqlClient;

namespace OOP_LAB1
{
    public partial class MyProfile : Form
    {
        SqlConnection _connection = new SqlConnection("workstation id=OOP-LAB.mssql.somee.com;packet size=4096;user id=eediker_SQLLogin_1;pwd=jkd89i8yei;data source=OOP-LAB.mssql.somee.com;persist security info=False;initial catalog=OOP-LAB");
        public MyProfile()
        {
            InitializeComponent();
            UsernameField.Text = SettingsSave.Default.Username;
            NameSurnameField.Text = SettingsSave.Default.NameSurname;
            PhoneNumberField.Text = SettingsSave.Default.PhoneNumber;
            AddressField.Text = SettingsSave.Default.Address;
            CityField.Text = SettingsSave.Default.City;
            CountryField.Text = SettingsSave.Default.Country;
            EmailField.Text = SettingsSave.Default.Email;
        }

        private void Save_Click(object sender, EventArgs e)
        {
            if(SettingsSave.Default.Password != Sha256Hash(PasswordCheck.Text))
            {
                MessageBox.Show("Hatalı Parola!");
                return;
            }

            try
            {
                _connection.Open();
                SqlCommand command = new SqlCommand("UPDATE Kullanıcılar SET password = @password , name_surname = @name_surname, phone_number = @phone_number , address = @address , city = @city , country = @country , email = @email WHERE username = @username", _connection);
                command.Parameters.AddWithValue("@username", UsernameField.Text);
                command.Parameters.AddWithValue("@password", Sha256Hash(PasswordField.Text));
                command.Parameters.AddWithValue("@name_surname", NameSurnameField.Text);
                command.Parameters.AddWithValue("@phone_number", PhoneNumberField.Text);
                command.Parameters.AddWithValue("@address", AddressField.Text);
                command.Parameters.AddWithValue("@city", CityField.Text);
                command.Parameters.AddWithValue("@country", CountryField.Text);
                command.Parameters.AddWithValue("@email", EmailField.Text);
                command.ExecuteNonQuery();
                _connection.Close();


                SettingsSave.Default.Password = Sha256Hash(PasswordField.Text);
                SettingsSave.Default.NameSurname = NameSurnameField.Text;
                SettingsSave.Default.PhoneNumber = PhoneNumberField.Text;
                SettingsSave.Default.Address = AddressField.Text;
                SettingsSave.Default.City = CityField.Text;
                SettingsSave.Default.Country = CountryField.Text;
                SettingsSave.Default.Email = EmailField.Text;
                SettingsSave.Default.Save();

                MessageBox.Show("User Informations updated.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


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
    }
}
