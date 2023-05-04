using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HireMeBLL
{
    public record UpdateFreelancerMoneyDto
    {
        public int? Rank { get; set; }
        public int? Bids { get; set; }

        public decimal? TotalMoneyEarned { get; set; }

        public int? PlanId { get; set; }

        public decimal? Balance { get; set; }
    }
}
