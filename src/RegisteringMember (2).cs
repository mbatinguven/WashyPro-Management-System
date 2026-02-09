namespace WashyPRO
{
    partial class UyeKayit
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
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            txtEmail = new TextBox();
            txtSifre = new TextBox();
            label5 = new Label();
            btnKayit = new Button();
            txtSoyad = new TextBox();
            label6 = new Label();
            txtAd = new TextBox();
            label7 = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 28F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(231, 9);
            label1.Name = "label1";
            label1.Size = new Size(319, 62);
            label1.TabIndex = 0;
            label1.Text = "HOŞGELDİNİZ";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(145, 71);
            label2.Name = "label2";
            label2.Size = new Size(442, 20);
            label2.TabIndex = 1;
            label2.Text = "Yeni Üye Olmak İçin Lütfen Aşağıdaki Gerekli Bilgileri Doldurunuz.";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(83, 102);
            label3.Name = "label3";
            label3.Size = new Size(611, 20);
            label3.TabIndex = 2;
            label3.Text = "*Lütfen mailinizi doğru formatta doldurunuz.(....@example, ....@gmail , ....@hotmail.com vb.)\r\n";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(184, 242);
            label4.Name = "label4";
            label4.Size = new Size(49, 20);
            label4.TabIndex = 3;
            label4.Text = "Email:";
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(276, 239);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(138, 27);
            txtEmail.TabIndex = 4;
            // 
            // txtSifre
            // 
            txtSifre.Location = new Point(276, 289);
            txtSifre.Name = "txtSifre";
            txtSifre.Size = new Size(138, 27);
            txtSifre.TabIndex = 6;
            txtSifre.UseSystemPasswordChar = true;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(184, 292);
            label5.Name = "label5";
            label5.Size = new Size(42, 20);
            label5.TabIndex = 5;
            label5.Text = "Şifre:";
            // 
            // btnKayit
            // 
            btnKayit.FlatStyle = FlatStyle.Flat;
            btnKayit.Location = new Point(290, 382);
            btnKayit.Name = "btnKayit";
            btnKayit.Size = new Size(124, 29);
            btnKayit.TabIndex = 7;
            btnKayit.Text = "Kayıt Ol";
            btnKayit.UseVisualStyleBackColor = true;
            btnKayit.Click += btnKayit_Click;
            // 
            // txtSoyad
            // 
            txtSoyad.Location = new Point(276, 196);
            txtSoyad.Name = "txtSoyad";
            txtSoyad.Size = new Size(138, 27);
            txtSoyad.TabIndex = 11;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(184, 199);
            label6.Name = "label6";
            label6.Size = new Size(76, 20);
            label6.TabIndex = 10;
            label6.Text = "Soyadınız:";
            // 
            // txtAd
            // 
            txtAd.Location = new Point(276, 146);
            txtAd.Name = "txtAd";
            txtAd.Size = new Size(138, 27);
            txtAd.TabIndex = 9;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(184, 149);
            label7.Name = "label7";
            label7.Size = new Size(54, 20);
            label7.TabIndex = 8;
            label7.Text = "Adınız:";
            // 
            // UyeKayit
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(txtSoyad);
            Controls.Add(label6);
            Controls.Add(txtAd);
            Controls.Add(label7);
            Controls.Add(btnKayit);
            Controls.Add(txtSifre);
            Controls.Add(label5);
            Controls.Add(txtEmail);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "UyeKayit";
            Text = "UyeKayit";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private TextBox txtEmail;
        private TextBox txtSifre;
        private Label label5;
        private Button btnKayit;
        private TextBox txtSoyad;
        private Label label6;
        private TextBox txtAd;
        private Label label7;
    }
}