using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{
    public class UserAccount
    {
        public long UserID { get; set; }
        public string UserName { get; set; }
        public string UserFullName { get; set; }
        public string Password { get; set; }
        public string IMEI { get; set; }
    }

    public class DocumentPunchList
    {
        public string Company { get; set; }
        public string DocStatus { get; set; }
        public long Total { get; set; }
    }

    public class LoginDTO
    {
        public long UserID { get; set; }
        public string UserName { get; set; }
        public string UserFullName { get; set; }
        public string Password { get; set; }
    }
}
