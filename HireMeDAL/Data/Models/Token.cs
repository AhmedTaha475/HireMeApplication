using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HireMeDAL.Data.Models
{
   public class Token
    {
        public string token { get; set; }
        public DateTime Expiry { get; set; }
        public List<string> Roles { get; set;}

    }
}
