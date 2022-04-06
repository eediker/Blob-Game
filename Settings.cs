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
    public partial class Settings : Form
    {
        public Settings()
        {
            InitializeComponent();
            

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Custom_CheckedChanged(object sender, EventArgs e)
        {
            Width.Visible = true;
            Height.Visible = true;
            label3.Visible = true;
            label4.Visible = true;
        }

        private void radioButton1_CheckedChanged_1(object sender, EventArgs e)
        {

        }

        private void Save_Click(object sender, EventArgs e)
        {
           
            
            this.Hide();
            
        }

        private void ReturnToLastForm_Click(object sender, EventArgs e)
        {
            
        }

        private void Easy_CheckedChanged(object sender, EventArgs e)
        {
            Width.Visible = false;
            Height.Visible = false;
            label3.Visible = false;
            label4.Visible = false;
        }

        private void Normal_CheckedChanged(object sender, EventArgs e)
        {
            Width.Visible = false;
            Height.Visible = false;
            label3.Visible = false;
            label4.Visible = false;
        }

        private void Hard_CheckedChanged(object sender, EventArgs e)
        {
             Width.Visible = false;
             Height.Visible = false;
             label3.Visible = false;
             label4.Visible = false;
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}
