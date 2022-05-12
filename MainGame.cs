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
        int[,] matrix = new int[SettingsSave.Default.Height, SettingsSave.Default.Width];
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

                MakeaMove(btn_now);

                flag = false;
                Random3Objects();
                Remember = "0";
            }
            if (CheckIsOver())
            {
                RestartGame();
            }
        }

        private void SettingsButton_Click(object sender, EventArgs e)
        {
            var Settings = new Settings();
            string remember = SettingsSave.Default.Diffuculty;
            Settings.ShowDialog();
            if(SettingsSave.Default.Diffuculty != remember)
            {
                Application.Restart();
            }
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
                int rand_num1 = rd.Next(1, 10);
                int rand_num2 = rd.Next(0, SettingsSave.Default.Width * SettingsSave.Default.Height);
                if (ButtonInfo[rand_num2] == 0)
                {
                    btn[rand_num2].Image = Image.FromFile("../../images/" + rand_num1.ToString() + ".jpg");
                    ButtonInfo[rand_num2] = rand_num1;
                    int height = rand_num2 / SettingsSave.Default.Width;
                    int width = rand_num2 % SettingsSave.Default.Height;
                    matrix[height, width] = rand_num1;
                    x--;
                }
            }
        }

        bool CheckIsOver()
        {

            int i = SettingsSave.Default.Width * SettingsSave.Default.Height-1;
            while (i>=0)
            {
                if(ButtonInfo[i] == 0)
                {
                    return false;
                };
                i--;
            }
            MessageBox.Show("GAME IS OVER!!!");
            return true;
        }

        void MakeaMove(Button btn_now)
        {
            // Changing the values between previous and last clicked buttons
            btn[int.Parse(btn_now.Name)].Image = Image.FromFile("../../images/" + ButtonInfo[int.Parse(Remember)] + ".jpg");
            ButtonInfo[int.Parse(btn_now.Name)] = ButtonInfo[int.Parse(Remember)];
            ButtonInfo[int.Parse(Remember)] = 0;
            btn[int.Parse(Remember)].Image = default;

            int height = int.Parse(btn_now.Name) / SettingsSave.Default.Width;
            int width = int.Parse(btn_now.Name) % SettingsSave.Default.Height;

            matrix[height, width] = ButtonInfo[int.Parse(btn_now.Name)];

            height = int.Parse(Remember) / SettingsSave.Default.Width;
            width = int.Parse(Remember) % SettingsSave.Default.Height;

            matrix[height, width] = 0;
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
                    matrix[i,j] = 0;
                    number++;
                }
            }
            Random3Objects();
        }

        void RestartGame()
        {
            matrix = new int[SettingsSave.Default.Height, SettingsSave.Default.Width];
            ButtonInfo = new int[SettingsSave.Default.Width * SettingsSave.Default.Height];
            btn = new Button[SettingsSave.Default.Width * SettingsSave.Default.Height];
            score = 0;
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
                    matrix[i, j] = 0;
                    btn[number].Image = default;
                    number++;
                }
            }
            Random3Objects();
        }
        
        void GiveScore()
        {
            if (SettingsSave.Default.Diffuculty == "Easy") score += 1;
            else if (SettingsSave.Default.Diffuculty == "Normal") score += 3;
            else if (SettingsSave.Default.Diffuculty == "Hard") score += 5;
            else if (SettingsSave.Default.Diffuculty == "Custom") score += 2;
        }

    }

}
