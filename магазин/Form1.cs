using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Xml.Linq;
using MySql.Data.MySqlClient;
using Mysqlx.Crud;
using MySqlX.XDevAPI.Common;
using магазин;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
namespace MySQLToGridViewExample
{
    public partial class Form1 : Form
    {
        private string connectionString = "Server=localhost;Database=magazin;Uid=root;Pwd=;";

        public Form1()
        {
            InitializeComponent();
        }
        public void LoadData()
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT * FROM products";

                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        using (MySqlDataAdapter adapter = new MySqlDataAdapter(command))
                        {
                            DataTable dataTable = new DataTable();
                            adapter.Fill(dataTable);

                            dataGridView1.DataSource = dataTable;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}");
            }
        }
        private void Form1_Load_1(object sender, EventArgs e)
        {
            LoadData();
            columnreplace();
            dataGridView1.CellEndEdit += dataGridView1_CellEndEdit;
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void columnreplace()
        {
            try
            {
                dataGridView1.Columns["id"].DisplayIndex = 0;
                dataGridView1.Columns["pr_name"].DisplayIndex = 1;
                dataGridView1.Columns["price"].DisplayIndex = 2;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "error replaceing column");
            }
        }
        private void dataGridView1_Click(object sender, EventArgs e)
        {
        }
        private void button3_Click(object sender, EventArgs e)
        {
            магазин.Update upd = new магазин.Update();
            upd.Show();

            //using MySqlConnection connection = new MySqlConnection(connectionString);
            //connection.Open();
            //LoadData();
            //string q = $"select * from products";
            //MySqlCommand cmd = new MySqlCommand(q, connection);
            //MySqlDataReader reader = cmd.ExecuteReader();
            //while (reader.Read())
            //{
            //    object id = reader.GetValue(0);
            //}

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Inserting DataAdding = new Inserting();
            DataAdding.Show();
            DataAdding.FormClosed += Newdataadding_FormClosed;
        }

        private void Newdataadding_FormClosed(object sender, FormClosedEventArgs e)
        {
            LoadData();
        }
        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                var cell = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex];
                var newValue = cell.Value;
                //var idValue=
                //string command = $"UPDATE products SET pr_name ='{newValue}' WHERE id=;";
                //MySqlCommand cmd = new MySqlCommand();
            }

        }

        private void dataGridView1_Click_1(object sender, EventArgs e)
        {
        }

        private void button4_Click(object sender, EventArgs e)
        {
           
        }


        //    }


        //    private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        //    {
        //        DataGridView grid = sender as DataGridView;

        //        if (grid != null)
        //        {

        //            string text = grid.Rows[e.RowIndex].Cells[e.ColumnIndex].Value?.ToString();

        //            if (!string.IsNullOrEmpty(text))
        //            {
        //                MessageBox.Show($"Вы ввели: {text}", "Сообщение");
        //            }
        //        }
    }
}
