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
    public partial class TedarikciGuncelle : Form
    {

        private int tedarikciid;
        public TedarikciGuncelle(int tedarikciid)
        {
            InitializeComponent();
            this.tedarikciid = tedarikciid;
        }
        public TedarikciGuncelle()
        {
            InitializeComponent();
        }

        private void TedarikciGuncelle_Load(object sender, EventArgs e)
        {

        }

        public void TedarikciBilgileriniGetir(int tedarikciId)
        {
            using (OracleConnection conn = new OracleConnection(SessionManager.Instance.ConnectionString))
            {
                conn.Open();

                string query = @"
SELECT tedarikciad, adres, telefon, eposta, temsilciadi
FROM tedarikci 
WHERE tedarikciid = :tedarikciId";

                OracleCommand cmd = new OracleCommand(query, conn);
                cmd.Parameters.Add(new OracleParameter("tedarikciId", tedarikciId));

                OracleDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    tbxTedarikciAd.Text = reader["tedarikciad"].ToString();
                    tbxAdres.Text = reader["adres"].ToString();
                    tbxTelefon.Text = reader["telefon"].ToString();
                    tbxEposta.Text = reader["eposta"].ToString();
                    tbxTemsilci.Text = reader["temsilciadi"].ToString();
                }
                else
                {
                    MessageBox.Show("Tedarikçi bulunamadı.");
                }

                conn.Close();
            }
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            string tedarikciAd = tbxTedarikciAd.Text.Trim();
            string adres = tbxAdres.Text.Trim();
            string telefon = tbxTelefon.Text.Trim();
            string eposta = tbxEposta.Text.Trim();
            string temsilciAdi = tbxTemsilci.Text.Trim();

            if (string.IsNullOrWhiteSpace(tedarikciAd) || string.IsNullOrWhiteSpace(adres) ||
                string.IsNullOrWhiteSpace(telefon) || string.IsNullOrWhiteSpace(eposta) || string.IsNullOrWhiteSpace(temsilciAdi))
            {
                MessageBox.Show("Lütfen tüm alanları doldurunuz.");
                return;
            }

            UpdateTedarikci(tedarikciid, tedarikciAd, adres, telefon, eposta, temsilciAdi);
        }
        private void UpdateTedarikci(int tedarikciId, string tedarikciAd, string adres, string telefon, string eposta, string temsilciAdi)
        {
            using (OracleConnection connection = new OracleConnection(SessionManager.Instance.ConnectionString))
            {
                try
                {
                    connection.Open();
                    string query = "UPDATE tedarikci SET TEDARIKCIAD = :tedarikciAd, ADRES = :adres, TELEFON = :telefon, EPOSTA = :eposta, TEMSILCIADI = :temsilciAdi WHERE TEDARIKCIID = :tedarikciId";

                    using (OracleCommand cmd = new OracleCommand(query, connection))
                    {
                        cmd.Parameters.Add(new OracleParameter("tedarikciAd", tedarikciAd));
                        cmd.Parameters.Add(new OracleParameter("adres", adres));
                        cmd.Parameters.Add(new OracleParameter("telefon", telefon));
                        cmd.Parameters.Add(new OracleParameter("eposta", eposta));
                        cmd.Parameters.Add(new OracleParameter("temsilciAdi", temsilciAdi));
                        cmd.Parameters.Add(new OracleParameter("tedarikciId", tedarikciId));

                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Tedarikçi başarıyla güncellendi.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Tedarikçi güncelleme hatası: " + ex.Message);
                }
            }
        }


    }
}
