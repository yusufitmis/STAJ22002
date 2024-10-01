namespace HastaneOtomasyon.PersonelModül.StokIslemleri
{
    partial class StokGuncelle
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
            this.cbxTedarikci = new System.Windows.Forms.ComboBox();
            this.cbxUrunTuru = new System.Windows.Forms.ComboBox();
            this.dtpSonGuncellemeTarihi = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.tbxMiktar = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbxAdre = new System.Windows.Forms.Label();
            this.btnKaydet = new Guna.UI.WinForms.GunaButton();
            this.tbxxUrunAd = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cbxTedarikci
            // 
            this.cbxTedarikci.FormattingEnabled = true;
            this.cbxTedarikci.Location = new System.Drawing.Point(215, 148);
            this.cbxTedarikci.Name = "cbxTedarikci";
            this.cbxTedarikci.Size = new System.Drawing.Size(230, 24);
            this.cbxTedarikci.TabIndex = 151;
            // 
            // cbxUrunTuru
            // 
            this.cbxUrunTuru.FormattingEnabled = true;
            this.cbxUrunTuru.Items.AddRange(new object[] {
            "Koruyucu Malzeme",
            "Tıbbi Cihaz",
            "Mobilya",
            "Kimyasal",
            "Tıbbi Malzeme",
            "Tıbbi Ekipman"});
            this.cbxUrunTuru.Location = new System.Drawing.Point(215, 73);
            this.cbxUrunTuru.Name = "cbxUrunTuru";
            this.cbxUrunTuru.Size = new System.Drawing.Size(230, 24);
            this.cbxUrunTuru.TabIndex = 150;
            // 
            // dtpSonGuncellemeTarihi
            // 
            this.dtpSonGuncellemeTarihi.Location = new System.Drawing.Point(215, 190);
            this.dtpSonGuncellemeTarihi.Name = "dtpSonGuncellemeTarihi";
            this.dtpSonGuncellemeTarihi.Size = new System.Drawing.Size(230, 22);
            this.dtpSonGuncellemeTarihi.TabIndex = 149;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(16, 153);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(74, 19);
            this.label4.TabIndex = 148;
            this.label4.Text = "Tedarikçi";
            // 
            // tbxMiktar
            // 
            this.tbxMiktar.Location = new System.Drawing.Point(215, 113);
            this.tbxMiktar.Name = "tbxMiktar";
            this.tbxMiktar.Size = new System.Drawing.Size(230, 22);
            this.tbxMiktar.TabIndex = 147;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(16, 112);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 19);
            this.label3.TabIndex = 146;
            this.label3.Text = "Miktar";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(16, 73);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 19);
            this.label2.TabIndex = 145;
            this.label2.Text = "Ürün Türü";
            // 
            // tbxAdre
            // 
            this.tbxAdre.AutoSize = true;
            this.tbxAdre.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.tbxAdre.ForeColor = System.Drawing.Color.Black;
            this.tbxAdre.Location = new System.Drawing.Point(16, 190);
            this.tbxAdre.Name = "tbxAdre";
            this.tbxAdre.Size = new System.Drawing.Size(172, 19);
            this.tbxAdre.TabIndex = 144;
            this.tbxAdre.Text = "Son Güncelleme Tarihi";
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
            this.btnKaydet.Location = new System.Drawing.Point(285, 283);
            this.btnKaydet.Name = "btnKaydet";
            this.btnKaydet.OnHoverBaseColor = System.Drawing.Color.SkyBlue;
            this.btnKaydet.OnHoverBorderColor = System.Drawing.Color.Black;
            this.btnKaydet.OnHoverForeColor = System.Drawing.Color.White;
            this.btnKaydet.OnHoverImage = null;
            this.btnKaydet.OnPressedColor = System.Drawing.Color.Black;
            this.btnKaydet.Size = new System.Drawing.Size(160, 42);
            this.btnKaydet.TabIndex = 143;
            this.btnKaydet.Text = "Kaydet";
            this.btnKaydet.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.btnKaydet.Click += new System.EventHandler(this.btnKaydet_Click);
            // 
            // tbxxUrunAd
            // 
            this.tbxxUrunAd.Location = new System.Drawing.Point(215, 33);
            this.tbxxUrunAd.Name = "tbxxUrunAd";
            this.tbxxUrunAd.Size = new System.Drawing.Size(230, 22);
            this.tbxxUrunAd.TabIndex = 142;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(16, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 19);
            this.label1.TabIndex = 141;
            this.label1.Text = "Ürün Adı";
            // 
            // StokGuncelle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(460, 356);
            this.Controls.Add(this.cbxTedarikci);
            this.Controls.Add(this.cbxUrunTuru);
            this.Controls.Add(this.dtpSonGuncellemeTarihi);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tbxMiktar);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbxAdre);
            this.Controls.Add(this.btnKaydet);
            this.Controls.Add(this.tbxxUrunAd);
            this.Controls.Add(this.label1);
            this.Name = "StokGuncelle";
            this.Text = "StokGuncelle";
            this.Load += new System.EventHandler(this.StokGuncelle_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbxTedarikci;
        private System.Windows.Forms.ComboBox cbxUrunTuru;
        private System.Windows.Forms.DateTimePicker dtpSonGuncellemeTarihi;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbxMiktar;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label tbxAdre;
        private Guna.UI.WinForms.GunaButton btnKaydet;
        private System.Windows.Forms.TextBox tbxxUrunAd;
        private System.Windows.Forms.Label label1;
    }
}