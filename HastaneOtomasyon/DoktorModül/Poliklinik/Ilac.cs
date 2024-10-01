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
using static HastaneOtomasyon.DataAccess.Defter;

namespace HastaneOtomasyon.DoktorModül.Poliklinik
{
    public partial class Ilac : Form
    {
        private string tcKimlikNo;
        private HastaBilgileri hastaBilgileri;
        private MuayeneBilgileri muayeneBilgileri;
        private Point fixedLocation = new Point(100, 50);
        public Ilac(HastaBilgileri hastaBilgileri, MuayeneBilgileri muayeneBilgileri, string tcKimlikNo)
        {
            InitializeComponent();
            this.hastaBilgileri = hastaBilgileri;
            this.muayeneBilgileri = muayeneBilgileri;
            this.tcKimlikNo = tcKimlikNo;
        }
        public Ilac()
        {
            InitializeComponent();
        }

        private void Ilac_Load(object sender, EventArgs e)
        {
            this.LocationChanged += Ilac_LocationChanged;
            grbBoxProfil.Visible = false;

            tbxTcNo.Text = tcKimlikNo;
            LoadHastaBilgileri();
            ReceteleriListele();
            ListeleIlacAdlari();

        }
        private void LoadHastaBilgileri()
        {
            if (hastaBilgileri != null)
            {
                tbxHastaNo.Text = hastaBilgileri.HastaNo;
                tbxAd.Text = hastaBilgileri.Ad;
                tbxSoyad.Text = hastaBilgileri.Soyad;
                tbxKanGrubu.Text = hastaBilgileri.KanGrubu;
                dtpDogumTarihi.Value = hastaBilgileri.DogumTarihi;
                cbxSosyalGuvence.SelectedItem = hastaBilgileri.SosyalGuvence;
                cbxCinsiyet.SelectedItem = hastaBilgileri.Cinsiyet;
            }

            if (muayeneBilgileri != null)
            {
                tbxProtokolNo.Text = muayeneBilgileri.ProtokolNo;
                tbxSıraNo.Text = muayeneBilgileri.SiraNo;
            }
        }

        private void Ilac_LocationChanged(object sender, EventArgs e)
        {
            this.Location = fixedLocation;
        }

        private void btnRadyoloji_Click(object sender, EventArgs e)
        {
            DoktorModül.Poliklinik.Radyoloji radyoloji = new DoktorModül.Poliklinik.Radyoloji();
            radyoloji.Show();
            this.Close();
        }

        private void btnDefter_Click(object sender, EventArgs e)
        {
            DoktorModül.Poliklinik.Defter defter = new DoktorModül.Poliklinik.Defter();
            defter.Show();
            this.Close();
        }

        private void btnTahlil_Click(object sender, EventArgs e)
        {
            DoktorModül.Poliklinik.Tahlil tahlil = new DoktorModül.Poliklinik.Tahlil();
            tahlil.Show();
            this.Close();
        }

        private void gunaButton1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }



        private void btnHastaKabul_Click(object sender, EventArgs e)
        {
            DoktorModül.HastaKabul hastaKabul = new DoktorModül.HastaKabul();
            hastaKabul.Show();
            this.Close();
        }

        private void btnHastaGecmis_Click(object sender, EventArgs e)
        {
            string tcKimlikNo = tbxTcNo.Text;
            if (!string.IsNullOrEmpty(tcKimlikNo))
            {
                DoktorModül.Poliklinik.HastaGecmis hastaGecmis = new DoktorModül.Poliklinik.HastaGecmis(hastaBilgileri, muayeneBilgileri, tcKimlikNo);
                hastaGecmis.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("TC kimlik numarası bulunamadı.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnHastaHomeProfil_Click(object sender, EventArgs e)
        {
            grbBoxProfil.Visible = !grbBoxProfil.Visible;
        }

        private void btnKimlikBilgiler_Click(object sender, EventArgs e)
        {
            DoktorModül.Profil.KisiselBilgiler kisiselBilgiler = new DoktorModül.Profil.KisiselBilgiler();
            kisiselBilgiler.Show();
            this.Close();
        }

        private void btnİletişimBilgileri_Click(object sender, EventArgs e)
        {
            DoktorModül.Profil.IletisimBilgileri ıletisimBilgileri = new DoktorModül.Profil.IletisimBilgileri();
            ıletisimBilgileri.Show();
            this.Close();
        }

        private void btnParolaİşlemleri_Click(object sender, EventArgs e)
        {
            DoktorModül.Profil.ParolaIslemleri parolaIslemleri = new DoktorModül.Profil.ParolaIslemleri();
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

        private Panel pnlRecete;

        private void btnReceteEkle_Click(object sender, EventArgs e)
        {

            if (pnlRecete != null)
            {
                pnlRecete.Show();
                pnlRecete.BringToFront();
                return;
            }

            pnlRecete = new Panel();
            pnlRecete.Size = new Size(400, 180);
            pnlRecete.Location = new Point(gbxHastaBilgileri.Left, gbxHastaBilgileri.Bottom);
            pnlRecete.BorderStyle = BorderStyle.FixedSingle;

            pnlRecete.BackColor = Color.White;

            Label lblReceteTuru = new Label();
            lblReceteTuru.Text = "Reçete Türü:";
            lblReceteTuru.Location = new Point(20, 20);
            lblReceteTuru.Font = new Font("Arial", 10, FontStyle.Regular);

            pnlRecete.Controls.Add(lblReceteTuru);

            ComboBox cbxReceteTuru = new ComboBox();
            cbxReceteTuru.Items.AddRange(new string[] { "Normal", "Kırmızı", "Yeşil", "Mor", "Turuncu" });
            cbxReceteTuru.Location = new Point(150, 20);
            cbxReceteTuru.Font = new Font("Arial", 10, FontStyle.Regular);

            pnlRecete.Controls.Add(cbxReceteTuru);

            Label lblReceteTarihi = new Label();
            lblReceteTarihi.Text = "Reçete Tarihi:";
            lblReceteTarihi.Location = new Point(20, 60);
            lblReceteTarihi.Font = new Font("Arial", 10, FontStyle.Regular);
            pnlRecete.Controls.Add(lblReceteTarihi);

            DateTimePicker dtpReceteTarihi = new DateTimePicker();
            dtpReceteTarihi.Format = DateTimePickerFormat.Short;
            dtpReceteTarihi.Location = new Point(150, 60);
            pnlRecete.Controls.Add(dtpReceteTarihi);


            Button btnEkle = new Button();
            btnEkle.Text = "Ekle";
            btnEkle.Location = new Point(100, 120);
            btnEkle.BackColor = Color.CadetBlue;
            btnEkle.ForeColor = Color.White;
            btnEkle.Font = new Font("Arial", 10, FontStyle.Regular);

            btnEkle.Click += (s, ev) =>
            {
                string receteTuru = cbxReceteTuru.SelectedItem.ToString();
                DateTime receteTarihi = dtpReceteTarihi.Value;
                int hekim = SessionManager.Instance.UserId;
                int muayeneId = Convert.ToInt32(muayeneBilgileri.ProtokolNo);

                using (OracleConnection conn = new OracleConnection(SessionManager.Instance.ConnectionString))
                {
                    conn.Open();
                    OracleCommand cmd = new OracleCommand("INSERT INTO Recete (RECETETIPI, RECETETARIHI, doktorid, MUAYENEID) VALUES (:receteTuru, :receteTarihi, :hekim, :muayeneId)", conn);
                    cmd.Parameters.Add(":receteTuru", receteTuru);
                    cmd.Parameters.Add(":receteTarihi", receteTarihi);
                    cmd.Parameters.Add(":hekim", hekim);
                    cmd.Parameters.Add(":muayeneId", muayeneId);

                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("Reçete başarıyla eklendi!");
                ReceteleriListele();
            };
            pnlRecete.Controls.Add(btnEkle);


            Button btnKapat = new Button();
            btnKapat.Text = "Kapat";
            btnKapat.Location = new Point(200, 120);
            btnKapat.BackColor = Color.CadetBlue;
            btnKapat.ForeColor = Color.White;
            btnKapat.Font = new Font("Arial", 10, FontStyle.Regular);

            btnKapat.Click += (s, ev) =>
            {
                pnlRecete.Hide();
            };
            pnlRecete.Controls.Add(btnKapat);


            this.Controls.Add(pnlRecete);
            pnlRecete.BringToFront();
        }
        private void ReceteleriListele()
        {
            using (OracleConnection conn = new OracleConnection(SessionManager.Instance.ConnectionString))
            {
                conn.Open();
                OracleCommand cmd = new OracleCommand("SELECT r.receteid as Recete_ID, r.RECETETIPI as Recete_Tipi, r.RECETETARIHI Reçete_Tarihi, p.personelad || ' ' || personelsoyad as Hekim_Adı FROM Recete r inner join personel p on r.doktorid = p.personelid", conn);
                OracleDataReader reader = cmd.ExecuteReader();

                DataTable dt = new DataTable();
                dt.Load(reader);

                dgwReceteler.DataSource = dt;

                reader.Close();
            }
        }
        private void ListeleIlacAdlari()
        {

            using (OracleConnection conn = new OracleConnection(SessionManager.Instance.ConnectionString))
            {
                try
                {
                    conn.Open();


                    string query = "SELECT ILACAD FROM ILAC order by ilacad";


                    OracleCommand cmd = new OracleCommand(query, conn);
                    OracleDataReader reader = cmd.ExecuteReader();

                    lbxİlacAd.Items.Clear();

                    while (reader.Read())
                    {
                        lbxİlacAd.Items.Add(reader["ILACAD"].ToString());
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Veri yüklenirken bir hata oluştu: " + ex.Message);
                }
            }
        }

        private void btnReceteİlac_Click(object sender, EventArgs e)
        {
            string ilacAd = lbxİlacAd.SelectedItem?.ToString();
            string ilacKullanimi = lbxİlacKullanımı.SelectedItem?.ToString();
            int periyod = Convert.ToInt32(lbxPeriyod.SelectedItem ?? "0");
            string periyodBirimi = lbxPeriyodBirimi.SelectedItem?.ToString();
            int periyodAdet = Convert.ToInt32(lbxPeriyodAdet.SelectedItem ?? "0");
            int periyodDoz = Convert.ToInt32(lbxPeriyodDoz.SelectedItem ?? "0");

            int receteId = GetSelectedReceteId();
            int ilacId = GetIlacId(ilacAd);

            if (IlacZatenEklendi(receteId, ilacId))
            {
                MessageBox.Show("Bu ilaç zaten reçeteye eklenmiş.");
                return;
            }

            using (OracleConnection conn = new OracleConnection(SessionManager.Instance.ConnectionString))
            {
                try
                {
                    conn.Open();
                    OracleCommand cmd = new OracleCommand("INSERT INTO ReceteIlac (RECETEID, ILACID, ILACAD, ILACKULLANIMI, PERIYOD, PERIYODBIRIMI, PERIYODADET, PERIYODDOZ) VALUES (:receteId, :ilacId, :ilacAd, :ilacKullanimi, :periyod, :periyodBirimi, :periyodAdet, :periyodDoz)", conn);

                    cmd.Parameters.Add(":receteId", receteId);
                    cmd.Parameters.Add(":ilacId", ilacId);
                    cmd.Parameters.Add(":ilacAd", ilacAd);
                    cmd.Parameters.Add(":ilacKullanimi", ilacKullanimi);
                    cmd.Parameters.Add(":periyod", periyod);
                    cmd.Parameters.Add(":periyodBirimi", periyodBirimi);
                    cmd.Parameters.Add(":periyodAdet", periyodAdet);
                    cmd.Parameters.Add(":periyodDoz", periyodDoz);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("İlaç reçeteye başarıyla eklendi!");
                    ListeleReceteIlac(receteId);
                    lbxİlacAd.ClearSelected();
                    lbxİlacKullanımı.ClearSelected();
                    lbxPeriyod.ClearSelected();
                    lbxPeriyodBirimi.ClearSelected();
                    lbxPeriyodAdet.ClearSelected();
                    lbxPeriyodDoz.ClearSelected();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Veri eklenirken bir hata oluştu: " + ex.Message);
                }
            }
        }

        private bool IlacZatenEklendi(int receteId, int ilacId)
        {
            using (OracleConnection conn = new OracleConnection(SessionManager.Instance.ConnectionString))
            {
                try
                {
                    conn.Open();
                    OracleCommand cmd = new OracleCommand("SELECT COUNT(*) FROM ReceteIlac WHERE RECETEID = :receteId AND ILACID = :ilacId", conn);
                    cmd.Parameters.Add(new OracleParameter(":receteId", receteId));
                    cmd.Parameters.Add(new OracleParameter(":ilacId", ilacId));

                    int count = Convert.ToInt32(cmd.ExecuteScalar());

                    return count > 0;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("İlaç kontrol edilirken bir hata oluştu: " + ex.Message);
                    return false;
                }
            }
        }

        private int selectedReceteId = -1;
        private void dgwReceteler_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgwReceteler.Rows[e.RowIndex];
                selectedReceteId = Convert.ToInt32(row.Cells["Recete_ID"].Value);
                ListeleReceteIlac(selectedReceteId);

            }
        }
        private int GetSelectedReceteId()
        {
            return selectedReceteId;
        }
        private int GetIlacId(string ilacAd)
        {
            int ilacId = -1;

            using (OracleConnection conn = new OracleConnection(SessionManager.Instance.ConnectionString))
            {
                try
                {
                    conn.Open();


                    string query = "SELECT ILACID FROM ILAC WHERE ILACAD = :ilacAd";

                    using (OracleCommand cmd = new OracleCommand(query, conn))
                    {
                        cmd.Parameters.Add(new OracleParameter(":ilacAd", ilacAd));


                        object result = cmd.ExecuteScalar();
                        if (result != null && int.TryParse(result.ToString(), out ilacId))
                        {

                        }
                        else
                        {

                            ilacId = -1;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Veri yüklenirken bir hata oluştu: " + ex.Message);
                }
            }

            return ilacId;
        }
        private void ListeleReceteIlac(int receteId)
        {
            using (OracleConnection conn = new OracleConnection(SessionManager.Instance.ConnectionString))
            {
                try
                {
                    conn.Open();
                    OracleCommand cmd = new OracleCommand("SELECT ILACAD, ILACKULLANIMI as Kullanım, PERIYOD, PERIYODBIRIMI as Per_Birim, PERIYODADET as Adet, PERIYODDOZ as Doz FROM ReceteIlac WHERE RECETEID = :receteId", conn);
                    cmd.Parameters.Add(new OracleParameter(":receteId", receteId));

                    OracleDataAdapter adapter = new OracleDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    dgwHastaRecete.DataSource = dt;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Veri yüklenirken bir hata oluştu: " + ex.Message);
                }
            }
        }

        private void dgwHastaRecete_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dgwHastaRecete.Rows.Count)
            {
                DataGridViewRow selectedRow = dgwHastaRecete.Rows[e.RowIndex];
                string ilacAd = selectedRow.Cells["ILACAD"].Value.ToString();

                DialogResult result = MessageBox.Show($"{ilacAd} adlı ilacı silmek istediğinize emin misiniz?", "Silme Onayı", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    int receteId = GetSelectedReceteId();
                    SilReceteIlac(receteId, ilacAd);

                    ListeleReceteIlac(receteId);
                }
            }

        }
        private void SilReceteIlac(int receteId, string ilacAd)
        {
            using (OracleConnection conn = new OracleConnection(SessionManager.Instance.ConnectionString))
            {
                try
                {
                    conn.Open();
                    OracleCommand cmd = new OracleCommand("DELETE FROM ReceteIlac WHERE RECETEID = :receteId AND ILACAD = :ilacAd", conn);
                    cmd.Parameters.Add(new OracleParameter(":receteId", receteId));
                    cmd.Parameters.Add(new OracleParameter(":ilacAd", ilacAd));

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("İlaç reçeteden başarıyla silindi!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Silme işlemi sırasında bir hata oluştu: " + ex.Message);
                }
            }
        }

        private void dgwReceteler_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                int receteId = Convert.ToInt32(dgwReceteler.Rows[e.RowIndex].Cells["Recete_ID"].Value);

                DialogResult result = MessageBox.Show("Seçilen reçeteyi silmek istediğinizden emin misiniz?", "Onay", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    SilRecete(receteId);
                }
            }
        }
        private void SilRecete(int receteId)
        {
            using (OracleConnection conn = new OracleConnection(SessionManager.Instance.ConnectionString))
            {
                try
                {
                    conn.Open();
                    OracleCommand cmd = new OracleCommand("DELETE FROM Recete WHERE RECETEID = :receteId", conn);
                    cmd.Parameters.Add(new OracleParameter(":receteId", receteId));
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Reçete başarıyla silindi!");

                    ReceteleriListele();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Reçete silinirken bir hata oluştu: " + ex.Message);
                }
            }
        }
    }
}
