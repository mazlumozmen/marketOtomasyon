using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using MySql.Data.MySqlClient;
using System.Collections;

namespace proje
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            labelSimdikiKullanici.Text = girisformu.ad+" "+girisformu.soyad;
            panelHesap.Visible = false;
            panelStok.Visible = false;
            panel3.Visible = false;
            panel1.Visible = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            panelStok.Visible = false;
            panelHesap.Visible = false;
            panel3.Visible = false;
            panel1.Visible = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(girisformu.kullanici=="admin" || girisformu.yetki=="var")
            {
                panelHesap.Visible = false;
                panel1.Visible = false;
                panel3.Visible = false;
                panelStok.Visible = true;
                listViewStok.Items.Clear();
                MySqlConnection baglanti = new MySqlConnection("Server=localhost;Database=proje;Uid=root;SslMode=none");
                baglanti.Open();
                MySqlCommand getir = new MySqlCommand("select * from urunler", baglanti);
                MySqlDataReader dr = getir.ExecuteReader();
                while (dr.Read())
                {
                    ListViewItem Kullanici = new ListViewItem((string)dr["urunkodu"]);
                    Kullanici.SubItems.Add((string)dr["ad"]);
                    Kullanici.SubItems.Add((string)dr["kategori"]);
                    Kullanici.SubItems.Add((string)dr["adet"].ToString());
                    Kullanici.SubItems.Add((string)dr["fiyat"].ToString());
                    listViewStok.Items.Add(Kullanici);

                }
            }
            else
            {
                MessageBox.Show("Bu işlemler sadece admin içindir.");
            }
            
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if(girisformu.kullanici=="admin" || girisformu.yetki=="var")
            {
                listViewIslem.Items.Clear();
                listViewHesap.Items.Clear();
                panel3.Visible = false;
                panelStok.Visible = false;
                panel1.Visible = false;
                panelHesap.Visible = true;
                MySqlConnection baglanti = new MySqlConnection("Server=localhost;Database=proje;Uid=root;SslMode=none");
                baglanti.Open();
                MySqlCommand getir = new MySqlCommand("select * from islemler",baglanti);
                getir.ExecuteNonQuery();
                MySqlDataReader dr = getir.ExecuteReader();
                while (dr.Read())
                {
                    ListViewItem islem = new ListViewItem(dr["islemid"].ToString());
                    islem.SubItems.Add((string)dr["urunkodu"]);
                    islem.SubItems.Add((string)dr["tarih"]);
                    islem.SubItems.Add((string)dr["kuladi"]);
                    islem.SubItems.Add(dr["fiyat"].ToString());
                    listViewIslem.Items.Add(islem);
                }
                dr.Close();
                MySqlCommand getir2 = new MySqlCommand("select * from hesap", baglanti);
                getir.ExecuteNonQuery();
                MySqlDataReader dr2 = getir2.ExecuteReader();
                while (dr2.Read())
                { 

                    ListViewItem hesap = new ListViewItem(dr2["hesapid"].ToString());
                    hesap.SubItems.Add((string)dr2["kuladi"]);
                    hesap.SubItems.Add((string)dr2["tarih"]);
                    hesap.SubItems.Add(dr2["para"].ToString());
                    listViewHesap.Items.Add(hesap);
                }
                baglanti.Close();

            }
            
            else
            {
                MessageBox.Show("Bu işlemler sadece admin için geçerlidir.");
            }
        }

        int sira = 1;
        double toplam = 0;
        private void buttonOku_Click(object sender, EventArgs e)
        {
            if(textBoxUrunKodu.Text==""||textBoxUrunAdet.Text=="")
            {
                MessageBox.Show("Alanlar boş geçilemez.");
            }
            else
            {
                MySqlConnection baglanti = new MySqlConnection("Server=localhost;Database=proje;Uid=root;SslMode=none");
                baglanti.Open();
                MySqlCommand komut = new MySqlCommand("select * from urunler where urunkodu='" + textBoxUrunKodu.Text + "'", baglanti);
                MySqlDataReader dr = komut.ExecuteReader();
                if (dr.Read())
                {
                    toplam = double.Parse(textBoxUrunAdet.Text) * (double)dr["fiyat"];
                    label6.Text = "Toplam: " + toplam.ToString() + " TL";
                    labelUrun.Text = "Okunan Ürün: " + (string)dr["ad"];
                }
                else
                {
                    MessageBox.Show("Yanlış kod girdiniz.");
                }
                baglanti.Close();
            }
            

            

        }


        private void buttonTemizle_Click(object sender, EventArgs e)
        {
            textBoxUrunAdet.Clear();
            textBoxUrunKodu.Clear();
            labelUrun.Text = "Okunan Ürün:";
        }

        private void buttonListeTemizle_Click(object sender, EventArgs e)
        {
            
        }

        private void buttonSepetTemizle_Click(object sender, EventArgs e)
        {
            sira2 = 0;
            listViewSepet.Items.Clear();
        }

        private void buttonGeriAl_Click(object sender, EventArgs e)
        {
            if(adetler.Count==0)
            {
                MessageBox.Show("Seçim yapmadınız.");
            }
            else
            {
                listViewSepet.Items.RemoveAt(listViewSepet.SelectedItems[0].Index);
            }
            
        }


        private void buttonSifreDegis_Click(object sender, EventArgs e)
        {
            if(textBoxEskiSifre.Text=="" || textBoxYeniSifre.Text=="" || textBoxYeniSifre2.Text=="")
            {
                MessageBox.Show("Alanlar boş geçilimez.");
            }
            else
            {
                MySqlConnection baglanti = new MySqlConnection("Server=localhost;Database=proje;Uid=root;SslMode=none");
                baglanti.Open();
                MySqlCommand getir = new MySqlCommand("select * from kullanicilar where kuladi='" + girisformu.kullanici + "' and sifre='" + textBoxEskiSifre.Text + "'", baglanti);
                MySqlDataReader dr = getir.ExecuteReader();
                if (dr.Read())
                {
                    dr.Close();
                    MySqlCommand sifreDegis = new MySqlCommand("update kullanicilar set sifre=@sifre where kuladi=@kuladi", baglanti);
                    sifreDegis.Parameters.AddWithValue("@sifre", textBoxYeniSifre2.Text);
                    sifreDegis.Parameters.AddWithValue("@kuladi", girisformu.kullanici);
                    sifreDegis.ExecuteNonQuery();
                    MessageBox.Show("Şifre değiştirildi.");
                    textBoxEskiSifre.Clear();
                    textBoxYeniSifre.Clear();
                    textBoxYeniSifre2.Clear();
                }
                else
                {
                    MessageBox.Show("Eski şifre hatalı.");
                }
                baglanti.Close();
            }
            

        }

        private void buttonKullanici_Click(object sender, EventArgs e)
        {
            if(girisformu.kullanici=="admin" || girisformu.yetki=="var")
            {
                listView1.Items.Clear();
                comboBox1.Items.Clear();
                panelHesap.Visible = false;
                panel1.Visible = false;
                panelStok.Visible = false;
                panel3.Visible = true;
                MySqlConnection baglanti = new MySqlConnection("Server=localhost;Database=proje;Uid=root;SslMode=none");
                baglanti.Open();
                MySqlCommand getir = new MySqlCommand("select * from kullanicilar", baglanti);
                MySqlDataReader dr = getir.ExecuteReader();

                while (dr.Read())
                {
                    comboBox1.Items.Add((string)dr["kuladi"]);
                    ListViewItem Kullanici = new ListViewItem((string)dr["ad"]);
                    Kullanici.SubItems.Add((string)dr["soyad"]);
                    Kullanici.SubItems.Add((string)dr["kuladi"]);
                    listView1.Items.Add(Kullanici);

                }
                
            }
            else
            {
                panelHesap.Visible = false;
                panel1.Visible = false;
                panelStok.Visible = false;
                panel3.Visible = true;
                panelYeniKullanici.Enabled = false;
                panel6.Enabled = false;
            }
           
            
        }

        private void textBoxYeniSifre2_KeyUp(object sender, KeyEventArgs e)
        {
            if (textBoxYeniSifre.Text != textBoxYeniSifre2.Text)
            {
                labelHata.Text = "Şifreler aynı değil.";
            }
            else
            {
                labelHata.Text = "";
            }
        }

        private void textBoxYeniSifre_KeyUp(object sender, KeyEventArgs e)
        {
            if (textBoxYeniSifre.Text != textBoxYeniSifre2.Text)
            {
                labelHata.Text = "Şifreler aynı değil.";
            }
            else
            {
                labelHata.Text = "";
            }
        }

        private void buttonCikisYap_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonYeniKullaniciEkle_Click(object sender, EventArgs e)
        {
            if (textBoxYeniSifre3.Text == null || textBoxYeniAd.Text == "" || textBoxYeniKulAdi.Text == "" || textBoxYeniSoyad.Text == "" || comboBoxYeni.Text == "" || comboBoxGizliSoru.Text=="" || textBoxCevap.Text=="")
            {
                MessageBox.Show("Değerler boş bırakılamaz.");
            }
            else
            {
                MySqlConnection baglanti = new MySqlConnection("Server=localhost;Database=proje;Uid=root;SslMode=none");
                baglanti.Open();
                MySqlCommand getir = new MySqlCommand("select * from kullanicilar where kuladi='" + textBoxYeniKulAdi.Text + "'", baglanti);
                MySqlDataReader dr = getir.ExecuteReader();
                if (dr.Read())
                {
                    MessageBox.Show("Bu kullanıcı adı zaten var.");
                    baglanti.Close();
                }
                else
                {
                    dr.Close();
                    MySqlCommand ekle = new MySqlCommand("insert into kullanicilar(kuladi,sifre,ad,soyad,yetki) values('" + textBoxYeniKulAdi.Text + "','" + textBoxYeniSifre3.Text + "','" + textBoxYeniAd.Text + "','" + textBoxYeniSoyad.Text + "','" + comboBoxYeni.Text + "')", baglanti);
                    MySqlCommand sorucevap = new MySqlCommand("insert into sorucevap(kuladi,soru,cevap) values('" + textBoxYeniKulAdi.Text + "','" + comboBoxGizliSoru.Text + "','" + textBoxCevap.Text + "')", baglanti);
                    sorucevap.ExecuteNonQuery();
                    ekle.ExecuteNonQuery();
                    MessageBox.Show("Kullanıcı eklendi.");
                    baglanti.Close();

                }
            }
            
            textBoxYeniAd.Clear();
            textBoxYeniSoyad.Clear();
            textBoxYeniKulAdi.Clear();
            textBoxYeniSifre3.Clear();
            textBoxCevap.Clear();

        }

        private void buttonKullaniciSil_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem == null)
            {
                MessageBox.Show("Lütfen bir kullanıcı seçiniz.");
            }
            else if (comboBox1.Text == "admin")
            {
                MessageBox.Show("Admin kullanıcısını silemezsiniz.");
            }
            else
            {
                MySqlConnection baglanti = new MySqlConnection("Server=localhost;Database=proje;Uid=root;SslMode=none");
                baglanti.Open();
                MySqlCommand sil = new MySqlCommand("delete from kullanicilar where kuladi='"+comboBox1.SelectedItem+"'",baglanti);
                sil.ExecuteNonQuery();
                comboBox1.Items.Remove(comboBox1.SelectedItem);
                MessageBox.Show("Kullanıcı silindi!");
                baglanti.Close();
            }
        }

        private void buttonYeniUrunEkle_Click(object sender, EventArgs e)
        {
            if(textBoxYeniUrunKodu.Text==""||textBoxYeniUrunAdi.Text==""||textBoxYeniKategori.Text==""||textBoxYeniAdet.Text==""||textBoxYeniFiyat.Text=="")
            {
                MessageBox.Show("Alanlar boş geçilemez.");
            }
            else
            {
                MySqlConnection baglanti = new MySqlConnection("Server=localhost;Database=proje;Uid=root;SslMode=none");
                baglanti.Open();
                MySqlCommand kontrol = new MySqlCommand("select * from urunler where urunkodu='" + textBoxYeniUrunKodu.Text + "'", baglanti);
                kontrol.ExecuteNonQuery();
                MySqlDataReader dr = kontrol.ExecuteReader();
                if (dr.Read())
                {
                    MessageBox.Show("Bu ürün koduna sahip bir ürün zaten var.");
                }
                else
                {
                    dr.Close();
                    MySqlCommand ekle = new MySqlCommand("insert into urunler(urunkodu,ad,kategori,adet,fiyat) values('" + textBoxYeniUrunKodu.Text + "','" + textBoxYeniUrunAdi.Text + "','" + textBoxYeniKategori.Text + "','" + int.Parse(textBoxYeniAdet.Text) + "','" + Convert.ToDouble(textBoxYeniFiyat.Text) + "')", baglanti);
                    ekle.ExecuteNonQuery();
                    baglanti.Close();
                    textBoxYeniUrunKodu.Clear();
                    textBoxYeniUrunAdi.Clear();
                    textBoxYeniKategori.Clear();
                    textBoxYeniAdet.Clear();
                    textBoxYeniFiyat.Clear();
                    MessageBox.Show("Ürün eklendi.");

                }
            }
           
            
        }

        private void textBoxKod_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar >= 48 && (int)e.KeyChar <= 57)
            {
                e.Handled = false;
            }

            else if ((int)e.KeyChar == 8)
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void textBoxUrunAdedi_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar >= 48 && (int)e.KeyChar <= 57)
            {
                e.Handled = false;
            }

            else if ((int)e.KeyChar == 8)
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void textBoxYeniUrunKodu_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar >= 48 && (int)e.KeyChar <= 57)
            {
                e.Handled = false;
            }

            else if ((int)e.KeyChar == 8)
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void textBoxYeniAdet_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar >= 48 && (int)e.KeyChar <= 57)
            {
                e.Handled = false;
            }

            else if ((int)e.KeyChar == 8)
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void textBoxYeniFiyat_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar >= 48 && (int)e.KeyChar <= 57)
            {
                e.Handled = false;
            }

            else if ((int)e.KeyChar == 8)
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void buttonUrunEkle_Click(object sender, EventArgs e)
        {
            if(textBoxKod.Text==""||textBoxUrunAdi.Text==""||textBoxAdet.Text==""||textBoxKategori.Text==""||textBoxFiyat.Text=="")
            {
                MessageBox.Show("Alanlar boş geçilemez.");
            }
            else
            {
                MySqlConnection baglanti = new MySqlConnection("Server=localhost;Database=proje;Uid=root;SslMode=none");
                baglanti.Open();
                MySqlCommand duzenle = new MySqlCommand("update urunler set ad=@ad,kategori=@kategori,adet=@adet,fiyat=@fiyat where urunkodu=@urunkodu", baglanti);
                duzenle.Parameters.AddWithValue("@urunkodu", textBoxKod.Text);
                duzenle.Parameters.AddWithValue("@ad", textBoxUrunAdi.Text);
                duzenle.Parameters.AddWithValue("@kategori", textBoxKategori.Text);
                duzenle.Parameters.AddWithValue("@adet", int.Parse(textBoxAdet.Text));
                duzenle.Parameters.AddWithValue("@fiyat", Convert.ToDouble(textBoxFiyat.Text));
                duzenle.ExecuteNonQuery();
                MessageBox.Show("Düzenleme başarılı.");
                textBoxUrunKodu.Clear();
                textBoxYeniUrunAdi.Clear();
                textBoxKategori.Clear();
                textBoxAdet.Clear();
                textBoxFiyat.Clear();
                baglanti.Close();
            }
            
        }

        private void buttonUrunSil_Click(object sender, EventArgs e)
        {
            if(textBoxKod.Text=="")
            {
                MessageBox.Show("Bu ürün koduna sahip bir ürün yok.");
            }
            else
            {
                MySqlConnection baglanti = new MySqlConnection("Server=localhost;Database=proje;Uid=root;SslMode=none");
                baglanti.Open();
                MySqlCommand sil = new MySqlCommand("delete from urunler where urunkodu='" + textBoxKod.Text + "'", baglanti);
                sil.ExecuteNonQuery();
                MessageBox.Show("Ürün silindi.");
            }
            
        }

        private void textBoxAdet_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar >= 48 && (int)e.KeyChar <= 57)
            {
                e.Handled = false;
            }

            else if ((int)e.KeyChar == 8)
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }
        int sira2 = 1;
        List<double> fiyatlar = new List<double>();
        List<int> adetler = new List<int>();
        List<string> kodlar = new List<string>();
        private void buttonSepeteEkle_Click(object sender, EventArgs e)
        {
            if (textBoxUrunKodu.Text == ""||textBoxUrunAdet.Text=="")
            {
                MessageBox.Show("Lütfen ürün seçiniz.");
            }
            else
            {
                adetler.Add(int.Parse(textBoxUrunAdet.Text));
                kodlar.Add(textBoxUrunKodu.Text);
                MySqlConnection baglanti = new MySqlConnection("Server=localhost;Database=proje;Uid=root;SslMode=none");
                baglanti.Open();
                MySqlCommand getir = new MySqlCommand("select * from urunler where urunkodu='" + textBoxUrunKodu.Text + "'", baglanti);
                MySqlDataReader dr = getir.ExecuteReader();
                if (dr.Read())
                {
                    ListViewItem sepet = new ListViewItem(sira2.ToString());
                    sepet.SubItems.Add((string)dr["ad"]);
                    sepet.SubItems.Add(textBoxUrunAdet.Text);
                    sepet.SubItems.Add((int.Parse(textBoxUrunAdet.Text) * (double)dr["fiyat"]).ToString());
                    listViewSepet.Items.Add(sepet);
                    sira2++;
                    fiyatlar.Add(int.Parse(textBoxUrunAdet.Text) * (double)dr["fiyat"]);

                }
            }
           
        }

        private void buttonSat_Click(object sender, EventArgs e)
        {
            if (listViewSepet.Items.Count==0)
            {
                MessageBox.Show("Sepet boş.");
            }
            else
            {
                MySqlConnection baglanti = new MySqlConnection("Server=localhost;Database=proje;Uid=root;SslMode=none");
                baglanti.Open();
                MySqlCommand sat = new MySqlCommand("insert into islemler(urunkodu,tarih,kuladi,fiyat) values('" + textBoxUrunKodu.Text + "','" + DateTime.Now.ToString() + "','" + girisformu.kullanici + "','" + toplam + "')", baglanti);
                sat.ExecuteNonQuery();
                listViewSepet.Items.Clear();
                sira2 = 1;
                for (int a = 0; a < adetler.Count; a++)
                {
                    MySqlCommand duzenle = new MySqlCommand("update urunler set adet=adet-'" + adetler[a] + "' where urunkodu=@urunkodu", baglanti);
                    MySqlCommand fiyat = new MySqlCommand("update ", baglanti);
                    duzenle.Parameters.AddWithValue("@urunkodu", kodlar[a]);
                    duzenle.ExecuteNonQuery();

                }
                MySqlCommand sat2 = new MySqlCommand("insert into hesap(kuladi,tarih,para) values('" + girisformu.kullanici + "','" + DateTime.Now.ToString() + "','" + toplam + "')", baglanti);
                sat2.ExecuteNonQuery();
                baglanti.Close();
                adetler.Clear();
                kodlar.Clear();
                fiyatlar.Clear();
                MessageBox.Show("Ürünler satıldı.");
            }
            
        }

        private void buttonIslemSil_Click(object sender, EventArgs e)
        {
            MySqlConnection baglanti = new MySqlConnection("Server=localhost;Database=proje;Uid=root;SslMode=none");
            baglanti.Open();
            MySqlCommand sil = new MySqlCommand("delete from islemler",baglanti);
            sil.ExecuteNonQuery();
            MessageBox.Show("Bütün islemler silindi");
            baglanti.Close();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            MySqlConnection baglanti = new MySqlConnection("Server=localhost;Database=proje;Uid=root;SslMode=none");
            baglanti.Open();
            MySqlCommand sil = new MySqlCommand("delete from hesap", baglanti);
            sil.ExecuteNonQuery();
            MessageBox.Show("Bütün islemler silindi");
            baglanti.Close();
        }

        private void buttonIslemKaldir_Click(object sender, EventArgs e)
        {
            if(textBoxIslemId.Text=="")
            {
                MessageBox.Show("Yanlış değer girdiniz");
            }
            else
            {
                MySqlConnection baglanti = new MySqlConnection("Server=localhost;Database=proje;Uid=root;SslMode=none");
                baglanti.Open();
                MySqlCommand getir = new MySqlCommand("select * from islemler where islemid='"+ int.Parse(textBoxIslemId.Text) + "'",baglanti);
                getir.ExecuteNonQuery();
                MySqlDataReader oku = getir.ExecuteReader();
                if(oku.Read())
                {
                    MySqlCommand sil = new MySqlCommand("delete from islemler where islemid='" + int.Parse(textBoxIslemId.Text) + "'", baglanti);
                    sil.ExecuteNonQuery();
                    MessageBox.Show("İşlem silindi");
                    baglanti.Close();
                }
                else
                {
                    MessageBox.Show("Böyle bir kayıt yok.");
                }
                
            }
            
        }

        private void buttonSecilenHesapKaldir_Click(object sender, EventArgs e)
        {
            if (textBoxHesapId.Text == "")
            {
                MessageBox.Show("Yanlış değer girdiniz");
            }
            else
            {
                MySqlConnection baglanti = new MySqlConnection("Server=localhost;Database=proje;Uid=root;SslMode=none");
                baglanti.Open();
                MySqlCommand getir = new MySqlCommand("select * from hesap where hesapid='" + int.Parse(textBoxHesapId.Text) + "'", baglanti);
                getir.ExecuteNonQuery();
                MySqlDataReader oku = getir.ExecuteReader();
                if (oku.Read())
                {
                    MySqlCommand sil = new MySqlCommand("delete from hesap where hesapid='" + int.Parse(textBoxHesapId.Text) + "'", baglanti);
                    sil.ExecuteNonQuery();
                    MessageBox.Show("Hesap silindi");
                    baglanti.Close();
                }
                else
                {
                    MessageBox.Show("Böyle bir kayıt yok.");
                }
            }
            
        }

        private void textBoxIslemId_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar >= 48 && (int)e.KeyChar <= 57)
            {
                e.Handled = false;
            }

            else if ((int)e.KeyChar == 8)
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void textBoxHesapId_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar >= 48 && (int)e.KeyChar <= 57)
            {
                e.Handled = false;
            }

            else if ((int)e.KeyChar == 8)
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void textBoxUrunKodu_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar >= 48 && (int)e.KeyChar <= 57)
            {
                e.Handled = false;
            }

            else if ((int)e.KeyChar == 8)
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void textBoxUrunAdet_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar >= 48 && (int)e.KeyChar <= 57)
            {
                e.Handled = false;
            }

            else if ((int)e.KeyChar == 8)
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }
    }
}
