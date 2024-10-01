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
    public partial class Defter : Form
    {
        
        Doctor doktor = new Doctor();
        private Point fixedLocation = new Point(100, 50);

        public Defter()
        {
            InitializeComponent();
        }

        private void gunaButton1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Defter_Load(object sender, EventArgs e)
        {
            this.LocationChanged += Defter_LocationChanged;
            grbBoxProfil.Visible = false;
        }

        private void Defter_LocationChanged(object sender, EventArgs e)
        {
            this.Location = fixedLocation;
        }

        private void btnTahlil_Click(object sender, EventArgs e)
        {
        
            string tcKimlikNo = tbxTcNo.Text; 
            if (!string.IsNullOrEmpty(tcKimlikNo))
            {
                DoktorModül.Poliklinik.Tahlil tahlil = new DoktorModül.Poliklinik.Tahlil(hastaBilgileri, muayeneBilgileri,tcKimlikNo);
                tahlil.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("TC kimlik numarası bulunamadı.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnHastaKabul_Click(object sender, EventArgs e)
        {
            DoktorModül.HastaKabul hastaKabul = new DoktorModül.HastaKabul();
            hastaKabul.Show();
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

        private HastaBilgileri hastaBilgileri;
        private MuayeneBilgileri muayeneBilgileri;

        private void txtBoxHastaKayitTcno_Leave(object sender, EventArgs e)
        {
            string tcNo = tbxTcNo.Text;
            tbxProtokolNo.Text = string.Empty;
            tbxSıraNo.Text = string.Empty;


            if (string.IsNullOrEmpty(tcNo))
            {
                MessageBox.Show("Lütfen bir TC kimlik numarası giriniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (OracleConnection con = new OracleConnection(SessionManager.Instance.ConnectionString))
            {
                con.Open();

                string queryHasta = "SELECT hastano, hastalad, hastasoyad, kangrubu, hastadtarihi, hastacinsiyet, sosyalguvence FROM Hasta WHERE hastatcno = :tcNo";

                using (OracleCommand cmdHasta = new OracleCommand(queryHasta, con))
                {
                    cmdHasta.Parameters.Add(new OracleParameter("tcNo", tcNo));

                    OracleDataReader reader = cmdHasta.ExecuteReader();

                    if (reader.Read())
                    {
                        hastaBilgileri = new HastaBilgileri
                        {
                            HastaNo = reader["hastano"].ToString(),
                            Ad = reader["hastalad"].ToString(),
                            Soyad = reader["hastasoyad"].ToString(),
                            KanGrubu = reader["kangrubu"].ToString(),
                            DogumTarihi = Convert.ToDateTime(reader["hastadtarihi"]),
                            Cinsiyet = reader["hastacinsiyet"].ToString(),
                            SosyalGuvence = reader["sosyalguvence"].ToString()
                        };

                        tbxHastaNo.Text = hastaBilgileri.HastaNo;
                        tbxAd.Text = hastaBilgileri.Ad;
                        tbxSoyad.Text = hastaBilgileri.Soyad;
                        tbxKanGrubu.Text = hastaBilgileri.KanGrubu;
                        dtpDogumTarihi.Value = hastaBilgileri.DogumTarihi;
                        tbxCinsiyet.Text = hastaBilgileri.Cinsiyet;
                        tbxSosyalGüvence.Text = hastaBilgileri.SosyalGuvence;
                        LoadMuayeneBilgileriByHastaneNo(Convert.ToInt32(hastaBilgileri.HastaNo));

                    }
                    else
                    {
                        MessageBox.Show("Hasta kayıtlı değil, lütfen hasta kabul işleminizi gerçekleştirin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    reader.Close();
                }

                string queryMuayene = "SELECT muayeneid, sira_no FROM Muayene WHERE HastaNo = :hastaNo";

                using (OracleCommand cmdMuayene = new OracleCommand(queryMuayene, con))
                {
                    cmdMuayene.Parameters.Add(new OracleParameter("hastaNo", tbxHastaNo.Text));

                    OracleDataReader readerMuayene = cmdMuayene.ExecuteReader();

                    if (readerMuayene.Read())
                    {
                        muayeneBilgileri = new MuayeneBilgileri
                        {
                            ProtokolNo = readerMuayene["muayeneid"].ToString(),
                            SiraNo = readerMuayene["sira_no"].ToString()
                        };

                        tbxProtokolNo.Text = muayeneBilgileri.ProtokolNo;
                        tbxSıraNo.Text = muayeneBilgileri.SiraNo;
                        LoadEklenenTanilar(Convert.ToInt32(muayeneBilgileri.ProtokolNo));

                    }
                    else
                    {
                        MessageBox.Show("Sevk işlemleri için hasta kabul işleminizi gerçekleştirin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }

                    readerMuayene.Close();
                }

                con.Close();
            }
        }
        private void LoadMuayeneBilgileriByHastaneNo(int hastaneNo)
        {
            using (OracleConnection con = new OracleConnection(SessionManager.Instance.ConnectionString))
            {
                con.Open();

                string queryMuayene = @"
            SELECT MUAYENEID, HASTANO, DOKTORID, KLINIKID, SIKAYET, MUAYENETARIHI, MUAYENETESHIS, MUAYENESONUC, 
                   MUAYENE_CIKIS_TARIHI, KABUL_SEKLI, GELDIGI_BIRIM, CIKIS_DURUMU, CIKIS_SEKLI, 
                   VAKA_SEKLI,  SIRA_NO
            FROM MUAYENE 
            WHERE HASTANO = :hastaNo";

                using (OracleCommand cmdMuayene = new OracleCommand(queryMuayene, con))
                {
                    cmdMuayene.Parameters.Add(new OracleParameter("hastaNo", hastaneNo));

                    OracleDataReader readerMuayene = cmdMuayene.ExecuteReader();

                    if (readerMuayene.Read())
                    {
                        cbxVakaSekli.SelectedItem = readerMuayene["VAKA_SEKLI"] != DBNull.Value ? readerMuayene["VAKA_SEKLI"].ToString() : null;
                        cbxKabulSekli.SelectedItem = readerMuayene["KABUL_SEKLI"] != DBNull.Value ? readerMuayene["KABUL_SEKLI"].ToString() : null;
                        cbxGeldigiBirim.SelectedItem = readerMuayene["GELDIGI_BIRIM"] != DBNull.Value ? readerMuayene["GELDIGI_BIRIM"].ToString() : null;
                        cbxCıkısSekli.SelectedItem = readerMuayene["CIKIS_SEKLI"] != DBNull.Value ? readerMuayene["CIKIS_SEKLI"].ToString() : null;
                        cbxxCıkısDurumu.SelectedItem = readerMuayene["CIKIS_DURUMU"] != DBNull.Value ? readerMuayene["CIKIS_DURUMU"].ToString() : null;
                        tbxSikayet.Text = readerMuayene["SIKAYET"] != DBNull.Value ? readerMuayene["SIKAYET"].ToString() : string.Empty;
                        tbxTeshis.Text = readerMuayene["MUAYENETESHIS"] != DBNull.Value ? readerMuayene["MUAYENETESHIS"].ToString() : string.Empty;
                        tbxSonuc.Text = readerMuayene["MUAYENESONUC"] != DBNull.Value ? readerMuayene["MUAYENESONUC"].ToString() : string.Empty;





                        int klinikId = Convert.ToInt32(readerMuayene["KLINIKID"]);
                        int doktorId = Convert.ToInt32(readerMuayene["DOKTORID"]);

                        
                        dtpMuayeneGirisTarihi.Value = readerMuayene["MUAYENETARIHI"] != DBNull.Value ? Convert.ToDateTime(readerMuayene["MUAYENETARIHI"]) : DateTime.Now;
                        dtpMuayeneCıkısTarihi.Value = readerMuayene["MUAYENE_CIKIS_TARIHI"] != DBNull.Value ? Convert.ToDateTime(readerMuayene["MUAYENE_CIKIS_TARIHI"]) : DateTime.Now;

                       
                        LoadKlinikler();
                        string klinikAdi = Polyclinic.GetPolyclinicNameById(klinikId);
                        cbxGeldigiBirim.SelectedItem =klinikAdi;

                        LoadDoktorlar(klinikId);
                        string doktorAdi = doktor.GetDoctorNameById(doktorId);
                        cbxHekim.SelectedItem = doktorAdi.ToString();
                    }
                    else
                    {
                        MessageBox.Show("Muayene kaydı bulunamadı.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }

                    readerMuayene.Close();
                }

                con.Close();
            }
        }
        private void btnKAydetMuayeneBilgileri_Click(object sender, EventArgs e)
        {
            try
            {
                using (OracleConnection con = new OracleConnection(SessionManager.Instance.ConnectionString))
                {
                    con.Open();

                    string updateQuery = @"
                UPDATE MUAYENE 
                SET VAKA_SEKLI = :vakaSekli,
                    KABUL_SEKLI = :kabulSekli,
                    GELDIGI_BIRIM = :geldigiBirim,
                    CIKIS_SEKLI = :cikisSekli,
                    CIKIS_DURUMU = :cikisDurumu,
                    MUAYENETARIHI = :muayeneTarihi,
                    MUAYENE_CIKIS_TARIHI = :muayeneCikisTarihi,
                    SIKAYET = :sikayet, 
                    MUAYENETESHIS = :teshis, 
                    MUAYENESONUC = :sonuc
                WHERE MUAYENEID = :muayeneId";

                    using (OracleCommand cmdUpdate = new OracleCommand(updateQuery, con))
                    {
                        cmdUpdate.Parameters.Add(new OracleParameter("vakaSekli", cbxVakaSekli.SelectedItem != null ? (object)cbxVakaSekli.SelectedItem.ToString() : DBNull.Value));
                        cmdUpdate.Parameters.Add(new OracleParameter("kabulSekli", cbxKabulSekli.SelectedItem != null ? (object)cbxKabulSekli.SelectedItem.ToString() : DBNull.Value));
                        cmdUpdate.Parameters.Add(new OracleParameter("geldigiBirim", cbxGeldigiBirim.SelectedItem != null ? (object)cbxGeldigiBirim.SelectedItem.ToString() : DBNull.Value));
                        cmdUpdate.Parameters.Add(new OracleParameter("cikisSekli", cbxCıkısSekli.SelectedItem != null ? (object)cbxCıkısSekli.SelectedItem.ToString() : DBNull.Value));
                        cmdUpdate.Parameters.Add(new OracleParameter("cikisDurumu", cbxxCıkısDurumu.SelectedItem != null ? (object)cbxxCıkısDurumu.SelectedItem.ToString() : DBNull.Value));
                        cmdUpdate.Parameters.Add(new OracleParameter("muayeneTarihi", dtpMuayeneGirisTarihi.Value));
                        cmdUpdate.Parameters.Add(new OracleParameter("muayeneCikisTarihi", dtpMuayeneCıkısTarihi.Value));
                        cmdUpdate.Parameters.Add(new OracleParameter("sikayet", !string.IsNullOrEmpty(tbxSikayet.Text) ? (object)tbxSikayet.Text : DBNull.Value));
                        cmdUpdate.Parameters.Add(new OracleParameter("teshis", !string.IsNullOrEmpty(tbxTeshis.Text) ? (object)tbxTeshis.Text : DBNull.Value));
                        cmdUpdate.Parameters.Add(new OracleParameter("sonuc", !string.IsNullOrEmpty(tbxSonuc.Text) ? (object)tbxSonuc.Text : DBNull.Value));
                        cmdUpdate.Parameters.Add(new OracleParameter("muayeneId", muayeneBilgileri.ProtokolNo));

                        cmdUpdate.ExecuteNonQuery();
                    }

                    con.Close();
                }

                MessageBox.Show("Kayıt başarıyla güncellendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Bir hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadKlinikler()
        {
            using (OracleConnection con = new OracleConnection(SessionManager.Instance.ConnectionString))
            {
                con.Open();

                string queryKlinik = "SELECT KLINIKID, KLINIKAD FROM KLINIK";

                using (OracleCommand cmdKlinik = new OracleCommand(queryKlinik, con))
                {
                    OracleDataReader readerKlinik = cmdKlinik.ExecuteReader();

                    cbxGeldigiBirim.Items.Clear();
                    while (readerKlinik.Read())
                    {
                        string klinikAdi = readerKlinik["KLINIKAD"].ToString();

                        cbxGeldigiBirim.Items.Add( klinikAdi);
                    }

                    readerKlinik.Close();
                }

                con.Close();
            }
        }
        private void LoadDoktorlar(int klinikId)
        {
            using (OracleConnection con = new OracleConnection(SessionManager.Instance.ConnectionString))
            {
                con.Open();

                string queryDoktor = "SELECT personelid, personelad || ' ' ||personelsoyad as hekim FROM personel WHERE KLINIKID = :klinikId";

                using (OracleCommand cmdDoktor = new OracleCommand(queryDoktor, con))
                {
                    cmdDoktor.Parameters.Add(new OracleParameter("klinikId", klinikId));

                    OracleDataReader readerDoktor = cmdDoktor.ExecuteReader();

                    cbxHekim.Items.Clear();
                    while (readerDoktor.Read())
                    {
                        string doktorAdi = readerDoktor["hekim"].ToString();
                        cbxHekim.Items.Add(doktorAdi);
                    }

                    readerDoktor.Close();
                }

                con.Close();
            }
        }
        private void cbxGeldigiBirim_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxGeldigiBirim.SelectedItem != null)
            {
                var selectedItem = cbxGeldigiBirim.SelectedItem.ToString();
                int klinikId = Convert.ToInt32(Polyclinic.GetPolyclinicIdByName(selectedItem));

                LoadDoktorlar(klinikId);
            }
        }

        private void btnTanıEkle_Click(object sender, EventArgs e)
        {
            string protokolNo = tbxProtokolNo.Text.ToString();
            TanıEkle tanıEkle = new TanıEkle(protokolNo);
            tanıEkle.Show();
            LoadEklenenTanilar(Convert.ToInt32(protokolNo));

        }
        public void LoadEklenenTanilar(int muayeneId)
        {
            using (OracleConnection con = new OracleConnection(SessionManager.Instance.ConnectionString))
            {
                con.Open();

                string query = @"
            SELECT TANI_ID, TANI_ACIKLAMASI, TANI_TURU 
            FROM MUAYENETANI 
            WHERE MUAYENE_ID = :muayeneId";

                using (OracleCommand cmd = new OracleCommand(query, con))
                {
                    cmd.Parameters.Add(new OracleParameter("muayeneId", Convert.ToInt32(muayeneId)));

                    OracleDataAdapter adapter = new OracleDataAdapter(cmd);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    dgwEklenenTanılar.DataSource = dataTable;
                }
            }
        }

        private void dgwEklenenTanılar_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) 
            {
              
                var selectedRow = dgwEklenenTanılar.Rows[e.RowIndex];
                int taniId = Convert.ToInt32(selectedRow.Cells["TANI_ID"].Value);

                
                DialogResult dialogResult = MessageBox.Show("Tanıyı silmek istediğinizden emin misiniz?",
                                                            "Tanı Silme",
                                                            MessageBoxButtons.YesNo,
                                                            MessageBoxIcon.Warning);

                if (dialogResult == DialogResult.Yes)
                {
                    
                    SilTanı(taniId);
                }
            }

        }
        private void SilTanı(int taniId)
        {
            using (OracleConnection con = new OracleConnection(SessionManager.Instance.ConnectionString))
            {
                con.Open();

                string deleteQuery = "DELETE FROM MUAYENETANI WHERE TANI_ID = :taniId";

                using (OracleCommand cmd = new OracleCommand(deleteQuery, con))
                {
                    cmd.Parameters.Add(new OracleParameter("taniId", taniId));

                    cmd.ExecuteNonQuery();
                }
            }


            MessageBox.Show("Tanı başarıyla silindi.");
        }

    }
}
