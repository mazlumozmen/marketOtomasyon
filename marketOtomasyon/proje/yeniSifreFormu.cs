using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace proje
{
    public partial class yeniSifreFormu : Form
    {
        public yeniSifreFormu()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBoxYeniSifre.Text == null || textBoxKulAdi.Text == "" || comboBoxSoru.Text == "" || textBoxYeniSifre2.Text == "" || textBoxCevap.Text == "")
            {
                MessageBox.Show("Alanlar boş bırakılamaz.");
            }
            else
            {
                MySqlConnection baglanti = new MySqlConnection("Server=localhost;Database=proje;Uid=root;SslMode=none");
                baglanti.Open();
                MySqlCommand kontrol = new MySqlCommand("select * from sorucevap where kuladi='"+textBoxKulAdi.Text+"' and soru='"+comboBoxSoru.Text+"' and cevap='"+textBoxCevap.Text+"'",baglanti);
                kontrol.ExecuteNonQuery();
                MySqlDataReader dr = kontrol.ExecuteReader();
                if (dr.Read())
                {
                    dr.Close();
                    MySqlCommand sifreDegis = new MySqlCommand("update kullanicilar set sifre=@sifre where kuladi=@kuladi", baglanti);
                    sifreDegis.Parameters.AddWithValue("@sifre", textBoxYeniSifre2.Text);
                    sifreDegis.Parameters.AddWithValue("@kuladi", textBoxKulAdi.Text);
                    sifreDegis.ExecuteNonQuery();
                    MessageBox.Show("Şifre değiştirildi.");
                    baglanti.Close();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Girilen bilgiler hatalı.");
                }
                textBoxKulAdi.Clear();
                textBoxCevap.Clear();
                textBoxYeniSifre.Clear();
                textBoxYeniSifre2.Clear();
                
                
            }
        }

        private void textBoxYeniSifre_KeyUp(object sender, KeyEventArgs e)
        {
            if (textBoxYeniSifre.Text != textBoxYeniSifre2.Text)
            {
                labelHata.Text = "Şifreler aynı değil.";
                labelHata.ForeColor = Color.DarkRed;
                button1.Enabled = false;

            }
            else
            {
                labelHata.Text = "Şifreler aynı.";
                labelHata.ForeColor = Color.Green;
                button1.Enabled = true;

            }
        }

        private void textBoxYeniSifre2_KeyUp(object sender, KeyEventArgs e)
        {
            if (textBoxYeniSifre.Text != textBoxYeniSifre2.Text)
            {
                labelHata.Text = "Şifreler aynı değil.";
                labelHata.ForeColor = Color.DarkRed;
                button1.Enabled = false;
            }
            else
            {
                labelHata.Text = "Şifreler Aynı.";
                labelHata.ForeColor = Color.Green;
                button1.Enabled = true;
            }
        }

        private void yeniSifreFormu_Load(object sender, EventArgs e)
        {
            
        }
    }
}
