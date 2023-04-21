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
        [Range(0, 10, ErrorMessage = "Please enter a valid rank")]
        public int? Rank { get; set; }
        [Range(0, 100, ErrorMessage = "Invalid amount of Bids")]
        public int? Bids { get; set; }

        public decimal? TotalMoneyEarned { get; set; }

        public int? PlanId { get; set; }

        public decimal? Balance { get; set; }
    }
}
