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
    public partial class girisformu : Form
    {
        public girisformu()
        {
            InitializeComponent();
        }
        Form1 ac = new Form1();
        public static string yetki;
        public static string ad;
        public static string soyad;
        public static string kullanici;
     

        private void buttonGirisYap_Click(object sender, EventArgs e)
        {
            MySqlConnection baglanti = new MySqlConnection("Server=localhost;Database=proje;Uid=root;SslMode=none");
            baglanti.Open();
            MySqlCommand komut = new MySqlCommand("select * from kullanicilar where kuladi='" + textBoxKulAdi.Text + "' and sifre='"+textBoxSifre.Text+"'", baglanti);
            MySqlDataReader dr = komut.ExecuteReader();
            if(dr.Read())
            {
                
                girisformu.ad= (string)dr["ad"];
                girisformu.soyad = (string)dr["soyad"];
                girisformu.yetki = (string)dr["yetki"];
                girisformu.kullanici = textBoxKulAdi.Text;

                this.Hide();
                ac.Show();
                
            }
            else
            {
                MessageBox.Show("Kullanıcı adı veya şifre hatalı.");
            }
        }
        yeniSifreFormu yeni = new yeniSifreFormu();
        private void buttonSifreUnuttum_Click(object sender, EventArgs e)
        {
            
            yeni.ShowDialog();
        }

        private void girisformu_Load(object sender, EventArgs e)
        {

        }
    }
}
