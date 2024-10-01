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
    public partial class Unvan : Form
    {
        private Point fixedLocation = new Point(100, 50);
        public Unvan()
        {
            InitializeComponent();
        }

        private void btnIletisimBilgileriGuncelle_Click(object sender, EventArgs e)
        {
            PersonelModül.PersonelIslemleri.IletisimBilgileriniGuncelle ıletisimBilgileriniGuncelle = new PersonelModül.PersonelIslemleri.IletisimBilgileriniGuncelle();
            ıletisimBilgileriniGuncelle.Show();
            this.Close();
        }

        private void btnEgitimveSertifika_Click(object sender, EventArgs e)
        {

            PersonelModül.PersonelIslemleri.EgitimveSertifikalar egitimveSertifikalar = new PersonelModül.PersonelIslemleri.EgitimveSertifikalar();
            egitimveSertifikalar.Show();
            this.Close();
        }

        private void btnGenelIslemler_Click(object sender, EventArgs e)
        {
            PersonelModül.PersonelIslemleri.PersonelIslemleri personelIslemleri = new PersonelModül.PersonelIslemleri.PersonelIslemleri();
            personelIslemleri.Show();
            this.Close();
        }

        private void btnRaporlar_Click(object sender, EventArgs e)
        {
            PersonelModül.PersonelIslemleri.Raporlar raporlar = new PersonelModül.PersonelIslemleri.Raporlar();
            raporlar.Show();
            this.Close();
        }

        private void Unvan_Load(object sender, EventArgs e)
        {
            this.LocationChanged += Unvan_LocationChanged;
            grbBoxProfil.Visible = false;
            

            UnvanlariListele();



        }
        private void UnvanlariListele()
        {
            try
            {
                using (OracleConnection connection = new OracleConnection(DataAccess.SessionManager.Instance.ConnectionString))
                {
                    connection.Open();
                    string query = "SELECT UNVANID, UNVANAD, UNVANTANIM FROM UNVAN " +
                        "ORDER BY UNVANID";

                    using (OracleDataAdapter dataAdapter = new OracleDataAdapter(query, connection))
                    {
                        DataTable dataTable = new DataTable();
                        dataAdapter.Fill(dataTable);
                        dgwUnvan.DataSource = dataTable; 
                        dgwUnvan.Columns["UNVANID"].HeaderText = "Unvan ID";
                        dgwUnvan.Columns["UNVANAD"].HeaderText = "Unvan Adı";
                        dgwUnvan.Columns["UNVANTANIM"].HeaderText = "Unvan Tanımı";

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unvanları yüklerken bir hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Unvan_LocationChanged(object sender, EventArgs e)
        {
            this.Location = fixedLocation;
        }

        private void gunaButton1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnHastaIslemleri_Click(object sender, EventArgs e)
        {
            PersonelModül.HastaIslemleri.HastaIslemleri hastaIslemleri = new PersonelModül.HastaIslemleri.HastaIslemleri();
            hastaIslemleri.Show();
            this.Close();
        }

        private void btnCihazIslemleri_Click(object sender, EventArgs e)
        {
            PersonelModül.CihazIslemleri.CihazIslemleri cihazIslemleri = new PersonelModül.CihazIslemleri.CihazIslemleri();
            cihazIslemleri.Show();
            this.Close();
        }

        private void btnKlinikİslemleri_Click(object sender, EventArgs e)
        {
            PersonelModül.HastaIslemleri.HastaIslemleri hastaIslemleri = new PersonelModül.HastaIslemleri.HastaIslemleri();
            hastaIslemleri.Show();
            this.Close();
        }

        private void btnStokIslemleri_Click(object sender, EventArgs e)
        {
            PersonelModül.StokIslemleri.StokIslemleri stokIslemleri = new PersonelModül.StokIslemleri.StokIslemleri();
            stokIslemleri.Show();
            this.Close();
        }

       

        private void btnHastaHomeProfil_Click(object sender, EventArgs e)
        {
            grbBoxProfil.Visible = !grbBoxProfil.Visible;
        }

        private void btnKimlikBilgiler_Click(object sender, EventArgs e)
        {
            PersonelModül.Profil.KimlikBilgileri kimlikBilgileri = new PersonelModül.Profil.KimlikBilgileri();
            kimlikBilgileri.Show();
            this.Close();
        }

        private void btnİletişimBilgileri_Click(object sender, EventArgs e)
        {
            PersonelModül.Profil.IletisimBilgileri ıletisimBilgileri = new PersonelModül.Profil.IletisimBilgileri();
            ıletisimBilgileri.Show();
            this.Close();
        }

        private void btnParolaİşlemleri_Click(object sender, EventArgs e)
        {
            PersonelModül.Profil.ParolaIslemleri parolaIslemleri = new PersonelModül.Profil.ParolaIslemleri();
            parolaIslemleri.Show();
            this.Close();
        }

        private void btnCıkısYap_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Çıkmak istediğinize emin misiniz?", "Çıkış", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);


            if (dialogResult == DialogResult.Yes)
            {
                Application.Exit();
            }

            else if (dialogResult == DialogResult.No)
            {

            }
        }

        private void btnUnvanEkle_Click(object sender, EventArgs e)
        {
            
            string unvanAd = UnvanAdd.Text.Trim();
            string unvanTanim = UnvanTanımm.Text.Trim();

            if (string.IsNullOrEmpty(unvanAd) || string.IsNullOrEmpty(unvanTanim))
            {
                MessageBox.Show("Lütfen tüm alanları doldurun.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            
            try
            {
                using (OracleConnection connection = new OracleConnection(DataAccess.SessionManager.Instance.ConnectionString))
                {
                    connection.Open();

                   
                    string query = "INSERT INTO UNVAN (UNVANAD, UNVANTANIM) VALUES (:UNVANAD, :UNVANTANIM)";

                    using (OracleCommand command = new OracleCommand(query, connection))
                    {
                        
                        command.Parameters.Add(":UNVANAD", OracleDbType.Varchar2).Value = unvanAd;
                        command.Parameters.Add(":UNVANTANIM", OracleDbType.Varchar2).Value = unvanTanim;

                        
                        int rowsAffected = command.ExecuteNonQuery();

                       
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Ünvan başarıyla eklendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            UnvanlariListele();
                            UnvanAdd.Text = string.Empty;
                            UnvanTanımm.Text = string.Empty;
                        }
                        else
                        {
                            MessageBox.Show("Ünvan eklenemedi.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnPersonelGuncelle_Click(object sender, EventArgs e)
        {
            
            string unvanAd = tbxAd.Text.Trim();
            string unvanTanim = tbxTanım.Text.Trim();

            
            if (string.IsNullOrEmpty(unvanAd) || string.IsNullOrEmpty(unvanTanim))
            {
                MessageBox.Show("Lütfen tüm alanları doldurun.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (dgwUnvan.CurrentRow != null)
            {
                int unvanId = Convert.ToInt32(dgwUnvan.CurrentRow.Cells["UNVANID"].Value);

                try
                {
                    using (OracleConnection connection = new OracleConnection(DataAccess.SessionManager.Instance.ConnectionString))
                    {
                        connection.Open();

                        string query = "UPDATE UNVAN SET UNVANAD = :UNVANAD, UNVANTANIM = :UNVANTANIM WHERE UNVANID = :UNVANID";

                        using (OracleCommand command = new OracleCommand(query, connection))
                        {

                            command.Parameters.Add(":UNVANAD", OracleDbType.Varchar2).Value = unvanAd;
                            command.Parameters.Add(":UNVANTANIM", OracleDbType.Varchar2).Value = unvanTanim;
                            command.Parameters.Add(":UNVANID", OracleDbType.Int32).Value = unvanId;

                            int rowsAffected = command.ExecuteNonQuery();

                            if (rowsAffected > 0)
                            {
                                MessageBox.Show("Ünvan başarıyla güncellendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                UnvanAdd.Text = string.Empty;
                                UnvanTanımm.Text = string.Empty;
                            }
                            else
                            {
                                MessageBox.Show("Ünvan güncellenemedi.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hata: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Lütfen güncellemek istediğiniz satırı seçin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void dgwUnvan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {

                DataGridViewRow row = dgwUnvan.Rows[e.RowIndex];


                tbxAd.Text = row.Cells["UNVANAD"].Value.ToString();
                tbxTanım.Text = row.Cells["UNVANTANIM"].Value.ToString();
            }
        }

        private void Unvan_MouseClick(object sender, MouseEventArgs e)
        {
            if (!dgwUnvan.DisplayRectangle.Contains(e.Location))
            {
                tbxAd.Clear();
                tbxTanım.Clear();
            }
        }

        private void dgwUnvan_MouseClick(object sender, MouseEventArgs e)
        {
            if (!dgwUnvan.DisplayRectangle.Contains(e.Location))
            {
                tbxAd.Clear();
                tbxTanım.Clear();
            }
        }
    }
}
