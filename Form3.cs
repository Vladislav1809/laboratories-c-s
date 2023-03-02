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


    public partial class Form3 : Form
    {

        private bool nonNumberEntered = false;

        public Form3()
        {
            InitializeComponent();
            button2.Hide();
            textBox1.KeyDown += textBox_KeyDown;
            textBox1.KeyPress += textBox_KeyPress;
            textBox2.KeyDown += textBox_KeyDown;
            textBox2.KeyPress += textBox_KeyPress;
        }


        private void textBox_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            nonNumberEntered = false;

            if ((e.KeyCode < Keys.D0 || e.KeyCode > Keys.D9)
                && e.KeyCode != Keys.OemMinus
                && e.KeyCode != Keys.Oemcomma
                )
            {
                if (
                    (e.KeyCode < Keys.NumPad0 || e.KeyCode > Keys.NumPad9)
                    && e.KeyCode != Keys.OemMinus
                    && e.KeyCode != Keys.Oemcomma
                )
                {
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

        private void textBox_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (nonNumberEntered == true)
            {
                e.Handled = true;
            }
        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try {
                double x = getCoordinates(textBox1);
                double y = getCoordinates(textBox2);
                checkCoordinates(x, y);
            } catch (ArgumentException)
            {
                return;
            }

            button2.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private double getCoordinates(System.Windows.Forms.TextBox textBox)
        {
            if (string.IsNullOrEmpty(textBox.Text))
            {
                toolTip1.ToolTipTitle = "Возникла ошибка при чтении данных";
                toolTip1.Show("Поле не может быть пустым", textBox1, 5000);
                throw new ArgumentException();
            }
            if (!Double.TryParse(textBox.Text, out double inputValue))
            {
                toolTip1.ToolTipTitle = "Возникла ошибка при получении данных";
                toolTip1.Show("Введите корректное значение", textBox1, 5000);
                throw new ArgumentException();
            }

            return inputValue;
        }

        private void checkCoordinates(double x, double y)
        {

        }
    }
}
