using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adm.Application.Security
{
    public class Token
    {
        public string AccesToken { get; set; }
        public string RefreshToken { get; set; }
        public DateTime Expiration { get; set; }


        public const string ValidAudience = "www.adem.com";
        public const string ValidIssuer = "www.api.com";
        public const string Key = "benim şifreli anahtarım  bu olacak ";
        public const int Expire = 60;
    }
}
