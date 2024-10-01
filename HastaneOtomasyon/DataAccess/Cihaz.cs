using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HastaneOtomasyon.DataAccess
{
    public class Cihaz
    {
        public static string GetTedarikciNameById(int tedarikciId)
        {
            string tedarikciAd = string.Empty;

            using (OracleConnection connection = new OracleConnection(SessionManager.Instance.ConnectionString))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT TEDARIKCIAD FROM TEDARIKCI WHERE TEDARIKCIID = :tedarikciId";

                    using (OracleCommand cmd = new OracleCommand(query, connection))
                    {
                        cmd.Parameters.Add(new OracleParameter("tedarikciId", tedarikciId));

                        object result = cmd.ExecuteScalar();

                        if (result != null)
                        {
                            tedarikciAd = result.ToString();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Tedarikçi adı getirme hatası: " + ex.Message);
                }
            }

            return tedarikciAd;
        }
        public static int GetTedarikciIdByName(string tedarikciAd)
        {
            int tedarikciId = -1; 

            using (OracleConnection connection = new OracleConnection(SessionManager.Instance.ConnectionString))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT TEDARIKCIID FROM TEDARIKCI WHERE TEDARIKCIAD = :tedarikciAd";

                    using (OracleCommand cmd = new OracleCommand(query, connection))
                    {
                        cmd.Parameters.Add(new OracleParameter("tedarikciAd", tedarikciAd));

                        object result = cmd.ExecuteScalar();

                        if (result != null)
                        {
                            tedarikciId = Convert.ToInt32(result);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Tedarikçi ID'si getirme hatası: " + ex.Message);
                }
            }

            return tedarikciId;
        }


    }
}
