using System;
using System.Windows.Forms;

namespace магазин
{
    public partial class CountsButton : Form
    {
        public string UpdatedValue { get; private set; } // Свойство для возврата значения
        public CountsButton(string initialValue)
        {
            InitializeComponent();
            textBox1.Text = initialValue;
            textBox1.Select();


        }
        // Общий метод для добавления текста кнопок в текстовое поле
        private void AppendTextToTextBox(object sender, EventArgs e)
        {
            if (sender is Button button)
            {
                textBox1.Text += button.Text;
            }
        }
        // Закрытие формы без сохранения
       
        // Подтверждение ввода
        private void button11_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                MessageBox.Show("Поле не может быть пустым.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            UpdatedValue = textBox1.Text; // Сохранение введённого значения
            this.DialogResult = DialogResult.OK; // Установка результата
            this.Close();
        }

        // Удаление последнего символа
        private void button12_Click(object sender, EventArgs e)
        {
        }
        private void CountsButton_Load(object sender, EventArgs e)
        {
            // Подключение всех цифровых кнопок к общему обработчику
            button2.Click += AppendTextToTextBox;
            button3.Click += AppendTextToTextBox;
            button4.Click += AppendTextToTextBox;
            button5.Click += AppendTextToTextBox;
            button6.Click += AppendTextToTextBox;
            button7.Click += AppendTextToTextBox;
            button8.Click += AppendTextToTextBox;
            button9.Click += AppendTextToTextBox;
            button10.Click += AppendTextToTextBox;
            button12.Click += AppendTextToTextBox;
            textBox1.Focus();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBox1.Text))
            {
                textBox1.Text = textBox1.Text.Substring(0, textBox1.Text.Length - 1);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        
        }

        private void button6_Click(object sender, EventArgs e)
        {

        }
    }
}
