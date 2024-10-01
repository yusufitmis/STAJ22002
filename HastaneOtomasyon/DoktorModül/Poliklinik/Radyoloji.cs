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
    public partial class Radyoloji : Form
    {
        private string tcKimlikNo;
        private HastaBilgileri hastaBilgileri;
        private MuayeneBilgileri muayeneBilgileri;
        private Point fixedLocation = new Point(100, 50);
        public Radyoloji(HastaBilgileri hastaBilgileri, MuayeneBilgileri muayeneBilgileri, string tcKimlikNo)
        {
            InitializeComponent();
            this.hastaBilgileri = hastaBilgileri;
            this.muayeneBilgileri = muayeneBilgileri;
            this.tcKimlikNo = tcKimlikNo;
        }
        public Radyoloji()
        {
            InitializeComponent();

        }

        private void gunaButton1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

      

        private void Radyoloji_Load(object sender, EventArgs e)
        {
            this.LocationChanged += Radyoloji_LocationChanged;
            grbBoxProfil.Visible = false;
            tbxTcNo.Text = tcKimlikNo;
            LoadHastaBilgileri();
            ListeleGoruntuleme();
            GoruntulemeMuayeneListele();

        }

        private void Radyoloji_LocationChanged(object sender, EventArgs e)
        {
            this.Location = fixedLocation;
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

        private void btnHastaKabul_Click(object sender, EventArgs e)
        {
            DoktorModül.HastaKabul hastaKabul = new DoktorModül.HastaKabul();
            hastaKabul.Show();
            this.Close();
        }

        private void btnTahlil_Click(object sender, EventArgs e)
        {
            DoktorModül.Poliklinik.Tahlil tahlil = new DoktorModül.Poliklinik.Tahlil();
            tahlil.Show();
            this.Close();
        }

        private void btnDefter_Click(object sender, EventArgs e)
        {
            DoktorModül.Poliklinik.Defter defter = new DoktorModül.Poliklinik.Defter();
            defter.Show();
            this.Close();
        }

        private void btnIlac_Click(object sender, EventArgs e)
        {
            string tcKimlikNo = tbxTcNo.Text;
            if (!string.IsNullOrEmpty(tcKimlikNo))
            {
                DoktorModül.Poliklinik.Ilac ilac = new DoktorModül.Poliklinik.Ilac(hastaBilgileri, muayeneBilgileri, tcKimlikNo);
                ilac.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("TC kimlik numarası bulunamadı.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
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
        private void ListeleGoruntuleme()
        {
            using (OracleConnection conn = new OracleConnection(SessionManager.Instance.ConnectionString))
            {
                try
                {
                    conn.Open();

                    string query = "SELECT GORUNTULEMEID as Kodu, GORUNTULEMETURU as Türü FROM GORUNTULEME";

                    using (OracleDataAdapter adapter = new OracleDataAdapter(query, conn))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);

                        dgwGoruntuleme.DataSource = dt;
                        dgwGoruntuleme.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Veriler listelenirken bir hata oluştu: " + ex.Message);
                }
            }
        }

        private void dgwGoruntuleme_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) 
            {
                DataGridViewRow row = dgwGoruntuleme.Rows[e.RowIndex];
                int goruntulemeId = Convert.ToInt32(row.Cells["Kodu"].Value);
                GoruntulemeMuayeneEkle(goruntulemeId);
            }
        }
        private void GoruntulemeMuayeneEkle(int goruntulemeId)
        {
            using (OracleConnection conn = new OracleConnection(SessionManager.Instance.ConnectionString))
            {
                try
                {
                    conn.Open();


                    string klinikQuery = "SELECT KLINIKID FROM PERSONEL WHERE PERSONELID = :doktorId";

                    int klinikId;
                    using (OracleCommand klinikCmd = new OracleCommand(klinikQuery, conn))
                    {
                        klinikCmd.Parameters.Add(":doktorId", SessionManager.Instance.UserId);
                        object result = klinikCmd.ExecuteScalar();

                        if (result != null)
                        {
                            klinikId = Convert.ToInt32(result);
                        }
                        else
                        {
                            MessageBox.Show("Klinik ID alınamadı.");
                            return;
                        }
                    }

                    string query = "INSERT INTO GORUNTULEMEMUAYENE (GORUNTULEMEID, MUAYENEID, HASTANO, KLINIKID, DOKTORID, GORUNTULEMETARIHI, SONUC) " +
                                   "VALUES (:goruntulemeId, :muayeneId, :hastaNo, :klinikId, :doktorId, SYSDATE, '-')";

                    using (OracleCommand cmd = new OracleCommand(query, conn))
                    {
                        cmd.Parameters.Add(":goruntulemeId", goruntulemeId);
                        cmd.Parameters.Add(":muayeneId", muayeneBilgileri.ProtokolNo);
                        cmd.Parameters.Add(":hastaNo", hastaBilgileri.HastaNo);
                        cmd.Parameters.Add(":klinikId", klinikId);
                        cmd.Parameters.Add(":doktorId", SessionManager.Instance.UserId);

                        int result = cmd.ExecuteNonQuery();
                        if (result > 0)
                        {
                            MessageBox.Show("Görüntüleme başarıyla muayene ile ilişkilendirildi.");
                            GoruntulemeMuayeneListele();
                        }
                        else
                        {
                            MessageBox.Show("Görüntüleme ilişkilendirme başarısız oldu.");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Bir hata oluştu: " + ex.Message);
                }
            }
        }
        private void GoruntulemeMuayeneListele()
        {
            using (OracleConnection conn = new OracleConnection(SessionManager.Instance.ConnectionString))
            {
                try
                {
                    conn.Open();

                    string query = @"SELECT 
                                G.GORUNTULEMEID AS Kodu,
                                GR.GORUNTULEMETURU AS TÜRÜ,
                                G.MUAYENEID AS Protokol_no, 
                                K.KLINIKAD AS Birim,           
                                P.personelad || ' ' ||p.personelsoyad AS Doktor, 
                                G.HASTANO AS Hasta_No, 
                                G.SONUC,
                                G.GORUNTULEMETARIHI AS Görüntüleme_Tarihi
                            FROM 
                                GORUNTULEMEMUAYENE G
                            INNER JOIN 
                                PERSONEL P ON G.DOKTORID = P.PERSONELID
                            INNER JOIN
                                GORUNTULEME GR ON G.GORUNTULEMEID = GR.GORUNTULEMEID
                            INNER JOIN 
                                KLINIK K ON G.KLINIKID = K.KLINIKID
                            WHERE 
                                G.MUAYENEID = :muayeneId
                            ORDER BY 
                                G. GORUNTULEMETARIHI DESC";

                    using (OracleDataAdapter adapter = new OracleDataAdapter(query, conn))
                    {
                        adapter.SelectCommand.Parameters.Add(":muayeneId", muayeneBilgileri.ProtokolNo);

                        DataTable dt = new DataTable();
                        adapter.Fill(dt);

                        dgwGoruntulemeMuayene.DataSource = dt;
                        dgwGoruntulemeMuayene.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Görüntüleme muayeneleri listelenirken bir hata oluştu: " + ex.Message);
                }
            }
        }

        private void dgwGoruntulemeMuayene_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgwGoruntulemeMuayene.Rows[e.RowIndex];
                string goruntulemeid = row.Cells["Kodu"].Value.ToString();

                DialogResult result = MessageBox.Show("Bu tahlili silmek istediğinizden emin misiniz?", "Silme Onayı", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    GoruntulemeSil(goruntulemeid);
                }
            }
        }
        private void GoruntulemeSil(string goruntulemeid)
        {
            using (OracleConnection conn = new OracleConnection(SessionManager.Instance.ConnectionString))
            {
                try
                {
                    conn.Open();

                    string query = "DELETE FROM GORUNTULEMEMUAYENE WHERE GORUNTULEMEID = :goruntulemeid";

                    using (OracleCommand cmd = new OracleCommand(query, conn))
                    {
                        cmd.Parameters.Add(":goruntulemeid", goruntulemeid);

                        int result = cmd.ExecuteNonQuery();
                        if (result > 0)
                        {
                            MessageBox.Show("Goruntuleme başarıyla silindi.");
                            GoruntulemeMuayeneListele();
                        }
                        else
                        {
                            MessageBox.Show("Goruntuleme silme işlemi başarısız oldu.");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Bir hata oluştu: " + ex.Message);
                }
            }
        }
    }
}
