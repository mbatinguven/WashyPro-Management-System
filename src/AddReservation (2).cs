namespace WashyPRO
{
    partial class RezervasyonEkle
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
            cmbMakine = new ComboBox();
            dtpTarih = new DateTimePicker();
            btnRezervasyonEkle = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            cmbSaat = new ComboBox();
            lvPazartesi = new ListView();
            btnBakiyeYukle = new Button();
            listBoxKullanilamaz = new ListBox();
            label4 = new Label();
            SuspendLayout();
            // 
            // cmbMakine
            // 
            cmbMakine.FormattingEnabled = true;
            cmbMakine.Location = new Point(132, 98);
            cmbMakine.Name = "cmbMakine";
            cmbMakine.Size = new Size(151, 28);
            cmbMakine.TabIndex = 0;
            // 
            // dtpTarih
            // 
            dtpTarih.Location = new Point(112, 62);
            dtpTarih.Name = "dtpTarih";
            dtpTarih.Size = new Size(250, 27);
            dtpTarih.TabIndex = 1;
            dtpTarih.ValueChanged += dtpTarih_ValueChanged;
            // 
            // btnRezervasyonEkle
            // 
            btnRezervasyonEkle.FlatStyle = FlatStyle.Flat;
            btnRezervasyonEkle.Location = new Point(12, 215);
            btnRezervasyonEkle.Name = "btnRezervasyonEkle";
            btnRezervasyonEkle.Size = new Size(216, 29);
            btnRezervasyonEkle.TabIndex = 2;
            btnRezervasyonEkle.Text = "Rezervasyon Ekle";
            btnRezervasyonEkle.UseVisualStyleBackColor = true;
            btnRezervasyonEkle.Click += btnRezervasyonEkle_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 69);
            label1.Name = "label1";
            label1.Size = new Size(82, 20);
            label1.TabIndex = 6;
            label1.Text = "Tarih Seçin:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(27, 101);
            label2.Name = "label2";
            label2.Size = new Size(99, 20);
            label2.TabIndex = 7;
            label2.Text = "Makine Seçin:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(27, 148);
            label3.Name = "label3";
            label3.Size = new Size(80, 20);
            label3.TabIndex = 9;
            label3.Text = "Saat Seçin:";
            // 
            // cmbSaat
            // 
            cmbSaat.FormattingEnabled = true;
            cmbSaat.Location = new Point(132, 145);
            cmbSaat.Name = "cmbSaat";
            cmbSaat.Size = new Size(151, 28);
            cmbSaat.TabIndex = 8;
            // 
            // lvPazartesi
            // 
            lvPazartesi.Location = new Point(484, 69);
            lvPazartesi.Name = "lvPazartesi";
            lvPazartesi.Size = new Size(819, 422);
            lvPazartesi.TabIndex = 10;
            lvPazartesi.UseCompatibleStateImageBehavior = false;
            // 
            // btnBakiyeYukle
            // 
            btnBakiyeYukle.FlatStyle = FlatStyle.Flat;
            btnBakiyeYukle.Location = new Point(12, 266);
            btnBakiyeYukle.Name = "btnBakiyeYukle";
            btnBakiyeYukle.Size = new Size(216, 32);
            btnBakiyeYukle.TabIndex = 11;
            btnBakiyeYukle.Text = "Bakiye yüklemek için tıkla";
            btnBakiyeYukle.UseVisualStyleBackColor = true;
            btnBakiyeYukle.Click += btnBakiyeYukle_Click;
            // 
            // listBoxKullanilamaz
            // 
            listBoxKullanilamaz.FormattingEnabled = true;
            listBoxKullanilamaz.ItemHeight = 20;
            listBoxKullanilamaz.Location = new Point(12, 380);
            listBoxKullanilamaz.Name = "listBoxKullanilamaz";
            listBoxKullanilamaz.Size = new Size(307, 104);
            listBoxKullanilamaz.TabIndex = 12;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(36, 346);
            label4.Name = "label4";
            label4.Size = new Size(217, 20);
            label4.TabIndex = 13;
            label4.Text = "Kullanımda olmayan makineler:";
            // 
            // RezervasyonEkle
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1329, 522);
            Controls.Add(label4);
            Controls.Add(listBoxKullanilamaz);
            Controls.Add(btnBakiyeYukle);
            Controls.Add(lvPazartesi);
            Controls.Add(label3);
            Controls.Add(cmbSaat);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(btnRezervasyonEkle);
            Controls.Add(dtpTarih);
            Controls.Add(cmbMakine);
            Name = "RezervasyonEkle";
            Text = "Rezervasyonİslemleri";
            Load += RezervasyonEkle_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox cmbMakine;
        private DateTimePicker dtpTarih;
        private Button btnRezervasyonEkle;
        private Button btnBakiyeYukle;
        private Label label1;
        private Label label2;
        private Label label3;
        private ComboBox cmbSaat;
        private ListView lvPazartesi;
        private ListBox listBoxKullanilamaz;
        private Label label4;
    }
}