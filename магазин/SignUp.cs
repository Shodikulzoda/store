using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace магазин
{
    public partial class SignUp : Form
    {
        MySqlConnection conn = new MySqlConnection("Server=localhost;Database=magazin;Uid=root;Pwd=;");
        public SignUp()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {   
             string loginName = textBox1.Text;
             string pwd1 = textBox2.Text;
             string pwd2 = textBox3.Text;
             string fio = textBox4.Text;
            
             if (pwd1 == pwd2)
             {
                 try
                 {
                     conn.Open();
                     string query = $"INSERT INTO customers(login,pwd,fio) VALUE ('{loginName}','{pwd2}','{fio}');";
                     MySqlCommand command = new MySqlCommand(query, conn);
                     MySqlDataReader reader = command.ExecuteReader();
                     textBox1.Text = "";
                     textBox2.Text = "";
                     textBox3.Text = "";
                     textBox4.Text = "";
                     MessageBox.Show("successful");
                     conn.Close();
                     login login = new login();
                     login.Show();
                }
                catch (Exception ex)
                { MessageBox.Show(ex.Message); }
            }
            else { MessageBox.Show("Paroli ne sovpadayut"); }
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}