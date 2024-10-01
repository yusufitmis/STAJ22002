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
    public partial class OdaIslemleri : Form
    {
        private Point fixedLocation = new Point(100, 50);
        public OdaIslemleri()
        {
            InitializeComponent();
        }

        private void OdaIslemleri_Load(object sender, EventArgs e)
        {
            this.LocationChanged += OdaIslemleri_LocationChanged;

            grbBoxProfil.Visible = false;
            cbxServisSec_Drop();


        }

        private void OdaIslemleri_LocationChanged(object sender, EventArgs e)
        {
            this.Location = fixedLocation;
        }

        private void btnServis_Click(object sender, EventArgs e)
        {
            PersonelModül.KlinikIslemleri.ServisIslemleri servisIslemleri = new PersonelModül.KlinikIslemleri.ServisIslemleri();
            servisIslemleri.Show();
            this.Close();
        }

        private void btnKlinik_Click(object sender, EventArgs e)
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
        private void cbxServisSec_Drop()
        {
            cbxServisSec.Items.Clear();

            using (OracleConnection conn = new OracleConnection(SessionManager.Instance.ConnectionString))
            {
                conn.Open();
                string query = "SELECT SERVISADI FROM SERVIS";

                OracleCommand cmd = new OracleCommand(query, conn);

                try
                {
                    using (OracleDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {

                            cbxServisSec.Items.Add(( reader["SERVISADI"].ToString()));
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Veritabanı hatası: " + ex.Message);
                }

                conn.Close();
            }

        }

        private void cbxServisSec_SelectedIndexChanged(object sender, EventArgs e)
        {
            OdaListele();
        }
        public void OdaListele()
        {
            if (cbxServisSec.SelectedItem == null)
            {
                MessageBox.Show("Lütfen bir servis seçin.");
                return; 
            }

            string selectedServisAd = cbxServisSec.SelectedItem.ToString();
            int? servisId = Servis.GetServisIdByName(selectedServisAd);

            if (servisId.HasValue)
            {
                using (OracleConnection conn = new OracleConnection(SessionManager.Instance.ConnectionString))
                {
                    conn.Open();

                    string query = "SELECT ODAID, ODANO, ODAKAPASITESI FROM ODALAR WHERE SERVISID = :servisId";
                    OracleCommand cmd = new OracleCommand(query, conn);
                    cmd.Parameters.Add(new OracleParameter("servisId", servisId.Value)); // Nullable değer doğrudan kullanılabilir.

                    OracleDataAdapter odaAdapter = new OracleDataAdapter(cmd);
                    DataTable odaTable = new DataTable();

                    try
                    {
                        odaAdapter.Fill(odaTable);
                        if (odaTable.Rows.Count == 0)
                        {
                            MessageBox.Show("Seçilen servise ait oda bulunamadı.");
                        }
                        else
                        {
                            dgwOdalar.DataSource = odaTable;
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Veritabanı hatası: " + ex.Message);
                    }
                    finally
                    {
                        conn.Close();
                    }
                }
            }
            else
            {
                MessageBox.Show("Seçilen servise ait servis ID bulunamadı.");
            }
        }


        private void btnEkle_Click(object sender, EventArgs e)
        {
            OdaEkle odaEkle = new OdaEkle();
            odaEkle.ShowDialog();
        }
        private int odaid;

        private void dgwOdalar_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var selectedRow = dgwOdalar.Rows[e.RowIndex];
                odaid = Convert.ToInt32(selectedRow.Cells["odaid"].Value);
            }
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            if (dgwOdalar.SelectedRows.Count > 0)
            {
                int selectedOdaId = Convert.ToInt32(dgwOdalar.SelectedRows[0].Cells["odaid"].Value);
                OdaGuncelle odaGuncelle = new OdaGuncelle(selectedOdaId);
                odaGuncelle.OdaBilgileriniGetir(selectedOdaId);
                odaGuncelle.ShowDialog();
            }
        }
    }
}
