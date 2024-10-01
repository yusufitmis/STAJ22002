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
    public partial class PersonelEkleme : Form
    {
        public PersonelEkleme()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void PersonelEkleme_Load(object sender, EventArgs e)
        {
            LoadPolyclinicComboBox();
            cbxKlinik.SelectedIndex = -1;

        }
        private void LoadPolyclinicComboBox()
        {
            try
            {
              
                if (SessionManager.Instance.Polyclinics == null || SessionManager.Instance.Polyclinics.Count == 0)
                {
                    Polyclinic.LoadPolyclinicsFromDatabase(); 
                }

             
                cbxKlinik.Items.Clear(); 
                foreach (var polyclinic in SessionManager.Instance.Polyclinics)
                {
                    cbxKlinik.Items.Add(polyclinic); 
                }

                if (cbxKlinik.Items.Count > 0)
                {
                    cbxKlinik.SelectedIndex = 0; 
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Poliklinik listesi yüklenirken bir hata oluştu: " + ex.Message);
            }
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(tbxUnvan.Text))
                {
                    MessageBox.Show("Lütfen unvan bilgisi giriniz.", "Eksik Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int unvanId;
                if (!int.TryParse(tbxUnvan.Text, out unvanId))
                {
                    MessageBox.Show("Lütfen geçerli bir unvan ID'si giriniz.", "Geçersiz Girdi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (unvanId == 2 && cbxKlinik.SelectedItem == null)
                {
                    MessageBox.Show("Bu unvan için klinik seçimi zorunludur. Lütfen bir klinik seçiniz.", "Eksik Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string tcKimlikNo = tbxTc.Text.Trim();
                if (string.IsNullOrWhiteSpace(tcKimlikNo))
                {
                    MessageBox.Show("Lütfen TC kimlik numarasını giriniz.", "Eksik Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                bool isTcKimlikNoExists = false;
                using (OracleConnection connection = new OracleConnection(DataAccess.SessionManager.Instance.ConnectionString))
                {
                    connection.Open();
                    string checkPersonelQuery = "SELECT COUNT(*) FROM Personel WHERE PERSONELTCNO = :TCNO";
                    using (OracleCommand checkPersonelCommand = new OracleCommand(checkPersonelQuery, connection))
                    {
                        checkPersonelCommand.Parameters.Add(":TCNO", OracleDbType.Char).Value = tcKimlikNo;
                        int personelCount = Convert.ToInt32(checkPersonelCommand.ExecuteScalar());
                        if (personelCount > 0)
                        {
                            isTcKimlikNoExists = true;
                        }
                    }
                }

                if (isTcKimlikNoExists)
                {
                    MessageBox.Show("Bu TC kimlik numarası zaten kayıtlı. Lütfen başka bir TC kimlik numarası giriniz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                using (OracleConnection connection = new OracleConnection(DataAccess.SessionManager.Instance.ConnectionString))
                {
                    connection.Open();
                    string query = "INSERT INTO Personel (PERSONELAD, PERSONELSOYAD, PERSONELADRES, PERSONELDTARIHI, PERSONELTCNO, " +
                                   "PERSONELGOREV, PERSONELTELNO, PERSONELEPOSTA, PERSONELOGRENIM, PERSONELDIPLOMANO, " +
                                   "PERSONELSICILNO, UNVANID, KLINIKID, PERSONELCINSIYET, PAROLA) " +
                                   "VALUES (:PERSONELAD, :PERSONELSOYAD, :PERSONELADRES, :PERSONELDTARIHI, :PERSONELTCNO, " +
                                   ":PERSONELGOREV, :PERSONELTELNO, :PERSONELEPOSTA, :PERSONELOGRENIM, :PERSONELDIPLOMANO, " +
                                   ":PERSONELSICILNO, :UNVANID, :KLINIKID, :PERSONELCINSIYET, :PAROLA)";

                    OracleCommand command = new OracleCommand(query, connection);

                    command.Parameters.Add(":PERSONELAD", OracleDbType.Varchar2).Value = string.IsNullOrWhiteSpace(tbxAd.Text) ? (object)DBNull.Value : tbxAd.Text;
                    command.Parameters.Add(":PERSONELSOYAD", OracleDbType.Varchar2).Value = string.IsNullOrWhiteSpace(tbxSoyad.Text) ? (object)DBNull.Value : tbxSoyad.Text;
                    command.Parameters.Add(":PERSONELADRES", OracleDbType.Varchar2).Value = string.IsNullOrWhiteSpace(tbxAdres.Text) ? (object)DBNull.Value : tbxAdres.Text;
                    command.Parameters.Add(":PERSONELDTARIHI", OracleDbType.Date).Value = dtpDtarih.Value != null ? (object)dtpDtarih.Value : DBNull.Value;
                    command.Parameters.Add(":PERSONELTCNO", OracleDbType.Char).Value = string.IsNullOrWhiteSpace(tbxTc.Text) ? (object)DBNull.Value : tbxTc.Text;
                    command.Parameters.Add(":PERSONELGOREV", OracleDbType.Varchar2).Value = string.IsNullOrWhiteSpace(tbxGorev.Text) ? (object)DBNull.Value : tbxGorev.Text;
                    command.Parameters.Add(":PERSONELTELNO", OracleDbType.Char).Value = string.IsNullOrWhiteSpace(tbxTel.Text) ? (object)DBNull.Value : tbxTel.Text;
                    command.Parameters.Add(":PERSONELEPOSTA", OracleDbType.Varchar2).Value = string.IsNullOrWhiteSpace(tbxEposta.Text) ? (object)DBNull.Value : tbxEposta.Text;
                    command.Parameters.Add(":PERSONELOGRENIM", OracleDbType.Varchar2).Value = string.IsNullOrWhiteSpace(tbxOgrenim.Text) ? (object)DBNull.Value : tbxOgrenim.Text;
                    command.Parameters.Add(":PERSONELDIPLOMANO", OracleDbType.Char).Value = string.IsNullOrWhiteSpace(tbxDiploma.Text) ? (object)DBNull.Value : tbxDiploma.Text;
                    command.Parameters.Add(":PERSONELSICILNO", OracleDbType.Char).Value = string.IsNullOrWhiteSpace(tbxSicil.Text) ? (object)DBNull.Value : tbxSicil.Text;

                    command.Parameters.Add(":UNVANID", OracleDbType.Int32).Value = unvanId; // Unvan ID burada kullanıldı

                    int? selectedKlinikID = null;

                    if (unvanId == 2)
                    {
                        if (cbxKlinik.SelectedItem != null)
                        {
                            selectedKlinikID = Polyclinic.GetPolyclinicIdByName(cbxKlinik.SelectedItem.ToString());
                        }
                        else
                        {
                            MessageBox.Show("Bu unvan için klinik seçimi zorunludur. Lütfen bir klinik seçiniz.", "Eksik Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }
                    else
                    {
                        selectedKlinikID = null; 
                    }

                    command.Parameters.Add(":KLINIKID", OracleDbType.Int32).Value = selectedKlinikID.HasValue ? (object)selectedKlinikID.Value : DBNull.Value;

                    command.Parameters.Add(":PERSONELCINSIYET", OracleDbType.Char).Value = cbxCinsiyet.SelectedItem != null ? cbxCinsiyet.SelectedItem.ToString() : (object)DBNull.Value;

                    command.Parameters.Add(":PAROLA", OracleDbType.Varchar2).Value = string.IsNullOrWhiteSpace(tbxParola.Text) ? (object)DBNull.Value : tbxParola.Text;

                    
                    command.ExecuteNonQuery();

                    MessageBox.Show("Personel başarıyla eklendi!");
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Personel ekleme sırasında bir hata oluştu: " + ex.Message);
            }
        }



    }
}
