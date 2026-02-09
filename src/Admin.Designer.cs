namespace WashyPRO
{
    partial class Admin
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            dataGridView1 = new DataGridView();
            btnGelir = new Button();
            btnGunluk = new Button();
            btnMakine = new Button();
            cmbDurum = new ComboBox();
            btnDurumGüncelle = new Button();
            groupBox1 = new GroupBox();
            btnMakineDurumları = new Button();
            groupBox2 = new GroupBox();
            btn_GecisYap = new Button();
            button1 = new Button();
            btnOnayla = new Button();
            btnReddet = new Button();
            groupBox3 = new GroupBox();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox3.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 20F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(435, 9);
            label1.Name = "label1";
            label1.Size = new Size(270, 46);
            label1.TabIndex = 0;
            label1.Text = "ADMİN SEKMESİ";
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(154, 68);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.RowTemplate.Height = 29;
            dataGridView1.Size = new Size(821, 235);
            dataGridView1.TabIndex = 7;
            dataGridView1.SelectionChanged += dataGridView1_SelectionChanged;
            // 
            // btnGelir
            // 
            btnGelir.FlatStyle = FlatStyle.Flat;
            btnGelir.Location = new Point(416, 32);
            btnGelir.Name = "btnGelir";
            btnGelir.Size = new Size(133, 71);
            btnGelir.TabIndex = 6;
            btnGelir.Text = "Toplam Gelir";
            btnGelir.UseVisualStyleBackColor = true;
            btnGelir.Click += btnGelir_Click;
            // 
            // btnGunluk
            // 
            btnGunluk.FlatStyle = FlatStyle.Flat;
            btnGunluk.Location = new Point(225, 32);
            btnGunluk.Name = "btnGunluk";
            btnGunluk.Size = new Size(133, 71);
            btnGunluk.TabIndex = 5;
            btnGunluk.Text = "Günlük Rezervasyon Sayısı";
            btnGunluk.UseVisualStyleBackColor = true;
            btnGunluk.Click += btnGunluk_Click;
            // 
            // btnMakine
            // 
            btnMakine.FlatStyle = FlatStyle.Flat;
            btnMakine.Location = new Point(38, 32);
            btnMakine.Name = "btnMakine";
            btnMakine.Size = new Size(133, 71);
            btnMakine.TabIndex = 4;
            btnMakine.Text = "En Çok Kullanılan Makine";
            btnMakine.UseVisualStyleBackColor = true;
            btnMakine.Click += btnMakine_Click;
            // 
            // cmbDurum
            // 
            cmbDurum.FormattingEnabled = true;
            cmbDurum.Location = new Point(15, 63);
            cmbDurum.Name = "cmbDurum";
            cmbDurum.Size = new Size(151, 28);
            cmbDurum.TabIndex = 9;
            // 
            // btnDurumGüncelle
            // 
            btnDurumGüncelle.FlatStyle = FlatStyle.Flat;
            btnDurumGüncelle.Location = new Point(184, 36);
            btnDurumGüncelle.Name = "btnDurumGüncelle";
            btnDurumGüncelle.Size = new Size(133, 71);
            btnDurumGüncelle.TabIndex = 10;
            btnDurumGüncelle.Text = "Güncelle";
            btnDurumGüncelle.UseVisualStyleBackColor = true;
            btnDurumGüncelle.Click += btnDurumGuncelle_Click;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(btnMakineDurumları);
            groupBox1.Controls.Add(btnDurumGüncelle);
            groupBox1.Controls.Add(cmbDurum);
            groupBox1.Location = new Point(678, 329);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(595, 135);
            groupBox1.TabIndex = 11;
            groupBox1.TabStop = false;
            groupBox1.Text = "Makine Durumu";
            // 
            // btnMakineDurumları
            // 
            btnMakineDurumları.FlatStyle = FlatStyle.Flat;
            btnMakineDurumları.Location = new Point(380, 36);
            btnMakineDurumları.Name = "btnMakineDurumları";
            btnMakineDurumları.Size = new Size(133, 71);
            btnMakineDurumları.TabIndex = 11;
            btnMakineDurumları.Text = "Makine Durumları";
            btnMakineDurumları.UseVisualStyleBackColor = true;
            btnMakineDurumları.Click += btnMakineDurumlari_Click;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(btnGelir);
            groupBox2.Controls.Add(btnGunluk);
            groupBox2.Controls.Add(btnMakine);
            groupBox2.Location = new Point(28, 317);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(585, 147);
            groupBox2.TabIndex = 12;
            groupBox2.TabStop = false;
            groupBox2.Text = "Sayısal İşlemler";
            // 
            // btn_GecisYap
            // 
            btn_GecisYap.FlatStyle = FlatStyle.Flat;
            btn_GecisYap.Location = new Point(1159, 12);
            btn_GecisYap.Name = "btn_GecisYap";
            btn_GecisYap.Size = new Size(133, 71);
            btn_GecisYap.TabIndex = 13;
            btn_GecisYap.Text = "Kullanıcı Formuna Geçiş Yap";
            btn_GecisYap.UseVisualStyleBackColor = true;
            btn_GecisYap.Click += btn_GecisYap_Click;
            // 
            // button1
            // 
            button1.FlatStyle = FlatStyle.Flat;
            button1.Location = new Point(39, 26);
            button1.Name = "button1";
            button1.Size = new Size(133, 71);
            button1.TabIndex = 14;
            button1.Text = "Bekleyen Rezervasyonları Göster";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // btnOnayla
            // 
            btnOnayla.FlatStyle = FlatStyle.Flat;
            btnOnayla.Location = new Point(39, 111);
            btnOnayla.Name = "btnOnayla";
            btnOnayla.Size = new Size(54, 34);
            btnOnayla.TabIndex = 15;
            btnOnayla.Text = "Onay";
            btnOnayla.UseVisualStyleBackColor = true;
            btnOnayla.Visible = false;
            btnOnayla.Click += btnOnayla_Click;
            // 
            // btnReddet
            // 
            btnReddet.FlatStyle = FlatStyle.Flat;
            btnReddet.Location = new Point(118, 111);
            btnReddet.Name = "btnReddet";
            btnReddet.Size = new Size(54, 34);
            btnReddet.TabIndex = 16;
            btnReddet.Text = "Red";
            btnReddet.UseVisualStyleBackColor = true;
            btnReddet.Visible = false;
            btnReddet.Click += btnReddet_Click;
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(btnReddet);
            groupBox3.Controls.Add(btnOnayla);
            groupBox3.Controls.Add(button1);
            groupBox3.Location = new Point(1120, 123);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(193, 187);
            groupBox3.TabIndex = 17;
            groupBox3.TabStop = false;
            groupBox3.Text = "Bekleyen Randevular";
            // 
            // Admin
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1308, 536);
            Controls.Add(groupBox3);
            Controls.Add(btn_GecisYap);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Controls.Add(dataGridView1);
            Controls.Add(label1);
            Name = "Admin";
            Text = "Admin";
            Load += Admin_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox2.ResumeLayout(false);
            groupBox3.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private DataGridView dataGridView1;
        private Button btnGelir;
        private Button btnGunluk;
        private Button btnMakine;
        private ComboBox cmbDurum;
        private Button btnDurumGüncelle;
        private GroupBox groupBox1;
        private Button btnMakineDurumları;
        private GroupBox groupBox2;
        private Button btn_GecisYap;
        private Button button1;
        private Button btnOnayla;
        private Button btnReddet;
        private GroupBox groupBox3;
    }
}