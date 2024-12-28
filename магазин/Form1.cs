using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Media;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using MySql.Data.MySqlClient;
using Mysqlx.Crud;
using MySqlX.XDevAPI.Common;
using магазин;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
namespace MySQLToGridViewExample
{
    public partial class Form1 : Form
    {
        public static Form1 instance;

        //public DataGridViewCell cell3;
        public string CellValue = "";
        MySqlConnection conn = new MySqlConnection("Server=localhost;Database=magazin;Uid=root;Pwd=;");
        public Form1()
        {
            InitializeComponent();
            instance = this;


        }
   
        //public string CountText = "";

        public void AddColumns()
        {
            //for creating Count and delete columns
            DataGridViewTextBoxColumn CountColumn = new DataGridViewTextBoxColumn
            {
                Name = "Count",
                HeaderText = "Count",
            };
            dataGridView1.Columns.Add(CountColumn);
            //Column1.Text = ;
            DataGridViewButtonColumn DeleteColumn = new DataGridViewButtonColumn
            {
                Width = 50,
                Name = "delete",
                HeaderText = "Delete",
                Text = "X",
                UseColumnTextForButtonValue = true
            };
            dataGridView1.Columns.Add(DeleteColumn);
        }
        public void LoadData()
        {
            List<String> Products = new List<String>();


            try
            {
                conn.Open();
                string query = "SELECT * FROM products";
                using (MySqlCommand command = new MySqlCommand(query, conn))
                using (MySqlDataAdapter adapter = new MySqlDataAdapter(command))
                {
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);
                    dataGridView1.DataSource = dataTable;
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}");
            }
        }
        private void Form1_Load_1(object sender, EventArgs e)
        {
            textBox1.Select();
            //LoadData();
            ////AddColumns();
            //dataGridView1.Columns["Сount"].DisplayIndex/ = 3;
            //label7.Text = Calculation();
            label6.Text = DateTime.Now.ToString("dd-MM-yyyy");
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //for deleting column in datagridview fild
            try
            {
                object cell = dataGridView1.Rows[e.RowIndex].Cells["pr_name"].Value;
                string cmd = $"DELETE FROM products WHERE pr_name='{cell.ToString()}'";
                if (e.ColumnIndex == dataGridView1.Columns["delete"].Index && e.RowIndex >= 0)
                {
                    string message = $"Do you want to delete this row?";
                    string title = "Magazin";
                    MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                    DialogResult result = MessageBox.Show(message, title, buttons);
                    if (result == DialogResult.Yes)
                    {
                        //conn.Open();
                        //MySqlCommand command = new MySqlCommand(cmd, conn);
                        //MySqlDataReader reader = command.ExecuteReader();
                        dataGridView1.Rows.RemoveAt(e.RowIndex);
                        Calculation();
                        //conn.Close();
                    }
                }
                else { }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            LoadData();
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
            MessageBox.Show("sfdsf");
            BeginInvoke(() => editColumn(e));
            //if (e.ColumnIndex >= 3)
            //{
            //    MessageBox.Show("end");
            //    Calculation();
            //}
        }
        private void editColumn(DataGridViewCellEventArgs e)
        {
            var cell1 = dataGridView1.Rows[e.RowIndex].Cells["id"];
            var IdValue = cell1.Value;
            var cell2 = dataGridView1.Rows[e.RowIndex].Cells["price"];
            var PriceValue = cell2.Value;
            var cell = dataGridView1.Rows[e.RowIndex].Cells["pr_name"];
            var newValue = cell.Value;
            var v = dataGridView1.Rows[e.RowIndex];
            string command2 = $"UPDATE products SET price={PriceValue.ToString()} WHERE id={IdValue.ToString()};";
            string command = $"UPDATE products SET pr_name ='{newValue}' WHERE id={IdValue};";
            string message = $"Do you want to update {PriceValue} to  this window?";
            string title = "Windows";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result = MessageBox.Show(message, title, buttons);
            if (result == DialogResult.Yes)
            {
                if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
                {
                    conn.Open();
                    if (e.ColumnIndex == 2)
                    {
                        try
                        {
                            MySqlCommand cmd = new MySqlCommand(command, conn);
                            MySqlDataReader ex = cmd.ExecuteReader();

                        }
                        catch (Exception ex2)
                        {
                            MessageBox.Show(ex2.Message);
                        }
                        finally { }
                    }
                    else if (e.ColumnIndex == 3)
                    {
                        try
                        {
                            MySqlCommand cmd = new MySqlCommand(command2, conn);
                            MySqlDataReader ex = cmd.ExecuteReader();
                            //LoadData();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                        finally { }
                    }
                }
            }
            else
            {
                LoadData();
            }
            conn.Close();
        }
        private void button2_Click_1(object sender, EventArgs e)
        {
            login login = new login();
            login.Show();
        }
        DataTable dataTable = new DataTable();
        private void button8_Click(object sender, EventArgs e)
        {
            string poisk = textBox1.Text;
            string str = $"SELECT * FROM products WHERE pr_name LIKE '{poisk}%' limit 1;";
            conn.Open();
            MySqlCommand cmd = new MySqlCommand(str, conn);
            using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
            {
                adapter.Fill(dataTable);
                dataGridView1.DataSource = dataTable;
                AddColumns();
                conn.Close();
                textBox1.Text = null;
            }
        }
        int count = 0;
        void Search()
        {
            //searching
            string poisk = textBox1.Text;
            string str = $"SELECT * FROM products WHERE pr_name LIKE '{poisk}%' limit 1;";
            if (poisk != "")
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(str, conn);
                using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                {
                    adapter.Fill(dataTable);
                    dataGridView1.DataSource = dataTable;
                    if (count == 0)
                    {
                        count++;
                        AddColumns();
                    }
                    conn.Close();
                }
                //Calculation();
                textBox1.Text = null;
            }
        }
        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            //enter event
            if (e.KeyCode == Keys.Enter)
            {
                Search();
                textBox1.Text = "";
            }
            SetDefaultValueForCountColumn();
            Calculation();
        }
        private void SetDefaultValueForCountColumn()
        {
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Cells["Count"].Value == null || string.IsNullOrEmpty(row.Cells["Count"].Value.ToString()))
                {
                    row.Cells["Count"].Value = 1;
                }
            }
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridView1.Columns["Count"].Index && e.RowIndex >= 0)
            {
                string currentValue = dataGridView1.Rows[e.RowIndex].Cells["Count"].Value?.ToString() ?? "";
                using (CountsButton countsButton = new CountsButton(currentValue))
                {
                    if (countsButton.ShowDialog() == DialogResult.OK)
                    {
                        dataGridView1.Rows[e.RowIndex].Cells["Count"].Value = countsButton.UpdatedValue;

                    }
                }
            }
            Calculation();
        }

        private void dataGridView1_DefaultValuesNeeded(object sender, DataGridViewRowEventArgs e)
        {
            //dataGridView1.Columns["Count"].DefaultCellStyle.NullValue = "1"; 
        }

        private void dataGridView1_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (dataGridView1.Columns[e.ColumnIndex].Name == "Count" &&
                string.IsNullOrEmpty(dataGridView1[e.ColumnIndex, e.RowIndex].Value?.ToString()))
            {
                dataGridView1[e.ColumnIndex, e.RowIndex].Value = 1;
            }
        }
        void Calculation()
        {
            //баъди добавит кардан количествя доб куни хато мегуд 
            int count = 0;
            int price = 0;
            int sum = 0;
            for (int i = 0; i < dataGridView1.Rows.Count; ++i)
            {
                count = Convert.ToInt32(dataGridView1.Rows[i].Cells[3].Value);
                price = Convert.ToInt32(dataGridView1.Rows[i].Cells[2].Value);
                sum += price * count;
            }
            label8.Text = sum.ToString();
        }
        private void button6_Click(object sender, EventArgs e)
        {
            Calculation();
        }

        private void dataGridView1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
        }

        private void dataGridView1_CellValuePushed(object sender, DataGridViewCellValueEventArgs e)
        {
        }
        private void button7_Click(object sender, EventArgs e)
        {
            int a = 0;
            var n = dataGridView1.Rows.Count;
            for (int i = dataGridView1.Rows.Count - 1; i >= 0; i--)
            {
                dataGridView1.Rows.RemoveAt(i); 
            }
            Calculation();
            //dataGridView1.Rows.Remove(dataGridView1.Rows[i]);
        }

        private void button4_Click(object sender, EventArgs e)
        {
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {   
        }
    }
}

