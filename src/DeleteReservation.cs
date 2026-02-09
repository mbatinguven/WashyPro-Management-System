using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using static System.ComponentModel.Design.ObjectSelectorEditor;

namespace WashyPRO
{
    public partial class RezervasyonSil : Form
    {
        public RezervasyonSil()
        {
            InitializeComponent();
        }

        private void RezervasyonSil_Load(object sender, EventArgs e)
        {
            using (SqlConnection baglanti = new SqlConnection("Server=DESKTOP-079GM3U\\SQLEXPRESS;Database=WashyProDB;Trusted_Connection=True;"))
            {
                baglanti.Open();

                SqlCommand komut = new SqlCommand(@"
                  SELECT RezervasyonID, MakineID, BaslangicZamani, BitisZamani
                  FROM Rezervasyon
                  WHERE KullaniciID = @kullaniciID AND Iptal = 0", baglanti); // <--- eklendi!


                komut.Parameters.AddWithValue("@kullaniciID", Form2.GirisYapanKullaniciID);

                SqlDataAdapter da = new SqlDataAdapter(komut);
                DataTable dt = new DataTable();
                da.Fill(dt);

                dataGridViewRezervasyonlar.DataSource = dt;

                // Sadece 1 kez buton ekle
                if (!dataGridViewRezervasyonlar.Columns.Contains("btnSil"))
                {
                    DataGridViewButtonColumn btnSil = new DataGridViewButtonColumn();
                    btnSil.HeaderText = "Sil";
                    btnSil.Text = "❌";
                    btnSil.Name = "btnSil";
                    btnSil.UseColumnTextForButtonValue = true;
                    dataGridViewRezervasyonlar.Columns.Add(btnSil);
                }
            }
        }

        private void dataGridViewRezervasyonlar_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == dataGridViewRezervasyonlar.Columns["btnSil"].Index)
            {
                int rezervasyonID = Convert.ToInt32(dataGridViewRezervasyonlar.Rows[e.RowIndex].Cells["RezervasyonID"].Value);

                DialogResult result = MessageBox.Show("Bu rezervasyonu silmek istediğinize emin misiniz?", "Onay", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    using (SqlConnection baglanti = new SqlConnection("Server=DESKTOP-079GM3U\\SQLEXPRESS;Database=WashyProDB;Trusted_Connection=True;"))
                    {
                        baglanti.Open();

                        // Rezervasyonu sil
                        SqlCommand silKomut = new SqlCommand("UPDATE Rezervasyon SET Iptal = 1, IptalTarihi = GETDATE() WHERE RezervasyonID = @id", baglanti);
                        silKomut.Parameters.AddWithValue("@id", rezervasyonID);
                        silKomut.ExecuteNonQuery();

                        // Kullanıcıya 30 TL iade
                        SqlCommand bakiyeIade = new SqlCommand("UPDATE Kullanici SET Bakiye = ISNULL(Bakiye, 0) + 30 WHERE KullaniciID = @kulID", baglanti);
                        bakiyeIade.Parameters.AddWithValue("@kulID", Form2.GirisYapanKullaniciID);
                        bakiyeIade.ExecuteNonQuery();

                        // Toplam gelirden -30 yansıt (iade)
                        SqlCommand iadeOdeme = new SqlCommand(
                           "INSERT INTO Odeme (KullaniciID, RezervasyonID, Tutar, OdemeTarihi, Iade) VALUES (@kulID, @rezID, @tutar, @tarih, 1)", baglanti);

                        iadeOdeme.Parameters.AddWithValue("@kulID", Form2.GirisYapanKullaniciID);
                        iadeOdeme.Parameters.AddWithValue("@rezID", rezervasyonID);
                        iadeOdeme.Parameters.AddWithValue("@tutar", 30);
                        iadeOdeme.Parameters.AddWithValue("@tarih", DateTime.Now);

                        iadeOdeme.ExecuteNonQuery();

                    }

                    MessageBox.Show("Rezervasyonunuz iptal edildi.\nHizmet bedeli kesintisi sonrası 30 TL iade edilmiştir.");

                    // Listeyi yenile
                    RezervasyonSil_Load(null, null);

                    // Ana formdaki bakiyeyi güncelle
                    foreach (Form form in Application.OpenForms)
                    {
                        if (form is Form2 anaForm)
                        {
                            anaForm.BakiyeGoster();
                        }
                    }
                }
            }
        }
    }
}
