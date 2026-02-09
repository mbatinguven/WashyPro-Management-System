using System.Data.SqlClient;





namespace WashyPRO
{
    public partial class Form1 : Form
    {

        SqlConnection baglanti = new SqlConnection("Server=DESKTOP-079GM3U\\SQLEXPRESS;Database=WashyProDB;Trusted_Connection=True;");

        public Form1()
        {
            InitializeComponent();
        }

        private void btnGiris_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text.Trim();
            string sifre = txtSifre.Text.Trim();

            using (SqlConnection baglanti = new SqlConnection("Server=DESKTOP-079GM3U\\SQLEXPRESS;Database=WashyProDB;Trusted_Connection=True;"))
            {
                baglanti.Open();
                SqlCommand komut = new SqlCommand("SELECT KullaniciID FROM Kullanici WHERE Email = @Email AND Sifre = @Sifre", baglanti);
                komut.Parameters.AddWithValue("@Email", email);
                komut.Parameters.AddWithValue("@Sifre", sifre);

                object sonuc = komut.ExecuteScalar();

                if (sonuc != null)
                {
                    int kullaniciID = Convert.ToInt32(sonuc);
                    Form2.GirisYapanKullaniciID = kullaniciID;

                    MessageBox.Show("Giriþ baþarýlý!");

                    if (email == "admin" && sifre == "1234")
                    {
                        Admin frmAdmin = new Admin();
                        frmAdmin.Show();
                    }
                    else
                    {
                        Form2 frm = new Form2();
                        frm.Show();
                    }
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Kullanýcý adý veya þifre hatalý.");
                }
            }
        }


        private void btnUyeOl_Click(object sender, EventArgs e)
        {
            UyeKayit frm = new UyeKayit();
            frm.ShowDialog();
        }
    }
}