using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace meh2
{
    static class Program
    {

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
        // Функция проверки на число армстронга
        public static bool isArm(int num) {
            int r, sum = 0, temp, l;
            l = num.ToString().Length;
            temp = num;
            while (num > 0) {
                r = num % 10;        
                sum = sum + Convert.ToInt32(Math.Pow(r, l));
                num = num / 10;
            }
            if (temp == sum)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
