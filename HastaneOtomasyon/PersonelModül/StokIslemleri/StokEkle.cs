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
    public partial class StokEkle : Form
    {
        public StokEkle()
        {
            InitializeComponent();
        }

        private void StokEkle_Load(object sender, EventArgs e)
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

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            string urunAdi = tbxxUrunAd.Text;
            string urunTuru = cbxUrunTuru.SelectedItem.ToString();
            int miktar;

            if (!int.TryParse(tbxMiktar.Text, out miktar))
            {
                MessageBox.Show("Lütfen geçerli bir miktar girin.");
                return;
            }

            if (cbxTedarikci.SelectedItem == null)
            {
                MessageBox.Show("Lütfen bir tedarikçi seçin.");
                return;
            }

            string tedarikciAdi = cbxTedarikci.SelectedItem.ToString(); 
            DateTime sonGuncellemeTarihi = DateTime.Now.Date; 

            string query = "INSERT INTO stok (URUNADI, URUNTURU, MIKTAR, TEDARIKCIID, SONGUNCELLEMETARIHI) " +
                           "VALUES (:urunAdi, :urunTuru, :miktar, (SELECT TEDARIKCIID FROM TEDARIKCI WHERE TEDARIKCIAD = :tedarikciAdi), :sonGuncellemeTarihi)";

            using (OracleConnection conn = new OracleConnection(SessionManager.Instance.ConnectionString))
            {
                try
                {
                    conn.Open();

                    using (OracleCommand cmd = new OracleCommand(query, conn))
                    {
                        
                        cmd.Parameters.Add(new OracleParameter("urunAdi", urunAdi));
                        cmd.Parameters.Add(new OracleParameter("urunTuru", urunTuru));
                        cmd.Parameters.Add(new OracleParameter("miktar", miktar));
                        cmd.Parameters.Add(new OracleParameter("tedarikciAdi", tedarikciAdi));  // Tedarikçi adıyla ID'yi buluyoruz
                        cmd.Parameters.Add(new OracleParameter("sonGuncellemeTarihi", sonGuncellemeTarihi));

                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Ürün başarıyla eklendi!");
                        }
                        else
                        {
                            MessageBox.Show("Ürün eklenemedi.");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hata: " + ex.Message);
                }
            }
        }

    }
}
