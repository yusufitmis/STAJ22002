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
    public partial class OdaGuncelle : Form
    {
        private int odaid;
        public OdaGuncelle(int odaid)
        {
            InitializeComponent();
            this.odaid = odaid;
        }
        public OdaGuncelle()
        {
            InitializeComponent();
        }

        private void OdaGuncelle_Load(object sender, EventArgs e)
        {
            cbxServisSec_Drop();
        }
        public void OdaBilgileriniGetir(int odaid)
        {
            using (OracleConnection conn = new OracleConnection(SessionManager.Instance.ConnectionString))
            {
                conn.Open();

                string query = @"
        SELECT odano, odakapasitesi, servisid
        FROM odalar 
        WHERE odaid = :odaid";

                OracleCommand cmd = new OracleCommand(query, conn);
                cmd.Parameters.Add(new OracleParameter("odaid", odaid));

                OracleDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    tbxOdaNo.Text = reader["odano"].ToString();
                    tbxKapasite.Text = reader["odakapasitesi"].ToString();
                               
                    cbxServisler.SelectedItem = Servis.GetServisNameById(Convert.ToInt32(reader["servisid"]));
                    
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
            string kapasite = tbxKapasite.Text.Trim();
            string servisAdi = cbxServisler.SelectedItem.ToString();

          
            int servisId = Servis.GetServisIdByName(servisAdi);

            using (OracleConnection conn = new OracleConnection(SessionManager.Instance.ConnectionString))
            {
                conn.Open();

                string query = @"
        UPDATE odalar 
        SET odano = :odano, 
            servisid = :servis, 
            odakapasitesi = :kapasite
        WHERE odaid = :odaid";

                OracleCommand cmd = new OracleCommand(query, conn);

                cmd.Parameters.Add(new OracleParameter("odano", string.IsNullOrEmpty(odano) ? (object)DBNull.Value : odano));
                cmd.Parameters.Add(new OracleParameter("servis", servisId)); // Servis ID'sini buraya ekleyin
                cmd.Parameters.Add(new OracleParameter("kapasite", string.IsNullOrEmpty(kapasite) ? (object)DBNull.Value : kapasite));
                cmd.Parameters.Add(new OracleParameter("odaid", odaid));

                try
                {
                    int rowsUpdated = cmd.ExecuteNonQuery();
                    if (rowsUpdated > 0)
                    {
                        MessageBox.Show("Oda bilgileri başarıyla güncellendi.");
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
    }
}
