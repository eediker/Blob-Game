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

namespace OOP_LAB1
{
    public partial class MyProfile : Form
    {
        public MyProfile()
        {
            InitializeComponent();
            UsernameField.Text = SettingsSave.Default.Username;
            PasswordField.Text = SettingsSave.Default.Password;
            NameSurnameField.Text = SettingsSave.Default.NameSurname;
            PhoneNumberField.Text = SettingsSave.Default.PhoneNumber;
            AddressField.Text = SettingsSave.Default.Address;
            CityField.Text = SettingsSave.Default.City;
            CountryField.Text = SettingsSave.Default.Country;
            EmailField.Text = SettingsSave.Default.Email;
        }

        private void Save_Click(object sender, EventArgs e)
        {
            SettingsSave.Default.Password = Sha256Hash(PasswordField.Text);
            SettingsSave.Default.NameSurname = NameSurnameField.Text;
            SettingsSave.Default.PhoneNumber = PhoneNumberField.Text;
            SettingsSave.Default.Address = AddressField.Text;
            SettingsSave.Default.City = CityField.Text;
            SettingsSave.Default.Country = CountryField.Text;
            SettingsSave.Default.Email = EmailField.Text;
            SettingsSave.Default.Save();

            XDocument xmlDoc = XDocument.Load("../../RegisteredUsers.xml");

            var Users = xmlDoc.Descendants("user");
            foreach (var xUser in Users)
            {
                if (xUser.Element("username").Value == UsernameField.Text)
                {
                    xUser.Element("password").Value = Sha256Hash(PasswordField.Text);
                    xUser.Element("name-surname").Value = NameSurnameField.Text;
                    xUser.Element("phone-number").Value = PhoneNumberField.Text;
                    xUser.Element("address").Value = AddressField.Text;
                    xUser.Element("city").Value = CityField.Text;
                    xUser.Element("country").Value = CountryField.Text;
                    xUser.Element("email").Value = EmailField.Text;
                    xUser.Save("../../RegisteredUsers.xml");

                    this.Hide();
                    return;
                }
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
