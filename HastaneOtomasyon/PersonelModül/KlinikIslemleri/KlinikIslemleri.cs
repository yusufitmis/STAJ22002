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

namespace HastaneOtomasyon.PersonelModül.KlinikIslemleri
{
    
    public partial class KlinikIslemleri : Form
    {
        private Point fixedLocation = new Point(100, 50);
        public KlinikIslemleri()
        {
            InitializeComponent();
        }

        private void KlinikIslemleri_Load(object sender, EventArgs e)
        {
            this.LocationChanged += KlinikIslemleri_LocationChanged;

            grbBoxProfil.Visible = false;

            tbxSearch.Text = "Klinik Ara";
            tbxSearch.ForeColor = Color.Gray;
            KlinikBilgileriniListele();
        }

        private void KlinikIslemleri_LocationChanged(object sender, EventArgs e)
        {
            this.Location = fixedLocation;
        }

        private void gunaDataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void tbxSearch_Enter(object sender, EventArgs e)
        {
            if (tbxSearch.Text == "Klinik Ara")
            {
                tbxSearch.Text = "";
                tbxSearch.ForeColor = Color.Black;
            }
        }

        private void tbxSearch_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbxSearch.Text))
            {
                tbxSearch.Text = "Klinik Ara";
                tbxSearch.ForeColor = Color.Gray;
            }
        }

        private void btnServis_Click(object sender, EventArgs e)
        {
            PersonelModül.KlinikIslemleri.ServisIslemleri servisIslemleri = new PersonelModül.KlinikIslemleri.ServisIslemleri();
            servisIslemleri.Show();
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

        private void btnOda_Click(object sender, EventArgs e)
        {
            PersonelModül.KlinikIslemleri.OdaIslemleri odaIslemleri = new PersonelModül.KlinikIslemleri.OdaIslemleri();
            odaIslemleri.Show();
            this.Close();
        }

        private void btnYatak_Click(object sender, EventArgs e)
        {
            PersonelModül.KlinikIslemleri.YatakIslemleri yatakIslemleri = new PersonelModül.KlinikIslemleri.YatakIslemleri();
            yatakIslemleri.Show();
            this.Close();
        }

        private void btnCihazIslemleri_Click(object sender, EventArgs e)
        {
            PersonelModül.CihazIslemleri.CihazIslemleri cihazIslemleri = new PersonelModül.CihazIslemleri.CihazIslemleri();
            cihazIslemleri.Show();
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
        public void KlinikBilgileriniListele(string searchQuery = "")
        {
            using (OracleConnection conn = new OracleConnection(SessionManager.Instance.ConnectionString))
            {
                conn.Open();

                string query = @"
            SELECT 
                KLINIKID,
                KLINIKAD, 
                KLINIKUCRET, 
                DAHILITEL, 
                LIMIT 
            FROM KLINIK";

                if (!string.IsNullOrWhiteSpace(searchQuery))
                {
                    query += " WHERE LOWER(KLINIKAD) LIKE :searchQuery";
                }

                query += " ORDER BY KLINIKID"; 

                OracleCommand cmd = new OracleCommand(query, conn);

                if (!string.IsNullOrWhiteSpace(searchQuery))
                {
                    cmd.Parameters.Add(new OracleParameter("searchQuery", $"%{searchQuery.ToLower()}%"));
                }

                OracleDataAdapter da = new OracleDataAdapter(cmd);
                DataTable dtKlinik = new DataTable();
                da.Fill(dtKlinik);

                dgwKlinikler.DataSource = dtKlinik;

                conn.Close();
            }
        }

        private void tbxSearch_TextChanged(object sender, EventArgs e)
        {
            string searchText = tbxSearch.Text.Trim();

            if (string.IsNullOrWhiteSpace(searchText) || searchText == "Hasta Ara")
            {
                KlinikBilgileriniListele(); 
            }
            else
            {
                KlinikBilgileriniListele(searchText); 
            }
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            KlinikEkle klinikEkle = new KlinikEkle();
            klinikEkle.Show();

        }
        private int klinikid;

        private void dgwKlinikler_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var selectedRow = dgwKlinikler.Rows[e.RowIndex];
                klinikid = Convert.ToInt32(selectedRow.Cells["klinikid"].Value); 
            }
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            if (dgwKlinikler.SelectedRows.Count > 0)
            {
                int selectedKlinikId = Convert.ToInt32(dgwKlinikler.SelectedRows[0].Cells["klinikid"].Value);
                KlinikGuncelle klinikGuncelleFormu = new KlinikGuncelle(selectedKlinikId);
                klinikGuncelleFormu.KlinikBilgileriniGetir(selectedKlinikId);
                klinikGuncelleFormu.ShowDialog(); 
            }
        }
    }
}
