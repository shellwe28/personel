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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        ErrorProvider provider = new ErrorProvider();
        SqlConnection con = new SqlConnection("Data Source=SHELLWE\\SQLEXPRESS;Initial Catalog=personel_deneme;Integrated Security=True");
        private void Form2_Load(object sender, EventArgs e)
        {
            
            this.CancelButton = button3;
            grid();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult ekle = MessageBox.Show("Veri Eklensin Mi?", "Onay", MessageBoxButtons.YesNo);
            if (ekle==DialogResult.Yes)
            {
                SqlCommand komut = new SqlCommand();
                con.Open();
                komut.Connection = con;
                komut.CommandText = "insert into giris(tcno,ad,soyad,yetki,kullaniciadi,sifre) values (" + textBox1.Text + ",'" + textBox2.Text + "','" + textBox3.Text + "','" + comboBox1.Text + "','" + textBox4.Text + "','" + textBox5.Text + "')";
                komut.ExecuteNonQuery();
                con.Close();
                grid();
                comboBox1.ResetText();
                MessageBox.Show("Veriler Eklendi");
                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                textBox4.Clear();
                textBox5.Clear();
                comboBox1.ResetText();
            }


        }
        void grid()
        {
        con.Open();
            SqlDataAdapter da = new SqlDataAdapter("select * from giris", con);
        DataSet ds = new DataSet();
        da.Fill(ds, "giris");
            dataGridView1.DataSource = ds.Tables["giris"];
            con.Close();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {

            DialogResult silme = MessageBox.Show("Veri Silinsin mi?", "SİL", MessageBoxButtons.YesNo);
            if (silme == DialogResult.Yes)
            {
                SqlCommand sil = new SqlCommand();
                con.Open();
                sil.Connection = con;
                sil.CommandText = "delete from giris where tcno=" + textBox1.Text + "";
                sil.ExecuteNonQuery();
                con.Close();
                grid();
                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                textBox4.Clear();
                textBox5.Clear();
                comboBox1.Text = "";
            }
            else if (silme == DialogResult.No)
            {

            }

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBox3.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            comboBox1.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            textBox4.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            textBox5.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult kapa = MessageBox.Show("Anamenüye Dönülsün Mü?", "Giriş Ekranı", MessageBoxButtons.YesNo);
            if (kapa==DialogResult.Yes)
            {
                Form1 frm1 = new Form1();
                this.Hide();
                frm1.Show();
                
            }
            else if (kapa==DialogResult.No)
            {
                
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            
            DialogResult onay = MessageBox.Show("Güncellensin mi ?", "Onay", MessageBoxButtons.YesNo);
            if (onay==DialogResult.Yes)
            {
                SqlCommand update = new SqlCommand();
                con.Open();
                update.Connection = con;
                update.CommandText = "update giris set ad='" + textBox2.Text + "', soyad='" + textBox3.Text + "',yetki='" + comboBox1.Text + "',kullaniciadi='" + textBox4.Text + "',sifre='" + textBox5.Text + "' where tcno=" + textBox1.Text + "";
                update.ExecuteNonQuery();
                con.Close();
                grid();
                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                textBox4.Clear();
                textBox5.Clear();
                comboBox1.ResetText();
                MessageBox.Show("Güncelleme Tamamlandı");
            }
            else if (onay==DialogResult.No)
            {
                MessageBox.Show("İşlem İptal Edildi");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form3 frm3 = new Form3();
            this.Hide();
            frm3.Show();
        }

        private void textBox1_Validated(object sender, EventArgs e)
        {
            if (textBox1.Text.Trim() == "")
            {
                provider.SetError(textBox1, "TCNO Girilmeli");
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
                provider.SetError(textBox2, "Ad Girilmeli");
            }
            else
            {
                provider.Clear();
            }
        }

        private void textBox3_Validated(object sender, EventArgs e)
        {
            if (textBox3.Text.Trim() == "")
            {
                provider.SetError(textBox3, "Soyad Girilmeli");
            }
            else
            {
                provider.Clear();
            }
        }

        private void comboBox1_Validated(object sender, EventArgs e)
        {
            if (comboBox1.Text.Trim() == "")
            {
                provider.SetError(comboBox1, "Yetki Seçilmeli");
            }
            else
            {
                provider.Clear();
            }
        }

        private void textBox4_Validated(object sender, EventArgs e)
        {
            if (textBox4.Text.Trim() == "")
            {
                provider.SetError(textBox4, "Kullanıcı Adı Girilmeli");
            }
            else
            {
                provider.Clear();
            }
        }

        private void textBox5_Validated(object sender, EventArgs e)
        {
            if (textBox5.Text.Trim() == "")
            {
                provider.SetError(textBox5, "Şifre Girilmeli");
            }
            else
            {
                provider.Clear();
            }
        }
    }
}
