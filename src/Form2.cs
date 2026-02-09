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

namespace WashyPRO
{
    public partial class Form2 : Form
    {
        SqlConnection baglanti = new SqlConnection("Server=DESKTOP-079GM3U\\SQLEXPRESS;Database=WashyProDB;Trusted_Connection=True;");
        public static int GirisYapanKullaniciID;

        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            if (GirisYapanKullaniciID == 0)
            {
                MessageBox.Show("Giriş yapan kullanıcı ID'si 0. Giriş formundan değer gelmiyor!");
            }

            BakiyeGoster();
        }
        private void RaporlariYukle()
        {
            int kullaniciID = GirisYapanKullaniciID; // Bu değişken zaten Form2'de vardır.
            string connectionString = "Server=DESKTOP-079GM3U\\SQLEXPRESS;Database=WashyProDB;Trusted_Connection=True;"; // Kendi bağlantı stringin

            // 1. Geçmiş Rezervasyonlar
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter(@"
            SELECT r.RezervasyonID, m.Tur AS MakineTuru, r.BaslangicZamani, r.BitisZamani, o.Tutar, 
                   CASE WHEN o.Iade = 1 THEN 'Iade' ELSE 'Tahsil' END AS IslemTipi
            FROM Rezervasyon r
            JOIN Makine m ON r.MakineID = m.MakineID
            JOIN Odeme o ON r.RezervasyonID = o.RezervasyonID
            WHERE r.KullaniciID = @KullaniciID
            ORDER BY r.BaslangicZamani DESC
        ", con);
                da.SelectCommand.Parameters.AddWithValue("@KullaniciID", kullaniciID);

                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridViewKullaniciRapor.DataSource = dt;
            }

            // 2. Toplam Tahsilat
            decimal toplamTahsilat = 0;
            decimal toplamIade = 0;
            int iptalSayisi = 0;
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                // Toplam Tahsilat
                SqlCommand komut = new SqlCommand(@"
            SELECT ISNULL(SUM(o.Tutar), 0)
            FROM Odeme o
            JOIN Rezervasyon r ON o.RezervasyonID = r.RezervasyonID
            WHERE r.KullaniciID = @KullaniciID AND o.Iade = 0", con);
                komut.Parameters.AddWithValue("@KullaniciID", kullaniciID);
                con.Open();
                toplamTahsilat = (decimal)komut.ExecuteScalar();
                con.Close();

                // Toplam İade
                komut.CommandText = @"
            SELECT ISNULL(SUM(o.Tutar), 0)
            FROM Odeme o
            JOIN Rezervasyon r ON o.RezervasyonID = r.RezervasyonID
            WHERE r.KullaniciID = @KullaniciID AND o.Iade = 1";
                con.Open();
                toplamIade = (decimal)komut.ExecuteScalar();
                con.Close();

                // İptal Sayısı (Eğer Rezervasyon tablosunda Iptal sütunu eklendiyse)
                komut.CommandText = @"
            SELECT COUNT(*)
            FROM Rezervasyon
            WHERE KullaniciID = @KullaniciID AND Iptal = 1";
                con.Open();
                iptalSayisi = (int)komut.ExecuteScalar();
                con.Close();
            }
            labelTahsilat.Text = "Toplam Tahsilat: " + toplamTahsilat + " TL";
            labelIade.Text = "Toplam İade: " + toplamIade + " TL";
            labelIptal.Text = "İptal Edilen Rezervasyon Sayısı: " + iptalSayisi;
        }

        public void BakiyeGoster()
        {
            using (SqlConnection baglanti = new SqlConnection("Server=DESKTOP-079GM3U\\SQLEXPRESS;Database=WashyProDB;Trusted_Connection=True;"))
            {
                baglanti.Open();

                SqlCommand komut = new SqlCommand("SELECT Bakiye FROM Kullanici WHERE KullaniciID = @id", baglanti);
                komut.Parameters.AddWithValue("@id", GirisYapanKullaniciID);

                object bakiyeObj = komut.ExecuteScalar();
                decimal bakiye = (bakiyeObj != DBNull.Value) ? Convert.ToDecimal(bakiyeObj) : 0;

                lblBakiye.Text = $"Güncel Bakiyeniz: {bakiye} TL";
            }
        }

        private void btnRezervasyon_Click(object sender, EventArgs e)
        {
            RezervasyonEkle frm = new RezervasyonEkle();
            frm.Show();
            this.Hide();
        }

        private void txtYuklenecekTutar_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Sadece rakam, backspace ve virgül/nokta kabul et
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != ',' && e.KeyChar != '.')
            {
                e.Handled = true;
            }

            // Birden fazla virgül/nokta engelle
            if ((e.KeyChar == ',' || e.KeyChar == '.') && ((sender as TextBox).Text.Contains(",") || (sender as TextBox).Text.Contains(".")))
            {
                e.Handled = true;
            }
        }

        private void btnBakiyeYukle_Click(object sender, EventArgs e)
        {
            if (decimal.TryParse(txtYuklenecekTutar.Text, out decimal yuklemeTutar) && yuklemeTutar > 0)
            {
                if (yuklemeTutar > 500)
                {
                    MessageBox.Show("Tek seferde en fazla 500 TL yükleyebilirsiniz.");
                    return;
                }

                using (SqlConnection baglanti = new SqlConnection("Server=DESKTOP-079GM3U\\SQLEXPRESS;Database=WashyProDB;Trusted_Connection=True;"))
                {
                    baglanti.Open();

                    SqlCommand komut = new SqlCommand("UPDATE Kullanici SET Bakiye = ISNULL(Bakiye, 0) + @tutar WHERE KullaniciID = @id", baglanti);
                    komut.Parameters.AddWithValue("@tutar", yuklemeTutar);
                    komut.Parameters.AddWithValue("@id", Form2.GirisYapanKullaniciID);

                    int etkilenenSatir = komut.ExecuteNonQuery();

                    if (etkilenenSatir > 0)
                    {
                        MessageBox.Show("Bakiye başarıyla yüklendi.");
                        txtYuklenecekTutar.Clear();
                        BakiyeGoster();
                    }
                    else
                    {
                        MessageBox.Show("Bakiye güncellenemedi. Kullanıcı ID kontrol edilmeli.");
                    }
                }
            }
            else
            {
                MessageBox.Show("Lütfen geçerli bir tutar girin.");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            RezervasyonSil form = new RezervasyonSil();
            form.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            labelTahsilat.Visible = true;
            labelIade.Visible = true;
            labelIptal.Visible = true;
            RaporlariYukle();
        }
    }
}
