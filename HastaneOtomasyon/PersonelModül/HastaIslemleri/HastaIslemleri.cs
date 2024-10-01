using HastaneOtomasyon.DataAccess;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HastaneOtomasyon.PersonelModül.HastaIslemleri
{
    public partial class HastaIslemleri : Form
    {
        private Point fixedLocation = new Point(100, 50);
        public HastaIslemleri()
        {
            InitializeComponent();
        }

        private void HastaIslemleri_Load(object sender, EventArgs e)
        {
            this.LocationChanged += HastaIslemleri_LocationChanged;

            grbBoxProfil.Visible = false;
            ListeleHastalar();
            tbxSearch.Text = "Hasta Ara";
            tbxSearch.ForeColor = Color.Gray;
            pnlHastaGuncelleme.Visible = false;

        }

        private void HastaIslemleri_LocationChanged(object sender, EventArgs e)
        {
            this.Location = fixedLocation;
        }

        private void gunaButton1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void tbxSearch_Enter(object sender, EventArgs e)
        {
            if (tbxSearch.Text == "Hasta Ara")
            {
                tbxSearch.Text = "";
                tbxSearch.ForeColor = Color.Black;
            }
        }

        private void tbxSearch_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbxSearch.Text))
            {
                tbxSearch.Text = "Hasta Ara";
                tbxSearch.ForeColor = Color.Gray;
            }
        }

        private void btnPersonelIslem_Click(object sender, EventArgs e)
        {

            PersonelModül.PersonelIslemleri.PersonelIslemleri personelIslemleri = new PersonelModül.PersonelIslemleri.PersonelIslemleri();
            personelIslemleri.Show();
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

        private void btnCıkısYap_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Çıkmak istediğinize emin misiniz?", "Çıkış", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (dialogResult == DialogResult.Yes)
            {
                SessionManager.Instance.CikisYap();
            }
        }
        private void ListeleHastalar(string searchQuery = "")
        {
            try
            {
                using (OracleConnection connection = new OracleConnection(DataAccess.SessionManager.Instance.ConnectionString))
                {
                    connection.Open();

                    string query = "SELECT HASTANO, HASTAlAD, HASTASOYAD, HASTADTARIHI, HASTATCNO, HASTACINSIYET, KANGRUBU " +
                                   "FROM hasta ";
                    if (!string.IsNullOrWhiteSpace(searchQuery))
                    {
                        query += "WHERE LOWER(HASTAlAD) LIKE '%' || :searchQuery || '%' " +
                                 "OR LOWER(HASTASOYAD) LIKE '%' || :searchQuery || '%' " +
                                 "OR LOWER(HASTATCNO) LIKE '%' || :searchQuery || '%' ";
                    }

                    query += "ORDER BY HASTANO";

                    OracleCommand command = new OracleCommand(query, connection);

                    if (!string.IsNullOrWhiteSpace(searchQuery))
                    {
                        command.Parameters.Add(":searchQuery", OracleDbType.Varchar2).Value = searchQuery.ToLower();
                    }

                    OracleDataAdapter dataAdapter = new OracleDataAdapter(command);
                    DataSet dataSet = new DataSet();

                    dataAdapter.Fill(dataSet);

                    dgwHastalar.DataSource = dataSet.Tables[0];
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Veritabanı bağlantısı sırasında bir hata oluştu: " + ex.Message);
            }
        }


        private void tbxSearch_TextChanged(object sender, EventArgs e)
        {
            string searchText = tbxSearch.Text.Trim();


            if (searchText == "Hasta Ara" || string.IsNullOrWhiteSpace(searchText))
            {
                ListeleHastalar();
            }
            else
            {
                ListeleHastalar(searchText);
            }
        }

        private Panel pnlHastaEkle;
        private Button btnEkle, btnKapat;
        private TextBox tbxHastaNo, tbxHastaAd, tbxHastaSoyad, tbxHastaAdres, tbxHastaTcNo, tbxHastaTelNo, tbxHastaEposta, tbxHastaKanGrubu, tbxParola;
        private ComboBox cbxHastaCinsiyet, cbxSosyalGuvence;

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private DateTimePicker dtpDogumTarihi;

        private void btnHastaEkle_Click(object sender, EventArgs e)
        {

            if (pnlHastaEkle != null && pnlHastaEkle.Visible)
            {
                pnlHastaEkle.Visible = true;
                pnlHastaEkle.BringToFront();
            }
            else
            {

                pnlHastaEkle = new Panel();
                pnlHastaEkle.Size = new Size(400, 600);
                pnlHastaEkle.Location = new Point(50, 50);
                pnlHastaEkle.BorderStyle = BorderStyle.FixedSingle;
                pnlHastaEkle.BackColor = Color.CadetBlue;
                pnlHastaEkle.ForeColor = Color.White;
                pnlHastaEkle.Font = new Font("Arial", 10, FontStyle.Bold);
                pnlHastaEkle.BringToFront();



                AddLabelAndTextBoxToPanel("Hasta Adı", out tbxHastaAd, 20);
                AddLabelAndTextBoxToPanel("Hasta Soyadı", out tbxHastaSoyad, 60);
                AddLabelAndTextBoxToPanel("Adres", out tbxHastaAdres, 100, multiline: true);
                AddLabelAndDatePickerToPanel("Doğum Tarihi", out dtpDogumTarihi, 200);
                AddLabelAndTextBoxToPanel("TC No", out tbxHastaTcNo, 240);
                AddLabelAndTextBoxToPanel("Telefon No", out tbxHastaTelNo, 280);
                AddLabelAndTextBoxToPanel("E-Posta", out tbxHastaEposta, 320);
                AddLabelAndComboBoxToPanel("Cinsiyet", out cbxHastaCinsiyet, new string[] { "E", "K" }, 360);
                AddLabelAndTextBoxToPanel("Kan Grubu", out tbxHastaKanGrubu, 400);
                AddLabelAndComboBoxToPanel("Sosyal Güvence", out cbxSosyalGuvence, new string[]
                {
                    "SGK (Sosyal Güvenlik Kurumu) - Genel kapsamlı sağlık sigortası",
                    "Bağ-Kur - Bağımsız çalışanlar için sosyal güvenlik",
                    "Emekli Sandığı - Kamu çalışanları ve emeklileri için sosyal güvenlik",
                    "Özel Sigorta - Özel sağlık sigortası olanlar için",
                    "Yeşil Kart - Düşük gelirli vatandaşlar için sağlık sigortası",
                    "GSS (Genel Sağlık Sigortası) - Genel sağlık güvencesi kapsamında olanlar",
                    "Öğrenci Sağlık Sigortası - Öğrenciler için özel sağlık güvencesi",
                    "Askeri Sigorta - Askeri personel ve aileleri için sağlık güvencesi",
                    "Hiçbiri - Herhangi bir sosyal güvencesi olmayanlar için"
                }, 440);
                AddLabelAndTextBoxToPanel("Parola", out tbxParola, 480);

                btnEkle = new Button();
                btnEkle.Text = "Ekle";
                btnEkle.Location = new Point(100, 520);
                btnEkle.BackColor = Color.White;
                btnEkle.ForeColor = Color.Black;
                btnEkle.Font = new Font("Arial", 12, FontStyle.Bold);

                btnEkle.Click += btnEkle_Click;
                pnlHastaEkle.Controls.Add(btnEkle);


                btnKapat = new Button();
                btnKapat.Text = "Kapat";
                btnKapat.Location = new Point(200, 520);
                btnKapat.BackColor = Color.White;
                btnKapat.ForeColor = Color.Black;
                btnKapat.Font = new Font("Arial", 10, FontStyle.Bold);

                btnKapat.Click += BtnKapat_Click;
                pnlHastaEkle.Controls.Add(btnKapat);

                this.Controls.Add(pnlHastaEkle);
                pnlHastaEkle.BringToFront();

            }
        }

        private void AddLabelAndTextBoxToPanel(string labelText, out TextBox textBox, int yPosition, bool multiline = false)
        {
            Label label = new Label();
            label.Text = labelText;
            label.Location = new Point(20, yPosition);
            pnlHastaEkle.Controls.Add(label);

            textBox = new TextBox();
            textBox.Location = new Point(150, yPosition);
            textBox.Size = new Size(200, multiline ? 60 : 30);
            textBox.Multiline = multiline;
            pnlHastaEkle.Controls.Add(textBox);
        }

        

        private void AddLabelAndComboBoxToPanel(string labelText, out ComboBox comboBox, string[] items, int yPosition)
        {
            Label label = new Label();
            label.Text = labelText;
            label.Location = new Point(20, yPosition);
            pnlHastaEkle.Controls.Add(label);

            comboBox = new ComboBox();
            comboBox.Location = new Point(150, yPosition);
            comboBox.Size = new Size(200, 30);
            comboBox.Items.AddRange(items);
            pnlHastaEkle.Controls.Add(comboBox);
        }

        

        private void AddLabelAndDatePickerToPanel(string labelText, out DateTimePicker datePicker, int yPosition)
        {

            Label label = new Label();
            label.Text = labelText;
            label.Location = new Point(20, yPosition);
            pnlHastaEkle.Controls.Add(label);

            datePicker = new DateTimePicker();
            datePicker.Location = new Point(150, yPosition);
            datePicker.Format = DateTimePickerFormat.Custom;
            datePicker.CustomFormat = "dd-MM-yyyy";
            pnlHastaEkle.Controls.Add(datePicker);
        }



        private void btnHastaSil_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(TcNo)) 
            {
                DialogResult result = MessageBox.Show("Bu hastayı silmek istediğinize emin misiniz?", "Silme Onayı", MessageBoxButtons.YesNo);

                if (result == DialogResult.Yes)
                {
                    try
                    {
                        using (OracleConnection con = new OracleConnection(SessionManager.Instance.ConnectionString))
                        {
                            con.Open();

                            string query = "DELETE FROM HASTA WHERE hastaTCNo = :TcNo";
                            using (OracleCommand cmd = new OracleCommand(query, con))
                            {
                                cmd.Parameters.Add(new OracleParameter(":TcNo", TcNo)); 
                                cmd.ExecuteNonQuery();
                            }
                            MessageBox.Show("Hasta başarıyla silindi.");
                            ListeleHastalar();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Hata: " + ex.Message);
                    }
                }
            }
            else
            {
                MessageBox.Show("Lütfen bir hasta seçin.");
            }
        }

        private void btnHastaGörüntüle_Click(object sender, EventArgs e)
        {
            if (dgwHastalar.SelectedRows.Count == 0)
            {
                MessageBox.Show("Görev tanımlamak için bir personel seçiniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DataGridViewRow selectedRow = dgwHastalar.SelectedRows[0];
            string selectedhastaTcNo =selectedRow.Cells["hastatcno"].Value.ToString();


            BilgileriGoruntule bilgileriGoruntule = new BilgileriGoruntule(selectedhastaTcNo);
            bilgileriGoruntule.ShowDialog();
        }

        private void btnTahlilGoruntuleme_Click(object sender, EventArgs e)
        {
            PersonelModül.HastaIslemleri.TahllGoruntulemeSonucları tahllGoruntulemeSonucları = new PersonelModül.HastaIslemleri.TahllGoruntulemeSonucları(TcNo);
            tahllGoruntulemeSonucları.Show();
        }

        private void btnHastaRandevuları_Click(object sender, EventArgs e)
        {
            PersonelModül.HastaIslemleri.HastaRandevular hastaRandevular = new PersonelModül.HastaIslemleri.HastaRandevular(TcNo);
            hastaRandevular.Show();
        }

        private void btnMuayeneKayıtları_Click(object sender, EventArgs e)
        {
            PersonelModül.HastaIslemleri.MuayeneKayıtları muayeneKayıtları = new PersonelModül.HastaIslemleri.MuayeneKayıtları(TcNo);
            muayeneKayıtları.Show();
        }

        private void btnHastaReceteleri_Click(object sender, EventArgs e)
        {

        }

        private bool TcKimlikNumarasiVarMi(string tcNo)
        {
            bool exists = false;
            try
            {
                using (OracleConnection connection = new OracleConnection(DataAccess.SessionManager.Instance.ConnectionString))
                {
                    connection.Open();

                    string query = "SELECT COUNT(*) FROM Hasta WHERE HASTATCNO = :tcNo";
                    OracleCommand command = new OracleCommand(query, connection);
                    command.Parameters.Add(":tcNo", OracleDbType.Varchar2).Value = tcNo;

                    int count = Convert.ToInt32(command.ExecuteScalar());
                    if (count > 0)
                    {
                        exists = true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Veritabanı bağlantısı sırasında bir hata oluştu: " + ex.Message);
            }

            return exists;
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            string tcNo = tbxHastaTcNo.Text.Trim();


            if (TcKimlikNumarasiVarMi(tcNo))
            {
                MessageBox.Show("Bu TC kimlik numarasına sahip bir hasta zaten kayıtlı.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                DateTime dateOnly = dtpDogumTarihi.Value.Date;
                using (OracleConnection connection = new OracleConnection(DataAccess.SessionManager.Instance.ConnectionString))
                {
                    connection.Open();

                    string query = "INSERT INTO Hasta (HASTAlAD, HASTASOYAD, HASTADTARIHI, HASTATCNO, HASTACINSIYET, KANGRUBU, HASTAADRES, HASTATELNO, HASTAEPOSTA, PAROLA) " +
                                   "VALUES (:ad, :soyad, :dogumTarihi, :tcNo, :cinsiyet, :kanGrubu, :adres, :telNo, :eposta, :parola)";

                    OracleCommand command = new OracleCommand(query, connection);
                    command.Parameters.Add(":ad", OracleDbType.Varchar2).Value = string.IsNullOrWhiteSpace(tbxHastaAd.Text) ? (object)DBNull.Value : tbxHastaAd.Text;
                    command.Parameters.Add(":soyad", OracleDbType.Varchar2).Value = string.IsNullOrWhiteSpace(tbxHastaSoyad.Text) ? (object)DBNull.Value : tbxHastaSoyad.Text;
                    command.Parameters.Add(":dogumTarihi", OracleDbType.Date).Value = dateOnly == default(DateTime) ? (object)DBNull.Value : dateOnly;
                    command.Parameters.Add(":tcNo", OracleDbType.Varchar2).Value = string.IsNullOrWhiteSpace(tcNo) ? (object)DBNull.Value : tcNo;
                    command.Parameters.Add(":cinsiyet", OracleDbType.Varchar2).Value = cbxHastaCinsiyet.SelectedItem == null ? (object)DBNull.Value : cbxHastaCinsiyet.SelectedItem.ToString();
                    command.Parameters.Add(":kanGrubu", OracleDbType.Varchar2).Value = string.IsNullOrWhiteSpace(tbxHastaKanGrubu.Text) ? (object)DBNull.Value : tbxHastaKanGrubu.Text;
                    command.Parameters.Add(":adres", OracleDbType.Varchar2).Value = string.IsNullOrWhiteSpace(tbxHastaAdres.Text) ? (object)DBNull.Value : tbxHastaAdres.Text;
                    command.Parameters.Add(":telNo", OracleDbType.Varchar2).Value = string.IsNullOrWhiteSpace(tbxHastaTelNo.Text) ? (object)DBNull.Value : tbxHastaTelNo.Text;
                    command.Parameters.Add(":eposta", OracleDbType.Varchar2).Value = string.IsNullOrWhiteSpace(tbxHastaEposta.Text) ? (object)DBNull.Value : tbxHastaEposta.Text;
                    command.Parameters.Add(":parola", OracleDbType.Varchar2).Value = string.IsNullOrWhiteSpace(tbxParola.Text) ? (object)DBNull.Value : tbxParola.Text;

                    command.ExecuteNonQuery();

                    MessageBox.Show("Hasta başarıyla eklendi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ListeleHastalar();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Veritabanı bağlantısı sırasında bir hata oluştu: " + ex.Message);
            }
        }


        private void BtnKapat_Click(object sender, EventArgs e)
        {
            pnlHastaEkle.Visible = false;
        }
        private string TcNo;

        private void dgwHastalar_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var selectedRow = dgwHastalar.Rows[e.RowIndex];
                TcNo = selectedRow.Cells["hastaTCNo"].Value.ToString();
            }
        }

        private void btnHastaGuncelle_Click(object sender, EventArgs e)
        {
            pnlHastaGuncelleme.Visible = true;

            Hasta hasta = VeritabaniGetirHastaBilgileri(TcNo);

            if (hasta != null)
            {
                tbxAd.Text = hasta.Ad;
                tbxSoyad.Text = hasta.Soyad;
                tbxTcNo.Text = hasta.TcNo;
                cbxCins.SelectedItem = hasta.Cinsiyet;
                tbxKan.Text = hasta.KanGrubu;
                cbxSosyal.SelectedItem = hasta.SosyalGuvence;
                tbxEposta.Text = hasta.Eposta;
                tbxTelefon.Text = hasta.TelNo;
                dtpDtar.Value = hasta.DogumTarihi;
                tbxAdres.Text = hasta.Adres;
                tbxPassw.Text = hasta.Parola;
            }
        }

        private Hasta VeritabaniGetirHastaBilgileri(string tcNo)
        {
            using (OracleConnection connection = new OracleConnection(SessionManager.Instance.ConnectionString))
            {
                connection.Open();
                string query = "SELECT * FROM Hasta WHERE hastaTCNo = :TcNo";
                using (OracleCommand command = new OracleCommand(query, connection))
                {
                    command.Parameters.Add(new OracleParameter("TcNo", tcNo));
                    using (OracleDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Hasta
                            {
                                Ad = reader["hastalAd"].ToString(),
                                Soyad = reader["hastaSoyad"].ToString(),
                                TcNo = reader["hastaTCNo"].ToString(),
                                Cinsiyet = reader["hastaCinsiyet"].ToString(),
                                KanGrubu = reader["kanGrubu"].ToString(),
                                SosyalGuvence = reader["sosyalGuvence"].ToString(),
                                Eposta = reader["hastaEposta"].ToString(),
                                TelNo = reader["hastaTelNo"].ToString(),
                                DogumTarihi = Convert.ToDateTime(reader["hastaDTarihi"]),
                                Adres = reader["hastaAdres"].ToString(),
                                Parola = reader["Parola"].ToString()
                            };
                        }
                    }
                }
            }
            return null;
        }

        private void VeritabaniGuncelleHastaBilgileri(Hasta hasta)
        {
            using (OracleConnection connection = new OracleConnection(SessionManager.Instance.ConnectionString))
            {
                connection.Open();

                var queryBuilder = new StringBuilder("UPDATE Hasta SET ");
                var parameters = new List<OracleParameter>();
                bool first = true;

                if (!string.IsNullOrEmpty(hasta.Ad))
                {
                    if (!first) queryBuilder.Append(", ");
                    queryBuilder.Append("hastalAd = :Ad");
                    parameters.Add(new OracleParameter("Ad", hasta.Ad));
                    first = false;
                }

                if (!string.IsNullOrEmpty(hasta.Soyad))
                {
                    if (!first) queryBuilder.Append(", ");
                    queryBuilder.Append("hastaSoyad = :Soyad");
                    parameters.Add(new OracleParameter("Soyad", hasta.Soyad));
                    first = false;
                }

                if (!string.IsNullOrEmpty(hasta.Cinsiyet))
                {
                    if (!first) queryBuilder.Append(", ");
                    queryBuilder.Append("hastaCinsiyet = :Cinsiyet");
                    parameters.Add(new OracleParameter("Cinsiyet", hasta.Cinsiyet));
                    first = false;
                }

                if (!string.IsNullOrEmpty(hasta.KanGrubu))
                {
                    if (!first) queryBuilder.Append(", ");
                    queryBuilder.Append("kanGrubu = :KanGrubu");
                    parameters.Add(new OracleParameter("KanGrubu", hasta.KanGrubu));
                    first = false;
                }

                if (!string.IsNullOrEmpty(hasta.SosyalGuvence))
                {
                    if (!first) queryBuilder.Append(", ");
                    queryBuilder.Append("sosyalGuvence = :SosyalGuvence");
                    parameters.Add(new OracleParameter("SosyalGuvence", hasta.SosyalGuvence));
                    first = false;
                }

                if (!string.IsNullOrEmpty(hasta.Eposta))
                {
                    if (!first) queryBuilder.Append(", ");
                    queryBuilder.Append("hastaEposta = :Eposta");
                    parameters.Add(new OracleParameter("Eposta", hasta.Eposta));
                    first = false;
                }

                if (!string.IsNullOrEmpty(hasta.TelNo))
                {
                    if (!first) queryBuilder.Append(", ");
                    queryBuilder.Append("hastaTelNo = :TelNo");
                    parameters.Add(new OracleParameter("TelNo", hasta.TelNo));
                    first = false;
                }

                if (hasta.DogumTarihi != DateTime.MinValue)
                {
                    if (!first) queryBuilder.Append(", ");
                    queryBuilder.Append("hastaDTarihi = :DogumTarihi");
                    parameters.Add(new OracleParameter("DogumTarihi", hasta.DogumTarihi.Date));
                    first = false;
                }

                if (!string.IsNullOrEmpty(hasta.Adres))
                {
                    if (!first) queryBuilder.Append(", ");
                    queryBuilder.Append("hastaAdres = :Adres");
                    parameters.Add(new OracleParameter("Adres", hasta.Adres));
                    first = false;
                }

                if (!string.IsNullOrEmpty(hasta.Parola))
                {
                    if (!first) queryBuilder.Append(", ");
                    queryBuilder.Append("Parola = :Parola");
                    parameters.Add(new OracleParameter("Parola", hasta.Parola));
                    first = false;
                }

                queryBuilder.Append(" WHERE hastaTCNo = :TCNo");
                parameters.Add(new OracleParameter("TCNo", hasta.TcNo));

                using (OracleCommand command = new OracleCommand(queryBuilder.ToString(), connection))
                {
                    command.Parameters.AddRange(parameters.ToArray());
                    command.ExecuteNonQuery();
                }
            }
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            Hasta hasta = new Hasta
            {
                Ad = tbxAd.Text,
                Soyad = tbxSoyad.Text,
                TcNo = tbxTcNo.Text,
                Cinsiyet = cbxCins.SelectedItem?.ToString(),
                KanGrubu = tbxKan.Text,
                SosyalGuvence = cbxSosyal.SelectedItem?.ToString(),
                Eposta = tbxEposta.Text,
                TelNo = tbxTelefon.Text,
                DogumTarihi = dtpDtar.Value,
                Adres = tbxAdres.Text,
                Parola = tbxPassw.Text
            };

            VeritabaniGuncelleHastaBilgileri(hasta);
            MessageBox.Show("Hasta bilgileri başarıyla güncellendi.");
            pnlHastaGuncelleme.Visible = false;
            ListeleHastalar();
        }

        private void btnKapat1_Click(object sender, EventArgs e)
        {
            pnlHastaGuncelleme.Visible = false;
        }

    }
    public class Hasta
    {
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public string TcNo { get; set; }
        public int HastaNo { get; set; }
        public string Cinsiyet { get; set; }
        public string KanGrubu { get; set; }
        public string SosyalGuvence { get; set; }
        public string Eposta { get; set; }
        public string TelNo { get; set; }
        public DateTime DogumTarihi { get; set; }
        public string Adres { get; set; }
        public string Parola { get; set; }
    }
}
