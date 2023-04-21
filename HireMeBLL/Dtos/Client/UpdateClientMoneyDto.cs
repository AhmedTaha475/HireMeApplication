using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HireMeBLL
{
    public record UpdateClientMoneyDto
    {
        public decimal? Balance { get; set; }

        public decimal? TotalMoneySpent { get; set; }

        public int? PlanId { get; set; }
    }
}
