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

namespace магазин
{
    public partial class login : Form
    {
        public login()
        {
           InitializeComponent();
        }
        MySqlConnection conn = new MySqlConnection("Server=localhost;Database=magazin;Uid=root;Pwd=;");
        //string ConnStr = "Server=localhost;Database=magazin;Uid=root;Pwd=;";
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Inserting inserting = new Inserting();
            inserting.Show();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            string name = textbox1.Text;
            string pwd = textbox2.Text;
            string c = $"SELECT COUNT(login) FROM customers WHERE login='{name}' AND pwd='{pwd}';";
            try
            {
                if ((name != null) || (pwd != null))
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand(c, conn);
                    MySqlDataReader reader = cmd.ExecuteReader();
                    string s="";
                    while (reader.Read())
                    {
                        s = reader.GetValue(0).ToString();
                    }
                    if (Convert.ToInt32(s) == 1)
                    {
                    //Form1 form = new Form1();   
                        //form.Show();
                        this.Hide();

                    }
                    else
                    {
                        MessageBox.Show("login or password is incorrect");
                    }
                    conn.Close();
                }
                else
                {
                    MessageBox.Show("fill the filds");
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
                //Form1 form = new Form1();   
                //form.Show();

        private void button2_Click(object sender, EventArgs e)
        {
            SignUp signUp = new SignUp();
            signUp.Show();    
        }
    }
}
