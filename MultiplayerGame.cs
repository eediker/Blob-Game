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
using System.Net.Sockets;
using System.Net;

namespace OOP_LAB1
{
    public partial class MultiplayerGame : Form
    {
        SqlConnection _connection = new SqlConnection("workstation id=OOP-LAB.mssql.somee.com;packet size=4096;user id=eediker_SQLLogin_1;pwd=jkd89i8yei;data source=OOP-LAB.mssql.somee.com;persist security info=False;initial catalog=OOP-LAB");

        int[,] ButtonInfo = new int[9, 9];
        Button[,] btn = new Button[9, 9];
        bool flag; string Remember;
        private Socket socket;
        BackgroundWorker MessageReceiver = new BackgroundWorker();
        private TcpListener server = null;
        private TcpClient client;
        bool player1 = false;
        bool player2 = false;


        public MultiplayerGame(bool isHost, IPAddress ip = null,int port = 47132)
        {
            InitializeComponent();

            _connection.Open();

            SqlCommand command1 = new SqlCommand("SELECT * FROM Multiplayer Where isServer = 1 ", _connection);
            SqlDataReader reader1 = command1.ExecuteReader();
            if (reader1.Read())
            {
                Player1.Text = reader1["username"].ToString();
            }
            reader1.Close();

            SqlCommand command2 = new SqlCommand("SELECT * FROM Multiplayer Where isServer = 0 ", _connection);
            SqlDataReader reader2 = command2.ExecuteReader();
            if (reader2.Read())
            {
                Player2.Text = reader2["username"].ToString();
            }
            reader2.Close();

            _connection.Close();

            MessageReceiver.DoWork += MessageReceiver_DoWork;
            CheckForIllegalCrossThreadCalls = false;
            if (isHost)
            {
                WhoseTurn.Text = "Your Turn !";
                StartGame();
                server = new TcpListener(ip, 47132);
                server.Start();
                socket = server.AcceptSocket();
                player1 = true;

                // sending the rand shapes to client for the first time
                List<Shape> list2 = new List<Shape>(Random3Objects());
                byte[] shapesToBeSended = new byte[9];
                // 3 + 3 + 3
                int number = 0;
                for (int k = 0; k < 9; k += 3)
                {
                    shapesToBeSended[k] = (byte)list2[number].rowLocation;
                    shapesToBeSended[k + 1] = (byte)list2[number].colLocation;
                    shapesToBeSended[k + 2] = (byte)list2[number].shapeInfo;
                    number++;
                }
                socket.Send(shapesToBeSended);
            }
            else
            {
                try
                {
                    StartGame();
                    player2 = true;
                    client = new TcpClient(ip.ToString(),47132);
                    socket = client.Client;
                    ReceiveRandShapes();
                    MessageReceiver.RunWorkerAsync();
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void MessageReceiver_DoWork(object sender, DoWorkEventArgs e)
        {
            if (CheckIsOver())
            {
                SeekForWinner();
                RestartGame();
                return;
            }

            FreezeButtons();
            WhoseTurn.Text = "Opponent's Turn!";
            ReceiveMove();
            ReceiveRandShapes();
            UpdateScoreLabels();

            WhoseTurn.Text = "Your Turn!";
            if (!CheckIsOver())
                UnFreezeButtons();
        }

        private void ReceiveRandShapes()
        {
            // shapes info in buffer
            byte[] buffer = new byte[9];
            socket.Receive(buffer);

            for(int i = 0; i < 9; i+=3)
            {
                btn[(int)buffer[i], (int)buffer[i+1]].Image = Image.FromFile("../../images/" + ((int)buffer[i+2]).ToString() + ".jpg");
                ButtonInfo[(int)buffer[i], (int)buffer[i+1]] = (int)buffer[i+2];
            }

            if (CheckIsOver())
            {
                SeekForWinner();
                RestartGame();
                return;
            }
        }

        private void ReceiveMove()
        {
            // 0,1,2,3 move info
            byte[] buffer = new byte[4];
            socket.Receive(buffer);
            
            // Take it to the minDistance function after that
            List<QItem> list = new List<QItem>();

            if (minDistance((int)buffer[0], (int)buffer[1], (int)buffer[2], (int)buffer[3], ref list))
            {
                MakeaMove(list);
                CheckIsScore(btn[(int)buffer[2], (int)buffer[3]]);
            }
        }

        void ButtonArray_click(object sender, EventArgs e)
        {
            Button btn_now = sender as Button;
            int i = int.Parse(btn_now.Name.Substring(0, btn_now.Name.IndexOf(',')));
            int j = int.Parse(btn_now.Name.Substring(btn_now.Name.IndexOf(',') + 1));

            if (ButtonInfo[i, j] != 0)
            {
                flag = true;
                Remember = btn_now.Name;
            }
            else if (ButtonInfo[i, j] == 0 && flag == true)
            {
                int x = int.Parse(Remember.Substring(0, Remember.IndexOf(',')));
                int y = int.Parse(Remember.Substring(Remember.IndexOf(',') + 1));

                List<QItem> list = new List<QItem>();

                if (minDistance(x, y, i, j, ref list))
                {
                    // Sending the move data
                    MakeaMove(list);
                    byte[] move = { (byte)x, (byte)y, (byte)i, (byte)j };
                    socket.Send(move);

                    if (CheckIsScore(btn_now))
                    {
                        if (player1)
                        {
                            GiveScore("Host");
                        }
                        else
                        {
                            GiveScore("Client");
                        }
                    }

                    // Sending the datas of shapes
                    List<Shape> list2 = new List<Shape>(Random3Objects());
                    byte[] shapesToBeSended = new byte[9];
                    // 3 + 3 + 3
                    int number = 0;
                    for(int k = 0; k < 9; k +=3)
                    {
                        shapesToBeSended[k] = (byte)list2[number].rowLocation;
                        shapesToBeSended[k + 1] = (byte)list2[number].colLocation;
                        shapesToBeSended[k + 2] = (byte)list2[number].shapeInfo;
                        number++;
                    }
                    socket.Send(shapesToBeSended);

                    MessageReceiver.RunWorkerAsync();
                }
                else
                {
                    MessageBox.Show("No PATH for this move!");
                }
                flag = false;
                Remember = "0";
            }
        }

        private void FreezeButtons()
        {
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    btn[i,j].Enabled = false;
                }
            }
        }

        private void UnFreezeButtons()
        {
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    btn[i, j].Enabled = true;
                }
            }
        }

        private void SeekForWinner()
        {
            if(int.Parse(Player1Score.Text) > int.Parse(Player2Score.Text))
            {
                MessageBox.Show(Player1.Text + " won the game!");
            }
            else if (int.Parse(Player1Score.Text) < int.Parse(Player2Score.Text))
            {
                MessageBox.Show(Player2.Text + " won the game!");
            }
            else
            {
                MessageBox.Show("Thats a draw!!!");
            }
        }

        void StartGame()
        {
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    btn[i, j] = new Button();
                    btn[i, j].Name = i.ToString() + " , " + j.ToString();
                    btn[i, j].Size = new Size(35, 35);
                    btn[i, j].Location = new Point(35 * (j + 2), 35 * (i + 2));
                    btn[i, j].Click += new EventHandler(ButtonArray_click);
                    ButtonInfo[i, j] = 0;
                    Controls.Add(btn[i, j]);
                }
            }
        }

        void RestartGame()
        {
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    ButtonInfo[i, j] = 0;
                    btn[i, j].Image = default;
                }
            }
            _connection.Open();
            SqlCommand command = new SqlCommand("UPDATE Multiplayer SET score = 0", _connection);
            command.ExecuteNonQuery();
            _connection.Close();

        }

        class Shape
        {
            public int rowLocation;
            public int colLocation;
            public int shapeInfo;
            public Shape(int x, int y, int z)
            {
                rowLocation = x;
                colLocation = y;
                shapeInfo = z;
            }
        };

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

        bool minDistance(int srcX, int srcY, int destX, int destY, ref List<QItem> arr)
        {
            char[,] grid = new char[9, 9];
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
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
            bool[,] visited = new bool[9, 9];
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    if (grid[i, j] == '0')
                        visited[i, j] = true;
                    else
                        visited[i, j] = false;

                    // Finding source
                    if (grid[i, j] == 's')
                    {
                        source.row = i;
                        source.col = j;
                    }
                }
            }

            // applying BFS on matrix cells starting from source
            List<QItem> list = new List<QItem>();
            list.Add(source);
            visited[source.row, source.col] = true;
            while (list.Any())
            {
                QItem p = list[0];
                list.RemoveAt(0);

                // Destination found;
                if (grid[p.row, p.col] == 'd')
                {
                    while (p != null)
                    {
                        arr.Add(p);
                        p = p.prev;
                    }
                    return true;
                }


                // moving up
                if (p.row - 1 >= 0 &&
                    visited[p.row - 1, p.col] == false)
                {
                    QItem q = new QItem(p.row - 1, p.col, p.dist + 1);
                    q.prev = p;
                    list.Add(q);
                    visited[p.row - 1, p.col] = true;
                }

                // moving down
                if (p.row + 1 < 9 &&
                    visited[p.row + 1, p.col] == false)
                {
                    QItem q = new QItem(p.row + 1, p.col, p.dist + 1);
                    q.prev = p;
                    list.Add(q);
                    visited[p.row + 1, p.col] = true;
                }

                // moving left
                if (p.col - 1 >= 0 &&
                    visited[p.row, p.col - 1] == false)
                {
                    QItem q = new QItem(p.row, p.col - 1, p.dist + 1);
                    q.prev = p;
                    list.Add(q);
                    visited[p.row, p.col - 1] = true;
                }

                // moving right
                if (p.col + 1 < 9 &&
                    visited[p.row, p.col + 1] == false)
                {
                    QItem q = new QItem(p.row, p.col + 1, p.dist + 1);
                    q.prev = p;
                    list.Add(q);
                    visited[p.row, p.col + 1] = true;
                }
            }
            return false;
        }

        void MakeaMove(List<QItem> list)
        {

            for (int m = list.Count - 1; m > 0; m--)
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

        bool CheckIsScore(Button btn_now)
        {


            int x = int.Parse(btn_now.Name.Substring(0, btn_now.Name.IndexOf(',')));
            int y = int.Parse(btn_now.Name.Substring(btn_now.Name.IndexOf(',') + 1));

            // Checking For Vertical Score

            for (int i = 0; i < 9 - 4; i++)
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
                        return true;
                    }
                }
            }


            // Checking For Horizontal Score

            for (int i = 0; i < 9 - 4; i++)
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
                        return true;
                    }
                }
            }
            return false;
        }

        bool CheckIsOver()
        {
            int number = 0;

            for (int i = 0; i < SettingsSave.Default.Height; i++)
            {
                for (int j = 0; j < SettingsSave.Default.Width; j++)
                {
                    if (ButtonInfo[i, j] == 0)
                    {
                        number++;
                    }
                }
            }
            if (number >= 3)
            {
                return false;
            }
            return true;
        }

        private List<Shape> Random3Objects()
        {
            List<Shape> list = new List<Shape>();

            List<int> list2 = new List<int>();
            list2.Add(2); list2.Add(5);list2.Add(8);

            int x = 3;
            while (x > 0)
            {
                Random rd = new Random();
                int randShape = list2[rd.Next(0,3)];
                int Width = rd.Next(0, 9);
                int Height = rd.Next(0, 9);
                if (ButtonInfo[Height, Width] == 0)
                {
                    btn[Height, Width].Image = Image.FromFile("../../images/" + randShape.ToString() + ".jpg");
                    ButtonInfo[Height, Width] = randShape;
                    x--;
                    list.Add(new Shape(Height,Width,randShape));
                }
            }
            return list;
        }

        void GiveScore(string player)
        {
            if(player == "Host")
            {
                _connection.Open();
                SqlCommand command = new SqlCommand("UPDATE Multiplayer SET score = score + 3 WHERE isServer = 1", _connection);
                command.ExecuteNonQuery();

                SqlCommand command2 = new SqlCommand("SELECT * FROM Multiplayer Where isServer = 1 ", _connection);
                SqlDataReader reader = command2.ExecuteReader();
                if (reader.Read())
                {
                    Player1Score.Text = reader["score"].ToString();
                }

                reader.Close();
                _connection.Close();
            }
            else
            {
                _connection.Open();
                SqlCommand command = new SqlCommand("UPDATE Multiplayer SET score= score + 3 WHERE isServer = 0", _connection);
                command.ExecuteNonQuery();

                SqlCommand command2 = new SqlCommand("SELECT * FROM Multiplayer Where isServer = 0 ", _connection);
                SqlDataReader reader = command2.ExecuteReader();
                if (reader.Read())
                {
                    Player2Score.Text = reader["score"].ToString();
                }

                reader.Close();
                _connection.Close();
            }
        }

        void DestroyBlocks(int[,] arr)
        {
            for (int i = 0; i < 5; i++)
            {
                ButtonInfo[arr[i, 0], arr[i, 1]] = 0;
                btn[arr[i, 0], arr[i, 1]].Image = default;
            }
            System.Media.SoundPlayer player = new System.Media.SoundPlayer("../../sounds/score.wav");
            player.Play();
        }

        private void MultiplayerGame_FormClosing(object sender, FormClosingEventArgs e)
        {
            MessageReceiver.WorkerSupportsCancellation = true;
            MessageReceiver.CancelAsync();
            if (server != null)
                server.Stop();

            _connection.Open();
            SqlCommand command = new SqlCommand("UPDATE Multiplayer SET score= 0", _connection);
            command.ExecuteNonQuery();
            _connection.Close();
        }

        private void UpdateScoreLabels()
        {
            _connection.Open();

            SqlCommand command1 = new SqlCommand("SELECT * FROM Multiplayer Where isServer = 1 ", _connection);
            SqlDataReader reader1 = command1.ExecuteReader();
            if (reader1.Read())
            {
                Player1Score.Text = reader1["score"].ToString();
            }
            reader1.Close();

            SqlCommand command2 = new SqlCommand("SELECT * FROM Multiplayer Where isServer = 0 ", _connection);
            SqlDataReader reader2 = command2.ExecuteReader();
            if (reader2.Read())
            {
                Player2Score.Text = reader2["score"].ToString();
            }
            reader2.Close();
            
            _connection.Close();
        }

    }
}
