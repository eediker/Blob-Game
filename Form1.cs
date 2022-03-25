using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OOP_LAB1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
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

        private void button1_Click(object sender, EventArgs e)
        {
            if (UsernameField.Text != "user" && PasswordField.Text != "user" ||
                UsernameField.Text != "admin" && PasswordField.Text != "admin"
                )
            {
                MessageBox.Show("There is no user found with this informations");
            }
            else
            {
                MessageBox.Show("Wait for next week");
            }
        }

        private void PasswordField_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
