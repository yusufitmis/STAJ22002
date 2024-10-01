using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HastaneOtomasyon.DataAccess
{
    public class Servis
    {
        public static int GetServisIdByName(string servisAdi)
        {
            int servisID = -1;

            using (OracleConnection conn = new OracleConnection(SessionManager.Instance.ConnectionString))
            {
                conn.Open();
                string query = "SELECT SERVISID FROM SERVIS WHERE SERVISADI = :ServisAdi";
                OracleCommand cmd = new OracleCommand(query, conn);
                cmd.Parameters.Add(new OracleParameter("ServisAdi", servisAdi));

                object result = cmd.ExecuteScalar();

                if (result != null)
                {
                    servisID = Convert.ToInt32(result);
                }
            }

            return servisID;
        }
        public static int GetOdaIdByName(string odaNo)
        {
            int odaID = -1;

            using (OracleConnection conn = new OracleConnection(SessionManager.Instance.ConnectionString))
            {
                conn.Open();
                string query = "SELECT ODAID FROM ODALAR WHERE ODANO = :OdaNo";
                OracleCommand cmd = new OracleCommand(query, conn);
                cmd.Parameters.Add(new OracleParameter("OdaNo", odaNo));

                object result = cmd.ExecuteScalar();

                if (result != null)
                {
                    odaID = Convert.ToInt32(result);
                }
            }

            return odaID;
        }
        public static string GetServisNameById(int servisId)
        {
            string servisAdi = null; 

            using (OracleConnection conn = new OracleConnection(SessionManager.Instance.ConnectionString))
            {
                conn.Open();
                string query = "SELECT SERVISADI FROM SERVIS WHERE SERVISID = :ServisId";
                OracleCommand cmd = new OracleCommand(query, conn);
                cmd.Parameters.Add(new OracleParameter("ServisId", servisId));

                object result = cmd.ExecuteScalar();

                if (result != null)
                {
                    servisAdi = result.ToString(); 
                }
            }

            return servisAdi; 
        }
        public static int GetOdaIdByOdaNo(string odaNo)
        {
            int odaId = -1; 

            using (OracleConnection conn = new OracleConnection(SessionManager.Instance.ConnectionString))
            {
                conn.Open();
               
                string query = "SELECT ODAID FROM ODALAR WHERE ODANO = :odaNo";

                OracleCommand cmd = new OracleCommand(query, conn);
                cmd.Parameters.Add(new OracleParameter(":odaNo", odaNo));

                try
                {
                    using (OracleDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            odaId = Convert.ToInt32(reader["ODAID"]);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Veritabanı hatası: " + ex.Message);
                }

                conn.Close();
            }

            return odaId;
        }



    }
}
