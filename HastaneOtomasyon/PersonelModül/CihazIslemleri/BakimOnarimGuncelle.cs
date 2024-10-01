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
    public partial class BakimOnarimGuncelle : Form
    {
        private int bakimOnarimID;

        public BakimOnarimGuncelle(int id)
        {
            InitializeComponent();
            this.bakimOnarimID = id;
            LoadBakimOnarimData();
        }
        public BakimOnarimGuncelle()
        {
            InitializeComponent();
        }

        private void BakimOnarimGuncelle_Load(object sender, EventArgs e)
        {
            LoadPersonelList();
        }
        private void LoadBakimOnarimData()
        {
            using (OracleConnection connection = new OracleConnection(SessionManager.Instance.ConnectionString))
            {
                try
                {
                    connection.Open();
                    string query = @"
                SELECT CIHAZID, BAKIMTARIHI, BAKIMTURU, SSONRAKIBAKIMTARIHI, SORUMLUPERSONELID, BAKIMDURUMU, ACIKLAMA
                FROM BAKIMONARIM
                WHERE BAKIMONARIMID = :bakimOnarimID";

                    using (OracleCommand cmd = new OracleCommand(query, connection))
                    {
                        cmd.Parameters.Add(new OracleParameter("bakimOnarimID", this.bakimOnarimID));

                        using (OracleDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                tbxCihazAdı.Text = reader["CIHAZID"].ToString();
                                dtpBakimTarihi.Value = Convert.ToDateTime(reader["BAKIMTARIHI"]);
                                cbxBakimTuru.SelectedItem = reader["BAKIMTURU"].ToString();

                                if (reader["SSONRAKIBAKIMTARIHI"] != DBNull.Value)
                                    dtpSonrakiBakimTarihi.Value = Convert.ToDateTime(reader["SSONRAKIBAKIMTARIHI"]);

                                var personelId = reader["SORUMLUPERSONELID"];
                                if (personelId != DBNull.Value)
                                {
                                    // Personel ID'ye göre ComboBox'ta uygun öğeyi seçiyoruz
                                    int id = Convert.ToInt32(personelId);
                                    foreach (var item in cbxPersonel.Items.Cast<KeyValuePair<string, int>>())
                                    {
                                        if (item.Value == id)
                                        {
                                            cbxPersonel.SelectedItem = item;
                                            break;
                                        }
                                    }
                                }

                                cbxBakimDurumu.SelectedItem = reader["BAKIMDURUMU"].ToString();
                                tbxAciklama.Text = reader["ACIKLAMA"].ToString();
                            }
                            else
                            {
                                MessageBox.Show("Bakım/Onarım kaydı bulunamadı.");
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Veri yükleme hatası: " + ex.Message);
                }
            }
        }
        private void LoadPersonelList()
        {
            using (OracleConnection connection = new OracleConnection(SessionManager.Instance.ConnectionString))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT PERSONELID, PERSONELAD, personelsoyad FROM PERSONEL where unvanid=5"; 

                    using (OracleCommand cmd = new OracleCommand(query, connection))
                    {
                        using (OracleDataReader reader = cmd.ExecuteReader())
                        {
                            Dictionary<string, int> personelList = new Dictionary<string, int>();

                            while (reader.Read())
                            {
                                string personelfullname = reader["PERSONELAD"].ToString() + ' ' + reader["PERSONELSOYAD"].ToString();
                                int personelId = Convert.ToInt32(reader["PERSONELID"]);

                                
                                if (!personelList.ContainsKey(personelfullname))
                                {
                                    personelList.Add(personelfullname, personelId);
                                }
                                else
                                {
                                    
                                }
                            }

                           
                            cbxPersonel.DataSource = new BindingSource(personelList, null);
                            cbxPersonel.DisplayMember = "Key"; 
                            cbxPersonel.ValueMember = "Value"; 
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Personel listesi yüklenemedi: " + ex.Message);
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
            int? personelId = selectedPersonel != null ? (int?)selectedPersonel.Value.Value : null;

            if (string.IsNullOrWhiteSpace(bakimTuru))
            {
                MessageBox.Show("Lütfen bakım türünü seçiniz.");
                return;
            }

            if (sonrakiBakimTarihi.HasValue && sonrakiBakimTarihi <= bakimTarihi)
            {
                MessageBox.Show("Sonraki bakım tarihi, bakım tarihinden büyük olmalıdır.");
                return;
            }

            UpdateBakimOnarim(cihazId, bakimTarihi, bakimTuru, sonrakiBakimTarihi, personelId, bakimDurumu, aciklama);
        }

        private void UpdateBakimOnarim(int cihazId, DateTime bakimTarihi, string bakimTuru, DateTime? sonrakiBakimTarihi, int? personelId, string bakimDurumu, string aciklama)
        {
            using (OracleConnection connection = new OracleConnection(SessionManager.Instance.ConnectionString))
            {
                try
                {
                    connection.Open();

                    string updateBakimOnarimQuery = @"
                    UPDATE BAKIMONARIM 
                    SET CIHAZID = :cihazId, 
                        BAKIMTARIHI = :bakimTarihi, 
                        BAKIMTURU = :bakimTuru, 
                        SSONRAKIBAKIMTARIHI = :sonrakiBakimTarihi, 
                        SORUMLUPERSONELID = :personelId, 
                        BAKIMDURUMU = :bakimDurumu, 
                        ACIKLAMA = :aciklama
                    WHERE BAKIMONARIMID = :bakimOnarimID";

                    using (OracleCommand cmd = new OracleCommand(updateBakimOnarimQuery, connection))
                    {
                        cmd.Parameters.Add(new OracleParameter("cihazId", cihazId));
                        cmd.Parameters.Add(new OracleParameter("bakimTarihi", bakimTarihi.Date)); 
                        cmd.Parameters.Add(new OracleParameter("bakimTuru", bakimTuru));
                        cmd.Parameters.Add(new OracleParameter("sonrakiBakimTarihi", sonrakiBakimTarihi ?? (object)DBNull.Value));
                        cmd.Parameters.Add(new OracleParameter("personelId", personelId ?? (object)DBNull.Value));
                        cmd.Parameters.Add(new OracleParameter("bakimDurumu", string.IsNullOrWhiteSpace(bakimDurumu) ? (object)DBNull.Value : bakimDurumu));
                        cmd.Parameters.Add(new OracleParameter("aciklama", string.IsNullOrWhiteSpace(aciklama) ? (object)DBNull.Value : aciklama));
                        cmd.Parameters.Add(new OracleParameter("bakimOnarimID", this.bakimOnarimID));

                        cmd.ExecuteNonQuery();
                    }

                    if (bakimDurumu == "Tamamlandı")
                    {
                        string updateTibbiCihazQuery = @"
                        UPDATE TIBBICIHAZ
                        SET SONBAKIMTARIHI = :bakimTarihi 
                        WHERE CIHAZID = :cihazId";

                        using (OracleCommand cmd = new OracleCommand(updateTibbiCihazQuery, connection))
                        {
                            cmd.Parameters.Add(new OracleParameter("bakimTarihi", bakimTarihi.Date));
                            cmd.Parameters.Add(new OracleParameter("cihazId", cihazId));

                            cmd.ExecuteNonQuery();
                        }

                        MessageBox.Show("Bakım/Onarım başarıyla güncellendi ve tıbbi cihaz bilgisi güncellendi.");
                    }
                    else
                    {
                        MessageBox.Show("Bakım/Onarım başarıyla güncellendi. Tıbbi cihaz bilgisi güncellenmedi çünkü durum 'tamamlandı' değil.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Güncelleme hatası: " + ex.Message);
                }
            }
        }



    }
}
