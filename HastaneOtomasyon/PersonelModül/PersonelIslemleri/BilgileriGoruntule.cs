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

namespace HastaneOtomasyon.PersonelModül.PersonelIslemleri
{
    public partial class BilgileriGoruntule : Form
    {
        Doctor doktor = new Doctor();
        private int selectedPersonelId;
        public BilgileriGoruntule(int selectedPersonelId)
        {
            InitializeComponent();
            this.selectedPersonelId = selectedPersonelId;
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
                            PERSONELAD, 
                            PERSONELSOYAD, 
                            PERSONELADRES, 
                            PERSONELDTARIHI, 
                            PERSONELTCNO, 
                            PERSONELGOREV, 
                            PERSONELTELNO, 
                            PERSONELEPOSTA, 
                            PERSONELOGRENIM, 
                            PERSONELDIPLOMANO, 
                            PERSONELSICILNO, 
                            UNVANID, 
                            KLINIKID, 
                            PERSONELCINSIYET 
                         FROM Personel WHERE PERSONELID = :PERSONELID";

                    OracleCommand command = new OracleCommand(query, connection);
                    command.Parameters.Add(":PERSONELID", OracleDbType.Int32).Value = selectedPersonelId;

                    using (OracleDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            lblAd.Text = reader["PERSONELAD"].ToString();
                            lblSoyad.Text = reader["PERSONELSOYAD"].ToString();
                            lblAdres.Text = reader["PERSONELADRES"].ToString();
                            lblDogumTarihi.Text = Convert.ToDateTime(reader["PERSONELDTARIHI"]).ToString("dd/MM/yyyy");
                            lblTc.Text = reader["PERSONELTCNO"].ToString();
                            lblGorev.Text = reader["PERSONELGOREV"].ToString();
                            lblTelno.Text = reader["PERSONELTELNO"].ToString();
                            lblEposta.Text = reader["PERSONELEPOSTA"].ToString();
                            lblOgrenim.Text = reader["PERSONELOGRENIM"].ToString();
                            lblDiploma.Text = reader["PERSONELDIPLOMANO"].ToString();
                            lblSicil.Text = reader["PERSONELSICILNO"].ToString();
                            lblUnvan.Text = doktor.GetUnvanNameById(Convert.ToInt32(reader["UNVANID"])).ToString();
                            lblKlinik.Text = Polyclinic.GetPolyclinicNameById(Convert.ToInt32(reader["KLINIKID"])).ToString();
                            lblCinsiyet.Text = reader["PERSONELCINSIYET"].ToString();

                            
                            string cinsiyet = reader["PERSONELCINSIYET"].ToString();
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
                            MessageBox.Show("Personel bilgileri bulunamadı.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
