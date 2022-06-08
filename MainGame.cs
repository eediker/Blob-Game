using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace OOP_LAB1
{
    public partial class MainGame : Form
    {
        SqlConnection _connection = new SqlConnection("workstation id=OOP-LAB.mssql.somee.com;packet size=4096;user id=eediker_SQLLogin_1;pwd=jkd89i8yei;data source=OOP-LAB.mssql.somee.com;persist security info=False;initial catalog=OOP-LAB");

        int[,] ButtonInfo = new int[SettingsSave.Default.Height , SettingsSave.Default.Width];
        Button[,] btn = new Button[SettingsSave.Default.Height , SettingsSave.Default.Width];
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

            ShowBestScore.Text = SettingsSave.Default.BestScore.ToString();
            ShowScore.Text = "0";

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
                List<Cell> list = new List<Cell>();  

                if(minDistance(x,y,i,j,ref list))
                {
                    MakeaMove(list);
                    CheckIsScore(btn_now);
                    Random3Objects();
                    ShowScore.Text = score.ToString();
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
                // Updating the highest score if user gets higher than his last highest score
                if(score > SettingsSave.Default.BestScore)
                {
                    try
                    {
                        _connection.Open();
                        SqlCommand command = new SqlCommand("UPDATE Kullanıcılar SET score=@score WHERE username = @username", _connection);
                        command.Parameters.AddWithValue("@username", SettingsSave.Default.Username);
                        command.Parameters.AddWithValue("@score", score);
                        command.ExecuteNonQuery();
                        _connection.Close();
                        SettingsSave.Default.BestScore = score;
                        ShowBestScore.Text = score.ToString();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
                ShowScore.Text = "0";
                RestartGame();
            }
        }

        private void SettingsButton_Click(object sender, EventArgs e)
        {
            int remember2 = SettingsSave.Default.Width;
            int remember3 = SettingsSave.Default.Height;
            string remember = SettingsSave.Default.Diffuculty;

            bool rememberSquare = SettingsSave.Default.Square;
            bool rememberRound = SettingsSave.Default.Round;
            bool rememberTriangle = SettingsSave.Default.Triangle;
            bool rememberRed = SettingsSave.Default.Red;
            bool rememberYellow = SettingsSave.Default.Yellow;
            bool rememberBlue = SettingsSave.Default.Blue;

            var Settings = new Settings();
            Settings.ShowDialog();

            if (SettingsSave.Default.Diffuculty != remember)
            {
                this.Hide();
                var MainGame = new MainGame();
                MainGame.Closed += (s, args) => this.Close();
                MainGame.ShowDialog();
                return;
            }

            if (remember2 != SettingsSave.Default.Width && remember3 != SettingsSave.Default.Height)
            {
                this.Hide();
                var MainGame = new MainGame();
                MainGame.Closed += (s, args) => this.Close();
                MainGame.ShowDialog();
                return;
            }

            if (SettingsSave.Default.Diffuculty == "Custom")
            {
                if (rememberRound != SettingsSave.Default.Round)
                {
                    this.Hide();
                    var MainGame = new MainGame();
                    MainGame.Closed += (s, args) => this.Close();
                    MainGame.ShowDialog();
                    return;
                }
                if (rememberSquare != SettingsSave.Default.Square)
                {
                    this.Hide();
                    var MainGame = new MainGame();
                    MainGame.Closed += (s, args) => this.Close();
                    MainGame.ShowDialog();
                    return;
                }
                if (rememberTriangle != SettingsSave.Default.Triangle)
                {
                    this.Hide();
                    var MainGame = new MainGame();
                    MainGame.Closed += (s, args) => this.Close();
                    MainGame.ShowDialog();
                    return;
                }
                if (rememberRed != SettingsSave.Default.Red)
                {
                    this.Hide();
                    var MainGame = new MainGame();
                    MainGame.Closed += (s, args) => this.Close();
                    MainGame.ShowDialog();
                    return;
                }
                if (rememberYellow != SettingsSave.Default.Yellow)
                {
                    this.Hide();
                    var MainGame = new MainGame();
                    MainGame.Closed += (s, args) => this.Close();
                    MainGame.ShowDialog();
                    return;
                }
                if (rememberBlue != SettingsSave.Default.Blue)
                {
                    this.Hide();
                    var MainGame = new MainGame();
                    MainGame.Closed += (s, args) => this.Close();
                    MainGame.ShowDialog();
                    return;
                }
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

        void Random3Objects()
        {
            List<int> list = new List<int>();
            if (SettingsSave.Default.Diffuculty != "Custom")
            {

                for (int i = 1; i < 10; i++)
                {
                    list.Add(i);
                }
            }
            else
            {
                if (SettingsSave.Default.Round == true)
                {
                    if (SettingsSave.Default.Red == true) list.Add(1);
                    if (SettingsSave.Default.Blue == true) list.Add(4);
                    if (SettingsSave.Default.Yellow == true) list.Add(7);
                }
                if (SettingsSave.Default.Square == true)
                {
                    if (SettingsSave.Default.Red == true) list.Add(2);
                    if (SettingsSave.Default.Blue == true) list.Add(5);
                    if (SettingsSave.Default.Yellow == true) list.Add(8);
                }
                if (SettingsSave.Default.Triangle == true)
                {
                    if (SettingsSave.Default.Red == true) list.Add(3);
                    if (SettingsSave.Default.Blue == true) list.Add(6);
                    if (SettingsSave.Default.Yellow == true) list.Add(9);
                }
            }

            int x = 3;
            while (x > 0)
            {
                Random rd = new Random();
                int randShape = list[rd.Next(0, list.Count)];
                int Width = rd.Next(0, SettingsSave.Default.Width);
                int Height = rd.Next(0, SettingsSave.Default.Height);
                if (ButtonInfo[Height, Width] == 0)
                {
                    btn[Height, Width].Image = Image.FromFile("../../images/" + randShape.ToString() + ".jpg");
                    ButtonInfo[Height, Width] = randShape;
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
        class Cell
        {
            public int row;
            public int col;
            public Cell prev;
            public Cell(int x, int y)
            {
                row = x;
                col = y;
                prev = null;
            }
        };

        bool minDistance(int srcX, int srcY, int destX, int destY,ref List<Cell> arr)
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

            Cell source = new Cell(0, 0);
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
            List<Cell> list = new List<Cell>();
            list.Add(source);
            visited[source.row,source.col] = true;
            while (list.Any())
            {
                Cell p = list[0];
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
                    Cell q = new Cell(p.row - 1, p.col);
                    q.prev = p;
                    list.Add(q);
                    visited[p.row - 1,p.col] = true;
                }
                // moving down
                if (p.row + 1 < SettingsSave.Default.Height &&
                    visited[p.row + 1,p.col] == false)
                {
                    Cell q = new Cell(p.row + 1, p.col);
                    q.prev = p;
                    list.Add(q);
                    visited[p.row + 1,p.col] = true;
                }
                // moving left
                if (p.col - 1 >= 0 &&
                    visited[p.row,p.col - 1] == false)
                {
                    Cell q = new Cell(p.row, p.col - 1);
                    q.prev = p;
                    list.Add(q);
                    visited[p.row,p.col - 1] = true;
                }
                // moving right
                if (p.col + 1 < SettingsSave.Default.Width &&
                    visited[p.row,p.col + 1] == false)
                {
                    Cell q = new Cell(p.row, p.col + 1);
                    q.prev = p;
                    list.Add(q);
                    visited[p.row,p.col + 1] = true;
                }
            }
            return false;
        }

        void MakeaMove(List<Cell> list)
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

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            var LogIn = new LogIn();
            LogIn.Show();
        }

        private void MainGame_FormClosing(object sender, FormClosingEventArgs e)
        {
            var window = MessageBox.Show(
                "Close the window?",
                "Are you sure?",
                MessageBoxButtons.YesNo);

            e.Cancel = (window == DialogResult.No);
        }   
  }
}
 