using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.Xml;
using System.Xml.Linq;

namespace OOP_LAB1
{
    public partial class ProfilePanel : Form
    {
        public ProfilePanel()
        {
            InitializeComponent();
            LoadTheData();
        }

        public void LoadTheData()
        {
            XmlDocument x = new XmlDocument();
            DataSet ds = new DataSet();
            XmlReader xmlFile;
            xmlFile = XmlReader.Create("../../RegisteredUsers.xml", new XmlReaderSettings());
            ds.ReadXml(xmlFile);
            dataGridView1.DataSource = ds.Tables[0];
            xmlFile.Close();
        }


    }
}
