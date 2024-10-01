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
    public partial class YatakIslemleri : Form
    {
        private Point fixedLocation = new Point(100, 50);
        private int odaid;
        public YatakIslemleri()
        {
            InitializeComponent();
        }

        private void YatakIslemleri_Load(object sender, EventArgs e)
        {
            this.LocationChanged += YatakIslemleri_LocationChanged;
            grbBoxProfil.Visible = false;
            cbxServisSec_Drop();
        }

        private void YatakIslemleri_LocationChanged(object sender, EventArgs e)
        {
            this.Location = fixedLocation;
        }

        private void btnOda_Click(object sender, EventArgs e)
        {
            PersonelModül.KlinikIslemleri.OdaIslemleri odaIslemleri = new PersonelModül.KlinikIslemleri.OdaIslemleri();
            odaIslemleri.Show();
            this.Close();
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

                            cbxServisSec.Items.Add((reader["SERVISADI"].ToString()));
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
        private void cbxOdaSec_Drop(int servisId)
        {
            cbxOdaSec.Items.Clear(); 

            using (OracleConnection conn = new OracleConnection(SessionManager.Instance.ConnectionString))
            {
                conn.Open();
                string query = "SELECT odano FROM odalar WHERE servisid = :servisId order by odano";

                OracleCommand cmd = new OracleCommand(query, conn);
                cmd.Parameters.Add(new OracleParameter(":servisId", servisId));

                try
                {
                    using (OracleDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            cbxOdaSec.Items.Add(reader["odano"].ToString());
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
            string secilenServisAdi = cbxServisSec.SelectedItem.ToString();

            int servisId = Servis.GetServisIdByName(secilenServisAdi);

            if (servisId != -1) 
            {
                cbxOdaSec_Drop(servisId);
            }
            else
            {
                MessageBox.Show("Geçerli bir servis bulunamadı.");
            }
        }
        private void YataklariListele(int odaId)
        {
            using (OracleConnection connection = new OracleConnection(SessionManager.Instance.ConnectionString))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT yatakid, YATAKNO, DURUM FROM YATAK WHERE ODAID = :odaId";
                    using (OracleCommand cmd = new OracleCommand(query, connection))
                    {
                        
                        cmd.Parameters.Add(new OracleParameter(":odaId", odaId));

                        OracleDataAdapter adapter = new OracleDataAdapter(cmd);
                        DataTable dt = new DataTable();

                        adapter.Fill(dt);

                        dgwYataklar.DataSource = dt;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Veri getirme hatası: " + ex.Message);
                }
            }
        }


        private void cbxOdaSec_SelectedIndexChanged(object sender, EventArgs e)
        {
            string secilenOdaNo = cbxOdaSec.SelectedItem.ToString();

            odaid = Servis.GetOdaIdByOdaNo(secilenOdaNo);

            if (odaid != -1) 
            {
                
                YataklariListele(odaid);
            }
            else
            {
                MessageBox.Show("Geçerli bir oda bulunamadı.");
            }
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            YatakEkle yatakEkle = new YatakEkle(odaid);
            yatakEkle.Show();
        }

        private void dgwYataklar_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var selectedRow = dgwYataklar.Rows[e.RowIndex];
                odaid = Convert.ToInt32(selectedRow.Cells["yatakid"].Value);
            }
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            if (dgwYataklar.SelectedRows.Count > 0)
            {
                int selectedYatakId = Convert.ToInt32(dgwYataklar.SelectedRows[0].Cells["yatakid"].Value);
                YatakGuncelle yatakGuncelle = new YatakGuncelle(selectedYatakId);
                yatakGuncelle.YatakBilgileriniGetir(selectedYatakId);
                yatakGuncelle.ShowDialog();
            }
        }
    }
}
