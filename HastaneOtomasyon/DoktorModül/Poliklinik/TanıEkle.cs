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
using static HastaneOtomasyon.DataAccess.Defter;

namespace HastaneOtomasyon.DoktorModül.Poliklinik
{
    public partial class TanıEkle : Form
    {
        
        private string _protokolNo;
        public TanıEkle(string protokolNo)
        {
            InitializeComponent();
            _protokolNo = protokolNo;
        }

        private void TanıEkle_Load(object sender, EventArgs e)
        {
            LoadTanılar();
        }
        private void LoadTanılar()
        {
            using (OracleConnection con = new OracleConnection(SessionManager.Instance.ConnectionString))
            {
                con.Open();
                string query = "SELECT TANI_ID, TANI_ACIKLAMASI, TANI_TURU FROM TANI";

                using (OracleCommand cmd = new OracleCommand(query, con))
                {
                    OracleDataAdapter adapter = new OracleDataAdapter(cmd);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    dgwTanılar.DataSource = dataTable;
                }
            }
        }

        private void tbxSearch_TextChanged(object sender, EventArgs e)
        {
            if (dgwTanılar.DataSource != null)
            {
                (dgwTanılar.DataSource as DataTable).DefaultView.RowFilter = string.Format(
                    "TANI_ACIKLAMASI LIKE '%{0}%' OR TANI_TURU LIKE '%{0}%'",
                    tbxSearch.Text);
            }
        }

        private void btnEkle_Click_1(object sender, EventArgs e)
        {
            if (dgwTanılar.SelectedRows.Count > 0)
            {
                var selectedRow = dgwTanılar.SelectedRows[0];
                int taniId = Convert.ToInt32(selectedRow.Cells["TANI_ID"].Value);

                if (string.IsNullOrEmpty(_protokolNo) || Convert.ToInt32(_protokolNo) <= 0)
                {
                    MessageBox.Show("Muayene ID geçerli değil.");
                    return;
                }

                using (OracleConnection con = new OracleConnection(SessionManager.Instance.ConnectionString))
                {
                    con.Open();

                    string checkQuery = @"
            SELECT COUNT(*) 
            FROM MUAYENETANI 
            WHERE MUAYENE_ID = :muayeneId AND TANI_ID = :taniId";

                    using (OracleCommand checkCmd = new OracleCommand(checkQuery, con))
                    {
                        checkCmd.Parameters.Add(new OracleParameter("muayeneId", Convert.ToInt32(_protokolNo)));
                        checkCmd.Parameters.Add(new OracleParameter("taniId", taniId));

                        int count = Convert.ToInt32(checkCmd.ExecuteScalar());

                        if (count > 0)
                        {
                            MessageBox.Show("Bu tanı zaten eklenmiş.");
                            return;
                        }
                    }

                    string insertQuery = @"
            INSERT INTO MUAYENETANI (MUAYENE_ID, TANI_ID, TANI_ACIKLAMASI, TANI_TURU)
            VALUES (:muayeneId, :taniId, :taniAciklamasi, :taniTuru)";

                    using (OracleCommand cmd = new OracleCommand(insertQuery, con))
                    {
                        cmd.Parameters.Add(new OracleParameter("muayeneId", Convert.ToInt32(_protokolNo)));
                        cmd.Parameters.Add(new OracleParameter("taniId", taniId));
                        cmd.Parameters.Add(new OracleParameter("taniAciklamasi", selectedRow.Cells["TANI_ACIKLAMASI"].Value.ToString()));
                        cmd.Parameters.Add(new OracleParameter("taniTuru", selectedRow.Cells["TANI_TURU"].Value.ToString()));

                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Tanı başarıyla eklendi.");
                this.Close();
                Defter defter = new Defter();
                defter.LoadEklenenTanilar(Convert.ToInt32(_protokolNo));
                defter.Close();
            }
            else
            {
                MessageBox.Show("Lütfen bir tanı seçin.");
            }
        }







    }
}
