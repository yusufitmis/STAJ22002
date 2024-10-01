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
    public partial class ServisEkle : Form
    {
        public ServisEkle()
        {
            InitializeComponent();
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
    INSERT INTO SERVIS (SERVISADI, SERVISSORUMLU, SERVISTELNO)
    VALUES (:servisAd, :sorumlu, :dahiliTel)";

                OracleCommand cmd = new OracleCommand(query, conn);

                cmd.Parameters.Add(new OracleParameter("servisAd", string.IsNullOrEmpty(servisAd) ? (object)DBNull.Value : servisAd));
                cmd.Parameters.Add(new OracleParameter("sorumlu", string.IsNullOrEmpty(sorumlu) ? (object)DBNull.Value : sorumlu));
                cmd.Parameters.Add(new OracleParameter("dahiliTel", string.IsNullOrEmpty(dahiliTel) ? (object)DBNull.Value : dahiliTel));

                try
                {
                    int rowsInserted = cmd.ExecuteNonQuery();
                    if (rowsInserted > 0)
                    {
                        MessageBox.Show("Servis başarıyla eklendi.");
                        this.Close(); 
                    }
                    else
                    {
                        MessageBox.Show("Servis eklenemedi.");
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
