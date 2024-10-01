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

namespace HastaneOtomasyon.PersonelModül.PersonelIslemleri
{
    public partial class EgitimveSertifikalar : Form
    {
        private Point fixedLocation = new Point(100, 50);
        
        private int hiddenPersonelId;
        public EgitimveSertifikalar()
        {
            InitializeComponent();
        }

        private void gunaButton1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnGenelIslemler_Click(object sender, EventArgs e)
        {
            PersonelModül.PersonelIslemleri.PersonelIslemleri personelIslemleri = new PersonelModül.PersonelIslemleri.PersonelIslemleri();
            personelIslemleri.Show();
            this.Close();
        }

        private void EgitimveSertifikalar_Load(object sender, EventArgs e)
        {
            this.LocationChanged += EgitimveSertifikalar_LocationChanged;
            
           

            tbxSearch.Text = "Personel Ara";
            tbxSearch.ForeColor = Color.Gray;

            grbBoxProfil.Visible = false;
            PersonelEgitimBilgileriniListele(tbxSearch.Text.Trim());
        }
        private void PersonelEgitimBilgileriniListele(string filterText)
        {
            try
            {
                using (OracleConnection conn = new OracleConnection(DataAccess.SessionManager.Instance.ConnectionString))
                {
                    conn.Open();

                    // Filtreleme sorgusu
                    string query = @"SELECT 
                                PERSONELID, 
                                (PERSONELAD || ' ' || PERSONELSOYAD) AS AD_SOYAD, 
                                PERSONELOGRENIM, 
                                PERSONELDIPLOMANO 
                            FROM PERSONEL
                            WHERE (PERSONELAD || ' ' || PERSONELSOYAD) LIKE :FilterText 
                            ORDER BY PERSONELID";

                    using (OracleCommand cmd = new OracleCommand(query, conn))
                    {
                        // Parametreyi ekle
                        cmd.Parameters.Add(":FilterText", OracleDbType.Varchar2).Value = "%" + filterText + "%";

                        OracleDataAdapter da = new OracleDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);

                        // DataGridView'i güncelle
                        dgwEgitim.DataSource = dt;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void EgitimveSertifikalar_LocationChanged(object sender, EventArgs e)
        {
            this.Location = fixedLocation;
        }

        private void btnRaporlar_Click(object sender, EventArgs e)
        {
            PersonelModül.PersonelIslemleri.Raporlar raporlar = new PersonelModül.PersonelIslemleri.Raporlar();
            raporlar.Show();
            this.Close();
        }

        private void btnIletisimBilgileriGuncelle_Click(object sender, EventArgs e)
        {
            PersonelModül.PersonelIslemleri.IletisimBilgileriniGuncelle ıletisimBilgileriniGuncelle = new PersonelModül.PersonelIslemleri.IletisimBilgileriniGuncelle();
            ıletisimBilgileriniGuncelle.Show();
            this.Close();
        }

        private void gunaButton2_Click(object sender, EventArgs e)
        {
            PersonelModül.PersonelIslemleri.Unvan unvan = new PersonelModül.PersonelIslemleri.Unvan();
            unvan.Show();
            this.Close();
        }

        private void tbxSearch_Enter(object sender, EventArgs e)
        {
            if (tbxSearch.Text == "Personel Ara")
            {
                tbxSearch.Text = "";
                tbxSearch.ForeColor = Color.Black;
               
            }
        }

        private void EgitimveSertifikalar_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbxSearch.Text))
            {
                
                tbxSearch.Text = "Personel Ara";
                tbxSearch.ForeColor = Color.Gray;
            }
        }

        private void btnHastaIslemleri_Click(object sender, EventArgs e)
        {
            PersonelModül.HastaIslemleri.HastaIslemleri hastaIslemleri = new PersonelModül.HastaIslemleri.HastaIslemleri();
            hastaIslemleri.Show();
            this.Close();
        }

        private void btnCihazIslemleri_Click(object sender, EventArgs e)
        {
            PersonelModül.CihazIslemleri.CihazIslemleri cihazIslemleri = new PersonelModül.CihazIslemleri.CihazIslemleri();
            cihazIslemleri.Show();
            this.Close();
        }

        private void btnKlinikİslemleri_Click(object sender, EventArgs e)
        {
            PersonelModül.HastaIslemleri.HastaIslemleri hastaIslemleri = new PersonelModül.HastaIslemleri.HastaIslemleri();
            hastaIslemleri.Show();
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

        private void dgwEgitim_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) 
            {
                DataGridViewRow row = dgwEgitim.Rows[e.RowIndex];

                // Seçilen satırdan verileri al
                string adSoyad = row.Cells["AD_SOYAD"].Value.ToString();
                string ogrenim = row.Cells["PERSONELOGRENIM"].Value.ToString();
                string diplomaNo = row.Cells["PERSONELDIPLOMANO"].Value.ToString();
                int personelId = Convert.ToInt32(row.Cells["PERSONELID"].Value);

                
                lblAd.Text = adSoyad;
                tbxOgrenim.Text = ogrenim;
                tbxDiploma.Text = diplomaNo;
                hiddenPersonelId = personelId; 
            }
        }

        private void btnPersonelGuncelle_Click(object sender, EventArgs e)
        {
            try
            {
                using (OracleConnection conn = new OracleConnection(DataAccess.SessionManager.Instance.ConnectionString))
                {
                    conn.Open();

                    // SQL UPDATE sorgusu
                    string query = @"UPDATE PERSONEL 
                             SET PERSONELOGRENIM = :Ogrenim, 
                                 PERSONELDIPLOMANO = :DiplomaNo 
                             WHERE PERSONELID = :PersonelID";

                    using (OracleCommand cmd = new OracleCommand(query, conn))
                    {
                        // Parametreleri ekle
                        cmd.Parameters.Add(":Ogrenim", OracleDbType.Varchar2).Value = tbxOgrenim.Text;
                        cmd.Parameters.Add(":DiplomaNo", OracleDbType.Varchar2).Value = tbxDiploma.Text;
                        cmd.Parameters.Add(":PersonelID", OracleDbType.Int32).Value = hiddenPersonelId;

                        // Sorguyu çalıştır
                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Bilgiler başarıyla güncellendi.", "Başarı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            PersonelEgitimBilgileriniListele(tbxSearch.Text.Trim()); 
                        }
                        else
                        {
                            MessageBox.Show("Güncelleme işlemi başarısız oldu.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tbxSearch_TextChanged(object sender, EventArgs e)
        {
            PersonelEgitimBilgileriniListele(tbxSearch.Text);
        }

        
    }
}
