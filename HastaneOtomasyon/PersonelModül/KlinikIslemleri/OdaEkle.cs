using HastaneOtomasyon.DataAccess;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HastaneOtomasyon.PersonelModül.KlinikIslemleri
{
    public partial class OdaEkle : Form
    {
        OdaIslemleri odaIslemleri = new OdaIslemleri();
        public OdaEkle()
        {
            InitializeComponent();
        }
        public void MaxOdaNumarasınıGetir()
        {
            using (OracleConnection conn = new OracleConnection(SessionManager.Instance.ConnectionString))
            {
                conn.Open();

                string query = @"
            SELECT NVL(MAX(TO_NUMBER(odano)), 0) AS maxOdaNo
            FROM odalar";

                OracleCommand cmd = new OracleCommand(query, conn);
                OracleDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    int maxOdaNo = Convert.ToInt32(reader["maxOdaNo"]);
                    tbxOdaNo.Text = (maxOdaNo + 1).ToString(); // Oda numarasını 1 artır
                }
                else
                {
                    MessageBox.Show("Oda bulunamadı.");
                }

                conn.Close();
            }
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            
            string odano = tbxOdaNo.Text.Trim();
            string odakapasitesi = tbxKapasite.Text.Trim();
            string servis = cbxServisler.SelectedItem.ToString();
            int servisid = Servis.GetServisIdByName(servis);


            using (OracleConnection conn = new OracleConnection(SessionManager.Instance.ConnectionString))
            {
                conn.Open();

                string query = @"
            INSERT INTO odalar (odano, odakapasitesi, servisid)
            VALUES (:odano, :odakapasitesi, :servisid)";

                OracleCommand cmd = new OracleCommand(query, conn);

                cmd.Parameters.Add(new OracleParameter("odano", string.IsNullOrEmpty(odano) ? (object)DBNull.Value : odano));
                cmd.Parameters.Add(new OracleParameter("odakapasitesi", string.IsNullOrEmpty(odakapasitesi) ? (object)DBNull.Value : odakapasitesi));
                cmd.Parameters.Add(new OracleParameter("servisid", servisid > 0 ? servisid : (object)DBNull.Value));


                try
                {
                    int rowsInserted = cmd.ExecuteNonQuery();
                    if (rowsInserted > 0)
                    {
                        MessageBox.Show("Oda başarıyla eklendi.");
                        this.Close();
                        
                    }
                    else
                    {
                        MessageBox.Show("Oda eklenemedi.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Veritabanı hatası: " + ex.Message);
                }

                conn.Close();
            }
        }
        private void cbxServisSec_Drop()
        {
            cbxServisler.Items.Clear();

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

                            cbxServisler.Items.Add((reader["SERVISADI"].ToString()));
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

        private void OdaEkle_Load(object sender, EventArgs e)
        {
            cbxServisSec_Drop();
            MaxOdaNumarasınıGetir();
        }
    }
}
