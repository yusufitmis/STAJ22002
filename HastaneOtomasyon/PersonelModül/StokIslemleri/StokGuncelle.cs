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
    public partial class StokGuncelle : Form
    {
        private int stokid;
        public StokGuncelle(int stokid)
        {
            InitializeComponent();
            this.stokid = stokid;   
        }
        public StokGuncelle()
        {
            InitializeComponent();
        }

        private void StokGuncelle_Load(object sender, EventArgs e)
        {
            LoadTedarikciler();
        }
        private void LoadTedarikciler()
        {
            using (OracleConnection conn = new OracleConnection(SessionManager.Instance.ConnectionString))
            {
                conn.Open();
                string query = "SELECT TEDARIKCIAD FROM TEDARIKCI";

                using (OracleCommand cmd = new OracleCommand(query, conn))
                {
                    using (OracleDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {

                            cbxTedarikci.Items.Add(reader["TEDARIKCIAD"].ToString());
                        }
                    }
                }
            }
        }

        public void StokBilgileriniGetir(int stokId)
        {
            using (OracleConnection conn = new OracleConnection(SessionManager.Instance.ConnectionString))
            {
                conn.Open();

                string query = @"
SELECT urunadi, urunturu, miktar, tedarikciid, songuncellemetarihi
FROM stok 
WHERE stokid = :stokId";

                OracleCommand cmd = new OracleCommand(query, conn);
                cmd.Parameters.Add(new OracleParameter("stokId", stokId));

                OracleDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    tbxxUrunAd.Text = reader["urunadi"].ToString();
                    cbxUrunTuru.Text = reader["urunturu"].ToString();
                    tbxMiktar.Text = reader["miktar"].ToString();
                    cbxTedarikci.SelectedItem = Cihaz.GetTedarikciNameById(Convert.ToInt32(reader["tedarikciid"])); 
                    dtpSonGuncellemeTarihi.Value = Convert.ToDateTime(reader["songuncellemetarihi"]);
                }
                else
                {
                    MessageBox.Show("Stok bulunamadı.");
                }

                conn.Close();
            }
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            string urunAd = tbxxUrunAd.Text.Trim();
            string urunTuru = cbxUrunTuru.Text.Trim();
            string miktarText = tbxMiktar.Text.Trim();

            if (cbxTedarikci.SelectedItem == null)
            {
                MessageBox.Show("Lütfen bir tedarikçi seçin.");
                return;
            }

            string tedarikciAdi = cbxTedarikci.SelectedItem.ToString();
            DateTime sonGuncellemeTarihi = dtpSonGuncellemeTarihi.Value.Date;

            if (string.IsNullOrWhiteSpace(urunAd) || string.IsNullOrWhiteSpace(urunTuru) ||
                string.IsNullOrWhiteSpace(miktarText))
            {
                MessageBox.Show("Lütfen tüm alanları doldurunuz.");
                return;
            }

            if (!int.TryParse(miktarText, out int miktar) || miktar < 0)
            {
                MessageBox.Show("Miktar geçersiz.");
                return;
            }

            UpdateStok(stokid, urunAd, urunTuru, miktar, tedarikciAdi, sonGuncellemeTarihi);
        }

        private void UpdateStok(int stokId, string urunAd, string urunTuru, int miktar, string tedarikciAdi, DateTime sonGuncellemeTarihi)
        {
            using (OracleConnection connection = new OracleConnection(SessionManager.Instance.ConnectionString))
            {
                try
                {
                    connection.Open();
                    string tedarikciQuery = "SELECT TEDARIKCIID FROM TEDARIKCI WHERE TEDARIKCIAD = :tedarikciAdi";
                    OracleCommand tedarikciCmd = new OracleCommand(tedarikciQuery, connection);
                    tedarikciCmd.Parameters.Add(new OracleParameter("tedarikciAdi", tedarikciAdi));
                    int tedarikciId = Convert.ToInt32(tedarikciCmd.ExecuteScalar());

                    string query = "UPDATE stok SET URUNADI = :urunAd, URUNTURU = :urunTuru, MIKTAR = :miktar, TEDARIKCIID = :tedarikciId, SONGUNCELLEMETARIHI = :sonGuncellemeTarihi WHERE STOKID = :stokId";

                    using (OracleCommand cmd = new OracleCommand(query, connection))
                    {
                        cmd.Parameters.Add(new OracleParameter("urunAd", urunAd));
                        cmd.Parameters.Add(new OracleParameter("urunTuru", urunTuru));
                        cmd.Parameters.Add(new OracleParameter("miktar", miktar));
                        cmd.Parameters.Add(new OracleParameter("tedarikciId", tedarikciId));
                        cmd.Parameters.Add(new OracleParameter("sonGuncellemeTarihi", sonGuncellemeTarihi));
                        cmd.Parameters.Add(new OracleParameter("stokId", stokId));

                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Stok başarıyla güncellendi.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Stok güncelleme hatası: " + ex.Message);
                }
            }
        }


    }
}
