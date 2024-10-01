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
    public partial class Tahlil : Form
    {
        Doctor doktor = new Doctor();
        private string tcKimlikNo;
        private HastaBilgileri hastaBilgileri;
        private MuayeneBilgileri muayeneBilgileri;
        private Point fixedLocation = new Point(100, 50);
        public Tahlil(HastaBilgileri hastaBilgileri, MuayeneBilgileri muayeneBilgileri, string tcKimlikNo)
        {
            InitializeComponent();
            this.hastaBilgileri = hastaBilgileri;
            this.muayeneBilgileri = muayeneBilgileri;
            this.tcKimlikNo = tcKimlikNo;
        }
        public Tahlil()
        {
            InitializeComponent();
            
        }

        private void Tahlil_Load(object sender, EventArgs e)
        {
            this.LocationChanged += Tahlil_LocationChanged;
            grbBoxProfil.Visible = false;
            tbxTcNo.Text = tcKimlikNo;
            LoadHastaBilgileri();
            TahlilleriListele();
            TahlilMuayeneListele();


        }

       

        private void gunaButton1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Tahlil_LocationChanged(object sender, EventArgs e)
        {
            this.Location = fixedLocation;
        }

        private void btnHastaKabul_Click(object sender, EventArgs e)
        {
            DoktorModül.HastaKabul hastaKabul = new DoktorModül.HastaKabul();
            hastaKabul.Show();
            this.Close();
        }

        private void btnDefter_Click(object sender, EventArgs e)
        {
            DoktorModül.Poliklinik.Defter defter = new DoktorModül.Poliklinik.Defter();
            defter.Show();
            this.Close();
        }

        private void btnRadyoloji_Click(object sender, EventArgs e)
        {
            string tcKimlikNo = tbxTcNo.Text;
            if (!string.IsNullOrEmpty(tcKimlikNo))
            {
                DoktorModül.Poliklinik.Radyoloji radyoloji = new DoktorModül.Poliklinik.Radyoloji(hastaBilgileri, muayeneBilgileri, tcKimlikNo);
                radyoloji.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("TC kimlik numarası bulunamadı.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
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
        public void TahlilleriListele()
        {
            using (OracleConnection conn = new OracleConnection(SessionManager.Instance.ConnectionString))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT TAHLILID as Kodu, TAHLILTURU as İşlem_Türü , TAHLILDETAY as Detay FROM TAHLIL";
                    OracleDataAdapter adapter = new OracleDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    dgwTahliller.DataSource = dt;  
                    dgwTahliller.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;  
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Veri çekilirken bir hata oluştu: " + ex.Message);
                }
            }
        }

        private void dgwTahliller_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgwTahliller.Rows[e.RowIndex];
                string tahlilId = row.Cells["Kodu"].Value.ToString();
                string tahlilTur = row.Cells["İşlem_Türü"].Value.ToString();

                TahliliMuayeneIleIliskilendir(tahlilId);
            }
        }
        private void TahliliMuayeneIleIliskilendir(string tahlilId)
        {
            using (OracleConnection conn = new OracleConnection(SessionManager.Instance.ConnectionString))
            {
                try
                {
                    conn.Open();

                    string query = "INSERT INTO TAHLILMUAYENE (TAHLILID, MUAYENEID,  DOKTORID, DURUM, SONUC, HASTANO, TAHLILTARIH) " +
                                   "VALUES (:tahlilId, :muayeneId, :doktorId, 'Beklemede', '-', :hastaNo, SYSDATE)";

                    using (OracleCommand cmd = new OracleCommand(query, conn))
                    {
                        cmd.Parameters.Add(":tahlilId", tahlilId);
                        cmd.Parameters.Add(":muayeneId", muayeneBilgileri.ProtokolNo); 
                        cmd.Parameters.Add(":doktorId", SessionManager.Instance.UserId);
                        cmd.Parameters.Add(":hastaNo", hastaBilgileri.HastaNo);

                        int result = cmd.ExecuteNonQuery();
                        if (result > 0)
                        {
                            MessageBox.Show("Tahlil başarıyla muayene ile ilişkilendirildi.");
                            TahlilMuayeneListele();
                        }
                        else
                        {
                            MessageBox.Show("Tahlil ilişkilendirme başarısız oldu.");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Bir hata oluştu: " + ex.Message);
                }
            }
        }
        private void TahlilMuayeneListele()
        {
            using (OracleConnection conn = new OracleConnection(SessionManager.Instance.ConnectionString))
            {
                try
                {
                    conn.Open();

                    string query = @"SELECT 
                                T.TAHLILID AS Kodu,
                                TA.TAHLILTURU AS TÜRÜ,
                                T.MUAYENEID AS Protokol_no, 
                                P.personelad || ' ' ||p.personelsoyad AS Doktor, 
                                T.DURUM, 
                                T.SONUC,
                                T.HASTANO AS Hasta_No, 
                                T.TAHLILTARIH AS Tahlil_Tarihi
                            FROM 
                                TAHLILMUAYENE T
                            INNER JOIN 
                                PERSONEL P ON T.DOKTORID = P.PERSONELID
                            INNER JOIN
                                TAHLIL TA ON T.TAHLILID = TA.TAHLILID
                            WHERE 
                                T.MUAYENEID = :muayeneId
                            ORDER BY 
                                T.TAHLILTARIH DESC";

                    using (OracleDataAdapter adapter = new OracleDataAdapter(query, conn))
                    {
                        adapter.SelectCommand.Parameters.Add(":muayeneId", muayeneBilgileri.ProtokolNo);

                        DataTable dt = new DataTable();
                        adapter.Fill(dt);

                        dgwTahMuayene.DataSource = dt;
                        dgwTahMuayene.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Tahliller listelenirken bir hata oluştu: " + ex.Message);
                }
            }
        }

        private void dgwTahMuayene_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgwTahMuayene.Rows[e.RowIndex];
                string tahlilId = row.Cells["Kodu"].Value.ToString();

                DialogResult result = MessageBox.Show("Bu tahlili silmek istediğinizden emin misiniz?", "Silme Onayı", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    // Tahlili sil
                    TahlilSil(tahlilId);
                }
            }
        }
        private void TahlilSil(string tahlilId)
        {
            using (OracleConnection conn = new OracleConnection(SessionManager.Instance.ConnectionString))
            {
                try
                {
                    conn.Open();

                    string query = "DELETE FROM TAHLILMUAYENE WHERE TAHLILID = :tahlilId";

                    using (OracleCommand cmd = new OracleCommand(query, conn))
                    {
                        cmd.Parameters.Add(":tahlilId", tahlilId);

                        int result = cmd.ExecuteNonQuery();
                        if (result > 0)
                        {
                            MessageBox.Show("Tahlil başarıyla silindi.");
                            TahlilMuayeneListele();
                        }
                        else
                        {
                            MessageBox.Show("Tahlil silme işlemi başarısız oldu.");
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
