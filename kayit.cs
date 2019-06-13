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
    public partial class kayit : Form
    {
        public kayit()
        {
            InitializeComponent();
        }
        SqlConnection bagla = new SqlConnection("Data Source=PC-BILGISAYAR\\ERTU;Initial Catalog=Kullanıcı;Integrated Security=True");

        private void button1_Click(object sender, EventArgs e)
        {
          try
            {
                

                SqlCommand komut = new SqlCommand("insert into dbo.giris (Ad,Sifre) values ('" + textBox1.Text + "','" + textBox2.Text + "')", bagla);
                bagla.Open();
                komut.ExecuteNonQuery();
                bagla.Close();
                MessageBox.Show("Kayıt Başarılı!");
            }
          catch (Exception)
            {

                MessageBox.Show("Kayıt Başarısız!");
            }

            
        }
    }
}
