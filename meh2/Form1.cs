using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Data.SQLite;
using System.Data;
using System.IO;

namespace meh2
{
    public partial class Form1 : Form
    {
        //DBAccess DBAccessV = new DBAccess(); 

        public Form1()
        {
            InitializeComponent();
        }

       
        // Функция срабатывает при нажатии кнопки Calculate("button1")
        private void button1_Click(object sender, EventArgs e)
        {
            var DBAccessV = new DBAccess();
            DBAccessV.CreateDb();
            DBAccessV.connectDb();
            textBox1.Clear();
            int n = Convert.ToInt32(textBox2.Text);
            getAllNumbers(n, DBAccessV);
            DBAccessV.addData2();
        }
        // Проверко от чисел от 10 до n на то что являются они числами армстронга или нет
        // DBAccess - образец класса доступа бд, передается в функцию чтобы оставить уже созданный коннект с БД
        private void getAllNumbers(int n, DBAccess DBAccessV)
        {
            //var DBAccessV = new DBAccess();
            for (int i = 10; i < n; i++)
            {
                if (Program.isArm(i))
                {
                    // Если является записывам в базу
                    DBAccessV.addData(i);
                    // Вывод чисел прошедших проверку на экран
                    if (textBox1.Text.Length > 0)
                    {
                        textBox1.AppendText(Environment.NewLine);
                    }
                    textBox1.AppendText(i.ToString());
                }
            }
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
