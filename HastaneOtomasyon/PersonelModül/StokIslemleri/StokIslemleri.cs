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

namespace HastaneOtomasyon.PersonelModül.StokIslemleri
{
    public partial class StokIslemleri : Form
    {
        private Point fixedLocation = new Point(100, 50);
        public StokIslemleri()
        {
            InitializeComponent();
        }

        private void gunaButton1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnCihazIslemleri_Click(object sender, EventArgs e)
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
        private void StokIslemleri_Load(object sender, EventArgs e)
        {
            this.LocationChanged += StokIslemleri_LocationChanged;
            tbxSearch.Text = "Ürün Ara";
            tbxSearch.ForeColor = Color.Gray;

            grbBoxProfil.Visible = false;
            ListeleStoklar();
        }
        private void StokIslemleri_LocationChanged(object sender, EventArgs e)
        {
            this.Location = fixedLocation;
        }

        private void btnTedarikci_Click(object sender, EventArgs e)
        {
            PersonelModül.StokIslemleri.Tedarikciİslemleri tedarikciİslemleri = new PersonelModül.StokIslemleri.Tedarikciİslemleri();
            tedarikciİslemleri.Show();
            this.Close();
        }
        private void tbxSearch_Enter(object sender, EventArgs e)
        {
            if (tbxSearch.Text == "Ürün Ara")
            {
                tbxSearch.Text = "";
                tbxSearch.ForeColor = Color.Black;
            }
        }
        private void tbxSearch_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbxSearch.Text))
            {
                tbxSearch.Text = "Ürün Ara";
                tbxSearch.ForeColor = Color.Gray;
            }
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
        public void ListeleStoklar()
        {
            using (OracleConnection connection = new OracleConnection(SessionManager.Instance.ConnectionString))
            {
                try
                {
                    connection.Open();

                    string searchValue = tbxSearch.Text.Trim();

                    bool filterEnabled = !string.IsNullOrWhiteSpace(searchValue) && searchValue != "Ürün Ara";

                    string query = @"
                SELECT stokid, urunadi, urunturu, miktar, tedarikciid, songuncellemetarihi 
                FROM stok";

                    if (filterEnabled)
                    {
                        query += " WHERE urunadi LIKE :searchValue OR urunturu LIKE :searchValue";
                    }

                    using (OracleCommand cmd = new OracleCommand(query, connection))
                    {
                        if (filterEnabled)
                        {
                            cmd.Parameters.Add(new OracleParameter("searchValue", "%" + searchValue + "%"));
                        }

                        OracleDataAdapter adapter = new OracleDataAdapter(cmd);
                        DataTable dt = new DataTable();

                        adapter.Fill(dt);

                        dgwStoklar.DataSource = dt;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Veri getirme hatası: " + ex.Message);
                }
            }
        }

        private void tbxSearch_TextChanged(object sender, EventArgs e)
        {
            ListeleStoklar();
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            StokEkle stokEkle = new StokEkle();
            stokEkle.ShowDialog();
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            if (dgwStoklar.SelectedRows.Count > 0)
            {
                int selectedStokId = Convert.ToInt32(dgwStoklar.SelectedRows[0].Cells["stokid"].Value);

                StokGuncelle stokGuncelle = new StokGuncelle(selectedStokId);
                stokGuncelle.StokBilgileriniGetir(selectedStokId);
                stokGuncelle.ShowDialog();
            }
        }
        private int stokid;
        private void dgwStoklar_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var selectedRow = dgwStoklar.Rows[e.RowIndex];
                stokid = Convert.ToInt32(selectedRow.Cells["stokid"].Value);
            }
        }

        private void btnSiparis_Click(object sender, EventArgs e)
        {
            if (dgwStoklar.SelectedRows.Count > 0)
            {
                int selectedStokId = Convert.ToInt32(dgwStoklar.SelectedRows[0].Cells["stokid"].Value);
                int selectedTedarikciId = Convert.ToInt32(dgwStoklar.SelectedRows[0].Cells["tedarikciid"].Value);

                SiparisVer siparisVer = new SiparisVer(selectedStokId, selectedTedarikciId);
                siparisVer.ShowDialog();
            }
        }

        private void btnSiparisTakip_Click(object sender, EventArgs e)
        {
            if (dgwStoklar.SelectedRows.Count > 0)
            {
                int selectedStokId = Convert.ToInt32(dgwStoklar.SelectedRows[0].Cells["STOKID"].Value);
                SiparisDetay siparisDetay = new SiparisDetay(selectedStokId);
                siparisDetay.ShowDialog();
            }
            else
            {
                MessageBox.Show("Lütfen bir stok seçin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
