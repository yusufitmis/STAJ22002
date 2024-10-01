using HastaneOtomasyon.DataAccess;
using Oracle.ManagedDataAccess.Client;
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
    public partial class IletisimBilgileri : Form
    {
        private Point fixedLocation = new Point(100, 50);
        public IletisimBilgileri()
        {
            InitializeComponent();
        }

        private void gunaButton1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void IletisimBilgileri_Load(object sender, EventArgs e)
        {
            this.LocationChanged += IletisimBilgileri_LocationChanged;
            flowLayoutPaneIletisimBilgileri.Controls.Clear();
            DisplayEpostaBilgileri();
            DisplayTelefonBilgileri();
        }

        private void IletisimBilgileri_LocationChanged(object sender, EventArgs e)
        {
            this.Location = fixedLocation;
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

        private void btnKlinikİslemleri_Click(object sender, EventArgs e)
        {
            PersonelModül.KlinikIslemleri.KlinikIslemleri klinikIslemleri = new PersonelModül.KlinikIslemleri.KlinikIslemleri();
            klinikIslemleri.Show();
            this.Close();
        }

        private void btnHastaIslemleri_Click(object sender, EventArgs e)
        {
            PersonelModül.HastaIslemleri.HastaIslemleri hastaIslemleri = new PersonelModül.HastaIslemleri.HastaIslemleri();
            hastaIslemleri.Show();
            this.Close();
        }

        private void btnPersonelIslem_Click(object sender, EventArgs e)
        {
            PersonelModül.PersonelIslemleri.PersonelIslemleri personelIslemleri = new PersonelModül.PersonelIslemleri.PersonelIslemleri();
            personelIslemleri.Show();
            this.Close();
        }

        private void btnKimlikBilgiler_Click(object sender, EventArgs e)
        {
            PersonelModül.Profil.KimlikBilgileri kimlikBilgileri = new PersonelModül.Profil.KimlikBilgileri();
            kimlikBilgileri.Show();
            this.Close();
        }
        private void btnParolaİşlemleri_Click(object sender, EventArgs e)
        {
            PersonelModül.Profil.ParolaIslemleri parolaIslemleri = new PersonelModül.Profil.ParolaIslemleri();
            parolaIslemleri.Show();
            this.Close();
        }

        private void btnHastaHomeProfil_Click(object sender, EventArgs e)
        {
            grbBoxProfil.Visible = !grbBoxProfil.Visible;
          
        }
        private void DisplayEpostaBilgileri()
        {
            var eposta = SessionManager.Instance.UserEposta;
            Panel pnlEpostaBilgiler = new Panel();
            pnlEpostaBilgiler.Size = new Size(490, 185);
            pnlEpostaBilgiler.Location = new Point(20, 20);
            pnlEpostaBilgiler.BorderStyle = BorderStyle.FixedSingle;
            pnlEpostaBilgiler.BackColor = Color.White;
            pnlEpostaBilgiler.Margin = new Padding(20, 30, 10, 10);

            Label lblBaslik = new Label();
            lblBaslik.Text = "E-Posta Bilgileri";
            lblBaslik.Font = new Font("Arial", 12, FontStyle.Bold);
            lblBaslik.Location = new Point(10, 10);
            lblBaslik.Padding = new Padding(10);
            lblBaslik.AutoSize = true;

            Label lblBaslikAltCizgi = new Label();
            lblBaslikAltCizgi.BorderStyle = BorderStyle.Fixed3D;
            lblBaslikAltCizgi.Size = new Size(500, 2);
            lblBaslikAltCizgi.Location = new Point(lblBaslik.Left - 10, lblBaslik.Bottom + 17);

            Label lbleposta = new Label();
            lbleposta.Text = "E-Posta Adresi";
            lbleposta.Font = new Font("Arial", 11, FontStyle.Regular);
            lbleposta.Location = new Point(20, lblBaslikAltCizgi.Bottom + 5);
            lbleposta.ForeColor = Color.CadetBlue;

            Label lblepostaVeri = new Label();
            lblepostaVeri.Text = eposta;
            lblepostaVeri.Font = new Font("Arial", 11, FontStyle.Italic);
            lblepostaVeri.Location = new Point(lbleposta.Right + 140, lblBaslikAltCizgi.Bottom + 5);
            lblepostaVeri.ForeColor = Color.Black;
            lblepostaVeri.AutoSize = true;

            Label lblAdAltCizgi = new Label();
            lblAdAltCizgi.BorderStyle = BorderStyle.Fixed3D;
            lblAdAltCizgi.Size = new Size(500, 2);
            lblAdAltCizgi.Location = new Point(lbleposta.Left - 20, lbleposta.Bottom);

            Label lblepostaTip = new Label();
            lblepostaTip.Text = "E-Posta Tipi";
            lblepostaTip.Location = new Point(20, lblAdAltCizgi.Bottom + 5);
            lblepostaTip.Font = new Font("Arial", 11, FontStyle.Regular);
            lblepostaTip.ForeColor = Color.CadetBlue;

            Label lblepostaTipVeri = new Label();
            lblepostaTipVeri.Text = "E-Devlet E-Postası";
            lblepostaTipVeri.Location = new Point(lblepostaTip.Right + 140, lblAdAltCizgi.Bottom + 5);
            lblepostaTipVeri.Font = new Font("Arial", 11, FontStyle.Italic);
            lblepostaTipVeri.ForeColor = Color.Black;
            lblepostaTipVeri.AutoSize = true;

            Button btnEpostaGuncelle = new Button
            {
                Text = "E-Posta Güncelle",
                AutoSize = true,
                Height = 40,
                BackColor = Color.LightCoral,
                Font = new Font("Arial", 11, FontStyle.Bold),
                Cursor = Cursors.Hand,
                Location = new Point(160, lblepostaTip.Bottom + 20),
                Margin = new Padding(0, 0, 0, 15)
            };
            btnEpostaGuncelle.MouseEnter += (sender, args) =>
            {
                btnEpostaGuncelle.BackColor = Color.Red;
                btnEpostaGuncelle.ForeColor = Color.White;
            };
            btnEpostaGuncelle.MouseLeave += (sender, args) =>
            {
                btnEpostaGuncelle.BackColor = Color.LightCoral;
                btnEpostaGuncelle.ForeColor = Color.Black;
            };

            pnlEpostaBilgiler.Controls.Add(lblBaslik);
            pnlEpostaBilgiler.Controls.Add(lblBaslikAltCizgi);
            pnlEpostaBilgiler.Controls.Add(lbleposta);
            pnlEpostaBilgiler.Controls.Add(lblepostaVeri);
            pnlEpostaBilgiler.Controls.Add(lblAdAltCizgi);
            pnlEpostaBilgiler.Controls.Add(lblepostaTip);
            pnlEpostaBilgiler.Controls.Add(lblepostaTipVeri);
            pnlEpostaBilgiler.Controls.Add(btnEpostaGuncelle);

            flowLayoutPaneIletisimBilgileri.Controls.Add(pnlEpostaBilgiler);

            btnEpostaGuncelle.Click += (s, e) =>
            {
                flowLayoutPaneIletisimBilgileri.Controls.Clear();

                Panel pnlEpostaGuncelle = new Panel();
                pnlEpostaGuncelle.Size = new Size(490, 150);
                pnlEpostaGuncelle.Location = new Point(20, 20);
                pnlEpostaGuncelle.BorderStyle = BorderStyle.FixedSingle;
                pnlEpostaGuncelle.BackColor = Color.White;
                pnlEpostaGuncelle.Margin = new Padding(20, 30, 10, 10);

                Label lblEpostanız = new Label();
                lblEpostanız.Text = "E-Posta Adresiniz";
                lblEpostanız.Font = new Font("Arial", 12, FontStyle.Bold);
                lblEpostanız.Location = new Point(10, 10);
                lblEpostanız.Padding = new Padding(10);
                lblEpostanız.AutoSize = true;

                PictureBox btnGeriDon = new PictureBox
                {
                    Image = Image.FromFile("C:\\Users\\yusuf\\Desktop\\hastane otomasyon\\HastaneOtomasyon\\icons\\arrow_left.png"),
                    SizeMode = PictureBoxSizeMode.Zoom,
                    Width = 30,
                    Height = 30,
                    Location = new Point(lblEpostanız.Right + 320, 18),
                    Cursor = Cursors.Hand,
                };

                PictureBox mail = new PictureBox
                {
                    Image = Image.FromFile("C:\\Users\\yusuf\\Desktop\\hastane otomasyon\\HastaneOtomasyon\\icons\\mail.png"),
                    SizeMode = PictureBoxSizeMode.StretchImage,
                    Width = 21,
                    Height = 21,
                    Location = new Point(lblEpostanız.Left + 15, lblEpostanız.Bottom + 17)
                };
                TextBox tbxMail = new TextBox();
                tbxMail.Size = new Size(200, 20);
                tbxMail.BorderStyle = BorderStyle.FixedSingle;
                tbxMail.BorderStyle = BorderStyle.None;
                tbxMail.BackColor = Color.White;
                tbxMail.Text = eposta;
                tbxMail.Font = new Font("Arial", 10, FontStyle.Italic);
                tbxMail.Location = new Point(mail.Right + 5, lblEpostanız.Bottom + 17);
                tbxMail.Click += (sender, args) =>
                {
                    tbxMail.BorderStyle = BorderStyle.Fixed3D;
                    tbxMail.Font = new Font("Arial", 10, FontStyle.Bold);
                };

                Button btnEpostaOnayla = new Button
                {
                    Text = "Onayla",
                    AutoSize = true,
                    Height = 40,
                    Width = 100,
                    BackColor = Color.LightCoral,
                    Font = new Font("Arial", 11, FontStyle.Bold),
                    Cursor = Cursors.Hand,
                    Location = new Point(180, tbxMail.Bottom + 20),
                    Margin = new Padding(0, 0, 0, 15)
                };
                btnEpostaOnayla.Click += (sender, args) =>
                {
                    string newEmail = tbxMail.Text.Trim();
                    if (string.IsNullOrEmpty(newEmail))
                    {
                        MessageBox.Show("Geçerli bir e-posta adresi giriniz.");
                        return;
                    }

                    UpdateEmailInDatabase(newEmail);
                };


                btnGeriDon.Click += (sender, args) =>
                {
                    flowLayoutPaneIletisimBilgileri.Controls.Clear();
                    DisplayEpostaBilgileri();
                    DisplayTelefonBilgileri();
                };

                pnlEpostaGuncelle.Controls.Add(lblEpostanız);
                pnlEpostaGuncelle.Controls.Add(btnGeriDon);
                pnlEpostaGuncelle.Controls.Add(mail);
                pnlEpostaGuncelle.Controls.Add(tbxMail);
                pnlEpostaGuncelle.Controls.Add(btnEpostaOnayla);

                flowLayoutPaneIletisimBilgileri.Controls.Add(pnlEpostaGuncelle);
            };
        }

        private void DisplayTelefonBilgileri()
        {
            var telNo = SessionManager.Instance.UserTelNo;
            Panel pnlTelefonBilgiler = new Panel();
            pnlTelefonBilgiler.Size = new Size(490, 185);
            pnlTelefonBilgiler.Location = new Point(20, 20);
            pnlTelefonBilgiler.BorderStyle = BorderStyle.FixedSingle;
            pnlTelefonBilgiler.BackColor = Color.White;
            pnlTelefonBilgiler.Margin = new Padding(20, 30, 10, 10);

            Label lblBaslik = new Label();
            lblBaslik.Text = "Telefon Bilgileri";
            lblBaslik.Font = new Font("Arial", 12, FontStyle.Bold);
            lblBaslik.Location = new Point(10, 10);
            lblBaslik.Padding = new Padding(10);
            lblBaslik.AutoSize = true;

            Label lblBaslikAltCizgi = new Label();
            lblBaslikAltCizgi.BorderStyle = BorderStyle.Fixed3D;
            lblBaslikAltCizgi.Size = new Size(500, 2);
            lblBaslikAltCizgi.Location = new Point(lblBaslik.Left - 10, lblBaslik.Bottom + 17);

            Label lbltelefon = new Label();
            lbltelefon.Text = "Telefon Numarası";
            lbltelefon.Font = new Font("Arial", 11, FontStyle.Regular);
            lbltelefon.Location = new Point(20, lblBaslikAltCizgi.Bottom + 5);
            lbltelefon.ForeColor = Color.CadetBlue;

            Label lbltelefonVeri = new Label();
            lbltelefonVeri.Text = telNo; // Dinamik telefon bilgisi
            lbltelefonVeri.Font = new Font("Arial", 11, FontStyle.Italic);
            lbltelefonVeri.Location = new Point(lbltelefon.Right + 140, lblBaslikAltCizgi.Bottom + 5);
            lbltelefonVeri.ForeColor = Color.Black;
            lbltelefonVeri.AutoSize = true;

            Label lblTelAltCizgi = new Label();
            lblTelAltCizgi.BorderStyle = BorderStyle.Fixed3D;
            lblTelAltCizgi.Size = new Size(500, 2);
            lblTelAltCizgi.Location = new Point(lbltelefon.Left - 20, lbltelefon.Bottom);

            Label lbltelefonTip = new Label();
            lbltelefonTip.Text = "Telefon Tipi";
            lbltelefonTip.Location = new Point(20, lblTelAltCizgi.Bottom + 5);
            lbltelefonTip.Font = new Font("Arial", 11, FontStyle.Regular);
            lbltelefonTip.ForeColor = Color.CadetBlue;

            Label lbltelefonTipVeri = new Label();
            lbltelefonTipVeri.Text = "Mobil Telefon";
            lbltelefonTipVeri.Location = new Point(lbltelefonTip.Right + 140, lblTelAltCizgi.Bottom + 5);
            lbltelefonTipVeri.Font = new Font("Arial", 11, FontStyle.Italic);
            lbltelefonTipVeri.ForeColor = Color.Black;
            lbltelefonTipVeri.AutoSize = true;

            Button btnTelefonGuncelle = new Button
            {
                Text = "Telefon Güncelle",
                AutoSize = true,
                Height = 40,
                BackColor = Color.LightCoral,
                Font = new Font("Arial", 11, FontStyle.Bold),
                Cursor = Cursors.Hand,
                Location = new Point(160, lbltelefonTip.Bottom + 20),
                Margin = new Padding(0, 0, 0, 15)
            };
            btnTelefonGuncelle.MouseEnter += (sender, args) =>
            {
                btnTelefonGuncelle.BackColor = Color.Red;
                btnTelefonGuncelle.ForeColor = Color.White;
            };
            btnTelefonGuncelle.MouseLeave += (sender, args) =>
            {
                btnTelefonGuncelle.BackColor = Color.LightCoral;
                btnTelefonGuncelle.ForeColor = Color.Black;
            };

            pnlTelefonBilgiler.Controls.Add(lblBaslik);
            pnlTelefonBilgiler.Controls.Add(lblBaslikAltCizgi);
            pnlTelefonBilgiler.Controls.Add(lbltelefon);
            pnlTelefonBilgiler.Controls.Add(lbltelefonVeri);
            pnlTelefonBilgiler.Controls.Add(lblTelAltCizgi);
            pnlTelefonBilgiler.Controls.Add(lbltelefonTip);
            pnlTelefonBilgiler.Controls.Add(lbltelefonTipVeri);
            pnlTelefonBilgiler.Controls.Add(btnTelefonGuncelle);

            flowLayoutPaneIletisimBilgileri.Controls.Add(pnlTelefonBilgiler);

            btnTelefonGuncelle.Click += (s, e) =>
            {
                flowLayoutPaneIletisimBilgileri.Controls.Clear();

                Panel pnlTelefonGuncelle = new Panel();
                pnlTelefonGuncelle.Size = new Size(490, 150);
                pnlTelefonGuncelle.Location = new Point(20, 20);
                pnlTelefonGuncelle.BorderStyle = BorderStyle.FixedSingle;
                pnlTelefonGuncelle.BackColor = Color.White;
                pnlTelefonGuncelle.Margin = new Padding(20, 30, 10, 10);

                Label lblTelefon = new Label();
                lblTelefon.Text = "Telefon Numaranız";
                lblTelefon.Font = new Font("Arial", 12, FontStyle.Bold);
                lblTelefon.Location = new Point(10, 10);
                lblTelefon.Padding = new Padding(10);
                lblTelefon.AutoSize = true;

                PictureBox btnGeriDon = new PictureBox
                {
                    Image = Image.FromFile("C:\\Users\\yusuf\\Desktop\\hastane otomasyon\\HastaneOtomasyon\\icons\\arrow_left.png"),
                    SizeMode = PictureBoxSizeMode.Zoom,
                    Width = 30,
                    Height = 30,
                    Location = new Point(lblTelefon.Right + 320, 18),
                    Cursor = Cursors.Hand,
                };

                PictureBox tel = new PictureBox
                {
                    Image = Image.FromFile("C:\\Users\\yusuf\\Desktop\\hastane otomasyon\\HastaneOtomasyon\\icons\\phone-call.png"),
                    SizeMode = PictureBoxSizeMode.StretchImage,
                    Width = 21,
                    Height = 21,
                    Location = new Point(lblTelefon.Left + 15, lblTelefon.Bottom + 17)
                };
                TextBox tbxTel = new TextBox
                {
                    Size = new Size(200, 20),
                    BorderStyle = BorderStyle.FixedSingle,
                    BackColor = Color.White,
                    Text = telNo,
                    Font = new Font("Arial", 10, FontStyle.Italic),
                    Location = new Point(tel.Right + 5, lblTelefon.Bottom + 17)
                };
                tbxTel.Click += (sender, args) =>
                {
                    tbxTel.BorderStyle = BorderStyle.Fixed3D;
                    tbxTel.Font = new Font("Arial", 10, FontStyle.Bold);
                };

                Button btnTelefonOnayla = new Button
                {
                    Text = "Onayla",
                    AutoSize = true,
                    Height = 40,
                    Width = 100,
                    BackColor = Color.LightCoral,
                    Font = new Font("Arial", 11, FontStyle.Bold),
                    Cursor = Cursors.Hand,
                    Location = new Point(180, tbxTel.Bottom + 20),
                    Margin = new Padding(0, 0, 0, 15)
                };
                btnTelefonOnayla.Click += (sender, args) =>
                {
                    string newTelNo = tbxTel.Text.Trim();
                    if (string.IsNullOrEmpty(newTelNo))
                    {
                        MessageBox.Show("Geçerli bir e-posta adresi giriniz.");
                        return;
                    }

                    UpdateTelInDatabase(newTelNo);
                };


                btnGeriDon.Click += (sender, args) =>
                {
                    flowLayoutPaneIletisimBilgileri.Controls.Clear();
                    DisplayEpostaBilgileri();
                    DisplayTelefonBilgileri();
                };

                pnlTelefonGuncelle.Controls.Add(lblTelefon);
                pnlTelefonGuncelle.Controls.Add(btnGeriDon);
                pnlTelefonGuncelle.Controls.Add(tel);
                pnlTelefonGuncelle.Controls.Add(tbxTel);
                pnlTelefonGuncelle.Controls.Add(btnTelefonOnayla);

                flowLayoutPaneIletisimBilgileri.Controls.Add(pnlTelefonGuncelle);
            };
        }

        private void UpdateEmailInDatabase(string newEmail)
        {

            using (OracleConnection connection = new OracleConnection(SessionManager.Instance.ConnectionString))
            {
                connection.Open();
                string query = "UPDATE personel SET personelEPOSTA = :Eposta WHERE personelid = :personelid";
                using (OracleCommand command = new OracleCommand(query, connection))
                {
                    command.Parameters.Add(new OracleParameter("Eposta", newEmail));
                    command.Parameters.Add(new OracleParameter("personel", SessionManager.Instance.UserId));

                    int rowsAffected = command.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("E-posta başarıyla güncellendi.");
                        SessionManager.Instance.UserEposta = newEmail;
                    }
                    else
                    {
                        MessageBox.Show("E-posta güncellenirken bir sorun oluştu.");
                    }
                }
                flowLayoutPaneIletisimBilgileri.Controls.Clear();
                DisplayEpostaBilgileri();
                DisplayTelefonBilgileri();

            }
        }
        private void UpdateTelInDatabase(string newTelNo)
        {

            using (OracleConnection connection = new OracleConnection(SessionManager.Instance.ConnectionString))
            {
                connection.Open();
                string query = "UPDATE personel SET personeltelno = :TELNO WHERE personelid = :personelid";
                using (OracleCommand command = new OracleCommand(query, connection))
                {
                    command.Parameters.Add(new OracleParameter("TELNO", newTelNo));
                    command.Parameters.Add(new OracleParameter("personelid", SessionManager.Instance.UserId));

                    int rowsAffected = command.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Telefon Numarası başarıyla güncellendi.");
                        SessionManager.Instance.UserTelNo = newTelNo;
                    }
                    else
                    {
                        MessageBox.Show("Telefon Numarası güncellenirken bir sorun oluştu.");
                    }
                }
                flowLayoutPaneIletisimBilgileri.Controls.Clear();
                DisplayEpostaBilgileri();
                DisplayTelefonBilgileri();

            }
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
