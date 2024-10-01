using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HastaneOtomasyon.DataAccess
{
    public class Defter
    {
        public class HastaBilgileri
        {
            public string TcNo { get; set; }
            public string HastaNo { get; set; }
            public string Ad { get; set; }
            public string Soyad { get; set; }
            public string KanGrubu { get; set; }
            public DateTime DogumTarihi { get; set; }
            public string Cinsiyet { get; set; }

            public string SosyalGuvence { get; set; }
        }
        public class MuayeneBilgileri
        {
            public string ProtokolNo { get; set; }
            public string SiraNo { get; set; }
        }
    }
}
