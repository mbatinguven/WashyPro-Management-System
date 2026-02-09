namespace WashyPRO
{
    partial class RezervasyonSil
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
            dataGridViewRezervasyonlar = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dataGridViewRezervasyonlar).BeginInit();
            SuspendLayout();
            // 
            // dataGridViewRezervasyonlar
            // 
            dataGridViewRezervasyonlar.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewRezervasyonlar.Dock = DockStyle.Fill;
            dataGridViewRezervasyonlar.Location = new Point(0, 0);
            dataGridViewRezervasyonlar.Name = "dataGridViewRezervasyonlar";
            dataGridViewRezervasyonlar.RowHeadersWidth = 51;
            dataGridViewRezervasyonlar.RowTemplate.Height = 29;
            dataGridViewRezervasyonlar.Size = new Size(1265, 532);
            dataGridViewRezervasyonlar.TabIndex = 0;
            dataGridViewRezervasyonlar.CellClick += dataGridViewRezervasyonlar_CellClick;
            // 
            // RezervasyonSil
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1265, 532);
            Controls.Add(dataGridViewRezervasyonlar);
            Name = "RezervasyonSil";
            Text = "RezervasyonSil";
            Load += RezervasyonSil_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridViewRezervasyonlar).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dataGridViewRezervasyonlar;
    }
}