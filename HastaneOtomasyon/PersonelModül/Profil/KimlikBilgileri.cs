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

namespace HastaneOtomasyon.PersonelModül.Profil
{
    public partial class KimlikBilgileri : Form
    {
        private Point fixedLocation = new Point(100, 50);
        public KimlikBilgileri()
        {
            InitializeComponent();
        }
        private void gunaButton1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void KimlikBilgileri_Load(object sender, EventArgs e)
        {
            this.LocationChanged += KimlikBilgileri_LocationChanged;
            DisplayKimlikBilgileri();
        }
        private void DisplayKimlikBilgileri()
        {
            var ad = SessionManager.Instance.UserName;
            var soyad = SessionManager.Instance.UserSurname;
            var cinsiyet = SessionManager.Instance.UserGender;
            var dogumTarihi = SessionManager.Instance.UserDTarihi;
            var gorev = SessionManager.Instance.Gorev;
            var ogrenim = SessionManager.Instance.Ogrenim;
            var diplomaNo = SessionManager.Instance.DiplomaNo;


            DateTime dogumTarihiDateTime = DateTime.Parse(dogumTarihi);
            string formattedDogumTarihi = dogumTarihiDateTime.ToString("dd.MM.yyyy");

            Panel pnlKisiselBilgiler = new Panel();
            pnlKisiselBilgiler.Size = new Size(500, 280);
            pnlKisiselBilgiler.Location = new Point(100, 100);
            pnlKisiselBilgiler.BorderStyle = BorderStyle.FixedSingle;
            pnlKisiselBilgiler.BackColor = Color.White;
            pnlKisiselBilgiler.Margin = new Padding(180, 80, 10, 5);


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

            Label lblDogumTarihiAltCizgi = new Label();
            lblDogumTarihiAltCizgi.BorderStyle = BorderStyle.Fixed3D;
            lblDogumTarihiAltCizgi.Size = new Size(500, 2);
            lblDogumTarihiAltCizgi.Location = new Point(lblDogumTarihi.Left - 20, lblDogumTarihi.Bottom);

            Label lblGorev = new Label();
            lblGorev.Text = "Görev";
            lblGorev.Location = new Point(20, lblDogumTarihiAltCizgi.Bottom + 5);
            lblGorev.Font = new Font("Arial", 11, FontStyle.Regular);
            lblGorev.ForeColor = Color.CadetBlue;

            Label lblGorevVeri = new Label();
            lblGorevVeri.Text = gorev;
            lblGorevVeri.Location = new Point(lblGorev.Right + 140, lblDogumTarihiAltCizgi.Bottom + 5);
            lblGorevVeri.Font = new Font("Arial", 11, FontStyle.Italic);
            lblGorevVeri.ForeColor = Color.Black;
            lblGorevVeri.AutoSize = true;

            Label lblGorevAltCizgi = new Label();
            lblGorevAltCizgi.BorderStyle = BorderStyle.Fixed3D;
            lblGorevAltCizgi.Size = new Size(500, 2);
            lblGorevAltCizgi.Location = new Point(lblGorev.Left - 20, lblGorev.Bottom);

            Label lblOgrenim = new Label();
            lblOgrenim.Text = "Öğrenim Durumu";
            lblOgrenim.Location = new Point(20, lblGorevAltCizgi.Bottom + 5);
            lblOgrenim.Font = new Font("Arial", 11, FontStyle.Regular);
            lblOgrenim.ForeColor = Color.CadetBlue;

            Label lblOgrenimVeri = new Label();
            lblOgrenimVeri.Text = ogrenim;
            lblOgrenimVeri.Location = new Point(lblOgrenim.Right + 140, lblGorevAltCizgi.Bottom + 5);
            lblOgrenimVeri.Font = new Font("Arial", 11, FontStyle.Italic);
            lblOgrenimVeri.ForeColor = Color.Black;
            lblOgrenimVeri.AutoSize = true;

            Label lblOgrenimAltCizgi = new Label();
            lblOgrenimAltCizgi.BorderStyle = BorderStyle.Fixed3D;
            lblOgrenimAltCizgi.Size = new Size(500, 2);
            lblOgrenimAltCizgi.Location = new Point(lblOgrenim.Left - 20, lblOgrenim.Bottom);

            Label lblDiplomaNo = new Label();
            lblDiplomaNo.Text = "Diploma No";
            lblDiplomaNo.Location = new Point(20, lblOgrenimAltCizgi.Bottom + 5);
            lblDiplomaNo.Font = new Font("Arial", 11, FontStyle.Regular);
            lblDiplomaNo.ForeColor = Color.CadetBlue;

            Label lblDiplomaNoVeri = new Label();
            lblDiplomaNoVeri.Text = diplomaNo;
            lblDiplomaNoVeri.Location = new Point(lblDiplomaNo.Right + 140, lblOgrenimAltCizgi.Bottom + 5);
            lblDiplomaNoVeri.Font = new Font("Arial", 11, FontStyle.Italic);
            lblDiplomaNoVeri.ForeColor = Color.Black;
            lblDiplomaNoVeri.AutoSize = true;


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
            pnlKisiselBilgiler.Controls.Add(lblDogumTarihiAltCizgi);
            pnlKisiselBilgiler.Controls.Add(lblGorev);
            pnlKisiselBilgiler.Controls.Add(lblGorevVeri);
            pnlKisiselBilgiler.Controls.Add(lblGorevAltCizgi);
            pnlKisiselBilgiler.Controls.Add(lblOgrenim);
            pnlKisiselBilgiler.Controls.Add(lblOgrenimVeri);
            pnlKisiselBilgiler.Controls.Add(lblOgrenimAltCizgi);
            pnlKisiselBilgiler.Controls.Add(lblDiplomaNo);
            pnlKisiselBilgiler.Controls.Add(lblDiplomaNoVeri);






            flowLayoutPanelKimlikBilgileri.Controls.Add(pnlKisiselBilgiler);
        }

        private void KimlikBilgileri_LocationChanged(object sender, EventArgs e)
        {
            this.Location = fixedLocation;
        }
        

        private void btnPersonelIslem_Click(object sender, EventArgs e)
        {
            PersonelModül.PersonelIslemleri.PersonelIslemleri personelIslemleri = new PersonelModül.PersonelIslemleri.PersonelIslemleri();
            personelIslemleri.Show();
            this.Close();
        }

        private void btnHastaIslemleri_Click(object sender, EventArgs e)
        {
            PersonelModül.HastaIslemleri.HastaIslemleri hastaIslemleri = new PersonelModül.HastaIslemleri.HastaIslemleri();
            hastaIslemleri.Show();
            this.Close();
        }

        private void btnKlinikİslemleri_Click(object sender, EventArgs e)
        {
            PersonelModül.KlinikIslemleri.KlinikIslemleri klinikIslemleri = new PersonelModül.KlinikIslemleri.KlinikIslemleri();
            klinikIslemleri.Show();
            this.Close();
        }

        private void btnStokIslemleri_Click(object sender, EventArgs e)
        {
            PersonelModül.StokIslemleri.StokIslemleri stokIslemleri = new PersonelModül.StokIslemleri.StokIslemleri();
            stokIslemleri.Show();
            this.Close();
        }

        

        private void btnCihazIslemleri_Click(object sender, EventArgs e)
        {
            PersonelModül.CihazIslemleri.CihazIslemleri cihazIslemleri = new PersonelModül.CihazIslemleri.CihazIslemleri();
            cihazIslemleri.Show();
            this.Close();
        }

        private void btnHastaHomeProfil_Click(object sender, EventArgs e)
        {
            grbBoxProfil.Visible = !grbBoxProfil.Visible;
        }

        private void btnİletişimBilgileri_Click(object sender, EventArgs e)
        {
            PersonelModül.Profil.IletisimBilgileri ıletisimBilgileri = new PersonelModül.Profil.IletisimBilgileri();
            ıletisimBilgileri.Show();
            this.Close();
        }

        private void btnParolaİşlemleri_Click(object sender, EventArgs e)
        {
            PersonelModül.Profil.ParolaIslemleri parolaIslemleri = new PersonelModül.Profil.ParolaIslemleri();
            parolaIslemleri.Show();
            this.Close();
        }

        private void btnCıkısYap_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Çıkmak istediğinize emin misiniz?", "Çıkış", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (dialogResult == DialogResult.Yes)
            {
                SessionManager.Instance.CikisYap();
            }
        }
    }
}
