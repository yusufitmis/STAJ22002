using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HastaneOtomasyon.DataAccess
{
    public class Hasta
    {
        public static string GetHastaNoByTcNo(string tcNo)
        {
            string hastaNo = string.Empty;


            string query = "SELECT hastaNo FROM HASTA WHERE hastaTcno = :tcNo";

            using (OracleConnection connection = new OracleConnection(SessionManager.Instance.ConnectionString))
            {
                try
                {
                    connection.Open();

                    using (OracleCommand command = new OracleCommand(query, connection))
                    {

                        command.Parameters.Add(new OracleParameter("tcNo", tcNo));

                        using (OracleDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read()) 
                            {
                                hastaNo = reader["hastaNo"].ToString(); 
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Veritabanı hatası: " + ex.Message);
                }
            }

            return hastaNo; 
        }

    }
}
