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

namespace OOP_LAB1
{
    public partial class AdminPanel : Form
    {
        public AdminPanel()
        {
            InitializeComponent();
        }

        private void ListUsers_Click(object sender, EventArgs e)
        {

        }

        private void AddNewUser_Click(object sender, EventArgs e)
        {
            var SignUp = new SignUp();
            SignUp.ShowDialog();
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
                }
            }
            MessageBox.Show("There is no user found with this informations");

        }
    }
}
