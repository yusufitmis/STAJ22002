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
    public partial class YatakGuncelle : Form
    {
        private int yatakid;
        public YatakGuncelle(int yatakid)
        {
            InitializeComponent();
            this.yatakid = yatakid;
        }
        public YatakGuncelle()
        {
            InitializeComponent();
        }

        private void YatakGuncelle_Load(object sender, EventArgs e)
        {

        }
        public void YatakBilgileriniGetir(int yatakid)
        {
            using (OracleConnection conn = new OracleConnection(SessionManager.Instance.ConnectionString))
            {
                conn.Open();

                string query = @"
        SELECT yatakno, odaid, durum
        FROM yatak 
        WHERE yatakid = :yatakid";

                OracleCommand cmd = new OracleCommand(query, conn);
                cmd.Parameters.Add(new OracleParameter("yatakid", yatakid));

                OracleDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    tbxYatakNo.Text = reader["yatakno"].ToString();
                    tbxOdaId.Text = reader["odaid"].ToString();
                    tbxDurum.Text = reader["durum"].ToString();



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
            string yatakno = tbxYatakNo.Text.Trim();
            string odaid = tbxOdaId.Text.Trim();
            string durum = tbxDurum.Text.Trim();

            using (OracleConnection conn = new OracleConnection(SessionManager.Instance.ConnectionString))
            {
                conn.Open();

                string query = @"
                UPDATE yatak 
                SET yatakno = :yatakno, 
                    odaid = :odaid, 
                    durum = :durum
                WHERE yatakid = :yatakid";

                OracleCommand cmd = new OracleCommand(query, conn);

                cmd.Parameters.Add(new OracleParameter("yatakno", string.IsNullOrEmpty(yatakno) ? (object)DBNull.Value : yatakno));
                cmd.Parameters.Add(new OracleParameter("odaid", odaid)); // Servis ID'sini buraya ekleyin
                cmd.Parameters.Add(new OracleParameter("kdurumapasite", string.IsNullOrEmpty(durum) ? (object)DBNull.Value : durum));
                cmd.Parameters.Add(new OracleParameter("yatakid", yatakid));

                try
                {
                    int rowsUpdated = cmd.ExecuteNonQuery();
                    if (rowsUpdated > 0)
                    {
                        MessageBox.Show("Yatak bilgileri başarıyla güncellendi.");
                        this.Close();
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
