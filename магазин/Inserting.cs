using Google.Protobuf.WellKnownTypes;
using MySql.Data.MySqlClient;
using MySQLToGridViewExample;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace магазин
{
    public partial class Inserting : Form
    {
        public Inserting()
        {
            InitializeComponent();
        }
        string strconn = "Server=localhost;Database=magazin;UID=root;Pwd=;";
        private void button1_Click(object sender, EventArgs e)
        {

            string text1 = richTextBox1.Text;
            string text2 = richTextBox2.Text;
            if (string.IsNullOrEmpty(text1) || string.IsNullOrEmpty(text2))
            {
                MessageBox.Show("The fild are empty");
            }
            else
            {
                try
                {
                    using MySqlConnection conn = new MySqlConnection(strconn);
                    string query = $"INSERT INTO products(pr_name,price) VALUE ('{text1}',{text2}); ";
                    conn.Open();
                    MySqlCommand command = new MySqlCommand(query, conn);
                    MySqlDataReader reader = command.ExecuteReader();
                    richTextBox1.Text = "";
                    richTextBox2.Text = "";
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void Inserting_Load(object sender, EventArgs e)
        {
        }

        private void richTextBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
      

        }
    }
}
