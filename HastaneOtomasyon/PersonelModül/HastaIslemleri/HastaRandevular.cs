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

namespace HastaneOtomasyon.PersonelModül.HastaIslemleri
{
    public partial class HastaRandevular : Form
    {
        private string TcNo;
        public HastaRandevular(string Tcno)
        {
            InitializeComponent();
            this.TcNo = Tcno;
        }
        public HastaRandevular()
        {
            InitializeComponent();
        }

        private void HastaRandevular_Load(object sender, EventArgs e)
        {
            string hastaNo = DataAccess.Hasta.GetHastaNoByTcNo(TcNo);

            if (!string.IsNullOrEmpty(hastaNo))
            {
                RandevulariListele(hastaNo);
            }
            else
            {
                MessageBox.Show("TcNo'ya karşılık gelen hasta bulunamadı.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void RandevulariListele(string hastano)
        {
          

            using (OracleConnection conn = new OracleConnection(SessionManager.Instance.ConnectionString))
            {
                conn.Open();

                string query = @"
            SELECT 
                R.RANDEVU_ID, 
                PERSONELAD || ' ' || PERSONELSOYAD AS HEKIM , 
                R.DOLULUK_DURUMU, 
                R.RANDEVU_SAATI, 
                R.RANDEVU_TARIHI, 
                K.KLINIKAD AS POLINIKLINIK
            FROM RANDEVULAR R
            INNER JOIN PERSONEL P ON R.DOKTOR_ID = P.PERSONELID
            INNER JOIN KLINIK K ON R.POLIKLINIK_ID = K.KLINIKID
            WHERE HASTA_ID = :hastano
            ORDER BY RANDEVU_TARIHI DESC, RANDEVU_SAATI DESC";

                OracleCommand cmd = new OracleCommand(query, conn);
                cmd.Parameters.Add(new OracleParameter("hastano", hastano));

                OracleDataAdapter da = new OracleDataAdapter(cmd);
                DataTable dtRandevular = new DataTable();
                da.Fill(dtRandevular);

                dgwHastaRandevular.DataSource = dtRandevular;

                conn.Close();
            }
        }

    }
}
