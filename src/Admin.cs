using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace WashyPRO
{
    public partial class Admin : Form
    {
        public Admin()
        {
            InitializeComponent();
        }

        SqlConnection baglanti = new SqlConnection("Server=DESKTOP-079GM3U\\SQLEXPRESS;Database=WashyProDB;Trusted_Connection=True;");

        private void Admin_Load(object sender, EventArgs e)
        {
            MakineListele();
            cmbDurum.Items.Clear();
            cmbDurum.Items.Add("Kullanılabilir");
            cmbDurum.Items.Add("Arızalı");
            cmbDurum.Items.Add("Bakımda");
            cmbDurum.SelectedIndex = 0;
        }

        private void GridAyarla()
        {
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 11, FontStyle.Bold);
            dataGridView1.DefaultCellStyle.Font = new Font("Segoe UI", 10);
        }

        // Makineleri gösteren fonksiyon
        private void MakineListele()
        {
            using (SqlConnection baglanti = new SqlConnection("Server=DESKTOP-079GM3U\\SQLEXPRESS;Database=WashyProDB;Trusted_Connection=True;"))
            {
                baglanti.Open();
                SqlDataAdapter da = new SqlDataAdapter("SELECT MakineID, Tur, Durum FROM Makine", baglanti);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;
                GridAyarla();
            }
        }
        private void BekleyenRezervasyonlariGetir()
        {
            using (SqlConnection baglanti = new SqlConnection("Server=DESKTOP-079GM3U\\SQLEXPRESS;Database=WashyProDB;Trusted_Connection=True;"))
            {
                baglanti.Open();
                SqlDataAdapter da = new SqlDataAdapter(
                    "SELECT RezervasyonID, KullaniciID, MakineID, BaslangicZamani, BitisZamani, Durum " +
                    "FROM Rezervasyon WHERE Durum = 'Bekliyor'", baglanti);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt; // Admin panelindeki DataGridView'in adı
                GridAyarla();
            }
        }


        // DataGridView'da satır seçilince durum ComboBox'a yansır
        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0 && dataGridView1.Columns.Contains("Durum"))
            {
                string durum = dataGridView1.SelectedRows[0].Cells["Durum"].Value.ToString();
                cmbDurum.SelectedItem = durum;
            }
        }

        // Güncelle butonuna basınca seçili makinenin durumu değiştirilir
        private void btnDurumGuncelle_Click(object sender, EventArgs e)
        {
            btnOnayla.Visible = false;
            btnReddet.Visible = false;
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Lütfen bir makine seçin.");
                return;
            }

            int makineID = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["MakineID"].Value);
            string yeniDurum = cmbDurum.SelectedItem.ToString();

            using (SqlConnection baglanti = new SqlConnection("Server=DESKTOP-079GM3U\\SQLEXPRESS;Database=WashyProDB;Trusted_Connection=True;"))
            {
                baglanti.Open();
                SqlCommand komut = new SqlCommand("UPDATE Makine SET Durum = @Durum WHERE MakineID = @MakineID", baglanti);
                komut.Parameters.AddWithValue("@Durum", yeniDurum);
                komut.Parameters.AddWithValue("@MakineID", makineID);
                komut.ExecuteNonQuery();
            }

            MessageBox.Show("Makine durumu güncellendi.");
            MakineListele();
        }

        // En Çok Kullanılan Makine raporu
        private void btnMakine_Click(object sender, EventArgs e)
        {
            btnOnayla.Visible = false;
            btnReddet.Visible = false;
            SqlDataAdapter da = new SqlDataAdapter(
                "SELECT TOP 1 MakineID, COUNT(*) AS KullanimSayisi FROM Rezervasyon GROUP BY MakineID ORDER BY KullanimSayisi DESC",
                baglanti);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            GridAyarla();
        }

        // Günlük Rezervasyon Sayısı raporu
        private void btnGunluk_Click(object sender, EventArgs e)
        {
            btnOnayla.Visible = false;
            btnReddet.Visible = false;
            SqlDataAdapter da = new SqlDataAdapter(
                "SELECT CAST(BaslangicZamani AS DATE) AS Tarih, COUNT(*) AS RezervasyonSayisi FROM Rezervasyon GROUP BY CAST(BaslangicZamani AS DATE)",
                baglanti);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            GridAyarla();
        }

        // Toplam Gelir raporu
        private void btnGelir_Click(object sender, EventArgs e)
        {
            btnOnayla.Visible = false;
            btnReddet.Visible = false;
            using (SqlConnection baglanti = new SqlConnection("Server=DESKTOP-079GM3U\\SQLEXPRESS;Database=WashyProDB;Trusted_Connection=True;"))
            {
                baglanti.Open();

                SqlDataAdapter da = new SqlDataAdapter(@"
                    SELECT 
                        ISNULL(SUM(CASE WHEN Iade = 0 THEN Tutar END), 0) AS ToplamGelir,
                        ISNULL(SUM(CASE WHEN Iade = 1 THEN -Tutar END), 0) AS ToplamIade,
                        ISNULL(SUM(CASE WHEN Iade = 0 THEN Tutar END), 0) 
                        - ISNULL(SUM(CASE WHEN Iade = 1 THEN Tutar END), 0) AS NetGelir
                    FROM Odeme", baglanti);

                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;
                GridAyarla();
            }
        }

        // Makineleri tekrar göstermek için buton
        private void btnMakineDurumlari_Click(object sender, EventArgs e)
        {
            btnOnayla.Visible = false;
            btnReddet.Visible = false;
            MakineListele();
        }

        private void btn_GecisYap_Click(object sender, EventArgs e)
        {
            btnOnayla.Visible = false;
            btnReddet.Visible = false;
            Form2 frm = new Form2();
            frm.Show();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            btnOnayla.Visible = true;
            btnReddet.Visible = true;
            BekleyenRezervasyonlariGetir();
        }

        private void btnOnayla_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Onaylamak için bir rezervasyon seçiniz.");
                return;
            }

            int rezervasyonID = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["RezervasyonID"].Value);

            using (SqlConnection baglanti = new SqlConnection("Server=DESKTOP-079GM3U\\SQLEXPRESS;Database=WashyProDB;Trusted_Connection=True;"))
            {
                baglanti.Open();
                SqlCommand cmd = new SqlCommand("UPDATE Rezervasyon SET Durum = 'Onaylandı' WHERE RezervasyonID = @id", baglanti);
                cmd.Parameters.AddWithValue("@id", rezervasyonID);
                cmd.ExecuteNonQuery();
            }

            MessageBox.Show("Rezervasyon onaylandı!");
            BekleyenRezervasyonlariGetir(); // Listeyi yenile
        }

        private void btnReddet_Click(object sender, EventArgs e)
        {
           
                if (dataGridView1.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Reddetmek için bir rezervasyon seçiniz.");
                    return;
                }

                int rezervasyonID = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["RezervasyonID"].Value);

                using (SqlConnection baglanti = new SqlConnection("Server=DESKTOP-079GM3U\\SQLEXPRESS;Database=WashyProDB;Trusted_Connection=True;"))
                {
                    baglanti.Open();
                    SqlCommand cmd = new SqlCommand("UPDATE Rezervasyon SET Durum = 'Reddedildi' WHERE RezervasyonID = @id", baglanti);
                    cmd.Parameters.AddWithValue("@id", rezervasyonID);
                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("Rezervasyon reddedildi!");
                BekleyenRezervasyonlariGetir(); // Listeyi yenile
            
        }
    }
}
