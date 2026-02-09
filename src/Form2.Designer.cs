namespace WashyPRO
{
    partial class Form2
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
            btnRezervasyon = new Button();
            button1 = new Button();
            btnBakiyeYukle = new Button();
            txtYuklenecekTutar = new TextBox();
            lblBakiye = new Label();
            dataGridViewKullaniciRapor = new DataGridView();
            labelTahsilat = new Label();
            labelIade = new Label();
            labelIptal = new Label();
            button2 = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridViewKullaniciRapor).BeginInit();
            SuspendLayout();
            // 
            // btnRezervasyon
            // 
            btnRezervasyon.FlatStyle = FlatStyle.Flat;
            btnRezervasyon.Location = new Point(625, 12);
            btnRezervasyon.Name = "btnRezervasyon";
            btnRezervasyon.Size = new Size(163, 78);
            btnRezervasyon.TabIndex = 4;
            btnRezervasyon.Text = "Rezervasyon Ekle";
            btnRezervasyon.UseVisualStyleBackColor = true;
            btnRezervasyon.Click += btnRezervasyon_Click;
            // 
            // button1
            // 
            button1.FlatStyle = FlatStyle.Flat;
            button1.Location = new Point(625, 106);
            button1.Name = "button1";
            button1.Size = new Size(163, 78);
            button1.TabIndex = 5;
            button1.Text = "Rezervasyon Sil";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // btnBakiyeYukle
            // 
            btnBakiyeYukle.FlatStyle = FlatStyle.Flat;
            btnBakiyeYukle.Location = new Point(625, 262);
            btnBakiyeYukle.Name = "btnBakiyeYukle";
            btnBakiyeYukle.Size = new Size(163, 78);
            btnBakiyeYukle.TabIndex = 6;
            btnBakiyeYukle.Text = "Bakiye Yükle";
            btnBakiyeYukle.UseVisualStyleBackColor = true;
            btnBakiyeYukle.Click += btnBakiyeYukle_Click;
            // 
            // txtYuklenecekTutar
            // 
            txtYuklenecekTutar.Location = new Point(625, 346);
            txtYuklenecekTutar.Name = "txtYuklenecekTutar";
            txtYuklenecekTutar.Size = new Size(163, 27);
            txtYuklenecekTutar.TabIndex = 7;
            txtYuklenecekTutar.KeyPress += txtYuklenecekTutar_KeyPress;
            // 
            // lblBakiye
            // 
            lblBakiye.AutoSize = true;
            lblBakiye.Location = new Point(625, 239);
            lblBakiye.Name = "lblBakiye";
            lblBakiye.Size = new Size(50, 20);
            lblBakiye.TabIndex = 8;
            lblBakiye.Text = "label1";
            // 
            // dataGridViewKullaniciRapor
            // 
            dataGridViewKullaniciRapor.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewKullaniciRapor.Location = new Point(1, 3);
            dataGridViewKullaniciRapor.Name = "dataGridViewKullaniciRapor";
            dataGridViewKullaniciRapor.RowHeadersWidth = 51;
            dataGridViewKullaniciRapor.RowTemplate.Height = 29;
            dataGridViewKullaniciRapor.Size = new Size(600, 265);
            dataGridViewKullaniciRapor.TabIndex = 9;
            // 
            // labelTahsilat
            // 
            labelTahsilat.AutoSize = true;
            labelTahsilat.Location = new Point(12, 271);
            labelTahsilat.Name = "labelTahsilat";
            labelTahsilat.Size = new Size(50, 20);
            labelTahsilat.TabIndex = 10;
            labelTahsilat.Text = "label1";
            labelTahsilat.Visible = false;
            // 
            // labelIade
            // 
            labelIade.AutoSize = true;
            labelIade.Location = new Point(12, 291);
            labelIade.Name = "labelIade";
            labelIade.Size = new Size(50, 20);
            labelIade.TabIndex = 11;
            labelIade.Text = "label2";
            labelIade.Visible = false;
            // 
            // labelIptal
            // 
            labelIptal.AutoSize = true;
            labelIptal.Location = new Point(12, 311);
            labelIptal.Name = "labelIptal";
            labelIptal.Size = new Size(50, 20);
            labelIptal.TabIndex = 12;
            labelIptal.Text = "label3";
            labelIptal.Visible = false;
            // 
            // button2
            // 
            button2.Location = new Point(12, 334);
            button2.Name = "button2";
            button2.Size = new Size(140, 45);
            button2.TabIndex = 13;
            button2.Text = "Raporları Göster";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // Form2
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(button2);
            Controls.Add(labelIptal);
            Controls.Add(labelIade);
            Controls.Add(labelTahsilat);
            Controls.Add(dataGridViewKullaniciRapor);
            Controls.Add(lblBakiye);
            Controls.Add(txtYuklenecekTutar);
            Controls.Add(btnBakiyeYukle);
            Controls.Add(button1);
            Controls.Add(btnRezervasyon);
            Name = "Form2";
            Text = "Form2";
            Load += Form2_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridViewKullaniciRapor).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button btnRezervasyon;
        private Button button1;
        private Button btnBakiyeYukle;
        private TextBox txtYuklenecekTutar;
        private Label lblBakiye;
        private DataGridView dataGridViewKullaniciRapor;
        private Label labelTahsilat;
        private Label labelIade;
        private Label labelIptal;
        private Button button2;
    }
}