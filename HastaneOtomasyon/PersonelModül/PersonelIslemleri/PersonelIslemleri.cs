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
    public partial class PersonelIslemleri : Form
    {
        private Point fixedLocation = new Point(100, 50);
        public PersonelIslemleri()
        {
            InitializeComponent();
        }

        private void gunaButton1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnPersonelIslemleri_Load(object sender, EventArgs e)
        {
            this.LocationChanged += btnPersonelIslemleri_LocationChanged;
            grbBoxProfil.Visible = false;
            tbxSearch.Text = "Personel Ara";
            tbxSearch.ForeColor = Color.Gray;
            ListelePersoneller();

        }
        private void ListelePersoneller(string searchQuery = "")
        {
            try
            {
                using (OracleConnection connection = new OracleConnection(DataAccess.SessionManager.Instance.ConnectionString))
                {
                    connection.Open();

                   
                    string query = "SELECT p.PERSONELID, p.PERSONELAD, p.PERSONELSOYAD, p.PERSONELTCNO, " +
                                   "u.UNVANAD, p.PERSONELGOREV, p.PERSONELCINSIYET, p.PAROLA " +
                                   "FROM Personel p " +
                                   "JOIN Unvan u ON p.UNVANID = u.UNVANID ";

                   
                    if (!string.IsNullOrWhiteSpace(searchQuery))
                    {
                        query += "WHERE LOWER(p.PERSONELAD) LIKE '%' || :searchQuery || '%' " +
                                 "OR LOWER(p.PERSONELSOYAD) LIKE '%' || :searchQuery || '%' " +
                                 "OR LOWER(p.PERSONELTCNO) LIKE '%' || :searchQuery || '%' ";
                    }

                    query += "ORDER BY p.PERSONELID";

                    OracleCommand command = new OracleCommand(query, connection);

                    
                    if (!string.IsNullOrWhiteSpace(searchQuery))
                    {
                        command.Parameters.Add(":searchQuery", OracleDbType.Varchar2).Value = searchQuery.ToLower();
                    }

                    OracleDataAdapter dataAdapter = new OracleDataAdapter(command);
                    DataSet dataSet = new DataSet();

                    dataAdapter.Fill(dataSet);

                    dgwPersoneller.DataSource = dataSet.Tables[0];
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Veritabanı bağlantısı sırasında bir hata oluştu: " + ex.Message);
            }
        }



        private void btnPersonelIslemleri_LocationChanged(object sender, EventArgs e)
        {
            this.Location = fixedLocation;
        }

        private void btnCıkısYap_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Çıkmak istediğinize emin misiniz?", "Çıkış", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (dialogResult == DialogResult.Yes)
            {
                SessionManager.Instance.CikisYap();
            }
        }

        private void btnGenelIslemler_Click(object sender, EventArgs e)
        {
           
            
        }

        private void btnEgitimveSertifika_Click(object sender, EventArgs e)
        {
            PersonelModül.PersonelIslemleri.EgitimveSertifikalar egitimveSertifikalar = new PersonelModül.PersonelIslemleri.EgitimveSertifikalar();
            egitimveSertifikalar.Show();
            this.Close();

        }

        private void btnRaporlar_Click(object sender, EventArgs e)
        {
            PersonelModül.PersonelIslemleri.Raporlar raporlar = new PersonelModül.PersonelIslemleri.Raporlar();
            raporlar.Show();
            this.Close();

        }

        private void btnIletisimBilgileriGuncelle_Click(object sender, EventArgs e)
        {        
            PersonelModül.PersonelIslemleri.IletisimBilgileriniGuncelle ıletisimBilgileriniGuncelle = new PersonelModül.PersonelIslemleri.IletisimBilgileriniGuncelle();
            ıletisimBilgileriniGuncelle.Show();
            this.Close();
        }

        private void gunaButton2_Click(object sender, EventArgs e)
        {
         
            PersonelModül.PersonelIslemleri.Unvan unvan = new PersonelModül.PersonelIslemleri.Unvan();
            unvan.Show();
            this.Close();


        }

        private void tbxSearch_Enter(object sender, EventArgs e)
        {
            if (tbxSearch.Text == "Personel Ara")
            {
                tbxSearch.Text = "";
                tbxSearch.ForeColor = Color.Black;
                tbxSearch.UseSystemPasswordChar = true;
            }
        }

        private void tbxSearch_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbxSearch.Text))
            {
                tbxSearch.UseSystemPasswordChar = false;
                tbxSearch.Text = "Personel Ara";
                tbxSearch.ForeColor = Color.Gray;
            }
        }

        private void btnHastaIslemleri_Click(object sender, EventArgs e)
        {
            
            PersonelModül.HastaIslemleri.HastaIslemleri hastaIslemleri = new PersonelModül.HastaIslemleri.HastaIslemleri();
            hastaIslemleri.Show();
            this.Close();
            
        }

        private void btnKlinikİslemleri_Click(object sender, EventArgs e)
        {
            PersonelModül.KlinikIslemleri.KlinikIslemleri klinikIslemleri = new PersonelModül.KlinikIslemleri.KlinikIslemleri();
            klinikIslemleri.Show();
            this.Close();
        }

        private void btnCihazIslemleri_Click(object sender, EventArgs e)
        {
            PersonelModül.CihazIslemleri.CihazIslemleri cihazIslemleri = new PersonelModül.CihazIslemleri.CihazIslemleri();
            cihazIslemleri.Show();
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

        private void tbxSearch_TextChanged(object sender, EventArgs e)
        {
        
                string searchText = tbxSearch.Text.Trim();
                ListelePersoneller(searchText);
            

        }

        private void btnpersonelEkle_Click(object sender, EventArgs e)
        {
            PersonelEkleme personelEkleForm = new PersonelEkleme();
            personelEkleForm.ShowDialog();
        }

        private void btnpersonelSil_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgwPersoneller.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Silinecek personeli seçiniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int selectedPersonelId = Convert.ToInt32(dgwPersoneller.SelectedRows[0].Cells["PERSONELID"].Value);

                using (OracleConnection connection = new OracleConnection(DataAccess.SessionManager.Instance.ConnectionString))
                {
                    connection.Open();

                    string query = "DELETE FROM Personel WHERE PERSONELID = :PERSONELID";
                    OracleCommand command = new OracleCommand(query, connection);
                    command.Parameters.Add(":PERSONELID", OracleDbType.Int32).Value = selectedPersonelId;

                    int rowsAffected = command.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Personel başarıyla silindi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ListelePersoneller();
                    }
                    else
                    {
                        MessageBox.Show("Silme işlemi sırasında bir hata oluştu.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Silme sırasında bir hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnPersonelGuncelle_Click(object sender, EventArgs e)
        {
            if (dgwPersoneller.SelectedRows.Count == 0)
            {
                MessageBox.Show("Güncellenecek personeli seçiniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            
            DataGridViewRow selectedRow = dgwPersoneller.SelectedRows[0];
            int selectedPersonelId = Convert.ToInt32(selectedRow.Cells["PERSONELID"].Value);

            
            PersonelGuncelle guncelleForm = new PersonelGuncelle(selectedPersonelId);

            
            guncelleForm.ShowDialog();

            
            ListelePersoneller();
        }

        

        private void btnPersonelGörüntüle_Click(object sender, EventArgs e)
        {
            if (dgwPersoneller.SelectedRows.Count == 0)
            {
                MessageBox.Show("Görev tanımlamak için bir personel seçiniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DataGridViewRow selectedRow = dgwPersoneller.SelectedRows[0];
            int selectedPersonelId = Convert.ToInt32(selectedRow.Cells["PERSONELID"].Value);

            
            BilgileriGoruntule bilgileriGoruntule = new BilgileriGoruntule(selectedPersonelId);
            bilgileriGoruntule.ShowDialog();

           
            ListelePersoneller();
        }
    }
}
