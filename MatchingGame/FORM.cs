using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.IO;

namespace MatchingGame
{
    public partial class FORM : Form
    {
       
        Form1 normal = new Form1();
        Form2 easy = new Form2();
        Form3 hard = new Form3();
        private int timeElapsed = 0;
        private int timeElapsed1 = 0;
        private int timeElapsed2 = 0;
        
        
        



        public FORM()
        {
            InitializeComponent();
            
        }

        private void FORM_Load(object sender, EventArgs e)
        {
            button1.Visible = false;
            button2.Visible = false;
            button3.Visible = false;
      
            ToolTip toolTip = new ToolTip();
            toolTip.SetToolTip(button1, "Легкая игра, по статистике её проходят все");
            toolTip.SetToolTip(button2, "Средняя сложность игры, тут уже все зависит от тебя");
            toolTip.SetToolTip(button3, "Сложный уровень игры, даже почти невозможный, но ты обязательно сможешь!");
            toolTip.SetToolTip(button4, "Таблица рекордов,где можно посомтреть имя пользователя,количество ходов,размер поля");
            toolTip.SetToolTip(button5, "Зарегистрируйся,чтобы продолжить");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            timer1.Start();
            normal.FormClosed += new FormClosedEventHandler(normal_FormClosed);
            normal.ShowDialog();
            timer1.Stop();
            this.Close();
            
        }

        private void normal_FormClosed(object sender,FormClosedEventArgs e)
        {
            timer1.Stop();
            string name = textBox1.Text;
            string time = timeElapsed.ToString();
            string data =   name + ";  " + time + " Normal ";
            StreamWriter sw = new StreamWriter("data.txt",true);
            sw.WriteLine(data);


            sw.Close();

        }
        private void button5_Click(object sender, EventArgs e)
        {
            textBox1.Enabled = false;
            Regex regex = new Regex("^[а-яА-Я]");
            if(textBox1.Text == "")
            {
                MessageBox.Show("Введите имя");
            }
            else if(!regex.IsMatch(textBox1.Text))
            {
                MessageBox.Show("Вводить можно только русские буквы");
            }
            else
            {
                button5.Visible = false;
                button1.Visible = true;
                button2.Visible = true;
                button3.Visible = true;
             
            }
   

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Table results = new Table();
           // this.Hide();
            results.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            timer2.Start();
            easy.FormClosed += new FormClosedEventHandler(easy_FormClosed);
            easy.ShowDialog();  

        }
        private void easy_FormClosed(object sender, FormClosedEventArgs e)
        {
            timer2.Stop();
            string name = textBox1.Text;
            string time = timeElapsed1.ToString();
            string data =  name + "; " + time + " Easy ";
            StreamWriter sw = new StreamWriter("data.txt", true);
            sw.WriteLine(data);


            sw.Close();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            timer3.Start();
             hard.FormClosed += new FormClosedEventHandler(hard_FormClosed);
            hard.ShowDialog();
        }
        private void hard_FormClosed(object sender, FormClosedEventArgs e)
        {
            timer3.Stop();
            string name = textBox1.Text;
            string time = timeElapsed2.ToString();
            string data = name + ";   " + time + " Hard ";
            StreamWriter sw = new StreamWriter("data.txt", true);
            sw.WriteLine(data);


            sw.Close();

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timeElapsed++;
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            timeElapsed1++;
        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            timeElapsed2++;
        }
    }
}
