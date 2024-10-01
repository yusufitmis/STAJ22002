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
    public partial class SiparisDetay : Form
    {
        private int stokid;
        public SiparisDetay(int stokid)
        {
            InitializeComponent();
            this.stokid = stokid;
        }
        public SiparisDetay()
        {
            InitializeComponent();
        }

        private void SiparisDetay_Load(object sender, EventArgs e)
        {
            SiparisDetaylariniYukle(stokid);
        }
        private void SiparisDetaylariniYukle(int stokId)
        {
            try
            {
                using (OracleConnection connection = new OracleConnection(DataAccess.SessionManager.Instance.ConnectionString))
                {
                    connection.Open();

                    string query = @"
                SELECT 
                    SIPARIS.SIPARISID,
                    S.URUNADI AS URUNAD, 
                    S.URUNTURU AS URUNTURU, 
                    T.TEDARIKCIAD AS TEDARIKCIAD,
                    SIPARIS.MIKTAR, 
                    SIPARIS.SIPARISTARIHI, 
                    SIPARIS.TESLIMTARIHI, 
                    SIPARIS.SIPARISDURUMU 
                FROM 
                    SIPARIS 
                INNER JOIN 
                    STOK S ON SIPARIS.STOKID = S.STOKID
                INNER JOIN 
                    TEDARIKCI T ON SIPARIS.TEDARIKCIID = T.TEDARIKCIID
                WHERE 
                    S.STOKID = :stokId";

                    OracleCommand command = new OracleCommand(query, connection);
                    command.Parameters.Add(":stokId", OracleDbType.Int32).Value = stokId;

                    using (OracleDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            lblSiparisid.Text = reader["SIPARISID"] != DBNull.Value ? reader["SIPARISID"].ToString() : "Bilgi Yok";
                            lblUrunAdı.Text = reader["URUNAD"] != DBNull.Value ? reader["URUNAD"].ToString() : "Bilgi Yok";
                            lblUrunTuru.Text = reader["URUNTURU"] != DBNull.Value ? reader["URUNTURU"].ToString() : "Bilgi Yok";
                            LblTedarikci.Text = reader["TEDARIKCIAD"] != DBNull.Value ? reader["TEDARIKCIAD"].ToString() : "Bilgi Yok";
                            lblMiktar.Text = reader["MIKTAR"] != DBNull.Value ? reader["MIKTAR"].ToString() : "Bilgi Yok";

                            if (reader["SIPARISTARIHI"] != DBNull.Value)
                            {
                                lblSiparisTarihi.Text = Convert.ToDateTime(reader["SIPARISTARIHI"]).ToString("dd/MM/yyyy");
                            }
                            else
                            {
                                lblSiparisTarihi.Text = "Tarih Bilinmiyor";
                            }

                            if (reader["TESLIMTARIHI"] != DBNull.Value)
                            {
                                lblTeslimTarihi.Text = Convert.ToDateTime(reader["TESLIMTARIHI"]).ToString("dd/MM/yyyy");
                            }
                            else
                            {
                                lblTeslimTarihi.Text = "Tarih Bilinmiyor";
                            }

                            lblSiparisDurumu.Text = reader["SIPARISDURUMU"] != DBNull.Value ? reader["SIPARISDURUMU"].ToString() : "Bilgi Yok";
                        }
                        else
                        {
                            MessageBox.Show("Sipariş detayları bulunamadı.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Bilgileri yüklerken bir hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



    }
}
