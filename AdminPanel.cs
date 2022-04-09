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

namespace OOP_LAB1
{
    public partial class AdminPanel : Form
    {
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
            XmlDocument x = new XmlDocument();
            DataSet ds = new DataSet();
            XmlReader xmlFile;
            xmlFile = XmlReader.Create("../../RegisteredUsers.xml", new XmlReaderSettings());
            ds.ReadXml(xmlFile);
            dataGridView1.DataSource = ds.Tables[0];
            xmlFile.Close();
        }

        private void AddNewUser_Click(object sender, EventArgs e)
        {
            XDocument xmlDoc = XDocument.Load("../../RegisteredUsers.xml");

            var Users = xmlDoc.Descendants("user");
            foreach (var xUser in Users)
            {
                if (xUser.Element("username").Value == UsernameField.Text)
                {
                    MessageBox.Show("There is an user with this username!");
                    return;
                }

            }
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
                PhoneNumber, Address, City, Country, Email);
            root.Add(element);
            xmlDoc.Save("../../RegisteredUsers.xml");
            MessageBox.Show("Succesfully registered");
            LoadTheData();
        }

        private void DeleteAnUser_Click(object sender, EventArgs e)
        {
            if (UsernameField.Text == "user" || UsernameField.Text == "admin")
            {
                MessageBox.Show("You cant delete these preregistered users!");
                return;
            }

            XDocument xmlDoc = XDocument.Load("../../RegisteredUsers.xml");

            var Users = xmlDoc.Descendants("user");
            foreach (var xUser in Users)
            {
                if (xUser.Element("username").Value == UsernameField.Text)
                {
                    xUser.Remove();
                    xmlDoc.Save("../../RegisteredUsers.xml");
                    MessageBox.Show("User deleted...");
                    LoadTheData();
                    return;
                }
            }
            MessageBox.Show("There is no user found with this informations");


        }

        private void AdminPanel_Load(object sender, EventArgs e)
        {
            LoadTheData();
        }

        private void UpdateUserInfo_Click(object sender, EventArgs e)
        {
            XDocument x = XDocument.Load("../../RegisteredUsers.xml");

            XElement node = x.Element("users").Elements("user").FirstOrDefault(a => a.Element("username").Value == UsernameField.Text);
            if (node != null)
            {
                node.SetElementValue("password", Sha256Hash(PasswordField.Text));
                node.SetElementValue("name-surname", NameSurnameField.Text);
                node.SetElementValue("phone-number", PhoneNumberField.Text);
                node.SetElementValue("address", AddressField.Text);
                node.SetElementValue("city", CityField.Text);
                node.SetElementValue("country", CountryField.Text);
                node.SetElementValue("email", EmailField.Text);
                x.Save("../../RegisteredUsers.xml");
                LoadTheData();
            }
            else
            {
                MessageBox.Show("There is no user with this username");
            }
        }
    }
}
