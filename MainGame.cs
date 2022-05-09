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
    public partial class MainGame : Form
    {
        int[] ButtonInfo = new int[SettingsSave.Default.Width * SettingsSave.Default.Height];
        Button[] btn = new Button[SettingsSave.Default.Width * SettingsSave.Default.Height];
        bool flag; string Remember; int score = 0;
        public MainGame()
        {
            InitializeComponent();

            if(SettingsSave.Default.Username != "admin")
            {
                AdminPanelButton.Visible = false;
            }
            else
            {
                ShowUserProfile.Visible = false;
            }      


            StartGame();;
            
        }

        void ButtonArray_click(object sender, EventArgs e)
        {

            Button btn_now = sender as Button;
            if (ButtonInfo[int.Parse(btn_now.Name)] != 0)
            {
                flag = true;
                Remember = btn_now.Name;
            }
            else if (ButtonInfo[int.Parse(btn_now.Name)] == 0 && flag == true)
            {
                 btn[int.Parse(btn_now.Name)].Image = Image.FromFile("../../images/" + ButtonInfo[int.Parse(Remember)] + ".jpg");
                 ButtonInfo[int.Parse(btn_now.Name)] = ButtonInfo[int.Parse(Remember)];
                 ButtonInfo[int.Parse(Remember)] = 0;
                 btn[int.Parse(Remember)].Image = default;
                 flag = false;
                 Random3Objects();
                 Remember = "0";
            }
            CheckIsOver();
        }

        private void SettingsButton_Click(object sender, EventArgs e)
        {
            var Settings = new Settings();
            Settings.ShowDialog();
        }

        private void AdminPanelButton_Click(object sender, EventArgs e)
        {
            var AdminPanel = new AdminPanel();
            AdminPanel.ShowDialog();
        }

        private void ShowUserProfile_Click(object sender, EventArgs e)
        {
            var MyProfile = new MyProfile();
            MyProfile.ShowDialog();
        }

        private void AboutScreenButton_Click(object sender, EventArgs e)
        {
            var AboutWindow = new AboutWindow();
            AboutWindow.ShowDialog();
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        void Random3Objects()
        {
            int x = 3;
            while (x > 0)
            {
                Random rd = new Random();
                int rand_num1 = rd.Next(1, 9);
                int rand_num2 = rd.Next(0, SettingsSave.Default.Width * SettingsSave.Default.Height);
                if (ButtonInfo[rand_num2] == 0)
                {
                    btn[rand_num2].Image = Image.FromFile("../../images/" + rand_num1.ToString() + ".jpg");
                    ButtonInfo[rand_num2] = rand_num1;
                    x--;
                }
            }
        }

        void CheckIsOver()
        {

            int i = SettingsSave.Default.Width * SettingsSave.Default.Height-1;
            while (i>=0)
            {
                if(ButtonInfo[i] == 0)
                {
                    return;
                };
                i--;
            }
            MessageBox.Show("GAME IS OVER!!!");
            StartGame();
            return;
        }

        void StartGame()
        {
            int number = 0;
            for (int i = 0; i < SettingsSave.Default.Height; i++)
            {
                for (int j = 0; j < SettingsSave.Default.Width; j++)
                {
                    btn[number] = new Button();
                    btn[number].Name = number.ToString();
                    btn[number].Size = new Size(35, 35);
                    btn[number].Location = new Point(35 * (j + 2), 35 * (i + 2));
                    btn[number].Click += new EventHandler(ButtonArray_click);
                    ButtonInfo[number] = 0;
                    Controls.Add(btn[number]);
                    number++;
                }
            }
            Random3Objects();
        }
    }
}
