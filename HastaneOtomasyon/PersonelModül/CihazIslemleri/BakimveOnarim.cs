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

namespace HastaneOtomasyon.PersonelModül.CihazIslemleri
{
    public partial class BakimveOnarim : Form
    {
        private Point fixedLocation = new Point(100, 50);
        public BakimveOnarim()
        {
            InitializeComponent();
        }

        private void gunaButton1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void BakimveOnarim_Load(object sender, EventArgs e)
        {
            this.LocationChanged += BakimveOnarim_LocationChanged;
            grbBoxProfil.Visible = false;
            ListeleBakimOnarim();
        }

        private void BakimveOnarim_LocationChanged(object sender, EventArgs e)
        {
            this.Location = fixedLocation;
        }

      

        private void btnTıbbiCihaz_Click(object sender, EventArgs e)
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

        private void btnStokIslemleri_Click(object sender, EventArgs e)
        {
            PersonelModül.StokIslemleri.StokIslemleri stokIslemleri = new PersonelModül.StokIslemleri.StokIslemleri();
            stokIslemleri.Show();
            this.Close();
        }

        


        private void btnHastaHomeProfil_Click(object sender, EventArgs e)
        {
            grbBoxProfil.Visible = !grbBoxProfil.Visible;
        }

        private void btnKimlikBilgiler_Click(object sender, EventArgs e)
        {
            PersonelModül.Profil.KimlikBilgileri kimlikBilgileri = new PersonelModül.Profil.KimlikBilgileri();
            kimlikBilgileri.Show();
            this.Close();
        }

        private void btnİletişimBilgileri_Click(object sender, EventArgs e)
        {
            PersonelModül.Profil.IletisimBilgileri ıletisimBilgileri = new PersonelModül.Profil.IletisimBilgileri();
            ıletisimBilgileri.Show();
            this.Close();
        }

        private void btnParolaİşlemleri_Click(object sender, EventArgs e)
        {
            PersonelModül.Profil.ParolaIslemleri parolaIslemleri = new PersonelModül.Profil.ParolaIslemleri();
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
        private void ListeleBakimOnarim()
        {
            using (OracleConnection connection = new OracleConnection(SessionManager.Instance.ConnectionString))
            {
                try
                {
                    connection.Open();
                    string query = @"
        SELECT BAKIMONARIMID, 
               CIHAZID, 
               TO_CHAR(BAKIMTARIHI, 'DD/MM/YYYY') AS BAKIMTARIHI, 
               BAKIMTURU, 
               TO_CHAR(SSONRAKIBAKIMTARIHI, 'DD/MM/YYYY') AS SSONRAKIBAKIMTARIHI, 
               SORUMLUPERSONELID as personelid, 
               BAKIMDURUMU, 
               ACIKLAMA 
        FROM BAKIMONARIM";

                    OracleDataAdapter dataAdapter = new OracleDataAdapter(query, connection);
                    DataTable dataTable = new DataTable();
                    dataAdapter.Fill(dataTable);
                    dgwBakimOnarim.DataSource = dataTable;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Bakım/Onarım verilerini listeleme hatası: " + ex.Message);
                }
            }
        }


        private void btnEkle_Click(object sender, EventArgs e)
        {
            BakimOnarimEkle bakimOnarimEkle = new BakimOnarimEkle();
            bakimOnarimEkle.ShowDialog();
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            if (dgwBakimOnarim.SelectedRows.Count > 0)
            {
                // Seçili satırdan BakimOnarimID'yi al
                int bakimOnarimID = Convert.ToInt32(dgwBakimOnarim.SelectedRows[0].Cells["BAKIMONARIMID"].Value);

                // BakimOnarimGuncelle formunu aç ve BakimOnarimID'yi gönder
                BakimOnarimGuncelle form = new BakimOnarimGuncelle(bakimOnarimID);
                form.ShowDialog();
            }
            else
            {
                MessageBox.Show("Lütfen bir satır seçin.");
            }
        }
    }
}
