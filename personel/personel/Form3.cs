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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection("Data Source=SHELLWE\\SQLEXPRESS;Initial Catalog=personel_deneme;Integrated Security=True");
        ErrorProvider provider = new ErrorProvider();
        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult ekle = MessageBox.Show("Veri Eklensin Mi?", "Onay", MessageBoxButtons.YesNo);
            if (ekle == DialogResult.Yes)
            {
                SqlCommand komut = new SqlCommand();
                con.Open();
                komut.Connection = con;
                komut.CommandText = "insert into urun(urun_kod,urun_ad,urun_adet,urun_cesit) values (" + textBox1.Text + ",'" + textBox2.Text + "','" + textBox3.Text + "','" + comboBox1.Text +  "')";
                komut.ExecuteNonQuery();
                con.Close();
                grid();
                comboBox1.ResetText();
                MessageBox.Show("Veriler Eklendi");
                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                comboBox1.Text = "";
            }
        }
            
        void grid()
        {
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter("select * from urun", con);
            DataSet ds = new DataSet();
            da.Fill(ds, "urun");
            dataGridView1.DataSource = ds.Tables["urun"];
            con.Close();

        }

        private void Form3_Load(object sender, EventArgs e)
        {
            
            grid();
            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBox3.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            comboBox1.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult kapa = MessageBox.Show("Anamenüye Dönülsün Mü?", "Giriş Ekranı", MessageBoxButtons.YesNo);
            if (kapa == DialogResult.Yes)
            {
                Form1 frm1 = new Form1();
                this.Hide();
                frm1.Show();

            }
            else if (kapa == DialogResult.No)
            {

            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DialogResult onay = MessageBox.Show("Güncellensin mi ?", "Onay", MessageBoxButtons.YesNo);
            if (onay == DialogResult.Yes)
            {
                SqlCommand update = new SqlCommand();
                con.Open();
                update.Connection = con;
                update.CommandText = "update urun set urun_ad='" + textBox2.Text + "', urun_adet='" + textBox3.Text + "',urun_cesit='" + comboBox1.Text + "' where urun_kod=" + textBox1.Text + "";
                update.ExecuteNonQuery();
                con.Close();
                grid();
                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                comboBox1.Text = "";

                comboBox1.ResetText();
                MessageBox.Show("Güncelleme Tamamlandı");
            }
            else if (onay == DialogResult.No)
            {
                MessageBox.Show("İşlem İptal Edildi");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult silme = MessageBox.Show("Veri Silinsin mi?", "SİL", MessageBoxButtons.YesNo);
            if (silme==DialogResult.Yes)
            {
                SqlCommand sil = new SqlCommand();
                con.Open();
                sil.Connection = con;
                sil.CommandText = "delete from urun where urun_kod=" + textBox1.Text + "";
                sil.ExecuteNonQuery();
                con.Close();
                grid();
                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                comboBox1.Text = "";
            }
            else if (silme==DialogResult.No)
            {

            }
        }

        private void Form3_FormClosed(object sender, FormClosedEventArgs e)
        {
            Form1 frm1 = new Form1();
            this.Hide();
            frm1.Show();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            DialogResult kapa = MessageBox.Show("Anamenüye Dönülsün Mü?", "Giriş Ekranı", MessageBoxButtons.YesNo);
            if (kapa == DialogResult.Yes)
            {
                Form2 frm2 = new Form2();
                this.Hide();
                frm2.Show();

            }
            
        }

        private void textBox1_Validated(object sender, EventArgs e)
        {
            if (textBox1.Text.Trim() == "")
            {
                provider.SetError(textBox1, "Ürün Kodu Girilmeli");
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
                provider.SetError(textBox2, "Ürün Adı Girilmeli");
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
                provider.SetError(textBox3, "Ürün Adedi Girilmeli");
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
                provider.SetError(comboBox1, "Ürün Çeşiti Seçilmeli");
            }
            else
            {
                provider.Clear();
            }
        }
    }
}
