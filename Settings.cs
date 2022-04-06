using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace OOP_LAB1
{
    public partial class Settings : Form
    {
        public Settings()
        {
            InitializeComponent();

            switch (SettingsSaved.Default.Diffuculty)
            {
                case "Easy":
                    Easy.Checked = true;
                    break;
                case "Normal":
                    Normal.Checked = true;
                    break ;
                case "Hard":
                    Hard.Checked = true;
                    break;
                case "Custom":
                    Custom.Checked = true;
                    break;
            }

            Square.Checked = SettingsSaved.Default.Square;
            Round.Checked = SettingsSaved.Default.Round;
            Triangle.Checked = SettingsSaved.Default.Triangle;

            Width.Text = SettingsSaved.Default.Width.ToString();
            Height.Text = SettingsSaved.Default.Height.ToString();

            Red.Checked = SettingsSaved.Default.Red;
            Blue.Checked = SettingsSaved.Default.Blue;
            Blue.Checked = SettingsSaved.Default.Blue;

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
            if (Easy.Checked)
            {
                SettingsSaved.Default.Diffuculty = "Easy";
            }
            else if (Normal.Checked)
            {
                SettingsSaved.Default.Diffuculty = "Normal";
            }
            else if (Hard.Checked)
            {
                SettingsSaved.Default.Diffuculty = "Hard";
            }
            else if (Custom.Checked)
            {
                SettingsSaved.Default.Diffuculty = "Custom";
                try
                {
                    SettingsSaved.Default.Width = int.Parse(Width.Text);
                    SettingsSaved.Default.Height = int.Parse(Height.Text);
                }
                catch(Exception ex)
                {
                    MessageBox.Show("Lütfen bir integer değer giriniz!");
                    return;
                }
                
            }
            SettingsSaved.Default.Square = Square.Checked;
            SettingsSaved.Default.Triangle = Triangle.Checked;
            SettingsSaved.Default.Round = Round.Checked;

            SettingsSaved.Default.Red = Red.Checked;
            SettingsSaved.Default.Blue = Blue.Checked;
            SettingsSaved.Default.Yellow = Yellow.Checked;
            SettingsSaved.Default.Save();

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
