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

namespace HastaneOtomasyon
{
    public partial class Randevularım : Form
    {
        Doctor doktor = new Doctor();
        public int hastaID = SessionManager.Instance.UserId;
        private hastaHome hastaHomeForm = null;

        private Point fixedLocation = new Point(300, 100);

        public Randevularım()
        {
            InitializeComponent();
            this.LocationChanged += Randevularım_LocationChanged;
        }

        private void gunaButton1_Click(object sender, EventArgs e)
        {
            Application.Exit();

        }

        private void btnHastaHomeProfil_Click(object sender, EventArgs e)
        {
            grbBoxHastaHomeProfil.Visible = !grbBoxHastaHomeProfil.Visible;
        }

        private void Randevularım_Load(object sender, EventArgs e)
        {
            grbBoxHastaHomeProfil.Visible = false;
            LoadRandevular();

        }
        private void LoadRandevular()
        {
            using (OracleConnection conn = new OracleConnection(SessionManager.Instance.ConnectionString))
            {
                try
                {
                    conn.Open();
                    string query = @"
SELECT RANDEVU_ID, DOKTOR_ID, RANDEVU_SAATI, RANDEVU_TARIHI, POLIKLINIK_ID 
FROM RANDEVULAR 
WHERE HASTA_ID = :hastaID
AND RANDEVU_TARIHI > SYSDATE"; // Sadece gelecekteki randevular

                    using (OracleCommand cmd = new OracleCommand(query, conn))
                    {
                        cmd.Parameters.Add(new OracleParameter("hastaID", hastaID));

                        OracleDataAdapter da = new OracleDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);

                        // Her randevuyu panelde listeleme
                        foreach (DataRow row in dt.Rows)
                        {
                            DateTime randevuTarihi = Convert.ToDateTime(row["RANDEVU_TARIHI"]);
                            Panel randevuPanel = new Panel();
                            randevuPanel.Size = new System.Drawing.Size(600, 80);
                            randevuPanel.BackColor = System.Drawing.Color.White;
                            randevuPanel.BorderStyle = BorderStyle.FixedSingle;
                            randevuPanel.Margin = new Padding(20, 3, 3, 3);

                            // Olay işleyicilerini ekleyin
                            randevuPanel.MouseEnter += RandevuPanel_MouseEnter;
                            randevuPanel.MouseLeave += RandevuPanel_MouseLeave;

                            PictureBox pictureBoxTarih = CreatePictureBox("calendar.png", new Point(10, 10));
                            Label lblTarih = new Label();
                            lblTarih.Text = randevuTarihi.ToString("dd.MM.yyyy");
                            lblTarih.Location = new System.Drawing.Point(pictureBoxTarih.Left + 20, 10);
                            lblTarih.Font = new Font("Arial", 12, FontStyle.Bold);

                            PictureBox pictureBoxSaat = CreatePictureBox("clock.png", new Point(lblTarih.Left + 120, 10));
                            Label lblSaat = new Label();
                            lblSaat.Text = "Saat: " + row["RANDEVU_SAATI"].ToString();
                            lblSaat.Location = new System.Drawing.Point(pictureBoxSaat.Left + 20, 10);
                            lblSaat.Font = new Font("Arial", 12, FontStyle.Bold);

                            var docbilgileri = Doctor.GetDoctor(Convert.ToInt32(row["DOKTOR_ID"]));
                            var cinsiyet = docbilgileri.Gender?.Trim();
                            string doctorImage = cinsiyet == "K" ? "woman.png" : "man.png";

                            PictureBox pictureBoxDoktor = CreatePictureBox(doctorImage, new Point(lblSaat.Left + 120, 10));
                            Label lblDoktor = new Label();
                            lblDoktor.Text = $"Dr.{docbilgileri.Name} {docbilgileri.Surname}";
                            lblDoktor.Location = new System.Drawing.Point(pictureBoxDoktor.Left + 20, 10);
                            lblDoktor.Font = new Font("Arial", 12, FontStyle.Bold);

                            PictureBox pictureBoxPol = CreatePictureBox("drugs.png", new Point(lblDoktor.Left + 120, 10));
                            Label lblPoliklinik = new Label();
                            lblPoliklinik.Text = Polyclinic.GetPolyclinicNameById(Convert.ToInt32(row["POLIKLINIK_ID"])) + " Polikliniği";
                            lblPoliklinik.Location = new System.Drawing.Point(pictureBoxPol.Left + 20, 10);
                            lblPoliklinik.Font = new Font("Arial", 12, FontStyle.Bold);

                            // İptal butonunu ekleme
                            Button btnIptal = new Button();
                            btnIptal.Text = "İptal";
                            btnIptal.Tag = Convert.ToInt32(row["RANDEVU_ID"]); // Randevu ID'sini Tag özelliğine atıyoruz
                            btnIptal.Click += BtnIptal_Click;
                            btnIptal.MouseEnter += BtnIptal_MouseEnter; // Olay işleyicilerini ekleyin
                            btnIptal.MouseLeave += BtnIptal_MouseLeave; // Olay işleyicilerini ekleyin
                            btnIptal.Location = new Point(lblPoliklinik.Left, 40);
                            btnIptal.BackColor = Color.Red;
                            btnIptal.ForeColor = Color.White;
                            btnIptal.Cursor = Cursors.Hand;
                            btnIptal.Size = new Size(80,30);
                            btnIptal.Font = new Font("Arial", 12, FontStyle.Bold);
                            
                            


                            // Paneli oluşturup, flowLayoutPanelRandevularım içerisine ekleme
                            randevuPanel.Controls.Add(pictureBoxTarih);
                            randevuPanel.Controls.Add(pictureBoxSaat);
                            randevuPanel.Controls.Add(pictureBoxDoktor);
                            randevuPanel.Controls.Add(pictureBoxPol);
                            randevuPanel.Controls.Add(lblTarih);
                            randevuPanel.Controls.Add(lblSaat);
                            randevuPanel.Controls.Add(lblDoktor);
                            randevuPanel.Controls.Add(lblPoliklinik);
                            randevuPanel.Controls.Add(btnIptal); // İptal butonunu panelin içine ekliyoruz

                            flowLayoutPanelRandevularım.Controls.Add(randevuPanel);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Bir hata oluştu: " + ex.Message);
                }
            }
        }



        private void BtnIptal_Click(object sender, EventArgs e)
        {
            // Randevu ID'sini butonun Tag özelliğinden al
            Button btn = sender as Button;
            int randevuId = Convert.ToInt32(btn.Tag);

            var result = MessageBox.Show("Bu randevuyu iptal etmek istediğinize emin misiniz?", "Randevu İptal", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                using (OracleConnection conn = new OracleConnection(SessionManager.Instance.ConnectionString))
                {
                    try
                    {
                        conn.Open();
                        string query = @"
                    UPDATE RANDEVULAR 
                    SET DOLULUK_DURUMU = '0', HASTA_ID = NULL, POLIKLINIK_ID = NULL 
                    WHERE RANDEVU_ID = :randevuID";

                        using (OracleCommand cmd = new OracleCommand(query, conn))
                        {
                            cmd.Parameters.Add(new OracleParameter("randevuID", randevuId));
                            cmd.ExecuteNonQuery();
                        }

                        // Randevunun başarıyla iptal edildiğini bildiren bir mesaj
                        MessageBox.Show("Randevu başarıyla iptal edildi.");
                        flowLayoutPanelRandevularım.Controls.Clear();
                        LoadRandevular();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Bir hata oluştu: " + ex.Message);
                    }
                }
            }
        }
        private void BtnIptal_MouseEnter(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (btn != null)
            {
                btn.BackColor = Color.DarkRed; 
                btn.ForeColor = Color.LightGray;
            }
        }

        private void BtnIptal_MouseLeave(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (btn != null)
            {
                btn.BackColor = Color.Red; 
                btn.ForeColor = Color.White; 
            }
        }



        // Olay işleyicileri
        private void RandevuPanel_MouseEnter(object sender, EventArgs e)
        {
            Panel panel = sender as Panel;
            if (panel != null)
            {
                panel.BackColor = Color.LightBlue; 
                panel.Cursor = Cursors.Hand;
            }
        }
        

        private void RandevuPanel_MouseLeave(object sender, EventArgs e)
        {
            Panel panel = sender as Panel;
            if (panel != null)
            {
                panel.BackColor = Color.White; // Üzerinden çıkıldığında eski rengine döner
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


        private void gunaButton4_Click(object sender, EventArgs e)
        {
            if (hastaHomeForm != null && !hastaHomeForm.IsDisposed)
            {
                hastaHomeForm.Close();
            }

            // Yeni bir hastaRandevu formu oluştur ve göster
            hastaHomeForm = new hastaHome();
            hastaHomeForm.Show();
        }

        private void Randevularım_LocationChanged(object sender, EventArgs e)
        {
            this.Location = fixedLocation;
        }

        private void gunaButton6_Click(object sender, EventArgs e)
        {
            GecmisRandevularım gecmisRandevularım = new GecmisRandevularım();
            gecmisRandevularım.Show();
            this.Close();
        }

        private void btnRandevularım_Click(object sender, EventArgs e)
        {
            this.Hide();
            Randevularım randevularım = new Randevularım();
            randevularım.Show();
        }

      

        private void btnKimlikBilgilerim_Click(object sender, EventArgs e)
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
