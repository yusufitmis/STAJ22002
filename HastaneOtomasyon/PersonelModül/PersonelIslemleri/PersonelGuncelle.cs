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
using static System.Net.Mime.MediaTypeNames;

namespace HastaneOtomasyon.PersonelModül.PersonelIslemleri
{
    public partial class PersonelGuncelle : Form
    {
        Doctor doktor = new Doctor();
        
        private int personelId;
        public PersonelGuncelle(int id)
        {
            InitializeComponent();
            personelId = id;
        }

        private void PersonelGuncelle_Load(object sender, EventArgs e)
        {
            LoadPersonelData();
        }
        private void LoadPersonelData()
        {
            try
            {
                using (OracleConnection connection = new OracleConnection(DataAccess.SessionManager.Instance.ConnectionString))
                {
                    connection.Open();

                    string query = "SELECT p.PERSONELAD, p.PERSONELSOYAD, p.PERSONELTCNO, u.UNVANAD, p.PERSONELGOREV, " +
                                   "p.PERSONELCINSIYET, p.PAROLA, p.PERSONELDIPLOMANO, p.PERSONELADRES, p.PERSONELDTARIHI, " +
                                   "p.PERSONELTELNO, p.PERSONELEPOSTA, p.PERSONELOGRENIM, p.PERSONELSICILNO " +
                                   "FROM Personel p " +
                                   "JOIN Unvan u ON p.UNVANID = u.UNVANID " +
                                   "WHERE p.PERSONELID = :PERSONELID";

                    OracleCommand command = new OracleCommand(query, connection);
                    command.Parameters.Add(":PERSONELID", OracleDbType.Int32).Value = personelId;

                    OracleDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        
                        tbxAd.Text = reader["PERSONELAD"].ToString();
                        tbxSoyad.Text = reader["PERSONELSOYAD"].ToString();
                        tbxTc.Text = reader["PERSONELTCNO"].ToString();
                        tbxUnvan.Text = doktor.GetUnvanIdByName(reader["UNVANAD"].ToString()).ToString();
                        ;
                        tbxGorev.Text = reader["PERSONELGOREV"].ToString();
                        cbxCinsiyet.SelectedItem = reader["PERSONELCINSIYET"].ToString();
                        tbxParola.Text = reader["PAROLA"].ToString();
                        tbxDiploma.Text = reader["PERSONELDIPLOMANO"].ToString();
                        tbxAdres.Text = reader["PERSONELADRES"].ToString();
                        dtpDtarih.Value = Convert.ToDateTime(reader["PERSONELDTARIHI"]);
                        tbxTel.Text = reader["PERSONELTELNO"].ToString();
                        tbxEposta.Text = reader["PERSONELEPOSTA"].ToString();
                        tbxOgrenim.Text = reader["PERSONELOGRENIM"].ToString();
                        tbxSicil.Text = reader["PERSONELSICILNO"].ToString();
                    }
                    else
                    {
                        MessageBox.Show("Personel verileri bulunamadı.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Veri yükleme sırasında bir hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            try
            {
                using (OracleConnection connection = new OracleConnection(DataAccess.SessionManager.Instance.ConnectionString))
                {
                    connection.Open();

                    string query = "UPDATE Personel SET " +
                                   "PERSONELAD = :PERSONELAD, " +
                                   "PERSONELSOYAD = :PERSONELSOYAD, " +
                                   "PERSONELTCNO = :PERSONELTCNO, " +
                                   "PERSONELGOREV = :PERSONELGOREV, " +
                                   "PERSONELCINSIYET = :PERSONELCINSIYET, " +
                                   "PAROLA = :PAROLA, " +
                                   "PERSONELDIPLOMANO = :PERSONELDIPLOMANO, " +
                                   "PERSONELADRES = :PERSONELADRES, " +
                                   "PERSONELDTARIHI = :PERSONELDTARIHI, " +
                                   "PERSONELTELNO = :PERSONELTELNO, " +
                                   "PERSONELEPOSTA = :PERSONELEPOSTA, " +
                                   "PERSONELOGRENIM = :PERSONELOGRENIM, " +
                                   "PERSONELSICILNO = :PERSONELSICILNO, " +
                                   "UNVANID = :UNVANID " +
                                   "WHERE PERSONELID = :PERSONELID";

                    OracleCommand command = new OracleCommand(query, connection);

                    command.Parameters.Add(":PERSONELAD", OracleDbType.Varchar2).Value = tbxAd.Text;
                    command.Parameters.Add(":PERSONELSOYAD", OracleDbType.Varchar2).Value = tbxSoyad.Text;
                    command.Parameters.Add(":PERSONELTCNO", OracleDbType.Char).Value = tbxTc.Text;
                    command.Parameters.Add(":PERSONELGOREV", OracleDbType.Varchar2).Value = tbxGorev.Text;
                    command.Parameters.Add(":PERSONELCINSIYET", OracleDbType.Char).Value = cbxCinsiyet.SelectedItem.ToString();
                    command.Parameters.Add(":PAROLA", OracleDbType.Varchar2).Value = tbxParola.Text;
                    command.Parameters.Add(":PERSONELDIPLOMANO", OracleDbType.Varchar2).Value = tbxDiploma.Text;
                    command.Parameters.Add(":PERSONELADRES", OracleDbType.Varchar2).Value = tbxAdres.Text;
                    command.Parameters.Add(":PERSONELDTARIHI", OracleDbType.Date).Value = dtpDtarih.Value;
                    command.Parameters.Add(":PERSONELTELNO", OracleDbType.Char).Value = tbxTel.Text;
                    command.Parameters.Add(":PERSONELEPOSTA", OracleDbType.Varchar2).Value = tbxEposta.Text;
                    command.Parameters.Add(":PERSONELOGRENIM", OracleDbType.Varchar2).Value = tbxOgrenim.Text;
                    command.Parameters.Add(":PERSONELSICILNO", OracleDbType.Char).Value = tbxSicil.Text;
                    command.Parameters.Add(":UNVANID", OracleDbType.Int32).Value = Convert.ToInt32(tbxUnvan.Text);
                    command.Parameters.Add(":PERSONELID", OracleDbType.Int32).Value = personelId;
                    int rowsAffected = command.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Personel başarıyla güncellendi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Güncelleme sırasında bir hata oluştu.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Güncelleme sırasında bir hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

