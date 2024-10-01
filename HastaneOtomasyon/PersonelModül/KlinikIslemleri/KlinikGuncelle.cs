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
    public partial class KlinikGuncelle : Form
    {
        private int klinikid; 
        KlinikIslemleri klinikIslemleri = new KlinikIslemleri();
        public KlinikGuncelle(int klinikid) 
        {
            InitializeComponent();
            this.klinikid = klinikid;
        }
        public KlinikGuncelle()
        {
            InitializeComponent();
        }

        private void KlinikGuncelle_Load(object sender, EventArgs e)
        {

        }
        public void KlinikBilgileriniGetir(int klinikId)
        {
            using (OracleConnection conn = new OracleConnection(SessionManager.Instance.ConnectionString))
            {
                conn.Open();

                string query = @"
            SELECT KLINIKAD, KLINIKUCRET, DAHILITEL, LIMIT 
            FROM KLINIK 
            WHERE KLINIKID = :klinikId";

                OracleCommand cmd = new OracleCommand(query, conn);
                cmd.Parameters.Add(new OracleParameter("klinikId", klinikId));

                OracleDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    tbxKlinikAd.Text = reader["KLINIKAD"].ToString();
                    tbxUcret.Text = reader["KLINIKUCRET"].ToString();
                    tbxDahiliTel.Text = reader["DAHILITEL"].ToString();
                    tbxLimit.Text = reader["LIMIT"].ToString();
                }
                else
                {
                    MessageBox.Show("Klinik bulunamadı.");
                }

                conn.Close();
            }
        }


        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            
            string klinikAd = tbxKlinikAd.Text.Trim();
            string ucret = tbxUcret.Text.Trim();
            string dahiliTel = tbxDahiliTel.Text.Trim();
            string limit = tbxLimit.Text.Trim();

            using (OracleConnection conn = new OracleConnection(SessionManager.Instance.ConnectionString))
            {
                conn.Open();

                string query = @"
            UPDATE KLINIK 
            SET KLINIKAD = :klinikAd, 
                KLINIKUCRET = :ucret, 
                DAHILITEL = :dahiliTel, 
                LIMIT = :limit 
            WHERE KLINIKID = :klinikId";

                OracleCommand cmd = new OracleCommand(query, conn);
                cmd.Parameters.Add(new OracleParameter("klinikAd", klinikAd));
                cmd.Parameters.Add(new OracleParameter("ucret", ucret));
                cmd.Parameters.Add(new OracleParameter("dahiliTel", dahiliTel));
                cmd.Parameters.Add(new OracleParameter("limit", limit));
                cmd.Parameters.Add(new OracleParameter("klinikId", klinikid));

                try
                {
                    int rowsUpdated = cmd.ExecuteNonQuery();
                    if (rowsUpdated > 0)
                    {
                        MessageBox.Show("Klinik bilgileri başarıyla güncellendi.");
                        this.Close();
                        klinikIslemleri.KlinikBilgileriniListele();

                    }
                    else
                    {
                        MessageBox.Show("Güncelleme işlemi sırasında bir hata oluştu.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Veritabanı hatası: " + ex.Message);
                }

                conn.Close();
            }
        }

    }
}
