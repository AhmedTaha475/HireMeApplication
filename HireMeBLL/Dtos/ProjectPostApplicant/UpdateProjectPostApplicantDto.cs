using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HireMeBLL
{
    public record UpdateProjectPostApplicantDto
    {
        [Required]
        public string Proposal { get; set; }
        [Required]
        public decimal BiddingPrice { get; set; }
        [Required]
        public string FreelancerId { get; set; }
        public bool? Approved { get; set; }
        [Required]
        public int PP_Id { get; set; }
    }
}
