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
        int[,] ButtonInfo = new int[SettingsSave.Default.Width , SettingsSave.Default.Height];
        Button[,] btn = new Button[SettingsSave.Default.Width , SettingsSave.Default.Height];
        bool flag; string Remember; int score = 0;
        public MainGame()
        {
            InitializeComponent();

            if (SettingsSave.Default.Username != "admin")
            {
                AdminPanelButton.Visible = false;
            }
            else
            {
                ShowUserProfile.Visible = false;
            }


            StartGame(); ;

        }

        void ButtonArray_click(object sender, EventArgs e)
        {

            Button btn_now = sender as Button;
            int i = int.Parse(btn_now.Name.Substring(0, btn_now.Name.IndexOf(',')));
            int j = int.Parse(btn_now.Name.Substring(btn_now.Name.IndexOf(',') + 1));

            if (ButtonInfo[i,j] != 0)
            {
                flag = true;
                Remember = btn_now.Name;
            }
            else if (ButtonInfo[i,j] == 0 && flag == true)
            {
                int x = int.Parse(Remember.Substring(0, Remember.IndexOf(',')));
                int y = int.Parse(Remember.Substring(Remember.IndexOf(',') + 1));
                List<QItem> list = new List<QItem>();  

                if(minDistance(x,y,i,j,ref list))
                {
                    MakeaMove(list);
                    CheckIsScore(btn_now);
                    Random3Objects();
                }
                else
                {
                    MessageBox.Show("No PATH for this move!");
                }


                flag = false;
                
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
            int remember2 = SettingsSave.Default.Width + SettingsSave.Default.Width;
            Settings.ShowDialog();
            if (SettingsSave.Default.Diffuculty != remember || remember2 != SettingsSave.Default.Width + SettingsSave.Default.Width)
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

            int x = 0;
            for (int i = 0; i < SettingsSave.Default.Height; i++)
            {
                for (int j = 0; j < SettingsSave.Default.Width; j++)
                {
                    if (ButtonInfo[i, j] == 0)
                    {
                        x++;
                    }
                }
            }
            if(x >= 3) x = 3;
   
            while (x > 0)
            {
                Random rd = new Random();
                int randShape = rd.Next(1, 10);
                int Width = rd.Next(0, SettingsSave.Default.Width);
                int Height = rd.Next(0, SettingsSave.Default.Height); 
                if (ButtonInfo[Height,Width] == 0)
                {
                    btn[Height,Width].Image = Image.FromFile("../../images/" + randShape.ToString() + ".jpg");
                    ButtonInfo[Height,Width] = randShape;
                    x--;
                }
            }
        }

        bool CheckIsOver()
        {
            int number = 0;

            for(int i = 0; i < SettingsSave.Default.Height; i++)
            {
                for(int j = 0; j < SettingsSave.Default.Width; j++)
                {
                    if (ButtonInfo[i,j] == 0)
                    {
                        number++;
                    }
                }
            }
            if(number >= 3)
            {
                return false;
            }
            MessageBox.Show("GAME IS OVER!!!");
            return true;
        }

        class QItem
        {
            public int row;
            public int col;
            public int dist;
            public QItem prev;
            public QItem(int x, int y, int w)
            {
                row = x;
                col = y;
                prev = null;
            }
        };


        bool minDistance(int srcX, int srcY, int destX, int destY,ref List<QItem> arr)
        {
            char[,] grid = new char[SettingsSave.Default.Height, SettingsSave.Default.Width];
            for (int i = 0; i < SettingsSave.Default.Height; i++)
            {
                for (int j = 0; j < SettingsSave.Default.Width; j++)
                {
                    if (ButtonInfo[i, j] != 0) grid[i, j] = '0';
                    if (ButtonInfo[i, j] == 0) grid[i, j] = '*';
                    if (i == srcX && j == srcY) grid[i, j] = 's';
                    if (i == destX && j == destY) grid[i, j] = 'd';
                }
            }


            QItem source = new QItem(0, 0, 0);

            // To keep track of visited QItems. Marking
            // blocked cells as visited.
            bool[,] visited = new bool[SettingsSave.Default.Height,SettingsSave.Default.Width] ;
            for (int i = 0; i < SettingsSave.Default.Height; i++)
            {
                for (int j = 0; j < SettingsSave.Default.Width; j++)
                {
                    if (grid[i,j] == '0')
                        visited[i,j] = true;
                    else
                        visited[i,j] = false;

                    // Finding source
                    if (grid[i,j] == 's')
                    {
                        source.row = i;
                        source.col = j;
                    }
                }
            }

            // applying BFS on matrix cells starting from source
            List<QItem> list = new List<QItem>();
            list.Add(source);
            visited[source.row,source.col] = true;
            while (list.Any())
            {
                QItem p = list[0];
                list.RemoveAt(0);

                // Destination found;
                if (grid[p.row,p.col] == 'd')
                {
                    while(p != null)
                    {
                        arr.Add(p);
                        p = p.prev;
                    }
                    return true;
                }


                // moving up
                if (p.row - 1 >= 0 &&
                    visited[p.row - 1,p.col] == false)
                {
                    QItem q = new QItem(p.row - 1, p.col, p.dist + 1);
                    q.prev = p;
                    list.Add(q);
                    visited[p.row - 1,p.col] = true;
                }

                // moving down
                if (p.row + 1 < SettingsSave.Default.Height &&
                    visited[p.row + 1,p.col] == false)
                {
                    QItem q = new QItem(p.row + 1, p.col, p.dist + 1);
                    q.prev = p;
                    list.Add(q);
                    visited[p.row + 1,p.col] = true;
                }

                // moving left
                if (p.col - 1 >= 0 &&
                    visited[p.row,p.col - 1] == false)
                {
                    QItem q = new QItem(p.row, p.col - 1, p.dist + 1);
                    q.prev = p;
                    list.Add(q);
                    visited[p.row,p.col - 1] = true;
                }

                // moving right
                if (p.col + 1 < SettingsSave.Default.Width &&
                    visited[p.row,p.col + 1] == false)
                {
                    QItem q = new QItem(p.row, p.col + 1, p.dist + 1);
                    q.prev = p;
                    list.Add(q);
                    visited[p.row,p.col + 1] = true;
                }
            }
            return false;
        }

        void MakeaMove(List<QItem> list)
        {

            for (int m = list.Count-1; m > 0; m--)
            {
                int sleepTime = 1000;
                Task.Delay(sleepTime).Wait();

                int i = list[m].row;
                int j = list[m].col;

                int x = list[m - 1].row;
                int y = list[m - 1].col;

                btn[x, y].Image = Image.FromFile("../../images/" + ButtonInfo[i, j] + ".jpg");
                ButtonInfo[x, y] = ButtonInfo[i, j];
                ButtonInfo[i, j] = 0;
                btn[i, j].Image = default;

                // Playing Sound for the move
                System.Media.SoundPlayer player = new System.Media.SoundPlayer("../../sounds/move.wav");
                player.Play();

            }

        }



        void StartGame()
        {
            for (int i = 0; i < SettingsSave.Default.Height; i++)
            {
                for (int j = 0; j < SettingsSave.Default.Width; j++)
                {
                    btn[i,j] = new Button();
                    btn[i,j].Name = i.ToString()+ " , " + j.ToString();
                    btn[i,j].Size = new Size(35, 35);
                    btn[i, j].Location = new Point(35 * (j + 2), 35 * (i + 2));
                    btn[i, j].Click += new EventHandler(ButtonArray_click);
                    ButtonInfo[i, j] = 0;
                    Controls.Add(btn[i, j]);
                }
            }
            Random3Objects();
        }

        void RestartGame()
        {
            score = 0;
            for (int i = 0; i < SettingsSave.Default.Height; i++)
            {
                for (int j = 0; j < SettingsSave.Default.Width; j++)
                {
                    ButtonInfo[i,j] = 0;
                    btn[i,j].Image = default;
                }
            }
            Random3Objects();
        }

        void CheckIsScore(Button btn_now)
        {


            int x = int.Parse(btn_now.Name.Substring(0, btn_now.Name.IndexOf(',')));
            int y = int.Parse(btn_now.Name.Substring(btn_now.Name.IndexOf(',') + 1));

            // Checking For Vertical Score

            for (int i = 0; i < SettingsSave.Default.Height - 4; i++)
            {
                int[,] arrX = new int[5, 2];
                int LastBlock = ButtonInfo[i, y];
                int count = 0;
                for (int j = 0; j < 5; j++)
                {
                    if (ButtonInfo[i + j, y] == LastBlock && ButtonInfo[i + j, y] != 0)
                    {
                        count++;
                    }
                    if (count == 5)
                    {
                        arrX[4, 0] = i + j - 4;
                        arrX[4, 1] = y;
                        arrX[3, 0] = i + j - 3;
                        arrX[3, 1] = y;
                        arrX[2, 0] = i + j - 2;
                        arrX[2, 1] = y;
                        arrX[1, 0] = i + j - 1;
                        arrX[1, 1] = y;
                        arrX[0, 0] = i + j;
                        arrX[0, 1] = y;
                        DestroyBlocks(arrX);
                        GiveScore();
                    }
                }
            }


            // Checking For Horizontal Score

            for (int i = 0; i < SettingsSave.Default.Width - 4; i++)
            {
                int[,] arrY = new int[5, 2];
                int LastBlock = ButtonInfo[x, i];
                int count = 0;
                for (int j = 0; j < 5; j++)
                {
                    if (ButtonInfo[x, i + j] == LastBlock && ButtonInfo[x, i + j] != 0)
                    {
                        count++;
                    }
                    else
                    {
                        break;
                    }
                    if (count == 5)
                    {
                        arrY[4, 1] = i + j - 4;
                        arrY[4, 0] = x;
                        arrY[3, 1] = i + j - 3;
                        arrY[3, 0] = x;
                        arrY[2, 1] = i + j - 2;
                        arrY[2, 0] = x;
                        arrY[1, 1] = i + j - 1;
                        arrY[1, 0] = x;
                        arrY[0, 1] = i + j;
                        arrY[0, 0] = x;
                        DestroyBlocks(arrY);
                        GiveScore();
                    }
                }
            }

        }

        void DestroyBlocks(int[,] arr)
        {
            for(int i = 0; i < 5; i++)
            {
                ButtonInfo[arr[i, 0], arr[i, 1]] = 0;
                btn[arr[i, 0], arr[i, 1]].Image = default;
            }
            System.Media.SoundPlayer player = new System.Media.SoundPlayer("../../sounds/score.wav");
            player.Play();
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
 