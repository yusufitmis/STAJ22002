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
    public partial class TahllGoruntulemeSonucları : Form
    {
        private string TcNo;
        public TahllGoruntulemeSonucları(string TcNo)
        {
            InitializeComponent();
            this.TcNo = TcNo;
        }
        public TahllGoruntulemeSonucları()
        {
            InitializeComponent();
        }

        private void TahllGoruntulemeSonucları_Load(object sender, EventArgs e)
        {
            string hastaNo = DataAccess.Hasta.GetHastaNoByTcNo(TcNo);

            if (!string.IsNullOrEmpty(hastaNo))
            {
                GoruntulemeVeTahlilVerileriListele(hastaNo);
            }
            else
            {
                MessageBox.Show("TcNo'ya karşılık gelen hasta bulunamadı.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void GoruntulemeVeTahlilVerileriListele(string hastano)
        {
            using (OracleConnection conn = new OracleConnection(SessionManager.Instance.ConnectionString))
            {
                conn.Open();

                string goruntulemeQuery = @"
            SELECT GM.GORUNTULEMETARIHI AS TARIH, GM.GORUNTULEMEID AS KODU, GM.MUAYENEID AS PROTOKOL, P.PERSONELAD || ' ' || P.PERSONELSOYAD AS HEKIM, G.GORUNTULEMETURU AS ISLEM_ADI, GM.SONUC AS SONUC
            FROM GORUNTULEMEMUAYENE GM
            INNER JOIN GORUNTULEME G on GM.GORUNTULEMEID = G.GORUNTULEMEID
            INNER JOIN PERSONEL P ON GM.DOKTORID = P.PERSONELID
            WHERE GM.hastano = :hastano 
            ORDER BY TARIH DESC";

                OracleCommand goruntulemeCmd = new OracleCommand(goruntulemeQuery, conn);
                goruntulemeCmd.Parameters.Add(new OracleParameter("hastano", hastano));

                OracleDataAdapter daGoruntuleme = new OracleDataAdapter(goruntulemeCmd);
                DataTable dtGoruntuleme = new DataTable();
                daGoruntuleme.Fill(dtGoruntuleme);

                string tahlilQuery = @"
            SELECT TM.TAHLILTARIH AS TARIH, TM.TAHLILID AS KODU, TM.MUAYENEID AS PROTOKOL, P.PERSONELAD || ' ' || P.PERSONELSOYAD AS HEKIM, T.TAHLILTURU AS ISLEM_ADI, TM.SONUC AS SONUC 
            FROM TAHLILMUAYENE TM
            INNER JOIN TAHLIL T on TM.TAHLILID = T.TAHLILID
            INNER JOIN PERSONEL P ON TM.DOKTORID = P.PERSONELID
            WHERE TM.MUAYENEID = :hastano 
            ORDER BY TARIH DESC";

                OracleCommand tahlilCmd = new OracleCommand(tahlilQuery, conn);
                tahlilCmd.Parameters.Add(new OracleParameter("hastano", hastano));

                OracleDataAdapter daTahlil = new OracleDataAdapter(tahlilCmd);
                DataTable dtTahlil = new DataTable();
                daTahlil.Fill(dtTahlil);

                DataTable combinedTable = dtGoruntuleme.Clone();
                combinedTable.Merge(dtGoruntuleme);
                combinedTable.Merge(dtTahlil);

                dgwTahlilGoruntulemeSonuclari.DataSource = combinedTable;

                conn.Close();
            }
        }
    }
}
