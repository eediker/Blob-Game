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

            switch (SettingsSave.Default.Diffuculty)
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

            Square.Checked = SettingsSave.Default.Square;
            Round.Checked = SettingsSave.Default.Round;
            Triangle.Checked = SettingsSave.Default.Triangle;

            Width.Text = SettingsSave.Default.Width.ToString();
            Height.Text = SettingsSave.Default.Height.ToString();

            Red.Checked = SettingsSave.Default.Red;
            Blue.Checked = SettingsSave.Default.Blue;
            Yellow.Checked = SettingsSave.Default.Yellow;

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
            Colors.Visible = true;
            Shapes.Visible = true;
        }

        private void radioButton1_CheckedChanged_1(object sender, EventArgs e)
        {

        }

        private void Save_Click(object sender, EventArgs e)
        {
            if (Easy.Checked)
            {
                SettingsSave.Default.Diffuculty = "Easy";
                SettingsSave.Default.Width = 15;
                SettingsSave.Default.Height = 15;
            }
            else if (Normal.Checked)
            {
                SettingsSave.Default.Diffuculty = "Normal";
                SettingsSave.Default.Width = 9;
                SettingsSave.Default.Height = 9;
            }
            else if (Hard.Checked)
            {
                SettingsSave.Default.Diffuculty = "Hard";
                SettingsSave.Default.Width = 6;
                SettingsSave.Default.Height = 6;
            }
            else if (Custom.Checked)
            {
                SettingsSave.Default.Diffuculty = "Custom";
                try
                {
                    SettingsSave.Default.Width = int.Parse(Width.Text);
                    SettingsSave.Default.Height = int.Parse(Height.Text);
                }
                catch
                {
                    MessageBox.Show("Lütfen bir integer değer giriniz!");
                    return;
                }
                
            }
            SettingsSave.Default.Square = Square.Checked;
            SettingsSave.Default.Triangle = Triangle.Checked;
            SettingsSave.Default.Round = Round.Checked;

            SettingsSave.Default.Red = Red.Checked;
            SettingsSave.Default.Blue = Blue.Checked;
            SettingsSave.Default.Yellow = Yellow.Checked;


            if(SettingsSave.Default.Diffuculty == "Custom")
            {
                bool colorFlag = false;
                if (SettingsSave.Default.Yellow == true) colorFlag = true;
                if (SettingsSave.Default.Red == true) colorFlag = true;
                if (SettingsSave.Default.Blue == true) colorFlag = true;

                bool shapeFlag = false;
                if (SettingsSave.Default.Round == true) shapeFlag = true;
                if (SettingsSave.Default.Triangle == true) shapeFlag = true;
                if (SettingsSave.Default.Square == true) shapeFlag = true;

                if (!colorFlag || !shapeFlag)
                {
                    MessageBox.Show("At least 1 shape and 1 color had to be chosen when in custom level");
                    return;
                }
            }

            SettingsSave.Default.Save();            
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
            Shapes.Visible = false;
            Colors.Visible = false;
        }

        private void Normal_CheckedChanged(object sender, EventArgs e)
        {
            Width.Visible = false;
            Height.Visible = false;
            label3.Visible = false;
            label4.Visible = false;
            Shapes.Visible = false;
            Colors.Visible = false;
        }

        private void Hard_CheckedChanged(object sender, EventArgs e)
        {
             Width.Visible = false;
             Height.Visible = false;
             label3.Visible = false;
             label4.Visible = false;
             Shapes.Visible = false;
             Colors.Visible = false;
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}
