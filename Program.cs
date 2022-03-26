using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace OOP_LAB1
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new LogIn());
        }
    }

    public class Admin
    {
        private string username;
        public string password;
        public Admin(string username = "admin",string password = "admin")
        {
            Username = username;
            Password = password;
        }

        public string Username
        {
            get { return username; }
            set { username = value; }
        }

        public string Password
        {
            get { return password; }
            set { password = value; }
        }
    }
    public class User
    {
        private string username;
        private string password;
        public User(string username = "user", string password = "user")
        {
            Username = username;
            Password = password;
        }

        public string Username
        {
            get { return username; }
            set { username = value; }
        }

        public string Password
        {
            get { return password; }
            set { password = value; }
        }

    }

    public class Output
    {
        private string filename;
        public Output(string filename = "NewFile")
        {
            this.filename = filename;
        }

        public string Filename
        {
            get { return filename;}
            set { filename = value; }
        }
    }


}
