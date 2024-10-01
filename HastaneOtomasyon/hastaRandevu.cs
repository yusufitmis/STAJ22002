using HastaneOtomasyon.DataAccess;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace HastaneOtomasyon
{

    public partial class hastaRandevu : Form
    {
        
        Doctor doktor = new Doctor();

        private int selectedPolyclinicId;
        private Form hastaHomeForm;
        public string selectedDoctor;
        private Point fixedLocation = new Point(300, 100);


        public hastaRandevu(int selectedPolyclinicId, hastaHome hastaHomeForm)
        {
            InitializeComponent();
            this.selectedPolyclinicId = selectedPolyclinicId;
            this.hastaHomeForm = hastaHomeForm;

        }
        public hastaRandevu()
        {
            InitializeComponent();
            this.LocationChanged += hastaRandevu_LocationChanged;
        }

        private void hastaRandevu_Load(object sender, EventArgs e)
        {
            grbBoxHastaHomeProfil.Visible = false;
            DisplayDoctorsAsCards();
        }
        
        private void DisplayDoctorsAsCards()
        {
            flowLayoutPanelDoktor.Controls.Clear();
            var doctors = Polyclinic.GetDoctorsFromDatabase(selectedPolyclinicId);
            string polyclinicName = Polyclinic.GetPolyclinicNameById(selectedPolyclinicId);

            foreach (var doctor in doctors)
            {
                var doctorId = doktor.GetDoctorIdByName(doctor);
                var docbilgileri = Doctor.GetDoctor(doctorId);

                var cinsiyet = docbilgileri.Gender?.Trim();
                string doctorImage = cinsiyet == "K" ? "woman.png" : "man.png";

                Panel panelDoktor = new Panel
                {
                    Width = flowLayoutPanelDoktor.Width - 25,
                    Height = 150,
                    BorderStyle = BorderStyle.FixedSingle,
                    BackColor = System.Drawing.Color.White,
                    Cursor = Cursors.Hand
                };
                panelDoktor.MouseEnter += (s, e) => panelDoktor.BackColor = System.Drawing.Color.LightBlue;
                panelDoktor.MouseLeave += (s, e) => panelDoktor.BackColor = System.Drawing.Color.White;
                panelDoktor.Click += (s, e) =>
                {
                    if (selectedDoctor == doctor)
                    {
                        foreach (Panel otherPanel in flowLayoutPanelDoktor.Controls)
                        {
                            otherPanel.Visible = true;
                        }
                        selectedDoctor = null;
                    }
                    else
                    {
                        selectedDoctor = doctor;
                        foreach (Panel otherPanel in flowLayoutPanelDoktor.Controls)
                        {
                            if (otherPanel != panelDoktor)
                            {
                                otherPanel.Visible = false;
                            }
                        }
                        DisplayAppointmentTimes();
                    }
                };

                PictureBox pictureBoxDoktor = CreatePictureBox(doctorImage, new Point(10, 10));
                PictureBox pictureBoxHospital = CreatePictureBox("hospital1.png", new Point(pictureBoxDoktor.Left, pictureBoxDoktor.Bottom + 5));
                PictureBox pictureBoxPol = CreatePictureBox("drugs.png", new Point(pictureBoxHospital.Left, pictureBoxHospital.Bottom + 5));

                Label lblDoktorName = CreateLabel($"Dr.{docbilgileri.Name} {docbilgileri.Surname}", new Point(pictureBoxDoktor.Right + 10, 10), 12, FontStyle.Bold);
                Label lblHospitalName = CreateLabel("DünyaMed Hastanesi", new Point(lblDoktorName.Left, lblDoktorName.Bottom + 5), 10, FontStyle.Italic);
                Label lblPolName = CreateLabel(polyclinicName, new Point(lblHospitalName.Left, lblHospitalName.Bottom + 5), 10, FontStyle.Italic);

                panelDoktor.Controls.AddRange(new Control[]
                {
            pictureBoxDoktor,
            pictureBoxHospital,
            pictureBoxPol,
            lblDoktorName,
            lblHospitalName,
            lblPolName
                }
                );

                flowLayoutPanelDoktor.Controls.Add(panelDoktor);
            }
        }

        private PictureBox CreatePictureBox(string imageName, Point location)
        {
            return new PictureBox
            {
                Image = Image.FromFile($"C:\\Users\\yusuf\\Desktop\\hastane otomasyon\\HastaneOtomasyon\\icons\\{imageName}"),
                SizeMode = PictureBoxSizeMode.StretchImage,
                Width = 20,
                Height = 20,
                Location = location
            };
        }

        private Label CreateLabel(string text, Point location, float fontSize, FontStyle fontStyle, Color? foreColor = null)
        {
            return new Label
            {
                Text = text,
                AutoSize = true,
                Font = new Font("Arial", fontSize, fontStyle),
                Location = location,
                ForeColor = foreColor ?? Color.Black
            };
        }

        private void DisplayAppointmentTimes()
        {
            string queryGünler = @"
SELECT TO_CHAR(RANDEVU_TARIHI, 'dd.MM.yyyy') AS RANDEVU_TARIHI
FROM (
    SELECT DISTINCT RANDEVU_TARIHI
    FROM RANDEVULAR
    WHERE TO_CHAR(RANDEVU_TARIHI, 'D') BETWEEN 1 AND 5
      AND RANDEVU_TARIHI >= SYSDATE
      AND DOKTOR_ID = :DoktorId
    ORDER BY RANDEVU_TARIHI
)
WHERE ROWNUM <= 5";

            string querySaatler = @"
SELECT RANDEVU_SAATI, DOLULUK_DURUMU 
FROM RANDEVULAR 
WHERE TO_CHAR(RANDEVU_TARIHI, 'dd.MM.yyyy') = :Gun 
AND DOKTOR_ID = :DoktorId 
ORDER BY RANDEVU_SAATI";

            try
            {
                using (OracleConnection conn = new OracleConnection(SessionManager.Instance.ConnectionString))
                {
                    conn.Open();

                    using (OracleCommand cmd = new OracleCommand(queryGünler, conn))
                    {
                        cmd.Parameters.Add(new OracleParameter("DoktorId", OracleDbType.Int32)).Value = doktor.GetDoctorIdByName(selectedDoctor);
                        OracleDataReader gunReader = cmd.ExecuteReader();
                        flowLayoutPanelRandevuSaat.Controls.Clear();

                        while (gunReader.Read())
                        {
                            string gun = gunReader["RANDEVU_TARIHI"].ToString();

                            Label gunLabel = new Label
                            {
                                Text = gun,
                                AutoSize = true,
                                Font = new Font("Arial", 12, FontStyle.Bold),
                                Margin = new Padding(3, 3, 3, 10)
                            };
                            flowLayoutPanelRandevuSaat.Controls.Add(gunLabel);

                            TableLayoutPanel tableLayoutPanel = new TableLayoutPanel
                            {
                                ColumnCount = 2,
                                AutoSize = true,
                                Margin = new Padding(10, 3, 10, 3),
                            };
                            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
                            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));

                            // Saatleri al
                            using (OracleCommand cmd1 = new OracleCommand(querySaatler, conn))
                            {
                                cmd1.Parameters.Add(new OracleParameter("Gun", gun));
                                cmd1.Parameters.Add(new OracleParameter("DoktorId", OracleDbType.Int32)).Value = doktor.GetDoctorIdByName(selectedDoctor);
                                OracleDataReader saatReader = cmd1.ExecuteReader();

                                while (saatReader.Read())
                                {
                                    string saat = saatReader["RANDEVU_SAATI"].ToString();
                                    string dolulukDurumu = saatReader["DOLULUK_DURUMU"].ToString();

                                    Label saatLabel = new Label
                                    {
                                        Text = saat,
                                        Width = 95,
                                        Height = 40,
                                        TextAlign = ContentAlignment.MiddleCenter,
                                        BackColor = Color.White,
                                        Font = new Font("Arial", 11, FontStyle.Regular),
                                        Margin = new Padding(10, 3, 10, 3),
                                        Cursor = Cursors.Hand,
                                        Enabled = dolulukDurumu != "1" // Doluluk durumu '1' ise buton devre dışı olacak
                                    };

                                    if (saatLabel.Enabled)
                                    {
                                        saatLabel.Click += (sender, args) =>
                                        {
                                            flowLayoutPanelRandevuSaat.Controls.Clear();
                                            ShowRandevuOnayPanel(saat, gun);
                                        };

                                        saatLabel.MouseEnter += (sender, args) =>
                                        {
                                            saatLabel.BackColor = Color.CadetBlue;
                                            saatLabel.ForeColor = Color.White;
                                        };

                                        saatLabel.MouseLeave += (sender, args) =>
                                        {
                                            saatLabel.BackColor = Color.White;
                                            saatLabel.ForeColor = Color.Black;
                                        };
                                    }
                                    else
                                    {
                                        saatLabel.BackColor = Color.Gray; // Doluluk durumu '1' olanlar gri renkte gösterilecek
                                        saatLabel.ForeColor = Color.DarkRed;
                                    }

                                    tableLayoutPanel.Controls.Add(saatLabel);
                                }
                            }
                            flowLayoutPanelRandevuSaat.Controls.Add(tableLayoutPanel);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Randevu günleri ve saatleri alınırken bir hata oluştu: " + ex.Message);
            }
        }


        private void ShowRandevuOnayPanel(string detailedTime,string gun)
        {
            string polyclinicName = Polyclinic.GetPolyclinicNameById(selectedPolyclinicId);
            Panel onayPanel = new Panel
            {
                Width = flowLayoutPanelRandevuSaat.Width - 25,
                Height = 280,
                BorderStyle = BorderStyle.FixedSingle,
                BackColor = Color.White,
                AutoScroll = true,
                Margin = new Padding(10, 0, 0, 0)
            };

            PictureBox RandevuOnayTarih = new PictureBox
            {
                Image = Image.FromFile("C:\\Users\\yusuf\\Desktop\\hastane otomasyon\\HastaneOtomasyon\\icons\\calendar1.png"),
                SizeMode = PictureBoxSizeMode.StretchImage,
                Width = 20,
                Height = 20,
                Location = new Point(30, 10)
            };
            PictureBox pictureBoxSaat = new PictureBox
            {
                Image = Image.FromFile("C:\\Users\\yusuf\\Desktop\\hastane otomasyon\\HastaneOtomasyon\\icons\\clock.png"),
                SizeMode = PictureBoxSizeMode.StretchImage,
                Width = 20,
                Height = 20,
                Location = new Point(RandevuOnayTarih.Left, RandevuOnayTarih.Bottom + 5)
            };
            PictureBox pictureBoxOnayHospital = new PictureBox
            {
                Image = Image.FromFile("C:\\Users\\yusuf\\Desktop\\hastane otomasyon\\HastaneOtomasyon\\icons\\hospital1.png"),
                SizeMode = PictureBoxSizeMode.StretchImage,
                Width = 20,
                Height = 20,
                Location = new Point(pictureBoxSaat.Left - 20, pictureBoxSaat.Bottom + 15)
            };

            PictureBox pictureBoxOnayPol = new PictureBox
            {
                Image = Image.FromFile("C:\\Users\\yusuf\\Desktop\\hastane otomasyon\\HastaneOtomasyon\\icons\\drugs.png"),
                SizeMode = PictureBoxSizeMode.StretchImage,
                Width = 20,
                Height = 20,
                Location = new Point(pictureBoxOnayHospital.Left, pictureBoxOnayHospital.Bottom + 8)
            };
            var doctorId = doktor.GetDoctorIdByName(selectedDoctor);
            var docbilgileri = Doctor.GetDoctor(doctorId);

            var cinsiyet = docbilgileri.Gender?.Trim();
            string doctorImage = cinsiyet == "K" ? "woman.png" : "man.png";
            PictureBox pictureBoxOnayDoktor = new PictureBox
            {
                Image = Image.FromFile($"C:\\Users\\yusuf\\Desktop\\hastane otomasyon\\HastaneOtomasyon\\icons\\{doctorImage}"),
                SizeMode = PictureBoxSizeMode.StretchImage,
                Width = 20,
                Height = 20,
                Location = new Point(pictureBoxOnayPol.Left, pictureBoxOnayPol.Bottom + 8)
            };
            Label lblOnayTarihYazı = new Label
            {
                Text = "Tarih",
                AutoSize = true,
                Font = new Font("Arial", 11, FontStyle.Bold),
                Location = new Point(RandevuOnayTarih.Right + 10, 10),
                ForeColor = Color.CadetBlue,
            };
            Label lblOnayTarih = new Label
            {
                Text = gun, // Güncel tarih
                AutoSize = true,
                Font = new Font("Arial", 11, FontStyle.Italic),
                Location = new Point(lblOnayTarihYazı.Right + 5, 10)
            };
            Label lblOnaySaatYazı = new Label
            {
                Text = "Saat",
                AutoSize = true,
                Font = new Font("Arial", 11, FontStyle.Bold),
                Location = new Point(lblOnayTarihYazı.Left, lblOnayTarihYazı.Bottom + 5),
                ForeColor = Color.CadetBlue,
            };
            Label lblOnaySaat = new Label
            {
                Text = detailedTime,
                AutoSize = true,
                Font = new Font("Arial", 11, FontStyle.Italic),
                Location = new Point(lblOnayTarih.Left, lblOnayTarih.Bottom + 5)
            };
            Label lblHospitalName = new Label
            {
                Text = "DünyaMed Hastanesi",
                AutoSize = true,
                Font = new Font("Arial", 10, FontStyle.Italic),
                Location = new Point(lblOnaySaatYazı.Left - 20, lblOnaySaatYazı.Bottom + 14)
            };
            Label lblOnayPolName = new Label
            {
                Text = polyclinicName.ToString() + " Polikliniği",
                AutoSize = true,
                Font = new Font("Arial", 10, FontStyle.Italic),
                Location = new Point(lblHospitalName.Left, lblHospitalName.Bottom + 5)
            };
            Label lblOnayDoktorName = new Label
            {
                Text = $"Dr.{docbilgileri.Name} {docbilgileri.Surname}",
                AutoSize = true,
                Font = new Font("Arial", 10, FontStyle.Italic),
                Location = new Point(lblOnayPolName.Left, lblOnayPolName.Bottom + 5)
            };
            Label lblOnayRandevuSahibiYazı = new Label
            {
                Text = "Randevu Sahibi",
                AutoSize = true,
                Font = new Font("Arial", 10, FontStyle.Italic),
                Location = new Point(lblOnayDoktorName.Left, lblOnayDoktorName.Bottom + 15),
                ForeColor = Color.CadetBlue
            };
            Label lblOnayRandevuSahibi = new Label
            {
                Text = SessionManager.Instance.UserFullName,
                AutoSize = true,
                Font = new Font("Arial", 10, FontStyle.Bold),
                Location = new Point(lblOnayRandevuSahibiYazı.Left, lblOnayRandevuSahibiYazı.Bottom + 5)
                
            };

            Button btnConfirm = new Button
            {
                Text = "Onayla",
                Width = 80,
                Height = 30,
                BackColor = Color.CadetBlue,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Location = new Point(onayPanel.Width - 100, onayPanel.Height - 60)
            };

            Button btnCancel = new Button
            {
                Text = "İptal",
                Width = 80,
                Height = 30,
                BackColor = Color.Red,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Location = new Point(onayPanel.Width - 200, onayPanel.Height - 60)
            };

            btnConfirm.Click += (s, e) =>
            {
                try
                {
                    int doktorId = doktor.GetDoctorIdByName(selectedDoctor);
                    char yeniDolulukDurumu = '1'; // 1 = dolu, 0 = boş
                    string selectedTime = detailedTime; // Saat formatı "HH:MM"
                    int selectedPatientId = SessionManager.Instance.UserId;
                    int selectedPolyclinicId = Polyclinic.GetPolyclinicIdByName(polyclinicName);

                    // Randevu tarihi DateTime olarak alınmalı
                    DateTime selectedDate;
                    if (!DateTime.TryParse(gun, out selectedDate))
                    {
                        MessageBox.Show("Randevu tarihi geçersiz.");
                        return;
                    }

                    // Tarih formatını "DD/MM/YYYY" olarak formatlayın
                    string formattedDate = selectedDate.ToString("dd/MM/yyyy");

                    using (OracleConnection conn = new OracleConnection(SessionManager.Instance.ConnectionString))
                    {
                        conn.Open();

                        // Randevu bilgilerini güncellemek için SQL sorgusu
                        string queryUpdate = @"
                        UPDATE RANDEVULAR 
                        SET DOLULUK_DURUMU = :YeniDolulukDurumu, HASTA_ID = :HastaId, POLIKLINIK_ID = :PoliklinikId 
                        WHERE DOKTOR_ID = :DoktorId 
                        AND RANDEVU_TARIHI = TO_DATE(:RandevuTarihi, 'DD-MM-YYYY') 
                        AND RANDEVU_SAATI = :RandevuSaati
                        AND DOLULUK_DURUMU= '0'";

                        using (OracleCommand command = new OracleCommand(queryUpdate, conn))
                        {
                            // Parametreleri ekleyin
                            command.Parameters.Add(":YeniDolulukDurumu", OracleDbType.Char).Value = yeniDolulukDurumu;
                            command.Parameters.Add(":HastaId", OracleDbType.Int32).Value = selectedPatientId;
                            command.Parameters.Add(":PoliklinikId", OracleDbType.Int32).Value = selectedPolyclinicId;
                            command.Parameters.Add(":DoktorId", OracleDbType.Int32).Value = doktorId;
                            command.Parameters.Add(":RandevuTarihi", OracleDbType.Varchar2).Value = formattedDate;
                            command.Parameters.Add(":RandevuSaati", OracleDbType.Varchar2).Value = selectedTime;


                            // Sorguyu çalıştır
                            int rowsAffected = command.ExecuteNonQuery();

                            if (rowsAffected == 0)
                            {
                                MessageBox.Show("Seçilen randevu bulunamadı veya doluluk durumu zaten güncel.");
                            }
                            else
                            {
                                MessageBox.Show("Randevunuz başarıyla onaylandı.");
                                DisplayAppointmentTimes(); // Randevuları güncelleyin
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Randevu kaydedilirken bir hata oluştu: " + ex.Message);
                }
            };

            btnCancel.Click += (s, e) =>
            {
                DisplayAppointmentTimes();
            };

            onayPanel.Controls.Add(RandevuOnayTarih);
            onayPanel.Controls.Add(pictureBoxSaat);
            onayPanel.Controls.Add(pictureBoxOnayHospital);
            onayPanel.Controls.Add(pictureBoxOnayPol);
            onayPanel.Controls.Add(pictureBoxOnayDoktor);
            onayPanel.Controls.Add(lblOnayTarihYazı);
            onayPanel.Controls.Add(lblOnayTarih);
            onayPanel.Controls.Add(lblOnaySaatYazı);
            onayPanel.Controls.Add(lblOnaySaat);
            onayPanel.Controls.Add(lblHospitalName);
            onayPanel.Controls.Add(lblOnayPolName);
            onayPanel.Controls.Add(lblOnayDoktorName);
            onayPanel.Controls.Add(lblOnayRandevuSahibiYazı);
            onayPanel.Controls.Add(lblOnayRandevuSahibi);
            onayPanel.Controls.Add(btnConfirm);
            onayPanel.Controls.Add(btnCancel);
            
            flowLayoutPanelRandevuSaat.Controls.Add(onayPanel);
        }
        private void gunaButton1_Click(object sender, EventArgs e)
        {
            Application.Exit();
            
        }
        private void btnHastaHomeProfil_Click(object sender, EventArgs e)
        {
            grbBoxHastaHomeProfil.Visible = !grbBoxHastaHomeProfil.Visible;
        }

        private void btnPoliklinikSec_Click(object sender, EventArgs e)
        {
            if (hastaHomeForm != null)
            {
                hastaHomeForm.Show();
                this.Close(); 
            }
        }
        private void hastaRandevu_LocationChanged(object sender, EventArgs e)
        {
            this.Location = fixedLocation;
        }

        private void btnGecmisRandevularım_Click(object sender, EventArgs e)
        {
            GecmisRandevularım gecmisRandevularım = new GecmisRandevularım();
            gecmisRandevularım.Show();
            this.Close();
        }

        private void btnRandevuAl_Click(object sender, EventArgs e)
        {
            hastaHome hastaHome = new hastaHome();
            hastaHome.Show();
            this.Close();
        }
        private void gunaButton5_Click(object sender, EventArgs e)
        {
            
            hastaHome hastaHome = new hastaHome();
            hastaHome.Show();
            this.Close();
        }
        
        private void btnKimlikBilgileri_Click(object sender, EventArgs e)
        {
            KimlikBilgileri kimlikBilgileri = new KimlikBilgileri();
            kimlikBilgileri.Show();
            this.Close();
        }
        private void btnİletisimBilgileri_Click(object sender, EventArgs e)
        {
            IletisimBilgileri ıletisimBilgileri = new IletisimBilgileri();
            ıletisimBilgileri.Show();
            this.Close();
        }
        private void btnParolaİslemleri_Click(object sender, EventArgs e)
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

