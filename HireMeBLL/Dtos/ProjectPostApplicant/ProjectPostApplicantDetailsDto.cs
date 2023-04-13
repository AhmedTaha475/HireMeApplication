using HireMeDAL;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HireMeBLL
{
    public record ProjectPostApplicantDetailsDto
    {
        [Required]
        public string Proposal { get; set; }
        [Required]
        public decimal BiddingPrice { get; set; }
        [Required]
        public int PP_ID { get; set; }
        [Required]
        public string FreelancerId { get; set; }
    }
}
