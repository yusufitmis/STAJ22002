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

namespace HastaneOtomasyon.DoktorModül
{
    public partial class HastaKabul : Form
    {
        int seciliBirimi;
        int doktorId;
        int servisID;
        int odaID;
        int yatakID;
        private int hastaNo;
        Doctor doktor = new Doctor();
        private Point fixedLocation = new Point(100, 50);
        public HastaKabul()
        {
            InitializeComponent();
        }

        private void gunaButton1_Click(object sender, EventArgs e)
        {
           Application.Exit();
        }

        private void HastaKabul_Load(object sender, EventArgs e)
        {
            this.LocationChanged += HastaKabul_LocationChanged;
            grbBoxProfil.Visible = false;
            LoadSevkBirimiData();

        }

        private void HastaKabul_LocationChanged(object sender, EventArgs e)
        {
            this.Location = fixedLocation;
        }

        private void btnPoliklinik_Click(object sender, EventArgs e)
        {
            DoktorModül.Poliklinik.Defter defter = new DoktorModül.Poliklinik.Defter();
            defter.Show();
            this.Close();
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

        private void tbxTc_Leave(object sender, EventArgs e)
        {
            string tcKimlikNo = tbxTc.Text;

            using (OracleConnection connection = new OracleConnection(SessionManager.Instance.ConnectionString))
            {
                string query = "SELECT * FROM HASTA WHERE HASTATCNO = :tc";
                OracleCommand command = new OracleCommand(query, connection);
                command.Parameters.Add(new OracleParameter("tc", tcKimlikNo));

                connection.Open();
                OracleDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    tbxAd.Text = reader["HASTALAD"].ToString();
                    tbxSoyad.Text = reader["HASTASOYAD"].ToString();
                    tbxTel.Text = reader["HASTATELNO"].ToString();
                    tbxEposta.Text = reader["HASTAEPOSTA"].ToString();
                    tbxKan.Text = reader["KANGRUBU"].ToString();
                    cbxCinsiyet.SelectedItem = reader["HASTACINSIYET"].ToString();
                    cbxSosyalGuvence.SelectedItem = reader["SOSYALGUVENCE"].ToString();
                    dtpDogumTarihi.Value = Convert.ToDateTime(reader["HASTADTARIHI"]);
                    tbxAdres.Text = reader["HASTAADRES"].ToString();
                    lblhastano.Text = reader["HASTANO"].ToString();
                    hastaNo = Convert.ToInt32(reader["HASTANO"]);
                    SetSelectedSevkAndHekim(hastaNo);
                    tbxHastaNo.Text = lblhastano.Text;
                    LoadServis();
                }
                else
                {
                    MessageBox.Show("Bu TC Kimlik Numarasına ait bir hasta bulunamadı.");
                    ClearFormFields();  
                }
            }
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbxTc.Text) ||
                string.IsNullOrEmpty(tbxAd.Text) ||
                string.IsNullOrEmpty(tbxSoyad.Text) ||
                string.IsNullOrEmpty(tbxTel.Text) ||
                string.IsNullOrEmpty(tbxEposta.Text) ||
                string.IsNullOrEmpty(tbxKan.Text) ||
                cbxCinsiyet.SelectedIndex == -1 ||
                cbxSosyalGuvence.SelectedIndex == -1 ||
                dtpDogumTarihi.Value == DateTime.Now ||
                string.IsNullOrEmpty(tbxAdres.Text))
            {
                MessageBox.Show("Lütfen tüm alanları doldurunuz.", "Eksik Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string tcKimlikNo = tbxTc.Text;

            using (OracleConnection connection = new OracleConnection(SessionManager.Instance.ConnectionString))
            {
                connection.Open();

                string checkQuery = "SELECT COUNT(*) FROM HASTA WHERE HASTATCNO = :tc";
                OracleCommand checkCommand = new OracleCommand(checkQuery, connection);
                checkCommand.Parameters.Add(new OracleParameter("tc", tcKimlikNo));

                int count = Convert.ToInt32(checkCommand.ExecuteScalar());

                if (count > 0)
                {
                    string updateQuery = "UPDATE HASTA SET HASTALAD = :ad, HASTASOYAD = :soyad, HASTATELNO = :telefon, HASTAEPOSTA = :eposta, KANGRUBU = :kanGrubu, HASTACINSIYET = :cinsiyet, SOSYALGUVENCE = :sosyalGuvence, HASTADTARIHI = :dogumTarihi, HASTAADRES = :adres WHERE HASTATCNO = :tc";
                    OracleCommand updateCommand = new OracleCommand(updateQuery, connection);

                    updateCommand.Parameters.Add(new OracleParameter("ad", tbxAd.Text));
                    updateCommand.Parameters.Add(new OracleParameter("soyad", tbxSoyad.Text));
                    updateCommand.Parameters.Add(new OracleParameter("telefon", tbxTel.Text));
                    updateCommand.Parameters.Add(new OracleParameter("eposta", tbxEposta.Text));
                    updateCommand.Parameters.Add(new OracleParameter("kanGrubu", tbxKan.Text));
                    updateCommand.Parameters.Add(new OracleParameter("cinsiyet", cbxCinsiyet.SelectedItem.ToString()));
                    updateCommand.Parameters.Add(new OracleParameter("sosyalGuvence", cbxSosyalGuvence.SelectedItem.ToString()));
                    updateCommand.Parameters.Add(new OracleParameter("dogumTarihi", dtpDogumTarihi.Value));
                    updateCommand.Parameters.Add(new OracleParameter("adres", tbxAdres.Text));
                    updateCommand.Parameters.Add(new OracleParameter("tc", tcKimlikNo));

                    updateCommand.ExecuteNonQuery();
                    MessageBox.Show("Hasta bilgileri başarıyla güncellendi.");
                }
                else
                {

                    string insertQuery = "INSERT INTO HASTA (HASTATCNO, HASTALAD, HASTASOYAD, HASTATELNO, HASTAEPOSTA, KANGRUBU, HASTACINSIYET, SOSYALGUVENCE, HASTADTARIHI, HASTAADRES) VALUES (:tc, :ad, :soyad, :telefon, :eposta, :kanGrubu, :cinsiyet, :sosyalGuvence, :dogumTarihi, :adres)";
                    OracleCommand insertCommand = new OracleCommand(insertQuery, connection);

                    insertCommand.Parameters.Add(new OracleParameter("tc", tcKimlikNo));
                    insertCommand.Parameters.Add(new OracleParameter("ad", tbxAd.Text));
                    insertCommand.Parameters.Add(new OracleParameter("soyad", tbxSoyad.Text));
                    insertCommand.Parameters.Add(new OracleParameter("telefon", tbxTel.Text));
                    insertCommand.Parameters.Add(new OracleParameter("eposta", tbxEposta.Text));
                    insertCommand.Parameters.Add(new OracleParameter("kanGrubu", tbxKan.Text));
                    insertCommand.Parameters.Add(new OracleParameter("cinsiyet", cbxCinsiyet.SelectedItem.ToString()));
                    insertCommand.Parameters.Add(new OracleParameter("sosyalGuvence", cbxSosyalGuvence.SelectedItem.ToString()));
                    insertCommand.Parameters.Add(new OracleParameter("dogumTarihi", dtpDogumTarihi.Value));
                    insertCommand.Parameters.Add(new OracleParameter("adres", tbxAdres.Text));

                    insertCommand.ExecuteNonQuery();
                    MessageBox.Show("Hasta kaydı başarıyla eklendi.");
                }
            }
        }



        private void ClearFormFields()
        {
            tbxAd.Text = "";
            tbxSoyad.Text = "";
            tbxTel.Text = "";
            tbxEposta.Text = "";
            tbxKan.Text = "";
            cbxCinsiyet.SelectedIndex = -1;
            cbxSosyalGuvence.SelectedIndex = -1;
            dtpDogumTarihi.Value = DateTime.Now;
            tbxAdres.Text = "";

        }

        private void btnSevkSakla_Click(object sender, EventArgs e)
        {
            try
            {
                string klinikAdi = cbxSevk.SelectedItem.ToString();
                int klinikId = Convert.ToInt32(Polyclinic.GetPolyclinicIdByName(klinikAdi));

                string doktorFullName = cbxHekim.SelectedItem.ToString();
                int doktorId = doktor.GetDoctorIdByFullName(doktorFullName);

                int sıraNo = Convert.ToInt32(tbxSıraNo.Text);

                using (OracleConnection connection = new OracleConnection(SessionManager.Instance.ConnectionString))
                {
                    connection.Open();

                    
                    string checkQuery = @"
            SELECT COUNT(*)
            FROM MUAYENE
            WHERE HASTANO = :hastaNo 
              AND DOKTORID = :doktorId 
              AND KLINIKID = :klinikId 
              AND SIRA_NO = :siraNo";

                    OracleCommand checkCommand = new OracleCommand(checkQuery, connection);
                    checkCommand.Parameters.Add(new OracleParameter("hastaNo", hastaNo));
                    checkCommand.Parameters.Add(new OracleParameter("doktorId", doktorId));
                    checkCommand.Parameters.Add(new OracleParameter("klinikId", klinikId));
                    checkCommand.Parameters.Add(new OracleParameter("siraNo", sıraNo));

                    int recordCount = Convert.ToInt32(checkCommand.ExecuteScalar());

                    if (recordCount > 0)
                    {
                        
                        MessageBox.Show("Bu muayene kaydı zaten mevcut.");
                    }
                    else
                    {
                        
                        string insertQuery = @"
                INSERT INTO MUAYENE (HASTANO, DOKTORID, KLINIKID, SIRA_NO)
                VALUES (:hastaNo, :doktorId, :klinikId, :siraNo)";

                        OracleCommand insertCommand = new OracleCommand(insertQuery, connection);
                        insertCommand.Parameters.Add(new OracleParameter("hastaNo", hastaNo));
                        insertCommand.Parameters.Add(new OracleParameter("doktorId", doktorId));
                        insertCommand.Parameters.Add(new OracleParameter("klinikId", klinikId));
                        insertCommand.Parameters.Add(new OracleParameter("siraNo", sıraNo));

                        int rowsAffected = insertCommand.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Muayene bilgileri başarıyla kaydedildi.");
                            LoadMuayeneData();
                        }
                        else
                        {
                            MessageBox.Show("Muayene kaydedilemedi.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Bir hata oluştu: {ex.Message}");
            }
        }

        private void LoadMuayeneData()
        {
            try
            {
                using (OracleConnection connection = new OracleConnection(SessionManager.Instance.ConnectionString))
                {
                    connection.Open();

                    string query = @"
                SELECT 
                    k.KLINIKAD AS Birim,
                    k.klinikid as KODU,
                    p.PERSONELAD || ' ' || p.PERSONELSOYAD AS HEKIM, 
                    m.MUAYENEID AS PROTOKOL, 
                    m.SIRA_NO 
                FROM 
                    MUAYENE m
                JOIN 
                    KLINIK k ON m.KLINIKID = k.KLINIKID
                JOIN 
                    PERSONEL p ON m.DOKTORID = p.PERSONELID 
                WHERE 
                    m.HASTANO = :HASTANO
                ORDER BY M.SIRA_NO"; 

                    OracleCommand command = new OracleCommand(query, connection);

                    command.Parameters.Add(new OracleParameter("HASTANO", hastaNo));  


                    OracleDataReader reader = command.ExecuteReader();


                    DataTable dataTable = new DataTable();
                    dataTable.Load(reader);

                    dgwSevk.DataSource = dataTable;

                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Veri yükleme sırasında bir hata oluştu: {ex.Message}");
            }
        }


        private void LoadSevkBirimiData()
        {
            using (OracleConnection connection = new OracleConnection(SessionManager.Instance.ConnectionString))
            {
                connection.Open();

                string query = "SELECT klinikad FROM klinik"; 
                OracleCommand command = new OracleCommand(query, connection);

                OracleDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    cbxSevk.Items.Add(reader["klinikad"].ToString());
                }
            }
        }
       

        private void LoadDoktorlar(int klinikid)
        {
            try
            {
                cbxHekim.Items.Clear();

                using (OracleConnection connection = new OracleConnection(SessionManager.Instance.ConnectionString))
                {
                    connection.Open();

                    string query = "SELECT personelad, personelsoyad FROM personel WHERE klinikid = :klinikid";
                    OracleCommand command = new OracleCommand(query, connection);
                    command.Parameters.Add(new OracleParameter("klinikid", klinikid));

                    OracleDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        string ad = reader["personelad"].ToString();
                        string soyad = reader["personelsoyad"].ToString();
                        string hekimFullName = $"{ad} {soyad}";

                        cbxHekim.Items.Add(hekimFullName);
                    }

                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Veri yükleme sırasında bir hata oluştu: {ex.Message}");
            }
        }

        private void cbxSevk_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxSevk.SelectedItem != null)
            {
                seciliBirimi = Polyclinic.GetPolyclinicIdByName(cbxSevk.SelectedItem.ToString());
                LoadDoktorlar(seciliBirimi);
            }
        }
        private void SetSelectedSevkAndHekim(int hastaNo)
        {
            using (OracleConnection connection = new OracleConnection(SessionManager.Instance.ConnectionString))
            {
                connection.Open();

                string query = "SELECT r.poliklinik_id, p.personelad || ' ' || p.personelsoyad AS hekimAd " +
                               "FROM randevular r " +
                               "JOIN personel p ON r.doktor_id = p.personelid " +
                               "WHERE r.hasta_id = :hastaNo";
                OracleCommand command = new OracleCommand(query, connection);
                command.Parameters.Add(new OracleParameter("hastaNo", hastaNo));

                OracleDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    int klinikId = Convert.ToInt32(reader["poliklinik_id"]);
                    string hekimAd = reader["hekimAd"].ToString();

                    foreach (string klinik in cbxSevk.Items)
                    {
                        if (Polyclinic.GetPolyclinicIdByName(klinik) == klinikId)
                        {
                            cbxSevk.SelectedItem = klinik;
                            break;
                        }
                    }


                    foreach (string hekim in cbxHekim.Items)
                    {
                        if (hekim == hekimAd)
                        {
                            cbxHekim.SelectedItem = hekim;
                            break;
                        }
                    }
                }
                reader.Close();
            }
        }
        private void CalculateAndDisplayQueueNumbers(int doktorId, int poliklinikId)
        {
            using (OracleConnection connection = new OracleConnection(SessionManager.Instance.ConnectionString))
            {
                connection.Open();

                
                DateTime currentDateTime = DateTime.Now;

                
                string currentQueueQuery = @"
            SELECT COUNT(*) AS MEVCUT_SIRA
            FROM RANDEVULAR
            WHERE DOKTOR_ID = :doktorId
              AND POLIKLINIK_ID = :poliklinikId
              AND RANDEVU_TARIHI = TRUNC(:currentDateTime)
              AND RANDEVU_SAATI <= TO_CHAR(:currentDateTime, 'HH24:MI')";

                OracleCommand currentQueueCommand = new OracleCommand(currentQueueQuery, connection);
                currentQueueCommand.Parameters.Add(new OracleParameter("doktorId", doktorId));
                currentQueueCommand.Parameters.Add(new OracleParameter("poliklinikId", poliklinikId));
                currentQueueCommand.Parameters.Add(new OracleParameter("currentDateTime", currentDateTime));

                int mevcutSira = Convert.ToInt32(currentQueueCommand.ExecuteScalar());

                
                int sıraNo = mevcutSira +1;
                int bekleyenSira = sıraNo - mevcutSira;

                
                tbxMevcutSıra.Text = mevcutSira.ToString();
                tbxBekleyenSıra.Text = bekleyenSira.ToString();
                tbxSıraNo.Text = sıraNo.ToString();
            }
        }

        private void cbxHekim_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxSevk.SelectedItem != null)
            {
                seciliBirimi = Polyclinic.GetPolyclinicIdByName(cbxSevk.SelectedItem.ToString());
                doktorId = doktor.GetDoctorIdByFullName(cbxHekim.SelectedItem.ToString());
                CalculateAndDisplayQueueNumbers(doktorId, seciliBirimi);
            }
        }

        private void btnYatisKaydet_Click(object sender, EventArgs e)
        {
            try
            {
                int hastaNo = Convert.ToInt32(tbxHastaNo.Text);
                DateTime yatısTarihi = dtpYatisTarihi.Value;

                int mevcutYatısID = GetMevcutYatisId(hastaNo);

                if (mevcutYatısID != -1)
                {
                    MessageBox.Show("Bu hastanın zaten bir yatışı var.");
                    return;
                }

                using (OracleConnection conn = new OracleConnection(SessionManager.Instance.ConnectionString))
                {
                    conn.Open();

                    string insertQuery = "INSERT INTO HastaYatis (HASTANO, SERVISID, ODAID, YATISTARIHI, YATAKID) " +
                                         "VALUES (:HastaNo, :ServisID, :OdaID, :YatisTarihi, :YatakID)";
                    OracleCommand insertCmd = new OracleCommand(insertQuery, conn);
                    insertCmd.Parameters.Add(new OracleParameter("HastaNo", hastaNo));
                    insertCmd.Parameters.Add(new OracleParameter("ServisID", servisID));
                    insertCmd.Parameters.Add(new OracleParameter("OdaID", odaID));
                    insertCmd.Parameters.Add(new OracleParameter("YatisTarihi", yatısTarihi));
                    insertCmd.Parameters.Add(new OracleParameter("YatakID", yatakID));

                    insertCmd.ExecuteNonQuery();

                    string updateQuery = "UPDATE Yatak SET DURUM = 'Dolu' WHERE YATAKID = :YatakID";
                    OracleCommand updateCmd = new OracleCommand(updateQuery, conn);
                    updateCmd.Parameters.Add(new OracleParameter("YatakID", yatakID));
                    updateCmd.ExecuteNonQuery();
                }

                MessageBox.Show("Yatış başarıyla kaydedildi.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message);
            }
        }

        private int GetMevcutYatisId(int hastaNo)
        {
            int yatısID = -1;

            using (OracleConnection conn = new OracleConnection(SessionManager.Instance.ConnectionString))
            {
                conn.Open();
                string query = "SELECT YATISID FROM HastaYatis WHERE HASTANO = :HastaNo";
                OracleCommand cmd = new OracleCommand(query, conn);
                cmd.Parameters.Add(new OracleParameter("HastaNo", hastaNo));

                object result = cmd.ExecuteScalar();

                if (result != null)
                {
                    yatısID = Convert.ToInt32(result);
                }
            }

            return yatısID;
        }

        private void LoadServis()
        {
            using (OracleConnection conn = new OracleConnection(SessionManager.Instance.ConnectionString))
            {
                conn.Open();
                string query = "SELECT SERVISID, SERVISADI FROM SERVIS";
                OracleCommand cmd = new OracleCommand(query, conn);
                OracleDataReader reader = cmd.ExecuteReader();

                

                while (reader.Read())
                {
                    cbxServis.Items.Add(reader["SERVISADI"].ToString());
                }
                reader.Close();
            }
        }

        private void cbxServis_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            servisID = Convert.ToInt32(Servis.GetServisIdByName(cbxServis.SelectedItem.ToString()));


            cbxOdaNo.Items.Clear();

            using (OracleConnection conn = new OracleConnection(SessionManager.Instance.ConnectionString))
            {
                conn.Open();
                string query = "SELECT ODAID, ODANO FROM ODALAR WHERE SERVISID = :ServisID";
                OracleCommand cmd = new OracleCommand(query, conn);
                cmd.Parameters.Add(new OracleParameter("ServisID", servisID));

                OracleDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    cbxOdaNo.Items.Add(reader["ODANO"].ToString());
                }
                reader.Close();
            }
        }

        private void cbxOdaNo_SelectedIndexChanged(object sender, EventArgs e)
        {
   
            odaID = Convert.ToInt32(Servis.GetOdaIdByName(cbxOdaNo.SelectedItem.ToString()));

            cbxYatakNo.Items.Clear();

            using (OracleConnection conn = new OracleConnection(SessionManager.Instance.ConnectionString))
            {
                conn.Open();
                string query = "SELECT YATAKID, YATAKNO FROM YATAK WHERE ODAID = :OdaID AND DURUM = 'Boş'";
                OracleCommand cmd = new OracleCommand(query, conn);
                cmd.Parameters.Add(new OracleParameter("OdaID", odaID));

                OracleDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    cbxYatakNo.Items.Add(reader["YATAKNO"].ToString());
                    yatakID = Convert.ToInt32(reader["YATAKID"]);
                }
                reader.Close();
            }
        }


       

    }
}
