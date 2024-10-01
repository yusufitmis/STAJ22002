namespace HastaneOtomasyon.PersonelModül.StokIslemleri
{
    partial class TedarikciEkle
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
            this.tbxAdres = new System.Windows.Forms.TextBox();
            this.tbxAdre = new System.Windows.Forms.Label();
            this.btnKaydet = new Guna.UI.WinForms.GunaButton();
            this.tbxTedarikciAd = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tbxTelefon = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbxEposta = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbxTemsilci = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // tbxAdres
            // 
            this.tbxAdres.Location = new System.Drawing.Point(211, 180);
            this.tbxAdres.Multiline = true;
            this.tbxAdres.Name = "tbxAdres";
            this.tbxAdres.Size = new System.Drawing.Size(230, 63);
            this.tbxAdres.TabIndex = 120;
            // 
            // tbxAdre
            // 
            this.tbxAdre.AutoSize = true;
            this.tbxAdre.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.tbxAdre.ForeColor = System.Drawing.Color.Black;
            this.tbxAdre.Location = new System.Drawing.Point(12, 179);
            this.tbxAdre.Name = "tbxAdre";
            this.tbxAdre.Size = new System.Drawing.Size(52, 19);
            this.tbxAdre.TabIndex = 119;
            this.tbxAdre.Text = "Adres";
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
            this.btnKaydet.Location = new System.Drawing.Point(281, 272);
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
            // tbxTedarikciAd
            // 
            this.tbxTedarikciAd.Location = new System.Drawing.Point(211, 22);
            this.tbxTedarikciAd.Name = "tbxTedarikciAd";
            this.tbxTedarikciAd.Size = new System.Drawing.Size(230, 22);
            this.tbxTedarikciAd.TabIndex = 109;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(12, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 19);
            this.label1.TabIndex = 108;
            this.label1.Text = "Tedarikçi Ad";
            // 
            // tbxTelefon
            // 
            this.tbxTelefon.Location = new System.Drawing.Point(211, 63);
            this.tbxTelefon.Name = "tbxTelefon";
            this.tbxTelefon.Size = new System.Drawing.Size(230, 22);
            this.tbxTelefon.TabIndex = 122;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(12, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(130, 19);
            this.label2.TabIndex = 121;
            this.label2.Text = "Tedarikçi Telefon";
            // 
            // tbxEposta
            // 
            this.tbxEposta.Location = new System.Drawing.Point(211, 102);
            this.tbxEposta.Name = "tbxEposta";
            this.tbxEposta.Size = new System.Drawing.Size(230, 22);
            this.tbxEposta.TabIndex = 124;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(12, 101);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(129, 19);
            this.label3.TabIndex = 123;
            this.label3.Text = "Tedarikçi Eposta";
            // 
            // tbxTemsilci
            // 
            this.tbxTemsilci.Location = new System.Drawing.Point(211, 143);
            this.tbxTemsilci.Name = "tbxTemsilci";
            this.tbxTemsilci.Size = new System.Drawing.Size(230, 22);
            this.tbxTemsilci.TabIndex = 126;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(12, 142);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(136, 19);
            this.label4.TabIndex = 125;
            this.label4.Text = "Tedarikçi Temsilci";
            // 
            // TedarikciEkle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(455, 396);
            this.Controls.Add(this.tbxTemsilci);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tbxEposta);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbxTelefon);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbxAdres);
            this.Controls.Add(this.tbxAdre);
            this.Controls.Add(this.btnKaydet);
            this.Controls.Add(this.tbxTedarikciAd);
            this.Controls.Add(this.label1);
            this.Name = "TedarikciEkle";
            this.Text = "TedarikciEkle";
            this.Load += new System.EventHandler(this.TedarikciEkle_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbxAdres;
        private System.Windows.Forms.Label tbxAdre;
        private Guna.UI.WinForms.GunaButton btnKaydet;
        private System.Windows.Forms.TextBox tbxTedarikciAd;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbxTelefon;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbxEposta;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbxTemsilci;
        private System.Windows.Forms.Label label4;
    }
}