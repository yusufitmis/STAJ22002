namespace HastaneOtomasyon.PersonelModül.CihazIslemleri
{
    partial class CihazGuncelle
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
            this.btnKaydet = new Guna.UI.WinForms.GunaButton();
            this.label2 = new System.Windows.Forms.Label();
            this.tbxCihazAdı = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tbxDurum = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cbxTedarikci
            // 
            this.cbxTedarikci.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.cbxTedarikci.FormattingEnabled = true;
            this.cbxTedarikci.Location = new System.Drawing.Point(162, 84);
            this.cbxTedarikci.Name = "cbxTedarikci";
            this.cbxTedarikci.Size = new System.Drawing.Size(230, 27);
            this.cbxTedarikci.TabIndex = 97;
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
            this.btnKaydet.Location = new System.Drawing.Point(232, 181);
            this.btnKaydet.Name = "btnKaydet";
            this.btnKaydet.OnHoverBaseColor = System.Drawing.Color.SkyBlue;
            this.btnKaydet.OnHoverBorderColor = System.Drawing.Color.Black;
            this.btnKaydet.OnHoverForeColor = System.Drawing.Color.White;
            this.btnKaydet.OnHoverImage = null;
            this.btnKaydet.OnPressedColor = System.Drawing.Color.Black;
            this.btnKaydet.Size = new System.Drawing.Size(160, 42);
            this.btnKaydet.TabIndex = 96;
            this.btnKaydet.Text = "Kaydet";
            this.btnKaydet.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.btnKaydet.Click += new System.EventHandler(this.btnKaydet_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(20, 84);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 19);
            this.label2.TabIndex = 95;
            this.label2.Text = "Tedarikçi";
            // 
            // tbxCihazAdı
            // 
            this.tbxCihazAdı.Location = new System.Drawing.Point(162, 45);
            this.tbxCihazAdı.Name = "tbxCihazAdı";
            this.tbxCihazAdı.Size = new System.Drawing.Size(230, 22);
            this.tbxCihazAdı.TabIndex = 94;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(20, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 19);
            this.label1.TabIndex = 93;
            this.label1.Text = "Cihaz Adı";
            // 
            // tbxDurum
            // 
            this.tbxDurum.Location = new System.Drawing.Point(162, 131);
            this.tbxDurum.Name = "tbxDurum";
            this.tbxDurum.Size = new System.Drawing.Size(230, 22);
            this.tbxDurum.TabIndex = 99;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(22, 131);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 19);
            this.label3.TabIndex = 98;
            this.label3.Text = "Durum";
            // 
            // CihazGuncelle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(416, 246);
            this.Controls.Add(this.tbxDurum);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cbxTedarikci);
            this.Controls.Add(this.btnKaydet);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbxCihazAdı);
            this.Controls.Add(this.label1);
            this.Name = "CihazGuncelle";
            this.Text = "CihazGuncelle";
            this.Load += new System.EventHandler(this.CihazGuncelle_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbxTedarikci;
        private Guna.UI.WinForms.GunaButton btnKaydet;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbxCihazAdı;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbxDurum;
        private System.Windows.Forms.Label label3;
    }
}