using MySql.Data.MySqlClient;
using System;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

        }
        public MySqlConnection mycon;
        public MySqlCommand mycom;

        string connect = "Server=localhost; DataBase= examplecsharp; Uid=root; pwd=; charset=utf8";


        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                MySqlConnection mycon = new MySqlConnection(connect);
                mycon.Open();
                MessageBox.Show("Connected");
                mycon.Close();
            }
            catch { MessageBox.Show("Failed"); }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                string script = scripter.Text;
                mycon = new MySqlConnection(connect);
                mycon.Open();
                MySqlDataAdapter msData = new MySqlDataAdapter(script, connect);
                System.Data.DataTable table = new System.Data.DataTable();
                msData.Fill(table);
                DBView.DataSource = table;
                mycon.Close();

            }
            catch { MessageBox.Show("Failed to connect"); }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                mycon = new MySqlConnection(connect);
                mycon.Open();
                MySqlDataAdapter msData = new MySqlDataAdapter("SELECT * FROM users WHERE 1", connect);
                System.Data.DataTable table = new System.Data.DataTable();
                msData.Fill(table);
                DBView.DataSource = table;
                mycon.Close();
            }
            catch { MessageBox.Show("Failed to connect"); }
        }
    }
}
