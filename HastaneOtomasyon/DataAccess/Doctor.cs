using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HastaneOtomasyon.DataAccess
{
    public class Doctor
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Address { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string TCNo { get; set; }
        public string PhoneNo { get; set; }
        public string Email { get; set; }
        public string Education { get; set; }
        public string DiplomaNo { get; set; }
        public string SicilNo { get; set; }
        public int TitleId { get; set; }
        public int ClinicId { get; set; }
        public string Gender { get; set; }
        public string Password { get; set; }

        public int GetDoctorIdByName(string doctorName)
        {
            int doctorId = -1; // ID bulunamazsa varsayılan değer olarak -1 kullanıyoruz

            string query = @"
                        SELECT p.personelid
                        FROM personel p
                        WHERE p.personelad = :DoctorName";

            try
            {
                using (OracleConnection conn = new OracleConnection(SessionManager.Instance.ConnectionString))
                {
                    conn.Open();

                    using (OracleCommand cmd = new OracleCommand(query, conn))
                    {
                        cmd.Parameters.Add(new OracleParameter("DoctorName", OracleDbType.Varchar2)).Value = doctorName;

                        object result = cmd.ExecuteScalar();
                        if (result != null)
                        {
                            doctorId = Convert.ToInt32(result);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Doktor ID'si alınırken bir hata oluştu: " + ex.Message);
            }

            return doctorId;
        }

        public string GetDoctorNameById(int doctorId)
        {
            string doctorFullName = string.Empty; // Eğer doktor bulunamazsa boş bir string döndürüyoruz

            string query = @"
    SELECT p.personelad, p.personelsoyad
    FROM personel p
    WHERE p.personelid = :DoctorId";

            try
            {
                using (OracleConnection conn = new OracleConnection(SessionManager.Instance.ConnectionString))
                {
                    conn.Open();

                    using (OracleCommand cmd = new OracleCommand(query, conn))
                    {
                        cmd.Parameters.Add(new OracleParameter("DoctorId", OracleDbType.Int32)).Value = doctorId;

                        using (OracleDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                string firstName = reader["personelad"] != DBNull.Value ? reader["personelad"].ToString() : string.Empty;
                                string lastName = reader["personelsoyad"] != DBNull.Value ? reader["personelsoyad"].ToString() : string.Empty;
                                doctorFullName = $"{firstName} {lastName}".Trim(); // Ad ve soyadı birleştiriyoruz
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Doktor adı alınırken bir hata oluştu: " + ex.Message);
            }

            return doctorFullName;
        }
        public static Doctor GetDoctor(int doctorId)
        {
            Doctor doctor = null;
            string query = @"
            SELECT p.personelad, p.personelsoyad, p.personelid, p.personeladres, p.personeldtarihi, p.personeltcno, p.personeltelno, p.personeleposta, 
                   p.personelogrenim, p.personeldiplomano, p.personelsicilno, p.unvanid, p.klinikid, p.personelcinsiyet, p.parola
            FROM personel p
            WHERE p.personelid = :DoctorId AND p.unvanid = 2";

            try
            {
                using (OracleConnection conn = new OracleConnection(SessionManager.Instance.ConnectionString))
                {
                    conn.Open();

                    using (OracleCommand cmd = new OracleCommand(query, conn))
                    {
                        cmd.Parameters.Add(new OracleParameter("DoctorId", OracleDbType.Int32)).Value = doctorId;

                        using (OracleDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                doctor = new Doctor
                                {
                                    Id = reader.GetInt32(reader.GetOrdinal("personelid")),
                                    Name = reader.GetString(reader.GetOrdinal("personelad")),
                                    Surname = reader.GetString(reader.GetOrdinal("personelsoyad")),
                                    Address = reader.GetString(reader.GetOrdinal("personeladres")),
                                    DateOfBirth = reader.GetDateTime(reader.GetOrdinal("personeldtarihi")),
                                    TCNo = reader.GetString(reader.GetOrdinal("personeltcno")),
                                    PhoneNo = reader.GetString(reader.GetOrdinal("personeltelno")),
                                    Email = reader.GetString(reader.GetOrdinal("personeleposta")),
                                    Education = reader.GetString(reader.GetOrdinal("personelogrenim")),
                                    DiplomaNo = reader.GetString(reader.GetOrdinal("personeldiplomano")),
                                    SicilNo = reader.GetString(reader.GetOrdinal("personelsicilno")),
                                    TitleId = reader.GetInt32(reader.GetOrdinal("unvanid")),
                                    ClinicId = reader.GetInt32(reader.GetOrdinal("klinikid")),
                                    Gender = reader.GetString(reader.GetOrdinal("personelcinsiyet")),
                                    Password = reader.GetString(reader.GetOrdinal("parola"))
                                };
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Doktor bilgileri alınırken bir hata oluştu: " + ex.Message);
            }

            return doctor;
        }

        public int GetDoctorIdByFullName(string fullName)
        {
            int doctorId = -1; // Varsayılan değer, doktor bulunamazsa -1 döner

            using (OracleConnection connection = new OracleConnection(SessionManager.Instance.ConnectionString))
            {
                connection.Open();

                string query = @"
            SELECT personelid
            FROM personel
            WHERE personelad || ' ' || personelsoyad = :fullName";

                OracleCommand command = new OracleCommand(query, connection);
                command.Parameters.Add(new OracleParameter("fullName", fullName));

                object result = command.ExecuteScalar();

                if (result != null && result != DBNull.Value)
                {
                    doctorId = Convert.ToInt32(result);
                }
            }

            return doctorId;
        }


        public int GetUnvanIdByName(string unvanName)
        {
            int doctorId = -1;

            string query = @"
                        SELECT u.unvanid
                        FROM UNVAN u
                        WHERE u.unvanad = :unvanName";

            try
            {
                using (OracleConnection conn = new OracleConnection(SessionManager.Instance.ConnectionString))
                {
                    conn.Open();

                    using (OracleCommand cmd = new OracleCommand(query, conn))
                    {
                        cmd.Parameters.Add(new OracleParameter("unvanName", OracleDbType.Varchar2)).Value = unvanName;

                        object result = cmd.ExecuteScalar();
                        if (result != null)
                        {
                            doctorId = Convert.ToInt32(result);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unvan ID'si alınırken bir hata oluştu: " + ex.Message);
            }

            return doctorId;
        }
        public string GetUnvanNameById(int unvanid)
        {
            string unvanad = string.Empty; 

            string query = @"
            SELECT u.unvanad
            FROM Unvan u
            WHERE u.unvanid = :unvanid";

            try
            {
                using (OracleConnection conn = new OracleConnection(SessionManager.Instance.ConnectionString))
                {
                    conn.Open();

                    using (OracleCommand cmd = new OracleCommand(query, conn))
                    {
                        cmd.Parameters.Add(new OracleParameter("unvanid", OracleDbType.Int32)).Value = unvanid;

                        using (OracleDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                string firstName = reader["unvanad"] != DBNull.Value ? reader["unvanad"].ToString() : string.Empty;
                                unvanad = firstName.Trim(); 
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Doktor adı alınırken bir hata oluştu: " + ex.Message);
            }

            return unvanad;
        }




    }

}
