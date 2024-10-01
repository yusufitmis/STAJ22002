namespace HastaneOtomasyon.PersonelModül.CihazIslemleri
{
    partial class BakimOnarimGuncelle
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
            this.dtpSonrakiBakimTarihi = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.tbxAciklama = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cbxBakimDurumu = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cbxPersonel = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.dtpBakimTarihi = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.cbxBakimTuru = new System.Windows.Forms.ComboBox();
            this.btnKaydet = new Guna.UI.WinForms.GunaButton();
            this.label2 = new System.Windows.Forms.Label();
            this.tbxCihazAdı = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // dtpSonrakiBakimTarihi
            // 
            this.dtpSonrakiBakimTarihi.Location = new System.Drawing.Point(213, 165);
            this.dtpSonrakiBakimTarihi.Name = "dtpSonrakiBakimTarihi";
            this.dtpSonrakiBakimTarihi.Size = new System.Drawing.Size(230, 22);
            this.dtpSonrakiBakimTarihi.TabIndex = 122;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(14, 164);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(160, 19);
            this.label7.TabIndex = 121;
            this.label7.Text = "Sonraki Bakım Tarihi";
            // 
            // tbxAciklama
            // 
            this.tbxAciklama.Location = new System.Drawing.Point(213, 297);
            this.tbxAciklama.Multiline = true;
            this.tbxAciklama.Name = "tbxAciklama";
            this.tbxAciklama.Size = new System.Drawing.Size(230, 63);
            this.tbxAciklama.TabIndex = 120;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(14, 296);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(76, 19);
            this.label6.TabIndex = 119;
            this.label6.Text = "Açıklama";
            // 
            // cbxBakimDurumu
            // 
            this.cbxBakimDurumu.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.cbxBakimDurumu.FormattingEnabled = true;
            this.cbxBakimDurumu.Items.AddRange(new object[] {
            "Planlandı",
            "Devam Ediyor",
            "İptal Edildi",
            "Tamamlandı"});
            this.cbxBakimDurumu.Location = new System.Drawing.Point(213, 251);
            this.cbxBakimDurumu.Name = "cbxBakimDurumu";
            this.cbxBakimDurumu.Size = new System.Drawing.Size(230, 27);
            this.cbxBakimDurumu.TabIndex = 118;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(14, 253);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(118, 19);
            this.label5.TabIndex = 117;
            this.label5.Text = "Bakım Durumu";
            // 
            // cbxPersonel
            // 
            this.cbxPersonel.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.cbxPersonel.FormattingEnabled = true;
            this.cbxPersonel.Location = new System.Drawing.Point(213, 206);
            this.cbxPersonel.Name = "cbxPersonel";
            this.cbxPersonel.Size = new System.Drawing.Size(230, 27);
            this.cbxPersonel.TabIndex = 116;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(14, 208);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(73, 19);
            this.label4.TabIndex = 115;
            this.label4.Text = "Personel";
            // 
            // dtpBakimTarihi
            // 
            this.dtpBakimTarihi.Location = new System.Drawing.Point(213, 76);
            this.dtpBakimTarihi.Name = "dtpBakimTarihi";
            this.dtpBakimTarihi.Size = new System.Drawing.Size(230, 22);
            this.dtpBakimTarihi.TabIndex = 114;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(14, 79);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(99, 19);
            this.label3.TabIndex = 113;
            this.label3.Text = "Bakım Tarihi";
            // 
            // cbxBakimTuru
            // 
            this.cbxBakimTuru.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.cbxBakimTuru.FormattingEnabled = true;
            this.cbxBakimTuru.Items.AddRange(new object[] {
            "Periyodik Bakım",
            "Kapsamlı Bakım",
            "Onarım Bakımı",
            "Kalibrasyon",
            "Yazılım Güncellemesi",
            "Temizlik Bakımı",
            "Acil Durum Bakımı",
            "Değişim",
            "Garanti Kapsamında Bakım"});
            this.cbxBakimTuru.Location = new System.Drawing.Point(213, 119);
            this.cbxBakimTuru.Name = "cbxBakimTuru";
            this.cbxBakimTuru.Size = new System.Drawing.Size(230, 27);
            this.cbxBakimTuru.TabIndex = 112;
            // 
            // btnKaydet
            // 
            this.btnKaydet.AnimationHoverSpeed = 0.07F;
            this.btnKaydet.AnimationSpeed = 0.03F;
            this.btnKaydet.BaseColor = System.Drawing.Color.CadetBlue;
            this.btnKaydet.BorderColor = System.Drawing.Color.Black;
            this.btnKaydet.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnKaydet.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnKaydet.ForeColor = System.Drawing.Color.White;
            this.btnKaydet.Image = null;
            this.btnKaydet.ImageSize = new System.Drawing.Size(20, 20);
            this.btnKaydet.Location = new System.Drawing.Point(283, 377);
            this.btnKaydet.Name = "btnKaydet";
            this.btnKaydet.OnHoverBaseColor = System.Drawing.Color.SkyBlue;
            this.btnKaydet.OnHoverBorderColor = System.Drawing.Color.Black;
            this.btnKaydet.OnHoverForeColor = System.Drawing.Color.White;
            this.btnKaydet.OnHoverImage = null;
            this.btnKaydet.OnPressedColor = System.Drawing.Color.Black;
            this.btnKaydet.Size = new System.Drawing.Size(160, 42);
            this.btnKaydet.TabIndex = 111;
            this.btnKaydet.Text = "Kaydet";
            this.btnKaydet.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.btnKaydet.Click += new System.EventHandler(this.btnKaydet_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(14, 118);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 19);
            this.label2.TabIndex = 110;
            this.label2.Text = "Bakım Türü";
            // 
            // tbxCihazAdı
            // 
            this.tbxCihazAdı.Location = new System.Drawing.Point(213, 37);
            this.tbxCihazAdı.Name = "tbxCihazAdı";
            this.tbxCihazAdı.Size = new System.Drawing.Size(230, 22);
            this.tbxCihazAdı.TabIndex = 109;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(14, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 19);
            this.label1.TabIndex = 108;
            this.label1.Text = "CihazID";
            // 
            // BakimOnarimGuncelle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(457, 454);
            this.Controls.Add(this.dtpSonrakiBakimTarihi);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.tbxAciklama);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cbxBakimDurumu);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cbxPersonel);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dtpBakimTarihi);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cbxBakimTuru);
            this.Controls.Add(this.btnKaydet);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbxCihazAdı);
            this.Controls.Add(this.label1);
            this.Name = "BakimOnarimGuncelle";
            this.Text = "BakimOnarimGuncelle";
            this.Load += new System.EventHandler(this.BakimOnarimGuncelle_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dtpSonrakiBakimTarihi;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox tbxAciklama;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cbxBakimDurumu;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cbxPersonel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dtpBakimTarihi;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbxBakimTuru;
        private Guna.UI.WinForms.GunaButton btnKaydet;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbxCihazAdı;
        private System.Windows.Forms.Label label1;
    }
}