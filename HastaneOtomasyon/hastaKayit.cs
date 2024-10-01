
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

namespace HastaneOtomasyon
{
    public partial class hastaKayit : Form
    {
        public hastaKayit()
        {
            InitializeComponent();
        }

        private void gunaLabel5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void hastaKayit_Load(object sender, EventArgs e)
        {
            tbxTcNo.Text = "TC No";
            tbxTcNo.ForeColor = Color.Gray;

            tbxAd.Text = "Ad";
            tbxAd.ForeColor = Color.Gray;

            tbxSoyad.Text = "Soyad";
            tbxSoyad.ForeColor = Color.Gray;

            tbxTelefon.Text = "Telefon";
            tbxTelefon.ForeColor = Color.Gray;

            tbxEposta.Text = "E-Posta";
            tbxEposta.ForeColor = Color.Gray;

            tbxParola.Text = "Parola";
            tbxParola.ForeColor = Color.Gray;


        }


        private void txtBoxHastaKayitTcno_Enter(object sender, EventArgs e)
        {
            if (tbxTcNo.Text == "TC No")
            {
                tbxTcNo.Text = "";
                tbxTcNo.ForeColor = Color.Black;
            }
        }

        private void txtBoxHastaKayitTcno_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbxTcNo.Text))
            {
                tbxTcNo.Text = "TC No";
                tbxTcNo.ForeColor = Color.Gray;
            }
        }

        private void txtBoxHastaKayitAd_Enter(object sender, EventArgs e)
        {
            if (tbxAd.Text == "Ad")
            {
                tbxAd.Text = "";
                tbxAd.ForeColor = Color.Black;
            }
        }

        private void txtBoxHastaKayitAd_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbxAd.Text))
            {
                tbxAd.Text = "Ad";
                tbxAd.ForeColor = Color.Gray;
            }
        }

        private void txtBoxHastaKayitSoyad_Enter(object sender, EventArgs e)
        {
            if (tbxSoyad.Text == "Soyad")
            {
                tbxSoyad.Text = "";
                tbxSoyad.ForeColor = Color.Black;
            }
        }

        private void txtBoxHastaKayitSoyad_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbxSoyad.Text))
            {
                tbxSoyad.Text = "Soyad";
                tbxSoyad.ForeColor = Color.Gray;
            }
        }

        private void txtBoxHastaKayitTelefon_Enter(object sender, EventArgs e)
        {
            if (tbxTelefon.Text == "Telefon")
            {
                tbxTelefon.Text = "";
                tbxTelefon.ForeColor = Color.Black;
            }
        }

        private void txtBoxHastaKayitTelefon_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbxTelefon.Text))
            {
                tbxTelefon.Text = "Telefon";
                tbxTelefon.ForeColor = Color.Gray;
            }
        }

        private void txtBoxHastaKayitEposta_Enter(object sender, EventArgs e)
        {
            if (tbxEposta.Text == "E-Posta")
            {
                tbxEposta.Text = "";
                tbxEposta.ForeColor = Color.Black;
            }
        }

        private void txtBoxHastaKayitEposta_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbxEposta.Text))
            {
                tbxEposta.Text = "E-Posta";
                tbxEposta.ForeColor = Color.Gray;
            }
        }
        private void tbxParola_Enter(object sender, EventArgs e)
        {
            if (tbxParola.Text == "Parola")
            {
                tbxParola.Text = "";
                tbxParola.ForeColor = Color.Black;
            }
        }

        private void tbxParola_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbxParola.Text))
            {
                tbxParola.Text = "Parola";
                tbxParola.ForeColor = Color.Gray;
            }
        }

        private void pbBack_Click(object sender, EventArgs e)
        {
            ;

            // login formu oluşturuluyor ve userService parametresi ile başlatılıyor
            login loginForm = new login();
            loginForm.Show();
            this.Hide();
        }

        private void btnKayıtol_Click(object sender, EventArgs e)
        {
            string tcNo = tbxTcNo.Text.Trim();
            string ad = tbxAd.Text.Trim();
            string soyad = tbxSoyad.Text.Trim();
            string telefon = tbxTelefon.Text.Trim();
            string eposta = tbxEposta.Text.Trim();
            string cinsiyet = cbxCinsiyet.SelectedItem.ToString();
            string sosyalGuvence = cbxSosyalGüvence.SelectedItem.ToString();
            string adres = tbxAdres.Text.Trim();
            DateTime dogumTarihi = dtpDTarihi.Value;
            string parola = tbxParola.Text.Trim();


            if (HastaVarMi(tcNo))
            {
                MessageBox.Show("Bu TC numarasıyla kayıtlı bir hasta zaten mevcut!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                HastaKaydet(tcNo, ad, soyad, telefon, eposta, cinsiyet, sosyalGuvence, adres, dogumTarihi,parola);
                MessageBox.Show("Hasta kaydı başarılı!", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Temizle();
            }
        }
        private bool HastaVarMi(string tcNo)
        {
            bool varMi = false;
            
            string sql = "SELECT COUNT(*) FROM HASTA WHERE HASTATCNO = :tcNo";

            using (OracleConnection conn = new OracleConnection(SessionManager.Instance.ConnectionString))
            {
                using (OracleCommand cmd = new OracleCommand(sql, conn))
                {
                    cmd.Parameters.Add(":tcNo", OracleDbType.Varchar2).Value = tcNo;
                    conn.Open();

                    int count = Convert.ToInt32(cmd.ExecuteScalar());
                    varMi = count > 0;
                }
            }

            return varMi;
        }

        private void HastaKaydet(string tcNo, string ad, string soyad, string telefon, string eposta, string cinsiyet, string sosyalGuvence, string adres, DateTime dogumTarihi,string parola)
        {
  
            string sql = "INSERT INTO HASTA (HASTATCNO, HASTALAD, HASTASOYAD, HASTATELNO, HASTAEPOSTA, HASTACINSIYET, SOSYALGUVENCE, HASTAADRES, HASTADTARIHI,parola) " +
                         "VALUES (:tcNo, :ad, :soyad, :telefon, :eposta, :cinsiyet, :sosyalGuvence, :adres, :dogumTarihi, :parola)";

            using (OracleConnection conn = new OracleConnection(SessionManager.Instance.ConnectionString))
            {
                using (OracleCommand cmd = new OracleCommand(sql, conn))
                {
                    cmd.Parameters.Add(":tcNo", OracleDbType.Char).Value = tcNo;
                    cmd.Parameters.Add(":ad", OracleDbType.Varchar2).Value = ad;
                    cmd.Parameters.Add(":soyad", OracleDbType.Varchar2).Value = soyad;
                    cmd.Parameters.Add(":telefon", OracleDbType.Char).Value = telefon;
                    cmd.Parameters.Add(":eposta", OracleDbType.Varchar2).Value = eposta;
                    cmd.Parameters.Add(":cinsiyet", OracleDbType.Char).Value = cinsiyet;
                    cmd.Parameters.Add(":sosyalGuvence", OracleDbType.Varchar2).Value = sosyalGuvence;
                    cmd.Parameters.Add(":adres", OracleDbType.Varchar2).Value = adres;
                    cmd.Parameters.Add(":dogumTarihi", OracleDbType.Date).Value = dogumTarihi;
                    cmd.Parameters.Add(":parola", OracleDbType.Varchar2).Value = parola;


                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        private void Temizle()
        {
            tbxTcNo.Text = "TC No";
            tbxAd.Text = "Ad";
            tbxSoyad.Text = "Soyad";
            tbxTelefon.Text = "Telefon";
            tbxEposta.Text = "E-Posta";
            tbxAdres.Text="";
            tbxParola.Text = "";
            dtpDTarihi.Value = DateTime.Today;
            cbxCinsiyet.SelectedIndex = -1;
            cbxSosyalGüvence.SelectedIndex = -1;
        }

        
    }
}
