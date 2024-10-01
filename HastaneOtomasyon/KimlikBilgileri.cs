using HastaneOtomasyon.DataAccess;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HastaneOtomasyon
{
    public partial class KimlikBilgileri : Form
    {
        private Point fixedLocation = new Point(300, 100);
        public KimlikBilgileri()
        {
            InitializeComponent();
        }

        private void btnrandevuAl_Click(object sender, EventArgs e)
        {
            hastaHome hastaHome = new hastaHome();
            hastaHome.Show();
            this.Close();
        }

        private void btnRandevularım_Click(object sender, EventArgs e)
        {
            this.Hide();
            Randevularım rand = new Randevularım();
            rand.Show();
        }

        private void btnGecmisRandevular_Click(object sender, EventArgs e)
        {
            GecmisRandevularım gecmisRandevularım = new GecmisRandevularım();
            gecmisRandevularım.Show();
            this.Close();
        }


        private void btnKimlikBilgiler_Click(object sender, EventArgs e)
        {
            KimlikBilgileri kimlikBilgileri = new KimlikBilgileri();
            kimlikBilgileri.Show();
            this.Close();
        }

        private void KimlikBilgileri_Load(object sender, EventArgs e)
        {
           
            this.LocationChanged += KimlikBilgileri_LocationChanged;
            DisplayKimlikBilgileri();
        }

        private void KimlikBilgileri_LocationChanged(object sender, EventArgs e)
        {
            this.Location = fixedLocation;

        }

        private void btnHastaHomeProfil_Click(object sender, EventArgs e)
        {

            grbBoxHastaHomeProfil.Visible = !grbBoxHastaHomeProfil.Visible;

        }
        private void DisplayKimlikBilgileri()
        {
            
            var ad = SessionManager.Instance.UserName;
            var soyad = SessionManager.Instance.UserSurname;
            var cinsiyet = SessionManager.Instance.UserGender;
            var dogumTarihi = SessionManager.Instance.UserDTarihi;

            
            DateTime dogumTarihiDateTime = DateTime.Parse(dogumTarihi);
            string formattedDogumTarihi = dogumTarihiDateTime.ToString("dd.MM.yyyy");

            
            Panel pnlKisiselBilgiler = new Panel();
            pnlKisiselBilgiler.Size = new Size(500, 175);
            pnlKisiselBilgiler.Location = new Point(20, 20);
            pnlKisiselBilgiler.BorderStyle = BorderStyle.FixedSingle;
            pnlKisiselBilgiler.BackColor = Color.White;
            pnlKisiselBilgiler.Margin = new Padding(20, 30, 10, 5);

            
            Label lblBaslik = new Label();
            lblBaslik.Text = "Kişisel Bilgiler";
            lblBaslik.Font = new Font("Arial", 12, FontStyle.Bold);
            lblBaslik.Location = new Point(10, 10);
            lblBaslik.Padding = new Padding(10);
            lblBaslik.AutoSize = true;

            
            Label lblBaslikAltCizgi = new Label();
            lblBaslikAltCizgi.BorderStyle = BorderStyle.Fixed3D;
            lblBaslikAltCizgi.Size = new Size(500, 2);
            lblBaslikAltCizgi.Location = new Point(lblBaslik.Left - 10, lblBaslik.Bottom + 17);

           
            Label lblAd = new Label();
            lblAd.Text = "Ad";
            lblAd.Font = new Font("Arial", 11, FontStyle.Regular);
            lblAd.Location = new Point(20, lblBaslikAltCizgi.Bottom + 5);
            lblAd.ForeColor = Color.CadetBlue;

            Label lblAdVeri = new Label();
            lblAdVeri.Text = ad;
            lblAdVeri.Font = new Font("Arial", 11, FontStyle.Italic);
            lblAdVeri.Location = new Point(lblAd.Right + 140, lblBaslikAltCizgi.Bottom + 5);
            lblAdVeri.ForeColor = Color.Black;
            lblAdVeri.AutoSize = true;

            
            Label lblAdAltCizgi = new Label();
            lblAdAltCizgi.BorderStyle = BorderStyle.Fixed3D;
            lblAdAltCizgi.Size = new Size(500, 2);
            lblAdAltCizgi.Location = new Point(lblAd.Left - 20, lblAd.Bottom);

            
            Label lblSoyad = new Label();
            lblSoyad.Text = "Soyad";
            lblSoyad.Location = new Point(20, lblAdAltCizgi.Bottom + 5);
            lblSoyad.Font = new Font("Arial", 11, FontStyle.Regular);
            lblSoyad.ForeColor = Color.CadetBlue;

            Label lblSoyadVeri = new Label();
            lblSoyadVeri.Text = soyad;
            lblSoyadVeri.Location = new Point(lblSoyad.Right + 140, lblAdAltCizgi.Bottom + 5);
            lblSoyadVeri.Font = new Font("Arial", 11, FontStyle.Italic);
            lblSoyadVeri.ForeColor = Color.Black;
            lblSoyadVeri.AutoSize = true;

            
            Label lblSoyadAltCizgi = new Label();
            lblSoyadAltCizgi.BorderStyle = BorderStyle.Fixed3D;
            lblSoyadAltCizgi.Size = new Size(500, 2);
            lblSoyadAltCizgi.Location = new Point(lblSoyad.Left - 20, lblSoyad.Bottom);

         
            Label lblCinsiyet = new Label();
            lblCinsiyet.Text = "Cinsiyet";
            lblCinsiyet.Location = new Point(20, lblSoyadAltCizgi.Bottom + 5);
            lblCinsiyet.Font = new Font("Arial", 11, FontStyle.Regular);
            lblCinsiyet.ForeColor = Color.CadetBlue;

            Label lblCinsiyetVeri = new Label();
            lblCinsiyetVeri.Text = cinsiyet == "K" ? "Kadın" : "Erkek";
            lblCinsiyetVeri.Location = new Point(lblCinsiyet.Right + 140, lblSoyadAltCizgi.Bottom + 5);
            lblCinsiyetVeri.Font = new Font("Arial", 11, FontStyle.Italic);
            lblCinsiyetVeri.ForeColor = Color.Black;
            lblCinsiyetVeri.AutoSize = true;

            
            Label lblCinsiyetAltCizgi = new Label();
            lblCinsiyetAltCizgi.BorderStyle = BorderStyle.Fixed3D;
            lblCinsiyetAltCizgi.Size = new Size(500, 2);
            lblCinsiyetAltCizgi.Location = new Point(lblCinsiyet.Left - 20, lblCinsiyet.Bottom);

            
            Label lblDogumTarihi = new Label();
            lblDogumTarihi.Text = "Doğum Tarihi";
            lblDogumTarihi.Location = new Point(20, lblCinsiyetAltCizgi.Bottom + 5);
            lblDogumTarihi.Font = new Font("Arial", 11, FontStyle.Regular);
            lblDogumTarihi.ForeColor = Color.CadetBlue;

            Label lblDogumTarihiVeri = new Label();
            lblDogumTarihiVeri.Text = formattedDogumTarihi;
            lblDogumTarihiVeri.Location = new Point(lblDogumTarihi.Right + 140, lblCinsiyetAltCizgi.Bottom + 5);
            lblDogumTarihiVeri.Font = new Font("Arial", 11, FontStyle.Italic);
            lblDogumTarihiVeri.ForeColor = Color.Black;
            lblDogumTarihiVeri.AutoSize = true;

            
            pnlKisiselBilgiler.Controls.Add(lblBaslik);
            pnlKisiselBilgiler.Controls.Add(lblBaslikAltCizgi);
            pnlKisiselBilgiler.Controls.Add(lblAd);
            pnlKisiselBilgiler.Controls.Add(lblAdVeri);
            pnlKisiselBilgiler.Controls.Add(lblAdAltCizgi);
            pnlKisiselBilgiler.Controls.Add(lblSoyad);
            pnlKisiselBilgiler.Controls.Add(lblSoyadVeri);
            pnlKisiselBilgiler.Controls.Add(lblSoyadAltCizgi);
            pnlKisiselBilgiler.Controls.Add(lblCinsiyet);
            pnlKisiselBilgiler.Controls.Add(lblCinsiyetVeri);
            pnlKisiselBilgiler.Controls.Add(lblCinsiyetAltCizgi);
            pnlKisiselBilgiler.Controls.Add(lblDogumTarihi);
            pnlKisiselBilgiler.Controls.Add(lblDogumTarihiVeri);

           
            flowLayoutPanelKimlikBilgileri.Controls.Add(pnlKisiselBilgiler);
        }



        private void gunaButton1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnİletişimBilgileri_Click(object sender, EventArgs e)
        {
            IletisimBilgileri ıletisimBilgileri = new IletisimBilgileri();
            ıletisimBilgileri.Show();
            this.Close();
        }

        private void btnParolaİşlemleri_Click(object sender, EventArgs e)
        {
            ParolaIslemleri parolaIslemleri = new ParolaIslemleri();
            parolaIslemleri.Show();
            this.Close();
        }

        private void btnCıkısYap_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Çıkmak istediğinize emin misiniz?", "Çıkış", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (dialogResult == DialogResult.Yes)
            {
                // Çıkış yap fonksiyonunu çağır
                SessionManager.Instance.CikisYap();
            }
        }
    }
}
