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

        SqlConnection bagla = new SqlConnection("Data Source=PC-BILGISAYAR\\ERTU;Initial Catalog=Kullanıcı;Integrated Security=True");

        private void giris_Click(object sender, EventArgs e)
        {
         try
            {
                bagla.Open();
                string sql = "select * from dbo.giris where ad=@adi and sifre=@sifre";
                SqlParameter prm1 = new SqlParameter("adi", textBox1.Text.Trim());
                SqlParameter prm2 = new SqlParameter("sifre", textBox2.Text.Trim());
                SqlCommand komut = new SqlCommand(sql, bagla);
                komut.Parameters.Add(prm1);
                komut.Parameters.Add(prm2);
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(komut);
                da.Fill(dt);
                bagla.Close();

                if (dt.Rows.Count > 0)
                {
                    Form4 frm4 = new Form4();
                    frm4.Show();
                    this.Hide();
                    if (textBox1.Text == "admin")
                    {
                        admin adm = new admin();
                        adm.Show();
                    }
                }

                else
                {
                    MessageBox.Show("Hatalı Giriş");
                }

            }
          catch (Exception)
            {
                
                MessageBox.Show("Hatalı Giriş");
            }
            
            
            
            
            /*SqlCommand komut = new SqlCommand("select * Kullanıcı where Kullanıcı Adı' " + textBox1.Text + "'and Şifre='" + textBox2.Text + "'", bagla);
            
            SqlDataReader dr = komut.EndExecuteReader();
            if (dr.Read())
            {
                form2 frm2 = new form2();
            }*/
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                bagla.Open();
                string sql = "select * from dbo.giris where ad=@adi and sifre=@sifre";
                SqlParameter prm1 = new SqlParameter("adi", textBox1.Text.Trim());
                SqlParameter prm2 = new SqlParameter("sifre", textBox2.Text.Trim());
                SqlCommand komut = new SqlCommand(sql, bagla);
                komut.Parameters.Add(prm1);
                komut.Parameters.Add(prm2);
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(komut);
                da.Fill(dt);
                bagla.Close();

                if (dt.Rows.Count > 0)
                {
                    form2 frm2 = new form2();
                    frm2.Show();
                    this.Hide();
                    if (textBox1.Text == "admin")
                    {
                        admin adm = new admin();
                        adm.Show();
                    }
                }

                else
                {
                    MessageBox.Show("Hatalı Giriş");
                }

            }
            catch (Exception)
            {

                MessageBox.Show("Hatalı Giriş");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            kayit kyt = new kayit();
            kyt.Show();
            
        }

        

        

        
        

        

        
    }
}
