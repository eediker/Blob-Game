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

namespace OOP_LAB1
{
    public partial class SignUp : Form
    {
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

            XDocument xmlDoc = XDocument.Load("../../RegisteredUsers.xml");
            XElement root = xmlDoc.Descendants("users").First();
            XElement element = new XElement("user");
            XElement UserName = new XElement("username", UsernameField.Text);
            XElement Password = new XElement("password", Sha256Hash(PasswordField.Text));
            XElement NameSurname = new XElement("name-surname", NameSurnameField.Text);
            XElement PhoneNumber = new XElement("phone-number", PhoneNumberField.Text);
            XElement Address = new XElement("address", AddressField.Text);
            XElement City = new XElement("city", CityField.Text);
            XElement Country = new XElement("country", CountryField.Text);
            XElement Email = new XElement("email", EmailField.Text);
            element.Add(UserName, Password, NameSurname,
                PhoneNumber, Address, City, Country,Email);
            root.Add(element);
            xmlDoc.Save("../../RegisteredUsers.xml");

            MessageBox.Show("Succesfully registered");
            this.Hide();
        }
    }
}
