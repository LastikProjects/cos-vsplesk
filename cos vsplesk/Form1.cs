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

namespace cos_vsplesk
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string[] lines = File.ReadAllLines("coeffs.txt");
            double[] mas = Array.ConvertAll<string, double>(
               lines[0].Split(' '),
               delegate (string input)
               {
                   return Convert.ToDouble(input);
               });
            double j = 0;
            double []masj=new double [4];
            double[] mas4=new double[4];
            for (int i = 0; i < mas4.Length; i++)
            {
                mas4[i] = mas[i];
                masj[0] += mas4[i];
            }
                        
            double[] mas6 = new double[6];
            for (int i = 0; i < mas6.Length; i++)
            {
                mas6[i] = mas[i + mas4.Length];
                masj[1] += mas6[i];
            }
                        
            double[] mas8 = new double[8];
            for (int i = 0; i < mas8.Length; i++)
            {
                mas8[i] = mas[i + mas4.Length + mas6.Length];
                masj[2] += mas8[i];
            }
               
            double[] mas10 = new double[10];
            for (int i = 0; i < mas10.Length; i++)
            {
                mas10[i] = mas[i + mas4.Length + mas6.Length + mas8.Length];
                masj[3] += mas10[i];
            }

            for (int i = 0; i < mas.Length; i++)
            {
                textBox1.Text += mas[i].ToString() + "  ";
                if (i == 3 | i == 9 | i == 17)
                    textBox1.Text += "\r\n";
            }

            for (int i = 0; i < masj.Length; i++)
            {
                masj[i] *= Math.Sqrt(2);
                textBox2.Text += masj[i].ToString() + "\r\n";
            }
        }
    }
}


