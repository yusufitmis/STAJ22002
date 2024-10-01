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
    public partial class YatakEkle : Form
    {
        private int odaid;
        public YatakEkle(int odaid)
        {
            InitializeComponent();
            this.odaid = odaid;
        }
        public YatakEkle()
        {
            InitializeComponent();
        }

        private void YatakEkle_Load(object sender, EventArgs e)
        {
            tbxOdaId.Text = odaid.ToString(); 
            string maxYatakNo = GetMaxYatakNoByOdaId(odaid); 

            if (maxYatakNo != "0")
            {
                string baseYatakNo = maxYatakNo.Substring(0, maxYatakNo.LastIndexOf('-') + 1); 
                int lastPart = int.Parse(maxYatakNo.Substring(maxYatakNo.LastIndexOf('-') + 1)); 
                tbxYatakNo.Text = $"{baseYatakNo}{lastPart + 1}"; 
            }
            else
            {
                tbxYatakNo.Text = $"{odaid}-1";
            }
        }
        private string GetMaxYatakNoByOdaId(int odaId)
        {
            string maxYatakNo = "0"; 

            using (OracleConnection connection = new OracleConnection(SessionManager.Instance.ConnectionString))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT NVL(MAX(YATAKNO), '0') FROM YATAK WHERE ODAID = :odaId";
                    using (OracleCommand cmd = new OracleCommand(query, connection))
                    {
                        cmd.Parameters.Add(new OracleParameter(":odaId", odaId));
                        object result = cmd.ExecuteScalar();

                        if (result != null)
                        {
                            maxYatakNo = result.ToString();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Veritabanı hatası: " + ex.Message);
                }
            }

            return maxYatakNo; 
        }

        private bool IsKapasiteDolu(int odaId)
        {
            int kapasite = 0;
            int mevcutYatakSayisi = 0;

            using (OracleConnection connection = new OracleConnection(SessionManager.Instance.ConnectionString))
            {
                try
                {
                    connection.Open();
                    string kapasiteQuery = "SELECT odakapasitesi FROM ODALAR WHERE ODAID = :odaId";
                    using (OracleCommand cmd = new OracleCommand(kapasiteQuery, connection))
                    {
                        cmd.Parameters.Add(new OracleParameter(":odaId", odaId));
                        object result = cmd.ExecuteScalar();
                        if (result != null)
                        {
                            kapasite = Convert.ToInt32(result);
                        }
                    }

                    string yatakSayisiQuery = "SELECT COUNT(*) FROM YATAK WHERE ODAID = :odaId";
                    using (OracleCommand cmd = new OracleCommand(yatakSayisiQuery, connection))
                    {
                        cmd.Parameters.Add(new OracleParameter(":odaId", odaId));
                        mevcutYatakSayisi = Convert.ToInt32(cmd.ExecuteScalar());
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Veritabanı hatası: " + ex.Message);
                }
            }

            return mevcutYatakSayisi >= kapasite;
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            string yatakNo = tbxYatakNo.Text; 
            int odaId = int.Parse(tbxOdaId.Text); 

          
            if (IsKapasiteDolu(odaId))
            {
                MessageBox.Show("Bu odaya daha fazla yatak eklenemez. Kapasite dolmuştur.");
                return; 
            }

            using (OracleConnection connection = new OracleConnection(SessionManager.Instance.ConnectionString))
            {
                try
                {
                    connection.Open();
                    string query = "INSERT INTO YATAK (YATAKNO, ODAID, DURUM) VALUES (:yatakNo, :odaId, 'Boş')";
                    using (OracleCommand cmd = new OracleCommand(query, connection))
                    {
                        cmd.Parameters.Add(new OracleParameter(":yatakNo", yatakNo));
                        cmd.Parameters.Add(new OracleParameter(":odaId", odaId));

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Yatak başarıyla eklendi.");
                        }
                        else
                        {
                            MessageBox.Show("Yatak eklenirken bir hata oluştu.");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Veritabanı hatası: " + ex.Message);
                }
            }
        }
    }
}
