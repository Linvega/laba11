using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Windows.Forms.DataVisualization.Charting;

namespace laba9
{
    public partial class Form1 : Form
    {

        ClassTest obj_1; //инициализация объекта
        public string color_1 = "White", color_2 = "LightGray", color_3 = "Salmon", color_4 = "Black"; //цвета оболочки
        public Form1() //конструктор формы
        {
            Program.f1 = this;
            InitializeComponent();
            colorize();
            img_update();
        }

        public string img_close = "close_rev.png", img_skip = "skip_rev.png", img_config = "Config_rev.png";//изображения оболочки
        public void img_update() //загрузка иконок
        {
            pictureBox1.Image = Image.FromFile(img_close);
            pictureBox2.Image = Image.FromFile(img_skip);
            pictureBox3.Image = Image.FromFile(img_config);
        }
        public void colorize() //специальный метод перекашивания(вся оболочка в разработке)
        {
            this.BackColor = Color.FromName(color_1);

            panel1.BackColor = Color.FromName(color_1);
            panel2.BackColor = Color.FromName(color_4);
            panel3.BackColor = Color.FromName(color_4);
            panel4.BackColor = Color.FromName(color_4);
            panel5.BackColor = Color.FromName(color_4);
            panel6.BackColor = Color.FromName(color_4);
            panel7.BackColor = Color.FromName(color_4);
            panel8.BackColor = Color.FromName(color_4);
            panel12.BackColor = Color.FromName(color_4);

            flowLayoutPanel1.BackColor = Color.FromName(color_4);
            pictureBox1.BackColor = Color.FromName(color_1);
            pictureBox2.BackColor = Color.FromName(color_1);
            pictureBox3.BackColor = Color.FromName(color_1);
            label1.ForeColor = Color.FromName(color_4);
            richTextBox1.ForeColor = Color.FromName(color_4);
            richTextBox1.BackColor = Color.FromName(color_1);

            numericUpDown1.BackColor = Color.FromName(color_1);
            numericUpDown1.ForeColor = Color.FromName(color_4);
            numericUpDown2.BackColor = Color.FromName(color_1);
            numericUpDown2.ForeColor = Color.FromName(color_4);

            label2.ForeColor = Color.FromName(color_4);
            label3.ForeColor = Color.FromName(color_4);
            label4.ForeColor = Color.FromName(color_4);
            label5.ForeColor = Color.FromName(color_4);
            label6.ForeColor = Color.FromName(color_4);
            label7.ForeColor = Color.FromName(color_4);
            label9.ForeColor = Color.FromName(color_4);
            label10.ForeColor = Color.FromName(color_4);
            label11.ForeColor = Color.FromName(color_4);
            label12.ForeColor = Color.FromName(color_4);

            maskedTextBox1.BackColor = Color.FromName(color_1);
            maskedTextBox1.ForeColor = Color.FromName(color_4);
            maskedTextBox2.BackColor = Color.FromName(color_1);
            maskedTextBox2.ForeColor = Color.FromName(color_4);

            button1.ForeColor = Color.FromName(color_4);
            button1.BackColor = Color.FromName(color_1);
            button2.ForeColor = Color.FromName(color_4);
            button2.BackColor = Color.FromName(color_1);
            button3.ForeColor = Color.FromName(color_4);
            button3.BackColor = Color.FromName(color_1);

            checkBox1.ForeColor = Color.FromName(color_4);
            checkBox1.BackColor = Color.FromName(color_1);
            checkBox2.ForeColor = Color.FromName(color_4);
            checkBox2.BackColor = Color.FromName(color_1);
        }


        /*дальше идёт код не по теме
        * это личная работа
        * над своей собственной оболочкой
        * программы
        * всё что помечено "Дизайн" напрямую
        * к работе не относится
        * */

        private Point mouseOffset;
        private bool isMouseDown = false;
        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            int xOffset;
            int yOffset;

            if (e.Button == MouseButtons.Left)
            {
                xOffset = -e.X - SystemInformation.FrameBorderSize.Width + 3;
                yOffset = -e.Y - SystemInformation.FrameBorderSize.Height + 3;
                mouseOffset = new Point(xOffset, yOffset);
                isMouseDown = true;
            }
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (isMouseDown)
            {
                Point mousePos = Control.MousePosition;
                mousePos.Offset(mouseOffset.X, mouseOffset.Y);
                Location = mousePos;
            }
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isMouseDown = false;
            }
        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox1_MouseEnter(object sender, EventArgs e)
        {
            pictureBox1.BackColor = Color.FromName(color_3);
        }

        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            pictureBox1.BackColor = Color.FromName(color_1);
        }

        private void pictureBox2_MouseEnter(object sender, EventArgs e)
        {
            pictureBox2.BackColor = Color.FromName(color_2);
        }

        private void pictureBox2_MouseLeave(object sender, EventArgs e)
        {
            pictureBox2.BackColor = Color.FromName(color_1);
        }

        private void label1_MouseDown(object sender, MouseEventArgs e)
        {
            int xOffset;
            int yOffset;

            if (e.Button == MouseButtons.Left)
            {
                xOffset = -e.X - SystemInformation.FrameBorderSize.Width - 1;
                yOffset = -e.Y - SystemInformation.FrameBorderSize.Height - 4;
                mouseOffset = new Point(xOffset, yOffset);
                isMouseDown = true;
            }

        }

        private void label1_MouseMove(object sender, MouseEventArgs e)
        {
            if (isMouseDown)
            {
                Point mousePos = Control.MousePosition;
                mousePos.Offset(mouseOffset.X, mouseOffset.Y);
                Location = mousePos;
            }

        }

        private void label1_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isMouseDown = false;
            }

        }
        int chek1, chek2, chek; //здесь начинается обработка нажатий клавиш
        private void button1_MouseClick(object sender, MouseEventArgs e) //обработка кнопки создать массив
        {
            label12.Text = "Описание задания";
            chek = 1;
            if (checkBox1.Checked == true) //проверяем чекбоксы
            {
                chek1 = 1;

                FontStyle style = FontStyle.Underline; //стили для создания ячеек
                richTextBox1.Font = new Font(richTextBox1.Font.FontFamily, 10, style);
            }
            else
            {
                chek1 = 0;
                //стили для создания ячеек
                FontStyle style = FontStyle.Regular;
                richTextBox1.Font = new Font(richTextBox1.Font.FontFamily, 10, style);
            }
            if (checkBox2.Checked == true)
            {
                chek2 = 1;
            }
            else
            {
                chek2 = 0;
            }
            try//основной блок проверки критических исключений введённых данных
            {
                //инициализация объекта
                obj_1 = new ClassTest(Convert.ToInt32(numericUpDown1.Value), Convert.ToInt32(numericUpDown2.Value), Convert.ToDouble(maskedTextBox1.Text), Convert.ToDouble(maskedTextBox2.Text), chek1, chek2);//создание объекта
                richTextBox1.Text = obj_1.mass_get();//вывод массива в ричбокс
            }
            catch//уведомление об ошибке
            {
                CustomMessage error = new CustomMessage("Ошибка входных данных.");
                error.Show();
            }
        }
        private void button1_MouseEnter(object sender, EventArgs e)//дизайн кнопок
        {
            button1.ForeColor = Color.FromName(color_1);
            button1.BackColor = Color.FromName(color_4);
        }

        private void button3_MouseClick(object sender, MouseEventArgs e)//обработка нажатия"Максимум из строчек"
        {
            if (chek == 1) //проверяем можно ли нажать
            {
                richTextBox1.Clear();
                richTextBox1.Text = obj_1.mass_get_str_sr();//вызываем метод
                label12.Text = "Среднее арифметическое в каждой строке";//передаём сообщение в строку состояния

            }
            else
            {
                CustomMessage error = new CustomMessage("Сначала создайте массив.");
                error.Show();
            }
        }

        private void button1_MouseLeave(object sender, EventArgs e)//дизайн кнопок
        {
            button1.ForeColor = Color.FromName(color_4);
            button1.BackColor = Color.FromName(color_1);
        }

        private void button3_MouseEnter(object sender, EventArgs e)//дизайн кнопок
        {
            if (chek == 0)
            {
                FontStyle style = FontStyle.Strikeout;
                button3.Font = new Font(button3.Font.FontFamily, 10, style);
            }
            else
            {
                FontStyle style = FontStyle.Regular;
                button3.Font = new Font(button3.Font.FontFamily, 10, style);
            }
            button3.ForeColor = Color.FromName(color_1);
            button3.BackColor = Color.FromName(color_4);
        }

        private void button3_MouseLeave(object sender, EventArgs e)//дизайн кнопок
        {
            FontStyle style = FontStyle.Regular;
            button3.Font = new Font(button3.Font.FontFamily, 10, style);
            button3.ForeColor = Color.FromName(color_4);
            button3.BackColor = Color.FromName(color_1);
        }
        private void button2_MouseClick(object sender, MouseEventArgs e) //обработка нажатия клавиши "Задание 1"
        {
            if (chek == 1) //доступность нажатия
            {
                richTextBox1.Clear();
                richTextBox1.Text += obj_1.mass_get_post_mult();//вызываем метод
                label12.Text = "Определить произведение элементов в тех строках, которые несодержат отрицательных и нулевых элементов";//передаём сообщение в строку состояния
            }
            else
            {
                CustomMessage error = new CustomMessage("Сначала создайте массив.");//сообщение об ошибке
                error.Show();
            }
        }

        private void button2_MouseEnter(object sender, EventArgs e)//дизайн кнопок
        {
            if (chek == 0)
            {
                FontStyle style = FontStyle.Strikeout;
                button2.Font = new Font(button2.Font.FontFamily, 10, style);
            }
            else
            {
                FontStyle style = FontStyle.Regular;
                button2.Font = new Font(button2.Font.FontFamily, 10, style);
            }
            button2.ForeColor = Color.FromName(color_1);
            button2.BackColor = Color.FromName(color_4);
        }

        int mask_1 = 0, mask_2 = 0;
        private void maskedTextBox1_KeyPress(object sender, KeyPressEventArgs e) //обработка второго ввода "Конец"
        {
            if (e.KeyChar.ToString().Equals("-"))//меняем маску ввода при нажатии '-'
            {
                if (mask_1 == 1)
                {
                    mask_1 = 0;
                    maskedTextBox1.Mask = "000.00";
                }
                else
                {
                    mask_1 = 1;
                    maskedTextBox1.Mask = "-000.00";
                }
            }
        }


        private void maskedTextBox2_KeyPress(object sender, KeyPressEventArgs e) //обработка второго ввода "Конец"
        {
            if (e.KeyChar.ToString().Equals("-"))//меняем маску ввода при нажатии '-'
            {
                if (mask_2 == 1)
                {
                    mask_2 = 0;
                    maskedTextBox2.Mask = "000.00";
                }
                else
                {
                    mask_2 = 1;
                    maskedTextBox2.Mask = "-000.00";
                }
            }

        }


        private void button2_MouseLeave(object sender, EventArgs e)//дизайн кнопки
        {
            FontStyle style = FontStyle.Regular;
            button2.Font = new Font(button2.Font.FontFamily, 10, style);
            button2.ForeColor = Color.FromName(color_4);
            button2.BackColor = Color.FromName(color_1);
        }
        private void pictureBox2_MouseClick(object sender, MouseEventArgs e)//кнопка свернуть
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void pictureBox3_MouseLeave(object sender, EventArgs e)//дизайн кнопки
        {
            pictureBox3.BackColor = Color.FromName(color_1);
        }

        private void pictureBox3_MouseEnter(object sender, EventArgs e)//дизайн кнопки
        {
            pictureBox3.BackColor = Color.FromName(color_2);
        }

        private void pictureBox3_MouseClick(object sender, MouseEventArgs e)//кнопка настройки
        {
            Form2 newForm = new Form2();
            newForm.Show();
        }


        
    }
}
