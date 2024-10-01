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
    public partial class HastaGecmis : Form
    {
        private string tcKimlikNo;
        private HastaBilgileri hastaBilgileri;
        private MuayeneBilgileri muayeneBilgileri;
        private Point fixedLocation = new Point(100, 50);
        public HastaGecmis(HastaBilgileri hastaBilgileri, MuayeneBilgileri muayeneBilgileri, string tcKimlikNo)
        {
            InitializeComponent();
            this.hastaBilgileri = hastaBilgileri;
            this.muayeneBilgileri = muayeneBilgileri;
            this.tcKimlikNo = tcKimlikNo;
        }
        public HastaGecmis()
        {
            InitializeComponent();
        }

        private void gunaButton1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnIlac_Click(object sender, EventArgs e)
        {
            DoktorModül.Poliklinik.Ilac recete = new DoktorModül.Poliklinik.Ilac();
            recete.Show();
            this.Close();
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

        private void HastaGecmis_Load(object sender, EventArgs e)
        {
            grbBoxProfil.Visible = false;
            this.LocationChanged += HastaGecmis_LocationChanged;
            tbxTcNo.Text = tcKimlikNo;
            LoadHastaBilgileri();
            MuayeneleriListele(Convert.ToInt32(hastaBilgileri.HastaNo));
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


        private void btnHastaHomeProfil_Click(object sender, EventArgs e)
        {
            grbBoxProfil.Visible = !grbBoxProfil.Visible;
        }

        private void btnHastaKabul_Click(object sender, EventArgs e)
        {
            DoktorModül.HastaKabul hastaKabul = new DoktorModül.HastaKabul();
            hastaKabul.Show();
            this.Close();
        }

        private void HastaGecmis_LocationChanged(object sender, EventArgs e)
        {
            this.Location = fixedLocation;
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
        private void MuayeneleriListele(int hastaNo)
        {
            using (OracleConnection conn = new OracleConnection(SessionManager.Instance.ConnectionString))
            {
                
                string query = @"
            SELECT M.MUAYENEID as Protokol, 
                   M.MUAYENETARIHI, 
                   K.KLINIKAD as Birim, 
                   P.personelAD || ' ' || P.personelSOYAD AS HEKIM
            FROM MUAYENE M
            JOIN KLINIK K ON M.KLINIKID = K.KLINIKID
            JOIN PERSONEL P ON M.doktorid = P.PERSONELID
            WHERE M.HASTANO = :HastaNo";

                OracleCommand cmd = new OracleCommand(query, conn);
                cmd.Parameters.Add(new OracleParameter("HastaNo", hastaNo));

                conn.Open();

                OracleDataAdapter da = new OracleDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                dgwMuayeneler.DataSource = dt;

                conn.Close();
            }
        }

        private void dgwMuayeneler_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgwMuayeneler.Rows[e.RowIndex];
                int muayeneID = Convert.ToInt32(row.Cells["Protokol"].Value); 

                GoruntulemeVeTahlilVerileriListele(muayeneID);
                MuayeneReceteleriniListele(muayeneID);
            }
        }
        private void GoruntulemeVeTahlilVerileriListele(int muayeneID)
        {
            using (OracleConnection conn = new OracleConnection(SessionManager.Instance.ConnectionString))
            {
                conn.Open();

                string goruntulemeQuery = @"
            SELECT GM.GORUNTULEMETARIHI AS TARIH, GM.GORUNTULEMEID AS KODU,G.GORUNTULEMETURU AS ISLEM_ADI, GM.SONUC AS SONUC
            FROM GORUNTULEMEMUAYENE GM
            INNER JOIN GORUNTULEME G on GM.GORUNTULEMEID = G.GORUNTULEMEID
            WHERE GM.MUAYENEID = :MuayeneID 
            ORDER BY TARIH DESC";

                OracleCommand goruntulemeCmd = new OracleCommand(goruntulemeQuery, conn);
                goruntulemeCmd.Parameters.Add(new OracleParameter("MuayeneID", muayeneID));

                OracleDataAdapter daGoruntuleme = new OracleDataAdapter(goruntulemeCmd);
                DataTable dtGoruntuleme = new DataTable();
                daGoruntuleme.Fill(dtGoruntuleme);

                string tahlilQuery = @"
            SELECT TM.TAHLILTARIH AS TARIH, TM.TAHLILID AS KODU, T.TAHLILTURU AS ISLEM_ADI, TM.SONUC AS SONUC 
            FROM TAHLILMUAYENE TM
            INNER JOIN TAHLIL T on TM.TAHLILID = T.TAHLILID
            WHERE TM.MUAYENEID = :MuayeneID 
            ORDER BY TARIH DESC";

                OracleCommand tahlilCmd = new OracleCommand(tahlilQuery, conn);
                tahlilCmd.Parameters.Add(new OracleParameter("MuayeneID", muayeneID));

                OracleDataAdapter daTahlil = new OracleDataAdapter(tahlilCmd);
                DataTable dtTahlil = new DataTable();
                daTahlil.Fill(dtTahlil);

                DataTable combinedTable = dtGoruntuleme.Clone(); 
                combinedTable.Merge(dtGoruntuleme); 
                combinedTable.Merge(dtTahlil); 

                dgwGoruntulemeTahlil.DataSource = combinedTable;

                conn.Close();
            }
        }
        private void MuayeneReceteleriniListele(int muayeneID)
        {
            using (OracleConnection conn = new OracleConnection(SessionManager.Instance.ConnectionString))
            {
                conn.Open();


                string receteQuery = @"
            SELECT RECETEID,   RECETETARIHI, RECETETIPI
            FROM RECETE
            WHERE MUAYENEID = :MuayeneID
            order by RECETETARIHI DESC";

                OracleCommand receteCmd = new OracleCommand(receteQuery, conn);
                receteCmd.Parameters.Add(new OracleParameter("MuayeneID", muayeneID));

                OracleDataAdapter daRecete = new OracleDataAdapter(receteCmd);
                DataTable dtRecete = new DataTable();
                daRecete.Fill(dtRecete);


                dgwReceteler.DataSource = dtRecete;

                conn.Close();
            }
        }

        private void dgwReceteler_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgwReceteler.Rows[e.RowIndex];
                int receteid = Convert.ToInt32(row.Cells["receteid"].Value);

                ReceteİlaclarListele(receteid);
            }
        }
        private void ReceteİlaclarListele(int receteid)
        {
            using (OracleConnection conn = new OracleConnection(SessionManager.Instance.ConnectionString))
            {
                conn.Open();


                string receteQuery = @"
            SELECT ilacad as Adı, ilackullanimi as Kullanımı, periyod as Periyod, periyodbirimi as Periyod_Birimi, periyodadet as Kutu, periyoddoz as Doz
            FROM RECETEILAC
            WHERE RECETEID = :RECETEID
            order by ADI";

                OracleCommand receteCmd = new OracleCommand(receteQuery, conn);
                receteCmd.Parameters.Add(new OracleParameter("RECETEID", receteid));

                OracleDataAdapter daRecete = new OracleDataAdapter(receteCmd);
                DataTable dtRecete = new DataTable();
                daRecete.Fill(dtRecete);


                dgwİlaclar.DataSource = dtRecete;

                conn.Close();
            }
        }
    }
}
