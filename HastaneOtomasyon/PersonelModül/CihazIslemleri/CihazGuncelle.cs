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
    public partial class CihazGuncelle : Form
    {
        private int cihazid;
        
        public CihazGuncelle(int cihazid)
        {
            InitializeComponent();
            this.cihazid = cihazid;
        }
        public CihazGuncelle()
        {
            InitializeComponent();
        }

        private void CihazGuncelle_Load(object sender, EventArgs e)
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
                                string tedarikciAd = reader["TEDARIKCIAD"].ToString();
                                cbxTedarikci.Items.Add(tedarikciAd);
                                Console.WriteLine("Yüklenen Tedarikçi: " + tedarikciAd); 
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

        public void CihazBilgileriniGetir(int cihazid)
        {
            using (OracleConnection conn = new OracleConnection(SessionManager.Instance.ConnectionString))
            {
                conn.Open();

                string query = @"
SELECT cihazadi, tedarikciid, durum
FROM tibbicihaz 
WHERE cihazid = :cihazid";

                OracleCommand cmd = new OracleCommand(query, conn);
                cmd.Parameters.Add(new OracleParameter("cihazid", cihazid));

                OracleDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    tbxCihazAdı.Text = reader["cihazadi"].ToString();
                    int tedarikciId = Convert.ToInt32(reader["tedarikciid"]);

                    string tedarikciad = Cihaz.GetTedarikciNameById(tedarikciId);
                    Console.WriteLine("Tedarikçi Adı: " + tedarikciad);

                    cbxTedarikci.SelectedItem = tedarikciad;
                        

                    if (cbxTedarikci.SelectedItem == null)
                    {
                        MessageBox.Show("Seçili tedarikçi bulunamadı: " + tedarikciad);
                    }

                    tbxDurum.Text = reader["durum"].ToString();
                }
                else
                {
                    MessageBox.Show("Cihaz bulunamadı.");
                }

                conn.Close();
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

            string durum = tbxDurum.Text.Trim();

            UpdateCihaz(cihazid, cihazAdi, tedarikciId, durum);
        }

        private void UpdateCihaz(int cihazId, string cihazAdi, int tedarikciId, string durum)
        {
            using (OracleConnection connection = new OracleConnection(SessionManager.Instance.ConnectionString))
            {
                try
                {
                    connection.Open();
                    string query = "UPDATE tibbicihaz SET CIHAZADI = :cihazAdi, TEDARIKCIID = :tedarikciId, DURUM = :durum WHERE CIHAZID = :cihazId";

                    using (OracleCommand cmd = new OracleCommand(query, connection))
                    {
                        cmd.Parameters.Add(new OracleParameter("cihazAdi", cihazAdi));
                        cmd.Parameters.Add(new OracleParameter("tedarikciId", tedarikciId));
                        cmd.Parameters.Add(new OracleParameter("durum", durum));
                        cmd.Parameters.Add(new OracleParameter("cihazId", cihazId));

                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Cihaz başarıyla güncellendi.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Cihaz güncelleme hatası: " + ex.Message);
                }
            }
        }
    }
}
