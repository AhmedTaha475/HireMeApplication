using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HireMeBLL
{
    public record TokenDto
    {
        public string Token { get; set; }

        public DateTime ExpiryDate { get; set; }

        public List<string> Roles { get; set; }
    }
}
