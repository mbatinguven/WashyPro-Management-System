namespace WashyPRO
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lblEmail = new Label();
            txtEmail = new TextBox();
            txtSifre = new TextBox();
            lblSifre = new Label();
            btnGiris = new Button();
            btnUyeOl = new Button();
            label1 = new Label();
            label2 = new Label();
            SuspendLayout();
            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.Location = new Point(464, 113);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(49, 20);
            lblEmail.TabIndex = 0;
            lblEmail.Text = "Email:";
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(547, 113);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(136, 27);
            txtEmail.TabIndex = 1;
            // 
            // txtSifre
            // 
            txtSifre.Location = new Point(547, 160);
            txtSifre.Name = "txtSifre";
            txtSifre.PasswordChar = '*';
            txtSifre.Size = new Size(131, 27);
            txtSifre.TabIndex = 3;
            txtSifre.UseSystemPasswordChar = true;
            // 
            // lblSifre
            // 
            lblSifre.AutoSize = true;
            lblSifre.Location = new Point(464, 163);
            lblSifre.Name = "lblSifre";
            lblSifre.Size = new Size(42, 20);
            lblSifre.TabIndex = 2;
            lblSifre.Text = "Şifre:";
            // 
            // btnGiris
            // 
            btnGiris.FlatStyle = FlatStyle.Flat;
            btnGiris.Location = new Point(531, 223);
            btnGiris.Name = "btnGiris";
            btnGiris.Size = new Size(152, 52);
            btnGiris.TabIndex = 4;
            btnGiris.Text = "Giriş Yap";
            btnGiris.UseVisualStyleBackColor = true;
            btnGiris.Click += btnGiris_Click;
            // 
            // btnUyeOl
            // 
            btnUyeOl.FlatStyle = FlatStyle.Flat;
            btnUyeOl.Location = new Point(742, 221);
            btnUyeOl.Name = "btnUyeOl";
            btnUyeOl.Size = new Size(154, 54);
            btnUyeOl.TabIndex = 5;
            btnUyeOl.Text = "Üye Olmak İçin Tıkla";
            btnUyeOl.UseVisualStyleBackColor = true;
            btnUyeOl.Click += btnUyeOl_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = SystemColors.ActiveCaption;
            label1.Font = new Font("Tahoma", 15F, FontStyle.Regular, GraphicsUnit.Point);
            label1.LiveSetting = System.Windows.Forms.Automation.AutomationLiveSetting.Assertive;
            label1.Location = new Point(441, 9);
            label1.Name = "label1";
            label1.Size = new Size(295, 30);
            label1.TabIndex = 6;
            label1.Text = "WashyPro'ya Hoşgeldiniz!";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Red;
            label2.Location = new Point(422, 63);
            label2.Name = "label2";
            label2.Size = new Size(328, 20);
            label2.TabIndex = 7;
            label2.Text = "Randevu sistemimiz haftalık olarak açılmaktadır!";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1129, 492);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(btnUyeOl);
            Controls.Add(btnGiris);
            Controls.Add(txtSifre);
            Controls.Add(lblSifre);
            Controls.Add(txtEmail);
            Controls.Add(lblEmail);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblEmail;
        private TextBox txtEmail;
        private TextBox txtSifre;
        private Label lblSifre;
        private Button btnGiris;
        private Button btnUyeOl;
        private Label label1;
        private Label label2;
    }
}