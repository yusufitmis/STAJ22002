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

namespace HastaneOtomasyon.PersonelModül.HastaIslemleri
{
    public partial class BilgileriGoruntule : Form
    {
        private string selectedhastaTcNo;

        public BilgileriGoruntule(string selectedhastaTcNo)
        {
            InitializeComponent();
            this.selectedhastaTcNo = selectedhastaTcNo;
        }
        public BilgileriGoruntule()
        {
            InitializeComponent();
        }

        private void BilgileriGoruntule_Load(object sender, EventArgs e)
        {
            PersonelBilgileriniYukle();
        }
        private void PersonelBilgileriniYukle()
        {
            try
            {
                using (OracleConnection connection = new OracleConnection(DataAccess.SessionManager.Instance.ConnectionString))
                {
                    connection.Open();

                    string query = @"SELECT 
                    hastalad, 
                    hastasoyad, 
                    hastaadres, 
                    hastadtarihi, 
                    hastatcno, 
                    hastacinsiyet, 
                    kangrubu, 
                    sosyalguvence, 
                    hastano, 
                    hastatelno, 
                    hastaeposta,
                    hastano
                 FROM hasta WHERE hastatcno = :selectedhastaTcNo";

                    OracleCommand command = new OracleCommand(query, connection);
                    command.Parameters.Add(":selectedhastaTcNo", OracleDbType.Int32).Value = selectedhastaTcNo;

                    using (OracleDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            lblAd.Text = reader["hastalad"] != DBNull.Value ? reader["hastalad"].ToString() : "...";
                            lblSoyad.Text = reader["hastasoyad"] != DBNull.Value ? reader["hastasoyad"].ToString() : "...";
                            lblAdres.Text = reader["hastaadres"] != DBNull.Value ? reader["hastaadres"].ToString() : "Bilgi Yok";

                            if (reader["hastadtarihi"] != DBNull.Value)
                            {
                                lblDogumTarihi.Text = Convert.ToDateTime(reader["hastadtarihi"]).ToString("dd/MM/yyyy");
                            }
                            else
                            {
                                lblDogumTarihi.Text = "Tarih Bilinmiyor";
                            }

                            lblTc.Text = reader["hastatcno"] != DBNull.Value ? reader["hastatcno"].ToString().Trim() : "Bilgi Yok";
                            lblCinsiyet.Text = reader["hastacinsiyet"] != DBNull.Value ? reader["hastacinsiyet"].ToString() : "Bilgi Yok";

                            lblKan.Text = reader["kangrubu"] != DBNull.Value ? reader["kangrubu"].ToString() : "Bilinmiyor";
                            lblSosyal.Text = reader["sosyalguvence"] != DBNull.Value ? reader["sosyalguvence"].ToString() : "Bilinmiyor";

                            lblTelno.Text = reader["hastatelno"] != DBNull.Value ? reader["hastatelno"].ToString().Trim() : "Bilgi Yok";
                            lblEposta.Text = reader["hastaeposta"] != DBNull.Value ? reader["hastaeposta"].ToString() : "Bilgi Yok";
                            lblHastaNo.Text = reader["hastano"] != DBNull.Value ? reader["hastano"].ToString() : "Bilgi Yok";


                            string cinsiyet = reader["hastacinsiyet"] != DBNull.Value ? reader["hastacinsiyet"].ToString() : "Bilinmiyor";
                            if (cinsiyet.Trim() == "K")
                            {
                                pictureBoxCinsiyet.Image = Image.FromFile("C:\\Users\\yusuf\\Desktop\\hastane otomasyon\\HastaneOtomasyon\\icons\\woman.png");
                            }
                            else if (cinsiyet.Trim() == "E")
                            {
                                pictureBoxCinsiyet.Image = Image.FromFile("C:\\Users\\yusuf\\Desktop\\hastane otomasyon\\HastaneOtomasyon\\icons\\man.png");
                            }
                            else
                            {
                                pictureBoxCinsiyet.Image = null;
                            }
                        }
                        else
                        {
                            MessageBox.Show("Hasta bilgileri bulunamadı.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
