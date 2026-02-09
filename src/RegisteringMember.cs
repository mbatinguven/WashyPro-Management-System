using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace WashyPRO
{
    public partial class UyeKayit : Form
    {
        public UyeKayit()
        {
            InitializeComponent();
        }

        private void btnKayit_Click(object sender, EventArgs e)
        {
            string ad = txtAd.Text.Trim();
            string soyad = txtSoyad.Text.Trim();
            string email = txtEmail.Text.Trim();
            string sifre = txtSifre.Text.Trim();

            Regex regex = new Regex(@"^[\w\.-]+@(gmail\.com|outlook\.com|hotmail\.com|example\.com)$");

            if (!regex.IsMatch(email))
            {
                MessageBox.Show("Lütfen geçerli bir e-posta adresi girin.");
                return;
            }

            if (string.IsNullOrWhiteSpace(sifre) || string.IsNullOrWhiteSpace(ad) || string.IsNullOrWhiteSpace(soyad))
            {
                MessageBox.Show("Lütfen tüm alanları doldurun.");
                return;
            }

            SqlConnection baglanti = new SqlConnection("Server=DESKTOP-079GM3U\\SQLEXPRESS;Database=WashyProDB;Trusted_Connection=True;");
            SqlCommand komut = new SqlCommand("INSERT INTO Kullanici (Ad, Soyad, Email, Sifre) VALUES (@Ad, @Soyad, @Email, @Sifre)", baglanti);
            komut.Parameters.AddWithValue("@Ad", ad);
            komut.Parameters.AddWithValue("@Soyad", soyad);
            komut.Parameters.AddWithValue("@Email", email);
            komut.Parameters.AddWithValue("@Sifre", sifre);

            try
            {
                baglanti.Open();
                komut.ExecuteNonQuery();
                baglanti.Close();

                MessageBox.Show("Kayıt başarılı!");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message);
            }
        }
    }
}

