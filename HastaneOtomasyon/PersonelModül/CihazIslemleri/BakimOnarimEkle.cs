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

namespace HastaneOtomasyon.PersonelModül.CihazIslemleri
{
    public partial class BakimOnarimEkle : Form
    {
        public BakimOnarimEkle()
        {
            InitializeComponent();
        }

        private void BakimOnarimEkle_Load(object sender, EventArgs e)
        {
            LoadPersonel();
        }
        private void LoadPersonel()
        {
            using (OracleConnection connection = new OracleConnection(SessionManager.Instance.ConnectionString))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT PERSONELID, personelAD, personelSOYAD FROM PERSONEL WHERE UNVANID = 5";
                    using (OracleCommand cmd = new OracleCommand(query, connection))
                    {
                        using (OracleDataReader reader = cmd.ExecuteReader())
                        {
                            
                            while (reader.Read())
                            {
                                string personelAdSoyad = reader["personelAD"].ToString() + " " + reader["personelSOYAD"].ToString();
                                int personelId = Convert.ToInt32(reader["PERSONELID"]);

                                cbxPersonel.Items.Add(new KeyValuePair<string, int>(personelAdSoyad, personelId));
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Personel yükleme hatası: " + ex.Message);
                }
            }
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            int cihazId;
            if (!int.TryParse(tbxCihazAdı.Text.Trim(), out cihazId))
            {
                MessageBox.Show("Geçerli bir Cihaz ID giriniz.");
                return;
            }

            DateTime bakimTarihi = dtpBakimTarihi.Value;
            DateTime? sonrakiBakimTarihi = dtpSonrakiBakimTarihi.Checked ? (DateTime?)dtpSonrakiBakimTarihi.Value : null;

            string bakimTuru = cbxBakimTuru.SelectedItem?.ToString();
            string bakimDurumu = cbxBakimDurumu.SelectedItem?.ToString();
            string aciklama = tbxAciklama.Text.Trim();

            var selectedPersonel = cbxPersonel.SelectedItem as KeyValuePair<string, int>?;
            int? personelId = selectedPersonel?.Value;

            if (string.IsNullOrWhiteSpace(bakimTuru))
            {
                MessageBox.Show("Lütfen bakım türünü seçiniz.");
                return;
            }

            AddBakimOnarim(cihazId, bakimTarihi, bakimTuru, sonrakiBakimTarihi, personelId, bakimDurumu, aciklama);
        }

        private void AddBakimOnarim(int cihazId, DateTime bakimTarihi, string bakimTuru, DateTime? sonrakiBakimTarihi, int? personelId, string bakimDurumu, string aciklama)
        {
            using (OracleConnection connection = new OracleConnection(SessionManager.Instance.ConnectionString))
            {
                try
                {
                    connection.Open();
                    string query = @"
        INSERT INTO BAKIMONARIM (CIHAZID, BAKIMTARIHI, BAKIMTURU, SSONRAKIBAKIMTARIHI, SORUMLUPERSONELID, BAKIMDURUMU, ACIKLAMA) 
        VALUES (:cihazId, :bakimTarihi, :bakimTuru, :sonrakiBakimTarihi, :personelId, :bakimDurumu, :aciklama)";

                    using (OracleCommand cmd = new OracleCommand(query, connection))
                    {
                        cmd.Parameters.Add(new OracleParameter("cihazId", cihazId));
                        cmd.Parameters.Add(new OracleParameter("bakimTarihi", bakimTarihi));
                        cmd.Parameters.Add(new OracleParameter("bakimTuru", bakimTuru));
                        cmd.Parameters.Add(new OracleParameter("sonrakiBakimTarihi", sonrakiBakimTarihi.HasValue ? (object)sonrakiBakimTarihi.Value : DBNull.Value));
                        cmd.Parameters.Add(new OracleParameter("personelId", personelId ?? (object)DBNull.Value));
                        cmd.Parameters.Add(new OracleParameter("bakimDurumu", string.IsNullOrWhiteSpace(bakimDurumu) ? (object)DBNull.Value : bakimDurumu));
                        cmd.Parameters.Add(new OracleParameter("aciklama", string.IsNullOrWhiteSpace(aciklama) ? (object)DBNull.Value : aciklama));

                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Bakım/Onarım başarıyla kaydedildi.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Bakım/Onarım kaydetme hatası: " + ex.Message);
                }
            }
        }

    }
}
