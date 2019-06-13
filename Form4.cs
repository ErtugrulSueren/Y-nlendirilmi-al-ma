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
    public partial class Form4 : Form
    {
        public static int net = 0;
        public static int gider = 0;
        public static int gelir = 0;
        public static int sayi1 = 0;
        
        SqlConnection baglanti = new SqlConnection("Data Source=PC-BILGISAYAR\\ERTU;Initial Catalog=Sirayet;Integrated Security=True");
        SqlCommand sil = new SqlCommand();
        
        public static int sayi2 = 0;
        public static int sayi3 = 0;
        public Form4()
        {
            InitializeComponent();
            comboBox1.Items.Add("Maaş");
            comboBox1.Items.Add("Gelir");
            comboBox1.Items.Add("Alışveriş(Market)");
            comboBox1.Items.Add("Alışveriş(Kıyafet)");
            comboBox1.Items.Add("Banyo");
            comboBox1.Items.Add("Mutfak");
            comboBox1.Items.Add("Çocuk");
            comboBox1.Items.Add("Tatil");
            comboBox1.Items.Add("Eğlence");
            comboBox1.Items.Add("Fatura");
            baglanti.Open();
            verilerigörüntüle();
            baglanti.Close();
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
            baglanti.Open();

            sil.CommandText = "DELETE FROM dbo.Sirayet WHERE ID='" + dataGridView1.CurrentRow.Cells[0].Value.ToString() + "'";
            sil.Connection = baglanti;
            sil.ExecuteNonQuery();
            verilerigörüntüle();
            SqlCommand gelirt = new SqlCommand("select sum(Fiyat) from dbo.Sirayet where Acıklama in ('Maaş','Gelir') And Tarih like '" + dateTimePicker1.Value.ToString("yyyy-MM-dd") + "' ");
            SqlCommand gidert = new SqlCommand("select sum(Fiyat) from dbo.Sirayet where Acıklama in ('Alışveriş(Market)','Çocuk','Tatil','Eğlence','Alışveriş(Kıyafet)','Banyo','Mutfak','Fatura') And Tarih like '" + dateTimePicker1.Value.ToString("yyyy-MM-dd") + "' ");
            gelirt.Connection = baglanti;
            gelirt.ExecuteNonQuery();
            string gelir = gelirt.ExecuteScalar().ToString();

            gidert.Connection = baglanti;
            gidert.ExecuteNonQuery();
            string gider = gidert.ExecuteScalar().ToString();
            hesap();
            baglanti.Close();

            label1.Text = Convert.ToString("Net Kazanç : " + net + " TL");
            label2.Text = Convert.ToString("Giderler : " + gider + " TL");
            label3.Text = Convert.ToString("Toplam Gelir : " + gelir + "TL");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string hesap;
            hesap = @"C:\WINDOWS\system32\calc.exe";
            System.Diagnostics.Process.Start(hesap);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            if (comboBox1.Text == "Fatura")
            {
                int ay = Convert.ToInt32(textBox1.Text);
                int ay30 = ay / 30;
                for (int i = 1; i < 31; i++)
                {
                    SqlCommand komut = new SqlCommand("insert into dbo.Sirayet (Acıklama,Fiyat,Nnot,Tarih) values ('" + comboBox1.Text + "','" + ay30 + "','" + richTextBox1.Text + "','" + dateTimePicker1.Value.ToString("yyyy-MM-"+i+"") + "')", baglanti);
                    komut.ExecuteNonQuery();
                }  
                    
                

            }
            else
            {
                SqlCommand komut = new SqlCommand("insert into dbo.Sirayet (Acıklama,Fiyat,Nnot,Tarih) values ('" + comboBox1.Text + "','" + textBox1.Text + "','" + richTextBox1.Text + "','" + dateTimePicker1.Value.ToString("yyyy-MM-dd") + "')", baglanti);
                komut.ExecuteNonQuery();
            }
           

            
            verilerigörüntüle();
             

            textBox1.Clear();
            richTextBox1.Clear();
            SqlCommand gidert = new SqlCommand("select sum(Fiyat) from dbo.Sirayet where Acıklama in ('Alışveriş(Market)','Çocuk','Tatil','Eğlence','Alışveriş(Kıyafet)','Banyo','Mutfak','Fatura') And Tarih like '" + dateTimePicker1.Value.ToString("yyyy-MM-dd") + "' ");
            SqlCommand gelirt = new SqlCommand("select sum(Fiyat) from dbo.Sirayet where Acıklama in ('Maaş','Gelir') And Tarih like '" + dateTimePicker1.Value.ToString("yyyy-MM-dd") + "' ");


            gelirt.Connection = baglanti;
            gelirt.ExecuteNonQuery();
            string gelir = gelirt.ExecuteScalar().ToString();

            gidert.Connection = baglanti;
            gidert.ExecuteNonQuery();
            string gider = gidert.ExecuteScalar().ToString();

            

            hesap();
            baglanti.Close();

            

            

            label4.Text = Convert.ToString("Net Kazanç : " +net+ " TL");
            label5.Text = Convert.ToString("Giderler : " +gider+ " TL");
            label6.Text = Convert.ToString("Toplam Gelir : " +gelir+ "TL");
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            string hesap;
            hesap = @"C:\WINDOWS\system32\calc.exe";
            System.Diagnostics.Process.Start(hesap);
        }

        private void verilerigörüntüle()
        {

            SqlCommand komut = new SqlCommand("SELECT * From Sirayet where Acıklama in ('Maaş','Gelir','Alışveriş(Market)','Çocuk','Tatil','Eğlence','Alışveriş(Kıyafet)','Banyo','Mutfak','Fatura')And Tarih like '" + dateTimePicker1.Value.ToString("yyyy-MM-dd") + "'", baglanti);
            komut.Connection = baglanti;

            SqlDataAdapter adap = new SqlDataAdapter(komut);
            DataTable tablo = new DataTable();

            adap.Fill(tablo);

            dataGridView1.DataSource = tablo;

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void hesap()
        {
            SqlCommand hesap = new SqlCommand("select Fiyat from dbo.Sirayet where Acıklama in ('Maaş','Gelir') And Tarih like '" + dateTimePicker1.Value.ToString("yyyy-MM-dd") + "'", baglanti);

            SqlDataReader verioku = hesap.ExecuteReader();
            sayi2 = 0;
            while (verioku.Read())
            {

                sayi2 += Convert.ToInt32(verioku["Fiyat"]);
            }


            verioku.Close();
            SqlCommand hesap1 = new SqlCommand("select Fiyat from dbo.Sirayet where Acıklama in ('Alışveriş(Market)','Çocuk','Tatil','Eğlence','Alışveriş(Kıyafet)','Banyo','Mutfak','Fatura')And Tarih like '" + dateTimePicker1.Value.ToString("yyyy-MM-dd") + "'", baglanti);
            SqlDataReader verioku1 = hesap1.ExecuteReader();
            sayi3 = 0;
            while (verioku1.Read())
            {

                sayi3 += Convert.ToInt32(verioku1["Fiyat"]);
            }

            verioku1.Close();
            hesap.Dispose();
            hesap1.Dispose();
            net = sayi2 - sayi3;


        }

        private void button5_Click(object sender, EventArgs e)
        {
            verilerigörüntüle();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
        
        }
    }
}
