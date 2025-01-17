﻿using HastaneOtomasyon.DataAccess;
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
    public partial class Raporlar : Form
    {
        private Point fixedLocation = new Point(100, 50);
        public Raporlar()
        {
            InitializeComponent();
        }

        private void Raporlar_Load(object sender, EventArgs e)
        {
            this.LocationChanged += Raporlar_LocationChanged;
            grbBoxProfil.Visible = false;
            cbxRaporSec.Items.Add("Klinik Bazında Personel Dağılımı");
            cbxRaporSec.Items.Add("Personel Görev ve Unvan Raporu");

            cbxRaporSec.SelectedIndex = -1;


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

        private void Raporlar_LocationChanged(object sender, EventArgs e)
        {
            this.Location = fixedLocation;

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
            PersonelModül.KlinikIslemleri.KlinikIslemleri klinikIslemleri = new PersonelModül.KlinikIslemleri.KlinikIslemleri();
            klinikIslemleri.Show();
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

        private void cbxRaporSec_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedReport = cbxRaporSec.SelectedItem.ToString();
            if (selectedReport == "Klinik Bazında Personel Dağılımı")
            {
                LoadKlinikBazindaPersonelDagilimi();
            }
            else if (selectedReport == "Personel Görev ve Unvan Raporu")
            {
                LoadPersonelGorevVeUnvanRaporu();
            }
        }
        private void LoadKlinikBazindaPersonelDagilimi()
        {
            
            string query = "SELECT Klinik.KlinikAd, Personel.PersonelAd, Personel.PersonelSoyad " +
                           "FROM Personel " +
                           "JOIN Klinik ON Personel.KlinikID = Klinik.KlinikID"; 

            using (OracleConnection connection = new OracleConnection(SessionManager.Instance.ConnectionString))
            {
                OracleDataAdapter dataAdapter = new OracleDataAdapter(query, connection);
                DataTable dataTable = new DataTable();

                try
                {
                    connection.Open();
                    dataAdapter.Fill(dataTable);
                    dgwRaporlar.DataSource = dataTable; 
                    MessageBox.Show("Klinik Bazında Personel Dağılımı yüklendi.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Hata: {ex.Message}");
                }
            }
        }
        private void LoadPersonelGorevVeUnvanRaporu()
        {
            
            string query = "SELECT Personel.PersonelAd, Personel.PersonelSoyad, k.klinikad, Personel.personelGorev " +
                           "FROM Personel inner join klinik k on personel.klinikid = k.klinikid"; 

            using (OracleConnection connection = new OracleConnection(SessionManager.Instance.ConnectionString))
            {
                OracleDataAdapter dataAdapter = new OracleDataAdapter(query, connection);
                DataTable dataTable = new DataTable();

                try
                {
                    connection.Open();
                    dataAdapter.Fill(dataTable);
                    dgwRaporlar.DataSource = dataTable; 
                    MessageBox.Show("Personel Görev ve Unvan Raporu yüklendi.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Hata: {ex.Message}");
                }
            }
        }


    }
}
