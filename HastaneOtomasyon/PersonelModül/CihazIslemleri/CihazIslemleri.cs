using HastaneOtomasyon.DataAccess;
using HastaneOtomasyon.PersonelModül.KlinikIslemleri;
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
    public partial class CihazIslemleri : Form
    {
        private Point fixedLocation = new Point(100, 50);
        public CihazIslemleri()
        {
            InitializeComponent();
        }

        private void gunaButton1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void CihazIslemleri_Load(object sender, EventArgs e)
        {
            this.LocationChanged += CihazIslemleri_LocationChanged;
            grbBoxProfil.Visible = false;
            ListeleCihazlar();
        }

        private void CihazIslemleri_LocationChanged(object sender, EventArgs e)
        {
            this.Location = fixedLocation;
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

      

        private void btnBakım_Click(object sender, EventArgs e)
        {
            PersonelModül.CihazIslemleri.BakimveOnarim bakimveOnarim = new PersonelModül.CihazIslemleri.BakimveOnarim();
            bakimveOnarim.Show();
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
        public void ListeleCihazlar()
        {
            using (OracleConnection connection = new OracleConnection(SessionManager.Instance.ConnectionString))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT cihazid, cihazadi, tedarikciid, sonbakimtarihi,durum FROM tibbicihaz";
                    using (OracleCommand cmd = new OracleCommand(query, connection))
                    {
                        OracleDataAdapter adapter = new OracleDataAdapter(cmd);
                        DataTable dt = new DataTable();

                        adapter.Fill(dt);

                        dgwCihazlar.DataSource = dt;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Veri getirme hatası: " + ex.Message);
                }
            }
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            CihazEkle cihazEkle = new CihazEkle();
            cihazEkle.Show();
        }
        private int cihazid;
        private void dgwCihazlar_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var selectedRow = dgwCihazlar.Rows[e.RowIndex];
                cihazid = Convert.ToInt32(selectedRow.Cells["cihazid"].Value);
            }
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            if (dgwCihazlar.SelectedRows.Count > 0)
            {
                int selectedCihazId = Convert.ToInt32(dgwCihazlar.SelectedRows[0].Cells["cihazid"].Value);
                CihazGuncelle cihazGuncelle = new CihazGuncelle(selectedCihazId);
                cihazGuncelle.CihazBilgileriniGetir(selectedCihazId);
                cihazGuncelle.ShowDialog();
            }
        }
    }
}
