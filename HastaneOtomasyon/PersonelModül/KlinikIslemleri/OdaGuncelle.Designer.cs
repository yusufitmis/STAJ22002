namespace HastaneOtomasyon.PersonelModül.KlinikIslemleri
{
    partial class OdaGuncelle
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
            this.cbxServisler = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnKaydet = new Guna.UI.WinForms.GunaButton();
            this.tbxKapasite = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbxOdaNo = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cbxServisler
            // 
            this.cbxServisler.FormattingEnabled = true;
            this.cbxServisler.Location = new System.Drawing.Point(164, 106);
            this.cbxServisler.Name = "cbxServisler";
            this.cbxServisler.Size = new System.Drawing.Size(230, 24);
            this.cbxServisler.TabIndex = 88;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(24, 106);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 19);
            this.label3.TabIndex = 87;
            this.label3.Text = "Servis";
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
            this.btnKaydet.Location = new System.Drawing.Point(234, 148);
            this.btnKaydet.Name = "btnKaydet";
            this.btnKaydet.OnHoverBaseColor = System.Drawing.Color.SkyBlue;
            this.btnKaydet.OnHoverBorderColor = System.Drawing.Color.Black;
            this.btnKaydet.OnHoverForeColor = System.Drawing.Color.White;
            this.btnKaydet.OnHoverImage = null;
            this.btnKaydet.OnPressedColor = System.Drawing.Color.Black;
            this.btnKaydet.Size = new System.Drawing.Size(160, 42);
            this.btnKaydet.TabIndex = 86;
            this.btnKaydet.Text = "Kaydet";
            this.btnKaydet.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.btnKaydet.Click += new System.EventHandler(this.btnKaydet_Click);
            // 
            // tbxKapasite
            // 
            this.tbxKapasite.Location = new System.Drawing.Point(164, 66);
            this.tbxKapasite.Name = "tbxKapasite";
            this.tbxKapasite.Size = new System.Drawing.Size(230, 22);
            this.tbxKapasite.TabIndex = 85;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(22, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 19);
            this.label2.TabIndex = 84;
            this.label2.Text = "Kapasite";
            // 
            // tbxOdaNo
            // 
            this.tbxOdaNo.Location = new System.Drawing.Point(164, 27);
            this.tbxOdaNo.Name = "tbxOdaNo";
            this.tbxOdaNo.Size = new System.Drawing.Size(230, 22);
            this.tbxOdaNo.TabIndex = 83;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(22, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 19);
            this.label1.TabIndex = 82;
            this.label1.Text = "Oda No";
            // 
            // OdaGuncelle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(417, 216);
            this.Controls.Add(this.cbxServisler);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnKaydet);
            this.Controls.Add(this.tbxKapasite);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbxOdaNo);
            this.Controls.Add(this.label1);
            this.Name = "OdaGuncelle";
            this.Text = "OdaGuncelle";
            this.Load += new System.EventHandler(this.OdaGuncelle_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbxServisler;
        private System.Windows.Forms.Label label3;
        private Guna.UI.WinForms.GunaButton btnKaydet;
        private System.Windows.Forms.TextBox tbxKapasite;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbxOdaNo;
        private System.Windows.Forms.Label label1;
    }
}