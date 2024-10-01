using HastaneOtomasyon.DataAccess;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HastaneOtomasyon
{
    public partial class ParolaIslemleri : Form
    {
        private Point fixedLocation = new Point(300, 100);
        public ParolaIslemleri()
        {
            InitializeComponent();
        }

        private void btnHastaHomeProfil_Click(object sender, EventArgs e)
        {
            grbBoxHastaHomeProfil.Visible = !grbBoxHastaHomeProfil.Visible;
        }

        private void ParolaIslemleri_Load(object sender, EventArgs e)
        {
            this.LocationChanged += ParolaIslemleri_LocationChanged;

            tbxGecerliParola.Text = "Geçerli Parola";
            tbxGecerliParola.ForeColor = Color.Gray;

            tbxYeniParola.Text = "Yeni Parola";
            tbxYeniParola.ForeColor = Color.Gray;

            btnYeniParolaTekrar.Text = "Yeni Parola Tekrar";
            btnYeniParolaTekrar.ForeColor = Color.Gray;
        }

        private void ParolaIslemleri_LocationChanged(object sender, EventArgs e)
        {
            this.Location = fixedLocation;
        }

        private void btnrandevuAl_Click(object sender, EventArgs e)
        {
            hastaHome hastaHome = new hastaHome();
            hastaHome.Show();
            this.Close();
        }

        private void btnRandevularım_Click(object sender, EventArgs e)
        {
            this.Hide();
            Randevularım rand = new Randevularım();
            rand.Show();
        }

        private void btnGecmisRandevularim_Click(object sender, EventArgs e)
        {
            GecmisRandevularım gecmisRandevularım = new GecmisRandevularım();
            gecmisRandevularım.Show();
            this.Close();
        }

    

        private void btnKimlikBilgiler_Click(object sender, EventArgs e)
        {
            KimlikBilgileri kimlikBilgileri = new KimlikBilgileri();
            kimlikBilgileri.Show();
            this.Close();
        }

        private void btnİletişimBilgileri_Click(object sender, EventArgs e)
        {
            IletisimBilgileri ıletisimBilgileri = new IletisimBilgileri();
            ıletisimBilgileri.Show();
            this.Close();
        }

        private void btnParolaİşlemleri_Click(object sender, EventArgs e)
        {
            ParolaIslemleri parolaIslemleri = new ParolaIslemleri();
            parolaIslemleri.Show();
            this.Close();
        }

        private void gunaButton1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }


        private void tbxGecerliParola_Enter_1(object sender, EventArgs e)
        {
            if (tbxGecerliParola.Text == "Geçerli Parola")
            {
                tbxGecerliParola.Text = "";
                tbxGecerliParola.ForeColor = Color.Black;
                tbxGecerliParola.UseSystemPasswordChar = true;
            }
        }

        private void tbxGecerliParola_Leave_1(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbxGecerliParola.Text))
            {
                tbxGecerliParola.UseSystemPasswordChar = false;
                tbxGecerliParola.Text = "Geçerli Parola";
                tbxGecerliParola.ForeColor = Color.Gray;
            }
        }

        private void pictureboxGecerliParola_Click(object sender, EventArgs e)
        {
            tbxGecerliParola.UseSystemPasswordChar = !tbxGecerliParola.UseSystemPasswordChar;
            if (tbxGecerliParola.UseSystemPasswordChar == true)
            {
                string imagePath = @"C:\\Users\\yusuf\\Desktop\\hastane otomasyon\\HastaneOtomasyon\\icons\\hide-password.png";
                pictureboxGecerliParola.Image = Image.FromFile(imagePath);
            }
            else {
                string imagePath = @"C:\\Users\\yusuf\\Desktop\\hastane otomasyon\\HastaneOtomasyon\\icons\\show-password.png";
                pictureboxGecerliParola.Image = Image.FromFile(imagePath);
            }
            
        }

        private void tbxYeniParola_Enter(object sender, EventArgs e)
        {
            if (tbxYeniParola.Text == "Yeni Parola")
            {
                tbxYeniParola.Text = "";
                tbxYeniParola.ForeColor = Color.Black;
                tbxYeniParola.UseSystemPasswordChar = true;
            }
        }

        private void tbxYeniParola_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbxYeniParola.Text))
            {
                tbxYeniParola.UseSystemPasswordChar = false;
                tbxYeniParola.Text = "Yeni Parola";
                tbxYeniParola.ForeColor = Color.Gray;
            }
        }

        private void pictureboxYeniParola_Click(object sender, EventArgs e)
        {
            tbxYeniParola.UseSystemPasswordChar = !tbxYeniParola.UseSystemPasswordChar;
            if (tbxYeniParola.UseSystemPasswordChar == true)
            {
                string imagePath = @"C:\\Users\\yusuf\\Desktop\\hastane otomasyon\\HastaneOtomasyon\\icons\\hide-password.png";
                pictureboxYeniParola.Image = Image.FromFile(imagePath);
            }
            else
            {
                string imagePath = @"C:\\Users\\yusuf\\Desktop\\hastane otomasyon\\HastaneOtomasyon\\icons\\show-password.png";
                pictureboxYeniParola.Image = Image.FromFile(imagePath);
            }
        }

        private void btnYeniParolaTekrar_Enter(object sender, EventArgs e)
        {
            if (btnYeniParolaTekrar.Text == "Yeni Parola Tekrar")
            {
                btnYeniParolaTekrar.Text = "";
                btnYeniParolaTekrar.ForeColor = Color.Black;
                btnYeniParolaTekrar.UseSystemPasswordChar = true;
            }
        }

        private void btnYeniParolaTekrar_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(btnYeniParolaTekrar.Text))
            {
                btnYeniParolaTekrar.UseSystemPasswordChar = false;
                btnYeniParolaTekrar.Text = "Yeni Parola Tekrar";
                btnYeniParolaTekrar.ForeColor = Color.Gray;
            }
        }

        private void gunaPictureBox1_Click(object sender, EventArgs e)
        {
            btnYeniParolaTekrar.UseSystemPasswordChar = !btnYeniParolaTekrar.UseSystemPasswordChar;
            if (btnYeniParolaTekrar.UseSystemPasswordChar == true)
            {
                string imagePath = @"C:\\Users\\yusuf\\Desktop\\hastane otomasyon\\HastaneOtomasyon\\icons\\hide-password.png";
                gunaPictureBox1.Image = Image.FromFile(imagePath);
            }
            else
            {
                string imagePath = @"C:\\Users\\yusuf\\Desktop\\hastane otomasyon\\HastaneOtomasyon\\icons\\show-password.png";
                gunaPictureBox1.Image = Image.FromFile(imagePath);
            }
        }

        private void btnCıkısYap_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Çıkmak istediğinize emin misiniz?", "Çıkış", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (dialogResult == DialogResult.Yes)
            {
                // Çıkış yap fonksiyonunu çağır
                SessionManager.Instance.CikisYap();
            }
        }

        private void btnParolaKaydet_Click(object sender, EventArgs e)
        {
            string mevcutParola = tbxGecerliParola.Text;
            string yeniParola = tbxYeniParola.Text;
            string yeniParolaTekrar = btnYeniParolaTekrar.Text;

            if (!GecerliParolaDogruMu(mevcutParola))
            {
                MessageBox.Show("Geçerli parola yanlış. Lütfen tekrar deneyin.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (yeniParola != yeniParolaTekrar)
            {
                MessageBox.Show("Yeni parolalar eşleşmiyor. Lütfen tekrar girin.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (ParolaGuncelle(yeniParola))
            {
                MessageBox.Show("Parola başarıyla güncellendi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Parola güncellenirken bir hata oluştu.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool GecerliParolaDogruMu(string mevcutParola)
        {
            bool parolaDogru = false;

            string query = "SELECT COUNT(*) FROM HASTA WHERE HASTANO = :HASTAID AND Parola = :Parola";

            using (OracleConnection connection = new OracleConnection(SessionManager.Instance.ConnectionString))
            {
                OracleCommand command = new OracleCommand(query, connection);
                command.Parameters.Add(new OracleParameter(":HASTAID", SessionManager.Instance.UserId)); 
                command.Parameters.Add(new OracleParameter(":Parola", mevcutParola));

                try
                {
                    connection.Open();
                    int result = Convert.ToInt32(command.ExecuteScalar());

                    if (result > 0)
                    {
                        parolaDogru = true; 
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Veritabanı hatası: " + ex.Message);
                }
            }

            return parolaDogru;
        }


        private bool ParolaGuncelle(string yeniParola)
        {
            bool guncellemeBasarili = false;


            string query = "UPDATE HASTA SET Parola = :YeniParola WHERE HASTANO = :HASTAID";

            using (OracleConnection connection = new OracleConnection(SessionManager.Instance.ConnectionString))
            {
                OracleCommand command = new OracleCommand(query, connection);

                // Parametreleri OracleParameter ile ekleyin
                command.Parameters.Add(new OracleParameter(":YeniParola", yeniParola));
                command.Parameters.Add(new OracleParameter(":HASTAID", SessionManager.Instance.UserId));

                try
                {
                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        guncellemeBasarili = true; 
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Veritabanı güncelleme hatası: " + ex.Message);
                }
            }

            return guncellemeBasarili;
        }


    }
}
