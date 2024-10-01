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
    public partial class MuayeneKayıtları : Form
    {
        private string TcNo;
        public MuayeneKayıtları(string TcNo)
        {
            InitializeComponent();
            this.TcNo = TcNo;
        }
        public MuayeneKayıtları()
        {
            InitializeComponent();
        }

        private void MuayeneKayıtları_Load(object sender, EventArgs e)
        {
            string hastaNo = DataAccess.Hasta.GetHastaNoByTcNo(TcNo);

            if (!string.IsNullOrEmpty(hastaNo))
            {
                MuayeneKayitlariniListele(hastaNo);
            }
            else
            {
                MessageBox.Show("TcNo'ya karşılık gelen hasta bulunamadı.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void MuayeneKayitlariniListele(string hastano)
        {
            using (OracleConnection conn = new OracleConnection(SessionManager.Instance.ConnectionString))
            {
                conn.Open();


                string query = @"
            SELECT 
                M.MUAYENEID AS PROTOKOL, 
                M.HASTANO, 
                P.PERSONELAD || ' ' || PERSONELSOYAD AS HEKIM, 
                K.KLINIKAD AS POLIKLINIK, 
                M.SIKAYET, 
                M.MUAYENETARIHI, 
                M.MUAYENETESHIS AS TESHIS, 
                M.MUAYENESONUC AS SONUC,  
                M.MUAYENE_CIKIS_TARIHI, 
                M.KABUL_SEKLI, 
                M.CIKIS_DURUMU, 
                M.CIKIS_SEKLI, 
                M.VAKA_SEKLI, 
                M.SIRA_NO
            FROM MUAYENE M
            INNER JOIN PERSONEL P ON M.DOKTORID = P.PERSONELID
            INNER JOIN KLINIK K ON M.KLINIKID = K.KLINIKID

            WHERE HASTANO = :hastano
            ORDER BY MUAYENETARIHI DESC";

                OracleCommand cmd = new OracleCommand(query, conn);
                cmd.Parameters.Add(new OracleParameter("hastano", hastano));

                OracleDataAdapter da = new OracleDataAdapter(cmd);
                DataTable dtMuayene = new DataTable();
                da.Fill(dtMuayene);

                dgwMuayeneKayıtları.DataSource = dtMuayene;

                conn.Close();
            }
        }

    }
}
