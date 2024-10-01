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
    public partial class IletisimBilgileriniGuncelle : Form
    {
        private Point fixedLocation = new Point(100, 50);
        public IletisimBilgileriniGuncelle()
        {
            InitializeComponent();
        }

        private void IletisimBilgileriniGuncelle_Load(object sender, EventArgs e)
        {
            this.LocationChanged += IletisimBilgileriniGuncelle_LocationChanged;
            grbBoxProfil.Visible = false;
            tbxSearch.Text = "Personel Ara";
            tbxSearch.ForeColor = Color.Gray;
            PersonelIletisimBilgileriniListele(tbxSearch.Text.Trim());

        }
        private void PersonelIletisimBilgileriniListele(string aramaMetni)
        {
            try
            {
                using (OracleConnection conn = new OracleConnection(DataAccess.SessionManager.Instance.ConnectionString))
                {
                    conn.Open();
                    string query = "SELECT PERSONELID, (PERSONELAD || ' ' || PERSONELSOYAD) AS AD_SOYAD, PERSONELTELNO, PERSONELEPOSTA " +
                                   "FROM PERSONEL " +
                                   "WHERE (PERSONELAD || ' ' || PERSONELSOYAD) LIKE :AramaMetni " +
                                   "ORDER BY PERSONELID";

                    using (OracleCommand cmd = new OracleCommand(query, conn))
                    {
                        cmd.Parameters.Add(":AramaMetni", OracleDbType.Varchar2).Value = "%" + aramaMetni + "%";
                        OracleDataAdapter da = new OracleDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        dgwIletisim.DataSource = dt;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message);
            }
        }

        private void IletisimBilgileriniGuncelle_LocationChanged(object sender, EventArgs e)
        {
            this.Location = fixedLocation;
        }

        private void gunaButton1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnRaporlar_Click(object sender, EventArgs e)
        {
            PersonelModül.PersonelIslemleri.Raporlar raporlar = new PersonelModül.PersonelIslemleri.Raporlar();
            raporlar.Show();
            this.Close();
        }

        private void btnEgitimveSertifika_Click(object sender, EventArgs e)
        {
           
            PersonelModül.PersonelIslemleri.EgitimveSertifikalar egitimveSertifikalar = new PersonelModül.PersonelIslemleri.EgitimveSertifikalar();
            egitimveSertifikalar.Show();
            this.Close();
        }

        private void btnGenelIslemler_Click(object sender, EventArgs e)
        {
            PersonelModül.PersonelIslemleri.PersonelIslemleri personelIslemleri = new PersonelModül.PersonelIslemleri.PersonelIslemleri();
            personelIslemleri.Show();
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

        private void tbxSearch_Leave(object sender, EventArgs e)
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
                Application.Exit();
            }

            else if (dialogResult == DialogResult.No)
            {

            }
        }

        private void dgwIletisim_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgwIletisim.Rows[e.RowIndex];

                string telefon = row.Cells["PERSONELTELNO"].Value.ToString();
                string eposta = row.Cells["PERSONELEPOSTA"].Value.ToString();

            
                tbxTel.Text = telefon;
                tbxEposta.Text = eposta;
            }
        }
      
        private int GetSelectedPersonelId()
        {
            if (dgwIletisim.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dgwIletisim.SelectedRows[0];
                return Convert.ToInt32(row.Cells["PERSONELID"].Value);
            }
            return -1;
        }

        private void gunaPanel3_MouseClick(object sender, MouseEventArgs e)
        {
            tbxTel.Clear();
            tbxEposta.Clear();
        }

        private void btnPersonelGuncelle_Click(object sender, EventArgs e)
        {
            string eposta = tbxEposta.Text;
            int personelId = GetSelectedPersonelId();

            if (personelId != -1)
            {
                try
                {
                    using (OracleConnection conn = new OracleConnection(DataAccess.SessionManager.Instance.ConnectionString))
                    {
                        conn.Open();

                        string query = "UPDATE PERSONEL SET PERSONELEPOSTA = :Eposta WHERE PERSONELID = :PersonelID";

                        using (OracleCommand cmd = new OracleCommand(query, conn))
                        {
                            cmd.Parameters.Add(":Eposta", OracleDbType.Varchar2).Value = eposta;
                            cmd.Parameters.Add(":PersonelID", OracleDbType.Int32).Value = personelId;

                            cmd.ExecuteNonQuery();
                        }
                    }

                    MessageBox.Show("E-posta adresi güncellendi.");
                    PersonelIletisimBilgileriniListele(tbxSearch.Text.Trim());

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hata: " + ex.Message);
                }
            }
        }

        private void btnTel_Click(object sender, EventArgs e)
        {
            string telefon = tbxTel.Text;
            int personelId = GetSelectedPersonelId();

            if (personelId != -1)
            {
                try
                {
                    using (OracleConnection conn = new OracleConnection(DataAccess.SessionManager.Instance.ConnectionString))
                    {
                        conn.Open();

                        string query = "UPDATE PERSONEL SET PERSONELTELNO = :Telefon WHERE PERSONELID = :PersonelID";

                        using (OracleCommand cmd = new OracleCommand(query, conn))
                        {
                            cmd.Parameters.Add(":Telefon", OracleDbType.Varchar2).Value = telefon;
                            cmd.Parameters.Add(":PersonelID", OracleDbType.Int32).Value = personelId;

                            cmd.ExecuteNonQuery();
                        }
                    }

                    MessageBox.Show("Telefon numarası güncellendi.");
                    PersonelIletisimBilgileriniListele(tbxSearch.Text.Trim());
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hata: " + ex.Message);
                }
            }
        }

        private void tbxSearch_TextChanged(object sender, EventArgs e)
        {
            PersonelIletisimBilgileriniListele(tbxSearch.Text);
        }
    }
}
