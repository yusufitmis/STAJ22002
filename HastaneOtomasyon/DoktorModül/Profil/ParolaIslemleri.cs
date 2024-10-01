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

namespace HastaneOtomasyon.DoktorModül.Profil
{
    public partial class ParolaIslemleri : Form
    {
        private Point fixedLocation = new Point(100, 50);
        public ParolaIslemleri()
        {
            InitializeComponent();
        }

        private void gunaButton1_Click(object sender, EventArgs e)
        {
            Application.Exit();
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

        private void btnHastaHomeProfil_Click(object sender, EventArgs e)
        {
            grbBoxProfil.Visible = !grbBoxProfil.Visible;
        }

        private void btnHastaKabul_Click(object sender, EventArgs e)
        {
            DoktorModül.HastaKabul hastaKabul = new DoktorModül.HastaKabul();
            hastaKabul.Show();
            this.Close();
        }

        private void btnPoliklinik_Click(object sender, EventArgs e)
        {
            DoktorModül.Poliklinik.Defter defter = new DoktorModül.Poliklinik.Defter();
            defter.Show();
            this.Close();
        }

        private void btnİletişimBilgileri_Click(object sender, EventArgs e)
        {
            DoktorModül.Profil.IletisimBilgileri ıletisimBilgileri = new DoktorModül.Profil.IletisimBilgileri();
            ıletisimBilgileri.Show();
            this.Close();
        }

        private void btnKimlikBilgiler_Click(object sender, EventArgs e)
        {
            DoktorModül.Profil.KisiselBilgiler kisiselBilgiler = new DoktorModül.Profil.KisiselBilgiler();
            kisiselBilgiler.Show();
            this.Close();
        }

        private void tbxGecerliParola_Enter(object sender, EventArgs e)
        {
            if (tbxGecerliParola.Text == "Geçerli Parola")
            {
                tbxGecerliParola.Text = "";
                tbxGecerliParola.ForeColor = Color.Black;
                tbxGecerliParola.UseSystemPasswordChar = true;
            }
        }

        private void tbxGecerliParola_Leave(object sender, EventArgs e)
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
            else
            {
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
                SessionManager.Instance.CikisYap();
            }
        }
       

        private bool GecerliParolaDogruMu(string mevcutParola)
        {
            bool parolaDogru = false;

            string query = "SELECT COUNT(*) FROM personel WHERE personelid = :personelid AND Parola = :Parola";

            using (OracleConnection connection = new OracleConnection(SessionManager.Instance.ConnectionString))
            {
                OracleCommand command = new OracleCommand(query, connection);
                command.Parameters.Add(new OracleParameter(":personelid", SessionManager.Instance.UserId));
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


            string query = "UPDATE personel SET Parola = :YeniParola WHERE personelid = :personelid";

            using (OracleConnection connection = new OracleConnection(SessionManager.Instance.ConnectionString))
            {
                OracleCommand command = new OracleCommand(query, connection);

                command.Parameters.Add(new OracleParameter(":YeniParola", yeniParola));
                command.Parameters.Add(new OracleParameter(":personelid", SessionManager.Instance.UserId));

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

        private void btnLoginDoktorGirisyap_Click(object sender, EventArgs e)
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
    }
}
