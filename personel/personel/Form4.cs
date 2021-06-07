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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection("Data Source=SHELLWE\\SQLEXPRESS;Initial Catalog=personel_deneme;Integrated Security=True");
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            con.Open();
            DataTable tbl = new DataTable();
            SqlDataAdapter ara = new SqlDataAdapter("select * from urun where urun_ad like '%" +textBox1.Text+"%'",con);
            ara.Fill(tbl);
            dataGridView1.DataSource = tbl;
            con.Close();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter("select * from urun", con);
            DataSet ds = new DataSet();
            da.Fill(ds, "urun");
            dataGridView1.DataSource = ds.Tables["urun"];
            con.Close();
            this.Text = "Ürün Arama";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult kapa = MessageBox.Show("Anamenüye Dönülsün Mü?", "Giriş Ekranı", MessageBoxButtons.YesNo);
            if (kapa == DialogResult.Yes)
            {
                Form1 frm1 = new Form1();
                this.Hide();
                frm1.Show();

            }
        }
    }
}
