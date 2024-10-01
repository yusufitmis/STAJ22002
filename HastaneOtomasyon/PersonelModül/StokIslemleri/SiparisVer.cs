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
    public partial class SiparisVer : Form
    {
        private int stokid;
        private int tedarikciid;

        public SiparisVer(int stokid, int tedarikciid)
        {
            InitializeComponent();
            this.stokid = stokid;
            this.tedarikciid = tedarikciid;
        }
        public SiparisVer()
        {
            InitializeComponent();
        }

        private void SiparisVer_Load(object sender, EventArgs e)
        {

        }

        private void AddSiparisToDatabase(int stokId, int tedarikciId, int miktar, DateTime siparisTarihi, DateTime teslimTarihi)
        {
            using (OracleConnection connection = new OracleConnection(SessionManager.Instance.ConnectionString))
            {
                try
                {
                    connection.Open();
                    string query = "INSERT INTO SIPARIS (STOKID, TEDARIKCIID, MIKTAR, SIPARISTARIHI, TESLIMTARIHI, SIPARISDURUMU) " +
                                   "VALUES (:stokId, :tedarikciId, :miktar, :siparisTarihi, :teslimTarihi, 'Teslim Edilmedi')";

                    using (OracleCommand cmd = new OracleCommand(query, connection))
                    {
                        cmd.Parameters.Add(new OracleParameter("stokId", stokId));
                        cmd.Parameters.Add(new OracleParameter("tedarikciId", tedarikciId));
                        cmd.Parameters.Add(new OracleParameter("miktar", miktar));
                        cmd.Parameters.Add(new OracleParameter("siparisTarihi", siparisTarihi));
                        cmd.Parameters.Add(new OracleParameter("teslimTarihi", teslimTarihi));

                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Sipariş başarıyla eklendi.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Sipariş ekleme hatası: " + ex.Message);
                }
            }
        }

        private void btnKaydet_Click_1(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbxMiktar.Text) || !int.TryParse(tbxMiktar.Text, out int miktar) || miktar <= 0)
            {
                MessageBox.Show("Lütfen geçerli bir miktar girin.");
                return;
            }

            DateTime siparisTarihi = DateTime.Now;
            DateTime teslimTarihi = siparisTarihi.AddMonths(1);

            AddSiparisToDatabase(stokid, tedarikciid, miktar, siparisTarihi, teslimTarihi);
        }
    }
}
