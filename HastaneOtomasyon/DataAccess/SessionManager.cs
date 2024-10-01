using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HastaneOtomasyon.DataAccess
{
    public class SessionManager
    {
        private static SessionManager _instance;
        private SessionManager() {
            ConnectionString = "Data Source=//localhost:1521/TEST.yusufitmis.com;User Id=hastane;Password=123;";
            Polyclinics = new List<string>();
            doctors = new List<string>();


        }

        public static SessionManager Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new SessionManager();
                return _instance;
            }
        }

        public string ConnectionString { get; set; }
        public string UserName { get; set; }
        public string UserTc { get; set; }
        public string UserGender { get; set; }
        public string UserTelNo { get; set; }
        public string UserEposta { get; set; }
        public string UserSurname { get; set; }
        public string UserKan { get; set; }
        public string UserSosyalGuvence { get; set; }
        public string UserDTarihi { get; set; }
        public string UserFullName { get; set; }
        public string Gorev { get; set; }
        public string Ogrenim { get; set; }
        public string DiplomaNo { get; set; }


        public int UserId { get; set; }
        public string UserType { get; set; }
        public List<string> Polyclinics { get; set; }
        public List<string> doctors { get; set; }
        public void ClearSession()
        {
            UserName = null;
            UserTc = null;
            UserGender = null;
            UserTelNo = null;
            UserEposta = null;
            UserSurname = null;
            UserKan = null;
            UserSosyalGuvence = null;
            UserDTarihi = null;
            UserFullName = null;
            UserId = 0;
            UserType = null;
            Gorev = null;
            Ogrenim = null;
            DiplomaNo = null;
        }
        public void CikisYap()
        {
           
            SessionManager.Instance.ClearSession();

            
            foreach (Form form in Application.OpenForms.Cast<Form>().ToList())
            {
                if (!(form is login)) 
                {
                    form.Close();
                }
            }

            
            login loginForm = new login();
            loginForm.Show();
        }


    }
}
