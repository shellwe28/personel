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
namespace personel
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection("Data Source=SHELLWE\\SQLEXPRESS;Initial Catalog=personel_deneme;Integrated Security=True");//Sql Bağlantı Bölümü
        ErrorProvider provider = new ErrorProvider();
        private void Form1_Load(object sender, EventArgs e)
        {
            this.AcceptButton = button1; this.CancelButton = button2;
            radioButton1.Checked = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                con.Open();
                SqlCommand getir = new SqlCommand("select * from giris where kullaniciadi='" + textBox1.Text + "'and sifre='" + textBox2.Text + "'and yetki='" + "Yönetici" + "'", con);
                SqlDataReader okuma = getir.ExecuteReader();
                if (okuma.Read())
                {
                    MessageBox.Show(" Yetkili Girişi Başarılı" + " " + textBox1.Text + " ");
                    Form2 frm2 = new Form2();
                    this.Hide();
                    frm2.Show();
                    con.Close();
                }
                else
                {
                    MessageBox.Show("Kullanıcı Adı Veya Şifre Yanlış ya da Yetkiniz Bulunmamakta");
                    con.Close();
                }
            }
            if (radioButton2.Checked)
            {
                con.Open();
                SqlCommand getir = new SqlCommand("select * from giris where kullaniciadi='" + textBox1.Text + "'and sifre='" + textBox2.Text + "'", con);
                SqlDataReader okuma = getir.ExecuteReader();
                if (okuma.Read())
                {
                    MessageBox.Show("Kullanıcı Girişi Başarılı" + " " + textBox1.Text + " ");
                    Form4 frm4 = new Form4();
                    this.Hide();
                    frm4.Show();
                    con.Close();
                }
                else
                {
                    MessageBox.Show("Kullanıcı Adı Veya Şifre Yanlış");
                    con.Close();
                }
            }
        }
            
        

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            DialogResult kapa = MessageBox.Show("Uygulama Kapansın mı?", "Exit", MessageBoxButtons.YesNo);
            if (kapa == DialogResult.Yes)
            {
                Application.Exit();

            }
        }

        private void textBox1_Validated(object sender, EventArgs e)
        {
            if (textBox1.Text.Trim()=="")
            {
                provider.SetError(textBox1, "Kullanıcı Adı Girilmeli");
            }
            else
            {
                provider.Clear();
            }
        }

        private void textBox2_Validated(object sender, EventArgs e)
        {
            if (textBox2.Text.Trim() == "")
            {
                provider.SetError(textBox2, "Şifre Girilmeli");
            }
            else
            {
                provider.Clear();
            }
        }
    }
}
