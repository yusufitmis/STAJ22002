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
    public partial class CihazEkle : Form
    {
        public CihazEkle()
        {
            InitializeComponent();
        }

        private void CihazEkle_Load(object sender, EventArgs e)
        {
            LoadTedarikciler();

        }
        public void LoadTedarikciler()
        {
            using (OracleConnection connection = new OracleConnection(SessionManager.Instance.ConnectionString))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT TEDARIKCIAD FROM TEDARIKCI";
                    using (OracleCommand cmd = new OracleCommand(query, connection))
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
                catch (Exception ex)
                {
                    MessageBox.Show("Tedarikçi yükleme hatası: " + ex.Message);
                }
            }
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            string cihazAdi = tbxCihazAdı.Text.Trim();
            string tedarikciAd = cbxTedarikci.SelectedItem?.ToString();

            if (string.IsNullOrWhiteSpace(cihazAdi) || string.IsNullOrWhiteSpace(tedarikciAd))
            {
                MessageBox.Show("Lütfen cihaz adı ve tedarikçi seçiniz.");
                return;
            }

            int tedarikciId = Cihaz.GetTedarikciIdByName(tedarikciAd);
            if (tedarikciId == -1)
            {
                MessageBox.Show("Tedarikçi bulunamadı.");
                return;
            }

            
            DateTime sonBakimTarihi = DateTime.Now.Date;

            AddCihaz(cihazAdi, tedarikciId, sonBakimTarihi);
        }

        private void AddCihaz(string cihazAdi, int tedarikciId, DateTime sonBakimTarihi)
        {
            using (OracleConnection connection = new OracleConnection(SessionManager.Instance.ConnectionString))
            {
                try
                {
                    connection.Open();
                    string query = "INSERT INTO tibbicihaz (CIHAZADI, TEDARIKCIID, SONBAKIMTARIHI, DURUM) VALUES (:cihazAdi, :tedarikciId, :sonBakimTarihi, 'Pasif')";

                    using (OracleCommand cmd = new OracleCommand(query, connection))
                    {
                        cmd.Parameters.Add(new OracleParameter("cihazAdi", cihazAdi));
                        cmd.Parameters.Add(new OracleParameter("tedarikciId", tedarikciId));
                        cmd.Parameters.Add(new OracleParameter("sonBakimTarihi", sonBakimTarihi));

                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Cihaz başarıyla eklendi.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Cihaz ekleme hatası: " + ex.Message);
                }
            }
        }
    }
}
