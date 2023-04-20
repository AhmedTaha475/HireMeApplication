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
        
        public string Proposal { get; set; }
        
        public decimal BiddingPrice { get; set; }
        
        public int PP_ID { get; set; }
        
        public string FreelancerId { get; set; }
    }
}
