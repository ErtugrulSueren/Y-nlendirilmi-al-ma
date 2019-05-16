using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace WindowsFormsApplication1
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
            label1.Text = "Ticari Seçim";
            MessageBox.Show("Ticari seçim yaptınız.");
            
            form2 frm = new form2();
            
            this.Hide();
            frm.Show();
            
            
        }

        

        
        private void label1_Click_1(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            label1.Text = "Kişisel Seçim";
            MessageBox.Show("Kişisel seçim yaptınız..");

            Form4 frm = new Form4();
            this.Hide();
            frm.Show();
            
            
        }

        
    }
}
