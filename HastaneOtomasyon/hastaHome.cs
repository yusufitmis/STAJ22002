using HastaneOtomasyon.DataAccess;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HastaneOtomasyon
{

    
    public partial class hastaHome : Form

    {
        private hastaRandevu hastaRandevuForm;

        private Point fixedLocation = new Point(300, 100);
        public hastaHome()
        {
            InitializeComponent();
            this.LocationChanged += hastaHome_LocationChanged;
        }

        private void gunaButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnHastaHomeProfil_Click(object sender, EventArgs e)
        {
            grbBoxHastaHomeProfil.Visible = !grbBoxHastaHomeProfil.Visible;
        }

        private void hastaHome_Load(object sender, EventArgs e)
        {
            grbBoxHastaHomeProfil.Visible = false;

            tbxSearch.Text = "Poliklinik Ara";
            tbxSearch.ForeColor = Color.Gray;
            Polyclinic.LoadPolyclinicsFromDatabase();
            if (SessionManager.Instance.Polyclinics != null && SessionManager.Instance.Polyclinics.Count > 0)
            {
                lbxPoliklinikler.DataSource = SessionManager.Instance.Polyclinics;
            }
            else
            {
                MessageBox.Show("Poliklinik listesi yüklenemedi.");
            }

        }
       
       
        private void tbxSearch_Enter(object sender, EventArgs e)
        {
            if (tbxSearch.Text == "Poliklinik Ara")
            {
                tbxSearch.Text = "";
                tbxSearch.ForeColor = Color.Black;
            }
        }

        private void tbxSearch_Leave(object sender, EventArgs e)
        {
            if(string.IsNullOrWhiteSpace(tbxSearch.Text))
            {
                tbxSearch.Text = "Poliklinik Ara";
                tbxSearch.ForeColor = Color.Gray;
            }
        }

        private void hastaHome_LocationChanged(object sender, EventArgs e)
        {
            this.Location = fixedLocation;
            
        }

        private void gunaButton4_Click(object sender, EventArgs e)
        {
            this.Close();
            hastaHome hastaHome = new hastaHome();
            hastaHome.Show();
            
        }

        private void btnRandevularım_Click(object sender, EventArgs e)
        {
            
            Randevularım randevularım = new Randevularım();
            randevularım.Show();
            this.Close();
        }

       
 

        private void btnGecmisRandevularım_Click(object sender, EventArgs e)
        {
            this.Close();    
            GecmisRandevularım gecmisRandevularım = new GecmisRandevularım();
            gecmisRandevularım.Show();
            
        }

        private void btnKimlikBilgileri_Click(object sender, EventArgs e)
        {
            this.Close();
            KimlikBilgileri kimlikBilgileri = new KimlikBilgileri();
            kimlikBilgileri.Show();
            
        }

        private void btnİletisimBilgileri_Click(object sender, EventArgs e)
        {
            this.Close();
            IletisimBilgileri ıletisimBilgileri = new IletisimBilgileri();
            ıletisimBilgileri.Show();
            
        }

        private void btnParolaİslemleri_Click(object sender, EventArgs e)
        {
            this.Close();
            ParolaIslemleri parolaIslemleri = new ParolaIslemleri();
            parolaIslemleri.Show();
            
        }

        private void btnCıkısYap_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Çıkmak istediğinize emin misiniz?", "Çıkış", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (dialogResult == DialogResult.Yes)
            {
                SessionManager.Instance.CikisYap();
            }
        }

        private bool isListBoxChangeBySearch = false;
        private void tbxSearch_TextChanged(object sender, EventArgs e)
        {
            isListBoxChangeBySearch = true;

            string searchText = tbxSearch.Text.ToLower();

            var filteredList = SessionManager.Instance.Polyclinics
                .Where(p => p.ToLower().Contains(searchText)) // Filtreleme
                .OrderBy(p => p) // Sıralama
                .ToList();

            lbxPoliklinikler.DataSource = new BindingSource { DataSource = filteredList };

           
            isListBoxChangeBySearch = false;
        }
        private void tbxSearch_Click(object sender, EventArgs e)
        {

        }

        private void lbxPoliklinikler_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (isListBoxChangeBySearch)
            {
                return;
            }

            // Seçilen öğenin boş olup olmadığını kontrol et
            if (lbxPoliklinikler.SelectedItem == null)
            {
                return;
            }

            var selectedPolyclinic = lbxPoliklinikler.SelectedItem.ToString();

            if (string.IsNullOrEmpty(selectedPolyclinic))
            {
                MessageBox.Show("Lütfen bir poliklinik seçin.");
                return;
            }

            int selectedPolyclinicId = Polyclinic.GetPolyclinicIdByName(selectedPolyclinic);

            if (selectedPolyclinicId == -1)
            {
                MessageBox.Show("Poliklinik ID'si alınırken bir hata oluştu.");
                return;
            }

            if (hastaRandevuForm != null && !hastaRandevuForm.IsDisposed)
            {
                hastaRandevuForm.Close();
            }

            // Yeni bir hastaRandevu formu oluştur ve göster
            hastaRandevuForm = new hastaRandevu(selectedPolyclinicId,this);
            hastaRandevuForm.Show();
        }
    }

 }
    
 

