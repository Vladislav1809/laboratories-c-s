using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{

    public partial class Form2 : Form
    {
        private int notValidValue = -2;

        private bool nonNumberEntered = false;

        public Form2()
        {
            InitializeComponent();
            button2.Hide();
            textBox1.KeyDown += new KeyEventHandler(textBox1_KeyDown);
            textBox1.KeyPress+= textBox1_KeyPress;
        }

        private void textBox1_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            nonNumberEntered = false;
                  
            if ((e.KeyCode < Keys.D0 || e.KeyCode > Keys.D9)
                && e.KeyCode != Keys.OemMinus 
                && e.KeyCode != Keys.Oemcomma
                ) {
                if (
                    (e.KeyCode < Keys.NumPad0 || e.KeyCode > Keys.NumPad9)
                    && e.KeyCode != Keys.OemMinus
                    && e.KeyCode != Keys.Oemcomma
                ) { 
                    if (e.KeyCode != Keys.Back)
                    {
                        nonNumberEntered = true;
                    }
                }
            }
            if (Control.ModifierKeys == Keys.Shift)
            {
                nonNumberEntered = true;
            }
        }

        private void textBox1_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (nonNumberEntered == true)
            {
                e.Handled = true;
            }
        }


        private void Form2_Load(object sender, EventArgs e)
        {
          // button1.Enabled = textBox1.TextLength != 0;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text))
            {
                toolTip1.ToolTipTitle = "Возникла ошибка при чтении данных";
                toolTip1.Show("Поле не может быть пустым", textBox1, 5000);
                return;
            }
            if (!Double.TryParse(textBox1.Text, out double inputValue))
            {
                toolTip1.ToolTipTitle = "Возникла ошибка при получении данных";
                toolTip1.Show("Введите корректное значение", textBox1, 5000);
                return;
            }
            if (inputValue == (double)notValidValue)
            {
                toolTip1.ToolTipTitle = "Возникла ошибка при обработке данных";
                toolTip1.Show("Значение должно взодить в область допустимых", textBox1, 5000);
                return;
            }
            label4.Text = $"Результат: {calculate_function(inputValue)}";
            button2.Show();

        }

        private double calculate_function(double inputValue)
        {
            double val = Math.Abs(Math.Pow(inputValue, 3) + 8);
            return 3 / val;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
