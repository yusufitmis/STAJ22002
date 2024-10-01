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

namespace HastaneOtomasyon.PersonelModül.KlinikIslemleri
{
    public partial class ServisIslemleri : Form
    {
        private Point fixedLocation = new Point(100, 50);
        public ServisIslemleri()
        {
            InitializeComponent();
        }

        private void ServisIslemleri_Load(object sender, EventArgs e)
        {
            this.LocationChanged += ServisIslemleri_LocationChanged;

            grbBoxProfil.Visible = false;
            ListeleServisler();
        }

        private void ServisIslemleri_LocationChanged(object sender, EventArgs e)
        {
            this.Location = fixedLocation;
        }

        private void btnKlinik_Click(object sender, EventArgs e)
        {
            PersonelModül.KlinikIslemleri.KlinikIslemleri klinikIslemleri = new PersonelModül.KlinikIslemleri.KlinikIslemleri();
            klinikIslemleri.Show();
            this.Close();
        }

        private void btnHastaIslemleri_Click(object sender, EventArgs e)
        {
            PersonelModül.HastaIslemleri.HastaIslemleri hastaIslemleri = new PersonelModül.HastaIslemleri.HastaIslemleri();
            hastaIslemleri.Show();
            this.Close();
        }

        private void btnPersonelIslem_Click(object sender, EventArgs e)
        {
            PersonelModül.PersonelIslemleri.PersonelIslemleri personelIslemleri = new PersonelModül.PersonelIslemleri.PersonelIslemleri();
            personelIslemleri.Show();
            this.Close();
        }

        private void btnOda_Click(object sender, EventArgs e)
        {
            PersonelModül.KlinikIslemleri.OdaIslemleri odaIslemleri = new PersonelModül.KlinikIslemleri.OdaIslemleri();
            odaIslemleri.Show();
            this.Close();
        }

        private void btnYatak_Click(object sender, EventArgs e)
        {
            PersonelModül.KlinikIslemleri.YatakIslemleri yatakIslemleri = new PersonelModül.KlinikIslemleri.YatakIslemleri();
            yatakIslemleri.Show();
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

        private void btnCıkısYap_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Çıkmak istediğinize emin misiniz?", "Çıkış", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (dialogResult == DialogResult.Yes)
            {
                SessionManager.Instance.CikisYap();
            }
        }
        public void ListeleServisler()
        {
            using (OracleConnection connection = new OracleConnection(SessionManager.Instance.ConnectionString))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT SERVISID, SERVISADI, SERVISSORUMLU, SERVISTELNO FROM SERVIS";
                    using (OracleCommand cmd = new OracleCommand(query, connection))
                    {
                        OracleDataAdapter adapter = new OracleDataAdapter(cmd);
                        DataTable dt = new DataTable();

                        adapter.Fill(dt);

                        dgwServisler.DataSource = dt;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Veri getirme hatası: " + ex.Message);
                }
            }
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            ServisEkle servisEkle = new ServisEkle();
            servisEkle.Show();
        }

        private int servisid;
        private void dgwServisler_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var selectedRow = dgwServisler.Rows[e.RowIndex];
                servisid = Convert.ToInt32(selectedRow.Cells["servisid"].Value);
            }
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            if (dgwServisler.SelectedRows.Count > 0)
            {
                int selectedServisId = Convert.ToInt32(dgwServisler.SelectedRows[0].Cells["servisid"].Value);
                ServisGuncelle servisGuncelle = new ServisGuncelle(selectedServisId);
                servisGuncelle.ServisBilgileriniGetir(selectedServisId);
                servisGuncelle.ShowDialog();
            }
        }
    }
}
