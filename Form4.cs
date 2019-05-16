using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form4 : Form
    {
        public static int net = 0;
        public static int gider = 0;
        public static int gelir = 0;
        public static int sayi1 = 0;

        public Form4()
        {
            InitializeComponent();
            comboBox1.Items.Add("Maaş");
            comboBox1.Items.Add("Gelir");
            comboBox1.Items.Add("Alışveriş(Market)");
            comboBox1.Items.Add("Alışveriş(Kıyafet)");
            comboBox1.Items.Add("Gider");
        }

        private void Form4_Load(object sender, EventArgs e)
        {

        }

        private void Acıklama_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Fiyat_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Not_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Acıklama.Items.Remove(Acıklama.SelectedItem);
            Not.Items.Remove(Not.SelectedItem);
            Fiyat.Items.Remove(Fiyat.SelectedItem);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string hesap;
            hesap = @"C:\WINDOWS\system32\calc.exe";
            System.Diagnostics.Process.Start(hesap);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Acıklama.Items.Add(comboBox1.Text);
            Not.Items.Add(richTextBox1.Text);
            Fiyat.Items.Add(textBox1.Text + "  TL");


            sayi1 = Convert.ToInt32(textBox1.Text);



            if (comboBox1.Text == "Maaş")
            {
                net = net + sayi1;
                gelir = gelir + sayi1;
            }
            else if (comboBox1.Text == "Gelir")
            {
                net = net + sayi1;
                gelir = gelir + sayi1;
            }
            else if (comboBox1.Text == "Alışveriş(Market)")
            {
                net = net - sayi1;
                gider = gider - sayi1;
            }
            else if (comboBox1.Text == "Alışveriş(Kıyafet)")
            {
                net = net - sayi1;
                gider = gider - sayi1;
            }
            else if (comboBox1.Text == "Gider")
            {
                net = net - sayi1;
                gider = gider - sayi1;
            }

            label1.Text = Convert.ToString("Net Kazanç : " + net + " TL");
            label2.Text = Convert.ToString("Giderler : " + gider + " TL");
            label3.Text = Convert.ToString("Toplam Gelir : " + gelir + "TL");
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
