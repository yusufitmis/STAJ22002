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
    public partial class KlinikEkle : Form
    {
        KlinikIslemleri klinikIslemleri = new KlinikIslemleri();
        public KlinikEkle()
        {
            InitializeComponent();
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            string klinikAd = tbxKlinikAd.Text.Trim();
            string ucret = tbxUcret.Text.Trim();
            string dahiliTel = tbxDahiliTel.Text.Trim();
            string limit = tbxLimit.Text.Trim();

            using (OracleConnection conn = new OracleConnection(SessionManager.Instance.ConnectionString))
            {
                conn.Open();

                string query = @"
            INSERT INTO KLINIK (KLINIKAD, KLINIKUCRET, DAHILITEL, LIMIT)
            VALUES (:klinikAd, :ucret, :dahiliTel, :limit)";

                OracleCommand cmd = new OracleCommand(query, conn);

                cmd.Parameters.Add(new OracleParameter("klinikAd", string.IsNullOrEmpty(klinikAd) ? (object)DBNull.Value : klinikAd));
                cmd.Parameters.Add(new OracleParameter("ucret", string.IsNullOrEmpty(ucret) ? (object)DBNull.Value : ucret));
                cmd.Parameters.Add(new OracleParameter("dahiliTel", string.IsNullOrEmpty(dahiliTel) ? (object)DBNull.Value : dahiliTel));
                cmd.Parameters.Add(new OracleParameter("limit", string.IsNullOrEmpty(limit) ? (object)DBNull.Value : limit));

                try
                {
                    int rowsInserted = cmd.ExecuteNonQuery();
                    if (rowsInserted > 0)
                    {
                        MessageBox.Show("Klinik başarıyla eklendi.");
                        this.Close();
                        klinikIslemleri.KlinikBilgileriniListele();
                    }
                    else
                    {
                        MessageBox.Show("Klinik eklenemedi.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Veritabanı hatası: " + ex.Message);
                }

                conn.Close();
            }
        }

        private void KlinikEkle_Load(object sender, EventArgs e)
        {

        }
    }
}
