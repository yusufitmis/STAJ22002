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
    public partial class ServisGuncelle : Form
    {
        private int servisid;
        ServisIslemleri ServisIslemleri = new ServisIslemleri();

        public ServisGuncelle(int servisid)
        {
            this.servisid = servisid;
            InitializeComponent();
        }
        public ServisGuncelle()
        {
            InitializeComponent();
        }

        private void ServisGuncelle_Load(object sender, EventArgs e)
        {

        }
        public void ServisBilgileriniGetir(int servisId)
        {
            using (OracleConnection conn = new OracleConnection(SessionManager.Instance.ConnectionString))
            {
                conn.Open();

                string query = @"
            SELECT servisadi, servissorumlu, servistelno
            FROM servis 
            WHERE servisid = :servisid";

                OracleCommand cmd = new OracleCommand(query, conn);
                cmd.Parameters.Add(new OracleParameter("servisid", servisId));

                OracleDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    tbxServisad.Text = reader["servisadi"].ToString();
                    tbxServisSorumlu.Text = reader["servissorumlu"].ToString();
                    tbxDahiliTel.Text = reader["servistelno"].ToString();
                }
                else
                {
                    MessageBox.Show("Klinik bulunamadı.");
                }

                conn.Close();
            }
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            string servisAd = tbxServisad.Text.Trim();        
            string sorumlu = tbxServisSorumlu.Text.Trim();   
            string dahiliTel = tbxDahiliTel.Text.Trim();         

            using (OracleConnection conn = new OracleConnection(SessionManager.Instance.ConnectionString))
            {
                conn.Open();

                string query = @"
                UPDATE SERVIS 
                SET SERVISADI = :servisAdi, 
                    SERVISSORUMLU = :sorumlu, 
                    SERVISTELNO = :servistelno
                WHERE SERVISID = :servisId";

                OracleCommand cmd = new OracleCommand(query, conn);

                cmd.Parameters.Add(new OracleParameter("servisAdi", string.IsNullOrEmpty(servisAd) ? (object)DBNull.Value : servisAd));
                cmd.Parameters.Add(new OracleParameter("servissorumlu", string.IsNullOrEmpty(sorumlu) ? (object)DBNull.Value : sorumlu));
                cmd.Parameters.Add(new OracleParameter("servistelno", string.IsNullOrEmpty(dahiliTel) ? (object)DBNull.Value : dahiliTel));
                cmd.Parameters.Add(new OracleParameter("servisId", servisid));

                try
                {
                   
                    int rowsUpdated = cmd.ExecuteNonQuery();
                    if (rowsUpdated > 0)
                    {
                        MessageBox.Show("Servis bilgileri başarıyla güncellendi.");
                        this.Close(); 

                        
                        ServisIslemleri.ListeleServisler();
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
