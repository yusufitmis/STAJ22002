namespace HastaneOtomasyon.PersonelModül.KlinikIslemleri
{
    partial class ServisGuncelle
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
            this.btnKaydet = new Guna.UI.WinForms.GunaButton();
            this.tbxDahiliTel = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbxServisSorumlu = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbxServisad = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
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
            this.btnKaydet.Location = new System.Drawing.Point(240, 180);
            this.btnKaydet.Name = "btnKaydet";
            this.btnKaydet.OnHoverBaseColor = System.Drawing.Color.SkyBlue;
            this.btnKaydet.OnHoverBorderColor = System.Drawing.Color.Black;
            this.btnKaydet.OnHoverForeColor = System.Drawing.Color.White;
            this.btnKaydet.OnHoverImage = null;
            this.btnKaydet.OnPressedColor = System.Drawing.Color.Black;
            this.btnKaydet.Size = new System.Drawing.Size(160, 42);
            this.btnKaydet.TabIndex = 72;
            this.btnKaydet.Text = "Kaydet";
            this.btnKaydet.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.btnKaydet.Click += new System.EventHandler(this.btnKaydet_Click);
            // 
            // tbxDahiliTel
            // 
            this.tbxDahiliTel.Location = new System.Drawing.Point(170, 122);
            this.tbxDahiliTel.Name = "tbxDahiliTel";
            this.tbxDahiliTel.Size = new System.Drawing.Size(230, 22);
            this.tbxDahiliTel.TabIndex = 71;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(28, 125);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 19);
            this.label3.TabIndex = 70;
            this.label3.Text = "Dahili Tel";
            // 
            // tbxServisSorumlu
            // 
            this.tbxServisSorumlu.Location = new System.Drawing.Point(170, 82);
            this.tbxServisSorumlu.Name = "tbxServisSorumlu";
            this.tbxServisSorumlu.Size = new System.Drawing.Size(230, 22);
            this.tbxServisSorumlu.TabIndex = 69;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(28, 82);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 19);
            this.label2.TabIndex = 68;
            this.label2.Text = "Sorumlu";
            // 
            // tbxServisad
            // 
            this.tbxServisad.Location = new System.Drawing.Point(170, 43);
            this.tbxServisad.Name = "tbxServisad";
            this.tbxServisad.Size = new System.Drawing.Size(230, 22);
            this.tbxServisad.TabIndex = 67;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(28, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 19);
            this.label1.TabIndex = 66;
            this.label1.Text = "Servis Ad";
            // 
            // ServisGuncelle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(428, 264);
            this.Controls.Add(this.btnKaydet);
            this.Controls.Add(this.tbxDahiliTel);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbxServisSorumlu);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbxServisad);
            this.Controls.Add(this.label1);
            this.Name = "ServisGuncelle";
            this.Text = "ServisGuncelle";
            this.Load += new System.EventHandler(this.ServisGuncelle_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI.WinForms.GunaButton btnKaydet;
        private System.Windows.Forms.TextBox tbxDahiliTel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbxServisSorumlu;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbxServisad;
        private System.Windows.Forms.Label label1;
    }
}