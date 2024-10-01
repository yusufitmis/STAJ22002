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
    public partial class GecmisRandevularım : Form
    {
        Doctor doktor = new Doctor();
        public int hastaID = SessionManager.Instance.UserId;
        private Point fixedLocation = new Point(300, 100);
        public GecmisRandevularım()
        {
            InitializeComponent();
        }


        private void GecmisRandevularım_Load(object sender, EventArgs e)
        {
            grbBoxHastaHomeProfil.Visible = false;
            this.LocationChanged += GecmisRandevularım_LocationChanged;
            LoadGecmisRandevular();


        }

        private void btnHastaHomeProfil_Click(object sender, EventArgs e)
        {
            grbBoxHastaHomeProfil.Visible = !grbBoxHastaHomeProfil.Visible;

        }

        private void gunaButton1_Click(object sender, EventArgs e)
        {
            Application.Exit();

        }

        private void LoadGecmisRandevular()
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
            AND RANDEVU_TARIHI < SYSDATE
            ORDER BY RANDEVU_TARIHI DESC"; // Randevuları tarihine göre sıralama

                    using (OracleCommand cmd = new OracleCommand(query, conn))
                    {
                        cmd.Parameters.Add(new OracleParameter("hastaID", hastaID));

                        OracleDataAdapter da = new OracleDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);

                     
                        // Her randevuyu panelde listeleme
                        flowLayoutPanelGecmisRandevularım.Controls.Clear(); // Eski verileri temizleme
                        foreach (DataRow row in dt.Rows)
                        {
                            DateTime randevuTarihi = Convert.ToDateTime(row["RANDEVU_TARIHI"]);
                            Panel randevuPanel = new Panel();
                            randevuPanel.Size = new System.Drawing.Size(600, 80);
                            randevuPanel.BackColor = System.Drawing.Color.DarkGray;
                            randevuPanel.BorderStyle = BorderStyle.FixedSingle;
                            randevuPanel.Margin = new Padding(20, 3, 3, 3);

                            PictureBox pictureBoxTarih = CreatePictureBox("calendar.png", new Point(10, 10));
                            Label lblTarih = new Label();
                            lblTarih.Text = randevuTarihi.ToString("dd.MM.yyyy");
                            lblTarih.Location = new System.Drawing.Point(pictureBoxTarih.Left + 20, 10);
                            lblTarih.Font = new Font("Arial", 12, FontStyle.Bold);
                            lblTarih.ForeColor = System.Drawing.Color.White;

                            PictureBox pictureBoxSaat = CreatePictureBox("clock.png", new Point(lblTarih.Left + 120, 10));
                            Label lblSaat = new Label();
                            lblSaat.Text = "Saat: " + row["RANDEVU_SAATI"].ToString();
                            lblSaat.Location = new System.Drawing.Point(pictureBoxSaat.Left + 20, 10);
                            lblSaat.Font = new Font("Arial", 12, FontStyle.Bold);
                            lblSaat.ForeColor = System.Drawing.Color.White;


                            var docbilgileri = Doctor.GetDoctor(Convert.ToInt32(row["DOKTOR_ID"]));
                            var cinsiyet = docbilgileri.Gender?.Trim();
                            string doctorImage = cinsiyet == "K" ? "woman.png" : "man.png";

                            PictureBox pictureBoxDoktor = CreatePictureBox(doctorImage, new Point(lblSaat.Left + 120, 10));
                            Label lblDoktor = new Label();
                            lblDoktor.Text = $"Dr.{docbilgileri.Name} {docbilgileri.Surname}";
                            lblDoktor.Location = new System.Drawing.Point(pictureBoxDoktor.Left + 20, 10);
                            lblDoktor.Font = new Font("Arial", 12, FontStyle.Bold);
                            lblDoktor.ForeColor = System.Drawing.Color.White;


                            PictureBox pictureBoxPol = CreatePictureBox("drugs.png", new Point(lblDoktor.Left + 120, 10));
                            Label lblPoliklinik = new Label();
                            lblPoliklinik.Text = Polyclinic.GetPolyclinicNameById(Convert.ToInt32(row["POLIKLINIK_ID"])) + " Polikliniği";
                            lblPoliklinik.Location = new System.Drawing.Point(pictureBoxPol.Left + 20, 10);
                            lblPoliklinik.Font = new Font("Arial", 12, FontStyle.Bold);
                            lblPoliklinik.ForeColor = System.Drawing.Color.White;


                            randevuPanel.Controls.Add(pictureBoxTarih);
                            randevuPanel.Controls.Add(pictureBoxSaat);
                            randevuPanel.Controls.Add(pictureBoxDoktor);
                            randevuPanel.Controls.Add(pictureBoxPol);
                            randevuPanel.Controls.Add(lblTarih);
                            randevuPanel.Controls.Add(lblSaat);
                            randevuPanel.Controls.Add(lblDoktor);
                            randevuPanel.Controls.Add(lblPoliklinik);

                            flowLayoutPanelGecmisRandevularım.Controls.Add(randevuPanel);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Bir hata oluştu: " + ex.Message);
                }
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

     

        private void btnrandevuAl_Click(object sender, EventArgs e)
        {
            hastaHome hastaHome = new hastaHome();
            hastaHome.Show();
            this.Close();
        }

        private void gunaButton6_Click(object sender, EventArgs e)
        {
            GecmisRandevularım gecmisRandevularım = new GecmisRandevularım();
            gecmisRandevularım.Show();
            this.Close();
        }

        private void btnRandevularım_Click(object sender, EventArgs e)
        {
            
            Randevularım rand = new Randevularım();
            rand.Show();
            this.Close();
        }

        private void GecmisRandevularım_LocationChanged(object sender, EventArgs e)
        {
            this.Location = fixedLocation;

        }

        private void grbBoxHastaHomeProfil_Click(object sender, EventArgs e)
        {

        }

        private void btnKimlikBilgiler_Click(object sender, EventArgs e)
        {
            KimlikBilgileri kimlikBilgileri = new KimlikBilgileri();
            kimlikBilgileri.Show();
            this.Close();
        }

        private void btnCıkısYap_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Çıkmak istediğinize emin misiniz?", "Çıkış", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);


            if (dialogResult == DialogResult.Yes)
            {
                Application.Exit();
            }

            else if (dialogResult == DialogResult.No)
            {

            }
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

      

       
    }
}
