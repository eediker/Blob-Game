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
            Output output = new Output("UserSettings");
            string line = "";            
            if (Easy.Checked)
                line += "Easy";
            else if (Normal.Checked)
                line += "Normal";
            else if (Hard.Checked)
                line += "Hard";
            else if (Custom.Checked)
            {
                try
                {
                    int.Parse(Width.Text);
                    int.Parse(Height.Text);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return;
                }

                line += "Custom(";
                line += Width.Text;
                line += "," + Height.Text + ")";
            }

            if (Square.Checked)
                line += "," + "Square";
            if (Triangle.Checked)
                line += "," + "Triangle";
            if (Round.Checked)
                line += "," + "Round";

            if (Red.Checked)
                line += "," + "Red";
            if (Blue.Checked)
                line += "," + "Blue";
            if (Yellow.Checked)
                line += "," + "Yellow";

            line += "\n";

            
            output.GiveOutput(line);
            MessageBox.Show("Your settings saved to file");
            
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
