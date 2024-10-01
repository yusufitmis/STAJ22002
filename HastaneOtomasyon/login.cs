


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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace HastaneOtomasyon
{
    public partial class login : Form
    {
        private Point fixedLocation = new Point(300, 100);


        public login()
        {
            InitializeComponent();

        }


        private void gunaLabel5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void login_Load(object sender, EventArgs e)
        {
            this.LocationChanged += login_LocationChanged;

            txtBoxLoginHastaTcno.Text = "Hasta TC No";
            txtBoxLoginHastaTcno.ForeColor = Color.Gray;

            txtBoxLoginHastaPassword.Text = "Hasta Şifre";
            txtBoxLoginHastaPassword.ForeColor = Color.Gray;

            txtBoxLoginDoktorKullaniciAdi.Text = "Doktor TC No";
            txtBoxLoginDoktorKullaniciAdi.ForeColor = Color.Gray;

            txtBoxLoginDoktorPassword.Text = "Doktor Şifre";
            txtBoxLoginDoktorPassword.ForeColor = Color.Gray;

            txtBoxLoginPersonelKullaniciAdi.Text = "Personel TC No";
            txtBoxLoginPersonelKullaniciAdi.ForeColor = Color.Gray;

            txtBoxLoginPersonelPassword.Text = "Personel Şifre";
            txtBoxLoginPersonelPassword.ForeColor = Color.Gray;

            groupBoxHastaGiris.Visible = false;
            grbBoxLoginDoktorGiris.Visible = false;
            grbBoxLoginPersonelGiris.Visible = false;
        }

        private void btnHastaLogin_Click(object sender, EventArgs e)
        {
            groupBoxHastaGiris.Visible = true;
            grbBoxLoginDoktorGiris.Visible = false;
            grbBoxLoginPersonelGiris.Visible = false;

        }

        private void btnDoktorLogin_Click(object sender, EventArgs e)
        {
            groupBoxHastaGiris.Visible = false;
            grbBoxLoginDoktorGiris.Visible = true;
            grbBoxLoginPersonelGiris.Visible = false;

        }

        private void btnPersonelLogin_Click(object sender, EventArgs e)
        {
            groupBoxHastaGiris.Visible = false;
            grbBoxLoginDoktorGiris.Visible = false;
            grbBoxLoginPersonelGiris.Visible = true;
        }

        private void txtBoxLoginDoktorKullaniciAdi_Enter(object sender, EventArgs e)
        {
            if (txtBoxLoginDoktorKullaniciAdi.Text == "Doktor TC No")
            {
                txtBoxLoginDoktorKullaniciAdi.Text = "";
                txtBoxLoginDoktorKullaniciAdi.ForeColor = Color.Black;
            }
        }

        private void txtBoxLoginDoktorKullaniciAdi_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtBoxLoginDoktorKullaniciAdi.Text))
            {
                txtBoxLoginDoktorKullaniciAdi.Text = "Doktor TC No";
                txtBoxLoginDoktorKullaniciAdi.ForeColor = Color.Gray;
            }
        }

        private void txtBoxLoginDoktorPassword_Enter(object sender, EventArgs e)
        {
            if (txtBoxLoginDoktorPassword.Text == "Doktor Şifre")
            {
                txtBoxLoginDoktorPassword.Text = "";
                txtBoxLoginDoktorPassword.ForeColor = Color.Black;
            }
        }

        private void txtBoxLoginDoktorPassword_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtBoxLoginDoktorPassword.Text))
            {
                txtBoxLoginDoktorPassword.Text = "Doktor Şifre";
                txtBoxLoginDoktorPassword.ForeColor = Color.Gray;
            }
        }

        private void txtBoxLoginPersonelKullaniciAdi_Enter(object sender, EventArgs e)
        {
            if (txtBoxLoginPersonelKullaniciAdi.Text == "Personel TC No")
            {
                txtBoxLoginPersonelKullaniciAdi.Text = "";
                txtBoxLoginPersonelKullaniciAdi.ForeColor = Color.Black;
            }
        }

        private void txtBoxLoginPersonelKullaniciAdi_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtBoxLoginPersonelKullaniciAdi.Text))
            {
                txtBoxLoginPersonelKullaniciAdi.Text = "Personel TC No";
                txtBoxLoginPersonelKullaniciAdi.ForeColor = Color.Gray;
            }
        }

        private void txtBoxLoginPersonelPassword_Enter(object sender, EventArgs e)
        {
            if (txtBoxLoginPersonelPassword.Text == "Personel Şifre")
            {
                txtBoxLoginPersonelPassword.Text = "";
                txtBoxLoginPersonelPassword.ForeColor = Color.Black;
            }
        }

        private void txtBoxLoginPersonelPassword_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtBoxLoginPersonelPassword.Text))
            {
                txtBoxLoginPersonelPassword.Text = "Personel Şifre";
                txtBoxLoginPersonelPassword.ForeColor = Color.Gray;
            }
        }

        private void txtBoxLoginHastaTcno_Enter(object sender, EventArgs e)
        {
            if (txtBoxLoginHastaTcno.Text == "Hasta TC No")
            {
                txtBoxLoginHastaTcno.Text = "";
                txtBoxLoginHastaTcno.ForeColor = Color.Black;
            }
        }

        private void txtBoxLoginHastaTcno_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtBoxLoginHastaTcno.Text))
            {
                txtBoxLoginHastaTcno.Text = "Hasta TC No";
                txtBoxLoginHastaTcno.ForeColor = Color.Gray;
            }
        }

        private void txtBoxLoginHastaPassword_Enter(object sender, EventArgs e)
        {
            if (txtBoxLoginHastaPassword.Text == "Hasta Şifre")
            {
                txtBoxLoginHastaPassword.Text = "";
                txtBoxLoginHastaPassword.ForeColor = Color.Black;
            }
        }

        private void txtBoxLoginHastaPassword_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtBoxLoginHastaPassword.Text))
            {
                txtBoxLoginHastaPassword.Text = "Hasta Şifre";
                txtBoxLoginHastaPassword.ForeColor = Color.Gray;
            }
        }

        private void gunaLinkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            hastaKayit hastaKayit1 = new hastaKayit();
            hastaKayit1.Show();
            this.Hide();
        }

        private string connectionString = "Data Source=//localhost:1521/TEST.yusufitmis.com;User Id=hastane;Password=123;";
        
        private void btnLoginPersonelGirisyap_Click(object sender, EventArgs e)
        {
            PerformLogin("Personel", txtBoxLoginPersonelKullaniciAdi.Text, txtBoxLoginPersonelPassword.Text);
        }


        private void btnLoginHastaGirisyap_Click(object sender, EventArgs e)
        {
            PerformLogin("Hasta", txtBoxLoginHastaTcno.Text, txtBoxLoginHastaPassword.Text);
        }



        private void btnLoginDoktorGirisyap_Click(object sender, EventArgs e)
        {
            PerformLogin("Doktor", txtBoxLoginDoktorKullaniciAdi.Text, txtBoxLoginDoktorPassword.Text);
        }

        private void login_LocationChanged(object sender, EventArgs e)
        {
            this.Location = fixedLocation;

        }
        private void PerformLogin(string userType, string tcNo, string password)
        {
            tcNo = tcNo.Trim();
            password = password.Trim();

            using (OracleConnection connection = new OracleConnection(connectionString))
            {
                connection.Open();
                string query = "";

                if (userType == "Hasta")
                {
                    query = "SELECT HASTANO, HASTALAD, HASTASOYAD, HASTADTARIHI, HASTAADRES, HASTATELNO, HASTAEPOSTA, HASTACINSIYET, SOSYALGUVENCE, KANGRUBU " +
                            "FROM HASTA WHERE HASTATCNO = :TcNo AND PAROLA = :Password";
                }
                else if (userType == "Doktor")
                {
                    query = "SELECT PERSONELID, PERSONELAD, PERSONELSOYAD, PERSONELDTARIHI, PERSONELADRES, PERSONELTELNO, PERSONELEPOSTA, PERSONELCINSIYET, PERSONELGOREV, PERSONELOGRENIM, PERSONELDIPLOMANO  " +
                             "FROM PERSONEL WHERE UNVANID=2 AND PERSONELTCNO = :TcNo AND PAROLA = :Password";
                }
                else if (userType == "Personel")
                {
                    query = "SELECT PERSONELID, PERSONELAD, PERSONELSOYAD, PERSONELDTARIHI, PERSONELADRES, PERSONELTELNO, PERSONELEPOSTA, PERSONELCINSIYET, PERSONELGOREV, PERSONELOGRENIM, PERSONELDIPLOMANO " +
                            "FROM PERSONEL WHERE PERSONELTCNO = :TcNo AND PAROLA = :Password";
                }


                using (OracleCommand command = new OracleCommand(query, connection))
                {
                    command.Parameters.Add(new OracleParameter("TcNo", tcNo));
                    command.Parameters.Add(new OracleParameter("Password", password));

                    using (OracleDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            SessionManager.Instance.UserTc = tcNo;
                            SessionManager.Instance.UserType = userType;

                            if (userType == "Hasta")
                            {
                                SessionManager.Instance.UserId = Convert.ToInt32(reader["HASTANO"]);
                                SessionManager.Instance.UserName = reader["HASTALAD"].ToString();
                                SessionManager.Instance.UserSurname = reader["HASTASOYAD"].ToString();
                                SessionManager.Instance.UserFullName = $"{reader["HASTALAD"]} {reader["HASTASOYAD"]}";
                                SessionManager.Instance.UserDTarihi = reader["HASTADTARIHI"].ToString();
                                SessionManager.Instance.UserGender = reader["HASTACINSIYET"].ToString();
                                SessionManager.Instance.UserTelNo = reader["HASTATELNO"].ToString();
                                SessionManager.Instance.UserEposta = reader["HASTAEPOSTA"].ToString();
                                SessionManager.Instance.UserKan = reader["KANGRUBU"].ToString();
                                SessionManager.Instance.UserSosyalGuvence = reader["SOSYALGUVENCE"].ToString();

                                hastaHome hastaHome = new hastaHome();
                                hastaHome.Show();
                                this.Hide();
                            }
                            else if (userType == "Doktor" || userType == "Personel")
                            {
                                SessionManager.Instance.UserId = Convert.ToInt32(reader["PERSONELID"]);
                                SessionManager.Instance.UserName = reader["PERSONELAD"].ToString();
                                SessionManager.Instance.UserSurname = reader["PERSONELSOYAD"].ToString();
                                SessionManager.Instance.UserFullName = $"{reader["PERSONELAD"]} {reader["PERSONELSOYAD"]}";
                                SessionManager.Instance.UserDTarihi = reader["PERSONELDTARIHI"].ToString();
                                SessionManager.Instance.UserGender = reader["PERSONELCINSIYET"].ToString();
                                SessionManager.Instance.UserTelNo = reader["PERSONELTELNO"].ToString();
                                SessionManager.Instance.UserEposta = reader["PERSONELEPOSTA"].ToString();
                                SessionManager.Instance.Gorev = reader["PERSONELGOREV"].ToString();
                                SessionManager.Instance.Ogrenim = reader["PERSONELOGRENIM"].ToString();
                                SessionManager.Instance.DiplomaNo = reader["PERSONELDIPLOMANO"].ToString();





                                if (userType == "Doktor")
                                {
                                    DoktorModül.HastaKabul hastaKabul = new DoktorModül.HastaKabul();
                                    hastaKabul.Show();
                                }
                                else
                                {
                                    PersonelModül.PersonelIslemleri.PersonelIslemleri personelIslemleri = new PersonelModül.PersonelIslemleri.PersonelIslemleri();
                                    personelIslemleri.Show();
                                }
                                this.Hide();
                            }
                        }
                        else
                        {
                            MessageBox.Show("Giriş başarısız. TC No veya şifre yanlış.");
                        }
                    }
                }
            }
        }

        private void gunaPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
