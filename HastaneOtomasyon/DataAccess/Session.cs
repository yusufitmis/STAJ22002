using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HastaneOtomasyon.DataAccess
{
    public static class Session
    {
        public static string ConnectionString { get; set; }
        public static string UserName { get; set; }
        public static int UserId { get; set; }
    }
}
