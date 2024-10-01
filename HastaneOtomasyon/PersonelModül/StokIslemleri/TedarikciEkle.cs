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
    public partial class TedarikciEkle : Form
    {
        public TedarikciEkle()
        {
            InitializeComponent();
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

            AddTedarikci(tedarikciAd, adres, telefon, eposta, temsilciAdi);
        }

        private void AddTedarikci(string tedarikciAd, string adres, string telefon, string eposta, string temsilciAdi)
        {
            using (OracleConnection connection = new OracleConnection(SessionManager.Instance.ConnectionString))
            {
                try
                {
                    connection.Open();
                    string query = "INSERT INTO tedarikci (TEDARIKCIAD, ADRES, TELEFON, EPOSTA, TEMSILCIADI) " +
                                   "VALUES (:tedarikciAd, :adres, :telefon, :eposta, :temsilciAdi)";

                    using (OracleCommand cmd = new OracleCommand(query, connection))
                    {
                        cmd.Parameters.Add(new OracleParameter("tedarikciAd", tedarikciAd));
                        cmd.Parameters.Add(new OracleParameter("adres", adres));
                        cmd.Parameters.Add(new OracleParameter("telefon", telefon));
                        cmd.Parameters.Add(new OracleParameter("eposta", eposta));
                        cmd.Parameters.Add(new OracleParameter("temsilciAdi", temsilciAdi));

                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Tedarikçi başarıyla eklendi.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Tedarikçi ekleme hatası: " + ex.Message);
                }
            }
        }
        private void TedarikciEkle_Load(object sender, EventArgs e)
        {
           
        }
    }
}
