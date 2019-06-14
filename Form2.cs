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
    public partial class form2 : Form
    {
        public static int net = 0;
        public static int gider = 0;
        public static int gelir = 0;
        public static int sayi1=0;
        
        SqlConnection baglanti = new SqlConnection("Data Source=PC-BILGISAYAR\\ERTU;Initial Catalog=Sirayet;Integrated Security=True");
        SqlCommand sil = new SqlCommand();
        
        
        public static int sayi2 = 0;
        public static int sayi3 = 0;
        public form2()
        {
            InitializeComponent();
            
            
            comboBox1.Items.Add("Satıs");
            comboBox1.Items.Add("Malzeme");
            comboBox1.Items.Add("Toptancı");
            comboBox1.Items.Add("Borç");
            comboBox1.Items.Add("İşciMaaş");
            comboBox1.Items.Add("Fatura-Ticari");
            baglanti.Open();
            verilerigörüntüle();
            baglanti.Close();
        }
    
        
        
        private void button1_Click(object sender, EventArgs e)
        {

             
            baglanti.Open();
            if (comboBox1.Text == "Fatura-Ticari" || comboBox1.Text == "İşciMaaş")
            {
                int ay = Convert.ToInt32(textBox1.Text);
                int ay30 = ay / 30;
                for (int j = 0; j < 4; j++)
                {
                    for (int i = 0; i < 10; i++)
                    {
                        SqlCommand komut = new SqlCommand("insert into dbo.Sirayet (Acıklama,Fiyat,Nnot,Tarih) values ('" + comboBox1.Text + "','" + ay30 + "','" + richTextBox1.Text + "','" + dateTimePicker1.Value.ToString("yyyy-MM-"+j+""+i+"") + "')", baglanti);
                        komut.ExecuteNonQuery();
                    }
                }


            }
            else
            {
                SqlCommand komut = new SqlCommand("insert into dbo.Sirayet (Acıklama,Fiyat,Nnot,Tarih) values ('" + comboBox1.Text + "','" + textBox1.Text + "','" + richTextBox1.Text + "','" + dateTimePicker1.Value.ToString("yyyy-MM-dd") + "')", baglanti);
                komut.ExecuteNonQuery();
                //SqlCommand koomut = new SqlCommand ("select Tarih from where Tarih='dd'",baglanti)
               // int gun = Convert.ToInt32(dateTimePicker1.Value);
            }
            
            
            
            verilerigörüntüle();
            
            
            textBox1.Clear();
            richTextBox1.Clear();
            SqlCommand gidert = new SqlCommand("select sum(Fiyat) from dbo.Sirayet where Acıklama in ('Malzeme','Toptancı','Borç','Fatura-Ticari','İşciMaaş') And Tarih like '" + dateTimePicker1.Value.ToString("yyyy-MM-dd") + "' ");
            SqlCommand gelirt = new SqlCommand("select sum(Fiyat) from dbo.Sirayet where Acıklama='Satıs' And Tarih like '" + dateTimePicker1.Value.ToString("yyyy-MM-dd") + "'");
            gelirt.Connection = baglanti;
            gelirt.ExecuteNonQuery();
            string gelir = gelirt.ExecuteScalar().ToString();

            gidert.Connection = baglanti;
            gidert.ExecuteNonQuery();
            string gider = gidert.ExecuteScalar().ToString();

            hesap();
            baglanti.Close();

            
            
            label1.Text = Convert.ToString("Net Kazanç : "+net+" TL");
            label2.Text = Convert.ToString("Giderler : "+gider+" TL");
            label3.Text = Convert.ToString("Toplam Gelir : "+gelir+"TL");
            
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string hesap;
            hesap = @"C:\WINDOWS\system32\calc.exe";
            System.Diagnostics.Process.Start(hesap);
        }

        
        
        private void button3_Click(object sender, EventArgs e)
        {
            
            
            //SqlCommand komut = new SqlCommand("DELETE FROM dbo.Sirayet WHERE id=@id",baglanti);

            try
            {
                baglanti.Open();

                sil.CommandText = "DELETE FROM dbo.Sirayet WHERE ID='" + dataGridView1.CurrentRow.Cells[0].Value.ToString() + "'";
                sil.Connection = baglanti;
                sil.ExecuteNonQuery();
                verilerigörüntüle();
                SqlCommand gidert = new SqlCommand("select sum(Fiyat) from dbo.Sirayet where Acıklama in ('Malzeme','Toptancı','Borç','Fatura-Ticari','İşciMaaş') And Tarih like '" + dateTimePicker1.Value.ToString("yyyy-MM-dd") + "' ");
                SqlCommand gelirt = new SqlCommand("select sum(Fiyat) from dbo.Sirayet where Acıklama='Satıs' And Tarih like '" + dateTimePicker1.Value.ToString("yyyy-MM-dd") + "'");
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
            catch (Exception)
            {
                
                
            }
            
            
            

            
        }

        

        private void verilerigörüntüle()
        {
            SqlCommand komut = new SqlCommand("SELECT * From Sirayet where Acıklama in ('Malzeme','Toptancı','Borç','Satıs','İşciMaaş','Fatura-Ticari') And Tarih like '" + dateTimePicker1.Value.ToString("yyyy-MM-dd") + "'", baglanti);
           // SqlCommand komut = new SqlCommand("SELECT * From Sirayet where Acıklama in ('Malzeme','Toptancı','Borç','Satıs') And Tarih like '"+dateTimePicker1.Value.ToShortDateString()+"'", baglanti);
            komut.Connection = baglanti;

            SqlDataAdapter adap = new SqlDataAdapter(komut);
            DataTable tablo = new DataTable();

            adap.Fill(tablo);

            dataGridView1.DataSource = tablo;

            //for (int i = 0; i < tablo.Rows.Count; i++)
           // {
                //listView1.Items.Add(tablo.Rows[i]["Acıklama"].ToString());
                //listView1.Items[i].SubItems.Add(tablo.Rows[i]["Fiyat"].ToString());
                //listView1.Items[i].SubItems.Add(tablo.Rows[i]["Nnot"].ToString());
               // listView1.Items[i].SubItems.Add(tablo.Rows[i]["Tarih"].ToString());
                //listView1.Items[i].SubItems.Add(tablo.Rows[i]["id"].ToString());
                
          //  }

            /*SqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                ListViewItem ekle = new ListViewItem();
                ekle.Text = oku["Acıklama"].ToString();
                ekle.SubItems.Add(oku["Fiyat"].ToString());
                ekle.SubItems.Add(oku["Nnot"].ToString());
                ekle.SubItems.Add(oku["Tarih"].ToString());
                ekle.SubItems.Add(oku["id"].ToString());
                listView1.Items.Add(ekle);

            }*/
            

        }

        

        private void hesap() 
        {
            SqlCommand hesap = new SqlCommand("select Fiyat from dbo.Sirayet where Acıklama='Satıs' And Tarih like '" + dateTimePicker1.Value.ToString("yyyy-MM-dd") + "'", baglanti);

            SqlDataReader verioku = hesap.ExecuteReader();
            sayi2 = 0;
            while (verioku.Read())
            {

                sayi2 += Convert.ToInt32(verioku["Fiyat"]);
            }


            verioku.Close();
            SqlCommand hesap1 = new SqlCommand("select Fiyat from dbo.Sirayet where Acıklama in ('Malzeme','Toptancı','Borç','İşciMaaş','Fatura-Ticari') And Tarih like '" + dateTimePicker1.Value.ToString("yyyy-MM-dd") + "'", baglanti);
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

        private void button4_Click(object sender, EventArgs e)
        {
            verilerigörüntüle();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            //textBox1.Text = listView1.SelectedItems[0].SubItems[0].Text;
            //comboBox1.Text = listView1.SelectedItems[0].SubItems[1].Text;
            //richTextBox1.Text = listView1.SelectedItems[0].SubItems[2].Text;
            //dateTimePicker1.Text = listView1.SelectedItems[0].SubItems[3].Text;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

    }
}
