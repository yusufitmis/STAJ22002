using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HastaneOtomasyon.DataAccess
{
    public class Polyclinic
    {
        public static void LoadPolyclinicsFromDatabase()
        {
            try
            {
                using (OracleConnection connection = new OracleConnection(SessionManager.Instance.ConnectionString))
                {
                    connection.Open();
                    string query = "SELECT KLINIKAD FROM KLINIK";
                    using (OracleCommand command = new OracleCommand(query, connection))
                    {
                        using (OracleDataReader reader = command.ExecuteReader())
                        {
                            List<string> polyclinicList = new List<string>();
                            while (reader.Read())
                            {
                                polyclinicList.Add(reader.GetString(0));
                            }

                            SessionManager.Instance.Polyclinics = polyclinicList;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Poliklinik listesi yüklenemedi: " + ex.Message);
            }
        }

        public static List<string> GetDoctorsFromDatabase(int klinikid)
        {
            List<string> doctors = new List<string>();

            try
            {
                using (OracleConnection connection = new OracleConnection(SessionManager.Instance.ConnectionString))
                {
                    connection.Open();
                    string query = "SELECT p.personelad" +  
                        " FROM personel p" +
                        " JOIN klinik k ON p.klinikid = k.klinikid" +
                        " WHERE p.unvanid = 2 AND p.klinikid = :klinikid";  

                    using (OracleCommand command = new OracleCommand(query, connection))
                    {
                        command.Parameters.Add(new OracleParameter("klinikid", OracleDbType.Int32)).Value = klinikid;  // Varchar yerine Int32 kullanın

                        using (OracleDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                doctors.Add(reader["personelad"].ToString());
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Doktor listesi yüklenemedi: " + ex.Message);
            }

            return doctors;
        }


        public static int GetPolyclinicIdByName(string polyclinicName)
        {
            int polyclinicId = -1; 
            string connectionString = SessionManager.Instance.ConnectionString;

            try
            {
                using (OracleConnection connection = new OracleConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT klinikid FROM klinik WHERE klinikad = :polyclinicName";

                    using (OracleCommand command = new OracleCommand(query, connection))
                    {
                       
                        command.Parameters.Add(new OracleParameter("polyclinicName", OracleDbType.Varchar2)).Value = polyclinicName;

                        
                        object result = command.ExecuteScalar();

                        if (result != null && int.TryParse(result.ToString(), out polyclinicId))
                        {
                            
                        }
                        else
                        {
                            MessageBox.Show("Poliklinik bulunamadı.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Poliklinik ID'si alınırken bir hata oluştu: " + ex.Message);
            }

            return polyclinicId;
        }
        public static string GetPolyclinicNameById(int id)
        {
            string polyclinicName = string.Empty;

            try
            {
                using (OracleConnection connection = new OracleConnection(SessionManager.Instance.ConnectionString))
                {
                    connection.Open();
                    string query = "SELECT klinikad FROM klinik WHERE klinikid = :klinikid";

                    using (OracleCommand command = new OracleCommand(query, connection))
                    {
                        command.Parameters.Add(new OracleParameter("klinikid", OracleDbType.Int32)).Value = id;

                        object result = command.ExecuteScalar();

                        if (result != null)
                        {
                            polyclinicName = result.ToString();
                        }
                        else
                        {
                            MessageBox.Show("Poliklinik adı alınamadı.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Poliklinik adı alınırken bir hata oluştu: " + ex.Message);
            }

            return polyclinicName;
        }

    }
}
