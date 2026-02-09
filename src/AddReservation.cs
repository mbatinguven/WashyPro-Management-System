using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows.Forms;


namespace WashyPRO
{
    public partial class RezervasyonEkle :Form
    {
       
        public RezervasyonEkle()
        {
            InitializeComponent();
            
        }

        private void RezervasyonEkle_Load(object sender, EventArgs e)
        {
            DateTime bugun = DateTime.Today;
            int haftaninGunu = (int)bugun.DayOfWeek;
            haftaninGunu = haftaninGunu == 0 ? 7 : haftaninGunu;
            DateTime haftaBasi = bugun.AddDays(-haftaninGunu + 1);
            DateTime haftaSonu = haftaBasi.AddDays(6);

            dtpTarih.MinDate = haftaBasi;
            dtpTarih.MaxDate = haftaSonu;

            MakineleriYenile();
            TariheGoreSaatleriListele();
            KullanilamazMakineleriListele();

            cmbSaat.Items.Clear();
            for (int saat = 8; saat < 22; saat++)
            {
                cmbSaat.Items.Add($"{saat:00}:00");
            }
        }

        private void dtpTarih_ValueChanged(object sender, EventArgs e)
        {
            TariheGoreSaatleriListele();
        }

        // Yalnızca kullanılabilir makineleri ComboBox'a yükler
        private void MakineleriYenile()
        {
            cmbMakine.Items.Clear();
            using (SqlConnection baglanti = new SqlConnection("Server=DESKTOP-079GM3U\\SQLEXPRESS;Database=WashyProDB;Trusted_Connection=True;"))
            {
                baglanti.Open();
                SqlCommand komut = new SqlCommand(
                    "SELECT MakineID, Tur FROM Makine WHERE Durum = 'Kullanılabilir'", baglanti);
                SqlDataReader oku = komut.ExecuteReader();
                while (oku.Read())
                {
                    int makineID = (int)oku["MakineID"];
                    string tur = oku["Tur"].ToString();
                    cmbMakine.Items.Add($"{makineID} - {tur}");
                }
                oku.Close();
            }
        }

        // Sadece "Arızalı" ve "Bakımda" makineleri ListBox'a yazar
        private void KullanilamazMakineleriListele()
        {
            listBoxKullanilamaz.Items.Clear();
            using (SqlConnection baglanti = new SqlConnection("Server=DESKTOP-079GM3U\\SQLEXPRESS;Database=WashyProDB;Trusted_Connection=True;"))
            {
                baglanti.Open();
                SqlCommand komut = new SqlCommand(
                    "SELECT MakineID, Tur, Durum FROM Makine WHERE Durum IN ('Arızalı', 'Bakımda')", baglanti);
                SqlDataReader oku = komut.ExecuteReader();
                while (oku.Read())
                {
                    string satir = $"Makine {oku["MakineID"]} - {oku["Tur"]} ({oku["Durum"]})";
                    listBoxKullanilamaz.Items.Add(satir);
                }
                oku.Close();
            }
        }

        // Her gün/saat için kullanılabilir makinelerin dolu/boş durumu ListView'e eklenir
        private void TariheGoreSaatleriListele()
        {
            lvPazartesi.View = View.Details;
            lvPazartesi.FullRowSelect = true;
            lvPazartesi.Columns.Clear();
            lvPazartesi.Items.Clear();

            lvPazartesi.Columns.Add("MakineID", 80);
            lvPazartesi.Columns.Add("Saat", 130);
            lvPazartesi.Columns.Add("Durum", 80);

            DateTime secilenTarih = dtpTarih.Value.Date;

            // Sadece kullanılabilir makineler
            List<int> makineIDList = new List<int>();
            using (SqlConnection baglanti = new SqlConnection("Server=DESKTOP-079GM3U\\SQLEXPRESS;Database=WashyProDB;Trusted_Connection=True;"))
            {
                baglanti.Open();
                SqlCommand makineKomut = new SqlCommand(
                    "SELECT MakineID FROM Makine WHERE Durum = 'Kullanılabilir'", baglanti);
                SqlDataReader makineOku = makineKomut.ExecuteReader();
                while (makineOku.Read())
                    makineIDList.Add((int)makineOku["MakineID"]);
                makineOku.Close();

                foreach (int makineID in makineIDList)
                {
                    for (int saat = 8; saat < 22; saat++)
                    {
                        DateTime baslangic = secilenTarih.AddHours(saat);
                        DateTime bitis = baslangic.AddHours(1);

                        SqlCommand kontrolKomut = new SqlCommand(@"
                            SELECT COUNT(*) FROM Rezervasyon 
                            WHERE MakineID = @MakineID 
                            AND BaslangicZamani >= @Baslangic 
                            AND BaslangicZamani < @Bitis", baglanti);

                        kontrolKomut.Parameters.AddWithValue("@MakineID", makineID);
                        kontrolKomut.Parameters.AddWithValue("@Baslangic", baslangic);
                        kontrolKomut.Parameters.AddWithValue("@Bitis", bitis);

                        int doluMu = (int)kontrolKomut.ExecuteScalar();
                        string durum = doluMu > 0 ? "Dolu" : "Boş";

                        ListViewItem item = new ListViewItem(makineID.ToString());
                        item.SubItems.Add($"{baslangic:HH:mm} - {bitis:HH:mm}");
                        item.SubItems.Add(durum);
                        lvPazartesi.Items.Add(item);
                    }
                }
                baglanti.Close();
            }
        }

        private void btnRezervasyonEkle_Click(object sender, EventArgs e)
        {
            if (cmbMakine.SelectedItem == null)
            {
                MessageBox.Show("Lütfen bir makine seçin.");
                return;
            }
            if (cmbSaat.SelectedItem == null)
            {
                MessageBox.Show("Lütfen bir saat seçin.");
                return;
            }

            string secilen = cmbMakine.SelectedItem.ToString();
            string[] parcalar = secilen.Split('-');
            int makineID = int.Parse(parcalar[0].Trim());

            // Güncel durumu kontrol et
            string makineDurum = "";
            using (SqlConnection baglanti = new SqlConnection("Server=DESKTOP-079GM3U\\SQLEXPRESS;Database=WashyProDB;Trusted_Connection=True;"))
            {
                baglanti.Open();
                SqlCommand komut = new SqlCommand(
                    "SELECT Durum FROM Makine WHERE MakineID = @MakineID", baglanti);
                komut.Parameters.AddWithValue("@MakineID", makineID);
                object durumObj = komut.ExecuteScalar();
                makineDurum = durumObj != null ? durumObj.ToString() : "";
            }
            if (makineDurum != "Kullanılabilir")
            {
                MessageBox.Show("Bu makine kullanımda değil, başka makine seçiniz.");
                return;
            }

            DateTime tarih = dtpTarih.Value.Date;
            string saatStr = cmbSaat.SelectedItem.ToString(); // Saat bilgisini ComboBox’tan al!
            DateTime baslangic = DateTime.Parse($"{tarih:yyyy-MM-dd} {saatStr}");
            DateTime bitis = baslangic.AddHours(1);

            if (baslangic <= DateTime.Now)
            {
                MessageBox.Show("Geçmiş bir saat için rezervasyon yapılamaz.");
                return;
            }

            int haftaninGunu = (int)DateTime.Today.DayOfWeek;
            haftaninGunu = haftaninGunu == 0 ? 7 : haftaninGunu;
            DateTime haftaBasi = DateTime.Today.AddDays(-haftaninGunu + 1);
            DateTime haftaSonu = haftaBasi.AddDays(6);

            if (tarih < haftaBasi || tarih > haftaSonu)
            {
                MessageBox.Show("Sadece bu haftaya rezervasyon yapılabilir.");
                return;
            }

            int kullaniciID = Form2.GirisYapanKullaniciID;

            using (SqlConnection baglanti = new SqlConnection("Server=DESKTOP-079GM3U\\SQLEXPRESS;Database=WashyProDB;Trusted_Connection=True;"))
            {
                baglanti.Open();

                // 1. Bakiyeyi kontrol et
                SqlCommand bakiyeKomut = new SqlCommand(
                    "SELECT Bakiye FROM Kullanici WHERE KullaniciID = @id", baglanti);
                bakiyeKomut.Parameters.AddWithValue("@id", kullaniciID);
                object bakiyeObj = bakiyeKomut.ExecuteScalar();
                decimal bakiye = (bakiyeObj != DBNull.Value) ? Convert.ToDecimal(bakiyeObj) : 0;

                if (bakiye < 50)
                {
                    MessageBox.Show("Bakiyeniz yetersiz. Lütfen önce bakiye yükleyin.");
                    return;
                }

                // 2. Saat dolu mu kontrol et
                SqlCommand kontrol = new SqlCommand(@"
                    SELECT COUNT(*) FROM Rezervasyon 
                    WHERE MakineID = @MakineID 
                    AND BaslangicZamani >= @Baslangic 
                    AND BaslangicZamani < @Bitis", baglanti);

                kontrol.Parameters.AddWithValue("@MakineID", makineID);
                kontrol.Parameters.AddWithValue("@Baslangic", baslangic);
                kontrol.Parameters.AddWithValue("@Bitis", bitis);

                int varMi = (int)kontrol.ExecuteScalar();
                if (varMi > 0)
                {
                    MessageBox.Show("Bu saat için bu makine dolu. Lütfen başka bir saat seçin.");
                    return;
                }

                // 3. Rezervasyonu ekle, ödeme ekle
                SqlCommand ekle = new SqlCommand(@"
                  DECLARE @YeniID INT;

                   INSERT INTO Rezervasyon (KullaniciID, MakineID, BaslangicZamani, BitisZamani, Durum)
                   VALUES (@KullaniciID, @MakineID, @Baslangic, @Bitis, 'Bekliyor');
 
                   SET @YeniID = SCOPE_IDENTITY();


                   SELECT @YeniID;", baglanti);


                ekle.Parameters.AddWithValue("@KullaniciID", kullaniciID);
                ekle.Parameters.AddWithValue("@MakineID", makineID);
                ekle.Parameters.AddWithValue("@Baslangic", baslangic);
                ekle.Parameters.AddWithValue("@Bitis", bitis);
                ekle.Parameters.AddWithValue("@Tutar", 50);
                ekle.Parameters.AddWithValue("@OdemeTarihi", DateTime.Now);

                object sonuc = ekle.ExecuteScalar();

                if (sonuc == null || sonuc == DBNull.Value)
                {
                    MessageBox.Show("Rezervasyon ID alınamadı.");
                    return;
                }

                // 4. Bakiyeyi düş
                SqlCommand dusur = new SqlCommand(
                    "UPDATE Kullanici SET Bakiye = Bakiye - 50 WHERE KullaniciID = @id", baglanti);
                dusur.Parameters.AddWithValue("@id", kullaniciID);
                dusur.ExecuteNonQuery();

                MessageBox.Show("Rezervasyon başarıyla eklendi.\n50 TL bakiyenizden düşüldü.");

                TariheGoreSaatleriListele();
                MakineleriYenile();
                KullanilamazMakineleriListele();
            }
        }

        private void btnBakiyeYukle_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Show();
            this.Hide();
        }
    }
}
